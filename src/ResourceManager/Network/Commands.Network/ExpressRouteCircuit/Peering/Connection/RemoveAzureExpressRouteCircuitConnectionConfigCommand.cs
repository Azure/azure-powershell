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
using System;
using Microsoft.Azure.Management.Network;


namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmExpressRouteCircuitConnectionConfig", SupportsShouldProcess = true), OutputType(typeof(PSExpressRouteCircuit))]
    public class RemoveAzureExpressRouteCircuitConnectionConfigCommand : ExpressRouteCircuitBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "The name of the Circuit Connection")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

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
                    this.ExpressRouteCircuit.Peerings.First(
                        resource =>
                            string.Equals(resource.Name, "AzurePrivatePeering", System.StringComparison.CurrentCultureIgnoreCase));

            if (peering == null)
            {
                throw new ArgumentException("Private Peering does not exist on the Express Route Circuit");
            }

            var connection = peering.Connections.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (connection != null)
            {
                peering.Connections.Remove(connection);
            }

            WriteObject(this.ExpressRouteCircuit);
        }
    }
}