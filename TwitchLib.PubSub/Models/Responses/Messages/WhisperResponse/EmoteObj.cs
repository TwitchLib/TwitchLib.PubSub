using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages.Whispers
{
    /// <summary>Class representing a single emote found in a whisper</summary>
    public class EmoteObj
    {
        /// <summary>Emote ID</summary>
        public int Id { get; protected set; }
        /// <summary>Starting character of emote</summary>
        public int Start { get; protected set; }
        /// <summary>Ending character of emote</summary>
        public int End { get; protected set; }

        /// <summary>EmoteObj construcotr.</summary>
        public EmoteObj(JToken json)
        {
            Id = int.Parse(json.SelectToken("id").ToString());
            Start = int.Parse(json.SelectToken("start").ToString());
            End = int.Parse(json.SelectToken("end").ToString());
        }
    }
}
