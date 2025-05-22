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
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitMicrosoftPeeringPrefixConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSExpressRouteCircuit))]
    public class AddAzureExpressRouteCircuitMicrosoftPeeringPrefixConfigCommand : AzureExpressRouteCircuitMicrosoftPeeringPrefixConfigBase
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

            List<PSPeeringPrefixConfig> prefixes = null;
            List<string> advertisedPublicPrefixes = null;
            if (string.Equals(PeerAddressType, IPv4))
            {
                prefixes = peering.MicrosoftPeeringConfig?.AdvertisedPublicPrefixInfo;
                advertisedPublicPrefixes = peering.MicrosoftPeeringConfig?.AdvertisedPublicPrefixes;
            }
            else
            {
                prefixes = peering.Ipv6PeeringConfig?.MicrosoftPeeringConfig?.AdvertisedPublicPrefixInfo;
                advertisedPublicPrefixes = peering.Ipv6PeeringConfig?.MicrosoftPeeringConfig?.AdvertisedPublicPrefixes;
            }

            if (advertisedPublicPrefixes == null || !advertisedPublicPrefixes.Contains(this.Prefix, StringComparer.CurrentCultureIgnoreCase))
            {
                throw new ArgumentException($"Prefix {this.Prefix} is not part of advertised public prefixes");
            }

            if (prefixes == null)
            {
                prefixes = new List<PSPeeringPrefixConfig>();
            }

            // Check if the prefix already exists
            if (prefixes.Exists(resource => string.Equals(resource.Prefix, this.Prefix, System.StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new ArgumentException("PrefixInfo already exists");
            }

            // Add the prefixInfo to the peering object and update the circuit object
            var prefix = new PSPeeringPrefixConfig();
            prefix.Prefix = this.Prefix;
            prefix.ValidationId = !string.IsNullOrEmpty(this.ValidationId) ? this.ValidationId : string.Empty;
            prefix.Signature = !string.IsNullOrEmpty(this.Signature) ? this.Signature : string.Empty;
            prefixes.Add(prefix);

            var peeringIndex = this.ExpressRouteCircuit.Peerings.FindIndex(resource => resource.Name.Equals("MicrosoftPeering"));
            if (string.Equals(PeerAddressType, IPv4))
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
