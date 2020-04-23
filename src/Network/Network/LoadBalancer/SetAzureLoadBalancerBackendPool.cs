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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPool"), OutputType(typeof(PSBackendAddressPool))]
    public partial class SetAzureLoadBalancerBackendPool : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the load balancer.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string LoadBalancerName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the backend pool.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string BackendAddressPoolName { get; set; }

        [Alias("BackendAddressPool")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The backend address pool to set.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public PSBackendAddressPool PsBackendAddressPool { get; set; }


        public override void Execute()
        {
            base.Execute();

            var backendAddressPoolModel = NetworkResourceManagerProfile.Mapper.Map<BackendAddressPool>(PsBackendAddressPool);

            backendAddressPoolModel.LoadBalancerBackendAddresses.Clear();

            foreach (var psBackendAddress in PsBackendAddressPool.LoadBalancerBackendAddresses)
            {
                var backendAddress = ToLoadBalancerBackendAddress(psBackendAddress);
                backendAddressPoolModel.LoadBalancerBackendAddresses.Add(backendAddress);
            }

            var loadBalancerBackendAddressPool = this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.CreateOrUpdate(this.ResourceGroupName, this.LoadBalancerName, this.BackendAddressPoolName, backendAddressPoolModel);

            var loadBalancerBackendAddressPoolModel = NetworkResourceManagerProfile.Mapper.Map<PSBackendAddressPool>(loadBalancerBackendAddressPool);

            WriteObject(loadBalancerBackendAddressPoolModel);
        }

        private LoadBalancerBackendAddress ToLoadBalancerBackendAddress(PSLoadBalancerBackendAddress pSLoadBalancerBackendAddress)
        {
            NetworkInterfaceIPConfiguration networkInterfaceIpConfig = null;
            Microsoft.Azure.Management.Network.Models.VirtualNetwork virtualNetworkConfig = null;

            if (pSLoadBalancerBackendAddress.BackendIpConfigurations != null)
            {
                networkInterfaceIpConfig = new NetworkInterfaceIPConfiguration(pSLoadBalancerBackendAddress.BackendIpConfigurations.Id);
            }
            if (pSLoadBalancerBackendAddress.VirtualNetwork != null)
            {
                virtualNetworkConfig = new Microsoft.Azure.Management.Network.Models.VirtualNetwork(pSLoadBalancerBackendAddress.VirtualNetwork.Id);
            }

            var backendAddress = new LoadBalancerBackendAddress();
            backendAddress.NetworkInterfaceIPConfiguration = networkInterfaceIpConfig;
            backendAddress.Name = pSLoadBalancerBackendAddress.Name;
            backendAddress.IpAddress = pSLoadBalancerBackendAddress.IpAddress;
            backendAddress.VirtualNetwork = virtualNetworkConfig;

            return backendAddress;
        }
    }
}
