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
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityAdminRuleCollection", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSNetworkManagerSecurityAdminRuleCollection))]
    public class GetAzNetworkManagerSecurityAdminRuleCollectionCommand : NetworkManagerSecurityAdminRuleCollectionBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityAdminConfigurationName")]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin configuration name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [ValidateNotNullOrEmpty]
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
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.Name != null)
            {
                var ruleCollection = this.GetNetworkManagerSecurityAdminRuleCollection(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.Name);
                WriteObject(ruleCollection);
            }
            else
            {
                IPage<AdminRuleCollection> ruleCollectionPage;
                ruleCollectionPage = this.NetworkManagerSecurityAdminRuleCollectionClient.List(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName);

                // Get all resources by polling on next page link
                var ruleCollectionList = ListNextLink<AdminRuleCollection>.GetAllResourcesByPollingNextLink(ruleCollectionPage, this.NetworkManagerSecurityAdminRuleCollectionClient.ListNext);
                var psRuleCollectionList = new List<PSNetworkManagerSecurityAdminRuleCollection>();

                foreach (var ruleCollectionModel in ruleCollectionList)
                {
                    var psRuleCollectionModel = this.ToPsNetworkManagerSecurityAdminRuleCollection(ruleCollectionModel);
                    psRuleCollectionModel.ResourceGroupName = this.ResourceGroupName;
                    psRuleCollectionModel.NetworkManagerName = this.NetworkManagerName;
                    psRuleCollectionModel.SecurityAdminConfigurationName = this.SecurityAdminConfigurationName;
                    psRuleCollectionList.Add(psRuleCollectionModel);
                }

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psRuleCollectionList), true);
            }
        }
    }
}
