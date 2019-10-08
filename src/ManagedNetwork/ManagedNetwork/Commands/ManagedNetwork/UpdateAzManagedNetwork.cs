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
    [Cmdlet(VerbsData.Update, "AzManagedNetwork", SupportsShouldProcess = true, DefaultParameterSetName = Constants.NameParameterSet)]
    [OutputType(typeof(PSManagedNetwork))]
    public class UpdateAzManagedNetwork : AzureManagedNetworkCmdletBase
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
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedNetworkScopeHelp)]
        public PSScope Scope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedNetworkTagHelp)]
        public Hashtable Tag { get; set; }

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
        /// Gets or sets the ARM resource ID
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = Constants.InputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = Constants.InputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedNetwork InputObject { get; set; }

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
                this.Name = resourceIdentifier.ResourceName;
            }
            else if (string.Equals(
                    this.ParameterSetName,
                    Constants.InputObjectParameterSet))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
                this.Scope = this.InputObject.Scope;
                this.Tag = new Hashtable();
                foreach(var entry in this.InputObject.Tags)
                {
                    this.Tag.Add(entry.Key, entry.Value);
                }
            }

            var present = IsManagedNetworkPresent(ResourceGroupName, Name);
            if(!present)
            {
                throw new Exception(string.Format(Constants.ManagedNetworkDoesNotExist, this.Name, this.ResourceGroupName));
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(Constants.ConfirmOverwriteResource, Name),
                Constants.UpdatingResource,
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
