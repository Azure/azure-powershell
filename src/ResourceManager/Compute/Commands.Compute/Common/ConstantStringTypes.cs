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

namespace Microsoft.Azure.Commands.Compute.Common
{
    public static class HelpMessages
    {
        public const string VMProfile = "The virtual machine profile.";
        public const string VMSize = "The virtual machine size.";
        public const string VMComputerName = "The virtual machine's omputer name.";
        public const string VMCredential = "The virtual machine's credential.";
        public const string VMSourceImageName = "The virtual machine's source image name.";
        public const string VMVHDContainer = "The virtual machine's Vhd container.";
        public const string VMOSDiskName = "The virtual machine OS disk's name.";
        public const string VMOSDiskVhdUri = "The virtual machine OS disk's Vhd Uri.";

        public const string VMDataDiskName = "The virtual machine data disk's name.";
        public const string VMDataDiskVhdUri = "The virtual machine data disk's Vhd Uri.";
        public const string VMDataDiskCaching = "The virtual machine data disk's caching.";
        public const string VMDataDiskSizeInGB = "The virtual machine data disk's size in GB.";
        public const string VMDataDiskLun = "The virtual machine data disk's Lun.";

        public const string VMNetworkInterfaceName = "The virtual machine network interface's name.";
        public const string VMNetworkInterfaceID = "The virtual machine network interface's ID.";
        public const string VMPublicIPAddressName = "The virtual machine public IP address's name.";
        public const string VMPublicIPAddressReferenceUri = "The virtual machine public IP address's reference Uri.";
    }

    public static class ValidateSetValues
    {
        public const string ReadOnly = "ReadOnly";
        public const string ReadWrite = "ReadWrite";
    }

    public static class ProfileNouns
    {
        public const string OS = "AzureVMOSProfile";
        public const string Storage = "AzureVMStorageProfile";
        public const string Hardware = "AzureVMHardwareProfile";
        public const string Network = "AzureVMNetworkProfile";
        public const string DataDisk = "AzureVMDataDiskProfile";
        public const string NetworkInterface = "AzureVMNetworkInterface";
        public const string VirtualMachine = "AzureVM";
        public const string VirtualMachineExtension = "AzureVMExtension";
        public const string VirtualMachineProfile = "AzureVMProfile";
        public const string AvailabilitySet = "AzureAvailabilitySet";
    }
}
