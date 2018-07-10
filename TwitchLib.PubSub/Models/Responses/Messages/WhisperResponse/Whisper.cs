using Newtonsoft.Json.Linq;
using System;
using TwitchLib.PubSub.Models.Responses.Messages.Whispers;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <inheritdoc />
    /// <summary>Class representing a whisper received via PubSub.</summary>
    public class Whisper : MessageData
    {
        /// <summary>Type of MessageData</summary>
        public string Type { get; protected set; }
        /// <summary>Enum of the Message type</summary>
        public Enums.WhisperType TypeEnum { get; protected set; }
        /// <summary>Data identifier in MessageData</summary>
        public string Data { get; protected set; }
        /// <summary>Object that houses the data accompanying the type.</summary>
        public DataObjWhisperReceived DataObjectWhisperReceived { get; protected set; }
        /// <summary>Object that houses the data accompanying the type.</summary>
        public DataObjThread DataObjectThread { get; protected set; }

        /// <summary>Whisper object constructor.</summary>
        public Whisper(string jsonStr)
        {
            var json = JObject.Parse(jsonStr);
            Type = json.SelectToken("type").ToString();
            Data = json.SelectToken("data").ToString();
            switch (Type)
            {
                case "whisper_received":
                    TypeEnum = Enums.WhisperType.WhisperReceived;
                    DataObjectWhisperReceived = new DataObjWhisperReceived(json.SelectToken("data_object"));
                    break;
                case "thread":
                    TypeEnum = Enums.WhisperType.Thread;
                    DataObjectThread = new DataObjThread(json.SelectToken("data_object"));
                    break;
                default:
                    TypeEnum = Enums.WhisperType.Unknown;
                    break;
            }
        }
    }
}