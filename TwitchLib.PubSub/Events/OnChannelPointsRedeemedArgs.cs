using System;

namespace TwitchLib.PubSub.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Object representing the arguments for channel points redeemed event
    /// </summary>
    public class OnChannelPointsRedeemedArgs : EventArgs
    {
        /// <summary>
        /// Property of for username.
        /// </summary>
        public string Username;
        /// <summary>
        /// Property of for user display name.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Property for user id.
        /// </summary>
        public string UserId;
        /// <summary>
        /// Property for channel id.
        /// </summary>
        public string ChannelId;
        /// <summary>
        /// Property for time.
        /// </summary>
        public string Time;
        /// <summary>
        /// Property for points used.
        /// </summary>
        public int PointsUsed;
        /// <summary>
        /// Property for title
        /// </summary>
        public string Title;
        /// <summary>
        /// Property for prompt
        /// </summary>
        public string Prompt;
        /// <summary>
        /// Property for user input
        /// </summary>
        public string UserInput;

    }
}
