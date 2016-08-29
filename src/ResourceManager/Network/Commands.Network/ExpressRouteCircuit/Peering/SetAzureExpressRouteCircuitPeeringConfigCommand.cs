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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmExpressRouteCircuitPeeringConfig"), OutputType(typeof(PSExpressRouteCircuit))]
    public class SetAzureExpressRouteCircuitPeeringConfigCommand : AzureExpressRouteCircuitPeeringConfigBase
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
        public PSExpressRouteCircuit ExpressRouteCircuit { get; set; }

        public override void Execute()
        {
            base.Execute();
            // Verify if the subnet exists in the VirtualNetwork
            var peering = this.ExpressRouteCircuit.Peerings.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

            if (peering == null)
            {
                throw new ArgumentException("Peering with the specified name does not exist");
            }

            peering.Name = this.Name;
            peering.PeeringType = this.PeeringType;
            peering.PrimaryPeerAddressPrefix = this.PrimaryPeerAddressPrefix;
            peering.SecondaryPeerAddressPrefix = this.SecondaryPeerAddressPrefix;
            peering.PeerASN = this.PeerASN;
            peering.VlanId = this.VlanId;

            if (!string.IsNullOrEmpty(this.SharedKey))
            {
                peering.SharedKey = this.SharedKey;
            }

            if (this.MicrosoftConfigAdvertisedPublicPrefixes != null
                && this.MicrosoftConfigAdvertisedPublicPrefixes.Any())
            {
                peering.MicrosoftPeeringConfig = new PSPeeringConfig();
                peering.MicrosoftPeeringConfig.AdvertisedPublicPrefixes = this.MicrosoftConfigAdvertisedPublicPrefixes;
                peering.MicrosoftPeeringConfig.CustomerASN = this.MicrosoftConfigCustomerAsn;
                peering.MicrosoftPeeringConfig.RoutingRegistryName = this.MicrosoftConfigRoutingRegistryName;
            }

            WriteObject(this.ExpressRouteCircuit);
        }
    }
}
