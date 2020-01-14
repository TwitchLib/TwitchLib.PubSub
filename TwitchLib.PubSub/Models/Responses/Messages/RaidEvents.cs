using System;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// RaidEvents model constructor.
    /// Implements the <see cref="MessageData" />
    /// </summary>
    /// <seealso cref="MessageData" />
    /// <inheritdoc />
    public class RaidEvents : MessageData
    {
        /// <summary>
        /// Raid type
        /// </summary>
        /// <value></value>
        public RaidType Type { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Guid Id { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int ChannelId { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int TargetChannelId { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string TargetLogin { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string TargetDisplayName { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string TargetProfileImage { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime AnnounceTime { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime RaidTime { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int RemainigDurationSeconds { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int ViewerCount { get; protected set; }

        /// <summary>
        /// RaidEvents constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public RaidEvents(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            switch (json.SelectToken("type").ToString())
            {                
                case "raid_update":
                    Type = RaidType.RaidUpdate;
                    break;
                case "raid_update_v2":
                    Type = RaidType.RaidUpdateV2;
                    break;
                case "raid_go_v2":
                    Type = RaidType.RaidGo;
                    break;

            }

            switch (Type)
            {                
                case RaidType.RaidUpdate:
                    Id = Guid.Parse(json.SelectToken("raid.id").ToString());
                    ChannelId = int.Parse(json.SelectToken("raid.source_id").ToString());
                    TargetChannelId = int.Parse(json.SelectToken("raid.target_id").ToString());
                    AnnounceTime = DateTime.Parse(json.SelectToken("raid.announce_time").ToString());
                    RaidTime = DateTime.Parse(json.SelectToken("raid.raid_time").ToString());
                    RemainigDurationSeconds = int.Parse(json.SelectToken("raid.remaining_duration_seconds").ToString());
                    ViewerCount = int.Parse(json.SelectToken("raid.viewer_count").ToString());
                    break;
                case RaidType.RaidUpdateV2:
                    Id = Guid.Parse(json.SelectToken("raid.id").ToString());
                    ChannelId = int.Parse(json.SelectToken("raid.source_id").ToString());
                    TargetChannelId = int.Parse(json.SelectToken("raid.target_id").ToString());
                    TargetLogin = json.SelectToken("raid_target_login").ToString();
                    TargetDisplayName = json.SelectToken("raid.target_display_name").ToString();
                    TargetProfileImage = json.SelectToken("raid.target_profile_picture").ToString();
                    ViewerCount = int.Parse(json.SelectToken("raid.viewer_count").ToString());
                    break;
                case RaidType.RaidGo:
                    Id = Guid.Parse(json.SelectToken("raid.id").ToString());
                    ChannelId = int.Parse(json.SelectToken("raid.source_id").ToString());
                    TargetChannelId = int.Parse(json.SelectToken("raid.target_id").ToString());
                    TargetLogin = json.SelectToken("raid_target_login").ToString();
                    TargetDisplayName = json.SelectToken("raid.target_display_name").ToString();
                    TargetProfileImage = json.SelectToken("raid.target_profile_picture").ToString();
                    ViewerCount = int.Parse(json.SelectToken("raid.viewer_count").ToString());
                    break;
            }
        }
    }
}
