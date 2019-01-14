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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class NetworkInterfaceTapConfigBase : NetworkInterfaceBaseCmdlet
    {
        public INetworkInterfaceTapConfigurationsOperations NetworkInterfaceTapClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkInterfaceTapConfigurations;
            }
        }

        protected object GetNetworkInterfaceTapConfiguration(string resourceGroupName, string networkInterfaceName, string tapConfigName)
        {
            var networkInterfaceTapConfig = this.NetworkInterfaceTapClient.Get(resourceGroupName, networkInterfaceName, tapConfigName);

            var psNetworkInterfaceTapConfig = ToPSNetworkInterfaceTapConfiguration(networkInterfaceTapConfig);
            psNetworkInterfaceTapConfig.ResourceGroupName = resourceGroupName;
            psNetworkInterfaceTapConfig.NetworkInterfaceName = networkInterfaceName;

            return psNetworkInterfaceTapConfig;
        }

        public PSNetworkInterfaceTapConfiguration ToPSNetworkInterfaceTapConfiguration(NetworkInterfaceTapConfiguration networkInterfaceTapConfig)
        {
            var psNetworkInterfaceTapConfig = NetworkResourceManagerProfile.Mapper.Map<PSNetworkInterfaceTapConfiguration>(networkInterfaceTapConfig);

            return psNetworkInterfaceTapConfig;
        }

        public bool IsNetworkInterfaceTapPresent(string resouceGroupName, string networkInterfaceName, string tapConfigName)
        {
            try
            {
                this.GetNetworkInterfaceTapConfiguration(resouceGroupName, networkInterfaceName, tapConfigName);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

    }
}
