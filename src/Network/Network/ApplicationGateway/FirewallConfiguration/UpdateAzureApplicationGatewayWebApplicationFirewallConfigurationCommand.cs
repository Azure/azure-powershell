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
using System.Management.Automation;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayWebApplicationFirewallConfiguration", SupportsShouldProcess = true), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayWebApplicationFirewallConfigurationCommand : AzureApplicationGatewayWebApplicationFirewallConfigurationBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The application gateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Whether web application firewall functionality is enabled or not.")]
        [ValidateNotNullOrEmpty]
        public override bool Enabled { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Web application firewall mode")]
        [ValidateSet("Detection", "Prevention", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string FirewallMode { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess("AzureApplicationGatewayWebApplicationFirewallConfiguration", Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage))
            {
                if (this.ApplicationGateway.WebApplicationFirewallConfiguration == null)
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration = new PSApplicationGatewayWebApplicationFirewallConfiguration();
                }

                if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Enabled)))
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.Enabled = this.Enabled;
                }

                if (this.FirewallMode != null)
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.FirewallMode = this.FirewallMode;
                }

                if (this.RuleSetType != null)
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.RuleSetType = this.RuleSetType;
                }

                if (this.RuleSetVersion != null)
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.RuleSetVersion = this.RuleSetVersion;
                }

                if (this.DisabledRuleGroup != null && DisabledRuleGroup.Length > 0)
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.DisabledRuleGroups = this.DisabledRuleGroup?.ToList();
                }

                if (MyInvocation.BoundParameters.ContainsKey(nameof(this.RequestBodyCheck)))
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.RequestBodyCheck = this.RequestBodyCheck;
                }

                if (MyInvocation.BoundParameters.ContainsKey(nameof(this.MaxRequestBodySizeInKb)))
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.MaxRequestBodySizeInKb = this.MaxRequestBodySizeInKb;
                }

                if (MyInvocation.BoundParameters.ContainsKey(nameof(this.FileUploadLimitInMb)))
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.FileUploadLimitInMb = this.FileUploadLimitInMb;
                }

                if (this.Exclusion != null && Exclusion.Length > 0)
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration.Exclusions = this.Exclusion?.ToList();
                }

                WriteObject(this.ApplicationGateway);
            }
        }
    }
}
