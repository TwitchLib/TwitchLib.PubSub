namespace TwitchLib.PubSub.Events
{
    /// <summary>Object representing the arguments for the channel points redemption event.</summary>
    public class OnChannelPointsRedemptionArgs
    {
        /// <summary>Property for the redemption type.</summary>
        public string Type;
        /// <summary>Property for the redemption id.</summary>
        public string Id;
        /// <summary>Property for the redeemers Twitch display name.</summary>
        public string DisplayName;

        /// <summary>Property for the unique reward id.</summary>
        public string RewardId;
        /// <summary>Property for the reward title.</summary>
        public string RewardTitle;
        /// <summary>Property for the reward description.</summary>
        public string RewardPrompt;
        /// <summary>Property for the reward's channel point cost.</summary>
        public int RewardCost;
        /// <summary>Property for the reward's max number of redemptions per stream.</summary>
        public int RewardMaxPerStream;
        /// <summary>Property for the flag determining if user input is required.</summary>
        public bool RewardIsUserInputRequired;
        /// <summary>Property for the flag determining if the reward is sub only.</summary>
        public bool RewardIsSubOnly;

        /// <summary>Property for the user's input.</summary>
        public string UserInput;
    }
}
