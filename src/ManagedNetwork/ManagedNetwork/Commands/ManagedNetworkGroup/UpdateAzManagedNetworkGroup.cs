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
    [Cmdlet(VerbsData.Update, "AzManagedNetworkGroup", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.NameParameterSet)]
    [OutputType(typeof(PSManagedNetworkGroup))]
    public class UpdateAzManagedNetworkGroup : AzureManagedNetworkCmdletBase
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
            HelpMessage = HelpMessage.ManagedNetworkGroupNameHelp,
            ParameterSetName = ParameterSetNames.NameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.ManagedNetworkGroupNameHelp,
            ParameterSetName = ParameterSetNames.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.ManagedNetwork/managedNetworks/managednetworkgroups", "ResourceGroupName", "ManagedNetworkName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ARM resource ID
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.ResourceIdNameHelp,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.ManagedNetwork/managedNetworks/managednetworkgroups")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Input Object
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.InputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = ParameterSetNames.InputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetworkGroup InputObject { get; set; }

        /// <summary>
        /// Gets or sets the managed network
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.ManagedNetworkObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = ParameterSetNames.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetwork ManagedNetworkObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork management group ids.")]
        public string[] ManagementGroupIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork subscription ids.")]
        public string[] SubscriptionIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork virtual network ids.")]
        public string[] VirtualNetworkIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork subnet ids.")]
        public string[] SubnetIdList { get; set; }

        /// <summary>
        ///     Do not ask for confirmation if you want to override a resource.
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

            var present = IsManagedNetworkGroupPresent(ResourceGroupName, ManagedNetworkName, Name);
            if(!present)
            {
                throw new Exception(string.Format(Properties.Resources.ManagedNetworkGroupDoesNotExist, this.Name, this.ManagedNetworkName, this.ResourceGroupName));
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.ConfirmOverwriteResource, Name),
                Properties.Resources.UpdatingResource,
                Name,
                () =>
                {
                    PSManagedNetworkGroup managedNetworkGroup = UpdateManagedNetworkGroup();
                    WriteObject(managedNetworkGroup);
                },
                () => present);
        }

        private PSManagedNetworkGroup UpdateManagedNetworkGroup()
        {
            var sdkManagedNetworkGroup = this.ManagedNetworkManagementClient.ManagedNetworkGroups.Get(this.ResourceGroupName, this.ManagedNetworkName, this.Name);
            var psManagedNetworkGroup = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetworkGroup>(sdkManagedNetworkGroup);

            if (this.ManagementGroupIdList != null)
            {
                psManagedNetworkGroup.ManagementGroups = this.ManagementGroupIdList.Select(id => new PSResourceId() { Id = id }).ToList();
            }

            if (this.SubscriptionIdList != null)
            {
                psManagedNetworkGroup.Subscriptions = this.SubscriptionIdList.Select(id => new PSResourceId() { Id = id }).ToList();
            }

            if (this.VirtualNetworkIdList != null)
            {
                psManagedNetworkGroup.VirtualNetworks = this.VirtualNetworkIdList.Select(id => new PSResourceId() { Id = id }).ToList();
            }

            if (this.SubscriptionIdList != null)
            {
                psManagedNetworkGroup.Subnets = this.SubnetIdList.Select(id => new PSResourceId() { Id = id }).ToList();
            }

            sdkManagedNetworkGroup = ManagedNetworkResourceManagerProfile.Mapper.Map<ManagedNetworkGroup>(psManagedNetworkGroup);
            var putSdkResponse = this.ManagedNetworkManagementClient.ManagedNetworkGroups.CreateOrUpdate(sdkManagedNetworkGroup, this.ResourceGroupName, this.ManagedNetworkName, this.Name);
            var putPSResponse = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetworkGroup>(putSdkResponse);
            return putPSResponse;
        }
    }
}
