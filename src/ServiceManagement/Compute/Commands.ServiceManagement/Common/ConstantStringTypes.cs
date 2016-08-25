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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Common
{
    public static class HelpMessages
    {
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
        public const string VMSourceImageUri = "The virtual machine OS disk's source image Uri.";

        public const string VMDataDiskName = "The virtual machine data disk's name.";
        public const string VMDataDiskVhdUri = "The virtual machine data disk's Vhd Uri.";
        public const string VMDataDiskCaching = "The virtual machine data disk's caching.";
        public const string VMDataDiskSizeInGB = "The virtual machine data disk's size in GB.";
        public const string VMDataDiskLun = "The virtual machine data disk's Lun.";
        public const string VMDataDiskCreateOption = "The virtual machine data disk's create option.";

        public const string VMBootDiagnosticsEnable = "Enable boot diagnostics of the virtual machine";
        public const string VMBootDiagnosticsDisable = "Disable boot diagnostics of the virtual machine";

        public const string VMLicenseType = "Specifies that the image or disk that is being used was licensed on-premises.";
    }

    public static class ValidateSetValues
    {
        public const string ReadOnly = "ReadOnly";
        public const string ReadWrite = "ReadWrite";
        public const string None = "None";
    }

    public static class ProfileNouns
    {
        public const string DataDisk = "AzureDataDisk";
        public const string OsDisk = "AzureOSDisk";
        public const string BootDiagnostics = "AzureVMBootDiagnostics";
       
        public const string VirtualMachine = "AzureVM";
        public const string VirtualMachineExtension = "AzureVMExtension";
        public const string VirtualMachineCustomScriptExtension = "AzureVMCustomScriptExtension";
        public const string VirtualMachineAccessExtension = "AzureVMAccessExtension";
        public const string VirtualMachineDiagnosticsExtension = "AzureVMDiagnosticsExtension";
        public const string VirtualMachineBgInfoExtension = "AzureVMBginfoExtension";
        public const string VirtualMachineChefExtension = "AzureVMChefExtension";

        public const string AvailabilitySet = "AzureAvailabilitySet";
        public const string VirtualMachineConfig = "AzureVMConfig";
        public const string VirtualMachineSize = "AzureVMSize";
        public const string VirtualMachineImage = "AzureVMImage";
        public const string RemoteDesktopFile = "AzureRemoteDesktopFile";

        //DSC
        public const string VirtualMachineDscExtension = "AzureVMDscExtension";
        public const string VirtualMachineDscConfiguration = "AzureVMDscConfiguration";
        public const string VirtualMachineDscExtensionStatus = "AzureVMDscExtensionStatus";
        public const string Vhd = "AzureVhd";

        // Sql Server
        public const string VirtualMachineSqlServerExtension = "AzureVMSqlServerExtension";

        //AzureDiskEncryption
        public const string AzureDiskEncryptionExtension = "AzureVMDiskEncryptionExtension";
        public const string AzureDiskEncryptionStatus = "AzureVMDiskEncryptionStatus";

        //AzureVMBackup
        public const string AzureVMBackup = "AzureVMBackup";
        public const string AzureVMBackupExtension = "AzureVMBackupExtension";
    }
}
