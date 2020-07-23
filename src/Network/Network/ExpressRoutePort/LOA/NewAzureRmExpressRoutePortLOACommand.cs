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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using System.IO;
using Microsoft.Azure.Management.Network.Models;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePortLOA", SupportsShouldProcess = false, DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(bool))]
    public partial class NewAzureRmExpressRoutePortLOA : NetworkBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceObjectParameterSet = "ResourceObjectParameterSet";
        private const string DefaultFileName = "LOA.pdf";

        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "The express route port name.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string PortName { get; set; }

        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "The resource group name of the express route port.",
            ValueFromPipelineByPropertyName = false)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ResourceObjectParameterSet,
            Mandatory = true,
            HelpMessage = "The express route port resource.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public PSExpressRoutePort ExpressRoutePort { get; set; }

        [Alias("ResourceId")]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "ResourceId of the express route port.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The customer name to whom this Express Route Port is assigned to.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string CustomerName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The output filepath to store the Letter of Authorization to.",
            ValueFromPipelineByPropertyName = false)]
        public string Destination { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, ResourceObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = ExpressRoutePort.ResourceGroupName;
                PortName = ExpressRoutePort.Name;
            }
            if (string.Equals(this.ParameterSetName, ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(Id);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                PortName = resourceInfo.ResourceName;
            }
            if(this.ResourceGroupName == null || this.PortName == null){
                Console.WriteLine("Empty resource group or port name.");
                return;
            }
            GenerateExpressRoutePortsLOARequest generateExpressRoutePortsLOARequest = new GenerateExpressRoutePortsLOARequest(CustomerName);
            var response = this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.GenerateLOA(this.ResourceGroupName, this.PortName, generateExpressRoutePortsLOARequest);
            var decodedDocument = Convert.FromBase64String(response.EncodedContent);
            if (String.IsNullOrEmpty(Destination))
            {
                Destination = DefaultFileName;
            }
            if (!(Path.IsPathRooted(Destination)))
            {
                Destination = Directory.GetCurrentDirectory() + "\\" + Destination;
            }
            File.WriteAllBytes(Destination, decodedDocument);
            Console.WriteLine("Written Letter of Authorization To: " + Destination);
            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
