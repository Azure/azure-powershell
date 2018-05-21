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
    [Cmdlet(VerbsCommon.Add, "AzureRmExpressRouteCircuitConnectionConfig", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSExpressRouteCircuit))]
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

            var circuitconnection = new PSExpressRouteCircuitConnection();

            circuitconnection.Name = this.Name;
            circuitconnection.AddressPrefix = this.AddressPrefix;

            var peering =
                    this.ExpressRouteCircuit.Peerings.First(
                        resource =>
                            string.Equals(resource.Name, "AzurePrivatePeering", System.StringComparison.CurrentCultureIgnoreCase));

            if (peering == null)
            {
                throw new ArgumentException("Private Peering needs to be configured on the Express Route Circuit");
            }

            circuitconnection.ExpressRouteCircuitPeering = new PSResourceId();
            circuitconnection.ExpressRouteCircuitPeering.Id = peering.Id;

            circuitconnection.PeerExpressRouteCircuitPeering = new PSResourceId();
            circuitconnection.PeerExpressRouteCircuitPeering.Id = this.PeerExpressRouteCircuitPeering;

            if (!string.IsNullOrWhiteSpace(this.AuthorizationKey))
            {
                circuitconnection.AuthorizationKey = this.AuthorizationKey;
            }

            peering.Connections.Add(circuitconnection);

            WriteObject(this.ExpressRouteCircuit);
        }
    }
}