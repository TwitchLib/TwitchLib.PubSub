using System;
using System.Text;
using System.Threading;

namespace TwitchLib.PubSub.Common
{
    internal static class Nonce
    {
        private static Random seeder = new Random();
        public static ThreadLocal<Random> random = new ThreadLocal<Random>(CreateRandom);
        private static Random CreateRandom()
        {
            lock(seeder)
            {
                return new Random(seeder.Next());
            }
        }

        const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string Generate(int length = 8)
        {
            var rand = random.Value;
            var sb = new StringBuilder(length);
            for(int i = 0; i < length; i++)
            {
                var c = characters[rand.Next(characters.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}