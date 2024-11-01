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
    public abstract class NetworkManagerSecurityAdminConfigurationBaseCmdlet : NetworkBaseCmdlet
    {
        public ISecurityAdminConfigurationsOperations NetworkManagerSecurityAdminConfigurationClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.SecurityAdminConfigurations;
            }
        }

        public bool IsNetworkManagerSecurityAdminConfigurationPresent(string resourceGroupName, string networkManagerName, string name)
        {
            try
            {
                GetNetworkManagerSecurityAdminConfiguration(resourceGroupName, networkManagerName, name);
            }
            catch (CommonErrorResponseException exception)
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


        public PSNetworkManagerSecurityAdminConfiguration GetNetworkManagerSecurityAdminConfiguration(string resourceGroupName, string networkManagerName, string name)
        {
            var nmsc = this.NetworkManagerSecurityAdminConfigurationClient.Get(resourceGroupName, networkManagerName, name);

            var psNetworkManagerSecurityConfiguration = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerSecurityAdminConfiguration>(nmsc);
            psNetworkManagerSecurityConfiguration.ResourceGroupName = resourceGroupName;
            psNetworkManagerSecurityConfiguration.NetworkManagerName = networkManagerName;
            return psNetworkManagerSecurityConfiguration;
        }

        // Temporary - to be removed
        public void NullifyNetworkManagerSecurityAdminConfigurationIfAbsent(SecurityAdminConfiguration nmsc)
        {
            if (nmsc == null)
            {
                return;
            }
        }

        public PSNetworkManagerSecurityAdminConfiguration ToPsNetworkManagerSecurityAdminConfiguration(SecurityAdminConfiguration nmsc)
        {
            var psNmsc = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerSecurityAdminConfiguration>(nmsc);

            return psNmsc;
        }
    }
}