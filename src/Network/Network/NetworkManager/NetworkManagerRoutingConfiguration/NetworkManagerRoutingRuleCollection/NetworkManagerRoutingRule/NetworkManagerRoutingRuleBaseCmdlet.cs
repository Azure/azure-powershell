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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Net;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class NetworkManagerRoutingRuleBaseCmdlet : NetworkBaseCmdlet
    {
        public IRoutingRulesOperations NetworkManagerRoutingRuleOperationClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.RoutingRules;
            }
        }

        public bool IsNetworkManagerRoutingRulePresent(string resourceGroupName, string networkManagerName, string configName, string ruleCollectionName, string name)
        {
            try
            {
                this.NetworkManagerRoutingRuleOperationClient.Get(resourceGroupName, networkManagerName, configName, ruleCollectionName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound || exception.Response.StatusCode == HttpStatusCode.BadRequest)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSNetworkManagerRoutingRule GetNetworkManagerRoutingRule(string resourceGroupName, string networkManagerName, string configName, string ruleCollectionName, string name)
        {
            var routingRule = this.NetworkManagerRoutingRuleOperationClient.Get(resourceGroupName, networkManagerName, configName, ruleCollectionName, name);
            var psRoutingRule = this.ToPSRoutingRule(routingRule);
            psRoutingRule.ResourceGroupName = resourceGroupName;
            psRoutingRule.NetworkManagerName = networkManagerName;
            psRoutingRule.RoutingConfigurationName = configName;
            psRoutingRule.RuleCollectionName = ruleCollectionName;
            return psRoutingRule;
        }

        public PSNetworkManagerRoutingRule ToPSRoutingRule(RoutingRule routingRule)
        {
            PSNetworkManagerRoutingRule psRoutingRule;
            if (routingRule.GetType().Name == "RoutingRule")
            {
                psRoutingRule = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerRoutingRule>(routingRule);
            }
            else
            {
                throw new ErrorException("Unknown Routing Rule Type");
            }
            
            return psRoutingRule;
        }
    }
}
