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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayFirewallPolicy"), OutputType(typeof(PSApplicationGatewayWebApplicationFirewallPolicy))]
    public class GetAzureApplicationGatewayFirewallPolicyCommand : ApplicationGatewayFirewallPolicyBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/applicationGatewayWebApplicationFirewallPolicies", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var firewallPolicy = this.GetApplicationGatewayFirewallPolicy(this.ResourceGroupName, this.Name);

                WriteObject(firewallPolicy);
            }
            else
            {
                IPage<WebApplicationFirewallPolicy> firewallPolicyPage;
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    firewallPolicyPage = this.ApplicationGatewayFirewallPolicyClient.List(this.ResourceGroupName);
                }
                else
                {
                    firewallPolicyPage = this.ApplicationGatewayFirewallPolicyClient.ListAll();
                }

                // Get all resources by polling on next page link
                var firewallPolicyResponseList = ListNextLink<WebApplicationFirewallPolicy>.GetAllResourcesByPollingNextLink(firewallPolicyPage, this.ApplicationGatewayFirewallPolicyClient.ListNext);

                var psFirewallPolicies = new List<PSApplicationGatewayWebApplicationFirewallPolicy>();

                foreach (var firewallPolicy in firewallPolicyResponseList)
                {
                    var psFirewallPolicy = this.ToPsApplicationGatewayFirewallPolicy(firewallPolicy);
                    psFirewallPolicy.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(firewallPolicy.Id);
                    psFirewallPolicies.Add(psFirewallPolicy);
                }

                WriteObject(psFirewallPolicies, true);
            }
        }
    }
}
