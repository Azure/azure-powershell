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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Net;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class IpamPoolBaseCmdlet : NetworkBaseCmdlet
    {
        public IIpamPoolsOperations IpamPoolClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.IpamPools;
            }
        }

        public bool IsIpamPoolPresent(string resourceGroupName, string networkManagerName, string poolName)
        {
            try
            {
                GetIpamPool(resourceGroupName, networkManagerName, poolName);
            }
            catch (Microsoft.Azure.Management.Network.Models.CommonErrorResponseException exception)
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


        public PSIpamPool GetIpamPool(string resourceGroupName, string networkManagerName, string poolName)
        {
            var ipamPool = this.IpamPoolClient.Get(resourceGroupName, networkManagerName, poolName);
            var psIpamPool = ToPsIpamPool(ipamPool);
            psIpamPool.Tags = ipamPool.Tags;
            psIpamPool.ResourceGroupName = resourceGroupName;
            psIpamPool.NetworkManagerName = networkManagerName;
            return psIpamPool;
        }

        public PSIpamPool ToPsIpamPool(Management.Network.Models.IpamPool ipamPool)
        {
            var psIpamPool = NetworkResourceManagerProfile.Mapper.Map<PSIpamPool>(ipamPool);
            return psIpamPool;
        }

        public PSPoolAssociation ToPsPoolAssociation(Management.Network.Models.PoolAssociation poolAssociation)
        {
            var psPoolAssociation = NetworkResourceManagerProfile.Mapper.Map<PSPoolAssociation>(poolAssociation);
            return psPoolAssociation;
        }

        public PSPoolUsage ToPsPoolUsage(Management.Network.Models.PoolUsage poolUsage)
        {
            var psPoolUsage = NetworkResourceManagerProfile.Mapper.Map<PSPoolUsage>(poolUsage);
            return psPoolUsage;
        }
    }
}