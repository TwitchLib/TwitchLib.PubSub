using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.PubSub.Models.Responses.Messages.HypeTrain;

namespace TwitchLib.PubSub.Events
{
    public class OnHypeTrainLevelUp
    {
        /// <summary>
        /// Details about the hype train level up event.
        /// </summary>
        public HypeTrainLevelUp LevelUp;
        /// <summary>
        /// The ID of the channel that this event fired from.
        /// </summary>
        public string ChannelId;
    }
}
