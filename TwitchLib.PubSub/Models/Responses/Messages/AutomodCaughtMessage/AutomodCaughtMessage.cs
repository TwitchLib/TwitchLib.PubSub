using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.AutomodCaughtMessage
{
    /// <summary>
    /// Model representing the data in automod caught message
    /// Implements the <see cref="MessageData" />
    /// </summary>
    /// <seealso cref="MessageData" />
    /// <inheritdoc />
    public class AutomodCaughtMessage : AutomodQueueData
    {
        [JsonProperty(PropertyName = "content_classification")]
        public ContentClassification ContentClassification { get; protected set; }
        [JsonProperty(PropertyName = "message")]
        public Message Message { get; protected set; }
        [JsonProperty(PropertyName = "reason_code")]
        public string ReasonCode { get; protected set; }
        [JsonProperty(PropertyName = "resolver_id")]
        public string ResolverId { get; protected set; }
        [JsonProperty(PropertyName = "resolver_login")]
        public string ResolverLogin { get; protected set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; protected set; }

    }
}
