using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// ChannelPointsChannel model constructor
    /// Implements the <see cref="MessageData" />
    /// </summary>
    public class AutomodQueue : MessageData
    {
        /// <summary>
        /// Type of channel points channel
        /// </summary>
        public AutomodQueueType Type { get; private set; }

        public AutomodQueueData Data { get; private set; }

        public string RawData { get; private set; }

        public AutomodQueue(string jsonStr)
        {
            RawData = jsonStr;
            JToken json = JObject.Parse(jsonStr);
            switch (json.SelectToken("type").ToString())
            {
                case "automod_caught_message":
                    Type = AutomodQueueType.CaughtMessage;
                    Data = JsonConvert.DeserializeObject<AutomodCaughtMessage.AutomodCaughtMessage>(json.SelectToken("data").ToString());
                    break;
                default:
                    Type = AutomodQueueType.Unknown;
                    break;
            }
        }
    }
}
