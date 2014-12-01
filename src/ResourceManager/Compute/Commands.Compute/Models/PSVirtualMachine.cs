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

using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSVirtualMachine
    {
        public string ResourceGroupName { get; set; }

        public string Name { get; set; }

        public string VMSize
        {
            get
            {
                if (this.hardwareProfile != null)
                {
                    return this.hardwareProfile.VirtualMachineSize;
                }

                return null;
            }
        }

        public IDictionary<string, string> Tags { get; set; }
        public Uri AvailabilitySetId { get; set; }
        public string ProvisioningState { get; set; }

        public OSProfile OSConfiguration
        {
            get
            {
                return this.osProfile;
            }
        }

        public string SourceImageId
        {
            get
            {
                if (this.storageProfile != null && this.storageProfile.SourceImage != null)
                {
                    return this.storageProfile.SourceImage.ReferenceUri;
                }

                return null;
            }
        }

        public Uri DestinationVHDsContainer
        {
            get
            {
                if (this.storageProfile != null && this.storageProfile.DestinationVhdsContainer != null)
                {
                    return this.storageProfile.DestinationVhdsContainer;
                }

                return null;
            }
        }

        public OSDisk OSDisk
        {
            get
            {
                if (this.storageProfile != null && this.storageProfile.OSDisk != null)
                {
                    return this.storageProfile.OSDisk;
                }

                return null;
            }
        }

        public IList<DataDisk> DataDisks
        {
            get
            {
                if (this.storageProfile != null && this.storageProfile.DataDisks != null)
                {
                    return this.storageProfile.DataDisks;
                }

                return null;
            }
        }

        public IList<string> NetworkInterfaces
        {
            get
            {
                if (this.networkProfile != null && this.networkProfile.NetworkInterfaces != null)
                {
                    return this.networkProfile.NetworkInterfaces.Select(t => t.ReferenceUri).ToList();
                }

                return null;
            }
        }

        public VirtualMachineSubResources Resources { get; set; }
        public VirtualMachineInstanceView Status { get; set; }

        private HardwareProfile hardwareProfile { get; set; }
        
        public void SetHardwareProfile(HardwareProfile hardwareProfile)
        {
            this.hardwareProfile = hardwareProfile;
        }

        public HardwareProfile GetHardwareProfile()
        {
            return this.hardwareProfile;
        }

        private NetworkProfile networkProfile { get; set; }
        
        public void SetNetworkProfile(NetworkProfile networkProfile)
        {
            this.networkProfile = networkProfile;
        }

        public NetworkProfile GetNetworkProfile()
        {
            return this.networkProfile;
        }

        private OSProfile osProfile { get; set; }

        public void SetOSProfile(OSProfile osProfile)
        {
            this.osProfile = osProfile;
        }

        public OSProfile GetOSProfile()
        {
            return this.osProfile;
        }

        private StorageProfile storageProfile { get; set; }

        public void SetStorageProfile(StorageProfile storageProfile)
        {
            this.storageProfile = storageProfile;
        }

        public StorageProfile GetStorageProfile()
        {
            return this.storageProfile;
        }
    }

    public static class PSVirtualMachineConversions
    {
        public static PSVirtualMachine ToPSVirtualMachine(this VirtualMachineGetResponse response, string rgName = null)
        {
            if (response == null)
            {
                return null;
            }

            return response.VirtualMachine.ToPSVirtualMachine(rgName);
        }

        public static PSVirtualMachine ToPSVirtualMachine(this VirtualMachine virtualMachine, string rgName = null)
        {
            PSVirtualMachine result = new PSVirtualMachine
            {
                ResourceGroupName = rgName,
                Name = virtualMachine == null ? null : virtualMachine.Name,
                ProvisioningState = virtualMachine.VirtualMachineProperties.ProvisioningState,
                Tags = virtualMachine.Tags,
                Resources = virtualMachine.VirtualMachineSubResources,
                Status = null, // TODO: VM response does not return Status info yet
            };

            result.SetOSProfile(virtualMachine.VirtualMachineProperties.OSProfile);
            result.SetHardwareProfile(virtualMachine.VirtualMachineProperties.HardwareProfile);
            result.SetStorageProfile(virtualMachine.VirtualMachineProperties.StorageProfile);
            result.SetNetworkProfile(virtualMachine.VirtualMachineProperties.NetworkProfile);

            return result;
        }

        public static List<PSVirtualMachine> ToPSVirtualMachineList(this VirtualMachineListResponse response, string rgName = null)
        {
            List<PSVirtualMachine> results = new List<PSVirtualMachine>();

            if (response != null && response.VirtualMachines != null)
            {
                foreach (var item in response.VirtualMachines)
                {
                    var vm = item.ToPSVirtualMachine(rgName);
                    results.Add(vm);
                }
            }

            return results;
        }
    }
}
