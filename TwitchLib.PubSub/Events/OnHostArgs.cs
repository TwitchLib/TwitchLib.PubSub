namespace TwitchLib.PubSub.Events
{
    /// <summary>
    /// Class representing arguments of on host event.
    /// </summary>
    public class OnHostArgs
    {
        /// <summary>
        /// Property representing moderator who issued command.
        /// </summary>
        public string Moderator;
        /// <summary>
        /// Property representing hosted channel.
        /// </summary>
        public string HostedChannel;
        /// <summary>
        /// The channel ID the event came from
        /// </summary>
        public string ChannelId;
    }
}
