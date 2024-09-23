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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRuleCollection", DefaultParameterSetName = ByListParameterSet), OutputType(typeof(PSNetworkManagerRoutingRuleCollection))]
    public class GetAzNetworkManagerRoutingRuleCollectionCommand : NetworkManagerRoutingRuleCollectionBaseCmdlet
    {
        private const string ByListParameterSet = "ByList";
        private const string ByNameParameterSet = "ByName";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceGroupAndNameParameterSet = "ByResourceGroupAndName";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ByNameParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ByResourceGroupAndNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "RoutingConfigurationName")]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string RoutingConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByResourceGroupAndNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByResourceIdParameterSet,
            HelpMessage = "NetworkManager RoutingCollection Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("RoutingCollectionId")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The input object containing the necessary properties.",
            ParameterSetName = ByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSNetworkManagerRoutingRuleCollection InputObject { get; set; }

        public override void Execute()
        {
            base.Execute();

            switch (this.ParameterSetName)
            {
                case ByNameParameterSet:
                    var ruleCollectionByName = this.GetNetworkManagerRoutingRuleCollection(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.Name);
                    WriteObject(ruleCollectionByName);
                    break;

                case ByResourceIdParameterSet:
                    var resourceId = this.ResourceId;
                    var resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(resourceId);
                    var networkManagerName = NetworkBaseCmdlet.GetResourceName(resourceId, "networkManagers");
                    var routingConfigurationName = NetworkBaseCmdlet.GetResourceName(resourceId, "routingConfigurations");
                    var ruleCollectionName = NetworkBaseCmdlet.GetResourceName(resourceId, "ruleCollections");

                    var ruleCollectionByResourceId = this.GetNetworkManagerRoutingRuleCollection(resourceGroupName, networkManagerName, routingConfigurationName, ruleCollectionName);
                    WriteObject(ruleCollectionByResourceId);
                    break;

                case ByInputObjectParameterSet:
                    var inputObject = this.InputObject;
                    var ruleCollectionByInputObject = this.GetNetworkManagerRoutingRuleCollection(inputObject.ResourceGroupName, inputObject.NetworkManagerName, inputObject.RoutingConfigurationName, inputObject.Name);
                    WriteObject(ruleCollectionByInputObject);
                    break;

                case ByListParameterSet:
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

                case ByResourceGroupAndNameParameterSet:
                    ProcessByResourceGroupAndNameAsync();
                    break;

                default:
                    break;
            }
        }

        private void ProcessByResourceGroupAndNameAsync()
        {
            // List all network managers in the resource group
            var networkManagers = this.NetworkClient.NetworkManagementClient.NetworkManagers.List(this.ResourceGroupName);

            foreach (var networkManager in networkManagers)
            {
                // List all routing configurations in the network manager
                var routingConfigurations = this.NetworkClient.NetworkManagementClient.NetworkManagerRoutingConfigurations.List(this.ResourceGroupName, networkManager.Name);

                foreach (var routingConfiguration in routingConfigurations)
                {
                    // List all rule collections in the routing configuration
                    var ruleCollections = this.NetworkClient.NetworkManagementClient.RoutingRuleCollections.List(this.ResourceGroupName, networkManager.Name, routingConfiguration.Name);

                    foreach (var ruleCollection in ruleCollections)
                    {
                        if (ruleCollection.Name.Equals(this.Name, System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            var psRuleCollection = this.ToPsNetworkManagerRoutingRuleCollection(ruleCollection);
                            psRuleCollection.ResourceGroupName = this.ResourceGroupName;
                            psRuleCollection.NetworkManagerName = networkManager.Name;
                            psRuleCollection.RoutingConfigurationName = routingConfiguration.Name;
                            WriteObject(psRuleCollection);
                            return;
                        }
                    }
                }
            }

            throw new PSArgumentException($"Routing rule '{this.Name}' not found in resource group '{this.ResourceGroupName}'.");
        }
    }
}
