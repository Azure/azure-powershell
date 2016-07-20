
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
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Management.Network.Models;

    public abstract class VirtualNetworkBaseCmdlet : NetworkBaseCmdlet
    {
        public IVirtualNetworksOperations VirtualNetworkClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworks;
            }
        }

        public bool IsVirtualNetworkPresent(string resourceGroupName, string name)
        {
            try
            {
                GetVirtualNetwork(resourceGroupName, name);
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

        public PSVirtualNetwork GetVirtualNetwork(string resourceGroupName, string name, string expandResource = null)
        {
            var vnet = this.VirtualNetworkClient.Get(resourceGroupName, name, expandResource);

            var psVirtualNetwork = Mapper.Map<PSVirtualNetwork>(vnet);
            psVirtualNetwork.ResourceGroupName = resourceGroupName;

            psVirtualNetwork.Tag =
                TagsConversionHelper.CreateTagHashtable(vnet.Tags);

            if (psVirtualNetwork.DhcpOptions == null)
            {
                psVirtualNetwork.DhcpOptions = new PSDhcpOptions();
            }

            return psVirtualNetwork;
        }

        public PSVirtualNetwork ToPsVirtualNetwork(VirtualNetwork vnet)
        {
            var psVnet = Mapper.Map<PSVirtualNetwork>(vnet);

            psVnet.Tag = TagsConversionHelper.CreateTagHashtable(vnet.Tags);

            return psVnet;
        }
    }
}