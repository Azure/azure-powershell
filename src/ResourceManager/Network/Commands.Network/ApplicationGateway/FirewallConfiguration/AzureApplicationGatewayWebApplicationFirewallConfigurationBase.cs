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
    public class AzureApplicationGatewayWebApplicationFirewallConfigurationBase : NetworkBaseCmdlet
    {
        [Parameter(
               Mandatory = true,
               HelpMessage = "Whether web application firewall functionality is enabled or not.")]
        [ValidateNotNullOrEmpty]
        public bool Enabled { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Web application firewall mode")]
        [ValidateSet("Detection", "Prevention", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string FirewallMode { get; set; }


        [Parameter(
               Mandatory = false,
               HelpMessage = "The type of the web application firewall rule set.")]
        [ValidateSet("OWASP")]
        public string RuleSetType { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "The version of the rule set type.")]
        [ValidateSet("3.0", "2.2.9")]
        public string RuleSetVersion { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "The disabled rule groups.")]
        [ValidateNotNullOrEmpty]
        public List<PSApplicationGatewayFirewallDisabledRuleGroup> DisabledRuleGroups { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            
            if (!this.MyInvocation.BoundParameters.ContainsKey("RuleSetType"))
            {
                this.RuleSetType = "OWASP";
            }
            if (!this.MyInvocation.BoundParameters.ContainsKey("RuleSetVersion"))
            {
                this.RuleSetVersion = "3.0";
            }
        }
    }
}
