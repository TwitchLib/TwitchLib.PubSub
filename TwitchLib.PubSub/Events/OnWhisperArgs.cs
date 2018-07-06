using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Events
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Models.Responses.Messages.Whispers;

    /// <summary>[INCOMPLETE/NOT_FULLY_SUPPORTED]Whisper arguement class.</summary>
    public class OnWhisperArgs
    {
        /// <summary>TOOOOOOOOOOOOODOOOOOOOOO</summary>
        public DateTime SentTimestamp;

        /// <summary>The TwitchId from the user who sent the message.</summary>
        public string SenderId;
        /// <summary>The username from the user who sent the message.</summary>
        public string SenderUsername;
        /// <summary>The display name from the user who sent the message.</summary>
        public string SenderDisplayName;
        /// <summary>The text color from the user who sent the message.</summary>
        public Color SenderColor;
        /// <summary>A list of emotes that were used in the message.</summary>
        public List<EmoteObj> SenderEmotes;
        /// <summary>A list of badges from the user who sent the message.</summary>
        public List<Badge> SenderBadges;

        /// <summary>Property representing the message that was sent.</summary>
        public string Body;

        /// <summary>The TwitchId from the user who received the message.</summary>
        public string RecipientId;
        /// <summary>The username from the user who received the message.</summary>
        public string RecipientUsername;
        /// <summary>The display name from the user who received the message.</summary>
        public string RecipientDisplayName;
        /// <summary>The text color from the user who received the message.</summary>
        public Color RecipientColor;
        /// <summary>A list of badges from the user who received the message.</summary>
        public List<Badge> RecipientBadges;

        /// <summary>Property representing the whisper object.</summary> 
        [Obsolete("The Whisper property is depreciated, use the properties within the OnWhisperArgs object itself.")]
        public WhisperEvent Whisper;
    }
}
