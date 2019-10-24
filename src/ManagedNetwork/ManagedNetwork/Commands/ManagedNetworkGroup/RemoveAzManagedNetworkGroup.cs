using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedNetwork.Common;
using Microsoft.Azure.Management.ManagedNetwork;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ManagedNetwork.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Properties = Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Properties;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzManagedNetworkGroup", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.NameParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzManagedNetworkGroup : AzureManagedNetworkCmdletBase
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

        /// <summary>
        /// Gets or sets the Managed Network Name
        /// </summary>
        [Parameter(Position = 1, 
            Mandatory = true, 
            HelpMessage = HelpMessage.ManagedNetworkNameHelp,
            ParameterSetName = ParameterSetNames.NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ManagedNetworkName { get; set; }

        /// <summary>
        /// Gets or sets the Managed Network Name
        /// </summary>
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
        /// Gets or sets the mangaged Network Group
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

        [Parameter(Mandatory = false, HelpMessage = HelpMessage.PassThruHelp)]
        public SwitchParameter PassThru { get; set; }

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

            var present = IsManagedNetworkPresent(ResourceGroupName, ManagedNetworkName);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.ConfirmDeleteResource, ManagedNetworkName),
                Properties.Resources.DeletingResource,
                Name,
                () =>
                {
                    RemoveManagedNetworkGroup();
                    if (this.PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                },
                () => present);
        }
        private void RemoveManagedNetworkGroup()
        {
            this.ManagedNetworkManagementClient.ManagedNetworkGroups.Delete(this.ResourceGroupName, this.ManagedNetworkName, this.Name);
        }
    }
}
