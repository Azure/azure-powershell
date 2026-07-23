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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitMicrosoftPeeringPrefixConfig"), OutputType(typeof(PSExpressRouteCircuit))]
    public class RemoveExpressRouteCircuitMicrosoftPeeringPrefixConfigCommand : AzureExpressRouteCircuitMicrosoftPeeringPrefixConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCircuit")]
        public PSExpressRouteCircuit ExpressRouteCircuit { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Check if Microsoft peering exists on this circuit
            var peering =
                this.ExpressRouteCircuit.Peerings.First(
                    resource =>
                        string.Equals(resource.Name, "MicrosoftPeering", System.StringComparison.CurrentCultureIgnoreCase));

            if (peering == null)
            {
                throw new ArgumentException("Microsoft peering is not configured on the circuit");
            }

            List<PSPeeringPrefixConfig> prefixes;
            if (string.Equals(PeerAddressType, "IPv4"))
            {
                prefixes = peering?.MicrosoftPeeringConfig?.AdvertisedPublicPrefixInfo;
            }
            else
            {
                prefixes = peering?.Ipv6PeeringConfig?.MicrosoftPeeringConfig?.AdvertisedPublicPrefixInfo;
            }

            if (prefixes == null || prefixes.Count == 0)
            {
                throw new ArgumentException("AdvertisedPublicPrefixInfo is empty in peering config");
            }

            // Check if the prefix exists. If not, throw an exception to add the prefix first
            var prefixIndex = prefixes.FindIndex(resource => string.Equals(resource.Prefix, this.Prefix, System.StringComparison.CurrentCultureIgnoreCase));
            if (prefixIndex < 0)
            {
                throw new ArgumentException("PrefixInfo does not exist for this prefix");
            }

            // Remove prefixInfo from the list and update the circuit object
            prefixes.RemoveAt(prefixIndex);

            var peeringIndex = this.ExpressRouteCircuit.Peerings.FindIndex(resource => resource.Name.Equals("MicrosoftPeering"));
            if (string.Equals(PeerAddressType, "IPv4"))
            {
                this.ExpressRouteCircuit.Peerings[peeringIndex].MicrosoftPeeringConfig.AdvertisedPublicPrefixInfo = prefixes;
            }
            else
            {
                this.ExpressRouteCircuit.Peerings[peeringIndex].Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixInfo = prefixes;
            }

            WriteObject(this.ExpressRouteCircuit);
        }
    }
}
