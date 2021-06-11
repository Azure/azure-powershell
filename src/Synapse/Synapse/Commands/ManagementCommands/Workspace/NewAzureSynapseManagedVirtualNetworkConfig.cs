using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Synapse.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.ManagedVirtualNetworkConfig)]
    [OutputType(typeof(PSManagedVirtualNetworkSettings))]
    public class NewAzureSynapseManagedVirtualNetworkConfig : SynapseManagementCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PreventDataExfiltration)]
        public SwitchParameter PreventDataExfiltration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AllowedAadTenantIdsForLinking)]
        public string[] AllowedAadTenantIdsForLinking { get; set; }

        public override void ExecuteCmdlet()
        {
            var settings = new ManagedVirtualNetworkSettings
            {
                PreventDataExfiltration = this.PreventDataExfiltration,
                AllowedAadTenantIdsForLinking = this.AllowedAadTenantIdsForLinking
            };

            WriteObject(new PSManagedVirtualNetworkSettings(settings));
        }
    }
}
