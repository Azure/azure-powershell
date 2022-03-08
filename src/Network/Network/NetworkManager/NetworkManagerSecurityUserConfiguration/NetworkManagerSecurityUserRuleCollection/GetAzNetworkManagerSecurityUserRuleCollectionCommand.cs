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
using Microsoft.Azure.Commands.Network.Models.NetworkManager;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRuleCollection", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSNetworkManagerSecurityRuleCollection))]
    public class GetAzNetworkManagerSecurityUserRuleCollectionCommand : NetworkManagerSecurityUserRuleCollectionBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName")]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security user configuration name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string SecurityUserConfigurationName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.Name != null)
            {
                var ruleCollection = this.GetNetworkManagerSecurityUserRuleCollection(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.Name);
                WriteObject(ruleCollection);
            }
            else
            {
                IPage<RuleCollection> ruleCollectionPage;
                ruleCollectionPage = this.NetworkManagerSecurityUserRuleCollectionClient.List(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName);

                // Get all resources by polling on next page link
                var ruleCollectionList = ListNextLink<RuleCollection>.GetAllResourcesByPollingNextLink(ruleCollectionPage, this.NetworkManagerSecurityUserRuleCollectionClient.ListNext);
                var psRuleCollectionList = new List<PSNetworkManagerSecurityRuleCollection>();

                foreach (var ruleCollectionModel in ruleCollectionList)
                {
                    var psRuleCollectionModel = this.ToPsNetworkManagerSecurityUserRuleCollection(ruleCollectionModel);
                    psRuleCollectionList.Add(psRuleCollectionModel);
                }

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psRuleCollectionList), true);
            }
        }
    }
}
