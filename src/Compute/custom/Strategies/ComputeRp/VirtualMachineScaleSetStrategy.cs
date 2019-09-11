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

using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Support;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Strategies;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    public static class VirtualMachineScaleSetStrategy
    {
        public static ResourceStrategy<VirtualMachineScaleSet> Strategy { get; }
            = ComputeStrategy.Create(
                provider: "virtualMachineScaleSets",
                getOperations: client => client.GetScaleSetOperations(),
                getAsync: (o, p) => o.Get(p.ResourceGroupName, p.Name),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdate(p.ResourceGroupName, p.Name, p.Model),
                createTime: _ => 180);

        internal static ResourceConfig<VirtualMachineScaleSet> CreateVirtualMachineScaleSetConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            NestedResourceConfig<Subnet, VirtualNetwork> subnet,
            NestedResourceConfig<BackendAddressPool, LoadBalancer> backendAdressPool,
            IEnumerable<NestedResourceConfig<InboundNatPool, LoadBalancer>> inboundNatPools,
            ResourceConfig<NetworkSecurityGroup> networkSecurityGroup,
            ImageAndOsType imageAndOsType,
            string adminUsername,
            string adminPassword,
            string vmSize,
            int instanceCount,
            VirtualMachineScaleSetIdentity identity,
            bool singlePlacementGroup,
            UpgradeMode? upgradeMode,
            IEnumerable<int> dataDisks,
            IList<string> zones,
            bool ultraSSDEnabled,
            Func<IEngine, Microsoft.Azure.Management.Internal.Resources.Models.SubResource> proximityPlacementGroup)
        {
            var windowsConfig = imageAndOsType?.CreateWindowsConfiguration();
            var linuxConfig = imageAndOsType?.CreateLinuxConfiguration();
            return Strategy.CreateResourceConfig(
                 resourceGroup: resourceGroup,
                 name: name,
                 createModel: engine => new VirtualMachineScaleSet()
                 {
                     Zone = zones?.ToArray(),
                     UpgradePolicyMode = upgradeMode ?? UpgradeMode.Manual,
                     SkuCapacity = instanceCount,
                     SkuName = vmSize,
                     Identity = identity,
                     SinglePlacementGroup = singlePlacementGroup,
                     UltraSsdEnabled = ultraSSDEnabled,

                     VirtualMachineProfile = new VirtualMachineScaleSetVMProfile
                     {
                         OSProfileComputerNamePrefix = name.Substring(0, Math.Min(name.Length, 9)),
                        WindowConfigurationAdditionalUnattendContent = windowsConfig?.AdditionalUnattendContent,
                        WindowConfigurationEnableAutomaticUpdate = windowsConfig?.EnableAutomaticUpdate,
                        WindowConfigurationProvisionVMAgent = windowsConfig?.ProvisionVMAgent,
                        WindowConfigurationTimeZone = windowsConfig?.TimeZone,
                        LinuxConfigurationDisablePasswordAuthentication = linuxConfig?.DisablePasswordAuthentication,
                        LinuxConfigurationSshPublicKey = linuxConfig?.SshPublicKey,
                        OSProfileAdminUsername = adminUsername,
                        OSProfileAdminPassword = adminPassword,
                        StorageProfile = new VirtualMachineScaleSetStorageProfile
                        {
                            ImageReference = imageAndOsType?.Image,
                            DataDisk = DataDiskStrategy.CreateVmssDataDisks(
                                imageAndOsType?.DataDiskLuns, dataDisks)?.ToArray()
                        },
                        NetworkProfile = new VirtualMachineScaleSetNetworkProfile
                        {

                            NetworkInterfaceConfiguration = new[]
                            {
                                new VirtualMachineScaleSetNetworkConfiguration
                                {
                                    Name = name,
                                    IPConfiguration = new []
                                    {
                                        new VirtualMachineScaleSetIPConfiguration
                                        {
                                            Name = name,

                                            LoadBalancerBackendAddressPool = new []
                                            {
                                                new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.SubResource{Id = engine.GetReference(backendAdressPool)?.Id}
                                            },

                                            SubnetId = engine.GetReference(subnet)?.Id,
                                            LoadBalancerInboundNatPool = inboundNatPools
                                                ?.Select(p => new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.SubResource{Id = engine.GetReference(p)?.Id })?
                                                .ToArray()
                                        }
                                    },
                                    Primary = true,
                                    NetworkSecurityGroupId = engine.GetReference(networkSecurityGroup)?.Id
                                }
                            }
                        }
                    },
                    ProximityPlacementGroupId = proximityPlacementGroup(engine)?.Id,
                });
        }
    }
}
