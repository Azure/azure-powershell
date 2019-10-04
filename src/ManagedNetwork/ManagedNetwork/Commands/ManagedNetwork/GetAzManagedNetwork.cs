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
    [Cmdlet(VerbsCommon.Get, "AzManagedNetwork", DefaultParameterSetName = Constants.NameParameterSet)]
    [OutputType(typeof(PSManagedNetwork))]
    public class GetAzManagedNetwork : AzureManagedNetworkCmdletBase
    {
        /// <summary>
        /// Gets or sets The Resource Group name
        /// </summary>
        [Parameter( 
            Mandatory = false, 
            HelpMessage = Constants.ResourceGroupNameHelp, 
            ParameterSetName = Constants.ListParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.NameParameterSet)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = Constants.ManagedNetworkNameHelp,
            ParameterSetName = Constants.NameParameterSet)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ARM resource ID
        /// </summary>
        [Parameter(Mandatory = true, 
            HelpMessage = Constants.ResourceIdNameHelp,
            ParameterSetName = Constants.ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(
                    this.ParameterSetName,
                    Constants.ResourceIdParameterSet))
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
