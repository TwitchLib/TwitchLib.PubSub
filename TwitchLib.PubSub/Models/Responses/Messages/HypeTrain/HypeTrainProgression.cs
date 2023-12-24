using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.HypeTrain
{
    public class HypeTrainProgression : HypeTrainEventData
    {
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; protected set; }
        [JsonProperty(PropertyName = "sequence_id")]
        public int SequenceId { get; protected set; }
        [JsonProperty(PropertyName = "action")]
        public string Action { get; protected set; }
        [JsonProperty(PropertyName = "source")]
        public string Source { get; protected set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; protected set; }
        [JsonProperty(PropertyName = "progress")]
        public Progress Progress {  get; protected set; }
    }
}
