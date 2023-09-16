using System;
using Newtonsoft.Json;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    public class BitsBadgeNotificationMessage : MessageData
    {
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; protected set; }
        
        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; protected set; }
        
        [JsonProperty(PropertyName = "channel_id")]
        public string ChannelId { get; protected set; }
        
        [JsonProperty(PropertyName = "channel_name")]
        public string ChannelName { get; protected set; }
        
        [JsonProperty(PropertyName = "badge_tier")]
        public int BadgeTier { get; protected set; }
        
        [JsonProperty(PropertyName = "chat_message")]
        public string ChatMessage { get; protected set; }
        
        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; protected set; }
    }
}