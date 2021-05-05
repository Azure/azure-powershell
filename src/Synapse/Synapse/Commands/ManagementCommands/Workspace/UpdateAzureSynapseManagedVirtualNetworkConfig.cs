using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.ManagedVirtualNetworkConfig)]
    [OutputType(typeof(PSSynapseWorkspace))]
    public class UpdateAzureSynapseManagedVirtualNetworkConfig : SynapseManagementCmdletBase
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PreventDataExfiltration)]
        public bool PreventDataExfiltration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AllowedAadTenantIdsForLinking)]
        public string[] AllowedAadTenantIdsForLinking { get; set; }

        public override void ExecuteCmdlet()
        {
            var managedVirtualNetwork = WorkspaceObject.ManagedVirtualNetworkSettings;
            if (managedVirtualNetwork == null)
            {
                throw new AzPSResourceNotFoundCloudException(Resources.ManagedVirtualNetworkNotExist);
            }

            if (this.IsParameterBound(c => this.PreventDataExfiltration))
            {
                managedVirtualNetwork.PreventDataExfiltration = this.PreventDataExfiltration;
            }

            if (this.IsParameterBound(c => c.AllowedAadTenantIdsForLinking))
            {
                managedVirtualNetwork.AllowedAadTenantIdsForLinking = this.AllowedAadTenantIdsForLinking;
            }

            WorkspaceObject.ManagedVirtualNetworkSettings = managedVirtualNetwork;
            WriteObject(WorkspaceObject);
        }
    }
}
