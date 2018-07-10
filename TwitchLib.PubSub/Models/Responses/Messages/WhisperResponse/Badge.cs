using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages.Whispers
{
    /// <summary>Class representing a single badge.</summary>
    public class Badge
    {
        /// <summary>Id of the badge.</summary>
        public string Id { get; protected set; }
        /// <summary>Version of the badge.</summary>
        public string Version { get; protected set; }

        /// <summary></summary>
        public Badge(JToken json)
        {
            Id = json.SelectToken("id")?.ToString();
            Version = json.SelectToken("version")?.ToString();
        }
    }
}
