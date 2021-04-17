using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    public class ChannelBitsEventsV2 : MessageData
    {
        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; protected set; }
        [JsonProperty(PropertyName = "channel_name")]
        public string ChannelName { get; protected set; }
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; protected set; }
        [JsonProperty(PropertyName = "channel_id")]
        public string ChannelId { get; protected set; }
        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; protected set; }
        [JsonProperty(PropertyName = "chat_message")]
        public string ChatMessage { get; protected set; }
        [JsonProperty(PropertyName = "bits_used")]
        public int BitsUsed { get; protected set; }
        [JsonProperty(PropertyName = "total_bits_used")]
        public int TotalBitsUsed { get; protected set; }
        [JsonProperty(PropertyName = "is_anonymous")]
        public bool IsAnonymous { get; protected set; }
        [JsonProperty(PropertyName = "context")]
        public string Context { get; protected set; }
    }
}
