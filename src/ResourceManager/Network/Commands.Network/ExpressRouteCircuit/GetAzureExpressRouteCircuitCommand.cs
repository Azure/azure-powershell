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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using MNM =  Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmExpressRouteCircuit"), OutputType(typeof(PSExpressRouteCircuit))]
    public class GetAzureExpressRouteCircuitCommand : ExpressRouteCircuitBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var circuit = this.GetExpressRouteCircuit(this.ResourceGroupName, this.Name);

                WriteObject(circuit);

                // TODO  : To be removed later once NRP fixes are checked in
                var peering = circuit.Peerings.First(
                            resource =>
                            string.Equals(resource.Name, "AzurePrivatePeering", System.StringComparison.CurrentCultureIgnoreCase));

                if (peering != null)
                {
                    var connection = peering.Connections.First();
                    if (connection != null)
                    {
                        var circuitconnection = NetworkClient.NetworkManagementClient.ExpressRouteCircuitConnections.GetWithHttpMessagesAsync(
                            this.ResourceGroupName, this.Name, "AzurePrivatePeering", connection.Name);
                        var psExpressRouteCircuitConnection = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCircuitConnection>(circuitconnection);
                        WriteObject(circuitconnection);
                    }
                } // To be removed end
                
            }
            else
            {
                IPage<Microsoft.Azure.Management.Network.Models.ExpressRouteCircuit> circuitPage;
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    circuitPage = this.ExpressRouteCircuitClient.List(this.ResourceGroupName);
                }
                else
                {
                    circuitPage = this.ExpressRouteCircuitClient.ListAll();
                }

                // Get all resources by polling on next page link
                var circuitList = ListNextLink<MNM.ExpressRouteCircuit>.GetAllResourcesByPollingNextLink(circuitPage, this.ExpressRouteCircuitClient.ListNext);

                var psCircuits = new List<PSExpressRouteCircuit>();
                foreach (var ExpressRouteCircuit in circuitList)
                {
                    var psVnet = this.ToPsExpressRouteCircuit(ExpressRouteCircuit);
                    psVnet.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(ExpressRouteCircuit.Id);
                    psCircuits.Add(psVnet);
                }

                WriteObject(psCircuits, true);
            }
        }
    }
}
