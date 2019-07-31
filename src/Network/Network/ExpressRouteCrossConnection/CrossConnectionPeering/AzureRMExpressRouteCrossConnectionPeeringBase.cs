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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Microsoft.Azure.Commands.Network.Models;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using System.Linq;

    public class AzureRMExpressRouteCrossConnectionPeeringBase : NetworkBaseCmdlet
    {
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
        public string PeeringType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PeerAsn")]
        [ValidateNotNullOrEmpty]
        public uint PeerASN { get; set; }

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
            HelpMessage = "The MicrosoftConfigAdvertisedPublicPrefixes")]
        [ValidateNotNullOrEmpty]
        public string[] MicrosoftConfigAdvertisedPublicPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The customerAsn")]
        [ValidateNotNullOrEmpty]
        public int MicrosoftConfigCustomerAsn { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The MicrosoftConfigRoutingRegistryName")]
        [ValidateNotNullOrEmpty]
        public string MicrosoftConfigRoutingRegistryName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PeerAddressType")]
        [ValidateSet(
           IPv4,
           IPv6,
           IgnoreCase = true)]
        public string PeerAddressType { get; set; }
        
        public IExpressRouteCrossConnectionsOperations ExpressRouteCrossConnectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ExpressRouteCrossConnections;
            }
        }

        public PSExpressRouteCrossConnection GetExpressRouteCrossConnection(string resourceGroupName, string name)
        {
            var crossConnection = this.ExpressRouteCrossConnectionClient.Get(resourceGroupName, name);

            var psExpressRouteCrossConnection = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCrossConnection>(crossConnection);
            psExpressRouteCrossConnection.ResourceGroupName = resourceGroupName;

            psExpressRouteCrossConnection.Tag =
                TagsConversionHelper.CreateTagHashtable(crossConnection.Tags);

            return psExpressRouteCrossConnection;
        }

        public void ConstructMicrosoftConfig(PSExpressRouteCrossConnectionPeering peering)
        {
            if (MicrosoftConfigAdvertisedPublicPrefix != null && MicrosoftConfigAdvertisedPublicPrefix.Count() > 0)
            {
                if (PeerAddressType == IPv6)
                {
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig = new PSPeeringConfig();
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = MicrosoftConfigAdvertisedPublicPrefix.ToList();
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.CustomerASN = MicrosoftConfigCustomerAsn;
                    peering.Ipv6PeeringConfig.MicrosoftPeeringConfig.RoutingRegistryName = MicrosoftConfigRoutingRegistryName;
                }
                else
                {
                    // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                    peering.MicrosoftPeeringConfig = new PSPeeringConfig();
                    peering.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = MicrosoftConfigAdvertisedPublicPrefix.ToList();
                    peering.MicrosoftPeeringConfig.CustomerASN = MicrosoftConfigCustomerAsn;
                    peering.MicrosoftPeeringConfig.RoutingRegistryName = MicrosoftConfigRoutingRegistryName;
                }
            }
        }

        public void SetIpv6PeeringParameters(PSExpressRouteCrossConnectionPeering peering)
        {
            peering.Ipv6PeeringConfig = new PSIpv6PeeringConfig();
            peering.Ipv6PeeringConfig.PrimaryPeerAddressPrefix = PrimaryPeerAddressPrefix;
            peering.Ipv6PeeringConfig.SecondaryPeerAddressPrefix = SecondaryPeerAddressPrefix;
        }

        public void SetIpv4PeeringParameters(PSExpressRouteCrossConnectionPeering peering)
        {
            peering.PrimaryPeerAddressPrefix = PrimaryPeerAddressPrefix;
            peering.SecondaryPeerAddressPrefix = SecondaryPeerAddressPrefix;
        }
    }
}
