using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.AutomodCaughtMessage
{
    public class Sender
    {
        [JsonProperty(PropertyName = "user_id")]
        public string UserId;
        [JsonProperty(PropertyName = "login")]
        public string Login;
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName;
    }
}
