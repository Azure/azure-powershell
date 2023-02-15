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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityAdminRule", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSNetworkManagerSecurityBaseAdminRule))]
    public class GetAzNetworkManagerSecurityAdminRuleCommand : NetworkManagerSecurityAdminRuleBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "Expand")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections/rules", "ResourceGroupName", "NetworkManagerName", "SecurityAdminConfigurationName", "RuleCollectionName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin rule collection name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityAdminConfigurationName")]
        [SupportsWildcards]
        public virtual string RuleCollectionName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin configuration name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string SecurityAdminConfigurationName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }


        public override void Execute()
        {
            base.Execute();
            if (this.Name != null)
            {
                var securityAdminRule = this.GetNetworkManagerSecurityAdminRule(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.RuleCollectionName, this.Name);

                WriteObject(securityAdminRule);
            }
            else
            {
                IPage<BaseAdminRule> adminRulePage;
                adminRulePage = this.NetworkManagerSecurityAdminRuleOperationClient.List(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.RuleCollectionName);

                // Get all resources by polling on next page link
                var secrurityRuleCollectionList = ListNextLink<BaseAdminRule>.GetAllResourcesByPollingNextLink(adminRulePage, this.NetworkManagerSecurityAdminRuleOperationClient.ListNext);

                var pSNetworkManagerSecurityAdminRules = new List<PSNetworkManagerSecurityBaseAdminRule>();

                foreach (var rule in secrurityRuleCollectionList)
                {
                    var psRule = this.ToPSSecurityAdminRule(rule);
                    psRule.ResourceGroupName = this.ResourceGroupName;
                    psRule.NetworkManagerName = this.NetworkManagerName;
                    psRule.SecurityAdminConfigurationName = this.SecurityAdminConfigurationName;
                    psRule.RuleCollectionName = this.RuleCollectionName;
                    pSNetworkManagerSecurityAdminRules.Add(psRule);
                }

                WriteObject(pSNetworkManagerSecurityAdminRules);
            }
        }
    }
}

