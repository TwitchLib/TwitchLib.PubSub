using Newtonsoft.Json;
using System;

namespace TwitchLib.PubSub.Models.Responses.Messages.Redemption
{
    public class Reward
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; protected set; }
        [JsonProperty(PropertyName = "channel_id")]
        public string ChannelId { get; protected set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; protected set; }
        [JsonProperty(PropertyName = "prompt")]
        public string Prompt { get; protected set; }
        [JsonProperty(PropertyName = "cost")]
        public int Cost { get; protected set; }
        [JsonProperty(PropertyName = "is_user_input_required")]
        public bool IsUserInputRequired { get; protected set; }
        [JsonProperty(PropertyName = "is_sub_only")]
        public bool IsSubOnly { get; protected set; }
        [JsonProperty(PropertyName = "image")]
        public RedemptionImage Image { get; protected set; }
        [JsonProperty(PropertyName = "default_image")]
        public RedemptionImage DefaultImage { get; protected set; }
        [JsonProperty(PropertyName = "background_color")]
        public string BackgroundColor { get; protected set; }
        [JsonProperty(PropertyName = "is_enabled")]
        public bool IsEnabled { get; protected set; }
        [JsonProperty(PropertyName = "is_paused")]
        public bool IsPaused { get; protected set; }
        [JsonProperty(PropertyName = "is_in_stock")]
        public bool IsInStock { get; protected set; }
        [JsonProperty(PropertyName = "max_per_stream")]
        public MaxPerStream MaxPerStream { get; protected set; }
        [JsonProperty(PropertyName = "should_redemptions_skip_request_queue")]
        public bool ShouldRedemptionsSkipRequestQueue { get; protected set; }
        [JsonProperty(PropertyName = "template_id")]
        public string TemplateId { get; protected set; }
        [JsonProperty(PropertyName = "updated_for_indicator_at")]
        public DateTime UpdatedForIndicatorAt { get; protected set; }
        [JsonProperty(PropertyName = "max_per_user_per_stream")]
        public MaxPerUserPerStream MaxPerUserPerStream { get; protected set; }
        [JsonProperty(PropertyName = "global_cooldown")]
        public GlobalCooldown GlobalCooldown { get; protected set; }
        [JsonProperty(PropertyName = "cooldown_expires_at")]
        public DateTime? CooldownExpiresAt { get; protected set; }
    }
}
