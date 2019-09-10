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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayFirewallMatchVariableBase : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            HelpMessage = "Match Variable.")]
        [ValidateSet("RemoteAddr", "RequestMethod", "QueryString", "PostArgs", "RequestUri", "RequestHeaders", "RequestBody", "RequestCookies", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string VariableName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Describes field of the matchVariable collection.")]
        [ValidateNotNullOrEmpty]
        public string Selector { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallMatchVariable NewObject()
        {
            return new PSApplicationGatewayFirewallMatchVariable()
            {
                VariableName = this.VariableName,
                Selector = this.Selector
            };
        }
    }
}
