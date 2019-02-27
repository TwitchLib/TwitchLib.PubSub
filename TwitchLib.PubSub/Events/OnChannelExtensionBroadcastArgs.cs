using System.Collections.Generic;

namespace TwitchLib.PubSub.Events
{
    /// <summary>
    /// Class OnChannelExtensionBroadcastArgs.
    /// </summary>
    public class OnChannelExtensionBroadcastArgs
    {
        /// <summary>
        /// Property containing the payload send to the specified extension on the specified channel.
        /// </summary>
        public List<string> Messages;
    }
}
