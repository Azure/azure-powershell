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
using Microsoft.Azure.Commands.Common.Strategies;
using System.Collections.Generic;
using System;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Support;
using System.Linq;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Strategies;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class VirtualMachineStrategy
    {
        public static ResourceStrategy<VirtualMachine> Strategy { get; }
            = ComputeStrategy.Create(
                provider: "virtualMachines",
                getOperations: client => client.GetVMOperations(),
                getAsync: (o, p) => o.Get(p.ResourceGroupName, p.Name, null),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdate(p.ResourceGroupName, p.Name, p.Model),
                createTime: c => 240);

        public static ResourceConfig<VirtualMachine> CreateVirtualMachineConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            ResourceConfig<NetworkInterface> networkInterface,
            ImageAndOsType imageAndOsType,
            string adminUsername,
            string adminPassword,
            string size,
            ResourceConfig<AvailabilitySet> availabilitySet,
            VirtualMachineIdentity identity,
            IEnumerable<int> dataDisks,
            IList<string> zones,
            bool ultraSSDEnabled,
            Func<IEngine, Microsoft.Azure.Management.Internal.Resources.Models.SubResource> proximityPlacementGroup)
        {
              var windowsConfig = imageAndOsType.CreateWindowsConfiguration();
              var linuxConfig = imageAndOsType.CreateLinuxConfiguration();
              return Strategy.CreateResourceConfig(
              resourceGroup: resourceGroup,
              name: name,
              createModel: engine => new VirtualMachine
              {
              OSProfileComputerName = name,
              WindowConfigurationAdditionalUnattendContent = windowsConfig?.AdditionalUnattendContent,
              WindowConfigurationEnableAutomaticUpdate = windowsConfig?.EnableAutomaticUpdate,
              WindowConfigurationProvisionVMAgent = windowsConfig?.ProvisionVMAgent,
              WindowConfigurationTimeZone = windowsConfig?.TimeZone,
              WinRmListener = windowsConfig?.WinRmListener,
              LinuxConfigurationDisablePasswordAuthentication = linuxConfig?.DisablePasswordAuthentication,
              LinuxConfigurationSshPublicKey = linuxConfig?.SshPublicKey,
              
              OSProfileAdminUsername = adminUsername,
              OSProfileAdminPassword = adminPassword,
              Identity = identity,
              NetworkProfileNetworkInterface = new[] { engine.GetReference(networkInterface) },
              Size = size,
              ImageReferenceId = imageAndOsType?.Image?.Id,
              ImageReferenceOffer = imageAndOsType?.Image?.Offer,
              ImageReferencePublisher = imageAndOsType?.Image?.Publisher,
              ImageReferenceSku = imageAndOsType?.Image?.Sku,
              ImageReferenceVersion = imageAndOsType?.Image?.Version,
              StorageProfileDataDisk = DataDiskStrategy.CreateDataDisks(
                      imageAndOsType?.DataDiskLuns, dataDisks)?.ToArray(),
              AvailabilitySetId = engine.GetReference(availabilitySet)?.Id,
              Zone = zones?.ToArray(),
              UltraSsdEnabled = ultraSSDEnabled,
              ProximityPlacementGroupId = proximityPlacementGroup(engine)?.Id
          });
        }
        public static ResourceConfig<VirtualMachine> CreateVirtualMachineConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            ResourceConfig<NetworkInterface> networkInterface,
            OperatingSystemTypes osType,
            ResourceConfig<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.Disk> disk,
            string size,
            ResourceConfig<AvailabilitySet> availabilitySet,
            VirtualMachineIdentity identity,
            IEnumerable<int> dataDisks,
            IList<string> zones,
            bool ultraSSDEnabled,
            Func<IEngine, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.SubResource> proximityPlacementGroup)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: engine => new VirtualMachine
                {
                    NetworkProfileNetworkInterface = new[]
                    {
                            engine.GetReference(networkInterface)
                    },
                    Size = size,
                    StorageProfileDataDisk = DataDiskStrategy.CreateDataDisks(null, dataDisks)?.ToArray(),
                    StorageProfileOSDisk = new OSDisk
                    {
                        Name = disk.Name,
                        CreateOption = DiskCreateOptionTypes.Attach,
                        OSType = osType,
                        ManagedDisk = engine.GetReference(disk, ultraSSDEnabled ? StorageAccountTypes.UltraSsdLrs : StorageAccountTypes.PremiumLrs),
                    },
                    Identity = identity,
                    AvailabilitySetId = engine.GetReference(availabilitySet)?.Id,
                    Zone = zones?.ToArray(),
                    UltraSsdEnabled = ultraSSDEnabled,
                    ProximityPlacementGroupId = proximityPlacementGroup(engine)?.Id,
                });
    }
}
