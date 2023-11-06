using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.HypeTrain
{
    public class Level
    {
        [JsonProperty(PropertyName = "value")]
        public int Value { get; protected set; }
        [JsonProperty(PropertyName = "goal")]
        public int Goal { get; protected set; }
        [JsonProperty(PropertyName = "rewards")]
        public Reward[] Rewards { get; protected set; }
    }
}
