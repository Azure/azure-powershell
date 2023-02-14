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
        public string RuleSetVersion { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "The disabled rule groups.")]
        [Alias(DisabledRuleGroupsAlias)]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallDisabledRuleGroup[] DisabledRuleGroup { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Whether request body is checked or not.")]
        [ValidateNotNullOrEmpty]
        public bool RequestBodyCheck { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Max request body size in KB.")]
        [ValidateNotNullOrEmpty]
        public int MaxRequestBodySizeInKb { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Max file upload limit in MB.")]
        [ValidateNotNullOrEmpty]
        public int FileUploadLimitInMb { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "The exclusion lists.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallExclusion[] Exclusion { get; set; }

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
            if (!this.MyInvocation.BoundParameters.ContainsKey("RequestBodyCheck"))
            {
                this.RequestBodyCheck = true;
            }
            if (!this.MyInvocation.BoundParameters.ContainsKey("MaxRequestBodySizeInKb"))
            {
                this.MaxRequestBodySizeInKb = 128;
            }
            if (!this.MyInvocation.BoundParameters.ContainsKey("FileUploadLimitInMb"))
            {
                this.FileUploadLimitInMb = 100;
            }
        }
    }
}
