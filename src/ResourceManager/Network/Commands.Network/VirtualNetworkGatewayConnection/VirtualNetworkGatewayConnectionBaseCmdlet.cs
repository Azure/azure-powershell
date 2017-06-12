
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
    public abstract class VirtualNetworkGatewayConnectionBaseCmdlet : NetworkBaseCmdlet
    {
        public IVirtualNetworkGatewayConnectionsOperations VirtualNetworkGatewayConnectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworkGatewayConnections;
            }
        }

        public bool IsVirtualNetworkGatewayConnectionPresent(string resourceGroupName, string name)
        {
            try
            {
                GetVirtualNetworkGatewayConnection(resourceGroupName, name);
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

        public PSVirtualNetworkGatewayConnection GetVirtualNetworkGatewayConnection(string resourceGroupName, string name)
        {
            var connection = this.VirtualNetworkGatewayConnectionClient.Get(resourceGroupName, name);

            var psVirtualNetworkGatewayConnection = ToPsVirtualNetworkGatewayConnection(connection);
            psVirtualNetworkGatewayConnection.ResourceGroupName = resourceGroupName;

            return psVirtualNetworkGatewayConnection;
        }

        public PSVirtualNetworkGatewayConnection ToPsVirtualNetworkGatewayConnection(VirtualNetworkGatewayConnection vnetGatewayConnection)
        {
            var psVirtualNetworkGatewayConnection = Mapper.Map<PSVirtualNetworkGatewayConnection>(vnetGatewayConnection);

            psVirtualNetworkGatewayConnection.Tag = TagsConversionHelper.CreateTagHashtable(vnetGatewayConnection.Tags);

            return psVirtualNetworkGatewayConnection;
        }

        public string GetVirtualNetworkGatewayConnectionSharedKey(string resourceGroupName, string name)
        {
            var getVirtualNetworkGatewayConnectionSharedKeyResponse = this.VirtualNetworkGatewayConnectionClient.GetSharedKey(resourceGroupName, name);
            var psVirtualNetworkGatewayConnectionSharedKey = Mapper.Map<string>(getVirtualNetworkGatewayConnectionSharedKeyResponse.Value);
            return psVirtualNetworkGatewayConnectionSharedKey;
        }

        public bool IsVirtualNetworkGatewayConnectionSharedKeyPresent(string resourceGroupName, string name)
        {
            try
            {
                GetVirtualNetworkGatewayConnectionSharedKey(resourceGroupName, name);
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