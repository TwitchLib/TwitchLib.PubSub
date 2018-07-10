﻿using Newtonsoft.Json.Linq;
using System;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <inheritdoc />
    /// <summary>ChannelSubscription model.</summary>
    public class ChannelSubscription : MessageData
    {
        public string Username { get; protected set; }
        public string DisplayName { get; protected set; }
        public string RecipientName { get; protected set; }
        public string RecipientDisplayName { get; protected set; }
        public string ChannelName { get; protected set; }
        public string UserId { get; protected set; }
        public string ChannelId { get; protected set; }
        public string RecipientId { get; protected set; }
        public DateTime Time { get; protected set; }
        public Enums.SubscriptionPlan SubscriptionPlan { get; protected set; }
        public string SubscriptionPlanName { get; protected set; }
        public int Months { get; protected set; }
        public string Context { get; protected set; }
        public SubMessage SubMessage { get; protected set; }

        /// <summary>ChatModeratorActions model constructor.</summary>
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
