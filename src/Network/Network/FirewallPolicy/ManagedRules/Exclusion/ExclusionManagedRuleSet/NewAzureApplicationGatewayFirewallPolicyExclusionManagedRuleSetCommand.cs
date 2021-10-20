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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayFirewallPolicyExclusionManagedRuleSet"), OutputType(typeof(PSApplicationGatewayFirewallPolicyExclusionManagedRuleSet))]
    public class NewAzureApplicationGatewayFirewallPolicyExclusionManagedRuleSetCommand : NetworkBaseCmdlet
    {
        [Alias("RuleSetType")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "RuleSet Type.")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Alias("RuleSetVersion")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "RuleSet Version.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Rule Groups.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallPolicyExclusionManagedRuleGroup[] RuleGroup { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(NewObject());
        }

        protected PSApplicationGatewayFirewallPolicyExclusionManagedRuleSet NewObject()
        {
            return new PSApplicationGatewayFirewallPolicyExclusionManagedRuleSet()
            {
                RuleSetType = this.Type,
                RuleSetVersion = this.Version,
                RuleGroups = this.RuleGroup?.ToList()
            };
        }
    }
}