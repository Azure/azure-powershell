using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedNetwork.Common;
using Microsoft.Azure.Commands.ManagedNetwork.Helpers;
using Microsoft.Azure.Management.ManagedNetwork;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ManagedNetwork.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ManagedNetwork.Models;
using System.Resources;
using System.Collections;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Properties = Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Properties;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzManagedNetworkGroup", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.NameParameterSet)]
    [OutputType(typeof(PSManagedNetworkGroup))]
    public class NewAzManagedNetworkGroup : AzureManagedNetworkCmdletBase
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
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.ManagedNetworkObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = ParameterSetNames.ManagedNetworkObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetwork ManagedNetworkObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessage.ManagedNetworkLocationHelp)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.ManagedNetwork/managedNetworks/managednetworkgroups")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork management group ids.")]
        public string[] ManagementGroupIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork subscription ids.")]
        public string[] SubscriptionIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork virtual network ids.")]
        public string[] VirtualNetworkIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork subnet ids.")]
        public string[] SubnetIdList { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
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

            if (string.Equals(
                    this.ParameterSetName,
                    ParameterSetNames.ManagedNetworkObjectParameterSet))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ManagedNetworkObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ManagedNetworkName = resourceIdentifier.ResourceName;
            }

            var present = IsManagedNetworkGroupPresent(ResourceGroupName, ManagedNetworkName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.ConfirmOverwriteResource, Name),
                Properties.Resources.CreatingResource,
                Name,
                () =>
                {
                    PSManagedNetworkGroup managedNetworkGroup = CreateManagedNetworkGroup();
                    WriteObject(managedNetworkGroup);
                },
                () => present);
        }

        private PSManagedNetworkGroup CreateManagedNetworkGroup()
        {
            PSManagedNetworkGroup psManagedNetworkGroup = new PSManagedNetworkGroup();
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

            if (this.SubnetIdList != null)
            {
                psManagedNetworkGroup.Subnets = this.SubnetIdList.Select(id => new PSResourceId() { Id = id }).ToList();
            }

            var sdkManagedNetworkGroup = ManagedNetworkResourceManagerProfile.Mapper.Map<ManagedNetworkGroup>(psManagedNetworkGroup);
            sdkManagedNetworkGroup.Location = this.Location;
            var putSdkResponse = this.ManagedNetworkManagementClient.ManagedNetworkGroups.CreateOrUpdate(sdkManagedNetworkGroup, this.ResourceGroupName, this.ManagedNetworkName, this.Name);
            var putPSResponse = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetworkGroup>(putSdkResponse);
            return putPSResponse;
        }
    }
}
