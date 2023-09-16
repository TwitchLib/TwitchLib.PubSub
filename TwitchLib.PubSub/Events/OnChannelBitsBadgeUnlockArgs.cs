using System;
using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Events
{
    public class OnChannelBitsBadgeUnlockArgs : EventArgs
    {
        /// <summary>
        /// The subscription
        /// </summary>
        public BitsBadgeNotificationMessage BitsBadgeUnlocks;

        /// <summary>
        /// The channel ID the event came from
        /// </summary>
        public string ChannelId;
    }
}