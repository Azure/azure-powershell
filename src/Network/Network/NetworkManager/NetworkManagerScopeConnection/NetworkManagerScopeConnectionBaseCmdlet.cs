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
    public abstract class NetworkManagerScopeConnectionBaseCmdlet : NetworkBaseCmdlet
    {
        public IScopeConnectionsOperations NetworkManagerScopeConnectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ScopeConnections;
            }
        }

        public bool IsNetworkManagerScopeConnectionPresent(string resourceGroupName, string networkManagerName, string name)
        {
            try
            {
                GetNetworkManagerScopeConnection(resourceGroupName, networkManagerName, name);
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

        public PSNetworkManagerScopeConnection GetNetworkManagerScopeConnection(string resourceGroupName, string networkManagerName, string name)
        {
            var networkManagerScopeConnection = this.NetworkManagerScopeConnectionClient.Get(resourceGroupName, networkManagerName, name);
            var psNetworkManagerScopeConnection = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerScopeConnection>(networkManagerScopeConnection);

            psNetworkManagerScopeConnection.ResourceGroupName = resourceGroupName;
            psNetworkManagerScopeConnection.NetworkManagerName = networkManagerName;
            return psNetworkManagerScopeConnection;
        }

        // Temporary - to be removed
        public void NullifyNetworkManagerScopeConnectionIfAbsent(ScopeConnection networkManagerScopeConnection)
        {
            if (networkManagerScopeConnection == null)
            {
                return;
            }
        }

        public PSNetworkManagerScopeConnection ToPsNetworkManagerScopeConnection(ScopeConnection networkManagerScopeConnection)
        {
            var psNetworkManagerScopeConnection = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerScopeConnection>(networkManagerScopeConnection);
            return psNetworkManagerScopeConnection;
        }
    }
}