
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

using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class SecureGatewayBaseCmdlet : NetworkBaseCmdlet
    {
        public ISecureGatewaysOperations SecureGatewayClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.SecureGateways;
            }
        }

        protected IVirtualNetworksOperations VirtualNetworkClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworks;
            }
        }

        public bool IsSecureGatewayPresent(string resourceGroupName, string name)
        {
            try
            {
                GetSecureGateway(resourceGroupName, name);
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

        public PSSecureGateway GetSecureGateway(string resourceGroupName, string name)
        {
            var secureGateway = this.SecureGatewayClient.Get(resourceGroupName, name);

            var psSecureGateway = NetworkResourceManagerProfile.Mapper.Map<PSSecureGateway>(secureGateway);
            psSecureGateway.ResourceGroupName = resourceGroupName;
            psSecureGateway.Tag = TagsConversionHelper.CreateTagHashtable(secureGateway.Tags);

            return psSecureGateway;
        }

        public PSSecureGateway ToPsSecureGateway(SecureGateway secureGw)
        {
            var secureGateway = NetworkResourceManagerProfile.Mapper.Map<PSSecureGateway>(secureGw);

            secureGateway.Tag = TagsConversionHelper.CreateTagHashtable(secureGw.Tags);

            return secureGateway;
        }
    }
}
