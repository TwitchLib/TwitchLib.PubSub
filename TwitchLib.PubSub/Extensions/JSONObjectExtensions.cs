using System;
using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Extensions
{
    /// <summary>
    /// Represents the Extensions on JToken
    /// </summary>
    public static class JSONObjectExtensions
    {
        /// <summary>
        /// Checks if the value is empty
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsEmpty(this JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }
    }
}
