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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRuleCollection", DefaultParameterSetName = ByListParameterSet), OutputType(typeof(PSNetworkManagerSecurityUserRuleCollection))]
    public class GetAzNetworkManagerSecurityUserRuleCollectionCommand : NetworkManagerSecurityUserRuleCollectionBaseCmdlet
    {
        private const string ByListParameterSet = "ByList";
        private const string ByNameParameterSet = "ByName";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName")]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager securityUser configuration name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager securityUser configuration name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string SecurityUserConfigurationName { get; set; }

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
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByResourceIdParameterSet,
            HelpMessage = "NetworkManager SecurityUserCollection Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("SecurityUserCollectionId")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The input object containing the necessary properties.",
            ParameterSetName = ByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSNetworkManagerSecurityUserRuleCollection InputObject { get; set; }

        public override void Execute()
        {
            base.Execute();

            switch (this.ParameterSetName)
            {
                case ByNameParameterSet:
                    var ruleCollectionByName = this.GetNetworkManagerSecurityUserRuleCollection(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.Name);
                    WriteObject(ruleCollectionByName);
                    break;

                case ByResourceIdParameterSet:
                    var resourceId = this.ResourceId;
                    var resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(resourceId);
                    var networkManagerName = NetworkBaseCmdlet.GetResourceName(resourceId, "networkManagers");
                    var securityUserConfigurationName = NetworkBaseCmdlet.GetResourceName(resourceId, "securityUserConfigurations");
                    var ruleCollectionName = NetworkBaseCmdlet.GetResourceName(resourceId, "ruleCollections");

                    var ruleCollectionByResourceId = this.GetNetworkManagerSecurityUserRuleCollection(resourceGroupName, networkManagerName, securityUserConfigurationName, ruleCollectionName);
                    WriteObject(ruleCollectionByResourceId);
                    break;

                case ByInputObjectParameterSet:
                    var inputObject = this.InputObject;
                    var ruleCollectionByInputObject = this.GetNetworkManagerSecurityUserRuleCollection(inputObject.ResourceGroupName, inputObject.NetworkManagerName, inputObject.SecurityUserConfigurationName, inputObject.Name);
                    WriteObject(ruleCollectionByInputObject);
                    break;

                case ByListParameterSet:
                    var ruleCollectionPage = this.NetworkManagerSecurityUserRuleCollectionClient.List(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName);

                    // Get all resources by polling on next page link
                    var ruleCollectionList = ListNextLink<SecurityUserRuleCollection>.GetAllResourcesByPollingNextLink(ruleCollectionPage, this.NetworkManagerSecurityUserRuleCollectionClient.ListNext);
                    var psRuleCollectionList = new List<PSNetworkManagerSecurityUserRuleCollection>();

                    foreach (var ruleCollectionModel in ruleCollectionList)
                    {
                        var psRuleCollectionModel = this.ToPsNetworkManagerSecurityUserRuleCollection(ruleCollectionModel);
                        psRuleCollectionModel.ResourceGroupName = this.ResourceGroupName;
                        psRuleCollectionModel.NetworkManagerName = this.NetworkManagerName;
                        psRuleCollectionModel.SecurityUserConfigurationName = this.SecurityUserConfigurationName;
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
