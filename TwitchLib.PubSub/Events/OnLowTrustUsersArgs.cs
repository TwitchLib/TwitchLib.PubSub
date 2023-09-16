using System;
using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Events
{
    public class OnLowTrustUsersArgs : EventArgs
    {
        /// <summary>
        /// The subscription
        /// </summary>
        public LowTrustUsers LowTrustUsers;

        /// <summary>
        /// The channel ID the event came from
        /// </summary>
        public string ChannelId;
    }
}