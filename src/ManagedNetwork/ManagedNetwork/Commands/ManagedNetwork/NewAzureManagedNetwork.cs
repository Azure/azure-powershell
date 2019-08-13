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

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzManagedNetwork", SupportsShouldProcess = true)]
    [OutputType(typeof(PSManagedNetwork))]
    public class NewAzureManagedNetwork : AzureManagedNetworkCmdletBase
    {
        /// <summary>
        /// Gets or sets The Resource Group name
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, HelpMessage = Constants.ResourceGroupNameHelp)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = Constants.ManagedNetworkNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = Constants.ManagedNetworkScopeHelp)]
        [ValidateNotNullOrEmpty]
        public PSScope Scope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedNetworkTagsHelp)]
        public List<string> Tags { get; set; }


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
            var present = IsManagedNetworkPresent(ResourceGroupName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Constants.ConfirmOverwriteResource, Name),
                Constants.CreatingResource,
                Name,
                () =>
                {
                    var managedNetwork = CreateManagedNetwork();
                    WriteObject(managedNetwork);
                },
                () => present);
        }

        private PSManagedNetwork CreateManagedNetwork()
        {
            PSManagedNetwork psManagedNetwork = new PSManagedNetwork()
            {
                Scope = this.Scope ?? new PSScope(),
                Tags = this.Tags ?? new List<string>()
            };

            var sdkManagedNetwork = ManagedNetworkResourceManagerProfile.Mapper.Map<ManagedNetworkModel>(psManagedNetwork);
            var putSdkResponse = this.ManagedNetworkManagementClient.ManagedNetworks.CreateOrUpdate(sdkManagedNetwork, this.ResourceGroupName, this.Name);
            var putPSResponse = ManagedNetworkResourceManagerProfile.Mapper.Map<PSManagedNetwork>(putSdkResponse);
            return putPSResponse;
        }
    }
}
