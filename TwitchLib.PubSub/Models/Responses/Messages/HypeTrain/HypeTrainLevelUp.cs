using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.HypeTrain
{
    public class HypeTrainLevelUp : HypeTrainEventData
    {
        [JsonProperty(PropertyName = "time_to_expire")]
        public long TimeToExpire { get; protected set; }
        [JsonProperty(PropertyName = "progress")]
        public Progress Progress { get; protected set; }
    }
}
