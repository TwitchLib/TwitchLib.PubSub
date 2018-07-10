using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <inheritdoc />
    /// <summary>Model representing the data in a channel commerce event.</summary>
    public class ChannelCommerceEvents : MessageData
    {
        /// <summary>Username of the buyer.</summary>
        public string Username { get; protected set; }
        /// <summary>Display name of the buyer.</summary>
        public string DisplayName { get; protected set; }
        /// <summary>The channel the purchase was made in.</summary>
        public string ChannelName { get; protected set; }
        /// <summary>User ID of the buyer.</summary>
        public string UserId { get; protected set; }
        /// <summary>Channel/User ID the purchase was made for/in.</summary>
        public string ChannelId { get; protected set; }
        /// <summary>Time stamp of the event.</summary>
        public string Time { get; protected set; }
        /// <summary>URL for the item's image.</summary>
        public string ItemImageURL { get; protected set; }
        /// <summary>Description of the item.</summary>
        public string ItemDescription { get; protected set; }
        /// <summary>Does this purchase support the channel?</summary>
        public bool SupportsChannel { get; protected set; }
        /// <summary>Chat message that accompanied the purchase.</summary>
        public string PurchaseMessage { get; protected set; }

        /// <summary>ChannelBitsEvents model constructor.</summary>
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
