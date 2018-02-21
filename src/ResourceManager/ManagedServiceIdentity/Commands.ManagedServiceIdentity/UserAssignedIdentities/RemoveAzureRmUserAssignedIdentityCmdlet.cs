using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedServiceIdentity.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ManagedServiceIdentity.UserAssignedIdentities
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmUserAssignedIdentity", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmUserAssignedIdentityCmdlet : MsiBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Identity name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                ConfirmAction(Force.IsPresent,
                    string.Format(CultureInfo.CurrentCulture, Properties.Resources.RemoveUserAssignedIdentity_ContinueMessage, this.ResourceGroupName, this.Name),
                    string.Format(CultureInfo.CurrentCulture, Properties.Resources.RemoveUserAssignedIdentity_ProcessMessage, this.ResourceGroupName, this.Name),
                    Name,
                    () => this.MsiClient.UserAssignedIdentities.DeleteWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.Name).GetAwaiter().GetResult());
            });
        }
    }
}
