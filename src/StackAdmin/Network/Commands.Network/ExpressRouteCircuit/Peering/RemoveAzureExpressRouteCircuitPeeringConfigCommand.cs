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
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmExpressRouteCircuitPeeringConfig"), OutputType(typeof(PSExpressRouteCircuit))]
    public class RemoveAzureExpressRouteCircuitPeeringConfigCommand : NetworkBaseCmdlet
    {
        public const string IPv4 = "IPv4";
        public const string IPv6 = "IPv6";
        public const string All = "All";

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the Peering")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The ExpressRouteCircuit")]
        public PSExpressRouteCircuit ExpressRouteCircuit { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Address family of the peering")]
        [ValidateSet(
           IPv4,
           IPv6,
           All,
           IgnoreCase = true)]
        public string PeerAddressType { get; set; }

        public override void Execute()
        {
            base.Execute();
            var peering = this.ExpressRouteCircuit.Peerings.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (peering != null)
            {
                // When a PeerAddressType is specified, we need to check if the corresponding address family peering is present, else ignore
                // For example if the peering has only IPv4 properties set and the user tries to remove IPv6 address family peering, we can ignore the remove operation
                bool validateAddressFamilyPresent = true;

                if ((this.PeerAddressType == IPv4 && peering.PeeringType == MNM.ExpressRouteCircuitPeeringType.MicrosoftPeering && peering.MicrosoftPeeringConfig == null) ||
                    (this.PeerAddressType == IPv6 && peering.PeeringType == MNM.ExpressRouteCircuitPeeringType.MicrosoftPeering && (peering.Ipv6PeeringConfig == null || peering.Ipv6PeeringConfig.MicrosoftPeeringConfig == null)))
                {
                    validateAddressFamilyPresent = false;
                }

                if (!validateAddressFamilyPresent)
                {
                    // Peering config for specified address family is not present. No action
                    return;
                }

                if (peering.MicrosoftPeeringConfig != null && peering.Ipv6PeeringConfig != null)
                {
                    // Both IPv4 and IPv6 peering configs are present. Only nullify the config corresponding to the address family specified
                    if (this.PeerAddressType == IPv4 || string.IsNullOrWhiteSpace(this.PeerAddressType))
                    {
                        peering.PrimaryPeerAddressPrefix = null;
                        peering.SecondaryPeerAddressPrefix = null;
                        peering.RouteFilter = null;
                        peering.MicrosoftPeeringConfig = null;
                    }
                    else if (this.PeerAddressType == IPv6)
                    {
                        peering.Ipv6PeeringConfig = null;
                    }
                    else if(this.PeerAddressType == All)
                    {
                        this.ExpressRouteCircuit.Peerings.Remove(peering);
                    }
                }
                else
                {
                    // Only one peering config exists. Removing that should result in the entire peering being removed
                    this.ExpressRouteCircuit.Peerings.Remove(peering);
                }
            }

            WriteObject(this.ExpressRouteCircuit);
        }
    }
}
