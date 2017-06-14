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
    [Cmdlet(VerbsCommon.Set, "AzureRmApplicationGatewayBackendHttpSettings"), OutputType(typeof(PSApplicationGateway))]
    public class SetAzureApplicationGatewayBackendHttpSettingsCommand : AzureApplicationGatewayBackendHttpSettingsBase
    {
        [Parameter(
                 Mandatory = true,
                 ValueFromPipeline = true,
                 HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var oldBackendHttpSettings = this.ApplicationGateway.BackendHttpSettingsCollection.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (oldBackendHttpSettings == null)
            {
                throw new ArgumentException("Backend http settings with the specified name does not exist");
            }

            var newBackendHttpSettings = base.NewObject();

            this.ApplicationGateway.BackendHttpSettingsCollection.Remove(oldBackendHttpSettings);
            this.ApplicationGateway.BackendHttpSettingsCollection.Add(newBackendHttpSettings);

            WriteObject(this.ApplicationGateway);
        }
    }
}