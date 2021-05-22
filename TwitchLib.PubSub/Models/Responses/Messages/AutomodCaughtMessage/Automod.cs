using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.AutomodCaughtMessage
{
    public class Automod
    {
        [JsonProperty(PropertyName = "topics")]
        public Dictionary<string, int> Topics;
    }
}
