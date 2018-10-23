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
    [Cmdlet(VerbsCommon.Set, "AzureRmExpressRouteCircuitPeeringConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSExpressRouteCircuit))]
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

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.RouteFilter != null)
                {
                    this.RouteFilterId = this.RouteFilter.Id;
                }
            }

            peering.Name = this.Name;
            peering.PeeringType = this.PeeringType;
            peering.PeerASN = this.PeerASN;
            peering.VlanId = this.VlanId;

            if (!string.IsNullOrEmpty(this.SharedKey))
            {
                peering.SharedKey = this.SharedKey;
            }

            if(PeerAddressType == IPv6)
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
            else
            {
                // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                peering.PrimaryPeerAddressPrefix = this.PrimaryPeerAddressPrefix;
                peering.SecondaryPeerAddressPrefix = this.SecondaryPeerAddressPrefix;
                if (!string.IsNullOrEmpty(this.RouteFilterId))
                {
                    peering.RouteFilter = new PSRouteFilter();
                    peering.RouteFilter.Id = this.RouteFilterId;
                }
            }

            this.ConstructMicrosoftConfig(peering);

            WriteObject(this.ExpressRouteCircuit);
        }
    }
}
