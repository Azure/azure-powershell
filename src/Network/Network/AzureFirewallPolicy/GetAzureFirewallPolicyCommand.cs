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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicy"), OutputType(typeof(PSAzureFirewall), typeof(IEnumerable<PSAzureFirewall>))]
    public class GetAzureFirewallPolicyCommand : AzureFirewallPolicyBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/azureFirewalls", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ResourceId")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id.")]
        [ResourceNameCompleter("Microsoft.Network/azureFirewalls", "ResourceId")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceId { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var azureFirewall = this.GetAzureFirewallPolicy(this.ResourceGroupName, this.Name);

                WriteObject(azureFirewall);
            }
            else
            {
                IPage<FirewallPolicy> azureFirewallPage = ShouldListBySubscription(ResourceGroupName, Name)
                    ? this.AzureFirewallPolicyClient.ListAll()
                    : this.AzureFirewallPolicyClient.List(this.ResourceGroupName);

                // Get all resources by polling on next page link
                var azureFirewallResponseLIst = ListNextLink<FirewallPolicy>.GetAllResourcesByPollingNextLink(azureFirewallPage, this.AzureFirewallPolicyClient.ListNext);

                var psAzureFirewalls = azureFirewallResponseLIst.Select(firewall =>
                {
                    var psAzureFirewall = this.ToPsAzureFirewallPolicy(firewall);
                    psAzureFirewall.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(firewall.Id);
                    return psAzureFirewall;
                }).ToList();

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psAzureFirewalls), true);
            }
        }
    }
}
