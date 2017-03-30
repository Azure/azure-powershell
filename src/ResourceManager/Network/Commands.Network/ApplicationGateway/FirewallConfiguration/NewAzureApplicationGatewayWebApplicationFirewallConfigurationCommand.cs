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
    [Cmdlet(VerbsCommon.New, "AzureRmApplicationGatewayWebApplicationFirewallConfiguration", SupportsShouldProcess = true),
        OutputType(typeof(PSApplicationGatewayWebApplicationFirewallConfiguration))]
    public class NewAzureApplicationGatewayWebApplicationFirewallConfigurationCommand : AzureApplicationGatewayWebApplicationFirewallConfigurationBase
    {
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess("AzureApplicationGatewayWebApplicationFirewallConfiguration", Microsoft.Azure.Commands.Network.Properties.Resources.CreatingResourceMessage))
            {
                base.ExecuteCmdlet();

                PSApplicationGatewayWebApplicationFirewallConfiguration firewallConfiguration = new PSApplicationGatewayWebApplicationFirewallConfiguration()
                {
                    Enabled = this.Enabled,
                    FirewallMode = this.FirewallMode,
                    RuleSetType = this.RuleSetType,
                    RuleSetVersion = this.RuleSetVersion,
                    DisabledRuleGroups = this.DisabledRuleGroups
                };

                WriteObject(firewallConfiguration);
            }
        }
    }
}
