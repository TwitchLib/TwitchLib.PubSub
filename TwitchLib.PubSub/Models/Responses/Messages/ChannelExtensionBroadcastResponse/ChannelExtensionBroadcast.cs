using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <inheritdoc />
    /// <summary>VideoPlaybackEvent model constructor.</summary>
    public class ChannelExtensionBroadcast : MessageData
    {
        /// <summary>Video playback type</summary>
        public List<string> Messages { get; protected set; } = new List<string>();

        /// <summary>VideoPlaybackEvent constructor.</summary>
        /// <param name="jsonStr"></param>
        public ChannelExtensionBroadcast(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            foreach (var msg in json["content"])
                Messages.Add(msg.ToString());
        }
    }
}
