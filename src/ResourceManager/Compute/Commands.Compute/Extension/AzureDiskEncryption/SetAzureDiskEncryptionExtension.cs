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

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Extension.AzureVMBackup;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.AzureDiskEncryptionExtension,
        SupportsShouldProcess = true,
        DefaultParameterSetName = AzureDiskEncryptionExtensionConstants.singlePassParameterSet)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureDiskEncryptionExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name to which the VM belongs to")]
        [ResourceGroupCompleter()]
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
           ParameterSetName = AzureDiskEncryptionExtensionConstants.aadClientSecretParameterSet,
           HelpMessage = "Client ID of AAD app with permissions to write secrets to KeyVault")]
        [Parameter(
           Mandatory = true,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = AzureDiskEncryptionExtensionConstants.aadClientCertParameterSet,
           HelpMessage = "Client ID of AAD app with permissions to write secrets to KeyVault")]
        public string AadClientID { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureDiskEncryptionExtensionConstants.aadClientSecretParameterSet,
            HelpMessage = "Client Secret of AAD app with permissions to write secrets to KeyVault")]
        [ValidateNotNullOrEmpty]
        public string AadClientSecret { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
             ParameterSetName = AzureDiskEncryptionExtensionConstants.aadClientCertParameterSet,
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
            HelpMessage = "Type of the volume (OS, Data, or All) to encrypt")]
        [ValidateSet(
            AzureDiskEncryptionExtensionContext.VolumeTypeOS,
            AzureDiskEncryptionExtensionContext.VolumeTypeData,
            AzureDiskEncryptionExtensionContext.VolumeTypeAll)]
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

        [Parameter(HelpMessage = "To force enabling encryption on the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 14,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable auto-upgrade of minor version")]
        public SwitchParameter DisableAutoUpgradeMinorVersion { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 15,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Skip backup creation for Linux VMs")]
        public SwitchParameter SkipVmBackup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension type. Specify this parameter to override its default value of \"AzureDiskEncryption\" for Windows VMs and \"AzureDiskEncryptionForLinux\" for Linux VMs.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension publisher name. Specify this parameter only to override the default value of \"Microsoft.Azure.Security\".")]
        [ValidateNotNullOrEmpty]
        public string ExtensionPublisherName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Encrypt-Format all data drives that are not already encrypted")]
        public SwitchParameter EncryptFormatAll { get; set; }

        private OperatingSystemTypes? currentOSType = null;

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
            AzureOperationResponse<VirtualMachineExtension> extensionResult = this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName, this.VMName, this.Name);
            if (extensionResult == null)
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationFailedException(string.Format(CultureInfo.CurrentUICulture, "Failed to retrieve extension status")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }

            PSVirtualMachineExtension returnedExtension = extensionResult.ToPSVirtualMachineExtension(
                this.ResourceGroupName, this.VMName);

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
            if (OperatingSystemTypes.Linux.Equals(currentOSType))
            {
                this.ExtensionPublisherName = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher;
                this.ExtensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultType;
                if (returnedExtension.Publisher.Equals(this.ExtensionPublisherName, StringComparison.InvariantCultureIgnoreCase) &&
                    returnedExtension.ExtensionType.Equals(this.ExtensionType, StringComparison.InvariantCultureIgnoreCase))
                {
                    publisherMatch = true;
                }
            }
            else if (OperatingSystemTypes.Windows.Equals(currentOSType))
            {
                this.ExtensionPublisherName = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher;
                this.ExtensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultType;
                if (returnedExtension.Publisher.Equals(this.ExtensionPublisherName, StringComparison.InvariantCultureIgnoreCase) &&
                    returnedExtension.ExtensionType.Equals(this.ExtensionType, StringComparison.InvariantCultureIgnoreCase))
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
        private AzureOperationResponse<VirtualMachine> UpdateVmEncryptionSettings(DiskEncryptionSettings encryptionSettingsBackup)
        {
            string statusMessage = GetExtensionStatusMessage();

            var vmParameters = (this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(
                this.ResourceGroupName, this.VMName));
            if ((vmParameters == null) ||
                (vmParameters.StorageProfile == null) ||
                (vmParameters.StorageProfile.OsDisk == null))
            {
                //VM should have been created and have valid storageProfile and OSDisk by now
                ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, "Set-AzureDiskEncryptionExtension can enable encryption only on a VM that was already created and has appropriate storageProfile and OS disk")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }

            DiskEncryptionSettings encryptionSettings = new DiskEncryptionSettings();
            encryptionSettings.Enabled = true;
            encryptionSettings.DiskEncryptionKey = new KeyVaultSecretReference();
            encryptionSettings.DiskEncryptionKey.SourceVault = new SubResource(this.DiskEncryptionKeyVaultId);
            encryptionSettings.DiskEncryptionKey.SecretUrl = statusMessage;
            if (this.KeyEncryptionKeyUrl != null)
            {
                encryptionSettings.KeyEncryptionKey = new KeyVaultKeyReference();
                encryptionSettings.KeyEncryptionKey.SourceVault = new SubResource(this.KeyEncryptionKeyVaultId);
                encryptionSettings.KeyEncryptionKey.KeyUrl = this.KeyEncryptionKeyUrl;
            }
            vmParameters.StorageProfile.OsDisk.EncryptionSettings = encryptionSettings;
            var parameters = new VirtualMachine
            {
                DiagnosticsProfile = vmParameters.DiagnosticsProfile,
                HardwareProfile = vmParameters.HardwareProfile,
                StorageProfile = vmParameters.StorageProfile,
                NetworkProfile = vmParameters.NetworkProfile,
                OsProfile = vmParameters.OsProfile,
                Plan = vmParameters.Plan,
                AvailabilitySet = vmParameters.AvailabilitySet,
                Location = vmParameters.Location,
                Tags = vmParameters.Tags
            };

            AzureOperationResponse<VirtualMachine> updateResult = null;

            // The 2nd pass. TODO: If something goes wrong here, try to revert to encryptionSettingsBackup.
            if (encryptionSettingsBackup.Enabled != true)
            {
                updateResult = this.ComputeClient.ComputeManagementClient.VirtualMachines.CreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    vmParameters.Name,
                    parameters).GetAwaiter().GetResult();
            }
            else
            {

                // stop-update-start
                // stop vm
                this.ComputeClient.ComputeManagementClient.VirtualMachines
                    .DeallocateWithHttpMessagesAsync(this.ResourceGroupName, this.VMName).GetAwaiter()
                    .GetResult();
                
                // update vm
                vmParameters = (this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(
                this.ResourceGroupName, this.VMName));
                vmParameters.StorageProfile.OsDisk.EncryptionSettings = encryptionSettings;
                parameters = new VirtualMachine
                {
                    DiagnosticsProfile = vmParameters.DiagnosticsProfile,
                    HardwareProfile = vmParameters.HardwareProfile,
                    StorageProfile = vmParameters.StorageProfile,
                    NetworkProfile = vmParameters.NetworkProfile,
                    OsProfile = vmParameters.OsProfile,
                    Plan = vmParameters.Plan,
                    AvailabilitySet = vmParameters.AvailabilitySet,
                    Location = vmParameters.Location,
                    Tags = vmParameters.Tags
                };

                updateResult = this.ComputeClient.ComputeManagementClient.VirtualMachines.CreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    vmParameters.Name,
                    parameters).GetAwaiter().GetResult();

                // start vm
                this.ComputeClient.ComputeManagementClient.VirtualMachines
                    .StartWithHttpMessagesAsync(ResourceGroupName, this.VMName).GetAwaiter().GetResult();
            }

            return updateResult;
        }

        private Hashtable GetExtensionPublicSettings()
        {
            Hashtable publicSettings = new Hashtable();
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.aadClientIDKey, AadClientID ?? String.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.aadClientCertThumbprintKey, AadClientCertThumbprint ?? String.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.keyVaultResourceIdKey, DiskEncryptionKeyVaultId ?? string.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.keyVaultUrlKey, DiskEncryptionKeyVaultUrl ?? String.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.kekVaultResourceIdKey, KeyEncryptionKeyVaultId ?? string.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.keyEncryptionKeyUrlKey, KeyEncryptionKeyUrl ?? String.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.volumeTypeKey, VolumeType ?? String.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.sequenceVersionKey, SequenceVersion ?? String.Empty);

            if (EncryptFormatAll.IsPresent)
            {
                publicSettings.Add(AzureDiskEncryptionExtensionConstants.encryptionOperationKey, AzureDiskEncryptionExtensionConstants.enableEncryptionFormatAllOperation);
            }
            else
            {
                publicSettings.Add(AzureDiskEncryptionExtensionConstants.encryptionOperationKey, AzureDiskEncryptionExtensionConstants.enableEncryptionOperation);
            }

            string keyEncryptAlgorithm = string.Empty;
            if (!string.IsNullOrEmpty(this.KeyEncryptionKeyUrl))
            {
                if(!string.IsNullOrEmpty(KeyEncryptionAlgorithm))
                {
                    keyEncryptAlgorithm = KeyEncryptionAlgorithm;
                }
                else
                {
                    keyEncryptAlgorithm = AzureDiskEncryptionExtensionConstants.defaultKeyEncryptionAlgorithm;
                }
            }
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.keyEncryptionAlgorithmKey, keyEncryptAlgorithm);

            return publicSettings;
        }

        private Hashtable GetExtensionProtectedSettings()
        {
            Hashtable protectedSettings = new Hashtable();
            protectedSettings.Add(AzureDiskEncryptionExtensionConstants.aadClientSecretKey, AadClientSecret ?? String.Empty);
            if (OperatingSystemTypes.Linux.Equals(currentOSType))
            {
                protectedSettings.Add(AzureDiskEncryptionExtensionConstants.passphraseKey, Passphrase ?? null);
            }
            return protectedSettings;
        }

        private VirtualMachineExtension GetVmExtensionParameters(VirtualMachine vmParameters)
        {
            Hashtable SettingString = GetExtensionPublicSettings();
            Hashtable ProtectedSettingString = GetExtensionProtectedSettings();
            string typeHandlerDefaultVersion;  // determined by parameter set and VM operating system type

            if (vmParameters == null)
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, "Set-AzureDiskEncryptionExtension can enable encryption only on a VM that was already created ")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }

            VirtualMachineExtension vmExtensionParameters = null;

            if (OperatingSystemTypes.Windows.Equals(currentOSType))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultName;

                if (this.ParameterSetName.Equals(AzureDiskEncryptionExtensionConstants.singlePassParameterSet))
                {
                    typeHandlerDefaultVersion = AzureDiskEncryptionExtensionContext.ExtensionSinglePassVersion;
                }
                else
                {
                    typeHandlerDefaultVersion = AzureDiskEncryptionExtensionContext.ExtensionDefaultVersion;
                }
                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Publisher = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher,
                    VirtualMachineExtensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultType,
                    TypeHandlerVersion = this.TypeHandlerVersion ?? typeHandlerDefaultVersion,
                    Settings = SettingString,
                    ProtectedSettings = ProtectedSettingString,
                    AutoUpgradeMinorVersion = !DisableAutoUpgradeMinorVersion.IsPresent
                };
            }
            else if (OperatingSystemTypes.Linux.Equals(currentOSType))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                if (this.ParameterSetName.Equals(AzureDiskEncryptionExtensionConstants.singlePassParameterSet))
                {
                    typeHandlerDefaultVersion = AzureDiskEncryptionExtensionContext.LinuxExtensionSinglePassVersion;
                }
                else
                {
                    typeHandlerDefaultVersion = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultVersion;
                }
                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Publisher = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher,
                    VirtualMachineExtensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultType,
                    TypeHandlerVersion = this.TypeHandlerVersion ?? typeHandlerDefaultVersion,
                    Settings = SettingString,
                    ProtectedSettings = ProtectedSettingString,
                    AutoUpgradeMinorVersion = !DisableAutoUpgradeMinorVersion.IsPresent
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
                if (this.ShouldProcess(VMName, Properties.Resources.EnableDiskEncryptionAction)
                && (this.Force.IsPresent ||
                this.ShouldContinue(Properties.Resources.EnableAzureDiskEncryptionConfirmation, Properties.Resources.EnableAzureDiskEncryptionCaption)))
                {
                    VirtualMachine virtualMachineResponse = this.ComputeClient.ComputeManagementClient.VirtualMachines.GetWithInstanceView(
                        this.ResourceGroupName, VMName).Body;

                    currentOSType = virtualMachineResponse.StorageProfile.OsDisk.OsType;

                    if (OperatingSystemTypes.Linux.Equals(currentOSType) && !SkipVmBackup)
                    {
                        CreateVMBackupForLinx();
                    }

                    VirtualMachineExtension parameters = GetVmExtensionParameters(virtualMachineResponse);

                    DiskEncryptionSettings encryptionSettingsBackup = virtualMachineResponse.StorageProfile.OsDisk.EncryptionSettings ??
                                                                      new DiskEncryptionSettings { Enabled = false };

                    // Single Pass
                    //      newer model, supported by newer extension versions and host functionality 
                    //      if SinglePassParameterSet is used, cmdlet will default to newer extension version
                    //      [first and only pass]
                    //          only one enable extension call will be issued from the cmdlet n
                    //          No AD identity information or protected settings will be passed to the extension 
                    //          Host performs the necessary key vault operations and vm model updates 
                    // Dual Pass
                    //      older model, supported by older extension versions  
                    //      if an AD ParameterSet is used, cmdlet will default to older extension version
                    //      [first pass] 
                    //          AD identity information is passed into the VM via protected settings of the extension
                    //          VM uses the AD identity to authenticate and perform key vault operations  
                    //          VM returns result of key vault operation to caller via the extension status message
                    //      [second pass]
                    //          powershell reads extension status message returned from first pass
                    //          updates VM model with encryption settings
                    //          updates VM 

                    // First Pass
                    AzureOperationResponse<VirtualMachineExtension> firstPass = this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VMName,
                        this.Name,
                        parameters).GetAwaiter().GetResult();

                    if (!firstPass.Response.IsSuccessStatusCode)
                    {
                        ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture,
                                                                                        "Installation failed for extension {0} with error {1}",
                                                                                        parameters.VirtualMachineExtensionType,
                                                                                        firstPass.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult())),
                                                                "InvalidResult",
                                                                ErrorCategory.InvalidResult,
                                                                null));
                    }

                    if (this.ParameterSetName.Equals(AzureDiskEncryptionExtensionConstants.singlePassParameterSet))
                    {
                        WriteObject(ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(firstPass));
                    }
                    else
                    {
                        // Second pass 
                        var secondPass = UpdateVmEncryptionSettings(encryptionSettingsBackup);
                        WriteObject(ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(secondPass));
                    }
                }
            });
        }
    }
}
