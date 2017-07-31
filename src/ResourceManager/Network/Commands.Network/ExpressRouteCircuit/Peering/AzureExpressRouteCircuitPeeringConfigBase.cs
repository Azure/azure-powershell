// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
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

namespace Microsoft.Azure.Commands.Network
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Microsoft.Azure.Commands.Network.Models;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using System.Linq;

    public class AzureExpressRouteCircuitPeeringConfigBase : NetworkBaseCmdlet
    {
        public const string IPv4 = "IPv4";
        public const string IPv6 = "IPv6";

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the Peering")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PeeringType")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
           MNM.ExpressRouteCircuitPeeringType.AzurePrivatePeering,
           MNM.ExpressRouteCircuitPeeringType.AzurePublicPeering,
           MNM.ExpressRouteCircuitPeeringType.MicrosoftPeering,
           IgnoreCase = true)]
        public string PeeringType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PeerAsn")]
        [ValidateNotNullOrEmpty]
        public int PeerASN { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PrimaryPeerAddressPrefix")]
        [ValidateNotNullOrEmpty]
        public string PrimaryPeerAddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The SecondaryPeerAddressPrefix")]
        [ValidateNotNullOrEmpty]
        public string SecondaryPeerAddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The vlanId")]
        [ValidateNotNullOrEmpty]
        public int VlanId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SharedKey")]
        [ValidateNotNullOrEmpty]
        public string SharedKey { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The MircosoftConfigAdvertisedPublicPrefixes")]
        [ValidateNotNullOrEmpty]
        public List<string> MicrosoftConfigAdvertisedPublicPrefixes { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The customerAsn")]
        [ValidateNotNullOrEmpty]
        public int MicrosoftConfigCustomerAsn { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The MircosoftConfigRoutingRegistryName")]
        [ValidateNotNullOrEmpty]
        public string MicrosoftConfigRoutingRegistryName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "MicrosoftPeeringConfigRoutFilterId",
            HelpMessage = "RouteFilterId")]
        [ValidateNotNullOrEmpty]
        public string RouteFilterId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "MicrosoftPeeringConfigRoutFilter",
            HelpMessage = "RouteFilter")]
        [ValidateNotNullOrEmpty]
        public PSRouteFilter RouteFilter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PeerAddressType")]
        [ValidateSet(
           IPv4,
           IPv6,
           IgnoreCase = true)]
        public string PeerAddressType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The legacy mode of the Peering")]
        public bool LegacyMode { get; set; }

        public void ConstructMicrosoftConfig(PSPeering peering)
        {
            if (this.MicrosoftConfigAdvertisedPublicPrefixes != null && this.MicrosoftConfigAdvertisedPublicPrefixes.Any())
            {
                if (PeerAddressType == IPv6)
                {
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig = new PSPeeringConfig();
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = this.MicrosoftConfigAdvertisedPublicPrefixes;
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.CustomerASN = this.MicrosoftConfigCustomerAsn;
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.RoutingRegistryName = this.MicrosoftConfigRoutingRegistryName;
                }
                else
                {
                    // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                    peering.MicrosoftPeeringConfig = new PSPeeringConfig();
                    peering.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = this.MicrosoftConfigAdvertisedPublicPrefixes;
                    peering.MicrosoftPeeringConfig.CustomerASN = this.MicrosoftConfigCustomerAsn;
                    peering.MicrosoftPeeringConfig.RoutingRegistryName = this.MicrosoftConfigRoutingRegistryName;
                }
            }
        }
    }
}
