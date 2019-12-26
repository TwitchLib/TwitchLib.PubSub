using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Models.Responses
{
    /// <summary>
    /// PubSub Message model.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Topic that the message is relevant to.
        /// </summary>
        /// <value>The topic.</value>
        public string Topic { get; }
        /// <summary>
        /// Model containing data of the message.
        /// </summary>
        public readonly MessageData MessageData;

        /// <summary>
        /// PubSub Message model constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public Message(string jsonStr)
        {
            var json = JObject.Parse(jsonStr).SelectToken("data");
            Topic = json.SelectToken("topic")?.ToString();
            var encodedJsonMessage = json.SelectToken("message").ToString();
            switch (Topic?.Split('.')[0])
            {
                case "chat_moderator_actions":
                    MessageData = new ChatModeratorActions(encodedJsonMessage);
                    break;
                case "channel-bits-events-v1":
                    MessageData = new ChannelBitsEvents(encodedJsonMessage);
                    break;
                case "video-playback":
                    MessageData = new VideoPlayback(encodedJsonMessage);
                    break;
                case "whispers":
                    MessageData = new Whisper(encodedJsonMessage);
                    break;
                case "channel-subscribe-events-v1":
                    MessageData = new ChannelSubscription(encodedJsonMessage);
                    break;
                case "channel-ext-v1":
                    MessageData = new ChannelExtensionBroadcast(encodedJsonMessage);
                    break;
                case "following":
                    MessageData = new Following(encodedJsonMessage);
                    break;
                case "community-points-channel-v1":
                    MessageData = new CommunityPointsChannel(encodedJsonMessage);
                    break;
                case "leaderboard-events-v1":
                    MessageData = new LeaderboardEvents(encodedJsonMessage);
                    break;
            }
        }
    }
}
