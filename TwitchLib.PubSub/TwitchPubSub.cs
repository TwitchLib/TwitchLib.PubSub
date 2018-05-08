using System;
using System.Linq;
using System.Timers;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using WebSocket4Net;
using SuperSocket.ClientEngine;
using TwitchLib.PubSub.Events;
using TwitchLib.PubSub.Models.Responses.Messages;
using TwitchLib.PubSub.Enums;
using TwitchLib.PubSub.Models;
using System.Net;
using SuperSocket.ClientEngine.Proxy;
using Microsoft.Extensions.Logging;
using TwitchLib.PubSub.Interfaces;

namespace TwitchLib.PubSub
{
    /// <summary>Class represneting interactions with the Twitch PubSub</summary>
    public class TwitchPubSub : ITwitchPubSub
    {
        private readonly WebSocket _socket;
        private readonly List<PreviousRequest> _previousRequests = new List<PreviousRequest>();
        private readonly ILogger<TwitchPubSub> _logger;
        private readonly Timer _pingTimer = new Timer();
        private readonly List<string> _topicList = new List<string>();

        #region Events
        /// <summary>Fires when PubSub Service is connected.</summary>
        public event EventHandler OnPubSubServiceConnected;
        /// <summary>Fires when PubSub Service has an error.</summary>
        public event EventHandler<OnPubSubServiceErrorArgs> OnPubSubServiceError;
        /// <summary>Fires when PubSub Service is closed.</summary>
        public event EventHandler OnPubSubServiceClosed;
        /// <summary>Fires when PubSub receives any response.</summary>
        public event EventHandler<OnListenResponseArgs> OnListenResponse;
        /// <summary>Fires when PubSub receives notice a viewer gets a timeout.</summary>
        public event EventHandler<OnTimeoutArgs> OnTimeout;
        /// <summary>Fires when PubSub receives notice a viewer gets banned.</summary>
        public event EventHandler<OnBanArgs> OnBan;
        /// <summary>Fires when PubSub receives notice a viewer gets unbanned.</summary>
        public event EventHandler<OnUnbanArgs> OnUnban;
        /// <summary>Fires when PubSub receives notice a viewer gets a timeout removed.</summary>
        public event EventHandler<OnUntimeoutArgs> OnUntimeout;
        /// <summary>Fires when PubSub receives notice that the channel being listened to is hosting another channel.</summary>
        public event EventHandler<OnHostArgs> OnHost;
        /// <summary>Fires when PubSub receives notice that Sub-Only Mode gets turned on.</summary>
        public event EventHandler<OnSubscribersOnlyArgs> OnSubscribersOnly;
        /// <summary>Fires when PubSub receives notice that Sub-Only Mode gets turned off.</summary>
        public event EventHandler<OnSubscribersOnlyOffArgs> OnSubscribersOnlyOff;
        /// <summary>Fires when PubSub receives notice that chat gets cleared.</summary>
        public event EventHandler<OnClearArgs> OnClear;
        /// <summary>Fires when PubSub receives notice that Emote-Only Mode gets turned on.</summary>
        public event EventHandler<OnEmoteOnlyArgs> OnEmoteOnly;
        /// <summary>Fires when PubSub receives notice that Emote-Only Mode gets turned off.</summary>
        public event EventHandler<OnEmoteOnlyOffArgs> OnEmoteOnlyOff;
        /// <summary>Fires when PubSub receives notice that the chat option R9kBeta gets turned on.</summary>
        public event EventHandler<OnR9kBetaArgs> OnR9kBeta;
        /// <summary>Fires when PubSub receives notice that the chat option R9kBeta gets turned off.</summary>
        public event EventHandler<OnR9kBetaOffArgs> OnR9kBetaOff;
        /// <summary>Fires when PubSub receives notice of a bit donation.</summary>
        public event EventHandler<OnBitsReceivedArgs> OnBitsReceived;
        /// <summary>Fires when PubSub receives notice of a commerce transaction.</summary>
        public event EventHandler<OnChannelCommerceReceivedArgs> OnChannelCommerceReceived;
        /// <summary>Fires when PubSub receives notice that the stream of the channel being listened to goes online.</summary>
        public event EventHandler<OnStreamUpArgs> OnStreamUp;
        /// <summary>Fires when PubSub receives notice that the stream of the channel being listened to goes offline.</summary>
        public event EventHandler<OnStreamDownArgs> OnStreamDown;
        /// <summary>Fires when PubSub receives notice view count has changed.</summary>
        public event EventHandler<OnViewCountArgs> OnViewCount;
        /// <summary>Fires when PubSub receives a whisper.</summary>
        public event EventHandler<OnWhisperArgs> OnWhisper;
        /// <summary>Fires when PubSub receives notice when the channel being listened to gets a subscription.</summary>
        public event EventHandler<OnChannelSubscriptionArgs> OnChannelSubscription;
        /// <summary>Fires when PubSub receives a message sent to the specified extension on the specified channel.</summary>
        public event EventHandler<OnChannelExtensionBroadcastArgs> OnChannelExtensionBroadcast;
        /// <summary>Fires when PubSub receives notice when a user follows the designated channel.</summary>
        public event EventHandler<OnFollowArgs> OnFollow;
        #endregion

