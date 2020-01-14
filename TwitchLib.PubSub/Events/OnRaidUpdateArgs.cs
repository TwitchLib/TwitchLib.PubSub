using System;

namespace TwitchLib.PubSub.Events
{
    public class OnRaidUpdateArgs : EventArgs
    {
        public int ChannelId;
        public Guid Id;
        public int TargetChannelId;
        public DateTime AnnounceTime;
        public DateTime RaidTime;
        public int RemainingDurationSeconds;
        public int ViewerCount;
    }
}
