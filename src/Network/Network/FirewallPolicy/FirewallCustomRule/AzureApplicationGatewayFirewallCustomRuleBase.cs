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
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayFirewallCustomRuleBase : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Name of the Rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Describes priority of the rule. Rules with a lower value will be evaluated before rules with a higher value.")]
        [ValidateNotNullOrEmpty]
        public int Priority { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Duration over which Rate Limit policy will be applied. Applies only when ruleType is RateLimitRule.")]
        [ValidateSet("OneMin", "FiveMins", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string RateLimitDuration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Rate Limit threshold to apply in case ruleType is RateLimitRule. Must be greater than or equal to 1")]
        [ValidateNotNullOrEmpty]
        public int RateLimitThreshold { get; set; } 

        [Parameter(
            Mandatory = true,
            HelpMessage = "Describes type of rule.")]
        [ValidateSet("MatchRule", "RateLimitRule", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string RuleType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of match conditions.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallCondition[] MatchCondition { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Define user session identifier group by clauses.")]
        [ValidateCount(1, 1)]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallCustomRuleGroupByUserSession[] GroupByUserSession { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Type of Actions.")]
        [ValidateSet("Allow", "Block", "Log", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Action { get; set; }

        [Parameter(
            HelpMessage = "Describes state of rule.")]
        [ValidateSet("Disabled", "Enabled", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.MyInvocation.BoundParameters.ContainsKey("State"))
            {
                this.State = "Enabled";
            }
        }

        protected PSApplicationGatewayFirewallCustomRule NewObject()
        {
            return new PSApplicationGatewayFirewallCustomRule()
            {
                Name = this.Name,
                Priority = this.Priority,
                RuleType = this.RuleType,
                RateLimitDuration = this.RateLimitDuration,
                RateLimitThreshold = this.RateLimitThreshold,
                MatchConditions = this.MatchCondition?.ToList(),
                GroupByUserSession = this.GroupByUserSession?.ToList(),
                Action = this.Action,
                State = this.State
            };
        }
    }
}
