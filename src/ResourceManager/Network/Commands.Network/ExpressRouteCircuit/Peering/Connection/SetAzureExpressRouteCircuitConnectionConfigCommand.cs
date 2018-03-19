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
    [Cmdlet(VerbsCommon.Set, "AzureRmExpressRouteCircuitConnectionConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSPeering))]
    public class SetAzureExpressRouteCircuitConnectionConfigCommand : AzureExpressRouteCircuitConnectionConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Circuit Connection")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Express Route Circuit Peering intiating connection")]
        [ValidateNotNullOrEmpty]
        public PSPeering ExpressRouteCircuitPeering { get; set; }

        public override void Execute()
        {
            base.Execute();

            var connection = this.ExpressRouteCircuitPeering.Connections.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

            if (connection == null)
            {
                throw new ArgumentException("Circuit Connection with the specified name does not exist");
            }

            if ((connection.PeerExpressRouteCircuitPeering.PeeringType != Microsoft.Azure.Management.Network.Models.ExpressRouteCircuitPeeringType.AzurePrivatePeering) ||
                (ExpressRouteCircuitPeering.PeeringType != Microsoft.Azure.Management.Network.Models.ExpressRouteCircuitPeeringType.AzurePrivatePeering))
            {
                throw new ArgumentException("Circuit Connection can only be established between Private Peerings");
            }

            connection.Name = this.Name;
            connection.AddressPrefix = this.AddressPrefix;
            connection.ExpressRouteCircuitPeering = this.ExpressRouteCircuitPeering;
            connection.PeerExpressRouteCircuitPeering = this.PeerExpressRouteCircuitPeering;

            if (!string.IsNullOrWhiteSpace(this.AuthorizationKey))
            {
                connection.AuthorizationKey = this.AuthorizationKey;
            }

            WriteObject(this.ExpressRouteCircuitPeering);
        }
    }
}
