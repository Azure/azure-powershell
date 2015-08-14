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
        public const string VMImageReference = "The virtual machine's image reference.";
        public const string VMVHDContainer = "The virtual machine's Vhd container.";
        public const string VMOSDiskName = "The virtual machine OS disk's name.";
        public const string VMOSDiskVhdUri = "The virtual machine OS disk's Vhd Uri.";
        public const string VMOSDiskCaching = "The virtual machine OS disk's caching.";
        public const string VMOSDiskWindowsOSType = "The virtual machine disk's OS is Windows.";
        public const string VMOSDiskLinuxOSType = "The virtual machine disk's OS is Linux.";
        public const string VMSourceImageUri = "The virtual machine OS disk's source image Uri.";

        public const string VMDataDiskName = "The virtual machine data disk's name.";
        public const string VMDataDiskVhdUri = "The virtual machine data disk's Vhd Uri.";
        public const string VMDataDiskCaching = "The virtual machine data disk's caching.";
        public const string VMDataDiskSizeInGB = "The virtual machine data disk's size in GB.";
        public const string VMDataDiskLun = "The virtual machine data disk's Lun.";
        public const string VMDataDiskCreateOption = "The virtual machine data disk's create option.";

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
        public const string VirtualMachineProfile = "AzureVMProfile";

        public const string OSProfile = "AzureVMOSProfile";
        public const string StorageProfile = "AzureVMStorageProfile";
        public const string HardwareProfile = "AzureVMHardwareProfile";
        public const string NetworkProfile = "AzureVMNetworkProfile";

        public const string OperatingSystem = "AzureVMOperatingSystem";

        public const string DataDisk = "AzureVMDataDisk";
        public const string OSDisk = "AzureVMOSDisk";
        public const string SourceImage = "AzureVMSourceImage";

        public const string NetworkInterface = "AzureVMNetworkInterface";

        public const string VirtualMachine = "AzureVM";
        public const string VirtualMachineExtension = "AzureVMExtension";
        public const string VirtualMachineCustomScriptExtension = "AzureVMCustomScriptExtension";
        public const string VirtualMachineAccessExtension = "AzureVMAccessExtension";
        public const string VirtualMachineDiagnosticsExtension = "AzureVMDiagnosticsExtension";
        public const string VirtualMachineExtensionImage = "AzureVMExtensionImage";
        public const string VirtualMachineExtensionImageVersion = "AzureVMExtensionImageVersion";
        public const string VirtualMachineExtensionImageType = "AzureVMExtensionImageType";

        public const string AvailabilitySet = "AzureAvailabilitySet";
        public const string VirtualMachineConfig = "AzureVMConfig";
        public const string VirtualMachinePlan = "AzureVMPlan";

        public const string VirtualMachineSize = "AzureVMSize";

        public const string VirtualMachineImage = "AzureVMImage";
        public const string VirtualMachineImagePublisher = "AzureVMImagePublisher";
        public const string VirtualMachineImageOffer = "AzureVMImageOffer";
        public const string VirtualMachineImageSku = "AzureVMImageSku";
        public const string VirtualMachineImageVersion = "AzureVMImageVersion";

        public const string VirtualMachineUsage = "AzureVMUsage";

        public const string SshPublicKey = "AzureVMSshPublicKey";
        public const string AdditionalUnattendContent = "AzureVMAdditionalUnattendContent";
        public const string VaultSecretGroup = "AzureVMSecret";
        public const string RemoteDesktopFile = "AzureRemoteDesktopFile";

        //DSC
        public const string VirtualMachineDscExtension = "AzureVMDscExtension";
        public const string VirtualMachineDscConfiguration = "AzureVMDscConfiguration";
    }
}
