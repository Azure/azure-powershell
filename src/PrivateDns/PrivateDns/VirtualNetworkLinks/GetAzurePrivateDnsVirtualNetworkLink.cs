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


using System;

namespace Microsoft.Azure.Commands.PrivateDns.VirtualNetworkLinks
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Gets one or more existing zones.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsVirtualNetworkLink"), OutputType(typeof(PSPrivateDnsVirtualNetworkLink))]
    public class GetAzurePrivateDnsVirtualNetworkLink : PrivateDnsBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The resource group in which the virtual network link and private zone exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the Private DNS zone (without a terminating dot).")]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ZoneName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The full name of the virtual network link.")]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones/virtualNetworkLinks", "ResourceGroupName", "ZoneName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.Name != null)
            {
                this.ZoneName = TrimTrailingDotInZoneName(this.ZoneName);

                this.WriteObject(this.PrivateDnsClient.GetPrivateDnsLink(this.Name, this.ResourceGroupName, this.ZoneName));
            }
            else
            {
                WriteObject(this.PrivateDnsClient.ListPrivateDnsLinksInZone(this.ResourceGroupName, this.ZoneName), true);
            }
        }
    }
}
