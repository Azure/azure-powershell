using Microsoft.Azure.Commands.BotService.Resources;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.BotService;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.BotService.BotService
{
    [Cmdlet(VerbsCommon.Remove, BotServiceChannelNounStr), OutputType(typeof(string))]
    public class RemoveAzureBotServiceChannel : BotServiceBaseCmdlet
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
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Name.")]
        public string Name { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Channel Name.")]
        public string ChannelName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(
                this.Name, string.Format(CultureInfo.CurrentCulture, BotPowerShellMessages.RemoveBotChannel_ProcessMessage, this.Name, this.ChannelName))
                ||
                Force.IsPresent)
            {
                RunCmdLet(() =>
                {
                    this.BotServiceClient.Channels.Delete(
                        this.ResourceGroupName,
                        this.Name,
                        this.ChannelName);
                });
            }
        }
    }
}
