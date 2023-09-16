using System;
using System.Threading.Tasks;
using TwitchLib.PubSub.Events;

namespace TwitchLib.PubSub.Interfaces
{
    /// <summary>
    /// Interface ITwitchPubSub
    /// </summary>
    public interface ITwitchPubSub
    {
        /// <summary>
        /// Fires when a moderation event hits a user
        /// </summary>
        event EventHandler<OnAutomodCaughtUserMessage> OnAutomodCaughtUserMessage;

        /// <summary>
        /// Fires when Automod updates a held message.
        /// </summary>
        event EventHandler<OnAutomodCaughtMessageArgs> OnAutomodCaughtMessage;
        
        /// <summary>
        /// Occurs when [on ban].
        /// </summary>
        event EventHandler<OnBanArgs> OnBan;
        /// <summary>
        /// Fires when PubSub receives a bits message.
        /// </summary>
        event EventHandler<OnBitsReceivedV2Args> OnBitsReceivedV2;
        /// <summary>
        /// Fires when PubSub receives notice when the channel unlocks bit badge.
        /// </summary>
        event EventHandler<OnChannelBitsBadgeUnlockArgs> OnChannelBitsBadgeUnlock;
        /// <summary>
        /// Occurs when [on channel extension broadcast].
        /// </summary>
        event EventHandler<OnChannelExtensionBroadcastArgs> OnChannelExtensionBroadcast;
        /// <summary>
        /// Occurs when [on channel subscription].
        /// </summary>
        event EventHandler<OnChannelSubscriptionArgs> OnChannelSubscription;
        /// <summary>
        /// Occurs when [on clear].
        /// </summary>
        event EventHandler<OnClearArgs> OnClear;
        /// <summary>
        /// Occurs when [on emote only].
        /// </summary>
        event EventHandler<OnEmoteOnlyArgs> OnEmoteOnly;
        /// <summary>
        /// Occurs when [on emote only off].
        /// </summary>
        event EventHandler<OnEmoteOnlyOffArgs> OnEmoteOnlyOff;
        /// <summary>
        /// Occurs when [on follow].
        /// </summary>
        event EventHandler<OnFollowArgs> OnFollow;
        /// <summary>
        /// Occurs when [on host].
        /// </summary>
        event EventHandler<OnHostArgs> OnHost;
        /// <summary>
        /// Occurs when [on message deleted].
        /// </summary>
        event EventHandler<OnMessageDeletedArgs> OnMessageDeleted; 
        /// <summary>
        /// Occurs when [on listen response].
        /// </summary>
        event EventHandler<OnListenResponseArgs> OnListenResponse;
        /// <summary>
        /// Fires when PubSub receives notice when the channel detects low trust user.
        /// </summary>
        event EventHandler<OnLowTrustUsersArgs> OnLowTrustUsers;
        /// <summary>
        /// Occurs when [on pub sub service closed].
        /// </summary>
        event EventHandler OnPubSubServiceClosed;
        /// <summary>
        /// Occurs when [on pub sub service connected].
        /// </summary>
        event EventHandler OnPubSubServiceConnected;
        /// <summary>
        /// Occurs when [on pub sub service error].
        /// </summary>
        event EventHandler<OnPubSubServiceErrorArgs> OnPubSubServiceError;
        /// <summary>
        /// Occurs when [on R9K beta].
        /// </summary>
        event EventHandler<OnR9kBetaArgs> OnR9kBeta;
        /// <summary>
        /// Occurs when [on R9K beta off].
        /// </summary>
        event EventHandler<OnR9kBetaOffArgs> OnR9kBetaOff;
        /// <summary>
        /// Fires when PubSub receives notice when a channel cancels the raid
        /// </summary>
        event EventHandler<OnRaidCancelArgs> OnRaidCancel; 
        /// <summary>
        /// Occurs when [on stream down].
        /// </summary>
        event EventHandler<OnStreamDownArgs> OnStreamDown;
        /// <summary>
        /// Occurs when [on stream up].
        /// </summary>
        event EventHandler<OnStreamUpArgs> OnStreamUp;
        /// <summary>
        /// Occurs when [on subscribers only].
        /// </summary>
        event EventHandler<OnSubscribersOnlyArgs> OnSubscribersOnly;
        /// <summary>
        /// Occurs when [on subscribers only off].
        /// </summary>
        event EventHandler<OnSubscribersOnlyOffArgs> OnSubscribersOnlyOff;
        /// <summary>
        /// Occurs when [on timeout].
        /// </summary>
        event EventHandler<OnTimeoutArgs> OnTimeout;
        /// <summary>
        /// Occurs when [on unban].
        /// </summary>
        event EventHandler<OnUnbanArgs> OnUnban;
        /// <summary>
        /// Occurs when [on untimeout].
        /// </summary>
        event EventHandler<OnUntimeoutArgs> OnUntimeout;
        /// <summary>
        /// Occurs when [on view count].
        /// </summary>
        event EventHandler<OnViewCountArgs> OnViewCount;
        /// <summary>
        /// Occurs when [on whisper].
        /// </summary>
        event EventHandler<OnWhisperArgs> OnWhisper;
        /// <summary>
        /// Occurs when [on reward created]
        ///</summary>
        [Obsolete("This event fires on an undocumented/retired/obsolete topic.", false)]
        event EventHandler<OnCustomRewardCreatedArgs> OnCustomRewardCreated;
        /// <summary>
        /// Occurs when [on reward updated]
        ///</summary>
        [Obsolete("This event fires on an undocumented/retired/obsolete topic.", false)]
        event EventHandler<OnCustomRewardUpdatedArgs> OnCustomRewardUpdated;
        /// <summary>
        /// Occurs when [on reward deleted]
        /// </summary>
        [Obsolete("This event fires on an undocumented/retired/obsolete topic.", false)]
        event EventHandler<OnCustomRewardDeletedArgs> OnCustomRewardDeleted;
        /// <summary>
        /// Occurs when [on reward redeemed]
        /// </summary>
        [Obsolete("This event fires on an undocumented/retired/obsolete topic.", false)]
        event EventHandler<OnRewardRedeemedArgs> OnRewardRedeemed;
        /// <summary>
        /// Occurs when [on reward redeemed]
        /// </summary>
        event EventHandler<OnChannelPointsRewardRedeemedArgs> OnChannelPointsRewardRedeemed;
        /// <summary>
        /// Occurs when [on leaderboard subs].
        /// </summary>
        event EventHandler<OnLeaderboardEventArgs> OnLeaderboardSubs;
        /// <summary>
        /// Occurs when [on leaderboard bits].
        /// </summary>
        event EventHandler<OnLeaderboardEventArgs> OnLeaderboardBits;
        /// <summary>
        /// Occurs when [on raid update]
        /// </summary>
        event EventHandler<OnRaidUpdateArgs> OnRaidUpdate;
        /// <summary>
        /// Occurs when [on raid update v2]
        /// </summary>
        event EventHandler<OnRaidUpdateV2Args> OnRaidUpdateV2;
        /// <summary>
        /// Occurs when [on raid go]
        /// </summary>
        event EventHandler<OnRaidGoArgs> OnRaidGo; 
        /// <summary>
        /// Occurs when [on log].
        /// </summary>
        event EventHandler<OnLogArgs> OnLog;
        /// <summary>
        /// Occurs when [on commercial].
        /// </summary>
        event EventHandler<OnCommercialArgs> OnCommercial;
        /// <summary>
        /// Occurs when [on prediction].
        /// </summary>
        event EventHandler<OnPredictionArgs> OnPrediction;

