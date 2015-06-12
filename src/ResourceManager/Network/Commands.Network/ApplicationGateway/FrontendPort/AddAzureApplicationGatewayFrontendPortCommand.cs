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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureApplicationGatewayFrontendPort"), OutputType(typeof(PSApplicationGateway))]
    public class AddAzureApplicationGatewayFrontendPortCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the frontend port")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Frontend port")]
        [ValidateNotNullOrEmpty]
        public int Port { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var applicationGateway = this.ApplicationGateway.FrontendPorts.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (applicationGateway != null)
            {
                throw new ArgumentException("Frontend port with the specified name already exists");
            }

            var frontendPort = new PSApplicationGatewayFrontendPort();
            applicationGateway.Name = this.Name;
            applicationGateway.Port = this.Port;

            frontendPort.Id =
                ChildResourceHelper.GetResourceId(
                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                    this.ApplicationGateway.ResourceGroupName,
                    this.ApplicationGateway.Name,
                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayFrontendPortName,
                    this.Name);

            this.ApplicationGateway.FrontendPorts.Add(frontendPort);

            WriteObject(this.ApplicationGateway);
        }
    }
}
