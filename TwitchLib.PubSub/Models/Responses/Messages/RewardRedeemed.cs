using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// Model representing the data in a reward-redeemed event.
    /// Implements the <see cref="MessageData" />
    /// </summary>
    /// <seealso cref="MessageData" />
    /// <inheritdoc />
    public class RewardRedeemed : MessageData
    {
        /// <summary>
        /// Username of the sender.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; }
        /// <summary>
        /// Display name of the sender.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; }
        /// <summary>
        /// User ID of the sender.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; }
        /// <summary>
        /// Channel/User ID of where the points were redeemed.
        /// </summary>
        /// <value>The channel identifier.</value>
        public string ChannelId { get; }
        /// <summary>
        /// Time stamp of the event.
        /// </summary>
        /// <value>The time.</value>
        public string Time { get; }
        /// <summary>
        /// The amount of points redeemed.
        /// </summary>
        /// <value>The amount of points used.</value>
        public int PointsUsed { get; }
        /// <summary>
        /// Title message that accompanied the points.
        /// </summary>
        /// <value>The title message.</value>
        public string Title { get; }
        /// <summary>
        /// Prompt that accompanied the points.
        /// </summary>
        /// <value>The prompt message.</value>
        public string Prompt { get; }
        /// <summary>
        /// User input that accompanied the points.
        /// </summary>
        /// <value>The chat message.</value>
        public string UserInput { get; }

        /// <summary>
        /// RewardRedeemed model constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public RewardRedeemed(string jsonStr)
        {
            var json = JObject.Parse(jsonStr);
            Username = json.SelectToken("data").SelectToken("redemption")?.SelectToken("user")?.SelectToken("login")?.ToString();
            DisplayName = json.SelectToken("data").SelectToken("redemption")?.SelectToken("user")?.SelectToken("display_name")?.ToString();
            UserId = json.SelectToken("data").SelectToken("redemption")?.SelectToken("user")?.SelectToken("id")?.ToString();
            ChannelId = json.SelectToken("data").SelectToken("redemption")?.SelectToken("channel_id")?.ToString();
            Time = json.SelectToken("data").SelectToken("timestamp")?.ToString();
            PointsUsed = int.Parse(json.SelectToken("data").SelectToken("redemption")?.SelectToken("reward")?.SelectToken("cost").ToString());
            Title = json.SelectToken("data").SelectToken("redemption")?.SelectToken("reward")?.SelectToken("title")?.ToString();
            Prompt = json.SelectToken("data").SelectToken("redemption")?.SelectToken("reward")?.SelectToken("prompt")?.ToString();
            UserInput = json.SelectToken("data").SelectToken("redemption")?.SelectToken("user_input")?.ToString();
        }
    }
}
