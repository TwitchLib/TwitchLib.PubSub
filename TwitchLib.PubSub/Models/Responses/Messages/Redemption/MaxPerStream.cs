using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.Redemption
{
    public class MaxPerStream
    {
        [JsonProperty(PropertyName = "is_enabled")]
        public bool IsEnabled { get; protected set; }
        [JsonProperty(PropertyName = "max_per_stream")]
        public int MaxPerStreamValue { get; protected set; }
    }
}
