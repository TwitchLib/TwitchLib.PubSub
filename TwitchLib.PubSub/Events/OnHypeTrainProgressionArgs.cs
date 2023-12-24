using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.PubSub.Models.Responses.Messages.HypeTrain;

namespace TwitchLib.PubSub.Events
{
    public class OnHypeTrainProgressionArgs
    {
        /// <summary>
        /// Details about the hype train.
        /// </summary>
        public HypeTrainProgression Progression;
        /// <summary>
        /// The ID of the channel that this event fired from.
        /// </summary>
        public string ChannelId;
    }
}
