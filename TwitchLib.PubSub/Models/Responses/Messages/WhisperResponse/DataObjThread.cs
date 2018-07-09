using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages.Whispers
{
    public class DataObjThread
    {
        public string Id { get; protected set; }
        public long LastRead { get; protected set; }
        public bool Archived { get; protected set; }
        public bool Muted { get; protected set; }
        public SpamInfoObj SpamInfo { get; protected set; }

        public DataObjThread(JToken json)
        {
            Id = json.SelectToken("id").ToString();
            LastRead = long.Parse(json.SelectToken("last_read").ToString());
            Archived = bool.Parse(json.SelectToken("archived").ToString());
            Muted = bool.Parse(json.SelectToken("muted").ToString());
            SpamInfo = new SpamInfoObj(json.SelectToken("spam_info"));
        }
    }
}
