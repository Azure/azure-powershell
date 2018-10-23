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
    [Cmdlet(VerbsCommon.Set, "AzureRmApplicationGatewayFrontendPort"), OutputType(typeof(PSApplicationGateway))]
    public class SetAzureApplicationGatewayFrontendPortCommand : AzureApplicationGatewayFrontendPortBase
    {

        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var oldFrontendPort = this.ApplicationGateway.FrontendPorts.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (oldFrontendPort == null)
            {
                throw new ArgumentException("Frontend port with the specified name does not exist");
            }

            var newFrontendPort = base.NewObject();

            this.ApplicationGateway.FrontendPorts.Remove(oldFrontendPort);
            this.ApplicationGateway.FrontendPorts.Add(newFrontendPort);

            WriteObject(this.ApplicationGateway);
        }
    }
}
