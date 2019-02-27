using Newtonsoft.Json.Linq;
using System;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// ChatModeratorActions model.
    /// Implements the <see cref="TwitchLib.PubSub.Models.Responses.Messages.MessageData" />
    /// </summary>
    /// <seealso cref="TwitchLib.PubSub.Models.Responses.Messages.MessageData" />
    /// <inheritdoc />
    public class ChannelSubscription : MessageData
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; protected set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; protected set; }
        /// <summary>
        /// Gets or sets the name of the recipient.
        /// </summary>
        /// <value>The name of the recipient.</value>
        public string RecipientName { get; protected set; }
        /// <summary>
        /// Gets or sets the display name of the recipient.
        /// </summary>
        /// <value>The display name of the recipient.</value>
        public string RecipientDisplayName { get; protected set; }
        /// <summary>
        /// Gets or sets the name of the channel.
        /// </summary>
        /// <value>The name of the channel.</value>
        public string ChannelName { get; protected set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; protected set; }
        /// <summary>
        /// Gets or sets the channel identifier.
        /// </summary>
        /// <value>The channel identifier.</value>
        public string ChannelId { get; protected set; }
        /// <summary>
        /// Gets or sets the recipient identifier.
        /// </summary>
        /// <value>The recipient identifier.</value>
        public string RecipientId { get; protected set; }
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time { get; protected set; }
        /// <summary>
        /// Gets or sets the subscription plan.
        /// </summary>
        /// <value>The subscription plan.</value>
        public Enums.SubscriptionPlan SubscriptionPlan { get; protected set; }
        /// <summary>
        /// Gets or sets the name of the subscription plan.
        /// </summary>
        /// <value>The name of the subscription plan.</value>
        public string SubscriptionPlanName { get; protected set; }
        /// <summary>
        /// Gets or sets the months.
        /// </summary>
        /// <value>The months.</value>
        public int Months { get; protected set; }
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public string Context { get; protected set; }
        /// <summary>
        /// Gets or sets the sub message.
        /// </summary>
        /// <value>The sub message.</value>
        public SubMessage SubMessage { get; protected set; }

        /// <summary>
        /// ChatModeratorActions model constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ChannelSubscription(string jsonStr)
        {
            JToken message = JObject.Parse(jsonStr);
            Username = message.SelectToken("user_name")?.ToString();
            DisplayName = message.SelectToken("display_name")?.ToString();
            RecipientName = message.SelectToken("recipient_user_name")?.ToString();
            RecipientDisplayName = message.SelectToken("recipient_display_name")?.ToString();
            ChannelName = message.SelectToken("channel_name")?.ToString();
            UserId = message.SelectToken("user_id")?.ToString();
            RecipientId = message.SelectToken("recipient_id")?.ToString();
            ChannelId = message.SelectToken("channel_id")?.ToString();
            Time = Common.Helpers.DateTimeStringToObject(message.SelectToken("time")?.ToString());
            switch (message.SelectToken("sub_plan").ToString().ToLower())
            {
                case "prime":
                    SubscriptionPlan = Enums.SubscriptionPlan.Prime;
                    break;
                case "1000":
                    SubscriptionPlan = Enums.SubscriptionPlan.Tier1;
                    break;
                case "2000":
                    SubscriptionPlan = Enums.SubscriptionPlan.Tier2;
                    break;
                case "3000":
                    SubscriptionPlan = Enums.SubscriptionPlan.Tier3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            SubscriptionPlanName = message.SelectToken("sub_plan_name")?.ToString();
            Months = int.Parse(message.SelectToken("months").ToString());
            SubMessage = new SubMessage(message.SelectToken("sub_message"));
            Context = message.SelectToken("context")?.ToString();
        }
    }
}
