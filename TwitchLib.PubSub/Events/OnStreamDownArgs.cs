using System;

namespace TwitchLib.PubSub.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Class representing stream going down event.
    /// </summary>
    public class OnStreamDownArgs : EventArgs
    {
        /// <summary>
        /// Property representing the server time of event.
        /// </summary>
        public string ServerTime;
    }
}
