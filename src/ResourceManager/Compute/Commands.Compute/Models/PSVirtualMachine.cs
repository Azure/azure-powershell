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

        public string Location { get; set; }

        public string VMSize
        {
            get
            {
                if (this.HardwareProfile != null)
                {
                    return this.HardwareProfile.VirtualMachineSize;
                }

                return null;
            }
        }

        public IDictionary<string, string> Tags { get; set; }
        public string AvailabilitySetId { get; set; }
        public string ProvisioningState { get; set; }

        public string OSConfiguration
        {
            get
            {
                if (this.StorageProfile != null && this.StorageProfile.OSDisk != null)
                {
                    return this.StorageProfile.OSDisk.OperatingSystemType;
                }

                return null;
            }
        }

        public string SourceImageId
        {
            get
            {
                if (this.StorageProfile != null && this.StorageProfile.SourceImage != null)
                {
                    return this.StorageProfile.SourceImage.ReferenceUri;
                }

                return null;
            }
        }

        public Uri DestinationVHDsContainer
        {
            get
            {
                if (this.StorageProfile != null && this.StorageProfile.DestinationVhdsContainer != null)
                {
                    return this.StorageProfile.DestinationVhdsContainer;
                }

                return null;
            }
        }

        public string OSDisk
        {
            get
            {
                if (this.StorageProfile != null && this.StorageProfile.OSDisk != null)
                {
                    return this.StorageProfile.OSDisk.Name;
                }

                return string.Empty;
            }
        }

        public IList<DataDisk> DataDisks
        {
            get
            {
                if (this.StorageProfile != null && this.StorageProfile.DataDisks != null)
                {
                    return this.StorageProfile.DataDisks;
                }

                return null;
            }
        }

        public IList<string> NetworkInterfaces
        {
            get
            {
                if (this.NetworkProfile != null && this.NetworkProfile.NetworkInterfaces != null)
                {
                    return this.NetworkProfile.NetworkInterfaces.Select(t => t.ReferenceUri).ToList();
                }

                return null;
            }
        }

        public VirtualMachineSubResources Resources { get; set; }
        public VirtualMachineInstanceView Status { get; set; }

        public HardwareProfile HardwareProfile { get; set; }

        public NetworkProfile NetworkProfile { get; set; }
        
        public OSProfile OSProfile { get; set; }

        public StorageProfile StorageProfile { get; set; }
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
                Location = virtualMachine == null ? null : virtualMachine.Location,
                ProvisioningState = virtualMachine.VirtualMachineProperties.ProvisioningState,
                Tags = virtualMachine.Tags,
                Resources = virtualMachine.VirtualMachineSubResources,
                Status = null, // TODO: VM response does not return Status info yet
            };

            var asetRef = virtualMachine.VirtualMachineProperties.AvailabilitySetReference;
            if (asetRef != null)
            {
                result.AvailabilitySetId = virtualMachine.VirtualMachineProperties.AvailabilitySetReference.ReferenceUri;
            }

            result.OSProfile = virtualMachine.VirtualMachineProperties.OSProfile;
            result.HardwareProfile = virtualMachine.VirtualMachineProperties.HardwareProfile;
            result.StorageProfile = virtualMachine.VirtualMachineProperties.StorageProfile;
            result.NetworkProfile = virtualMachine.VirtualMachineProperties.NetworkProfile;

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
