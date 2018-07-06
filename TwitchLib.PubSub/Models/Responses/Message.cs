using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Models.Responses
{
    /// <summary>PubSub Message model.</summary>
    public class Message
    {
        /// <summary>Topic that the message is relevant to.</summary>
        public string Topic { get; protected set; }
        /// <summary>Model containing data of the message.</summary>
        public readonly MessageData MessageData;

        /// <summary>PubSub Message model constructor.</summary>
        public Message(string jsonStr)
        {
            var json = JObject.Parse(jsonStr).SelectToken("data");
            Topic = json.SelectToken("topic")?.ToString();
            var encodedJsonMessage = json.SelectToken("message").ToString();
            switch (Topic?.Split('.')[0])
            {
                case "chat_moderator_actions":
                    MessageData = new ChatModeratorActionEvent(encodedJsonMessage);
                    break;
                case "channel-bits-events-v1":
                    MessageData = new ChannelBitsEvent(encodedJsonMessage);
                    break;
                case "video-playback":
                    MessageData = new VideoPlaybackEvent(encodedJsonMessage);
                    break;
                case "whispers":
                    MessageData = new WhisperEvent(encodedJsonMessage);
                    break;
                case "channel-subscribe-events-v1":
                    MessageData = new ChannelSubscriptionEvent(encodedJsonMessage);
                    break;
                case "channel-ext-v1":
                    MessageData = new ChannelExtensionBroadcastEvent(encodedJsonMessage);
                    break;
                case "following":
                    MessageData = new FollowEvent(encodedJsonMessage);
                    break;
            }
        }
    }
}
