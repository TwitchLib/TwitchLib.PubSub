using System;

namespace TwitchLib.PubSub.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Class representing arguments of custom reward updated event.
    /// </summary>
    public class OnCustomRewardUpdatedArgs : EventArgs
    {
        /// <summary>
        /// Property representing server time stamp
        /// </summary>
        public DateTime TimeStamp;
        /// <summary>
        /// Property representing title of the redeemed reward
        /// </summary>
        public string RewardTitle;
        /// <summary>
        /// Property representing prompt of the redeemed reward
        /// </summary>
        public string RewardPrompt;
        /// <summary>
        /// Property representing cost of the redeemed reward
        /// </summary>
        public int RewardCost;
    }
}
