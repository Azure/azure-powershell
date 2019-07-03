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
            Mandatory = true,
            HelpMessage = "Describes type of rule.")]
        [ValidateSet("MatchRule", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string RuleType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of match conditions.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallCondition[] MatchCondition { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Type of Actions.")]
        [ValidateSet("Allow", "Block", "Log", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Action { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallCustomRule NewObject()
        {
            return new PSApplicationGatewayFirewallCustomRule()
            {
                Name = this.Name,
                Priority = this.Priority,
                RuleType = this.RuleType,
                MatchConditions = this.MatchCondition?.ToList(),
                Action = this.Action
            };
        }
    }
}
