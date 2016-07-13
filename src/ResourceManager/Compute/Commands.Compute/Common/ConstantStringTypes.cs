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
        public const string VMOSDiskDiskEncryptionKeyUrl = "the URL referencing a secret in a disk encryption key vault";
        public const string VMOSDiskDiskEncryptionKeyVaultId = "the Id of a disk encryption key vault";
        public const string VMOSDiskKeyEncryptionKeyUrl = "the URL referencing a key in a key encryption key vault";
        public const string VMOSDiskKeyEncryptionKeyVaultId = "the Id of a key encryption key Vault";
        public const string VMOSDiskSizeInGB = "The virtual machine OS disk's size in GB.";
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

        public const string VMBootDiagnosticsEnable = "Enable boot diagnostics data of the virtual machine";
        public const string VMBootDiagnosticsDisable = "Disable boot diagnostics data of the virtual machine";
        public const string VMBootDiagnosticsResourceGroupName = "Resource group name for storage account";
        public const string VMBootDiagnosticsStorageAccountName = "Storage account name for boot diagnostics data";

        public const string VMPlanName = "The plan ID";
        public const string VMPlanProduct = "The offer ID";
        public const string VMPlanPromotionCode = "The promotion code";
        public const string VMPlanPublisher = "The publisher ID";
    }

    public static class ValidateSetValues
    {
        public const string ReadOnly = "ReadOnly";
        public const string ReadWrite = "ReadWrite";
        public const string None = "None";
    }

    public static class ProfileNouns
    {
        public const string VirtualMachineProfile = "AzureRmVMProfile";

        public const string OSProfile = "AzureRmVMOSProfile";
        public const string StorageProfile = "AzureRmVMStorageProfile";
        public const string HardwareProfile = "AzureRmVMHardwareProfile";
        public const string NetworkProfile = "AzureRmVMNetworkProfile";

        public const string OperatingSystem = "AzureRmVMOperatingSystem";

        public const string DataDisk = "AzureRmVMDataDisk";
        public const string OSDisk = "AzureRmVMOSDisk";
        public const string SourceImage = "AzureRmVMSourceImage";
        public const string BootDiagnostics = "AzureRmVMBootDiagnostics";
        public const string BootDiagnosticsData = "AzureRmVMBootDiagnosticsData";

        public const string NetworkInterface = "AzureRmVMNetworkInterface";

        public const string VirtualMachine = "AzureRmVM";
        public const string VirtualMachineExtension = "AzureRmVMExtension";
        public const string VirtualMachineADDomainExtension = "AzureRmVMADDomainExtension";
        public const string VirtualMachineCustomScriptExtension = "AzureRmVMCustomScriptExtension";
        public const string VirtualMachineAccessExtension = "AzureRmVMAccessExtension";
        public const string VirtualMachineDiagnosticsExtension = "AzureRmVMDiagnosticsExtension";
        public const string VirtualMachineBgInfoExtension = "AzureRmVMBginfoExtension";
        public const string VirtualMachineExtensionImage = "AzureRmVMExtensionImage";
        public const string VirtualMachineExtensionImageVersion = "AzureRmVMExtensionImageVersion";
        public const string VirtualMachineExtensionImageType = "AzureRmVMExtensionImageType";
        public const string VirtualMachineChefExtension = "AzureRmVMChefExtension";
        public const string VirtualMachineAEMExtension = "AzureRmVMAEMExtension";

        public const string AvailabilitySet = "AzureRmAvailabilitySet";
        public const string VirtualMachineConfig = "AzureRmVMConfig";
        public const string VirtualMachinePlan = "AzureRmVMPlan";

        public const string VirtualMachineSize = "AzureRmVMSize";

        public const string VirtualMachineImage = "AzureRmVMImage";
        public const string VirtualMachineImagePublisher = "AzureRmVMImagePublisher";
        public const string VirtualMachineImageOffer = "AzureRmVMImageOffer";
        public const string VirtualMachineImageSku = "AzureRmVMImageSku";
        public const string VirtualMachineImageVersion = "AzureRmVMImageVersion";

        public const string VirtualMachineUsage = "AzureRmVMUsage";

        public const string SshPublicKey = "AzureRmVMSshPublicKey";
        public const string AdditionalUnattendContent = "AzureRmVMAdditionalUnattendContent";
        public const string VaultSecretGroup = "AzureRmVMSecret";
        public const string RemoteDesktopFile = "AzureRmRemoteDesktopFile";

        //DSC
        public const string VirtualMachineDscExtension = "AzureRmVMDscExtension";
        public const string VirtualMachineDscConfiguration = "AzureRmVMDscConfiguration";
        public const string VirtualMachineDscExtensionStatus = "AzureRmVMDscExtensionStatus";
        public const string Vhd = "AzureRmVhd";

        // Sql Server
        public const string VirtualMachineSqlServerExtension = "AzureRmVMSqlServerExtension";

        //AzureDiskEncryption
        public const string AzureDiskEncryptionExtension = "AzureRmVMDiskEncryptionExtension";
        public const string AzureDiskEncryptionStatus = "AzureRmVMDiskEncryptionStatus";
        public const string AzureDiskEncryption = "AzureRmVMDiskEncryption";

        //AzureVMBackup
        public const string AzureVMBackup = "AzureRmVMBackup";
        public const string AzureVMBackupExtension = "AzureRmVMBackupExtension";

    }
}
