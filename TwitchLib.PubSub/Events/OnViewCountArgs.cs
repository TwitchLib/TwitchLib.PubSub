﻿namespace TwitchLib.PubSub.Events
{
    /// <summary>ViewCount arguments class.</summary>
    public class OnViewCountArgs
    {
        /// <summary>Server time issued by Twitch.</summary>
        public string ServerTime;
        /// <summary>Number of viewers at current time.</summary>
        public int Viewers;
        /// <summary>The channel id associated with this event.</summary>
        public string ChannelId;
    }
}
