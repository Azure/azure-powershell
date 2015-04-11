
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
using AutoMapper;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Resources.Models;
using Hyak.Common;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    using Microsoft.Azure.Management.Network.Models;

    public abstract class NetworkInterfaceBaseCmdlet : NetworkBaseCmdlet
    {
        public INetworkInterfaceOperations NetworkInterfaceClient
        {
            get
            {
                return NetworkClient.NetworkResourceProviderClient.NetworkInterfaces;
            }
        }

        public bool IsNetworkInterfacePresent(string resourceGroupName, string name)
        {
            try
            {
                GetNetworkInterface(resourceGroupName, name);
            }
            catch (CloudException exception)
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

        public PSNetworkInterface GetNetworkInterface(string resourceGroupName, string name)
        {
            var getNetworkInterfaceResponse = this.NetworkInterfaceClient.Get(resourceGroupName, name);

            var networkInterface = Mapper.Map<PSNetworkInterface>(getNetworkInterfaceResponse.NetworkInterface);
            networkInterface.ResourceGroupName = resourceGroupName;
            networkInterface.Tag =
                TagsConversionHelper.CreateTagHashtable(getNetworkInterfaceResponse.NetworkInterface.Tags);
            
            if (networkInterface.IpConfigurations[0].PublicIpAddress == null)
            {
                networkInterface.IpConfigurations[0].PublicIpAddress = new PSResourceId();
            }

            return networkInterface;
        }

        public PSNetworkInterface ToPsNetworkInterface(NetworkInterface nic)
        {
            var psNic = Mapper.Map<PSNetworkInterface>(nic);

            psNic.Tag = TagsConversionHelper.CreateTagHashtable(nic.Tags);

            return psNic;
        }
    }
}