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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyKubeSelectorGroup", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicyKubeSelectorGroupWrapper))]
    public class GetAzureFirewallPolicyKubeSelectorGroupCommand : AzureFirewallPolicyKubeSelectorGroupBaseCmdlet
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByInputObjectParameterSet = "GetByInputObjectParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.", ParameterSetName = GetByNameParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = GetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Firewall policy name", ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string AzureFirewallPolicyName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Firewall Policy.", ParameterSetName = GetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy AzureFirewallPolicy { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string resourceGroupName = this.ResourceGroupName;
            string firewallPolicyName = this.AzureFirewallPolicyName;
            if (this.IsParameterBound(c => c.AzureFirewallPolicy))
            {
                resourceGroupName = AzureFirewallPolicy.ResourceGroupName;
                firewallPolicyName = AzureFirewallPolicy.Name;
            }

            if (!string.IsNullOrEmpty(this.Name) && !WildcardPattern.ContainsWildcardCharacters(this.Name))
            {
                var kubeSelectorGroup = this.GetKubeSelectorGroup(resourceGroupName, firewallPolicyName, this.Name);
                WriteObject(kubeSelectorGroup);
            }
            else
            {
                var kubeSelectorGroups = this.KubeSelectorGroupClient.List(resourceGroupName, firewallPolicyName)
                    .Select(group => ToPSWrapper(group)).ToList();

                if (!string.IsNullOrEmpty(this.Name))
                {
                    var wildcard = new WildcardPattern(this.Name, WildcardOptions.IgnoreCase);
                    kubeSelectorGroups = kubeSelectorGroups.Where(group => wildcard.IsMatch(group.Name)).ToList();
                }

                WriteObject(kubeSelectorGroups, true);
            }
        }
    }
}
