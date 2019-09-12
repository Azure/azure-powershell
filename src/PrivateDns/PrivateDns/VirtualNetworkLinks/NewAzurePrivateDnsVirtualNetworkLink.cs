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
    using System.Collections.Generic;
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
        private const string RemoteIdParameterSetName = "RemoteVirtualNetworkId";

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

        [Parameter(Mandatory = true, HelpMessage = "The resource id of the virtual network in another tenant.", ParameterSetName = RemoteIdParameterSetName)]
        public string RemoteVirtualNetworkId { get; set; }

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
                    Dictionary<string, List<string>> auxAuthHeader = null;
                    // If link is being created in a VNet belonging to a diff tenant than the Private DNS zone
                    if (this.VirtualNetwork == null && this.VirtualNetworkId == null && !string.IsNullOrEmpty(this.RemoteVirtualNetworkId))
                    {
                        var auxHeaderDict = GetAuxilaryAuthHeaderFromResourceIds(new List<string>() { this.RemoteVirtualNetworkId });
                        if (auxHeaderDict != null && auxHeaderDict.Count > 0)
                        {
                            auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDict);
                        }
                    }

                    var result = this.PrivateDnsClient.CreatePrivateDnsLink(
                        this.Name,
                        this.ResourceGroupName,
                        this.ZoneName,
                        (this.VirtualNetwork != null) ? this.VirtualNetwork.Id : (this.VirtualNetworkId != null) ? this.VirtualNetworkId : this.RemoteVirtualNetworkId,
                        this.EnableRegistration.IsPresent,
                        this.Tag,
                        auxAuthHeader);
                    this.WriteVerbose(ProjectResources.Success);
                    this.WriteVerbose(string.Format(ProjectResources.Success_NewVirtualNetworkLink, this.Name, this.ResourceGroupName));
                    this.WriteObject(result);
                });
        }
    }
}
