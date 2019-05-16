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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMOSDisk",DefaultParameterSetName = DefaultParamSet),OutputType(typeof(PSVirtualMachine))]
    public class SetAzureVMOSDiskCommand : ComputeClientBaseCmdlet
    {
        protected const string DefaultParamSet = "DefaultParamSet";
        protected const string WindowsParamSet = "WindowsParamSet";
        protected const string LinuxParamSet = "LinuxParamSet";
        protected const string WindowsAndDiskEncryptionParameterSet = "WindowsDiskEncryptionParameterSet";
        protected const string LinuxAndDiskEncryptionParameterSet = "LinuxDiskEncryptionParameterSet";

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Alias("OSDiskName", "DiskName")]
        [Parameter(
            Mandatory = false,
            Position = 1,
            HelpMessage = HelpMessages.VMOSDiskName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("OSDiskVhdUri", "DiskVhdUri")]
        [Parameter(
            Mandatory = false,
            Position = 2,
            HelpMessage = HelpMessages.VMOSDiskVhdUri)]
        [ValidateNotNullOrEmpty]
        public string VhdUri { get; set; }

        [Parameter(
            Position = 3,
            HelpMessage = HelpMessages.VMOSDiskCaching)]
        public CachingTypes? Caching { get; set; }

        [Alias("SourceImage")]
        [Parameter(
            Position = 4,
            HelpMessage = HelpMessages.VMSourceImageUri)]
        [ValidateNotNullOrEmpty]
        public string SourceImageUri { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            HelpMessage = HelpMessages.VMDataDiskCreateOption)]
        public string CreateOption { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 6,
            HelpMessage = HelpMessages.VMOSDiskWindowsOSType)]
        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Position = 6,
            HelpMessage = HelpMessages.VMOSDiskWindowsOSType)]
        public SwitchParameter Windows { get; set; }

        [Parameter(
            ParameterSetName = LinuxParamSet,
            Position = 6,
            HelpMessage = HelpMessages.VMOSDiskLinuxOSType)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Position = 6,
            HelpMessage = HelpMessages.VMOSDiskLinuxOSType)]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Mandatory = true,
            Position = 7,
            HelpMessage = HelpMessages.VMOSDiskDiskEncryptionKeyUrl)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Mandatory = true,
            Position = 7,
            HelpMessage = HelpMessages.VMOSDiskDiskEncryptionKeyUrl)]
        public string DiskEncryptionKeyUrl { get; set; }

        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Mandatory = true,
            Position = 8,
            HelpMessage = HelpMessages.VMOSDiskDiskEncryptionKeyVaultId)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Mandatory = true,
            Position = 8,
            HelpMessage = HelpMessages.VMOSDiskDiskEncryptionKeyVaultId)]
        public string DiskEncryptionKeyVaultId { get; set; }

        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Mandatory = false,
            Position = 9,
            HelpMessage = HelpMessages.VMOSDiskKeyEncryptionKeyUrl)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Mandatory = false,
            Position = 9,
            HelpMessage = HelpMessages.VMOSDiskKeyEncryptionKeyUrl)]
        public string KeyEncryptionKeyUrl { get; set; }

        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Mandatory = false,
            Position = 10,
            HelpMessage = HelpMessages.VMOSDiskKeyEncryptionKeyVaultId)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Mandatory = false,
            Position = 10,
            HelpMessage = HelpMessages.VMOSDiskKeyEncryptionKeyVaultId)]
        public string KeyEncryptionKeyVaultId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.VMOSDiskSizeInGB)]
        [AllowNull]
        public int? DiskSizeInGB { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.VMManagedDiskId)]
        [ValidateNotNullOrEmpty]
        public string ManagedDiskId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.VMManagedDiskAccountType)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard_LRS", "Premium_LRS", "StandardSSD_LRS", "UltraSSD_LRS")]
        public string StorageAccountType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        public SwitchParameter WriteAccelerator { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string DiffDiskSetting { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VM.StorageProfile == null)
            {
                this.VM.StorageProfile = new StorageProfile();
            }

            if ((string.IsNullOrEmpty(this.KeyEncryptionKeyVaultId) && !string.IsNullOrEmpty(this.KeyEncryptionKeyUrl))
                || (!string.IsNullOrEmpty(this.KeyEncryptionKeyVaultId) && string.IsNullOrEmpty(this.KeyEncryptionKeyUrl)))
            {
                WriteError(new ErrorRecord(
                        new Exception(Properties.Resources.VMOSDiskDiskEncryptionBothKekVaultIdAndKekUrlRequired),
                        string.Empty, ErrorCategory.InvalidArgument, null));
            }

            if (this.VM.StorageProfile.OsDisk == null)
            {
                this.VM.StorageProfile.OsDisk = new OSDisk();
            }

            this.VM.StorageProfile.OsDisk.Name = this.Name ?? this.VM.StorageProfile.OsDisk.Name;
            this.VM.StorageProfile.OsDisk.Caching = this.Caching ?? this.VM.StorageProfile.OsDisk.Caching;
            this.VM.StorageProfile.OsDisk.DiskSizeGB = this.DiskSizeInGB ?? this.VM.StorageProfile.OsDisk.DiskSizeGB;

            if (this.Windows.IsPresent)
            {
                this.VM.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
            }
            else if (this.Linux.IsPresent)
            {
                this.VM.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Linux;
            }

            if (!string.IsNullOrEmpty(this.VhdUri))
            {
                this.VM.StorageProfile.OsDisk.Vhd = new VirtualHardDisk
                {
                    Uri = this.VhdUri
                };
            }

            if (!string.IsNullOrEmpty(this.SourceImageUri))
            {
                this.VM.StorageProfile.OsDisk.Image = new VirtualHardDisk
                {
                    Uri = this.SourceImageUri
                };
            }

            if (this.IsParameterBound(c => c.CreateOption))
            {
                this.VM.StorageProfile.OsDisk.CreateOption = this.CreateOption;
            }

            if (this.ParameterSetName.Equals(WindowsAndDiskEncryptionParameterSet) || this.ParameterSetName.Equals(LinuxAndDiskEncryptionParameterSet))
            {
                this.VM.StorageProfile.OsDisk.EncryptionSettings = new DiskEncryptionSettings
                {
                    DiskEncryptionKey = new KeyVaultSecretReference
                    {
                        SourceVault = new SubResource
                        {
                            Id = this.DiskEncryptionKeyVaultId
                        },
                        SecretUrl = this.DiskEncryptionKeyUrl
                    },
                    KeyEncryptionKey = (this.KeyEncryptionKeyVaultId == null || this.KeyEncryptionKeyUrl == null)
                    ? null
                    : new KeyVaultKeyReference
                    {
                        KeyUrl = this.KeyEncryptionKeyUrl,
                        SourceVault = new SubResource
                        {
                            Id = this.KeyEncryptionKeyVaultId
                        },
                    }
                };
            }

            this.VM.StorageProfile.OsDisk.ManagedDisk = SetManagedDisk(this.ManagedDiskId, this.StorageAccountType, this.VM.StorageProfile.OsDisk.ManagedDisk);

            this.VM.StorageProfile.OsDisk.WriteAcceleratorEnabled = this.WriteAccelerator.IsPresent;

            if (this.IsParameterBound(c => c.DiffDiskSetting))
            {
                if (this.VM.StorageProfile.OsDisk.DiffDiskSettings == null)
                {
                    this.VM.StorageProfile.OsDisk.DiffDiskSettings = new DiffDiskSettings();
                }
                this.VM.StorageProfile.OsDisk.DiffDiskSettings.Option = this.DiffDiskSetting;
            }

            WriteObject(this.VM);
        }
    }
}
