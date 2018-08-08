using System;
using BotSdk = Microsoft.Azure.Management.BotService.Models;

namespace Microsoft.Azure.Commands.BotService.BotService
{
    public static class ChannelNames
    {
        public const string DirectLineChannel = "DirectLineChannel";
        public const string EmailChannel = "EmailChannel";
        public const string FacebookChannel = "FacebookChannel";
        public const string KikChannel = "KikChannel";
        public const string MsTeamsChannel = "MsTeamsChannel";
        public const string SkypeChannel = "SkypeChannel";
        public const string SlackChannel = "SlackChannel";
        public const string SmsChannel = "SmsChannel";
        public const string TelegramChannel = "TelegramChannel";
        public const string WebChatChannel = "WebChatChannel";

        public static void ValidateChannelName(string channelName)
        {
            // ToEnum throws an argument exception if the channel name is invalid.
            ToEnum(channelName);
        }

        public static BotSdk.ChannelName ToEnum(string channelName)
        {
            switch (channelName)
            {
                case DirectLineChannel:
                    return BotSdk.ChannelName.DirectLineChannel;
                case EmailChannel:
                    return BotSdk.ChannelName.EmailChannel;
                case FacebookChannel:
                    return BotSdk.ChannelName.FacebookChannel;
                case KikChannel:
                    return BotSdk.ChannelName.KikChannel;
                case MsTeamsChannel:
                    return BotSdk.ChannelName.MsTeamsChannel;
                case SkypeChannel:
                    return BotSdk.ChannelName.SkypeChannel;
                case SlackChannel:
                    return BotSdk.ChannelName.SlackChannel;
                case SmsChannel:
                    return BotSdk.ChannelName.SmsChannel;
                case TelegramChannel:
                    return BotSdk.ChannelName.TelegramChannel;
                case WebChatChannel:
                    return BotSdk.ChannelName.WebChatChannel;
                default:
                    throw new ArgumentException("Channel not supported");
            }
        }
    }
}
