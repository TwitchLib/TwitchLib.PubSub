using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages.HypeTrain
{
    public class HypeTrainEvent : MessageData
    {
        public HypeTrainEventType Type { get; protected set; }
        public HypeTrainEventData Data { get; protected set; }


        public HypeTrainEvent(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            switch (json.SelectToken("type").ToString())
            {
                case "hype-train-progression":
                    Type = HypeTrainEventType.Progression;
                    Data = json["data"].ToObject<HypeTrainProgression>();
                    break;
                case "hype-train-level-up":
                    Type = HypeTrainEventType.LevelUp;
                    Data = json["data"].ToObject<HypeTrainLevelUp>();
                    break;
            }
        }
    }
}
