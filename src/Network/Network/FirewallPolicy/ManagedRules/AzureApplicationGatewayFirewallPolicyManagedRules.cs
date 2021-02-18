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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayFirewallPolicyManagedRules : NetworkBaseCmdlet
    {
        [Parameter(
          Mandatory = false,
          HelpMessage = "List of Managed ruleSets.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallPolicyManagedRuleSet[] ManagedRuleSet { get; set; }
        
        [Parameter(
          Mandatory = false,
          HelpMessage = "List of Exclusion Entry.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallPolicyExclusion[] Exclusion { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallPolicyManagedRules NewObject()
        {
            var managedRules = new PSApplicationGatewayFirewallPolicyManagedRules()
            {
                Exclusions = this.Exclusion?.ToList(),
                ManagedRuleSets = this.ManagedRuleSet?.ToList()
            };

            if (this.ManagedRuleSet == null || this.ManagedRuleSet.Count() == 0)
            {
                managedRules.ManagedRuleSets = new List<PSApplicationGatewayFirewallPolicyManagedRuleSet>()
                {
                    new PSApplicationGatewayFirewallPolicyManagedRuleSet()
                    {
                        RuleSetType = "OWASP",
                        RuleSetVersion = "3.0"
                    }
                };
            }

            return managedRules;
        }
    }
}
