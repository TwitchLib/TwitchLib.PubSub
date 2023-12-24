using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.HypeTrain
{
    public class Progress
    {
        [JsonProperty(PropertyName = "level")]
        public Level Level { get; protected set; }
        [JsonProperty(PropertyName = "value")]
        public int Value { get; protected set; }
        [JsonProperty(PropertyName = "goal")]
        public int Goal { get; protected set; }
        [JsonProperty(PropertyName = "total")]
        public int Total { get; protected set; }
        [JsonProperty(PropertyName = "remaining_seconds")]
        public int RemainingSeconds { get; protected set; }
    }
}
