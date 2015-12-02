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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Management.Automation;
using System.Globalization;
using AutoMapper;
using Microsoft.Azure.Commands.Compute.Extension.AzureVMBackup;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.AzureDiskEncryptionExtension,
        DefaultParameterSetName = aadClientSecretParameterSet)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class SetAzureDiskEncryptionExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        private const string aadClientCertParameterSet = "AAD Client Cert Parameters";
        private const string aadClientSecretParameterSet = "AAD Client Secret Parameters";
        private const string enableEncryptionOperation = "EnableEncryption";

        private const string aadClientIDKey = "AADClientID";
        private const string aadClientSecretKey = "AADClientSecret";
        private const string aadClientCertThumbprintKey = "AADClientCertThumbprint";
        private const string keyVaultUrlKey = "KeyVaultURL";
        private const string keyEncryptionKeyUrlKey = "KeyEncryptionKeyURL";
        private const string keyEncryptionAlgorithmKey = "KeyEncryptionAlgorithm";
        private const string volumeTypeKey = "VolumeType";
        private const string encryptionOperationKey = "EncryptionOperation";
        private const string sequenceVersionKey = "SequenceVersion";
        private const string passphraseKey = "Passphrase";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name to which the VM belongs to")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the virtual machine")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Client ID of AAD app with permissions to write secrets to KeyVault")]
        public string AadClientID { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = aadClientSecretParameterSet,
            HelpMessage = "Client Secret of AAD app with permissions to write secrets to KeyVault")]
        [ValidateNotNullOrEmpty]
        public string AadClientSecret { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
             ParameterSetName = aadClientCertParameterSet,
            HelpMessage = "Thumbprint of AAD app certificate with permissions to write secrets to KeyVault")]
        [ValidateNotNullOrEmpty]
        public string AadClientCertThumbprint { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "URL of the KeyVault where generated encryption key will be placed to")]
        public string DiskEncryptionKeyVaultUrl { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ResourceID of the KeyVault where generated encryption key will be placed to")]
        public string DiskEncryptionKeyVaultId { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Versioned KeyVault URL of the KeyEncryptionKey used to encrypt the disk encryption key")]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionKeyUrl { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ResourceID of the KeyVault containing the KeyEncryptionKey used to encrypt the disk encryption key")]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionKeyVaultId { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyEncryption Algorithm used to encrypt the volume encryption key")]
        [ValidateSet("RSA-OAEP", "RSA1_5")]
        public string KeyEncryptionAlgorithm { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Type of the volume (OS or Data) to perform encryption operation")]
        [ValidateSet("OS", "Data", "All")]
        public string VolumeType { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Sequence version of encryption operation. This must be incremented to perform repeated encryption operations on the same VM")]
        [ValidateNotNullOrEmpty]
        public string SequenceVersion { get; set; }

        [Alias("HandlerVersion", "Version")]
        [Parameter(
            Mandatory = false,
            Position = 11,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type handler version.")]
        [ValidateNotNullOrEmpty]
        public string TypeHandlerVersion { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 12,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name. If this parameter is not specified, default values used are AzureDiskEncryption for windows VMs and AzureDiskEncryptionForLinux for Linux VMs")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 13,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The passphrase specified in parameters. This parameter only works for Linux VM.")]
        [ValidateNotNullOrEmpty]
        public string Passphrase { get; set; }

        [Parameter(HelpMessage = "To force the removal.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        private string currentOSType = null;

        private void ValidateInputParameters()
        {
            if (false == Uri.IsWellFormedUriString(DiskEncryptionKeyVaultId, UriKind.Absolute))
            {
                ThrowTerminatingError(new ErrorRecord(new ArgumentException(string.Format(CultureInfo.CurrentUICulture, "Invalid DiskEncryptionKeyVaultUrl. Please provide a valid KeyVault URI for DiskEncryptionKeyVaultUrl")),
                                                      "InvalidArgument",
                                                      ErrorCategory.InvalidArgument,
                                                      null));
            }
            if (string.IsNullOrWhiteSpace(KeyEncryptionKeyUrl) == false)
            {
                if (false == Uri.IsWellFormedUriString(DiskEncryptionKeyVaultId, UriKind.Absolute))
                {
                    ThrowTerminatingError(new ErrorRecord(new ArgumentException(string.Format(CultureInfo.CurrentUICulture, "Invalid KeyEncryptionKeyUrl. Please provide a valid KeyVault URI for KeyEncryptionKeyUrl")),
                                                          "InvalidArgument",
                                                          ErrorCategory.InvalidArgument,
                                                          null));
                }
            }
        }

        private string GetExtensionStatusMessage()
        {
            VirtualMachineExtensionGetResponse extensionResult = this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName, this.VMName, this.Name);
            if (extensionResult == null)
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationFailedException(string.Format(CultureInfo.CurrentUICulture, "Failed to retrieve extension status")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }
            PSVirtualMachineExtension returnedExtension = extensionResult.ToPSVirtualMachineExtension(this.ResourceGroupName);
            if ((returnedExtension == null) ||
                (string.IsNullOrWhiteSpace(returnedExtension.Publisher)) ||
                (string.IsNullOrWhiteSpace(returnedExtension.ExtensionType)))
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationFailedException(string.Format(CultureInfo.CurrentUICulture, "Missing extension publisher and type info")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }
            bool publisherMatch = false;
            if (string.Equals(currentOSType, "Linux", StringComparison.InvariantCultureIgnoreCase))
            {
                if (returnedExtension.Publisher.Equals(AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                    returnedExtension.ExtensionType.Equals(AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase))
                {
                    publisherMatch = true;
                }
            }
            else if (string.Equals(currentOSType, "Windows", StringComparison.InvariantCultureIgnoreCase))
            {
                if (returnedExtension.Publisher.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                    returnedExtension.ExtensionType.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase))
                {
                    publisherMatch = true;
                }
            }
            if (publisherMatch)
            {
                AzureDiskEncryptionExtensionContext context = new AzureDiskEncryptionExtensionContext(returnedExtension);
                if ((context == null) ||
                    (context.Statuses == null) ||
                    (context.Statuses.Count < 1) ||
                    (string.IsNullOrWhiteSpace(context.Statuses[0].Message)))
                {
                    ThrowTerminatingError(new ErrorRecord(new ApplicationFailedException(string.Format(CultureInfo.CurrentUICulture, "Invalid extension status")),
                                                          "InvalidResult",
                                                          ErrorCategory.InvalidResult,
                                                          null));
                }
                return context.Statuses[0].Message;
            }
            else
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationFailedException(string.Format(CultureInfo.CurrentUICulture, "Extension publisher and type mismatched")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }
            return null;
        }

        /// <summary>
        /// This function gets the VM model, fills in the OSDisk properties with encryptionSettings and does an UpdateVM
        /// </summary>
        private ComputeLongRunningOperationResponse UpdateVmEncryptionSettings()
        {
            string statusMessage = GetExtensionStatusMessage();

            VirtualMachine vmParameters = (this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName)).VirtualMachine;
            if ((vmParameters == null) ||
                (vmParameters.StorageProfile == null) ||
                (vmParameters.StorageProfile.OSDisk == null))
            {
                //VM should have been created and have valid storageProfile and OSDisk by now
                ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, "Set-AzureDiskEncryptionExtension can enable encryption only on a VM that was already created and has appropriate storageProfile and OS disk")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }

            DiskEncryptionSettings encryptionSettings = new DiskEncryptionSettings();
            encryptionSettings.DiskEncryptionKey = new KeyVaultSecretReference();
            encryptionSettings.DiskEncryptionKey.SourceVault = new SourceVaultReference();
            encryptionSettings.DiskEncryptionKey.SourceVault.ReferenceUri = this.DiskEncryptionKeyVaultId;
            encryptionSettings.DiskEncryptionKey.SecretUrl = statusMessage;
            if (this.KeyEncryptionKeyUrl != null)
            {
                encryptionSettings.KeyEncryptionKey = new KeyVaultKeyReference();
                encryptionSettings.KeyEncryptionKey.SourceVault = new SourceVaultReference();
                encryptionSettings.KeyEncryptionKey.SourceVault.ReferenceUri = this.KeyEncryptionKeyVaultId;
                encryptionSettings.KeyEncryptionKey.KeyUrl = this.KeyEncryptionKeyUrl;
            }
            vmParameters.StorageProfile.OSDisk.EncryptionSettings = encryptionSettings;
            var parameters = new VirtualMachine
            {
                DiagnosticsProfile = vmParameters.DiagnosticsProfile,
                HardwareProfile = vmParameters.HardwareProfile,
                StorageProfile = vmParameters.StorageProfile,
                NetworkProfile = vmParameters.NetworkProfile,
                OSProfile = vmParameters.OSProfile,
                Plan = vmParameters.Plan,
                AvailabilitySetReference = vmParameters.AvailabilitySetReference,
                Location = vmParameters.Location,
                Name = vmParameters.Name,
                Tags = vmParameters.Tags
            };
            return this.ComputeClient.ComputeManagementClient.VirtualMachines.CreateOrUpdate(this.ResourceGroupName, parameters);
        }

        private string GetExtensionPublicSettings()
        {
            Hashtable publicSettings = new Hashtable();
            publicSettings.Add(aadClientIDKey, AadClientID ?? String.Empty);
            publicSettings.Add(aadClientCertThumbprintKey, AadClientCertThumbprint ?? String.Empty);
            publicSettings.Add(keyVaultUrlKey, DiskEncryptionKeyVaultUrl ?? String.Empty);
            publicSettings.Add(keyEncryptionKeyUrlKey, KeyEncryptionKeyUrl ?? String.Empty);
            publicSettings.Add(keyEncryptionAlgorithmKey, KeyEncryptionAlgorithm ?? String.Empty);
            publicSettings.Add(volumeTypeKey, VolumeType ?? String.Empty);
            publicSettings.Add(encryptionOperationKey, enableEncryptionOperation);
            publicSettings.Add(sequenceVersionKey, SequenceVersion ?? String.Empty);

            return JsonConvert.SerializeObject(publicSettings);
        }

        private string GetExtensionProtectedSettings()
        {
            Hashtable protectedSettings = new Hashtable();
            protectedSettings.Add(aadClientSecretKey, AadClientSecret ?? String.Empty);
            if (string.Equals(this.currentOSType, "Linux"))
            {
                protectedSettings.Add(passphraseKey, Passphrase ?? null);
            }
            return JsonConvert.SerializeObject(protectedSettings);
        }

        private VirtualMachineExtension GetVmExtensionParameters(VirtualMachine vmParameters)
        {
            string SettingString = GetExtensionPublicSettings();
            string ProtectedSettingString = GetExtensionProtectedSettings();

            if (vmParameters == null)
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, "Set-AzureDiskEncryptionExtension can enable encryption only on a VM that was already created ")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }

            VirtualMachineExtension vmExtensionParameters = null;
            if (string.Equals(currentOSType, "Windows", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultName;
                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Name = this.Name,
                    Type = VirtualMachineExtensionType,
                    Publisher = AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher,
                    ExtensionType = AzureDiskEncryptionExtensionContext.ExtensionDefaultName,
                    TypeHandlerVersion = (this.TypeHandlerVersion) ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultVersion,
                    Settings = SettingString,
                    ProtectedSettings = ProtectedSettingString,
                };
            }
            else if (string.Equals(currentOSType, "Linux", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Name = this.Name,
                    Type = VirtualMachineExtensionType,
                    Publisher = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher,
                    ExtensionType = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName,
                    TypeHandlerVersion = (this.TypeHandlerVersion) ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultVersion,
                    Settings = SettingString,
                    ProtectedSettings = ProtectedSettingString,
                };
            }

            return vmExtensionParameters;
        }

        private void CreateVMBackupForLinx()
        {
            try
            {
                AzureVMBackupExtensionUtil azureBackupExtensionUtil = new AzureVMBackupExtensionUtil();
                AzureVMBackupConfig vmConfig = new AzureVMBackupConfig();
                vmConfig.ResourceGroupName = ResourceGroupName;
                vmConfig.VMName = VMName;
                vmConfig.VirtualMachineExtensionType = VirtualMachineExtensionType;
                string tag = string.Format("{0}{1}", "AzureEnc", Guid.NewGuid().ToString());
                // this would create shapshot only for Linux box. and we should wait for the snapshot found.
                azureBackupExtensionUtil.CreateSnapshotForDisks(vmConfig, tag, this);
                WriteWarning(string.Format("one snapshot for disks are created with tag,{0}, you can use {1}-{2} to remove it.", tag, VerbsCommon.Remove,
    ProfileNouns.AzureVMBackup));
            }
            catch (AzureVMBackupException e)
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, e.ToString())),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.Force.IsPresent ||
                this.ShouldContinue(Properties.Resources.EnableAzureDiskEncryptionConfirmation, Properties.Resources.EnableAzureDiskEncryptionCaption))
                {
                    VirtualMachine virtualMachineResponse = this.ComputeClient.ComputeManagementClient.VirtualMachines.GetWithInstanceView(this.ResourceGroupName, VMName).VirtualMachine;

                    currentOSType = virtualMachineResponse.StorageProfile.OSDisk.OperatingSystemType;

                    if (string.Equals(currentOSType, "Linux", StringComparison.InvariantCultureIgnoreCase))
                    {
                        CreateVMBackupForLinx();
                    }

                    VirtualMachineExtension parameters = GetVmExtensionParameters(virtualMachineResponse);

                    this.VirtualMachineExtensionClient.CreateOrUpdate(this.ResourceGroupName,
                                                                      this.VMName,
                                                                      parameters);

                    var op = UpdateVmEncryptionSettings();
                    WriteObject(Mapper.Map<PSComputeLongRunningOperation>(op));
                }
            });
        }
    }
}
