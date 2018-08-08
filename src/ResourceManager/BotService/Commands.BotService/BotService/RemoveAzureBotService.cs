using Microsoft.Azure.Commands.BotService.Resources;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.BotService;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.BotService.BotService
{
    [Cmdlet(VerbsCommon.Remove, BotServiceNounStr), OutputType(typeof(string))]
    public class RemoveAzureBotService : BotServiceBaseCmdlet
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

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(
                this.Name, string.Format(CultureInfo.CurrentCulture, BotPowerShellMessages.RemoveBot_ProcessMessage, this.Name))
                ||
                Force.IsPresent)
            {
                RunCmdLet(() =>
                {
                    this.BotServiceClient.Bots.Delete(
                        this.ResourceGroupName,
                        this.Name);
                });
            }
        }
    }
}
