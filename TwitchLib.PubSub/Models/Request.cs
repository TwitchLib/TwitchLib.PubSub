using Newtonsoft.Json;
using System.Collections.Generic;

namespace TwitchLib.PubSub.Models
{
    internal class Request
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("data")]
        public RequestData Data { get; set; }
    }

    internal class RequestData
    {
        [JsonProperty("topics")]
        public List<string> Topics { get; set; }

        [JsonProperty("auth_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthToken { get; set; }
    }
}
