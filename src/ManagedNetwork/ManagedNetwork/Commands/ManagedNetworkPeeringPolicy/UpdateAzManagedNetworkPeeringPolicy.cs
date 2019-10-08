using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedNetwork.Common;
using Microsoft.Azure.Management.ManagedNetwork;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ManagedNetwork.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ManagedNetwork.Models;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzManagedNetworkPeeringPolicy", SupportsShouldProcess = true, DefaultParameterSetName = Constants.NameParameterSet)]
    [OutputType(typeof(PSManagedNetwork))]
    public class UpdateAzManagedNetworkPeeringPolicy : AzureManagedNetworkCmdletBase
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

        /// <summary>
        /// Gets or sets the ARM resource ID
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = Constants.ResourceIdNameHelp,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Input Object
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = Constants.InputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = Constants.InputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetworkPeeringPolicy InputObject { get; set; }

        /// <summary>
        /// Gets or sets the managed network
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = Constants.ManagedNetworkObjectHelp,
            ParameterSetName = Constants.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetwork ManagedNetworkObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Policy type.")]
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
                Constants.ResourceIdParameterSet))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ManagedNetworkName = resourceIdentifier.ParentResource.Split('/')[1];
                this.Name = resourceIdentifier.ResourceName;
            }
            else if (string.Equals(
                    this.ParameterSetName,
                    Constants.InputObjectParameterSet))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
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

            var present = IsManagedNetworkPeeringPolicyPresent(ResourceGroupName, ManagedNetworkName, Name);
            if(!present)
            {
                throw new Exception(string.Format(Constants.ManagedNetworkPeeringPolicyDoesNotExist, this.Name, this.ManagedNetworkName, this.ResourceGroupName));
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(Constants.ConfirmOverwriteResource, Name),
                Constants.UpdatingResource,
                Name,
                () =>
                {
                    var managedNetworkGroup = UpdateManagedNetworkPeeringPolicy();
                    WriteObject(managedNetworkGroup);
                },
                () => present);
        }

        private PSManagedNetworkPeeringPolicy UpdateManagedNetworkPeeringPolicy()
        {
            var sdkManagedNetworkPeeringPolicy = this.ManagedNetworkManagementClient.ManagedNetworkPeeringPolicies.Get(this.ResourceGroupName, this.ManagedNetworkName, this.Name);
            var psManagedNetworkPeeringPolicy = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetworkPeeringPolicy>(sdkManagedNetworkPeeringPolicy);
            var managedNetworkPeeringPolicyProperties = psManagedNetworkPeeringPolicy.Properties;

            if (this.PeeringPolicyType != null)
            {
                managedNetworkPeeringPolicyProperties.Type = this.PeeringPolicyType;
            }

            if (this.Hub != null)
            {
                managedNetworkPeeringPolicyProperties.Hub = new PSResourceId() { Id = this.Hub };
            }

            if (this.SpokeList != null)
            {
                managedNetworkPeeringPolicyProperties.Spokes = this.SpokeList.Select(id => new PSResourceId() { Id = id }).ToList();
            }

            if (this.Mesh != null)
            {
                managedNetworkPeeringPolicyProperties.Mesh = this.Mesh.Select(id => new PSResourceId() { Id = id }).ToList();
            }
            psManagedNetworkPeeringPolicy.Properties = managedNetworkPeeringPolicyProperties;
            sdkManagedNetworkPeeringPolicy = ManagedNetworkResourceManagerProfile.Mapper.Map<ManagedNetworkPeeringPolicy>(psManagedNetworkPeeringPolicy);
            var putSdkResponse = this.ManagedNetworkManagementClient.ManagedNetworkPeeringPolicies.CreateOrUpdate(sdkManagedNetworkPeeringPolicy, this.ResourceGroupName, this.ManagedNetworkName, this.Name);
            var putPSResponse = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetworkPeeringPolicy>(putSdkResponse);
            return putPSResponse;
        }
    }
}
