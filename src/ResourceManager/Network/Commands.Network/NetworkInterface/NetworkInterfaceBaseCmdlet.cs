
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
using System.Collections.Generic;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class NetworkInterfaceBaseCmdlet : NetworkBaseCmdlet
    {
        public INetworkInterfacesOperations NetworkInterfaceClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkInterfaces;
            }
        }

        public bool IsNetworkInterfacePresent(string resourceGroupName, string name)
        {
            try
            {
                GetNetworkInterface(resourceGroupName, name);
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

        public PSNetworkInterface GetNetworkInterface(string resourceGroupName, string name, string expandResource = null)
        {
            var nic = this.NetworkInterfaceClient.Get(resourceGroupName, name, expandResource);

            var psNetworkInterface = Mapper.Map<PSNetworkInterface>(nic);
            psNetworkInterface.ResourceGroupName = resourceGroupName;
            psNetworkInterface.Tag =
                TagsConversionHelper.CreateTagHashtable(nic.Tags);

            return psNetworkInterface;
        }

        public PSNetworkInterface GetScaleSetNetworkInterface(string resourceGroupName, string scaleSetName, string vmIndex, string name, string expandResource = null)
        {
            var nic = this.NetworkInterfaceClient.GetVirtualMachineScaleSetNetworkInterface(resourceGroupName, scaleSetName, vmIndex, name, expandResource);

            var psNetworkInterface = Mapper.Map<PSNetworkInterface>(nic);
            psNetworkInterface.ResourceGroupName = resourceGroupName;
            psNetworkInterface.Tag =
                TagsConversionHelper.CreateTagHashtable(nic.Tags);

            return psNetworkInterface;
        }

        public PSNetworkInterface ToPsNetworkInterface(NetworkInterface nic)
        {
            var psNic = Mapper.Map<PSNetworkInterface>(nic);

            psNic.Tag = TagsConversionHelper.CreateTagHashtable(nic.Tags);

            foreach (var ipconfig in psNic.IpConfigurations)
            {
                ipconfig.LoadBalancerBackendAddressPools = ipconfig.LoadBalancerBackendAddressPools ?? new List<PSBackendAddressPool>();
                ipconfig.LoadBalancerInboundNatRules = ipconfig.LoadBalancerInboundNatRules ?? new List<PSInboundNatRule>();
                ipconfig.ApplicationGatewayBackendAddressPools = ipconfig.ApplicationGatewayBackendAddressPools ?? new List<PSApplicationGatewayBackendAddressPool>();
            }

            return psNic;
        }
    }
}