using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// VideoPlayback model constructor.
    /// Implements the <see cref="MessageData" />
    /// </summary>
    /// <seealso cref="MessageData" />
    /// <inheritdoc />
    public class ChannelExtensionBroadcast : MessageData
    {
        /// <summary>
        /// Video playback type
        /// </summary>
        /// <value>The messages.</value>
        public List<string> Messages { get; } = new List<string>();

        /// <summary>
        /// VideoPlayback constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public ChannelExtensionBroadcast(string jsonStr)
        {
            var json = JObject.Parse(jsonStr);
            foreach (var msg in json["content"])
                Messages.Add(msg.ToString());
        }
    }
}
