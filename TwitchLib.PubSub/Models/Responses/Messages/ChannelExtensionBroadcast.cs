using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// VideoPlayback model constructor.
    /// Implements the <see cref="TwitchLib.PubSub.Models.Responses.Messages.MessageData" />
    /// </summary>
    /// <seealso cref="TwitchLib.PubSub.Models.Responses.Messages.MessageData" />
    /// <inheritdoc />
    public class ChannelExtensionBroadcast : MessageData
    {
        /// <summary>
        /// Video playback type
        /// </summary>
        /// <value>The messages.</value>
        public List<string> Messages { get; protected set; } = new List<string>();

        /// <summary>
        /// VideoPlayback constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public ChannelExtensionBroadcast(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            foreach (JToken msg in json["content"])
                Messages.Add(msg.ToString());
        }
    }
}
