using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <inheritdoc />
    /// <summary>ChannelPointRedemption model constructor.</summary>
    public class ChannelPointRedemption : MessageData
    {
        /// <summary>Channel point redemption id.</summary>
        public string Id { get; protected set; }
        /// <summary>Channel id the points were redeemed at.</summary>
        public string ChannelId { get; protected set; }
        /// <summary>Time the reward was redeemed.</summary>
        public string RedeemedAt { get; protected set; }
        /// <summary>The flag that determines if the reward skips the request queue.</summary>
        public bool ShouldRedemptionsSkipRequestQueue { get; protected set; }
        /// <summary>User input when the reward was redeemed.</summary>
        public string UserInput { get; protected set; }

        /// <summary>Redeemer's user id.</summary>
        public string RedeemerId { get; protected set; }
        /// <summary>Redeemer's display name.</summary>
        public string RedeemerDisplayName { get; protected set; }

        /// <summary>The redeemed reward's id.</summary>
        public string RewardId { get; protected set; }

        /// <summary>The redeemed reward's title.</summary>
        public string RewardTitle { get; protected set; }

        /// <summary>The redeemed reward's prompt.</summary>
        public string RewardPrompt { get; protected set; }

        /// <summary>The redeemed reward's costs in channel points.</summary>
        public int RewardCost { get; protected set; }

        /// <summary>The flag that determines if user input was required.</summary>
        public bool RewardIsUserInputRequired { get; protected set; }

        /// <summary>The flag that determines if the reward is "sub only".</summary>
        public bool RewardIsSubOnly { get; protected set; }

        /// <summary>The largest image associated with the redeemed reward.</summary>
        public string RewardImageUrl { get; protected set; }

        /// <summary>The background color for the redeemed reward.</summary>
        public string RewardBackgroundColor { get; protected set; }

        /// <summary>The flag that determines if reward is enabled.</summary>
        public bool RewardIsEnabled { get; protected set; }

        /// <summary>The flag that determines if the reward is paused.</summary>
        public bool RewardIsPaused { get; protected set; }

        /// <summary>The flag that determines if the reward is in stock.</summary>
        public bool RewardIsInStock { get; protected set; }

        /// <summary>The maximum number of times this reward can be redeemed.</summary>
        public int RewardMaxPerStream { get; protected set; }

        /// <summary>ChannelPointRedemption constructor.</summary>
        /// <param name="jsonStr"></param>
        public ChannelPointRedemption(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            bool isUserInputRequired = false;
            bool isSubOnly = false;
            bool isEnabled = false;
            bool isPaused = false;
            bool isInStock = false;
            bool shouldRedemptionsSkipQueue = false;

            int cost = 0;
            int maxPerStream = 0;

            this.ChannelId = json.SelectToken("data").SelectToken("redemption").SelectToken("channel_id").ToString();
            this.RedeemedAt = json.SelectToken("data").SelectToken("redemption").SelectToken("channel_id").ToString();

            this.RedeemerDisplayName = json.SelectToken("data").SelectToken("redemption").SelectToken("user").SelectToken("display_name").ToString();
            this.RedeemerId = json.SelectToken("data").SelectToken("redemption").SelectToken("user").SelectToken("id").ToString();

            this.RewardId = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("id").ToString();
            this.RewardTitle = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("title").ToString();
            this.RewardPrompt = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("prompt").ToString();
            this.RewardBackgroundColor = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("background_color").ToString();

            if (json.SelectToken("data").SelectToken("redemption").SelectToken("user_input") != null)
            {
                this.UserInput = json.SelectToken("data").SelectToken("redemption").SelectToken("user_input").ToString();
            }

            int.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("max_per_stream").ToString(), out maxPerStream);
            int.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("cost").ToString(), out cost);
            this.RewardMaxPerStream = maxPerStream;
            this.RewardCost = cost;

            bool.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("channel_id").ToString(), out shouldRedemptionsSkipQueue);
            bool.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_user_input_required").ToString(), out isUserInputRequired);
            bool.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_sub_only").ToString(), out isSubOnly);
            bool.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_enabled").ToString(), out isEnabled);
            bool.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_paused").ToString(), out isPaused);
            bool.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_in_stock").ToString(), out isInStock);
            this.ShouldRedemptionsSkipRequestQueue = shouldRedemptionsSkipQueue;
            this.RewardIsUserInputRequired = isUserInputRequired;
            this.RewardIsSubOnly = isSubOnly;
            this.RewardIsEnabled = isEnabled;
            this.RewardIsPaused = isPaused;
            this.RewardIsInStock = isInStock;


            if (json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("image").SelectToken("url_4x") == null)
            {
                this.RewardImageUrl = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("default_image").SelectToken("url_4x").ToString();
            }
            else
            {
                this.RewardImageUrl = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("image").SelectToken("url_4x").ToString();
            }
        }
    }
}
