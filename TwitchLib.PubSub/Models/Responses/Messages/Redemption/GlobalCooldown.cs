using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages.Redemption
{
    public class GlobalCooldown
    {
        [JsonProperty(PropertyName = "is_enabled")]
        public string IsEnabled { get; protected set; }
        [JsonProperty(PropertyName = "global_cooldown_seconds")]
        public int GlobalCooldownSeconds { get; protected set; }
    }
}
