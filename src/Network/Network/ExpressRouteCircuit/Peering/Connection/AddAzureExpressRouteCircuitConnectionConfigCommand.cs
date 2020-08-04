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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletOutputBreakingChange(typeof(PSExpressRouteCircuit), DeprecatedOutputProperties = new[] { "AllowGlobalReach" })]
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitConnectionConfig", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSExpressRouteCircuit))]
    public class AddAzureExpressRouteCircuitConnectionConfigCommand : AzureExpressRouteCircuitConnectionConfigBase
    {
        [Parameter(
            Position = 0, 
            Mandatory = true,
            HelpMessage = "The name of the Circuit Connection")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(           
            Position = 1,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Express Route Circuit Peering intiating connection")]
        [ValidateNotNullOrEmpty]
        public PSExpressRouteCircuit ExpressRouteCircuit { get; set; }

        public override void Execute()
        {
            base.Execute();

            var peering =
                    this.ExpressRouteCircuit.Peerings.SingleOrDefault(
                        resource =>
                            string.Equals(resource.Name, "AzurePrivatePeering", System.StringComparison.CurrentCultureIgnoreCase));

            if (peering == null)
            {
                throw new ArgumentException(Properties.Resources.ExpressRoutePrivatePeeringNotFound);
            }

            var circuitconnection = peering.Connections.SingleOrDefault(
                    resource =>
                        string.Equals(resource.Name, Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (circuitconnection != null)
            {
                throw new ArgumentException(string.Format(Properties.Resources.ExpressRouteCircuitConnectionAlreadyAdded, Name));
            }

            circuitconnection = new PSExpressRouteCircuitConnection();

            circuitconnection.Name = this.Name;
 
            circuitconnection.ExpressRouteCircuitPeering = new PSResourceId();
            circuitconnection.ExpressRouteCircuitPeering.Id = peering.Id;

            circuitconnection.PeerExpressRouteCircuitPeering = new PSResourceId();
            circuitconnection.PeerExpressRouteCircuitPeering.Id = this.PeerExpressRouteCircuitPeering;

            if (!string.IsNullOrWhiteSpace(this.AuthorizationKey))
            {
                circuitconnection.AuthorizationKey = this.AuthorizationKey;
            }

            if (AddressTypeUtils.IsIpv6(this.AddressPrefixType))
            {
                // Create new PSExpressRouteIPv6AddressPrefix()
                var expressRouteIPv6AddressPrefix = new PSExpressRouteCircuitConnectionIPv6ConnectionConfig();
                expressRouteIPv6AddressPrefix.AddressPrefix = AddressPrefix;
                circuitconnection.IPv6CircuitConnectionConfig = expressRouteIPv6AddressPrefix;
            }
            else
            {
                // For IPv4 
                circuitconnection.AddressPrefix = this.AddressPrefix;
            }

            peering.Connections.Add(circuitconnection);

            WriteObject(this.ExpressRouteCircuit);
        }
    }
}
