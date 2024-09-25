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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRuleCollection", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSNetworkManagerRoutingRuleCollection))]
    public class GetAzNetworkManagerRoutingRuleCollectionCommand : NetworkManagerRoutingRuleCollectionBaseCmdlet
    {
        private const string ListParameterSet = "ByList";
        private const string GetByNameParameterSet = "ByName";
        private const string GetByResourceIdParameterSet = "ByResourceId";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "RoutingConfigurationName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string RoutingConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = "The network manager routing collection id.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("RoutingCollectionId")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            switch (this.ParameterSetName)
            {
                case GetByNameParameterSet:
                    var ruleCollectionByName = this.GetNetworkManagerRoutingRuleCollection(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.Name);
                    WriteObject(ruleCollectionByName);
                    break;

                case GetByResourceIdParameterSet:
                    var resourceId = this.ResourceId;
                    var resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(resourceId);
                    var networkManagerName = NetworkBaseCmdlet.GetResourceName(resourceId, "networkManagers");
                    var routingConfigurationName = NetworkBaseCmdlet.GetResourceName(resourceId, "routingConfigurations");
                    var ruleCollectionName = NetworkBaseCmdlet.GetResourceName(resourceId, "ruleCollections");

                    var ruleCollectionByResourceId = this.GetNetworkManagerRoutingRuleCollection(resourceGroupName, networkManagerName, routingConfigurationName, ruleCollectionName);
                    WriteObject(ruleCollectionByResourceId);
                    break;

                case ListParameterSet:
                    var ruleCollectionPage = this.NetworkManagerRoutingRuleCollectionClient.List(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName);

                    // Get all resources by polling on next page link
                    var ruleCollectionList = ListNextLink<RoutingRuleCollection>.GetAllResourcesByPollingNextLink(ruleCollectionPage, this.NetworkManagerRoutingRuleCollectionClient.ListNext);
                    var psRuleCollectionList = new List<PSNetworkManagerRoutingRuleCollection>();

                    foreach (var ruleCollectionModel in ruleCollectionList)
                    {
                        var psRuleCollectionModel = this.ToPsNetworkManagerRoutingRuleCollection(ruleCollectionModel);
                        psRuleCollectionModel.ResourceGroupName = this.ResourceGroupName;
                        psRuleCollectionModel.NetworkManagerName = this.NetworkManagerName;
                        psRuleCollectionModel.RoutingConfigurationName = this.RoutingConfigurationName;
                        psRuleCollectionList.Add(psRuleCollectionModel);
                    }

                    WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psRuleCollectionList), true);
                    break;

                default:
                    break;
            }
        }
    }
}
