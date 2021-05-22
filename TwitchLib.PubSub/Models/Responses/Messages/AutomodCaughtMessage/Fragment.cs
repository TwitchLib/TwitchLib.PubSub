using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.AutomodCaughtMessage
{
    public class Fragment
    {
        [JsonProperty(PropertyName = "text")]
        public string Text;
        [JsonProperty(PropertyName = "automod")]
        public Automod Automod;
    }
}
