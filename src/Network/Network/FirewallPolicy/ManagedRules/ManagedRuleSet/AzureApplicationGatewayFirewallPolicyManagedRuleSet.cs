﻿// ----------------------------------------------------------------------------------
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
    public class AzureApplicationGatewayFirewallPolicyManagedRuleSet : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "RuleSet Type.")]
        [ValidateNotNullOrEmpty]
        public string RuleSetType { get; set; }

        [Parameter(
        Mandatory = true,
        HelpMessage = "RuleSet Version.")]
        [ValidateNotNullOrEmpty]
        public string RuleSetVersion { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "Rule Group Overrides.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallPolicyManagedRuleGroupOverride[] RuleGroupOverride { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallPolicyManagedRuleSet NewObject()
        {
            return new PSApplicationGatewayFirewallPolicyManagedRuleSet()
            {
                RuleSetType = this.RuleSetType,
                RuleSetVersion = this.RuleSetVersion,               
                RuleGroupOverrides = this.RuleGroupOverride?.ToList()
            };
        }
    }
}
