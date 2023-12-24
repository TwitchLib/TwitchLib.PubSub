using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.HypeTrain
{
    public class Reward
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; protected set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; protected set; }
        [JsonProperty(PropertyName = "group_id")]
        public string GroupId { get; protected set; }
        [JsonProperty(PropertyName = "reward_level")]
        public int RewardLevel { get; protected set; }
    }
}