        /// <summary>
        /// Constructor for a client that interface's with Twitch's PubSub system.
        /// </summary>
        /// <param name="logger">Optional ILogger param to enable logging</param>
        /// <param name="proxy">Optional IPEndpoint param to enable proxy support</param>
        public TwitchPubSub(ILogger<TwitchPubSub> logger = null, EndPoint proxy = null)
        {
            _logger = logger;
            _socket = new WebSocket("wss://pubsub-edge.twitch.tv");
            _socket.Opened += Socket_OnConnected;
            _socket.Error += OnError;
            _socket.MessageReceived += OnMessage;
            _socket.Closed += Socket_OnDisconnected;

            if (proxy != null)
                _socket.Proxy = new HttpConnectProxy(proxy);
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            _logger?.LogError($"Error in PubSub Websocket connection occured! Exception: {e.Exception}");
            OnPubSubServiceError?.Invoke(this, new OnPubSubServiceErrorArgs { Exception = e.Exception });
        }

        private void OnMessage(object sender, MessageReceivedEventArgs e)
        {
            _logger?.LogDebug($"Received Websocket Message: {e.Message}");
            ParseMessage(e.Message);
        }

        private void Socket_OnDisconnected(object sender, EventArgs e)
        {
            _logger?.LogWarning("PubSub Websocket connection closed");
            _pingTimer.Stop();
            OnPubSubServiceClosed?.Invoke(this, null);
        }

        private void Socket_OnConnected(object sender, EventArgs e)
        {
            _logger?.LogInformation("PubSub Websocket connection established");
            _pingTimer.Interval = 180000;
            _pingTimer.Elapsed += PingTimerTick;
            _pingTimer.Start();
            OnPubSubServiceConnected?.Invoke(this, null);
        }

        private void PingTimerTick(object sender, ElapsedEventArgs e)
        {
            var data = new JObject(
                new JProperty("type", "PING")
            );
            _socket.Send(data.ToString());
        }

