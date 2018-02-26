using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedServiceIdentity.Common;
using Microsoft.Azure.Commands.ManagedServiceIdentity.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Resources.Models;

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
            ParameterSetName = Constants.ResourceGroupAndNameParameterSet,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ResourceGroupAndNameParameterSet,
            HelpMessage = "The Identity name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The Identity object.")]
        [ValidateNotNullOrEmpty]
        public PsUserAssignedIdentity Identity { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = Constants.ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Identity's resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Force execution of the cmdlet.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.Name = identifier.ResourceName;
            }

            if (this.Identity != null)
            {
                this.ResourceGroupName = this.Identity.ResourceGroupName;
                this.Name = this.Identity.Name;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(CultureInfo.CurrentCulture,
                    Properties.Resources.RemoveUserAssignedIdentity_ContinueMessage,
                    this.ResourceGroupName,
                    this.Name),
                string.Format(CultureInfo.CurrentCulture,
                    Properties.Resources.RemoveUserAssignedIdentity_ProcessMessage,
                    this.ResourceGroupName,
                    this.Name),
                Name,
                ExecuteDelete);
        }

        private void ExecuteDelete()
        {
            this.MsiClient.UserAssignedIdentities.DeleteWithHttpMessagesAsync(
                this.ResourceGroupName,
                this.Name);
        }
    }
}
