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

        public const string VMManagedDiskId = "The virtual machine managed disk's Id.";
        public const string VMManagedDiskAccountType = "The virtual machine managed disk's account type.";

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
        public const string Manual = "Manual";
        public const string Automated = "Automated";
        public const string Daily = "Daily";
        public const string Weekly = "Weekly";
    }

    public static class ProfileNouns
    {
        public const string VirtualMachineProfile = "AzVMProfile";

        public const string OSProfile = "AzVMOSProfile";
        public const string StorageProfile = "AzVMStorageProfile";
        public const string HardwareProfile = "AzVMHardwareProfile";
        public const string NetworkProfile = "AzVMNetworkProfile";

        public const string OperatingSystem = "AzVMOperatingSystem";

        public const string DataDisk = "AzVMDataDisk";
        public const string OSDisk = "AzVMOSDisk";
        public const string SourceImage = "AzVMSourceImage";
        public const string BootDiagnostics = "AzVMBootDiagnostic";
        public const string BootDiagnosticsData = "AzVMBootDiagnosticsData";

        public const string NetworkInterface = "AzVMNetworkInterface";

        public const string VirtualMachine = "AzVM";
        public const string VirtualMachineExtension = "AzVMExtension";
        public const string VirtualMachineADDomainExtension = "AzVMADDomainExtension";
        public const string VirtualMachineCustomScriptExtension = "AzVMCustomScriptExtension";
        public const string VirtualMachineAccessExtension = "AzVMAccessExtension";
        public const string VirtualMachineDiagnosticsExtension = "AzVMDiagnosticsExtension";
        public const string VirtualMachineBgInfoExtension = "AzVMBginfoExtension";
        public const string VirtualMachineExtensionImage = "AzVMExtensionImage";
        public const string VirtualMachineExtensionImageVersion = "AzVMExtensionImageVersion";
        public const string VirtualMachineExtensionImageType = "AzVMExtensionImageType";
        public const string VirtualMachineChefExtension = "AzVMChefExtension";
        public const string VirtualMachineAEMExtension = "AzVMAEMExtension";

        public const string AvailabilitySet = "AzAvailabilitySet";
        public const string VirtualMachineConfig = "AzVMConfig";
        public const string VirtualMachinePlan = "AzVMPlan";

        public const string VirtualMachineSize = "AzVMSize";

        public const string VirtualMachineImage = "AzVMImage";
        public const string VirtualMachineImagePublisher = "AzVMImagePublisher";
        public const string VirtualMachineImageOffer = "AzVMImageOffer";
        public const string VirtualMachineImageSku = "AzVMImageSku";
        public const string VirtualMachineImageVersion = "AzVMImageVersion";

        public const string VirtualMachineUsage = "AzVMUsage";

        public const string SshPublicKey = "AzVMSshPublicKey";
        public const string AdditionalUnattendContent = "AzVMAdditionalUnattendContent";
        public const string VaultSecretGroup = "AzVMSecret";
        public const string RemoteDesktopFile = "AzRemoteDesktopFile";

        public const string VirtualMachineScaleSetDiagnosticsExtension = "AzVmssDiagnosticsExtension";

        //DSC
        public const string VirtualMachineDscExtension = "AzVMDscExtension";
        public const string VirtualMachineDscConfiguration = "AzVMDscConfiguration";
        public const string VirtualMachineDscExtensionStatus = "AzVMDscExtensionStatus";
        public const string Vhd = "AzVhd";

        // Sql Server
        public const string VirtualMachineSqlServerExtension = "AzVMSqlServerExtension";
        public const string VirtualMachineSqlServerAutoBackupConfig = "AzVMSqlServerAutoBackupConfig";
        public const string VirtualMachineSqlServerAutoPatchingConfig = "AzVMSqlServerAutoPatchingConfig";
        public const string VirtualMachineSqlServerKeyVaultCredentialConfig = "AzVMSqlServerKeyVaultCredentialConfig";

        //AzureDiskEncryption
        public const string AzureDiskEncryptionExtension = "AzVMDiskEncryptionExtension";
        public const string AzureDiskEncryptionStatus = "AzVMDiskEncryptionStatus";
        public const string AzureDiskEncryption = "AzVMDiskEncryption";

        // AzureVmssDiskEncryption
        public const string AzureVmssDiskEncryptionExtension = "AzVmssDiskEncryptionExtension";
        public const string AzureVmssDiskEncryption = "AzVmssDiskEncryption";
        public const string AzureVmssVMDiskEncryption = "AzVmssVMDiskEncryption";
        public const string GetAzureRmVmssDiskEncryptionAlias = "Get-AzVmssDiskEncryptionStatus";
        public const string GetAzureRmVmssVMDiskEncryptionAlias = "Get-AzVmssVMDiskEncryptionStatus";

        //AzureVMBackup
        public const string AzureVMBackup = "AzVMBackup";
        public const string AzureVMBackupExtension = "AzVMBackupExtension";

    }
}
