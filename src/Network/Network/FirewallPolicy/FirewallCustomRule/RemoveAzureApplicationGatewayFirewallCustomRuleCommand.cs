

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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using System.Text;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayFirewallCustomRule", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureApplicationGatewayFirewallCustomRuleCommand : ApplicationGatewayFirewallPolicyBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/applicationGatewayWebApplicationFirewallCustomRule", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The policy name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string PolicyName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsApplicationGatewayFirewallPolicyPresent(ResourceGroupName, PolicyName))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var firewallPolicy = this.GetApplicationGatewayFirewallPolicy(ResourceGroupName, PolicyName);

            foreach (PSApplicationGatewayFirewallCustomRule rule in firewallPolicy.CustomRules)
            {
                if(rule.Name == this.Name)
                {
                    firewallPolicy.CustomRules.Remove(rule);
                }
                break;
            }

            // Map to the sdk object
            var firewallPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.WebApplicationFirewallPolicy>(firewallPolicy);
            firewallPolicyModel.Tags = TagsConversionHelper.CreateTagDictionary(firewallPolicy.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.ApplicationGatewayFirewallPolicyClient.CreateOrUpdate(ResourceGroupName, PolicyName, firewallPolicyModel);

            var getApplicationGatewayFirewallPolicy = this.GetApplicationGatewayFirewallPolicy(ResourceGroupName, PolicyName);

            // Assign the CustomBlockResponse fields from policy settings to policy (Feature parity with AFD WAF Policy)
            getApplicationGatewayFirewallPolicy.CustomBlockResponseStatusCode = getApplicationGatewayFirewallPolicy.PolicySettings.CustomBlockResponseStatusCode;

            // decode the body value as it is base64 encoded
            if (!string.IsNullOrEmpty(getApplicationGatewayFirewallPolicy.PolicySettings.CustomBlockResponseBody))
            {
                string decodedCustomBlockResponseBody = Encoding.UTF8.GetString(Convert.FromBase64String(getApplicationGatewayFirewallPolicy.PolicySettings.CustomBlockResponseBody));
                getApplicationGatewayFirewallPolicy.CustomBlockResponseBody = decodedCustomBlockResponseBody;
            }

            WriteObject(getApplicationGatewayFirewallPolicy.CustomRules);

        }
    }
}
