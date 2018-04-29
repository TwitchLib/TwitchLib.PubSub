using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <inheritdoc />
    /// <summary>Following model constructor.</summary>
    public class Following : MessageData
    {
        /// <summary>Following user display name.</summary>
        public string DisplayName { get; protected set; }
        /// <summary>Following user username.</summary>
        public string Username { get; protected set; }
        /// <summary>Following user user-id.</summary>
        public string UserId { get; protected set; }
        public string FollowedChannelId { get; internal set; }

        /// <summary>Following constructor.</summary>
        /// <param name="jsonStr"></param>
        public Following(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            DisplayName = json["display_name"].ToString();
            Username = json["username"].ToString();
            UserId = json["user_id"].ToString();
        }
    }
}
