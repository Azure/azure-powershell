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

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
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
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMDiskEncryption",SupportsShouldProcess =  true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class DisableAzureDiskEncryptionCommand : VirtualMachineExtensionBaseCmdlet
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
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Type of the volume (OS, Data or All) to perform decryption operation")]
        [ValidateSet(
            AzureDiskEncryptionExtensionContext.VolumeTypeOS,
            AzureDiskEncryptionExtensionContext.VolumeTypeData,
            AzureDiskEncryptionExtensionContext.VolumeTypeAll)]
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable auto-upgrade of minor version")]
        public SwitchParameter DisableAutoUpgradeMinorVersion { get; set; }

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

        private bool IsVmModelEncryptionSet(VirtualMachine vm)
        {
            return (vm != null &&
                vm.StorageProfile != null &&
                vm.StorageProfile.OsDisk != null &&
                vm.StorageProfile.OsDisk.EncryptionSettings != null);
        }

        private string GetVersionForDisable(VirtualMachine vm)
        {
            // if there is currently an extension installed, use that version for disable as well 
            if (vm.Resources != null)
            {
                foreach (VirtualMachineExtension vme in vm.Resources)
                {
                    if (vme.Publisher.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher) &&
                         (vme.VirtualMachineExtensionType.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultType) ||
                          vme.VirtualMachineExtensionType.Equals(AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultType)))
                    {
                        return vme.TypeHandlerVersion;
                    }
                }
            }

            // If we reach this point, no extension is currently installed, even if the VM is encrypted.
            // To disable encryption, we will select the extension version matching the encryption 
            // settings present on the VM and then use that version to issue the disable operation. 

            if (IsVmModelEncryptionSet(vm))
            {
                // encryption settings present in VM model, use default dual pass version
                if (currentOSType == OperatingSystemTypes.Linux)
                {
                    return AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultVersion;
                }
                else
                {
                    return AzureDiskEncryptionExtensionContext.ExtensionDefaultVersion;
                }
            }
            else
            {
                // encryption settings not present in the VM model, use single pass version
                if (currentOSType == OperatingSystemTypes.Linux)
                {
                    return AzureDiskEncryptionExtensionContext.LinuxExtensionSinglePassVersion;
                }
                else
                {
                    return AzureDiskEncryptionExtensionContext.ExtensionSinglePassVersion;
                }
            }
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
                    Publisher = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher,
                    VirtualMachineExtensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultType,
                    TypeHandlerVersion = GetVersionForDisable(vmParameters),
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
                    Publisher = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher,
                    VirtualMachineExtensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultType,
                    TypeHandlerVersion = GetVersionForDisable(vmParameters),
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
                VirtualMachine virtualMachineResponse = (this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName, InstanceViewTypes.InstanceView));

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

                    // +---------+---------------+----------------------------+
                    // | OSType  |  VolumeType   | UpdateVmEncryptionSettings |
                    // +---------+---------------+----------------------------+
                    // | Windows | OS            | Yes                        |
                    // | Windows | Data          | No                         |
                    // | Windows | Not Specified | Yes                        |
                    // | Linux   | OS            | N/A                        |
                    // | Linux   | Data          | Yes                        |
                    // | Linux   | Not Specified | N/A                        |
                    // +---------+---------------+----------------------------+

                    if ((OperatingSystemTypes.Windows.Equals(currentOSType) && parameters.TypeHandlerVersion.Equals(AzureDiskEncryptionExtensionContext.ExtensionSinglePassVersion)) ||
                        (OperatingSystemTypes.Linux.Equals(currentOSType) && parameters.TypeHandlerVersion.Equals(AzureDiskEncryptionExtensionContext.LinuxExtensionSinglePassVersion)) ||
                        (OperatingSystemTypes.Windows.Equals(currentOSType) && !string.IsNullOrEmpty(VolumeType) && VolumeType.Equals(AzureDiskEncryptionExtensionContext.VolumeTypeData, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(opExt);
                        WriteObject(result);
                    }
                    else
                    {
                        var opVm = UpdateVmEncryptionSettings();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(opVm);
                        WriteObject(result);
                    }
                }
            });
        }
    }
}
