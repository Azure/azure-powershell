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
    public abstract class NetworkManagerSecurityUserRuleCollectionBaseCmdlet : NetworkBaseCmdlet
    {
        public ISecurityUserRuleCollectionsOperations NetworkManagerSecurityUserRuleCollectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.SecurityUserRuleCollections;
            }
        }

        public bool IsNetworkManagerSecurityUserRuleCollectionPresent(string resourceGroupName, string networkManagerName, string securityUserConfigName, string name)
        {
            try
            {
                GetNetworkManagerSecurityUserRuleCollection(resourceGroupName, networkManagerName, securityUserConfigName, name);
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


        public PSNetworkManagerSecurityUserRuleCollection GetNetworkManagerSecurityUserRuleCollection(string resourceGroupName, string networkManagerName, string securityUserConfigName, string name)
        {
            var ruleCollection = this.NetworkManagerSecurityUserRuleCollectionClient.Get(resourceGroupName, networkManagerName, securityUserConfigName, name);
            var psRuleCollection = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerSecurityUserRuleCollection>(ruleCollection);

            psRuleCollection.ResourceGroupName = resourceGroupName;
            psRuleCollection.NetworkManagerName = networkManagerName;
            psRuleCollection.SecurityUserConfigurationName = securityUserConfigName;
            return psRuleCollection;
        }

        public PSNetworkManagerSecurityUserRuleCollection ToPsNetworkManagerSecurityUserRuleCollection(SecurityUserRuleCollection ruleCollection)
        {
            var psRuleCollection = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerSecurityUserRuleCollection>(ruleCollection);
            return psRuleCollection;
        }
    }
}