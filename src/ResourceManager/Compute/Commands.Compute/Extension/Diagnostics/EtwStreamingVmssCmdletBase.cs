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
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    public class EtwStreamingVmssCmdletBase : EtwStreamingCmdletBase
    {
        private const string LoadBalancerResourceType = "loadBalancers";

        protected VirtualMachineScaleSet virtualMachineScaleSet;

        /// <summary>
        /// Get network security groups used by the VM scale set
        /// </summary>
        /// <returns></returns>
        protected async Task<NetworkSecurityGroup[]> GetNetworkSecurityGroupsAsync()
        {
            string[] subnetIds = virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.SelectMany(v => v.IpConfigurations.Select(u => u.Subnet.Id)).ToArray();

            Subnet[] subnets = await Task.WhenAll(subnetIds.Select(id =>
            {
                var subnetResourceIdentifier = new ResourceIdentifier(id);
                var parentIdentifier = subnetResourceIdentifier.GetParentResourceIdentifier();
                return this.SubnetClient.GetAsync(subnetResourceIdentifier.ResourceGroupName, parentIdentifier.ResourceName, subnetResourceIdentifier.ResourceName);
            }));

            return await Task.WhenAll(subnets.Where(v => v.NetworkSecurityGroup != null).Select(v => v.NetworkSecurityGroup.Id).Distinct().Select(v =>
            {
                var nsgResourceIdentifier = new ResourceIdentifier(v);
                return this.NetworkSecurityGroupClient.GetAsync(nsgResourceIdentifier.ResourceGroupName, nsgResourceIdentifier.ResourceName);
            }));
        }

        /// <summary>
        /// Get load balancer that is used by the VM scale set
        /// </summary>
        /// <returns></returns>
        protected async Task<LoadBalancer[]> GetLoadBalancersAsync()
        {
            string[] loadBalancerIds = virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations
                    .SelectMany(ip => ip.IpConfigurations.SelectMany(c => c.LoadBalancerBackendAddressPools))
                    .Select(backendAddressPool => new ResourceIdentifier(backendAddressPool.Id).GetParentResourceIdentifier())
                    .Where(id => string.Equals(ResourceIdentifier.GetTypeFromResourceType(id.ResourceType), LoadBalancerResourceType, StringComparison.OrdinalIgnoreCase))
                    .Select(v => v.ToString())
                    .Distinct()
                    .ToArray();

            return await Task.WhenAll(loadBalancerIds.Select((loadBalancerId) =>
            {
                var rid = new ResourceIdentifier(loadBalancerId);
                return this.LoadBalancerClient.GetAsync(rid.ResourceGroupName, rid.ResourceName);
            }));
        }

        /// <summary>
        /// Enable network security groups and NAT inbound pools
        /// </summary>
        /// <param name="portMap">Port map where the key is port name and the value is port number.</param>
        /// <returns></returns>
        protected async Task SetupNetworkPortsAsync(Dictionary<string, int> portMap)
        {
            NetworkSecurityGroup[] networkSecurityGroups = await this.GetNetworkSecurityGroupsAsync();
            foreach (var nsg in networkSecurityGroups)
            {
                nsg.EnableNetworkSecurityGroupRules(portMap);
            }

            DispatchVerboseMessage(Properties.Resources.UpdatingNetworkSecurityGroup);
            Task[] updateNetworkSecurityGroupTasks = networkSecurityGroups.Select(nsg =>
            {
                var rid = new ResourceIdentifier(nsg.Id);
                return this.NetworkSecurityGroupClient.CreateOrUpdateAsync(rid.ResourceGroupName, rid.ResourceName, nsg);
            }).ToArray();

            LoadBalancer[] loadBalancers = await this.GetLoadBalancersAsync();

            foreach (var loadBalancer in loadBalancers)
            {
                EtwStreamingHelper.EnableInboundNatPools(loadBalancer, this.virtualMachineScaleSet, portMap);
            }

            this.DispatchVerboseMessage(Properties.Resources.UpdatingLoadBalancer);
            await Task.WhenAll(loadBalancers.Select(loadBalancer =>
            {
                // Remove inbound nat rules property when updating load balancer
                loadBalancer.InboundNatRules = null;

                ResourceIdentifier rid = new ResourceIdentifier(loadBalancer.Id);
                return this.LoadBalancerClient.CreateOrUpdateAsync(rid.ResourceGroupName, rid.ResourceName, loadBalancer);
            }));

            this.DispatchVerboseMessage(Properties.Resources.UpdatingNetworkInterface);
            ResourceIdentifier scaleSetRid = new ResourceIdentifier(this.virtualMachineScaleSet.Id);

            await this.VirtualMachineScaleSetClient.CreateOrUpdateWithHttpMessagesAsync(scaleSetRid.ResourceGroupName, scaleSetRid.ResourceName, this.virtualMachineScaleSet);
            await Task.WhenAll(updateNetworkSecurityGroupTasks);
        }

        /// <summary>
        /// Disable network security groups and NAT inbound pools
        /// </summary>
        /// <param name="portMap">Port map where the key is port name and the value is port number.</param>
        /// <returns></returns>
        protected async Task CleanupNetworkPortsAsync(Dictionary<string, int> portMap)
        {
            LoadBalancer[] loadBalancers = await this.GetLoadBalancersAsync();

            foreach (var loadBalancer in loadBalancers)
            {
                EtwStreamingHelper.DisableInboundNatPools(loadBalancer, this.virtualMachineScaleSet, portMap);
            }

            DispatchVerboseMessage(Properties.Resources.UpdatingNetworkInterface);
            ResourceIdentifier scaleSetRid = new ResourceIdentifier(this.virtualMachineScaleSet.Id);
            await this.VirtualMachineScaleSetClient.CreateOrUpdateWithHttpMessagesAsync(scaleSetRid.ResourceGroupName, scaleSetRid.ResourceName, this.virtualMachineScaleSet);

            DispatchVerboseMessage(Properties.Resources.UpdatingLoadBalancer);
            IEnumerable<Task> tasks = loadBalancers.Select(loadBalancer =>
            {
                // Remove inbound nat rules property when updating load balancer
                loadBalancer.InboundNatRules = null;

                ResourceIdentifier rid = new ResourceIdentifier(loadBalancer.Id);
                return this.LoadBalancerClient.CreateOrUpdateAsync(rid.ResourceGroupName, rid.ResourceName, loadBalancer);
            }).ToArray();

            NetworkSecurityGroup[] networkSecurityGroups = await this.GetNetworkSecurityGroupsAsync();
            foreach (var nsg in networkSecurityGroups)
            {
                nsg.DisableNetworkSecurityGroupRules(portMap);
            }

            DispatchVerboseMessage(Properties.Resources.UpdatingNetworkSecurityGroup);
            IEnumerable<Task> updateNetworkSecurityGroupTasks = networkSecurityGroups.Select(nsg =>
            {
                var rid = new ResourceIdentifier(nsg.Id);
                return this.NetworkSecurityGroupClient.CreateOrUpdateAsync(rid.ResourceGroupName, rid.ResourceName, nsg);
            }).ToArray();

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception)
            {
                if (this.virtualMachineScaleSet.UpgradePolicy.Mode != UpgradeMode.Automatic)
                {
                    // If upgrade policy is manual, it fails to remote NAT inbound pools from load balancer because virtual machines still keep the reference to NAT inbound rules.
                    // User need to trigger manual upgrade to latest model
                    DispatchWarningMessage(Properties.Resources.NeedManualUpgradeScaleSetVMsToCleanup);
                }
                else
                {
                    throw;
                }
            }

            await Task.WhenAll(updateNetworkSecurityGroupTasks);
        }
    }
}