        /// <summary>
        /// Connects this instance.
        /// </summary>
        void Connect();
        
        /// <summary>
        /// Connects this instance.
        /// </summary>
        Task ConnectAsync();
        
        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        Task DisconnectAsync();
        
        /// <summary>
        /// Listens to bits events.
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToBitsEventsV2(string channelTwitchId);
        /// <summary>
        /// Listens to extension channel broadcast messages.
        /// </summary>
        /// <param name="channelId">The channel twitch identifier.</param>
        /// <param name="extensionId">The extension identifier.</param>
        void ListenToChannelExtensionBroadcast(string channelId, string extensionId);
        /// <summary>
        /// Listens to chat moderator actions.
        /// </summary>
        /// <param name="myTwitchId">My twitch identifier.</param>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToChatModeratorActions(string myTwitchId, string channelTwitchId);
        /// <summary>
        /// Listens to follows.
        /// </summary>
        /// <param name="channelId">The channel twitch identifier.</param>
        void ListenToFollows(string channelId);
        /// <summary>
        /// Listens to subscriptions.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        void ListenToSubscriptions(string channelId);
        /// <summary>
        /// Listens to video playback.
        /// </summary>
        /// <param name="channelName">Name of the channel.</param>
        void ListenToVideoPlayback(string channelName);
        /// <summary>
        /// Listens to whispers.
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToWhispers(string channelTwitchId);
        /// <summary>
        /// Listens to rewards
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        [Obsolete("This method listens to an undocumented/retired/obsolete topic. Consider using ListenToChannelPoints()", false)]
        void ListenToRewards(string channelTwitchId);
        /// <summary>
        /// Listens to channel points.
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToChannelPoints(string channelTwitchId);
        /// <summary>
        /// Listens to leaderboards
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToLeaderboards(string channelTwitchId);
        /// <summary>
        /// Listens to raids
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToRaid(string channelTwitchId);
        /// <summary>
        /// Listens to predictions
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToPredictions(string channelTwitchId);
        /// <summary>
        /// A user’s message held by AutoMod has been approved or denied.
        /// </summary>
        /// <param name="myTwitchId">Current user identifier.</param>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToUserModerationNotifications(string myTwitchId, string channelTwitchId);
        /// <summary>
        /// Sends a request to listen to Automod queued messages in a specific channel
        /// </summary>
        /// <param name="userTwitchId">A moderator's twitch account's ID</param>
        /// <param name="channelTwitchId">Channel ID who has previous parameter's moderator</param>
        void ListenToAutomodQueue(string userTwitchId, string channelTwitchId);
        /// <summary>
        /// Message sent when a user earns a new Bits badge in a particular channel, and chooses to share the notification with chat.
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        void ListenToChannelBitsBadgeUnlocks(string channelTwitchId);
        /// <summary>
        /// The broadcaster or a moderator updates the low trust status of a user, or a new message has been sent in chat by a potential ban evader or a bans shared user.
        /// </summary>
        /// <param name="channelTwitchId">The channel twitch identifier.</param>
        /// <param name="suspiciousUser">Suspicious user identifier.</param>
        void ListenToLowTrustUsers(string channelTwitchId, string suspiciousUser);
        
        /// <summary>
        /// Sends the topics.
        /// </summary>
        /// <param name="oauth">The oauth.</param>
        /// <param name="unlisten">if set to <c>true</c> [unlisten].</param>
        void SendTopics(string oauth = null, bool unlisten = false);

        /// <summary>
        /// Sends the topics.
        /// </summary>
        /// <param name="oauth">The oauth.</param>
        /// <param name="unlisten">if set to <c>true</c> [unlisten].</param>
        Task SendTopicsAsync(string oauth = null, bool unlisten = false);
        
        /// <summary>
        /// Tests the message parser.
        /// </summary>
        /// <param name="testJsonString">The test json string.</param>
        void TestMessageParser(string testJsonString);
    }
}
