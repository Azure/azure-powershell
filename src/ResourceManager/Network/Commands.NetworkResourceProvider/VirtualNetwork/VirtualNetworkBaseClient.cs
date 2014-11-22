
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

using System;
using AutoMapper;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    public abstract class VirtualNetworkBaseClient : NetworkResourceBaseClient
    {
        public const string VirtualNetworkCmdletName = "AzureNrpVirtualNetwork";

        public IVirtualNetworkOperations VirtualNetworkClient
        {
            get
            {
                return NetworkClient.NetworkResourceProviderClient.VirtualNetworks;
            }
        }

        public bool IsVirtualNetworkPresent(string resrouceGroupName, string name)
        {
            try
            {
                GetVirtualNetwork(resrouceGroupName, name);
            }
            catch (CloudException exception)
            {
                if (string.Equals(exception.ErrorCode, ResourceNotFound, StringComparison.OrdinalIgnoreCase))
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSVirtualNetwork GetVirtualNetwork(string resourceGroupName, string name)
        {
            var getNetworkInterfaceResponse = this.VirtualNetworkClient.Get(resourceGroupName, name);

            var virtualNetwork = Mapper.Map<PSVirtualNetwork>(getNetworkInterfaceResponse.VirtualNetwork);
            virtualNetwork.ResourceGroupName = resourceGroupName;

            return virtualNetwork;
        }
    }
}