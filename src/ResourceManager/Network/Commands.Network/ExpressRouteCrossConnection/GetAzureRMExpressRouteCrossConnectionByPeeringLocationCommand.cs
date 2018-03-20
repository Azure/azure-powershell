// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmExpressRouteCrossConnectionByPeeringLocation"), OutputType(typeof(List<PSExpressRouteCrossConnection>))]
    public partial class GetAzureRmExpressRouteCrossConnectionByResourceGroup : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Peering Location.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string PeeringLocation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            var crossConnectionsClient = this.NetworkClient.NetworkManagementClient.ExpressRouteCrossConnections;
            base.Execute();

            var vExpressRouteCrossConnectionList = crossConnectionsClient.List(PeeringLocation);

            // Get all resources by polling on next page link
            var crossConnectionList = ListNextLink<PSExpressRouteCrossConnection>.GetAllResourcesByPollingNextLink(vExpressRouteCrossConnectionList, crossConnectionsClient.ListNext);

            var psCircuits = new List<PSExpressRouteCircuit>();
            foreach (var ExpressRouteCircuit in circuitList)
            {
                var psVnet = this.ToPsExpressRouteCircuit(ExpressRouteCircuit);
                psVnet.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(ExpressRouteCircuit.Id);
                psCircuits.Add(psVnet);
            }

            foreach (var expressRouteCrossConnection in crossConnectionList)
            {
                var vExpressRouteCrossConnectionModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRouteCrossConnection>(vExpressRouteCrossConnection);
                vExpressRouteCrossConnectionModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vExpressRouteCrossConnectionModel.Id);
                vExpressRouteCrossConnectionModel.Tag = TagsConversionHelper.CreateTagHashtable(vExpressRouteCrossConnection.Tags);
                WriteObject(vExpressRouteCrossConnectionModel);
            }
        }
    }
}
