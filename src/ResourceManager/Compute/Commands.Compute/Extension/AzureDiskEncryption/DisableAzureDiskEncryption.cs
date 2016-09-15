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
using Microsoft.Azure.Commands.Compute.Models;
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
        VerbsLifecycle.Disable,
        ProfileNouns.AzureDiskEncryption,
        SupportsShouldProcess =  true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class DisableAzureDiskEncryptionCommand : VirtualMachineExtensionBaseCmdlet
    {
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
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Type of the volume (OS, Data or All) to perform decryption operation")]
        [ValidateSet("OS", "Data", "All")]
        public string VolumeType { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name. If this parameter is not specified, default values used are AzureDiskEncryption for windows VMs and AzureDiskEncryptionForLinux for Linux VMs")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("HandlerVersion", "Version")]
        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type handler version of AzureDiskEncryption VM extension that is used to disable encryption on the VM.")]
        [ValidateNotNullOrEmpty]
        public string TypeHandlerVersion { get; set; }

        [Parameter(HelpMessage = "To force the operation of decrypting the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable auto-upgrade of minor version")]
        public SwitchParameter DisableAutoUpgradeMinorVersion { get; set; }

        private OperatingSystemTypes? currentOSType = null;

        private Hashtable GetExtensionPublicSettings()
        {
            Hashtable publicSettings = new Hashtable();

            // Generate a new sequence version everytime to force run the extension. 
            // This is to bypass CRP & Guest Agent's optimization of not re-running the extension when there is no config change
            string sequenceVersion = Guid.NewGuid().ToString();
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.volumeTypeKey, VolumeType ?? String.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.encryptionOperationKey, AzureDiskEncryptionExtensionConstants.disableEncryptionOperation);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.sequenceVersionKey, sequenceVersion);

            return publicSettings;
        }

        private Hashtable GetExtensionProtectedSettings()
        {
            return null;
        }

        private VirtualMachineExtension GetVmExtensionParameters(VirtualMachine vmParameters)
        {
            Hashtable SettingString = GetExtensionPublicSettings();
            Hashtable ProtectedSettingString = GetExtensionProtectedSettings();

            if (vmParameters == null)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        new ApplicationException(
                            string.Format(
                                CultureInfo.CurrentUICulture,
                                "Disable-AzureDiskEncryption can disable encryption only on a VM that was already created ")),
                        "InvalidResult",
                        ErrorCategory.InvalidResult,
                        null));
            }

            VirtualMachineExtension vmExtensionParameters = null;
            if (OperatingSystemTypes.Windows.Equals(currentOSType))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultName;

                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Publisher = AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher,
                    VirtualMachineExtensionType = AzureDiskEncryptionExtensionContext.ExtensionDefaultName,
                    TypeHandlerVersion = (this.TypeHandlerVersion) ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultVersion,
                    Settings = SettingString,
                    ProtectedSettings = ProtectedSettingString,
                    AutoUpgradeMinorVersion = !DisableAutoUpgradeMinorVersion.IsPresent
                };
            }
            if (OperatingSystemTypes.Linux.Equals(currentOSType))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName;

                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Publisher = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher,
                    VirtualMachineExtensionType = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName,
                    TypeHandlerVersion = (this.TypeHandlerVersion) ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultVersion,
                    Settings = SettingString,
                    ProtectedSettings = ProtectedSettingString,
                    AutoUpgradeMinorVersion = !DisableAutoUpgradeMinorVersion.IsPresent
                };
            }

            return vmExtensionParameters;
        }

        /// <summary>
        /// This function gets the VM model, fills in the OSDisk properties with encryptionSettings and does an UpdateVM
        /// </summary>
        private AzureOperationResponse<VirtualMachine> UpdateVmEncryptionSettings()
        {
            var vmParameters = (this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(
                this.ResourceGroupName, this.VMName));
            if ((vmParameters == null) ||
                (vmParameters.StorageProfile == null) ||
                (vmParameters.StorageProfile.OsDisk == null))
            {
                // VM should have been created and have valid storageProfile and OSDisk by now
                ThrowTerminatingError(
                    new ErrorRecord(
                        new ApplicationException(
                            string.Format(
                                CultureInfo.CurrentUICulture,
                                "Set-AzureDiskEncryptionExtension can enable encryption only on a VM that was already created and has appropriate storageProfile and OS disk")),
                        "InvalidResult",
                        ErrorCategory.InvalidResult,
                        null));
            }

            DiskEncryptionSettings encryptionSettings = new DiskEncryptionSettings();
            encryptionSettings.Enabled = false;
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

            return this.ComputeClient.ComputeManagementClient.VirtualMachines.CreateOrUpdateWithHttpMessagesAsync(
                this.ResourceGroupName,
                vmParameters.Name,
                parameters).GetAwaiter().GetResult();
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                VirtualMachine virtualMachineResponse = (this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName));

                if ((virtualMachineResponse == null) ||
                    (virtualMachineResponse.StorageProfile == null) ||
                    (virtualMachineResponse.StorageProfile.OsDisk == null))
                {
                    // VM should have been created and have valid storageProfile and OSDisk by now
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new ApplicationException(
                                string.Format(
                                    CultureInfo.CurrentUICulture,
                                    "Disable-AzureDiskEncryption can disable encryption only on a VM that was already created and has appropriate storageProfile and OS disk")),
                            "InvalidResult",
                            ErrorCategory.InvalidResult,
                            null));
                }

                currentOSType = virtualMachineResponse.StorageProfile.OsDisk.OsType;

                if (OperatingSystemTypes.Linux.Equals(currentOSType) &&
                    !AzureDiskEncryptionExtensionContext.VolumeTypeData.Equals(VolumeType, StringComparison.InvariantCultureIgnoreCase))
                {
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new ArgumentException(
                                string.Format(
                                    CultureInfo.CurrentUICulture,
                                    "Disabling encryption is only allowed on Data volumes for Linux VMs.")),
                            "InvalidType",
                            ErrorCategory.NotImplemented,
                            null));
                }

                if (this.ShouldProcess(VMName, Properties.Resources.DisableDiskEncryptionAction)
                    && (this.Force.IsPresent ||
                    this.ShouldContinue(Properties.Resources.DisableAzureDiskEncryptionConfirmation, Properties.Resources.DisableAzureDiskEncryptionCaption)))
                {
                    VirtualMachineExtension parameters = GetVmExtensionParameters(virtualMachineResponse);

                    var opExt = this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                                                            this.ResourceGroupName,
                                                            this.VMName,
                                                            this.Name,
                                                            parameters).GetAwaiter().GetResult();

                    if (string.IsNullOrWhiteSpace(VolumeType) ||
                        VolumeType.Equals(AzureDiskEncryptionExtensionContext.VolumeTypeAll, StringComparison.InvariantCultureIgnoreCase) ||
                        VolumeType.Equals(AzureDiskEncryptionExtensionContext.VolumeTypeOS, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var opVm = UpdateVmEncryptionSettings();
                        var result = Mapper.Map<PSAzureOperationResponse>(opVm);
                        WriteObject(result);
                    }
                    else
                    {
                        var result = Mapper.Map<PSAzureOperationResponse>(opExt);
                        WriteObject(result);
                    }
                }
            });
        }
    }
}
