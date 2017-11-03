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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.OSDisk,
        DefaultParameterSetName = DefaultParamSet),
    OutputType(
        typeof(PSVirtualMachine))]
    public class SetAzureVMOSDiskCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Alias("OSDiskName", "DiskName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("OSDiskVhdUri", "DiskVhdUri")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskVhdUri)]
        [ValidateNotNullOrEmpty]
        public string VhdUri { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskCaching)]
        public CachingTypes? Caching { get; set; }

        [Alias("SourceImage")]
        [Parameter(
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMSourceImageUri)]
        [ValidateNotNullOrEmpty]
        public string SourceImageUri { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskCreateOption)]
        public DiskCreateOptionTypes CreateOption { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskWindowsOSType)]
        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskWindowsOSType)]
        public SwitchParameter Windows { get; set; }

        [Parameter(
            ParameterSetName = LinuxParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskLinuxOSType)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskLinuxOSType)]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Mandatory = true,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskDiskEncryptionKeyUrl)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Mandatory = true,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskDiskEncryptionKeyUrl)]
        public string DiskEncryptionKeyUrl { get; set; }

        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Mandatory = true,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskDiskEncryptionKeyVaultId)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Mandatory = true,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskDiskEncryptionKeyVaultId)]
        public string DiskEncryptionKeyVaultId { get; set; }

        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Mandatory = false,
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskKeyEncryptionKeyUrl)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Mandatory = false,
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskKeyEncryptionKeyUrl)]
        public string KeyEncryptionKeyUrl { get; set; }

        [Parameter(
            ParameterSetName = WindowsAndDiskEncryptionParameterSet,
            Mandatory = false,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskKeyEncryptionKeyVaultId)]
        [Parameter(
            ParameterSetName = LinuxAndDiskEncryptionParameterSet,
            Mandatory = false,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskKeyEncryptionKeyVaultId)]
        public string KeyEncryptionKeyVaultId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskSizeInGB)]
        [AllowNull]
        public int? DiskSizeInGB { get; set; }

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

            this.VM.StorageProfile.OsDisk = new OSDisk
            {
                Caching = this.Caching,
                Name = this.Name,
                OsType = this.Windows.IsPresent ? OperatingSystemTypes.Windows : this.Linux.IsPresent ? OperatingSystemTypes.Linux : (OperatingSystemTypes?)null,
                Vhd = string.IsNullOrEmpty(this.VhdUri) ? null : new VirtualHardDisk
                {
                    Uri = this.VhdUri
                },
                DiskSizeGB = this.DiskSizeInGB,
                Image = string.IsNullOrEmpty(this.SourceImageUri) ? null : new VirtualHardDisk
                {
                    Uri = this.SourceImageUri
                },
                CreateOption = this.CreateOption,
                EncryptionSettings =
                (this.ParameterSetName.Equals(WindowsAndDiskEncryptionParameterSet) || this.ParameterSetName.Equals(LinuxAndDiskEncryptionParameterSet))
                ? new DiskEncryptionSettings
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
                }
                : null
            };

            WriteObject(this.VM);
        }
    }
}
