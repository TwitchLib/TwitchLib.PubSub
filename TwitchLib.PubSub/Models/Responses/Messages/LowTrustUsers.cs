using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Extensions;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    public class LowTrustUsers : MessageData
    {
        /// <summary>
        /// An ID for the suspicious user entry, which is a combination of the channel ID where the treatment was updated and the user ID of the suspicious user.
        /// </summary>
        public string LowTrustId { get; protected set; }
        /// <summary>
        /// ID of the channel where the suspicious user was present
        /// </summary>
        public string ChannelId { get; protected set; }
        /// <summary>
        /// Information about the moderator who made any update for the suspicious user.
        /// </summary>
        public UpdatedBy UpdatedBy { get; protected set; }
        /// <summary>
        /// DateTime of when the treatment was updated for the suspicious user.
        /// </summary>
        public DateTime? UpdatedAt { get; protected set; }
        /// <summary>
        /// User ID of the suspicious user.
        /// </summary>
        public string TargetUserId { get; protected set; }
        /// <summary>
        /// Login of the suspicious user.
        /// </summary>
        public string TargetUser { get; protected set; }
        /// <summary>
        /// The treatment set for the suspicious user, can be “NO_TREATMENT”, “ACTIVE_MONITORING”, or “RESTRICTED”
        /// </summary>
        public string Treatment { get; protected set; }
        /// <summary>
        /// User types (if any) that apply to the suspicious user, can be “UNKNOWN_TYPE”, “MANUALLY_ADDED”, “DETECTED_BAN_EVADER”, or “BANNED_IN_SHARED_CHANNEL”
        /// </summary>
        public string[] Types { get; protected set; }
        /// <summary>
        /// A ban evasion likelihood value (if any) that as been applied to the user automatically by Twitch, can be “UNKNOWN_EVADER”, “UNLIKELY_EVADER”, “LIKELY_EVADER”, or “POSSIBLE_EVADER”
        /// </summary>
        public string BanEvasionEvaluation { get; protected set; }
        /// <summary>
        /// If applicable, an DateTime timestamp for the first time the suspicious user was automatically evaluated by Twitch.
        /// </summary>
        public DateTime? EvaluatedAt { get; protected set; }
        
        public LowTrustUsers(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            var data = json.SelectToken("data");
            LowTrustId = data.SelectToken("low_trust_id")?.ToString();
            ChannelId = data.SelectToken("channel_id")?.ToString();
            UpdatedBy = new UpdatedBy(data.SelectToken("updated_by"));
            UpdatedAt = (data.SelectToken("updated_at").IsEmpty()) ? (DateTime?) null : DateTime.Parse(data.SelectToken("updated_at").ToString());
            TargetUserId = data.SelectToken("target_user")?.ToString();
            TargetUser = data.SelectToken("target_user")?.ToString();
            Treatment = data.SelectToken("treatment")?.ToString();
            Types = data.SelectToken("types")?.ToObject<string[]>();
            BanEvasionEvaluation = data.SelectToken("ban_evasion_evaluation")?.ToString();
            EvaluatedAt = (data.SelectToken("evaluated_at").IsEmpty()) ? (DateTime?) null : DateTime.Parse(data.SelectToken("evaluated_at").ToString());
        }
    }

    public class UpdatedBy
    {
        /// <summary>
        /// User ID of the moderator.
        /// </summary>
        public string Id { get; protected set; }
        /// <summary>
        /// Login of the moderator.
        /// </summary>
        public string Login { get; protected set; }
        /// <summary>
        /// Display name of the moderator.
        /// </summary>
        public string DisplayName { get; protected set; }

        public UpdatedBy(JToken? json)
        {
            Id = json?.SelectToken("id")?.ToString();
            Login = json?.SelectToken("login")?.ToString();
            DisplayName = json?.SelectToken("display_name")?.ToString();
        }
    }
}