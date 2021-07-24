using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.PubSub.Models.Responses.Messages.UserModerationNotifications;
using TwitchLib.PubSub.Models.Responses.Messages.UserModerationNotificationsTypes;

namespace TwitchLib.PubSub.Events
{
    public class OnAutomodCaughtUserMessage
    {
        /// <summary>
        /// Details about the caught message
        /// </summary>
        public AutomodCaughtMessage AutomodCaughtMessage;
        /// <summary>
        /// The ID of the channel that this event fired from.
        /// </summary>
        public string ChannelId;
        /// <summary>
        /// The ID of the user that this event fired from.
        /// </summary>
        public string UserId;
    }
}
