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
    public abstract class VirtualNetworkPeeringBase : NetworkBaseCmdlet
    {
        public IVirtualNetworkPeeringsOperations VirtualNetworkPeeringClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworkPeerings;
            }
        }

        public PSVirtualNetworkPeering GetVirtualNetworkPeering(string resouceGroupName, string virtualNetworkName, string virtualNetworkPeeringName)
        {
            var virtualNetworkPeering = this.VirtualNetworkPeeringClient.Get(resouceGroupName, virtualNetworkName, virtualNetworkPeeringName);

            var psVirtualNetworkPeering = ToPsVirtualNetworkPeering(virtualNetworkPeering);

            psVirtualNetworkPeering.ResourceGroupName = resouceGroupName;
            psVirtualNetworkPeering.VirtualNetworkName = virtualNetworkName;

            return psVirtualNetworkPeering;

        }

        public PSVirtualNetworkPeering ToPsVirtualNetworkPeering(VirtualNetworkPeering vnetPeering)
        {
            var psVnetpeering = Mapper.Map<PSVirtualNetworkPeering>(vnetPeering);

            return psVnetpeering;
        }

        public bool IsVirtualNetworkPeeringPresent(string resouceGroupName, string virtualNetworkName, string virtualNetworkPeeringName)
        {
            try
            {
                this.GetVirtualNetworkPeering(resouceGroupName, virtualNetworkName, virtualNetworkPeeringName);
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
