using System;
using System.Drawing;
using System.Globalization;

namespace TwitchLib.PubSub.Common
{
    /// <summary>Static class of helper functions used around the project.</summary>
    public static class Helpers
    {
        /// <summary>Takes date time string received from Twitch API and converts it to DateTime object.</summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime DateTimeStringToObject(string dateTime)
        {
            return dateTime == null ? new DateTime() : Convert.ToDateTime(dateTime);
        }
        
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static Color ColorFromHex(string hex)
        {
            if (hex == null)
                return default(Color);

            if (int.TryParse(hex.Replace("#", ""), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var argb))
                return Color.FromArgb(argb);

            return default(Color);
        }
    }
}