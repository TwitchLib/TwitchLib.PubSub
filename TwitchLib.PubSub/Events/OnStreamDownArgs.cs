namespace TwitchLib.PubSub.Events
{
    /// <summary>Class representing stream going down event.</summary>
    public class OnStreamDownArgs
    {
        /// <summary>Property representing the server time of event.</summary>
        public string ServerTime;
        /// <summary>Property representing the channel id that this event relates to.</summary>
        public string ChannelId;
    }
}
