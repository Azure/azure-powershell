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
        protected const string ParamSetByRouteFilterId = "MicrosoftPeeringConfigRoutFilterId";
        protected const string ParamSetByRouteFilter = "MicrosoftPeeringConfigRoutFilter";

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
           MNM.ExpressRoutePeeringType.AzurePrivatePeering,
           MNM.ExpressRoutePeeringType.AzurePublicPeering,
           MNM.ExpressRoutePeeringType.MicrosoftPeering,
           IgnoreCase = true)]
        public virtual string PeeringType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PeerAsn")]
        [ValidateNotNullOrEmpty]
        public virtual uint PeerASN { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PrimaryPeerAddressPrefix")]
        [ValidateNotNullOrEmpty]
        public virtual string PrimaryPeerAddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The SecondaryPeerAddressPrefix")]
        [ValidateNotNullOrEmpty]
        public virtual string SecondaryPeerAddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The vlanId")]
        [ValidateNotNullOrEmpty]
        public virtual int VlanId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SharedKey")]
        [ValidateNotNullOrEmpty]
        public string SharedKey { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The MircosoftConfigAdvertisedPublicPrefixes")]
        [ValidateNotNullOrEmpty]
        public string[] MicrosoftConfigAdvertisedPublicPrefixes { get; set; }

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
            ParameterSetName = ParamSetByRouteFilterId,
            HelpMessage = "RouteFilterId")]
        [ValidateNotNullOrEmpty]
        public virtual string RouteFilterId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParamSetByRouteFilter,
            HelpMessage = "RouteFilter")]
        [ValidateNotNullOrEmpty]
        public virtual PSRouteFilter RouteFilter { get; set; }

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
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = this.MicrosoftConfigAdvertisedPublicPrefixes?.ToList();
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.CustomerASN = this.MicrosoftConfigCustomerAsn;
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.RoutingRegistryName = this.MicrosoftConfigRoutingRegistryName;
                }
                else
                {
                    // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                    peering.MicrosoftPeeringConfig = new PSPeeringConfig();
                    peering.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = this.MicrosoftConfigAdvertisedPublicPrefixes?.ToList();
                    peering.MicrosoftPeeringConfig.CustomerASN = this.MicrosoftConfigCustomerAsn;
                    peering.MicrosoftPeeringConfig.RoutingRegistryName = this.MicrosoftConfigRoutingRegistryName;
                }
            }
        }

        public void UpdateMicrosoftConfig(PSPeering peering)
        {
            if (PeerAddressType == IPv6)
            {
                if (peering.Ipv6PeeringConfig.MicrosoftPeeringConfig == null)
                {
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig = new PSPeeringConfig();
                }

                if (this.MicrosoftConfigAdvertisedPublicPrefixes != null)
                {
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = this.MicrosoftConfigAdvertisedPublicPrefixes?.ToList();
                }

                if (MyInvocation.BoundParameters.ContainsKey("MicrosoftConfigCustomerAsn"))
                {
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.CustomerASN = this.MicrosoftConfigCustomerAsn;
                }

                if (this.MicrosoftConfigRoutingRegistryName != null)
                {
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.RoutingRegistryName = this.MicrosoftConfigRoutingRegistryName;
                }
            }
            else
            {
                // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                if (peering.MicrosoftPeeringConfig == null)
                {
                    peering.MicrosoftPeeringConfig = new PSPeeringConfig();
                }

                if (this.MicrosoftConfigAdvertisedPublicPrefixes != null)
                {
                    peering.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = this.MicrosoftConfigAdvertisedPublicPrefixes?.ToList();
                }

                if (MyInvocation.BoundParameters.ContainsKey("MicrosoftConfigCustomerAsn"))
                {
                    peering.MicrosoftPeeringConfig.CustomerASN = this.MicrosoftConfigCustomerAsn;
                }

                if (this.MicrosoftConfigRoutingRegistryName != null)
                {
                    peering.MicrosoftPeeringConfig.RoutingRegistryName = this.MicrosoftConfigRoutingRegistryName;
                }
            }
        }

        public void SetIpv6PeeringParameters(PSPeering peering)
        {
            peering.Ipv6PeeringConfig = new PSIpv6PeeringConfig();
            peering.Ipv6PeeringConfig.PrimaryPeerAddressPrefix = this.PrimaryPeerAddressPrefix;
            peering.Ipv6PeeringConfig.SecondaryPeerAddressPrefix = this.SecondaryPeerAddressPrefix;
            if (!string.IsNullOrEmpty(this.RouteFilterId))
            {
                peering.Ipv6PeeringConfig.RouteFilter = new PSRouteFilter();
                peering.Ipv6PeeringConfig.RouteFilter.Id = this.RouteFilterId;
            }
        }

        public void UpdateIpv6PeeringParameters(PSPeering peering)
        {
            if (peering.Ipv6PeeringConfig == null)
            {
                peering.Ipv6PeeringConfig = new PSIpv6PeeringConfig();
            }

            if (peering.PrimaryPeerAddressPrefix != null)
            {
                peering.PrimaryPeerAddressPrefix = null;
            }

            if (peering.SecondaryPeerAddressPrefix != null)
            {
                peering.SecondaryPeerAddressPrefix = null;
            }

            if (peering.RouteFilter != null)
            {
                peering.RouteFilter = null;
            }

            if (this.PrimaryPeerAddressPrefix != null)
            {
                peering.Ipv6PeeringConfig.PrimaryPeerAddressPrefix = this.PrimaryPeerAddressPrefix;
            }

            if (this.SecondaryPeerAddressPrefix != null)
            {
                peering.Ipv6PeeringConfig.SecondaryPeerAddressPrefix = this.SecondaryPeerAddressPrefix;
            }

            if (!string.IsNullOrEmpty(this.RouteFilterId))
            {
                peering.Ipv6PeeringConfig.RouteFilter = new PSRouteFilter();
                peering.Ipv6PeeringConfig.RouteFilter.Id = this.RouteFilterId;
            }
        }

        public void SetIpv4PeeringParameters(PSPeering peering)
        {
            peering.PrimaryPeerAddressPrefix = this.PrimaryPeerAddressPrefix;
            peering.SecondaryPeerAddressPrefix = this.SecondaryPeerAddressPrefix;
            if (!string.IsNullOrEmpty(this.RouteFilterId))
            {
                peering.RouteFilter = new PSRouteFilter();
                peering.RouteFilter.Id = this.RouteFilterId;
            }
        }

        public void UpdateIpv4PeeringParameters(PSPeering peering)
        {
            if(peering.Ipv6PeeringConfig != null && peering.Ipv6PeeringConfig.PrimaryPeerAddressPrefix != null)
            {
                peering.Ipv6PeeringConfig.PrimaryPeerAddressPrefix = null;
            }

            if (peering.Ipv6PeeringConfig != null && peering.Ipv6PeeringConfig.SecondaryPeerAddressPrefix != null)
            {
                peering.Ipv6PeeringConfig.SecondaryPeerAddressPrefix = null;
            }

            if (peering.Ipv6PeeringConfig != null && peering.Ipv6PeeringConfig.RouteFilter != null)
            {
                peering.Ipv6PeeringConfig.RouteFilter = null;
            }

            if (this.PrimaryPeerAddressPrefix != null)
            {
                peering.PrimaryPeerAddressPrefix = this.PrimaryPeerAddressPrefix;
            }

            if (this.SecondaryPeerAddressPrefix != null)
            {
                peering.SecondaryPeerAddressPrefix = this.SecondaryPeerAddressPrefix;
            }

            if (!string.IsNullOrEmpty(this.RouteFilterId))
            {
                peering.RouteFilter = new PSRouteFilter();
                peering.RouteFilter.Id = this.RouteFilterId;
            }
        }
    }
}
