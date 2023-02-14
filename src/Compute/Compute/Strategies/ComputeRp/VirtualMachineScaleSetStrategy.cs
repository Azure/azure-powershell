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
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Common.Strategies;
using CM = Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    public static class VirtualMachineScaleSetStrategy
    {
        private const string flexibleOModeNetworkAPIVersion = "2020-11-01";
        public static ResourceStrategy<VirtualMachineScaleSet> Strategy { get; }
            = ComputeStrategy.Create(
                provider: "virtualMachineScaleSets",
                getOperations: client => client.VirtualMachineScaleSets,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateWithCustomHeaderAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
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
            Func<IEngine, CM.SubResource> proximityPlacementGroup,
            Func<IEngine, CM.SubResource> hostGroup,
            string priority,
            string evictionPolicy,
            double? maxPrice,
            string[] scaleInPolicy,
            bool doNotRunExtensionsOnOverprovisionedVMs,
            bool encryptionAtHost,
            int? platformFaultDomainCount,
            string edgeZone,
            string orchestrationMode,
            string capacityReservationId,
            string userData,
            string imageReferenceId,
            Dictionary<string, List<string>> auxAuthHeader,
            string diskControllerType
            )
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: engine => {
                    var vmss = new VirtualMachineScaleSet
                    {
                        Zones = zones,
                        ExtendedLocation = edgeZone == null ? null : new CM.ExtendedLocation(edgeZone, CM.ExtendedLocationTypes.EdgeZone),
                        UpgradePolicy = new UpgradePolicy
                        {
                            Mode = upgradeMode ?? UpgradeMode.Manual
                        },
                        Sku = new Azure.Management.Compute.Models.Sku()
                        {
                            Capacity = instanceCount,
                            Name = vmSize,
                        },
                        Identity = identity,
                        SinglePlacementGroup = singlePlacementGroup,
                        AdditionalCapabilities = ultraSSDEnabled ? new AdditionalCapabilities(true) : null,
                        PlatformFaultDomainCount = platformFaultDomainCount,
                        VirtualMachineProfile = new VirtualMachineScaleSetVMProfile
                        {
                            SecurityProfile = (encryptionAtHost == true) ? new SecurityProfile(encryptionAtHost: encryptionAtHost) : null,
                            OsProfile = new VirtualMachineScaleSetOSProfile
                            {
                                ComputerNamePrefix = name.Substring(0, Math.Min(name.Length, 9)),
                                WindowsConfiguration = imageAndOsType.CreateWindowsConfiguration(),
                                LinuxConfiguration = imageAndOsType.CreateLinuxConfiguration(),
                                AdminUsername = adminUsername,
                                AdminPassword = adminPassword,
                            },
                            StorageProfile = new VirtualMachineScaleSetStorageProfile
                            {
                                ImageReference = (imageReferenceId == null) ? imageAndOsType?.Image : (imageReferenceId.ToLower().StartsWith("/communitygalleries/") ? new ImageReference
                                {
                                    CommunityGalleryImageId = imageReferenceId
                                } : new ImageReference
                                {
                                    Id = imageReferenceId
                                }),
                                DataDisks = DataDiskStrategy.CreateVmssDataDisks(
                                    imageAndOsType?.DataDiskLuns, dataDisks),
                                DiskControllerType = diskControllerType
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
                            },
                            Priority = priority,
                            EvictionPolicy = evictionPolicy,
                            BillingProfile = (maxPrice == null) ? null : new BillingProfile(maxPrice),
                            CapacityReservation = (capacityReservationId == null) ? null : new CapacityReservationProfile
                            {
                                CapacityReservationGroup = new Microsoft.Azure.Management.Compute.Models.SubResource(capacityReservationId)
                            },
                            UserData = userData
                        },
                        ProximityPlacementGroup = proximityPlacementGroup(engine),
                        HostGroup = hostGroup(engine),
                        ScaleInPolicy = (scaleInPolicy == null) ? null : new ScaleInPolicy
                        {
                            Rules = scaleInPolicy
                        },
                        DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs ? true : (bool?)null,
                        OrchestrationMode = orchestrationMode
                    };
                    if (auxAuthHeader != null)
                    {
                        vmss.SetAuxAuthHeader(auxAuthHeader);
                    }
                    return vmss;
                });

        internal static ResourceConfig<VirtualMachineScaleSet> CreateVirtualMachineScaleSetConfigOrchestrationModeFlexible(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            NestedResourceConfig<Subnet, VirtualNetwork> subnet,
            NestedResourceConfig<BackendAddressPool, LoadBalancer> backendAdressPool,
            ResourceConfig<NetworkSecurityGroup> networkSecurityGroup,
            ImageAndOsType imageAndOsType,
            string adminUsername,
            string adminPassword,
            string vmSize,
            int instanceCount,
            VirtualMachineScaleSetIdentity identity,
            bool singlePlacementGroup,
            IEnumerable<int> dataDisks,
            IList<string> zones,
            bool ultraSSDEnabled,
            Func<IEngine, CM.SubResource> proximityPlacementGroup,
            Func<IEngine, CM.SubResource> hostGroup,
            string priority,
            string evictionPolicy,
            double? maxPrice,
            string[] scaleInPolicy,
            bool doNotRunExtensionsOnOverprovisionedVMs,
            bool encryptionAtHost,
            int? platformFaultDomainCount,
            string edgeZone,
            string orchestrationMode,
            string capacityReservationId
            )
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: engine => new VirtualMachineScaleSet()
                {
                    Zones = zones,
                    ExtendedLocation = edgeZone == null ? null : new CM.ExtendedLocation(edgeZone, CM.ExtendedLocationTypes.EdgeZone),
                    Sku = new Azure.Management.Compute.Models.Sku()
                    {
                        Capacity = instanceCount,
                        Name = vmSize,
                    },
                    Identity = identity,
                    SinglePlacementGroup = singlePlacementGroup,
                    AdditionalCapabilities = ultraSSDEnabled ? new AdditionalCapabilities(true) : null,
                    PlatformFaultDomainCount = platformFaultDomainCount,
                    VirtualMachineProfile = new VirtualMachineScaleSetVMProfile
                    {
                        SecurityProfile = (encryptionAtHost == true) ? new SecurityProfile(encryptionAtHost: encryptionAtHost) : null,
                        OsProfile = new VirtualMachineScaleSetOSProfile
                        {
                            ComputerNamePrefix = name.Substring(0, Math.Min(name.Length, 9)),
                            WindowsConfiguration = imageAndOsType.CreateWindowsConfiguration(),
                            LinuxConfiguration = imageAndOsType.CreateLinuxConfiguration(),
                            AdminUsername = adminUsername,
                            AdminPassword = adminPassword,
                        },
                        StorageProfile = new VirtualMachineScaleSetStorageProfile
                        {
                            ImageReference = imageAndOsType?.Image,
                            DataDisks = DataDiskStrategy.CreateVmssDataDisks(
                                imageAndOsType?.DataDiskLuns, dataDisks)
                        },
                        NetworkProfile = new VirtualMachineScaleSetNetworkProfile
                        {
                            NetworkApiVersion = flexibleOModeNetworkAPIVersion,
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
                                            Subnet = engine.GetReference(subnet)
                                        }
                                    },
                                    Primary = true,
                                    NetworkSecurityGroup = engine.GetReference(networkSecurityGroup)
                                }
                            }
                        },
                        Priority = priority,
                        EvictionPolicy = evictionPolicy,
                        BillingProfile = (maxPrice == null) ? null : new BillingProfile(maxPrice),
                        CapacityReservation = (capacityReservationId == null) ? null : new CapacityReservationProfile
                        {
                            CapacityReservationGroup = new Microsoft.Azure.Management.Compute.Models.SubResource(capacityReservationId)
                        }
                    },
                    ProximityPlacementGroup = proximityPlacementGroup(engine),
                    HostGroup = hostGroup(engine),
                    ScaleInPolicy = (scaleInPolicy == null) ? null : new ScaleInPolicy
                    {
                        Rules = scaleInPolicy
                    },
                    DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs ? true : (bool?)null,
                    OrchestrationMode = orchestrationMode
                });
    }
}
