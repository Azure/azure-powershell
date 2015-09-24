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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureRmExpressRouteCircuitAuthorizationConfig"), OutputType(typeof(PSExpressRouteCircuit))]
    public class AddAzureExpressRouteCircuitAuthorizationConfigCommand : AzureExpressRouteCircuitAuthorizationConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the authorization")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCircuit")]
        public PSExpressRouteCircuit Circuit { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            // Verify if the subnet exists in the VirtualNetwork
            var auth = this.Circuit.Authorizations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (auth != null)
            {
                throw new ArgumentException("Authorization with the specified name already exists");
            }

            auth = new PSExpressRouteCircuitAuthorization();

            auth.Name = this.Name;
            auth.AuthorizationKey = this.AuthorizationKey;

            this.Circuit.Authorizations.Add(auth);

            WriteObject(this.Circuit);
        }
    }
}
