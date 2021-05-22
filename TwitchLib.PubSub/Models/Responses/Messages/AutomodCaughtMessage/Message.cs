using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.AutomodCaughtMessage
{
    public class Message
    {
        [JsonProperty(PropertyName = "content")]
        public Content Content;
        [JsonProperty(PropertyName = "id")]
        public string Id;
        [JsonProperty(PropertyName = "sender")]
        public Sender Sender;
        [JsonProperty(PropertyName = "sent_at")]
        public DateTime SentAt;
    }
}
