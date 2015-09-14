﻿// ----------------------------------------------------------------------------------
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
        public const string VirtualMachineProfile = "AzureRMVMProfile";

        public const string OSProfile = "AzureRMVMOSProfile";
        public const string StorageProfile = "AzureRMVMStorageProfile";
        public const string HardwareProfile = "AzureRMVMHardwareProfile";
        public const string NetworkProfile = "AzureRMVMNetworkProfile";

        public const string OperatingSystem = "AzureRMVMOperatingSystem";

        public const string DataDisk = "AzureRMVMDataDisk";
        public const string OSDisk = "AzureRMVMOSDisk";
        public const string SourceImage = "AzureRMVMSourceImage";

        public const string NetworkInterface = "AzureRMVMNetworkInterface";

        public const string VirtualMachine = "AzureRMVM";
        public const string VirtualMachineExtension = "AzureRMVMExtension";
        public const string VirtualMachineCustomScriptExtension = "AzureRMVMCustomScriptExtension";
        public const string VirtualMachineAccessExtension = "AzureRMVMAccessExtension";
        public const string VirtualMachineDiagnosticsExtension = "AzureRMVMDiagnosticsExtension";
        public const string VirtualMachineExtensionImage = "AzureRMVMExtensionImage";
        public const string VirtualMachineExtensionImageVersion = "AzureRMVMExtensionImageVersion";
        public const string VirtualMachineExtensionImageType = "AzureRMVMExtensionImageType";

        public const string AvailabilitySet = "AzureRMAvailabilitySet";
        public const string VirtualMachineConfig = "AzureRMVMConfig";
        public const string VirtualMachinePlan = "AzureRMVMPlan";

        public const string VirtualMachineSize = "AzureRMVMSize";

        public const string VirtualMachineImage = "AzureRMVMImage";
        public const string VirtualMachineImagePublisher = "AzureRMVMImagePublisher";
        public const string VirtualMachineImageOffer = "AzureRMVMImageOffer";
        public const string VirtualMachineImageSku = "AzureRMVMImageSku";
        public const string VirtualMachineImageVersion = "AzureRMVMImageVersion";

        public const string VirtualMachineUsage = "AzureRMVMUsage";

        public const string SshPublicKey = "AzureRMVMSshPublicKey";
        public const string AdditionalUnattendContent = "AzureRMVMAdditionalUnattendContent";
        public const string VaultSecretGroup = "AzureRMVMSecret";
        public const string RemoteDesktopFile = "AzureRMRemoteDesktopFile";

        //DSC
        public const string VirtualMachineDscExtension = "AzureRMVMDscExtension";
        public const string VirtualMachineDscConfiguration = "AzureRMVMDscConfiguration";

        public const string Vhd = "AzureRMVhd";

        // Sql Server
        public const string VirtualMachineSqlServerExtension = "AzureRMVMSqlServerExtension";
    }
}
