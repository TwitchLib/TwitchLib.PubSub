using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Events
{
    public class OnFollowArgs
    {
        public string FollowedChannelId;
        public string DisplayName;
        public string Username;
        public string UserId;
    }
}
