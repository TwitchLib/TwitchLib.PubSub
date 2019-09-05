using System;

namespace TwitchLib.PubSub.Events
{
    /// <inheritdoc />
    /// <summary>
    /// ViewCount arguments class.
    /// </summary>
    public class OnViewCountArgs : EventArgs
    {
        /// <summary>
        /// Server time issued by Twitch.
        /// </summary>
        public string ServerTime;
        /// <summary>
        /// Number of viewers at current time.
        /// </summary>
        public int Viewers;
    }
}
