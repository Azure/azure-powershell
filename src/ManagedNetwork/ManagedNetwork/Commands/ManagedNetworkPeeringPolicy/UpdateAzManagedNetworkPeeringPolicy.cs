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
using Properties = Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Properties;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzManagedNetworkPeeringPolicy", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.NameParameterSet)]
    [OutputType(typeof(PSManagedNetworkPeeringPolicy))]
    public class UpdateAzManagedNetworkPeeringPolicy : AzureManagedNetworkCmdletBase
    {
        /// <summary>
        /// Gets or sets The Resource Group name
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = HelpMessage.ResourceGroupNameHelp,
            ParameterSetName = ParameterSetNames.NameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            HelpMessage = HelpMessage.ManagedNetworkNameHelp,
            ParameterSetName = ParameterSetNames.NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ManagedNetworkName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = HelpMessage.ManagedNetworkPeeringPolicyNameHelp,
            ParameterSetName = ParameterSetNames.NameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.ManagedNetworkPeeringPolicyNameHelp,
            ParameterSetName = ParameterSetNames.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.ManagedNetwork/managedNetworks/managednetworkpeeringpolicies", "ResourceGroupName", "ManagedNetworkName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ARM resource ID
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.ResourceIdNameHelp,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.ManagedNetwork/managedNetworks/managednetworkpeeringpolicies")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Input Object
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.InputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = ParameterSetNames.InputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetworkPeeringPolicy InputObject { get; set; }

        /// <summary>
        /// Gets or sets the managed network
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.ManagedNetworkObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = ParameterSetNames.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetwork ManagedNetworkObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Policy type.")]
        public string PeeringPolicyType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Policy Hub id.")]
        public string Hub { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Policy Spoke Groups.")]
        public string[] SpokeList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Policy Mesh Groups.")]
        public string[] Mesh { get; set; }

        /// <summary>
        ///     Do not ask for confirmation if you want to override a resource
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = HelpMessage.ForceHelp)]
        public SwitchParameter Force { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = HelpMessage.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            switch (this.ParameterSetName)
            {
                case ParameterSetNames.ResourceIdParameterSet:
                    var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    this.ManagedNetworkName = resourceIdentifier.ParentResource.Split('/')[1];
                    this.Name = resourceIdentifier.ResourceName;
                    break;
                case ParameterSetNames.InputObjectParameterSet:
                    resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    this.ManagedNetworkName = resourceIdentifier.ParentResource.Split('/')[1];
                    this.Name = resourceIdentifier.ResourceName;
                    break;
                case ParameterSetNames.ManagedNetworkObjectParameterSet:
                    resourceIdentifier = new ResourceIdentifier(this.ManagedNetworkObject.Id);
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    this.ManagedNetworkName = resourceIdentifier.ResourceName;
                    break;
                default:
                    break;
            }

            var present = IsManagedNetworkPeeringPolicyPresent(ResourceGroupName, ManagedNetworkName, Name);
            if(!present)
            {
                throw new Exception(string.Format(Properties.Resources.ManagedNetworkPeeringPolicyDoesNotExist, this.Name, this.ManagedNetworkName, this.ResourceGroupName));
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.ConfirmOverwriteResource, Name),
                Properties.Resources.UpdatingResource,
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
