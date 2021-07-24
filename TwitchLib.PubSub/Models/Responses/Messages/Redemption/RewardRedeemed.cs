using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.Redemption
{
    public class RewardRedeemed : ChannelPointsData
    {
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; protected set; }
        [JsonProperty(PropertyName = "redemption")]
        public Redemption Redemption { get; protected set; }
    }
}
