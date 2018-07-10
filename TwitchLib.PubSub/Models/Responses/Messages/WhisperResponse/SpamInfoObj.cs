using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages.Whispers
{
    public class SpamInfoObj
    {
        public string Likelihood { get; protected set; }
        public long LastMarkedNotSpam { get; protected set; }

        public SpamInfoObj(JToken json)
        {
            Likelihood = json.SelectToken("likelihood").ToString();
            LastMarkedNotSpam = long.Parse(json.SelectToken("last_marked_not_spam").ToString());
        }
    }
}
