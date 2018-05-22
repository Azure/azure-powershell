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

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Common.Strategies.Rm.Meta;
using Microsoft.Azure.Commands.Common.Strategies.Rm.Config;
using Microsoft.Azure.Commands.Common.Strategies.Rm;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    public static class VirtualMachineScaleSetStrategy
    {
        public static IResourceStrategy<VirtualMachineScaleSet> Strategy { get; }
            = ComputeStrategy.Create(
                provider: "virtualMachineScaleSets",
                getOperations: client => client.VirtualMachineScaleSets,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: _ => 180);

        internal static IResourceConfig<VirtualMachineScaleSet> CreateVirtualMachineScaleSetConfig(
            this IResourceConfig<ResourceGroup> resourceGroup,
            string name,
            INestedResourceConfig<Subnet, VirtualNetwork> subnet,
            INestedResourceConfig<BackendAddressPool, LoadBalancer> backendAdressPool,
            IEnumerable<INestedResourceConfig<InboundNatPool, LoadBalancer>> inboundNatPools,
            IResourceConfig<NetworkSecurityGroup> networkSecurityGroup,
            ImageAndOsType imageAndOsType,
            Credential credential,
            string vmSize,
            int instanceCount,
            VirtualMachineScaleSetIdentity identity,
            UpgradeMode? upgradeMode,
            IEnumerable<int> dataDisks,
            IList<string> zones)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: engine => new VirtualMachineScaleSet()
                {
                    Zones = zones,
                    UpgradePolicy = new UpgradePolicy
                    {
                        Mode = upgradeMode ?? UpgradeMode.Manual
                    },
                    Sku = new Azure.Management.Compute.Models.Sku()
                    {
                        Capacity = instanceCount,
                        Name = engine.GetParameterValue(Parameter.Create("vmSize", vmSize)),
                    },
                    Identity = identity,
                    VirtualMachineProfile = new VirtualMachineScaleSetVMProfile
                    {
                        OsProfile = new VirtualMachineScaleSetOSProfile
                        {
                            ComputerNamePrefix = name.Substring(0, Math.Min(name.Length, 9)),
                            WindowsConfiguration = imageAndOsType.CreateWindowsConfiguration(),
                            LinuxConfiguration = imageAndOsType.CreateLinuxConfiguration(),
                            AdminUsername = engine.GetParameterValue(credential.AdminUserName),
                            AdminPassword = engine.GetParameterValue(credential.AdminPassword),
                        },
                        StorageProfile = new VirtualMachineScaleSetStorageProfile
                        {
                            ImageReference = imageAndOsType?.Image,
                            DataDisks = DataDiskStrategy.CreateVmssDataDisks(
                                imageAndOsType?.DataDiskLuns, dataDisks)
                        },
                        NetworkProfile = new VirtualMachineScaleSetNetworkProfile
                        {
                            NetworkInterfaceConfigurations = new[]
                            {
                                new VirtualMachineScaleSetNetworkConfiguration
                                {
                                    Name = name,
                                    IpConfigurations = new []
                                    {
                                        new VirtualMachineScaleSetIPConfiguration
                                        {
                                            Name = name,
                                            LoadBalancerBackendAddressPools = new [] 
                                            {
                                                engine.GetReference(backendAdressPool)
                                            },
                                            Subnet = engine.GetReference(subnet),
                                            LoadBalancerInboundNatPools = inboundNatPools
                                                ?.Select(engine.GetReference)
                                                .ToList()
                                        }
                                    },
                                    Primary = true,
                                    NetworkSecurityGroup = engine.GetReference(networkSecurityGroup)
                                }
                            }
                        }
                    }
                });
    }
}
