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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    public class EtwStreamingVMCmdletBase : EtwStreamingCmdletBase
    {
        protected VirtualMachine virtualMachine;

        /// <summary>
        /// Get primary network interface of the virtual machine
        /// </summary>
        /// <returns></returns>
        protected NetworkInterface GetPrimaryNetworkInterface()
        {
            NetworkInterfaceReference networkInterfaceRef = virtualMachine.NetworkProfile.NetworkInterfaces.Count == 1 ?
                virtualMachine.NetworkProfile.NetworkInterfaces.First() :
                virtualMachine.NetworkProfile.NetworkInterfaces.FirstOrDefault(ni => ni.Primary == true);

            if (networkInterfaceRef == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.PrimaryNetworkInterfaceNotFound, virtualMachine.Name));
            }

            ResourceIdentifier niId = new ResourceIdentifier(networkInterfaceRef.Id);
            return this.NetworkInterfaceClient.Get(niId.ResourceGroupName, niId.ResourceName);
        }

        /// <summary>
        /// Get load balancer used by the network interface
        /// </summary>
        /// <param name="networkInterface">Network interface</param>
        /// <returns></returns>
        protected LoadBalancer GetLoadBalancer(NetworkInterface networkInterface)
        {
            var loadBalancers = this.LoadBalancerClient.ListAll();
            var backendAddressPools = networkInterface.IpConfigurations.Where(v => v.LoadBalancerBackendAddressPools != null).SelectMany(v => v.LoadBalancerBackendAddressPools).ToDictionary(v => v.Id);
            var loadBalancer = loadBalancers.FirstOrDefault(v => v.BackendAddressPools != null && v.BackendAddressPools.Any(u => backendAddressPools.ContainsKey(u.Id)));
            return loadBalancer;
        }

        /// <summary>
        /// Get network security group used by the network interface
        /// </summary>
        /// <param name="networkInterface">Network interface</param>
        /// <returns></returns>
        protected NetworkSecurityGroup GetNetworkSecurityGroup(NetworkInterface networkInterface)
        {
            var networkSecurityGroups = this.NetworkSecurityGroupClient.ListAll();
            return networkSecurityGroups.FirstOrDefault(u => u.NetworkInterfaces.Any(v => v.Id == networkInterface.Id));
        }

        /// <summary>
        /// Enable network security group and inbound nat rules for given ports
        /// </summary>
        /// <param name="portMap">Port map where the key is port name and the value is port number.</param>
        /// <returns></returns>
        protected async Task SetupNetworkPortsAsync(Dictionary<string, int> portMap)
        {
            NetworkInterface networkInterface = this.GetPrimaryNetworkInterface();
            NetworkSecurityGroup networkSecurityGroup = this.GetNetworkSecurityGroup(networkInterface);

            DispatchVerboseMessage(Properties.Resources.UpdatingNetworkSecurityGroup);

            Task updateNetworkSecurityGroupTask = null;
            if (networkSecurityGroup != null)
            {
                networkSecurityGroup.EnableNetworkSecurityGroupRules(portMap);
                ResourceIdentifier nsgId = new ResourceIdentifier(networkSecurityGroup.Id);
                updateNetworkSecurityGroupTask = this.NetworkSecurityGroupClient.CreateOrUpdateAsync(nsgId.ResourceGroupName, nsgId.ResourceName, networkSecurityGroup);
            }

            LoadBalancer loadBalancer = this.GetLoadBalancer(networkInterface);
            if (loadBalancer != null)
            {
                DispatchVerboseMessage(Properties.Resources.UpdatingLoadBalancer);
                EtwStreamingHelper.EnableInboundNatRules(loadBalancer, networkInterface, portMap);
                ResourceIdentifier identifier = new ResourceIdentifier(loadBalancer.Id);

                // load balancer rules must exist before network interfaces reference them
                await this.LoadBalancerClient.CreateOrUpdateAsync(identifier.ResourceGroupName, identifier.ResourceName, loadBalancer);

                DispatchVerboseMessage(Properties.Resources.UpdatingNetworkInterface);
                ResourceIdentifier niId = new ResourceIdentifier(networkInterface.Id);
                await this.NetworkInterfaceClient.CreateOrUpdateAsync(niId.ResourceGroupName, niId.ResourceName, networkInterface);
            }

            if (updateNetworkSecurityGroupTask != null)
            {
                await updateNetworkSecurityGroupTask;
            }
        }

        /// <summary>
        /// Disable network security group and inbound nat rules for given ports
        /// </summary>
        /// <param name="portMap">Port map where the key is port name and the value is port number.</param>
        protected async Task CleanupNetworkPortsAsync(Dictionary<string, int> portMap, IEnumerable<ComputeExtension> extensions)
        {
            NetworkInterface networkInterface = this.GetPrimaryNetworkInterface();

            LoadBalancer loadBalancer = this.GetLoadBalancer(networkInterface);
            if (loadBalancer != null)
            {
                EtwStreamingHelper.DisableInboundNatRules(loadBalancer, networkInterface, portMap);

                DispatchVerboseMessage(Properties.Resources.UpdatingNetworkInterface);

                ResourceIdentifier niId = new ResourceIdentifier(networkInterface.Id);
                await this.NetworkInterfaceClient.CreateOrUpdateAsync(niId.ResourceGroupName, niId.ResourceName, networkInterface);

                DispatchVerboseMessage(Properties.Resources.UpdatingLoadBalancer);

                ResourceIdentifier identifier = new ResourceIdentifier(loadBalancer.Id);
                await this.LoadBalancerClient.CreateOrUpdateAsync(identifier.ResourceGroupName, identifier.ResourceName, loadBalancer);
            }

            DispatchVerboseMessage(Properties.Resources.UpdatingNetworkSecurityGroup);

            NetworkSecurityGroup networkSecurityGroup = this.GetNetworkSecurityGroup(networkInterface);
            if (networkSecurityGroup != null && CanRemoveNetworkSecurityGroupRules(networkSecurityGroup, networkInterface, extensions))
            {
                networkSecurityGroup.DisableNetworkSecurityGroupRules(portMap);
                ResourceIdentifier identifier = new ResourceIdentifier(networkSecurityGroup.Id);
                await this.NetworkSecurityGroupClient.CreateOrUpdateAsync(identifier.ResourceGroupName, identifier.ResourceName, networkSecurityGroup);
            }
        }

        /// <summary>
        /// Check if any other virtual machines rely on given security rules by checking if the related extensions are installed
        /// </summary>
        /// <param name="networkSecurityGroup">Network security group</param>
        /// <param name="networkInterface">Network interface</param>
        /// <param name="extensions">Extensions which uses given security rules</param>
        /// <returns></returns>
        protected bool CanRemoveNetworkSecurityGroupRules(NetworkSecurityGroup networkSecurityGroup, NetworkInterface networkInterface, IEnumerable<ComputeExtension> extensions)
        {
            if (networkSecurityGroup == null ||
                networkSecurityGroup.NetworkInterfaces == null ||
                (networkSecurityGroup.Subnets != null && networkSecurityGroup.Subnets.Any()))
            {
                return false;
            }

            string[] distinctNicIds = networkSecurityGroup.NetworkInterfaces
                .Select(v => v.Id)
                .Where(v => !v.Equals(networkInterface.Id, StringComparison.OrdinalIgnoreCase))
                .ToArray();

            List<string> vmIds = new List<string>();
            foreach (var nicId in distinctNicIds)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(nicId);
                NetworkInterface ni = NetworkInterfaceClient.Get(identifier.ResourceGroupName, identifier.ResourceName);

                if (ni.VirtualMachine != null && ni.VirtualMachine.Id != null)
                {
                    string virtualMachineId = ni.VirtualMachine.Id;
                    if (vmIds.Any(v => v.Equals(virtualMachineId, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }

                    vmIds.Add(virtualMachineId);

                    ResourceIdentifier vmIdentifier = new ResourceIdentifier(virtualMachineId);
                    var response = this.VirtualMachineClient.GetWithHttpMessagesAsync(vmIdentifier.ResourceGroupName, vmIdentifier.ResourceName).GetAwaiter().GetResult();

                    if (response.Body != null &&
                        response.Body.Resources != null &&
                        response.Body.Resources.Any(extensions.Includes))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
