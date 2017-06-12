
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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class LocalNetworkGatewayBaseCmdlet : NetworkBaseCmdlet
    {
        public ILocalNetworkGatewaysOperations LocalNetworkGatewayClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.LocalNetworkGateways;
            }
        }

        public bool IsLocalNetworkGatewayPresent(string resourceGroupName, string name)
        {
            try
            {
                GetLocalNetworkGateway(resourceGroupName, name);
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

        public PSLocalNetworkGateway GetLocalNetworkGateway(string resourceGroupName, string name)
        {
            var localNetworkGateway = this.LocalNetworkGatewayClient.Get(resourceGroupName, name);

            var psLocalNetworkGateway = ToPsLocalNetworkGateway(localNetworkGateway);
            psLocalNetworkGateway.ResourceGroupName = resourceGroupName;

            return psLocalNetworkGateway;
        }

        public PSLocalNetworkGateway ToPsLocalNetworkGateway(LocalNetworkGateway localnetGateway)
        {
            var psLocalNetworkGateway = Mapper.Map<PSLocalNetworkGateway>(localnetGateway);

            psLocalNetworkGateway.Tag = TagsConversionHelper.CreateTagHashtable(localnetGateway.Tags);

            return psLocalNetworkGateway;
        }
    }
}