﻿// ----------------------------------------------------------------------------------
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
    public abstract class NetworkManagerSecurityAdminRuleBaseCmdlet : NetworkBaseCmdlet
    {
        public IAdminRulesOperations NetworkManagerSecurityAdminRuleOperationClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.AdminRules;
            }
        }

        public bool IsNetworkManagerSecurityAdminRulePresent(string resourceGroupName, string networkManagerName, string configName, string ruleCollectionName, string name)
        {
            try
            {
                this.NetworkManagerSecurityAdminRuleOperationClient.Get(resourceGroupName, networkManagerName, configName, ruleCollectionName, name);
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


        public PSNetworkManagerSecurityBaseAdminRule GetNetworkManagerSecurityAdminRule(string resourceGroupName, string networkManagerName, string configName, string ruleCollectionName, string name)
        {
            var adminRule = this.NetworkManagerSecurityAdminRuleOperationClient.Get(resourceGroupName, networkManagerName, configName, ruleCollectionName, name);
            var psAdminRule = this.ToPSSecurityAdminRule(adminRule);
            psAdminRule.ResourceGroupName = resourceGroupName;
            psAdminRule.NetworkManagerName = networkManagerName;
            psAdminRule.SecurityAdminConfigurationName = configName;
            psAdminRule.RuleCollectionName = ruleCollectionName;
            return psAdminRule;
        }

        // Temporary - to be removed
        public void NullifySecurityAdminRuleIfAbsent(BaseAdminRule adminRule)
        {
            if (adminRule == null)
            {
                return;
            }
        }

        public PSNetworkManagerSecurityBaseAdminRule ToPSSecurityAdminRule(BaseAdminRule adminRule)
        {
            PSNetworkManagerSecurityBaseAdminRule psAdminRule;
            if (adminRule.GetType().Name == "AdminRule")
            {
                psAdminRule = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerSecurityAdminRule>(adminRule);
            }
            else if(adminRule.GetType().Name == "DefaultAdminRule")
            {
                psAdminRule = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerSecurityDefaultAdminRule>(adminRule);
            }
            else
            {
                throw new ErrorException("UnKnown Admin Rule Type");
            }
            
            return psAdminRule;
        }
    }
}
