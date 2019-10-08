using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedNetwork.Common;
using Microsoft.Azure.Management.ManagedNetwork;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ManagedNetwork.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ManagedNetwork.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzManagedNetworkPeeringPolicy", SupportsShouldProcess = true, DefaultParameterSetName = Constants.NameParameterSet)]
    [OutputType(typeof(PSManagedNetwork))]
    public class NewAzManagedNetworkPeeringPolicy : AzureManagedNetworkCmdletBase
    {
        /// <summary>
        /// Gets or sets The Resource Group name
        /// </summary>
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
            ParameterSetName = Constants.NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ManagedNetworkName { get; set; }

        [Parameter(Position = 2, 
            Mandatory = true, 
            HelpMessage = Constants.ManagedNetworkPeeringPolicyNameHelp,
            ParameterSetName = Constants.NameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = Constants.ManagedNetworkPeeringPolicyNameHelp,
            ParameterSetName = Constants.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = Constants.ManagedNetworkObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetwork ManagedNetworkObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure ManagedNetwork Policy location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure ManagedNetwork Policy type.")]
        [ValidateNotNullOrEmpty]
        public string PeeringPolicyType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Policy Hub id.")]
        public string Hub { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Policy Spoke Groups.")]
        public List<string> SpokeList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Policy Mesh Groups.")]
        public List<string> Mesh { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.ForceHelp)]
        public SwitchParameter Force { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(
                    this.ParameterSetName,
                    Constants.ManagedNetworkObjectParameterSet))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ManagedNetworkObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ManagedNetworkName = resourceIdentifier.ResourceName;
            }

            var present = IsManagedNetworkPeeringPolicyPresent(ResourceGroupName, ManagedNetworkName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Constants.ConfirmOverwriteResource, Name),
                Constants.CreatingResource,
                Name,
                () =>
                {
                    var managedNetworkPeeringPolicy = CreateManagedNetworkPeeringPolicy();
                    WriteObject(managedNetworkPeeringPolicy);
                },
                () => present);
        }

        private PSManagedNetworkPeeringPolicy CreateManagedNetworkPeeringPolicy()
        {
            PSManagedNetworkPeeringPolicyProperties psManagedNetworkPeeringPolicyProperties = new PSManagedNetworkPeeringPolicyProperties()
            {
                Type = this.PeeringPolicyType
            };

            if (this.Hub != null)
            {
                psManagedNetworkPeeringPolicyProperties.Hub = new PSResourceId() { Id = this.Hub };
            }

            if (this.SpokeList != null)
            {
                psManagedNetworkPeeringPolicyProperties.Spokes = this.SpokeList.Select(id => new PSResourceId() { Id = id }).ToList();
            }

            if (this.Mesh != null)
            {
                psManagedNetworkPeeringPolicyProperties.Mesh = this.Mesh.Select(id => new PSResourceId() { Id = id }).ToList();
            }

            PSManagedNetworkPeeringPolicy psManagedNetworkPeeringPolicy = new PSManagedNetworkPeeringPolicy();
            psManagedNetworkPeeringPolicy.Properties = psManagedNetworkPeeringPolicyProperties;
            psManagedNetworkPeeringPolicy.Location = this.Location;
            var sdkManagedNetworkPeeringPolicy = ManagedNetworkResourceManagerProfile.Mapper.Map<ManagedNetworkPeeringPolicy>(psManagedNetworkPeeringPolicy);
            var putSdkResponse = this.ManagedNetworkManagementClient.ManagedNetworkPeeringPolicies.CreateOrUpdate(sdkManagedNetworkPeeringPolicy, this.ResourceGroupName, this.ManagedNetworkName, this.Name);
            var putPSResponse = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetworkPeeringPolicy>(putSdkResponse);
            return putPSResponse;
        }
    }
}
