using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Events
{
    /// <summary>
    /// [INCOMPLETE/NOT_FULLY_SUPPORTED]Whisper arguement class.
    /// </summary>
    public class OnWhisperArgs
    {
        /// <summary>
        /// Property representing the whisper object.
        /// </summary>
        public Whisper Whisper;

        /// <summary>
        /// The channel ID the event came from
        /// </summary>
        public string ChannelId;
    }
}
