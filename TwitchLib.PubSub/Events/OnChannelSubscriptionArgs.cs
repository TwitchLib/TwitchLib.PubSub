using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Events
{
    /// <summary>
    /// Class OnChannelSubscriptionArgs.
    /// </summary>
    public class OnChannelSubscriptionArgs
    {
        /// <summary>
        /// The subscription
        /// </summary>
        public ChannelSubscription Subscription;

        /// <summary>
        /// The channel ID the event came from
        /// </summary>
        public string ChannelId;
    }
}
