using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.UserModerationNotificationsTypes
{
    public class AutomodCaughtMessage : UserModerationNotificationsData
    {
        [JsonProperty(PropertyName = "message_id")]
        public string MessageId { get; protected set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; protected set; }
    }
}
