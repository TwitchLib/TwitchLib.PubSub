using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <inheritdoc />
    /// <summary>ChannelPointRedemption model constructor.</summary>
    public class ChannelPointRedemption : MessageData
    {
        /// <summary>Channel Points Redemption Type</summary>
        public string Type { get; protected set; }

        /// <summary>Channel Points Redemption Id</summary>
        public string Id { get; protected set; }

        /// <summary>Channel Points Redemption User Display Name</summary>
        public string DisplayName { get; protected set; }

        /// <summary>Channel Points Redemption Reward ID</summary>
        public string RewardId { get; protected set; }

        /// <summary>Channel Points Redemption Reward Title</summary>
        public string RewardTitle { get; protected set; }

        /// <summary>Channel Points Redemption Reward Prompt</summary>
        public string RewardPrompt { get; protected set; }

        /// <summary>Channel Points Redemption Reward Cost</summary>
        public int RewardCost { get; protected set; }

        /// <summary>Channel Points Redemption Is User Input Required Flag</summary>
        public bool RewardIsUserInputRequired { get; protected set; }

        /// <summary>Channel Points Redemption Is Sub Only Flag - Not Currently Used?</summary>
        public bool RewardIsSubOnly { get; protected set; }

        /// <summary>Channel Points Redemption Image URL - 4x Version</summary>
        public string RewardImageUrl { get; protected set; }

        /// <summary>Channel Points Redemption Reward Background Color</summary>
        public string RewardBackgroundColor { get; protected set; }

        /// <summary>Channel Points Redemption Reward Max Redemptions Per Stream</summary>
        public int RewardMaxPerStream { get; protected set; }

        /// <summary>Channel Points Redemption User Input</summary>
        public string UserInput { get; protected set; }

        /// <summary>ChannelPointRedemption constructor.</summary>
        /// <param name="jsonStr"></param>
        public ChannelPointRedemption(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            bool isUserInputRequired = false;
            bool isSubOnly = false;
            int cost = 0;
            int maxPerStream = 0;

            this.Type = json.SelectToken("type").ToString();
            this.DisplayName = json.SelectToken("data").SelectToken("redemption").SelectToken("user").SelectToken("display_name").ToString();
            this.RewardId = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("id").ToString();
            this.RewardTitle = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("title").ToString();
            this.RewardPrompt = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("prompt").ToString();
            this.RewardIsUserInputRequired = bool.Parse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_user_input_required").ToString());
            this.RewardIsSubOnly = bool.Parse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_sub_only").ToString());
            this.RewardBackgroundColor = json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("background_color").ToString();

            if (json.SelectToken("data").SelectToken("redemption").SelectToken("user_input") != null)
            {
                this.UserInput = json.SelectToken("data").SelectToken("redemption").SelectToken("user_input").ToString();
            }

            int.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("max_per_stream").ToString(), out maxPerStream);
            int.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("cost").ToString(), out cost);
            bool.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_user_input_required").ToString(), out isUserInputRequired);
            bool.TryParse(json.SelectToken("data").SelectToken("redemption").SelectToken("reward").SelectToken("is_sub_only").ToString(), out isSubOnly);

            this.RewardMaxPerStream = maxPerStream;
            this.RewardCost = cost;
            this.RewardIsUserInputRequired = isUserInputRequired;
            this.RewardIsSubOnly = isSubOnly;

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
