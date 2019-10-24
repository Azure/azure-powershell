using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedNetwork.Common;
using Microsoft.Azure.Management.ManagedNetwork;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ManagedNetwork.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzManagedNetwork", DefaultParameterSetName = ParameterSetNames.NameParameterSet)]
    [OutputType(typeof(PSManagedNetwork))]
    public class GetAzManagedNetwork : AzureManagedNetworkCmdletBase
    {
        [Parameter(
           Mandatory = false,
           HelpMessage = HelpMessage.ManagedNetworkNameHelp,
           ParameterSetName = ParameterSetNames.ListParameterSet)]
        [Parameter(
           Mandatory = true,
           HelpMessage = HelpMessage.ManagedNetworkNameHelp,
           ParameterSetName = ParameterSetNames.NameParameterSet)]
        [ResourceNameCompleter("Microsoft.ManagedNetwork/managedNetworks", "ResourceGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets The Resource Group name
        /// </summary>
        [Parameter( 
            Mandatory = false,
            HelpMessage = HelpMessage.ResourceGroupNameHelp,
            ParameterSetName = ParameterSetNames.ListParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = HelpMessage.ResourceGroupNameHelp,
            ParameterSetName = ParameterSetNames.NameParameterSet)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the ARM resource ID
        /// </summary>
        [Parameter(Mandatory = true, 
            HelpMessage = HelpMessage.ResourceIdNameHelp,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.ManagedNetwork/managedNetworks")]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(
                    this.ParameterSetName,
                    ParameterSetNames.ResourceIdParameterSet))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var sdkResult = this.ManagedNetworkManagementClient.ManagedNetworks.Get(this.ResourceGroupName, this.Name);
                var psResult = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetwork>(sdkResult);
                WriteObject(psResult);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var sdkResult = this.ManagedNetworkManagementClient.ManagedNetworks.ListByResourceGroup(this.ResourceGroupName);
                var psResult = sdkResult.Select(managedNetwork => ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetwork>(managedNetwork));
                WriteObject(psResult);
            }
            else
            {
                var sdkResult = this.ManagedNetworkManagementClient.ManagedNetworks.ListBySubscription();
                var psResult = sdkResult.Select(managedNetwork => ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetwork>(managedNetwork));
                WriteObject(psResult);
            }
        }
    }
}
