
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

using System.Net;
using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Network;
using Hyak.Common;

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Management.Network.Models;

    public abstract class ExpressRouteCircuitBaseCmdlet : NetworkBaseCmdlet
    {
        public IExpressRouteCircuitOperations ExpressRouteCircuitClient
        {
            get
            {
                return NetworkClient.NetworkResourceProviderClient.ExpressRouteCircuits;
            }
        }

        public bool IsExpressRouteCircuitPresent(string resourceGroupName, string name)
        {
            try
            {
                GetExpressRouteCircuit(resourceGroupName, name);
            }
            catch (CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSExpressRouteCircuit GetExpressRouteCircuit(string resourceGroupName, string name)
        {
            var circuitGetResponse = this.ExpressRouteCircuitClient.Get(resourceGroupName, name);

            var expressRouteCircuit = Mapper.Map<PSExpressRouteCircuit>(circuitGetResponse.ExpressRouteCircuit);
            expressRouteCircuit.ResourceGroupName = resourceGroupName;

            expressRouteCircuit.Tag =
                TagsConversionHelper.CreateTagHashtable(circuitGetResponse.ExpressRouteCircuit.Tags);
            
            return expressRouteCircuit;
        }

        public PSExpressRouteCircuit ToPsExpressRouteCircuit(ExpressRouteCircuit circuit)
        {
            var psCircuit = Mapper.Map<PSExpressRouteCircuit>(circuit);

            psCircuit.Tag = TagsConversionHelper.CreateTagHashtable(circuit.Tags);

            return psCircuit;
        }
    }
}