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
    public class AzureApplicationGatewayFirewallExclusionConfigBase : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            HelpMessage = "The variable to be excluded.")]
        [ValidateNotNullOrEmpty]
        public string Variable { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion applies to.")]
        [ValidateNotNullOrEmpty]
        public string Operator { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.")]
        [ValidateNotNullOrEmpty]
        public string Selector { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallExclusion NewObject()
        {
            return new PSApplicationGatewayFirewallExclusion()
            {
                MatchVariable = this.Variable,
                SelectorMatchOperator = this.Operator,
                Selector = this.Selector
            };
        }
    }
}
