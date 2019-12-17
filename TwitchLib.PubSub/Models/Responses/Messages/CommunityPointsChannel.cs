using System;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// CommunityPointsChannel model constructor.
    /// Implements the <see cref="MessageData" />
    /// </summary>
    /// <seealso cref="MessageData" />
    /// <inheritdoc />
    public class CommunityPointsChannel : MessageData
    {
        /// <summary>
        /// Community points channel type
        /// </summary>
        /// <value>The type.</value>
        public CommunityPointsChannelType Type;
        /// <summary>
        /// Server time stamp
        /// </summary>
        /// <value>The server DateTime.</value>
        public DateTime TimeStamp;
        /// <summary>
        /// Channel identifier.
        /// </summary>
        /// <value>The channel identifier.</value>
        public string ChannelId;
        /// <summary>
        /// Login value associated.
        /// </summary>
        /// <value>The login name.</value>
        public string Login { get; protected set; }
        /// <summary>
        /// Display name found in chat.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; protected set; }
        /// <summary>
        /// Custom reward message of the user
        /// </summary>
        /// <value>The reward message.</value>
        public string Message { get; protected set; }
        /// <summary>
        /// Reward title
        /// </summary>
        /// <value>The reward title.</value>
        public string RewardTitle { get; protected set; }
        /// <summary>
        /// Reward prompt, the text thats been shown in the chat
        /// </summary>
        /// <value></value>
        public string RewardPrompt { get; protected set; }
        /// <summary>
        /// Reward cost
        /// </summary>
        /// <value>The reward cost.</value>
        public int RewardCost { get; protected set; }

        /// <summary>
        /// CommunityPointsChannel constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public CommunityPointsChannel(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            switch (json.SelectToken("type").ToString())
            {
                case "reward-redeemed":
                    Type = CommunityPointsChannelType.RewardRedeemed;
                    break;
                case "custom-reward-updated":
                    Type = CommunityPointsChannelType.CustomRewardUpdated;
                    break;
            }

            TimeStamp = DateTime.Parse(json.SelectToken("data.timestamp").ToString());

            switch (Type)
            {
                case CommunityPointsChannelType.RewardRedeemed:
                    ChannelId = json.SelectToken("data.redemption.channel_id").ToString();
                    Login = json.SelectToken("data.redemption.user.login").ToString();
                    DisplayName = json.SelectToken("data.redemption.user.display_name").ToString();
                    RewardTitle = json.SelectToken("data.redemption.reward.title").ToString();
                    RewardPrompt = json.SelectToken("data.redemption.reward.prompt").ToString();
                    RewardCost = int.Parse(json.SelectToken("data.redemption.reward.cost").ToString());
                    Message = json.SelectToken("data.user_input")?.ToString();
                    break;
                case CommunityPointsChannelType.CustomRewardUpdated:
                    ChannelId = json.SelectToken("data.updated_reward.channel_id").ToString();
                    RewardTitle = json.SelectToken("data.updated_reward.title").ToString();
                    RewardPrompt = json.SelectToken("data.updated_reward.prompt").ToString();
                    RewardCost = int.Parse(json.SelectToken("data.updated_reward.cost").ToString());
                    break;
            }
        }
    }
}
