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

using Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption;
using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models
{
    class PSVmssDiskEncryptionStatusContext
    {
        public string ResourceGroupName { get; set; }
        public string VmScaleSetName { get; set; }
        public AzureVmssDiskEncryptionExtensionPublicSettings EncryptionSettings { get; set; }
        public IList<VirtualMachineStatusCodeCount> EncryptionSummary { get; set; }
        // EncryptionEnabled will be deprecated in the future and replaced with disk level granularity
        // in a future version that accomodates breaking changes.  Currently true if any disk encrypted.
        public bool EncryptionEnabled { get; set; }
        public bool EncryptionExtensionInstalled { get; set; }
        public IList<PSVmssDiskEncryptionInstanceStatusContext> Instances { get; set; }
    }

    class PSVmssDiskEncryptionStatusContextList : PSVmssDiskEncryptionStatusContext
    {
    }

    class PSVmssDiskEncryptionInstanceStatusContext
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public IList<PSVmssDiskEncryptionDiskStatusContext> Disks { get; set; }
    }

    class PSVmssDiskEncryptionDiskStatusContext
    {
        public string Name { get; set; }
        // Per Disk Encryption settings (not to be confused with VMSS EncryptionSettings set at the extension level)
        public IList<DiskEncryptionSettings> EncryptionSettings { get; set; }
        // Disk Instance View Statuses filtered by codes starting with "EncryptionState/" 
        public IList<InstanceViewStatus> Statuses { get; set; }
    }
}
