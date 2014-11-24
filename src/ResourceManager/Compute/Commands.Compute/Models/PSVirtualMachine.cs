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
        public PSVirtualMachine()
        {
        }

        public string ResourceGroupName { get; set; }

        public string Name { get; set; }

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
        public Uri AvailabilitySetId { get; set; }
        public string ProvisioningState { get; set; }

        public OSProfile OSConfiguration
        {
            get
            {
                return this.OSProfile;
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

        public OSDisk OSDisk
        {
            get
            {
                if (this.StorageProfile != null && this.StorageProfile.OSDisk != null)
                {
                    return this.StorageProfile.OSDisk;
                }

                return null;
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
}
