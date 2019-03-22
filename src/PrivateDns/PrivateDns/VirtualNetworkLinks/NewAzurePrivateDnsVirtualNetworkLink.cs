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
    using Microsoft.Azure.Management.Internal.Network.Common;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Creates a new zone.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsVirtualNetworkLink", SupportsShouldProcess = true, DefaultParameterSetName = IdParameterSetName), OutputType(typeof(PSPrivateDnsVirtualNetworkLink))]
    public class NewAzurePrivateDnsVirtualNetworkLink : PrivateDnsBaseCmdlet
    {
        private const string IdParameterSetName = "VirtualNetworkId";
        private const string ObjectParameterSetName = "VirtualNetworkObject";

        [Parameter(Mandatory = true, HelpMessage = "The resource group in which to create the virtual network link. Should match resource group of the private DNS zone")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the Private DNS zone associated with the virtual network link (without a terminating dot).")]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ZoneName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the virtual network link.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource id of the virtual network associated with the link.", ParameterSetName = IdParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource object of the virtual network associated with the link.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public IVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Switch parameter that represents if the virtual network link is registration enabled or not.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableRegistration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ZoneName = TrimTrailingDotInZoneName(this.ZoneName);

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
                        this.EnableRegistration.IsPresent,
                        this.Tag);
                    this.WriteVerbose(ProjectResources.Success);
                    this.WriteVerbose(string.Format(ProjectResources.Success_NewVirtualNetworkLink, this.Name, this.ResourceGroupName));
                    this.WriteObject(result);
                });
        }
    }
}
