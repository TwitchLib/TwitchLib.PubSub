#pragma warning disable SYSLIB1006 // Multiple logging methods cannot use the same event id within a class
using Microsoft.Extensions.Logging;
using System;

namespace TwitchLib.PubSub.Extensions
{
    internal static partial class LoggingExtesions
    {
        [LoggerMessage(-1, LogLevel.Error, "OnError in PubSub Websocket connection occured! Exception: {ex}")]
        public static partial void LogOnError(this ILogger<TwitchPubSub> logger, Exception ex);

        [LoggerMessage(-1, LogLevel.Debug, "Received Websocket OnMessage: {message}")]
        public static partial void LogReceivednMessage(this ILogger<TwitchPubSub> logger, string message);

        [LoggerMessage(-1, LogLevel.Warning, "PubSub Websocket connection closed")]
        public static partial void LogConnectionClosed(this ILogger<TwitchPubSub> logger);

        [LoggerMessage(-1, LogLevel.Information, "PubSub Websocket connection established")]
        public static partial void LogConnectionEstablished(this ILogger<TwitchPubSub> logger);

        [LoggerMessage(-1, LogLevel.Information, "[TwitchPubSub] {message}")]
        public static partial void LogUnaccountedFor(this ILogger<TwitchPubSub> logger, string message);
    }
}
