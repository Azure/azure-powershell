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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    using System.Collections;

    [Cmdlet(VerbsCommon.Move, "AzureRmExpressRouteCircuit", SupportsShouldProcess = true),
        OutputType(typeof(PSExpressRouteCircuit))]
    public class MoveAzureExpressRouteCircuitCommand : ExpressRouteCircuitBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public virtual string ServiceKey { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsExpressRouteCircuitPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.MovingExpressRoutCircuitMessage,
                Name,
                () =>
                {
                    var expressRouteCircuit = CreateExpressRouteCircuit();
                    WriteObject(expressRouteCircuit);
                },
                () => present);
        }

        private PSExpressRouteCircuit CreateExpressRouteCircuit()
        {
            var circuit = new PSExpressRouteCircuit();
            circuit.Name = this.Name;
            circuit.ServiceKey = this.ServiceKey;
            circuit.ResourceGroupName = this.ResourceGroupName;
            circuit.Location = this.Location;

            // Map to the sdk object
            var circuitModel = Mapper.Map<MNM.ExpressRouteCircuit>(circuit);
            circuitModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create ExpressRouteCircuit call
            this.ExpressRouteCircuitClient.CreateOrUpdate(this.ResourceGroupName, this.Name, circuitModel);

            var getExpressRouteCircuit = this.GetExpressRouteCircuit(this.ResourceGroupName, this.Name);
            return getExpressRouteCircuit;
        }
    }
}




