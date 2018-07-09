using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TwitchLib.PubSub.Models.Responses.Messages.Whispers
{

    // <summary>Class representing the tags associated with the whisper.</summary>
    public class TagsObj
    {
        /// <summary>Login value associated.</summary>
        public string Login { get; protected set; }
        /// <summary>Display name found in chat.</summary>
        public string DisplayName { get; protected set; }
        /// <summary>Color of whispers</summary>
        public string Color { get; protected set; }
        /// <summary>User type of whisperer</summary>
        public string UserType { get; protected set; }
        /// <summary>List of emotes found in whisper</summary>
        public readonly List<EmoteObj> Emotes = new List<EmoteObj>();
        /// <summary>All badges associated with the whisperer</summary>
        public readonly List<Badge> Badges = new List<Badge>();

        /// <summary></summary>
        public TagsObj(JToken json)
        {
            Login = json.SelectToken("login")?.ToString();
            DisplayName = json.SelectToken("login")?.ToString();
            Color = json.SelectToken("color")?.ToString();
            UserType = json.SelectToken("user_type")?.ToString();
            foreach (var emote in json.SelectToken("emotes"))
                Emotes.Add(new EmoteObj(emote));
            foreach (var badge in json.SelectToken("badges"))
                Badges.Add(new Badge(badge));
        }
    }
}
