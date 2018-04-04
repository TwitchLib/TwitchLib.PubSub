<p align="center"> 
<img src="http://swiftyspiffy.com/img/twitchlib.png" style="max-height: 300px;">
</p>

# TwitchLib.PubSub

## About 
TwitchLib repository representing all code belonging to the implementation Twitch's PubSub service.

### Example
```csharp
using System;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;

namespace TwitchLibPubSubExample
{
    class Program
    {
        private static TwitchPubSub client;
        static void Main(string[] args)
        {
            client = new TwitchPubSub();

            client.OnPubSubServiceConnected += onPubSubServiceConnected;
            client.OnListenResponse += onListenResponse;
            client.OnStreamUp += onStreamUp;
            client.OnStreamDown += onStreamDown;

            client.ListenToVideoPlayback("{{CHANNEL}}");
        }

        private static void onPubSubServiceConnected(object sender, EventArgs e)
        {
            // SendTopics accepts an oauth optionally, which is necessary for some topics
            client.SendTopics();
        }
        
        private static void onListenResponse(object sender, OnListenResponseArgs e)
        {
            if (!e.Successful)
                throw new Exception($"Failed to listen! Response: {e.Response}");
        }

        private static void onStreamUp(object sender, OnStreamUpArgs e)
        {
            Console.WriteLine($"Stream just went up! Play delay: {e.PlayDelay}, server time: {e.ServerTime}");
        }

        private static void onStreamDown(object sender, OnStreamDownArgs e)
        {
            Console.WriteLine($"Stream just went down! Server time: {e.ServerTime}");
        }
    }
}
```
