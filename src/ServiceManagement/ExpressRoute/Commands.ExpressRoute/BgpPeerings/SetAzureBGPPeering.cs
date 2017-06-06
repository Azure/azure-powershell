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

using System;
using System.ComponentModel;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ExpressRoute.Properties;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{

    [Cmdlet(VerbsCommon.Set, "AzureBGPPeering"), OutputType(typeof(AzureBgpPeering))]
    public class SetAzureBGPPeeringCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service Key representing Azure Circuit for which BGP peering needs to be created/modified")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Advertised Public Prefixes")]
        [ValidateNotNullOrEmpty]
        public string AdvertisedPublicPrefixes;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Advertised Public Prefixes for Ipv6")]
        [ValidateNotNullOrEmpty]
        public string AdvertisedPublicPrefixesIpv6;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Customer AS number")]
        public UInt32? CustomerAsn { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Customer AS number for Ipv6")]
        public UInt32? CustomerAsnIpv6 { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Peer Asn")]
        public UInt32? PeerAsn { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Primary Peer Subnet")]
        [ValidateNotNullOrEmpty]
        public string PrimaryPeerSubnet { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Primary Peer Subnet for Ipv6")]
        [ValidateNotNullOrEmpty]
        public string PrimaryPeerSubnetIpv6 { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Routing Registry Name for Prefix Validation")]
        public string RoutingRegistryName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Routing Registry Name for Prefix Validation for Ipv6")]
        public string RoutingRegistryNameIpv6 { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Secondary Peer Subnet")]
        [ValidateNotNullOrEmpty]
        public string SecondaryPeerSubnet { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Secondary Peer Subnet for Ipv6")]
        [ValidateNotNullOrEmpty]
        public string SecondaryPeerSubnetIpv6 { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Shared Key")]
        [ValidateNotNullOrEmpty]
        public string SharedKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Vlan Id")]
        public UInt32? VlanId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Bgp Peering Access Type: Microsoft, Public or Private")]
        [DefaultValue("Private")]
        public BgpPeeringAccessType AccessType { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var route = ExpressRouteClient.GetAzureBGPPeering(ServiceKey, AccessType);

                var updatedRoute = ExpressRouteClient.UpdateAzureBGPPeering(ServiceKey, AccessType,
                    AdvertisedPublicPrefixes ?? route.AdvertisedPublicPrefixes, AdvertisedPublicPrefixesIpv6 ?? route.AdvertisedPublicPrefixesIpv6,
                    (CustomerAsn.HasValue) ? CustomerAsn.Value : route.CustomerAutonomousSystemNumber, (CustomerAsnIpv6.HasValue) ? CustomerAsnIpv6.Value : route.CustomerAutonomousSystemNumberIpv6,
                    PeerAsn.HasValue ? PeerAsn.Value : route.PeerAsn, PrimaryPeerSubnet ?? route.PrimaryPeerSubnet, PrimaryPeerSubnetIpv6 ?? route.PrimaryPeerSubnetIpv6,
                    RoutingRegistryName ?? route.RoutingRegistryName, RoutingRegistryNameIpv6 ?? RoutingRegistryNameIpv6,
                    SecondaryPeerSubnet ?? route.SecondaryPeerSubnet, SecondaryPeerSubnetIpv6 ?? route.SecondaryPeerSubnetIpv6,
                    VlanId.HasValue ? VlanId.Value : route.VlanId,
                    string.IsNullOrWhiteSpace(SharedKey) ? null : SharedKey.Trim());
                WriteObject(updatedRoute, false);
            }
            catch
            {
                if (!PeerAsn.HasValue)
                {
                    throw new ArgumentException(Resources.PeerAsnRequired);
                }

                if (!VlanId.HasValue)
                {
                    throw new ArgumentException(Resources.VlanIdRequired);
                }

                if (PrimaryPeerSubnet == null && PrimaryPeerSubnetIpv6 == null)
                {
                    throw new ArgumentException(Resources.PrimaryPeerSubnetRequired);
                }

                if (SecondaryPeerSubnet == null && SecondaryPeerSubnetIpv6 == null)
                {
                    throw new ArgumentException(Resources.SecondaryPeerSubnetRequired);
                }

                var newRoute = ExpressRouteClient.NewAzureBGPPeering(ServiceKey, AdvertisedPublicPrefixes, AdvertisedPublicPrefixesIpv6, CustomerAsn.Value, CustomerAsnIpv6.Value,
                    PeerAsn.Value, PrimaryPeerSubnet, PrimaryPeerSubnetIpv6, RoutingRegistryName, RoutingRegistryNameIpv6, SecondaryPeerSubnet, SecondaryPeerSubnetIpv6,
                    VlanId.Value, AccessType, SharedKey);
                WriteObject(newRoute);
            }
        }
    }
}
