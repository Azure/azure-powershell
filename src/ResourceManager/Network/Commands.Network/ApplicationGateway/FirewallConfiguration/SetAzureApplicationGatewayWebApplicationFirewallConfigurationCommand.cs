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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmApplicationGatewayWebApplicationFirewallConfiguration", SupportsShouldProcess = true),
        OutputType(typeof(PSApplicationGateway))]
    public class SetAzureApplicationGatewayWebApplicationFirewallConfigurationCommand : AzureApplicationGatewayWebApplicationFirewallConfigurationBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The application gateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess("AzureApplicationGatewayWebApplicationFirewallConfiguration", Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage))
            {
                base.ExecuteCmdlet();

                if (this.ApplicationGateway.WebApplicationFirewallConfiguration == null)
                {
                    this.ApplicationGateway.WebApplicationFirewallConfiguration = new PSApplicationGatewayWebApplicationFirewallConfiguration();
                }

                this.ApplicationGateway.WebApplicationFirewallConfiguration.Enabled = this.Enabled;
                this.ApplicationGateway.WebApplicationFirewallConfiguration.FirewallMode = this.FirewallMode;
                this.ApplicationGateway.WebApplicationFirewallConfiguration.RuleSetType = this.RuleSetType;
                this.ApplicationGateway.WebApplicationFirewallConfiguration.RuleSetVersion = this.RuleSetVersion;
                this.ApplicationGateway.WebApplicationFirewallConfiguration.DisabledRuleGroups = this.DisabledRuleGroups;

                WriteObject(this.ApplicationGateway);
            }
        }
    }
}
