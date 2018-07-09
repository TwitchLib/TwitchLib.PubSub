using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TwitchLib.PubSub.Models.Responses.Messages.SubMessages;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    public class SubMessage
    {
        public string Message { get; protected set; }
        public List<Emote> Emotes { get; protected set; } = new List<Emote>();

        public SubMessage(JToken json)
        {
            Message = json.SelectToken("message")?.ToString();
            foreach (var token in json.SelectToken("emotes"))
                Emotes.Add(new Emote(token));
        }
    }
}