        private void ParseMessage(string message)
        {
            var type = JObject.Parse(message).SelectToken("type")?.ToString();

            switch (type?.ToLower())
            {
                case "response":
                    var resp = new Models.Responses.Response(message);
                    if (_previousRequests.Count != 0)
                    {
                        foreach (var request in _previousRequests)
                        {
                            if (string.Equals(request.Nonce, resp.Nonce, StringComparison.CurrentCultureIgnoreCase))
                            {
                                OnListenResponse?.Invoke(this, new OnListenResponseArgs { Response = resp, Topic = request.Topic, Successful = resp.Successful });
                            }
                        }
                        return;
                    }
                    break;
                case "message":
                    var msg = new Models.Responses.Message(message);
                    switch (msg.Topic.Split('.')[0])
                    {
                        case "channel-subscribe-events-v1":
                            var subscription = msg.MessageData as ChannelSubscription;
                            OnChannelSubscription?.Invoke(this, new OnChannelSubscriptionArgs { Subscription = subscription });
                            return;
                        case "whispers":
                            var whisper = (Whisper)msg.MessageData;
                            OnWhisper?.Invoke(this, new OnWhisperArgs { Whisper = whisper });
                            return;
                        case "chat_moderator_actions":
                            var cma = msg.MessageData as ChatModeratorActions;
                            var reason = "";
                            switch (cma?.ModerationAction.ToLower())
                            {
                                case "timeout":
                                    if (cma.Args.Count > 2)
                                        reason = cma.Args[2];
                                    OnTimeout?.Invoke(this, new OnTimeoutArgs
                                    {
                                        TimedoutBy = cma.CreatedBy,
                                        TimedoutById = cma.CreatedByUserId,
                                        TimedoutUserId = cma.TargetUserId,
                                        TimeoutDuration = TimeSpan.FromSeconds(int.Parse(cma.Args[1])),
                                        TimeoutReason = reason,
                                        TimedoutUser = cma.Args[0]
                                    });
                                    return;
                                case "ban":
                                    if (cma.Args.Count > 1)
                                        reason = cma.Args[1];
                                    OnBan?.Invoke(this, new OnBanArgs { BannedBy = cma.CreatedBy, BannedByUserId = cma.CreatedByUserId, BannedUserId = cma.TargetUserId, BanReason = reason, BannedUser = cma.Args[0] });
                                    return;
                                case "unban":
                                    OnUnban?.Invoke(this, new OnUnbanArgs { UnbannedBy = cma.CreatedBy, UnbannedByUserId = cma.CreatedByUserId, UnbannedUserId = cma.TargetUserId });
                                    return;
                                case "untimeout":
                                    OnUntimeout?.Invoke(this, new OnUntimeoutArgs { UntimeoutedBy = cma.CreatedBy, UntimeoutedByUserId = cma.CreatedByUserId, UntimeoutedUserId = cma.TargetUserId });
                                    return;
                                case "host":
                                    OnHost?.Invoke(this, new OnHostArgs { HostedChannel = cma.Args[0], Moderator = cma.CreatedBy });
                                    return;
                                case "subscribers":
                                    OnSubscribersOnly?.Invoke(this, new OnSubscribersOnlyArgs { Moderator = cma.CreatedBy });
                                    return;
                                case "subscribersoff":
                                    OnSubscribersOnlyOff?.Invoke(this, new OnSubscribersOnlyOffArgs { Moderator = cma.CreatedBy });
                                    return;
                                case "clear":
                                    OnClear?.Invoke(this, new OnClearArgs { Moderator = cma.CreatedBy });
                                    return;
                                case "emoteonly":
                                    OnEmoteOnly?.Invoke(this, new OnEmoteOnlyArgs { Moderator = cma.CreatedBy });
                                    return;
                                case "emoteonlyoff":
                                    OnEmoteOnlyOff?.Invoke(this, new OnEmoteOnlyOffArgs { Moderator = cma.CreatedBy });
                                    return;
                                case "r9kbeta":
                                    OnR9kBeta?.Invoke(this, new OnR9kBetaArgs { Moderator = cma.CreatedBy });
                                    return;
                                case "r9kbetaoff":
                                    OnR9kBetaOff?.Invoke(this, new OnR9kBetaOffArgs { Moderator = cma.CreatedBy });
                                    return;

                            }
                            break;
                        case "channel-bits-events-v1":
                            if (msg.MessageData is ChannelBitsEvents cbe)
                                OnBitsReceived?.Invoke(this, new OnBitsReceivedArgs
                                {
                                    BitsUsed = cbe.BitsUsed,
                                    ChannelId = cbe.ChannelId,
                                    ChannelName = cbe.ChannelName,
                                    ChatMessage = cbe.ChatMessage,
                                    Context = cbe.Context,
                                    Time = cbe.Time,
                                    TotalBitsUsed = cbe.TotalBitsUsed,
                                    UserId = cbe.UserId,
                                    Username = cbe.Username
                                });
                            return;
                        case "channel-commerce-events-v1":
                            if (msg.MessageData is ChannelCommerceEvents cce)
                                OnChannelCommerceReceived?.Invoke(this, new OnChannelCommerceReceivedArgs
                                {

                                    Username = cce.Username,
                                    DisplayName = cce.DisplayName,
                                    ChannelName = cce.ChannelName,
                                    UserId = cce.UserId,
                                    ChannelId = cce.ChannelId,
                                    Time = cce.Time,
                                    ItemImageURL = cce.ItemImageURL,
                                    ItemDescription = cce.ItemDescription,
                                    SupportsChannel = cce.SupportsChannel,
                                    PurchaseMessage = cce.PurchaseMessage
                                });
                            return;
                        case "channel-ext-v1":
                            var cEB = msg.MessageData as ChannelExtensionBroadcast;
                            OnChannelExtensionBroadcast?.Invoke(this, new OnChannelExtensionBroadcastArgs { Messages = cEB.Messages });
                            break;
                        case "video-playback":
                            var vP = msg.MessageData as VideoPlayback;
                            switch (vP?.Type)
                            {
                                case VideoPlaybackType.StreamDown:
                                    OnStreamDown?.Invoke(this, new OnStreamDownArgs { ServerTime = vP.ServerTime });
                                    return;
                                case VideoPlaybackType.StreamUp:
                                    OnStreamUp?.Invoke(this, new OnStreamUpArgs { PlayDelay = vP.PlayDelay, ServerTime = vP.ServerTime });
                                    return;
                                case VideoPlaybackType.ViewCount:
                                    OnViewCount?.Invoke(this, new OnViewCountArgs { ServerTime = vP.ServerTime, Viewers = vP.Viewers });
                                    return;
                            }
                            break;
                        case "following":
                            var f = msg.MessageData as Following;
                            f.FollowedChannelId = msg.Topic.Split('.')[1];
                            OnFollow?.Invoke(this, new OnFollowArgs { FollowedChannelId = f.FollowedChannelId, DisplayName = f.DisplayName, UserId = f.UserId, Username = f.Username });
                            break;
                    }
                    break;
            }
            UnaccountedFor(message);
        }

