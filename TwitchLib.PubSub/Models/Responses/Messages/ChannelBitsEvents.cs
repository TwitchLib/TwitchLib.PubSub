using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// Model representing the data in a channel bits event.
    /// Implements the <see cref="TwitchLib.PubSub.Models.Responses.Messages.MessageData" />
    /// </summary>
    /// <seealso cref="TwitchLib.PubSub.Models.Responses.Messages.MessageData" />
    /// <inheritdoc />
    public class ChannelBitsEvents : MessageData
    {
        /// <summary>
        /// Username of the sender.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; protected set; }
        /// <summary>
        /// The channel the bits were sent to.
        /// </summary>
        /// <value>The name of the channel.</value>
        public string ChannelName { get; protected set; }
        /// <summary>
        /// User ID of the sender.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; protected set; }
        /// <summary>
        /// Channel/User ID of where the bits were sent to.
        /// </summary>
        /// <value>The channel identifier.</value>
        public string ChannelId { get; protected set; }
        /// <summary>
        /// Time stamp of the event.
        /// </summary>
        /// <value>The time.</value>
        public string Time { get; protected set; }
        /// <summary>
        /// Chat message that accompanied the bits.
        /// </summary>
        /// <value>The chat message.</value>
        public string ChatMessage { get; protected set; }
        /// <summary>
        /// The amount of bits sent.
        /// </summary>
        /// <value>The bits used.</value>
        public int BitsUsed { get; protected set; }
        /// <summary>
        /// The total amount of bits the user has sent.
        /// </summary>
        /// <value>The total bits used.</value>
        public int TotalBitsUsed { get; protected set; }
        /// <summary>
        /// Context related to event.
        /// </summary>
        /// <value>The context.</value>
        public string Context { get; protected set; }

        /// <summary>
        /// ChannelBitsEvent model constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public ChannelBitsEvents(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            Username = json.SelectToken("data").SelectToken("user_name")?.ToString();
            ChannelName = json.SelectToken("data").SelectToken("channel_name")?.ToString();
            UserId = json.SelectToken("data").SelectToken("user_id")?.ToString();
            ChannelId = json.SelectToken("data").SelectToken("channel_id")?.ToString();
            Time = json.SelectToken("data").SelectToken("time")?.ToString();
            ChatMessage = json.SelectToken("data").SelectToken("chat_message")?.ToString();
            BitsUsed = int.Parse(json.SelectToken("data").SelectToken("bits_used").ToString());
            TotalBitsUsed = int.Parse(json.SelectToken("data").SelectToken("total_bits_used").ToString());
            Context = json.SelectToken("data").SelectToken("context")?.ToString();
        }
    }
}
