using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.PubSub.Enums;
using TwitchLib.PubSub.Models.Responses.Messages.Redemption;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// ChannelPointsChannel model constructor
    /// Implements the <see cref="MessageData" />
    /// </summary>
    public class ChannelPointsChannel : MessageData
    {
        /// <summary>
        /// Type of channel points channel
        /// </summary>
        public ChannelPointsChannelType Type { get; private set; }

        public ChannelPointsData Data { get; private set; }

        public string RawData { get; private set; }

        public ChannelPointsChannel(string jsonStr)
        {
            RawData = jsonStr;
            JToken json = JObject.Parse(jsonStr);
            switch(json.SelectToken("type").ToString())
            {
                case "reward-redeemed":
                    Type = ChannelPointsChannelType.RewardRedeemed;
                    Data = JsonConvert.DeserializeObject<RewardRedeemed>(json.SelectToken("data").ToString());
                    break;
                default:
                    Type = ChannelPointsChannelType.Unknown;
                    break;
            }
        }
    }
}
