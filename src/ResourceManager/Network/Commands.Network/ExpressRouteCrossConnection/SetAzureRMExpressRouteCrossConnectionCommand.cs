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
    [Cmdlet(VerbsCommon.Set, "AzureRmExpressRouteCrossConnection", SupportsShouldProcess = true), OutputType(typeof(PSExpressRouteCrossConnection))]
    public class SetAzureRMExpressRouteCrossConnectionCommand : ExpressRouteCrossConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCrossConnection")]
        public PSExpressRouteCrossConnection ExpressRouteCrossConnection { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();

            ConfirmAction(
               Force.IsPresent,
               string.Format(Properties.Resources.OverwritingResource, ExpressRouteCrossConnection.Name),
               Properties.Resources.CreatingResourceMessage,
               ExpressRouteCrossConnection.Name,
               () =>
               {
                   if (!IsExpressRouteCrossConnectionPresent(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name))
                   {
                       throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
                   }

                   // Map to the sdk object
                   var crossConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteCrossConnection>(ExpressRouteCrossConnection);
                   crossConnectionModel.Tags = TagsConversionHelper.CreateTagDictionary(ExpressRouteCrossConnection.Tag, validate: true);

                   // Execute the Update ExpressRouteCrossConnection call
                   ExpressRouteCrossConnectionClient.CreateOrUpdate(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name, crossConnectionModel);

                   var getExpressRouteCircuit = GetExpressRouteCrossConnection(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name);
                   WriteObject(getExpressRouteCircuit);
               });
        }
    }
}
