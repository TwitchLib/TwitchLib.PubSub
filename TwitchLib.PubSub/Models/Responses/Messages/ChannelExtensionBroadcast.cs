using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <inheritdoc />
    /// <summary>VideoPlayback model constructor.</summary>
    public class ChannelExtensionBroadcast : MessageData
    {
        /// <summary>Video playback type</summary>
        public List<string> Messages { get; protected set; } = new List<string>();

        /// <summary>VideoPlayback constructor.</summary>
        /// <param name="jsonStr"></param>
        public ChannelExtensionBroadcast(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            foreach (var msg in json["content"])
                Messages.Add(msg.ToString());
        }
    }
}
