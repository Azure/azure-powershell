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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureRmExpressRouteCircuitPeeringConfig"), OutputType(typeof(PSExpressRouteCircuit))]
    public class AddAzureExpressRouteCircuitPeeringConfigCommand : AzureExpressRouteCircuitPeeringConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Peering")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCircuit")]
        public PSExpressRouteCircuit Circuit { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            // Verify if the subnet exists in the VirtualNetwork
            var peering = this.Circuit.Peerings.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (peering != null)
            {
                throw new ArgumentException("Peering with the specified name already exists");
            }

            peering = new PSPeering();

            peering.Name = this.Name;
            peering.PeeringType = this.PeeringType;
            peering.PrimaryPeerAddressPrefix = this.PrimaryPeerAddressPrefix;
            peering.SecondaryPeerAddressPrefix = this.SecondaryPeerAddressPrefix;
            peering.AzureASN = this.AzureASN;
            peering.PeerASN = this.PeerASN;
            peering.VlanId = this.VlanId;

            if (this.MircosoftConfigAdvertisedPublicPrefixes != null
                && this.MircosoftConfigAdvertisedPublicPrefixes.Any())
            {
                peering.MicrosoftPeeringConfig = new PSPeeringConfig();
                peering.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = this.MircosoftConfigAdvertisedPublicPrefixes;
                peering.MicrosoftPeeringConfig.CustomerASN = this.MircosoftConfigCustomerAsn;
                peering.MicrosoftPeeringConfig.RoutingRegistryName = this.MircosoftConfigRoutingRegistryName;
            }

            this.Circuit.Peerings.Add(peering);

            WriteObject(this.Circuit);
        }
    }
}
