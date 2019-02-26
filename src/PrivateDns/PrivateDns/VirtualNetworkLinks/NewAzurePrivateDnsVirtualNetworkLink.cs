// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.PrivateDns.VirtualNetworkLinks
{
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Creates a new zone.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsVirtualNetworkLink", SupportsShouldProcess = true, DefaultParameterSetName = IdParameterSetName), OutputType(typeof(PSPrivateDnsLink))]
    public class NewAzurePrivateDnsVirtualNetworkLink : PrivateDnsBaseCmdlet
    {
        private const string IdParameterSetName = "VirtualNetworkId";
        private const string ObjectParameterSetName = "Object";

        [Parameter(Mandatory = true, HelpMessage = "The resource group in which to create the zone.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the zone associated with the link (without a terminating dot).")]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ZoneName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the link.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource id of the virtual network associated with the link.", ParameterSetName = IdParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource id of the virtual network associated with the link.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public VirtualNetwork VirtualNetwork { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Boolean that represents if the link is registration enabled or not.")]
        [ValidateNotNullOrEmpty]
        public bool IsRegistrationEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ZoneName.EndsWith("."))
            {
                this.ZoneName = this.ZoneName.TrimEnd('.');
                this.WriteWarning($"Modifying zone name to remove terminating '.'.  Zone name used is \"{this.ZoneName}\".");
            }

            ConfirmAction(
                ProjectResources.Progress_CreatingNewVirtualNetworkLink,
                this.Name,
                () =>
                {
                    var result = this.PrivateDnsClient.CreatePrivateDnsLink(
                        this.Name,
                        this.ResourceGroupName,
                        this.ZoneName,
                        (this.VirtualNetwork != null) ? this.VirtualNetwork.Id : this.VirtualNetworkId,
                        this.IsRegistrationEnabled,
                        this.Tag);
                    this.WriteVerbose(ProjectResources.Success);
                    this.WriteVerbose(string.Format(ProjectResources.Success_NewVirtualNetworkLink, this.Name, this.ResourceGroupName));
                    this.WriteObject(result);
                });
        }
    }
}
