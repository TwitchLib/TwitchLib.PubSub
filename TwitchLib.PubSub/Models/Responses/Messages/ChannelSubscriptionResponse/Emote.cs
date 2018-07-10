using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages.SubMessages
{
    public class Emote
    {
        public int Start { get; protected set; }
        public int End { get; protected set; }
        public int Id { get; protected set; }

        public Emote(JToken json)
        {
            Start = int.Parse(json.SelectToken("start").ToString());
            End = int.Parse(json.SelectToken("end").ToString());
            Id = int.Parse(json.SelectToken("id").ToString());
        }
    }
}
