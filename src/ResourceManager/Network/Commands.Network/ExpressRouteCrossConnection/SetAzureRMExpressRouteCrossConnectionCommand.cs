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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System;
using System.Management.Automation;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmExpressRouteCrossConnection"), OutputType(typeof(PSExpressRouteCrossConnection))]
    public class SetAzureRMExpressRouteCrossConnectionCommand : ExpressRouteCrossConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCrossConnection")]
        public PSExpressRouteCrossConnection ExpressRouteCrossConnection { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!this.IsExpressRouteCrossConnectionPresent(this.ExpressRouteCrossConnection.ResourceGroupName, this.ExpressRouteCrossConnection.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var crossConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteCrossConnection>(this.ExpressRouteCrossConnection);
            crossConnectionModel.PeeringLocation = this.ExpressRouteCrossConnection.PeeringLocation;
            crossConnectionModel.Tags = TagsConversionHelper.CreateTagDictionary(this.ExpressRouteCrossConnection.Tag, validate: true);

            // Execute the Update ExpressRouteCrossConnection call
            this.ExpressRouteCrossConnectionClient.CreateOrUpdate(this.ExpressRouteCrossConnection.ResourceGroupName, this.ExpressRouteCrossConnection.Name, crossConnectionModel);

            var getExpressRouteCircuit = this.GetExpressRouteCrossConnection(this.ExpressRouteCrossConnection.ResourceGroupName, this.ExpressRouteCrossConnection.Name);
            WriteObject(getExpressRouteCircuit);
        }
    }
}
