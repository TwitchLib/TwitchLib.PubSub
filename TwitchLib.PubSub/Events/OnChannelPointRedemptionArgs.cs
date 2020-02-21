namespace TwitchLib.PubSub.Events
{
    /// <summary>Object representing the arguments for the channel points redemption event.</summary>
    public class OnChannelPointRedemptionArgs
    {
        /// <summary>Property for the redemption id.</summary>
        public string Id;
        /// <summary>Property for the redemption channel id.</summary>
        public string ChannelId;
        /// <summary>Property for the time the reward was redeemed.</summary>
        public string RedeemedAt;
        /// <summary>Property for the flag determining if this redemption skips the fulfillment queue.</summary>
        public bool ShouldRedemptionsSkipRequestQueue;

        /// <summary>Property for the redeemers user id.</summary>
        public string RedeemerId;
        /// <summary>Property for the redeemers display name.</summary>
        public string RedeemerDisplayName;

        /// <summary>Property for the unique reward id.</summary>
        public string RewardId;
        /// <summary>Property for the reward title.</summary>
        public string RewardTitle;
        /// <summary>Property for the reward description.</summary>
        public string RewardPrompt;
        /// <summary>Property for the reward image url.</summary>
        public string RewardImageUrl;
        /// <summary>Property for the reward background color.</summary>
        public string RewardBackgroundColor;

        /// <summary>Property for the reward's channel point cost.</summary>
        public int RewardCost;
        /// <summary>Property for the reward's max number of redemptions per stream.</summary>
        public int RewardMaxPerStream;

        /// <summary>Property for the flag determining if user input is required.</summary>
        public bool RewardIsUserInputRequired;
        /// <summary>Property for the flag determining if the reward is sub only.</summary>
        public bool RewardIsSubOnly;
        /// <summary>Property for the flag determining if the reward is enabled.</summary>
        public bool RewardIsEnabled;
        /// <summary>Property for the flag determining if the reward is paused.</summary>
        public bool RewardIsPaused;
        /// <summary>Property for the flag determining if the reward is in stock.</summary>
        public bool RewardIsInStock;

        /// <summary>Property for the user's input.</summary>
        public string UserInput;
    }
}
