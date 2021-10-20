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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayFirewallPolicyExclusionManagedRuleGroup"), OutputType(typeof(PSApplicationGatewayFirewallPolicyExclusionManagedRuleGroup))]
    public class NewAzureApplicationGatewayFirewallPolicyExclusionManagedRuleGroupCommand : NetworkBaseCmdlet
    {
        [Alias("RuleGroupName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Rule Group Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of Rules.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallPolicyExclusionManagedRule[] Rule { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(NewObject());
        }

        protected PSApplicationGatewayFirewallPolicyExclusionManagedRuleGroup NewObject()
        {
            return new PSApplicationGatewayFirewallPolicyExclusionManagedRuleGroup()
            {
                RuleGroupName = this.Name,
                Rules = this.Rule?.ToList()
            };
        }
    }
}
