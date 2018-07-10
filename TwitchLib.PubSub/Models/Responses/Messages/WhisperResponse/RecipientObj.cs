using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TwitchLib.PubSub.Models.Responses.Messages.Whispers
{
    /// <summary>Class representing the recipient of the whisper.</summary>
    public class RecipientObj
    {
        /// <summary>Receiver id</summary>
        public string Id { get; protected set; }
        /// <summary>Receiver username</summary>
        public string Username { get; protected set; }
        /// <summary>Receiver display name.</summary>
        public string DisplayName { get; protected set; }
        /// <summary>Receiver color.</summary>
        public string Color { get; protected set; }
        /// <summary>User type of receiver.</summary>
        public string UserType { get; protected set; }
        /// <summary>List of badges that the receiver has.</summary>
        public List<Badge> Badges { get; protected set; } = new List<Badge>();

        /// <summary>RecipientObj constructor.</summary>
        public RecipientObj(JToken json)
        {
            Id = json.SelectToken("id").ToString();
            Username = json.SelectToken("username")?.ToString();
            DisplayName = json.SelectToken("display_name")?.ToString();
            Color = json.SelectToken("color")?.ToString();
            UserType = json.SelectToken("user_type")?.ToString();
            foreach (var badge in json.SelectToken("badges"))
                Badges.Add(new Badge(badge));
        }
    }
}
