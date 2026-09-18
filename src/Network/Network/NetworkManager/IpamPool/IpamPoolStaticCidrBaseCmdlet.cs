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
    public abstract class IpamPoolStaticCidrBaseCmdlet : NetworkBaseCmdlet
    {
        public IStaticCidrsOperations StaticCidrClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.StaticCidrs;
            }
        }

        public bool IsStaticCidrPresent(string resourceGroupName, string networkManagerName, string ipamPoolName, string staticCidrName)
        {
            try
            {
                GetStaticCidr(resourceGroupName, networkManagerName, ipamPoolName, staticCidrName);
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

        public PSStaticCidr GetStaticCidr(string resourceGroupName, string networkManagerName, string ipamPoolName, string staticCidrName)
        {
            var staticCidr = this.StaticCidrClient.Get(resourceGroupName, networkManagerName, ipamPoolName, staticCidrName);
            var psStaticCidr = ToPsStaticCidr(staticCidr);
            psStaticCidr.ResourceGroupName = resourceGroupName;
            psStaticCidr.NetworkManagerName = networkManagerName;
            psStaticCidr.PoolName = ipamPoolName;
            psStaticCidr.Name = staticCidrName;
            return psStaticCidr;
        }

        public PSStaticCidr ToPsStaticCidr(Management.Network.Models.StaticCidr staticCidr)
        {
            var psStaticCidr = NetworkResourceManagerProfile.Mapper.Map<PSStaticCidr>(staticCidr);
            return psStaticCidr;
        }
    }
}