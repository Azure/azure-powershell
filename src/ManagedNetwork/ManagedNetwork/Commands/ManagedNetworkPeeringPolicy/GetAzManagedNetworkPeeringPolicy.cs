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
    [Cmdlet(VerbsCommon.Get, "AzManagedNetworkPeeringPolicy", DefaultParameterSetName = Constants.NameParameterSet)]
    [OutputType(typeof(PSManagedNetwork))]
    public class GetAzManagedNetworkPeeringPolicy : AzureManagedNetworkCmdletBase
    {
        /// <summary>
        /// Gets or sets The Resource Group name
        /// </summary>
        [Parameter(Position = 0, 
            Mandatory = false, 
            HelpMessage = Constants.ResourceGroupNameHelp, 
            ParameterSetName = Constants.ListParameterSet)]
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.NameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, 
            Mandatory = true, 
            HelpMessage = Constants.ManagedNetworkNameHelp,
            ParameterSetName = Constants.ListParameterSet)]
        [Parameter(Position = 1,
            Mandatory = true,
            HelpMessage = Constants.ManagedNetworkNameHelp,
            ParameterSetName = Constants.NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ManagedNetworkName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = Constants.ManagedNetworkPeeringPolicyNameHelp,
            ParameterSetName = Constants.NameParameterSet)]
        [Parameter(Mandatory = false,
            HelpMessage = Constants.ManagedNetworkPeeringPolicyNameHelp,
            ParameterSetName = Constants.ManagedNetworkObjectParameterSet)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ARM resource ID
        /// </summary>
        [Parameter(Mandatory = true, 
            HelpMessage = Constants.ResourceIdNameHelp,
            ParameterSetName = Constants.ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the managed network
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = Constants.ManagedNetworkObjectHelp,
            ParameterSetName = Constants.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetwork ManagedNetworkObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(
                    this.ParameterSetName,
                    Constants.ResourceIdParameterSet))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ManagedNetworkName = resourceIdentifier.ParentResource.Split('/')[1];
                this.Name = resourceIdentifier.ResourceName;
            }
            else if (string.Equals(
                    this.ParameterSetName,
                    Constants.ManagedNetworkObjectParameterSet))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ManagedNetworkObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ManagedNetworkName = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var sdkResult = this.ManagedNetworkManagementClient.ManagedNetworkPeeringPolicies.Get(this.ResourceGroupName, this.ManagedNetworkName, this.Name);
                var psResult = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetworkPeeringPolicy>(sdkResult);
                WriteObject(psResult);
            }
            else
            {
                var sdkResult = this.ManagedNetworkManagementClient.ManagedNetworkPeeringPolicies.ListByManagedNetwork(this.ResourceGroupName, this.ManagedNetworkName);
                var psResult = sdkResult.Select(managedNetworkPolicy => ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetworkPeeringPolicy>(managedNetworkPolicy));
                WriteObject(psResult);
            }
        }
    }
}
