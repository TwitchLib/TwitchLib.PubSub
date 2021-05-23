using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages.UserModerationNotifications
{
    /// <summary>
    /// userModerationNotifications model constructor
    /// Implements the <see cref="MessageData" />
    /// </summary>
    public class UserModerationNotifications : MessageData
    {
        public UserModerationNotificationsType Type { get; private set; }
        public UserModerationNotificationsData Data { get; private set; }

        public string RawData { get; private set; }

        public UserModerationNotifications(string jsonStr)
        {
            RawData = jsonStr;
            JToken json = JObject.Parse(jsonStr);
            switch (json.SelectToken("type").ToString())
            {
                case "automod_caught_message":
                    Type = UserModerationNotificationsType.AutomodCaughtMessage;
                    Data = JsonConvert.DeserializeObject<UserModerationNotificationsTypes.AutomodCaughtMessage>(json.SelectToken("data").ToString());
                    break;
                default:
                    Type = UserModerationNotificationsType.Unknown;
                    break;
            }
        }
    }
}
