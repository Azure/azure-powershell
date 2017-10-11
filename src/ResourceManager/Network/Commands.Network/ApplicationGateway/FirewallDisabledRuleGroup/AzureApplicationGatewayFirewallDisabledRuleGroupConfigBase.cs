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
    public class AzureApplicationGatewayFirewallDisabledRuleGroupConfigBase : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the rule group that will be disabled.")]
        [ValidateNotNullOrEmpty]
        public string RuleGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of rules that will be disabled. If null, all rules of the rule group will be disabled.")]
        public List<int> Rules { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallDisabledRuleGroup NewObject()
        {
            return new PSApplicationGatewayFirewallDisabledRuleGroup()
            {
                RuleGroupName = this.RuleGroupName,
                Rules = this.Rules
            };
        }
    }
}
