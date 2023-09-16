namespace TwitchLib.PubSub.Models.Responses.Messages
{
    public class LowTrustUsers : MessageData
    {
        public string RawData { get; private set; }

        public LowTrustUsers(string jsonString)
        {
            RawData = jsonString;
        }
    }
}