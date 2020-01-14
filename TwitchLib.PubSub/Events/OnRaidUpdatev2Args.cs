using System;

namespace TwitchLib.PubSub.Events
{
    public class OnRaidUpdateV2Args : EventArgs
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
