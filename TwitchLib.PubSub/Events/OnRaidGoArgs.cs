using System;

namespace TwitchLib.PubSub.Events
{
    public class OnRaidGoArgs : EventArgs
    {
        public int ChannelId;
        public Guid Id;
        public int TargetChannelId;
        public string TargetLogin;
        public string TargetDisplayName;
        public string TargetProfileImage;
        public int ViewerCount;
    }
}
