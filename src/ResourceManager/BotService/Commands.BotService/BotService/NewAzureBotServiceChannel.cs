using Microsoft.Azure.Commands.BotService.Resources;
using Microsoft.Azure.Commands.BotService.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.BotService;
using Microsoft.Azure.Management.BotService.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.BotService.BotService
{
    [Cmdlet(VerbsCommon.New, BotServiceChannelNounStr), OutputType(typeof(string))]
    public class NewAzureBotServiceChannel : BotServiceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Name.")]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Channel Name.")]
        public string ChannelName { get; set; }

        // DirectLine parameters
        [Parameter(
            ParameterSetName = ChannelNames.DirectLineChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Collection of direct line sites.")]
        public IList<DirectLineSite> DirectLineSites { get; set; }

        // Email parameters
        [Parameter(
            ParameterSetName = ChannelNames.EmailChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Email address.")]
        public string EmailAddress { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.EmailChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Email password.")]
        public string Password { get; set; }

        // Facebook Channel
        [Parameter(
            ParameterSetName = ChannelNames.FacebookChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Facebook App Id.")]
        public string FacebookAppId { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.FacebookChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Facebook App secret.")]
        public string FacebookAppSecret { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.FacebookChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Collection of Facebook Pages.")]
        public IList<FacebookPage> FacebookPages{ get; set; }

        // Kik
        [Parameter(
            ParameterSetName = ChannelNames.KikChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Kik Api Key.")]
        public string KikApiKey { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.KikChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Kik user name.")]
        public string KikUserName { get; set; }

        // MsTeams
        [Parameter(
            ParameterSetName = ChannelNames.MsTeamsChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether calling is enabled for MsTeams.")]
        public bool EnableMsTeamsCalling { get; set; }

        // Skype
        [Parameter(
            ParameterSetName = ChannelNames.SkypeChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether calling is enabled for Skype.")]
        public bool EnableSkypeCalling { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SkypeChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether calling is enabled for Skype.")]
        public bool EnableSkypeGroups { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SkypeChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether calling is enabled for Skype.")]
        public bool EnableSkypeMediaCards { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SkypeChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether calling is enabled for Skype.")]
        public bool EnableSkypeMessaging { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SkypeChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether calling is enabled for Skype.")]
        public bool EnableSkypeScreenSharing { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SkypeChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether calling is enabled for Skype.")]
        public bool EnableSkypeVideo { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SkypeChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Skype calling webhook.")]
        public string SkypeCallingWebHook { get; set; }

        // Slack
        [Parameter(
            ParameterSetName = ChannelNames.SlackChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Slack ClientId.")]
        public string SlackClientId { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SlackChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Slack ClientSecret.")]
        public string SlackClientSecret { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SlackChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Slack Landing Page Url.")]
        public string SlackLandingPageUrl { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SlackChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Slack Verification Token.")]
        public string SlackVerificationToken { get; set; }

        // Sms
        [Parameter(
            ParameterSetName = ChannelNames.SmsChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Sms Account SID.")]
        public string SmsAccountSID { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SmsChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Sms Auth Token.")]
        public string SmsAuthToken { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.SmsChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Sms phone.")]
        public string SmsPhone { get; set; }

        // Telegram
        [Parameter(
            ParameterSetName = ChannelNames.TelegramChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Telegram Access Token.")]
        public string TelegramAccessToken { get; set; }

        [Parameter(
            ParameterSetName = ChannelNames.WebChatChannel,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Collection of webchat line sites.")]
        public IList<WebChatSite> WebChatSites { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the channel is enabled.")]
        public bool IsEnabled{ get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                var channel = new BotChannel()
                {
                    Location = BotServiceLocation,
                };

                // Populate channel properties selectively based off channel name
                switch (ChannelName)
                {
                    case ChannelNames.DirectLineChannel:
                        channel.Properties = new DirectLineChannel()
                        {
                            Properties = new DirectLineChannelProperties()
                            {
                                Sites = DirectLineSites
                            }
                        };
                        break;
                    case ChannelNames.EmailChannel:
                        channel.Properties = new EmailChannel()
                        {
                            Properties = new EmailChannelProperties()
                            {
                                EmailAddress = EmailAddress,
                                Password = Password,
                                IsEnabled = IsEnabled 
                            }
                        };
                        break;
                    case ChannelNames.FacebookChannel:
                        channel.Properties = new FacebookChannel()
                        {
                            Properties = new FacebookChannelProperties()
                            {
                                AppId = FacebookAppId,
                                AppSecret = FacebookAppSecret,
                                Pages = FacebookPages,
                                IsEnabled = IsEnabled
                            }
                        };
                        break;
                    case ChannelNames.KikChannel:
                        channel.Properties = new KikChannel
                        {
                            Properties = new KikChannelProperties()
                            {
                                ApiKey = KikApiKey,
                                UserName = KikUserName,
                                IsEnabled = IsEnabled
                            }
                        };
                        break;
                    case ChannelNames.MsTeamsChannel:
                        channel.Properties = new MsTeamsChannel
                        {
                            Properties = new MsTeamsChannelProperties()
                            {
                                EnableCalling = EnableMsTeamsCalling,
                                IsEnabled = IsEnabled
                            }
                        };
                        break;
                    case ChannelNames.SkypeChannel:
                        channel.Properties = new SkypeChannel
                        {
                            Properties = new SkypeChannelProperties()
                            {
                                CallingWebHook = SkypeCallingWebHook,
                                EnableCalling = EnableSkypeCalling,
                                EnableGroups = EnableSkypeGroups,
                                EnableMediaCards = EnableSkypeMediaCards,
                                EnableMessaging = EnableSkypeMessaging,
                                EnableScreenSharing = EnableSkypeScreenSharing,
                                EnableVideo = EnableSkypeVideo,
                                IsEnabled = IsEnabled
                            }
                        };
                        break;
                    case ChannelNames.SlackChannel:
                        channel.Properties = new SlackChannel
                        {
                            Properties = new SlackChannelProperties()
                            {
                                ClientId = SlackClientId,
                                ClientSecret = SlackClientSecret,
                                LandingPageUrl = SlackLandingPageUrl,
                                VerificationToken = SlackVerificationToken,
                                IsEnabled = IsEnabled
                            }
                        };
                        break;
                    case ChannelNames.SmsChannel:
                        channel.Properties = new SmsChannel
                        {
                            Properties = new SmsChannelProperties()
                            {
                                AccountSID = SmsAccountSID,
                                AuthToken = SmsAuthToken,
                                Phone = SmsPhone,
                                IsEnabled = IsEnabled
                            }
                        };
                        break;
                    case ChannelNames.TelegramChannel:
                        channel.Properties = new TelegramChannel
                        {
                            Properties = new TelegramChannelProperties()
                            {
                                AccessToken = TelegramAccessToken,
                                IsEnabled = IsEnabled
                            }
                        };
                        break;
                    case ChannelNames.WebChatChannel:
                        channel.Properties = new WebChatChannel()
                        {
                            Properties = new WebChatChannelProperties()
                            {
                                Sites = WebChatSites
                            }
                        };
                        break;
                }

                if (Force.IsPresent || ShouldProcess(
                    this.Name, string.Format(CultureInfo.CurrentCulture, BotPowerShellMessages.NewBotChannel_ProcessMessage, Name, ChannelName)))
                {
                    var createBotChannelResponse = this.BotServiceClient.Channels.Create(
                                    this.ResourceGroupName,
                                    this.Name,
                                    ChannelNames.ToEnum(ChannelName),
                                    channel);

                    this.WriteBotChannel(createBotChannelResponse);
                }
            });
        }
    }
}
