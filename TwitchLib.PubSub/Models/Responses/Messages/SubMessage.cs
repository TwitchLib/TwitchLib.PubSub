using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// Class SubMessage.
    /// </summary>
    public class SubMessage
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; protected set; }
        /// <summary>
        /// Gets or sets the emotes.
        /// </summary>
        /// <value>The emotes.</value>
        public List<Emote> Emotes { get; protected set; } = new List<Emote>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SubMessage"/> class.
        /// </summary>
        /// <param name="json">The json.</param>
        public SubMessage(JToken json)
        {
            Message = json.SelectToken("message")?.ToString();
            foreach (JToken token in json.SelectToken("emotes"))
                Emotes.Add(new Emote(token));
        }

        /// <summary>
        /// Class Emote.
        /// </summary>
        public class Emote
        {
            /// <summary>
            /// Gets or sets the start.
            /// </summary>
            /// <value>The start.</value>
            public int Start { get; protected set; }
            /// <summary>
            /// Gets or sets the end.
            /// </summary>
            /// <value>The end.</value>
            public int End { get; protected set; }
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public int Id { get; protected set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Emote"/> class.
            /// </summary>
            /// <param name="json">The json.</param>
            public Emote(JToken json)
            {
                Start = int.Parse(json.SelectToken("start").ToString());
                End = int.Parse(json.SelectToken("end").ToString());
                Id = int.Parse(json.SelectToken("id").ToString());
            }
        }
    }
}