        private static readonly Random Random = new Random();
        private static string GenerateNonce()
        {
            return new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 8)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        private void ListenToTopic(string topic)
        {
            _topicList.Add(topic);
        }

        public void SendTopics(string oauth = null, bool unlisten = false)
        {
            if (oauth != null && oauth.Contains("oauth:"))
            {
                oauth = oauth.Replace("oauth:", "");
            }

            var nonce = GenerateNonce();

            var topics = new JArray();
            foreach (var val in _topicList)
            {
                _previousRequests.Add(new PreviousRequest(nonce, PubSubRequestType.ListenToTopic, val));
                topics.Add(new JValue(val));
            }

            var jsonData = new JObject(
                new JProperty("type", !unlisten ? "LISTEN" : "UNLISTEN"),
                new JProperty("nonce", nonce),
                new JProperty("data",
                    new JObject(
                        new JProperty("topics", topics)
                        )
                    )
                );
            if (oauth != null)
            {
                ((JObject)jsonData.SelectToken("data")).Add(new JProperty("auth_token", oauth));
            }

            _socket.Send(jsonData.ToString());

            _topicList.Clear();
        }

        private void UnaccountedFor(string message)
        {
            _logger?.LogInformation($"[TwitchPubSub] {message}");
        }

        #region Listeners
        /// <summary>
        /// Sends a request to listenOn follows coming into a specified channel.
        /// </summary>
        /// <param name="channelTwitchId">Channel ID to watch for new followers on.</param>
        public void ListenToFollows(string channelId)
        {
            ListenToTopic($"following.{channelId}");
        }

        /// <summary>
        /// Sends a request to listenOn timeouts and bans in a specific channel
        /// </summary>
        /// <param name="myTwitchId">A moderator's twitch acount's ID (can be fetched from TwitchApi)</param>
        /// <param name="channelTwitchId">Channel ID who has previous parameter's moderator (can be fetched from TwitchApi)</param>
        public void ListenToChatModeratorActions(string myTwitchId, string channelTwitchId)
        {
            ListenToTopic($"chat_moderator_actions.{myTwitchId}.{channelTwitchId}");
        }

        /// <summary>
        /// Sends a request to ListenOn EBS broadcasts sent to a specific extension on a specific channel.
        /// </summary>
        /// <param name="channelId">Id of the channel that the extension lives on.</param>
        /// <param name="extensionId"></param>
        public void ListenToChannelExtensionBroadcast(string channelId, string extensionId)
        {
            ListenToTopic($"channel-ext-v1.{channelId}-{extensionId}-broadcast");
        }

        /// <summary>
        /// Sends request to listenOn bits events in specific channel
        /// </summary>
        /// <param name="channelTwitchId">Channel Id of channel to listen to bits on (can be fetched from TwitchApi)</param>
        public void ListenToBitsEvents(string channelTwitchId)
        {
            ListenToTopic($"channel-bits-events-v1.{channelTwitchId}");
        }

        /// <summary>
        /// Sends request to listenOn channel commerce events in specific channel
        /// </summary>
        /// <param name="channelName">Name of channel to listen to commerce events in.</param>
        public void ListenToCommerce(string channelName)
        {
            ListenToTopic($"channel-commerce-events-v1.{channelName}");
        }
        
        /// <summary>
        /// Sends request to listenOn video playback events in specific channel
        /// </summary>
        /// <param name="channelName">Name of channel to listen to playback events in.</param>
        public void ListenToVideoPlayback(string channelName)
        {
            ListenToTopic($"video-playback.{channelName}");
        }

        /// <summary>
        /// Sends request to listen to whispers from specific channel.
        /// </summary>
        /// <param name="channelTwitchId">Channel to listen to whispers on.</param>
        public void ListenToWhispers(string channelTwitchId)
        {
            ListenToTopic($"whispers.{channelTwitchId}");
        }

        /// <summary>
        /// Sends request to listen to channel subscriptions.
        /// </summary>
        /// <param name="channelId">Id of the channel to listen to.</param>
        public void ListenToSubscriptions(string channelId)
        {
            ListenToTopic($"channel-subscribe-events-v1.{channelId}");
        }
        #endregion

        /// <summary>
        /// Method to connect to Twitch's PubSub service. You MUST listen toOnConnected event and listen to a Topic within 15 seconds of connecting (or be disconnected)
        /// </summary>
        public void Connect()
        {
            _socket.Open();
        }

        /// <summary>
        /// What do you think it does? :)
        /// </summary>
        public void Disconnect()
        {
            _socket.Close();
        }

        /// <summary>
        /// This method will send passed json text to the message parser in order to allow forOn-demand parser testing.
        /// </summary>
        /// <param name="testJsonString"></param>
        public void TestMessageParser(string testJsonString)
        {
            ParseMessage(testJsonString);
        }
    }
}
