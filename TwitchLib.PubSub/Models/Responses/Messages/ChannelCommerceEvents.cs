using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// Model representing the data in a channel commerce event.
    /// Implements the <see cref="TwitchLib.PubSub.Models.Responses.Messages.MessageData" />
    /// </summary>
    /// <seealso cref="TwitchLib.PubSub.Models.Responses.Messages.MessageData" />
    /// <inheritdoc />
    public class ChannelCommerceEvents : MessageData
    {
        /// <summary>
        /// Username of the buyer.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; protected set; }
        /// <summary>
        /// Display name of the buyer.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; protected set; }
        /// <summary>
        /// The channel the purchase was made in.
        /// </summary>
        /// <value>The name of the channel.</value>
        public string ChannelName { get; protected set; }
        /// <summary>
        /// User ID of the buyer.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; protected set; }
        /// <summary>
        /// Channel/User ID the purchase was made for/in.
        /// </summary>
        /// <value>The channel identifier.</value>
        public string ChannelId { get; protected set; }
        /// <summary>
        /// Time stamp of the event.
        /// </summary>
        /// <value>The time.</value>
        public string Time { get; protected set; }
        /// <summary>
        /// URL for the item's image.
        /// </summary>
        /// <value>The item image URL.</value>
        public string ItemImageURL { get; protected set; }
        /// <summary>
        /// Description of the item.
        /// </summary>
        /// <value>The item description.</value>
        public string ItemDescription { get; protected set; }
        /// <summary>
        /// Does this purchase support the channel?
        /// </summary>
        /// <value><c>true</c> if [supports channel]; otherwise, <c>false</c>.</value>
        public bool SupportsChannel { get; protected set; }
        /// <summary>
        /// Chat message that accompanied the purchase.
        /// </summary>
        /// <value>The purchase message.</value>
        public string PurchaseMessage { get; protected set; }

        /// <summary>
        /// ChannelBitsEvent model constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public ChannelCommerceEvents(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            Username = json.SelectToken("data").SelectToken("user_name")?.ToString();
            DisplayName = json.SelectToken("data").SelectToken("display_name")?.ToString();
            ChannelName = json.SelectToken("data").SelectToken("channel_name")?.ToString();
            UserId = json.SelectToken("data").SelectToken("user_id")?.ToString();
            ChannelId = json.SelectToken("data").SelectToken("channel_id")?.ToString();
            Time = json.SelectToken("data").SelectToken("time")?.ToString();
            ItemImageURL = json.SelectToken("data").SelectToken("image_item_url")?.ToString();
            ItemDescription = json.SelectToken("data").SelectToken("item_description")?.ToString();
            SupportsChannel = bool.Parse(json.SelectToken("data").SelectToken("supports_channel")?.ToString());
            PurchaseMessage = json.SelectToken("data").SelectToken("purchase_message").SelectToken("message")?.ToString();
        }
    }
}
