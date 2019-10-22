using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedNetwork.Common;
using Microsoft.Azure.Management.ManagedNetwork;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ManagedNetwork.Models;
using Microsoft.Azure.Commands.ManagedNetwork.Models;
using System.Collections;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzManagedNetwork", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.NameParameterSet)]
    [OutputType(typeof(PSManagedNetwork))]
    public class UpdateAzManagedNetwork : AzureManagedNetworkCmdletBase
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
        [ResourceNameCompleter("Microsoft.ManagedNetwork/managedNetworks", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessage.ManagedNetworkScopeHelp)]
        public PSScope Scope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessage.ManagedNetworkTagHelp)]
        public Hashtable Tag { get; set; }

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

        /// <summary>
        /// Gets or sets the Input Object
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessage.InputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = ParameterSetNames.InputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetwork InputObject { get; set; }

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
                    this.Name = resourceIdentifier.ResourceName;
                    break;
                case ParameterSetNames.InputObjectParameterSet:
                    resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    this.Name = resourceIdentifier.ResourceName;
                    if (this.Scope == null)
                    {
                        this.Scope = this.InputObject.Scope;
                    }

                    if (this.Tag == null)
                    {
                        this.Tag = new Hashtable();
                        foreach (var entry in this.InputObject.Tags)
                        {
                            this.Tag.Add(entry.Key, entry.Value);
                        }
                    }
                    break;
                default:
                    break;
            }


            var present = IsManagedNetworkPresent(ResourceGroupName, Name);
            if(!present)
            {
                throw new Exception(string.Format(Properties.Resources.ManagedNetworkDoesNotExist, this.Name, this.ResourceGroupName));
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.ConfirmOverwriteResource, Name),
                Properties.Resources.UpdatingResource,
                Name,
                () =>
                {
                    var managedNetwork = UpdateManagedNetwork();
                    WriteObject(managedNetwork);
                },
                () => present);
        }

        private PSManagedNetwork UpdateManagedNetwork()
        {
            var sdkManagedNetwork = this.ManagedNetworkManagementClient.ManagedNetworks.Get(this.ResourceGroupName, this.Name);
            var psManagedNetwork = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetwork>(sdkManagedNetwork);

            if(this.Scope != null)
            {
                psManagedNetwork.Scope = this.Scope;
            }
            if (this.Tag != null)
            {
                psManagedNetwork.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(table => (string)table.Key, table => (string)table.Value);
            }


            sdkManagedNetwork = ManagedNetworkResourceManagerProfile.Mapper.Map<ManagedNetworkModel>(psManagedNetwork);
            var updateSdkResponse = this.ManagedNetworkManagementClient.ManagedNetworks.CreateOrUpdate(sdkManagedNetwork, this.ResourceGroupName, this.Name);
            var updatePSResponse = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetwork>(updateSdkResponse);
            return updatePSResponse;
        }
    }
}
