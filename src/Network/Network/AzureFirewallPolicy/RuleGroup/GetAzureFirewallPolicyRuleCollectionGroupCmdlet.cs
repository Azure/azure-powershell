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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;


namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleCollectionGroup", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicyRuleCollectionGroupWrapper))]
    public class GetAzureFirewallPolicyRuleCollectionGroupCommand : AzureFirewallPolicyRuleCollectionGroupBaseCmdlet
    {

        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByInputObjectParameterSet = "GetByInputObjectParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.", ParameterSetName = GetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = GetByInputObjectParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/azureFirewalls", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id.", ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Firewall Policy.", ParameterSetName = GetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy AzureFirewallPolicy { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Firewall policy name", ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string AzureFirewallPolicyName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (this.IsParameterBound(c => c.AzureFirewallPolicy))
            {
                var azureFirewallPolicyRuleGroup = this.GetAzureFirewallPolicyRuleGroup(AzureFirewallPolicy.ResourceGroupName, AzureFirewallPolicy.Name, this.Name);
                WriteObject(azureFirewallPolicyRuleGroup);
            }

            else if (this.IsParameterBound(c => c.AzureFirewallPolicyName))
            {
                var ruleGroup = this.GetAzureFirewallPolicyRuleGroup(this.ResourceGroupName, AzureFirewallPolicyName, this.Name);
                WriteObject(ruleGroup);
            }
        }
    }
}
