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
    public class AzureApplicationGatewayFirewallPolicyManagedRuleOverride : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Rule Id.")]
        [ValidateNotNullOrEmpty]
        public string RuleId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "State of the Rule.")]
        [ValidateSet("Disabled", "Enabled", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Action of the Rule.")]
        [ValidateSet("AnomalyScoring", "Allow", "Block", "Log", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Action { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Sensitivity of the Rule.")]
        [ValidateSet("None", "Low", "Medium", "High", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Sensitivity { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallPolicyManagedRuleOverride NewObject()
        {
            return new PSApplicationGatewayFirewallPolicyManagedRuleOverride()
            {
                RuleId = this.RuleId,
                State = string.IsNullOrEmpty(State) ? "Disabled" : this.State,
                Action = this.Action,
                Sensitivity = this.Sensitivity
            };
        }
    }
}
