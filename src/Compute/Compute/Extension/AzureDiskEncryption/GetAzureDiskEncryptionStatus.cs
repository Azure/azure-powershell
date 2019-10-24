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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMDiskEncryptionStatus"),OutputType(typeof(AzureDiskEncryptionExtensionContext))]
    public class GetAzureDiskEncryptionStatusCommand : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource group name of the virtual machine")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name. If this parameter is not specified, default values used are AzureDiskEncryption for Windows VMs and AzureDiskEncryptionForLinux for Linux VMs")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines/extensions", "ResourceGroupName", "VMName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
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

        private VirtualMachineExtension GetDualPassQueryVmExtensionParameters(VirtualMachine vmParameters)
        {
            Hashtable publicSettings = new Hashtable();
            Hashtable protectedSettings = new Hashtable();

            publicSettings.Add(AzureDiskEncryptionExtensionConstants.encryptionOperationKey, AzureDiskEncryptionExtensionConstants.queryEncryptionStatusOperation);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.sequenceVersionKey, Guid.NewGuid().ToString());

            if (vmParameters == null)
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, "Get-AzDiskEncryptionExtension can enable encryption only on a VM that was already created ")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }

            VirtualMachineExtension vmExtensionParameters = null;

            if (OperatingSystemTypes.Windows.Equals(vmParameters.StorageProfile.OsDisk.OsType))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultName;
                this.ExtensionPublisherName = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher;
                this.ExtensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultType;
                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Publisher = this.ExtensionPublisherName,
                    VirtualMachineExtensionType = this.ExtensionType,
                    TypeHandlerVersion = AzureDiskEncryptionExtensionContext.ExtensionDefaultVersion,
                    Settings = publicSettings,
                    ProtectedSettings = protectedSettings
                };
            }
            else if (OperatingSystemTypes.Linux.Equals(vmParameters.StorageProfile.OsDisk.OsType))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                this.ExtensionPublisherName = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher;
                this.ExtensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultType;
                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Publisher = this.ExtensionPublisherName,
                    VirtualMachineExtensionType = this.ExtensionType,
                    TypeHandlerVersion = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultVersion,
                    Settings = publicSettings,
                    ProtectedSettings = protectedSettings
                };
            }

            return vmExtensionParameters;
        }

        private bool IsExtensionInstalled(VirtualMachine vm)
        {
            return FindEncryptionExtension(vm) == null;
        }

        private string GetExtensionStatusMessage(VirtualMachine vm, bool returnSubstatusMessage=false)
        {
            VirtualMachineExtensionInstanceView extensionInstanceView = this.FindEncryptionExtensionInstanceView(vm);

            if (extensionInstanceView == null)
            {
                throw new KeyNotFoundException(string.Format(CultureInfo.CurrentUICulture, "Encryption extension not found on VM Instance View"));
            }
            if ((extensionInstanceView.Statuses == null) || (extensionInstanceView.Statuses.Count < 1))
            {
                throw new KeyNotFoundException(string.Format(CultureInfo.CurrentUICulture, "Invalid extension status"));
            }
            if (returnSubstatusMessage)
            {
                if ((extensionInstanceView == null) || (extensionInstanceView.Substatuses == null) || (extensionInstanceView.Substatuses.Count < 1))
                {
                    throw new KeyNotFoundException(string.Format(CultureInfo.CurrentUICulture, "Invalid extension substatus"));
                }
                else
                {
                    return extensionInstanceView.Substatuses[0].Message;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(extensionInstanceView.Statuses[0].Message))
                {
                    return extensionInstanceView.Statuses[0].Message;
                }
                else
                {
                    // if message is empty, fall back to display status
                    return extensionInstanceView.Statuses[0].DisplayStatus;
                }
            }
        }

        private EncryptionStatus IsWindowsOsVolumeEncryptedDualPass(VirtualMachine vmParameters)
        {
            switch (vmParameters.StorageProfile.OsDisk.OsType)
            {
                case OperatingSystemTypes.Windows:
                    DiskEncryptionSettings osEncryptionSettings = GetOsVolumeEncryptionSettingsDualPass(vmParameters);

                    if (osEncryptionSettings != null
                        && osEncryptionSettings.DiskEncryptionKey != null
                        && !string.IsNullOrEmpty(osEncryptionSettings.DiskEncryptionKey.SecretUrl)
                        && osEncryptionSettings.Enabled == true)
                    {
                        return EncryptionStatus.Encrypted;
                    }
                    else
                    {
                        return EncryptionStatus.NotEncrypted;
                    }
                default:
                    return EncryptionStatus.Unknown;
            }
        }

        private string GetLastEncryptionStatus(DiskInstanceView div)
        {
            string lastCode = "";
            foreach (InstanceViewStatus ivs in div.Statuses)
            {
                if (ivs.Code.StartsWith("EncryptionState/"))
                    lastCode = ivs.Code;
            }
            return lastCode;
        }

        private DiskEncryptionSettings GetOsVolumeEncryptionSettingsDualPass(VirtualMachine vmParameters)
        {
            if ((vmParameters != null) &&
                (vmParameters.StorageProfile != null) &&
                (vmParameters.StorageProfile.OsDisk != null))
            {
                return vmParameters.StorageProfile.OsDisk.EncryptionSettings;
            }

            // nothing found
            return null;
        }

        private bool DataVolumeInExtensionConfig(AzureDiskEncryptionExtensionContext adeExtension)
        {
            if (adeExtension != null)
            {
                if ((string.IsNullOrWhiteSpace(adeExtension.VolumeType)) ||
                    (adeExtension.VolumeType.Equals(AzureDiskEncryptionExtensionContext.VolumeTypeData, StringComparison.InvariantCultureIgnoreCase)) ||
                    (adeExtension.VolumeType.Equals(AzureDiskEncryptionExtensionContext.VolumeTypeAll, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ExtensionProvisioningSucceeded(AzureDiskEncryptionExtensionContext adeExtension)
        {
            var extensionStatusViewresult = this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName, this.VMName, adeExtension.Name);
            var extensionStatusView = extensionStatusViewresult.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName);
            var adeExtensionWithStatus = new AzureDiskEncryptionExtensionContext(extensionStatusView);
            if (adeExtensionWithStatus.ProvisioningState.Equals(AzureDiskEncryptionExtensionContext.StatusSucceeded, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private EncryptionStatus AreWindowsDataVolumesEncryptedDualPass(VirtualMachine vmParameters)
        {
            VirtualMachineExtension vmExtension = this.FindEncryptionExtension(vmParameters);
            if (vmExtension == null)
            {
                return EncryptionStatus.Unknown;
            }

            AzureDiskEncryptionExtensionContext adeExtension =
                new AzureDiskEncryptionExtensionContext(vmExtension.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName));

            if (DataVolumeInExtensionConfig(adeExtension))
            {
                if (adeExtension.EncryptionOperation.Equals(AzureDiskEncryptionExtensionConstants.enableEncryptionOperation, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (ExtensionProvisioningSucceeded(adeExtension))
                    {
                        return EncryptionStatus.Encrypted;
                    }
                }
            }
            return EncryptionStatus.NotEncrypted;
        }

        private AzureDiskEncryptionStatusContext GetStatusFromInstanceView(VirtualMachine vm)
        {
            AzureDiskEncryptionStatusContext result = new AzureDiskEncryptionStatusContext();
            result.OsVolumeEncrypted = EncryptionStatus.Unknown;
            result.DataVolumesEncrypted = EncryptionStatus.Unknown;

            StorageProfile storageProfile = vm.StorageProfile;
            VirtualMachineInstanceView iv = vm.InstanceView;
            if (iv != null)
            {
                result.OsVolumeEncrypted = EncryptionStatus.NoDiskFound;
                result.DataVolumesEncrypted = EncryptionStatus.NoDiskFound;

                foreach (DiskInstanceView div in iv.Disks)
                {
                    if (div.Name.Equals(storageProfile.OsDisk.Name))
                    {
                        // check os volume status
                        string status = GetLastEncryptionStatus(div);
                        switch (status)
                        {
                            case "EncryptionState/encrypted":
                                result.OsVolumeEncrypted = EncryptionStatus.Encrypted;
                                break;
                            case "EncryptionState/notEncrypted":
                            case "":
                                result.OsVolumeEncrypted = EncryptionStatus.NotEncrypted;
                                break;
                            default:
                                break;
                        }
                        result.OsVolumeEncryptionSettings = (div.EncryptionSettings != null) ? div.EncryptionSettings[0] : null;
                    }
                    else 
                    {
                        // check data volume status

                        // Mark DataVolumesEncrypted as Encrypted if even one of the disks is Encrypted
                        // Skip if DataVolumesEncrypted has already been marked Encrypted
                        if (result.DataVolumesEncrypted == EncryptionStatus.Encrypted)
                        {
                            continue;
                        }

                        string status = GetLastEncryptionStatus(div);
                        switch (status)
                        {
                            case "EncryptionState/encrypted":
                                result.DataVolumesEncrypted = EncryptionStatus.Encrypted;
                                break;
                            case "EncryptionState/notEncrypted":
                            case "":
                                result.DataVolumesEncrypted = EncryptionStatus.NotEncrypted;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return result;
        }

        private VirtualMachineExtensionInstanceView FindEncryptionExtensionInstanceView(VirtualMachine vm)
        {
            string extensionPublisher = "";
            string extensionName = "";

            if (vm.InstanceView == null || vm.InstanceView.Extensions == null) return null;

            switch(vm.StorageProfile.OsDisk.OsType)
            {
                case OperatingSystemTypes.Linux:
                    extensionPublisher = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher;
                    extensionName = this.Name ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                    break;
                case OperatingSystemTypes.Windows:
                    extensionPublisher = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher;
                    extensionName = this.Name ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultName;
                    break;
            }

            foreach (VirtualMachineExtensionInstanceView extension in vm.InstanceView.Extensions)
            {
                if (!string.IsNullOrWhiteSpace(extension.Type) &&
                    extension.Type.StartsWith(extensionPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                    !string.IsNullOrWhiteSpace(extension.Name) &&
                    extension.Name.Equals(extensionName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return extension;
                }
            }

            return null;
        }

        private VirtualMachineExtension FindEncryptionExtension(VirtualMachine vm)
        {
            string extensionPublisher = "";
            string extensionType = "";

            if (vm == null || vm.Resources == null) return null;

            switch(vm.StorageProfile.OsDisk.OsType)
            {
                case OperatingSystemTypes.Linux:
                    extensionPublisher = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher;
                    extensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultType;
                    break;
                case OperatingSystemTypes.Windows:
                    extensionPublisher = this.ExtensionPublisherName ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher;
                    extensionType = this.ExtensionType ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultType;
                    break;
            }

            foreach (VirtualMachineExtension extension in vm.Resources)
            {
                if (extensionPublisher.Equals(extension.Publisher, StringComparison.InvariantCultureIgnoreCase) &&
                    extensionType.Equals(extension.VirtualMachineExtensionType, StringComparison.InvariantCultureIgnoreCase))
                {
                    return extension;
                }
            }

            return null;
        }

        private AzureDiskEncryptionMode GetAzureDiskEncryptionMode(VirtualMachine vmWithInstanceView)
        {
            if (vmWithInstanceView.StorageProfile.OsDisk.EncryptionSettings != null && 
                vmWithInstanceView.StorageProfile.OsDisk.EncryptionSettings.Enabled == true)
            {
                // If Enabled Settings found in VM Model's Storage Profile, it's DualPass encrypted
                return AzureDiskEncryptionMode.DualPass;
            }

            foreach (DiskInstanceView diskInstanceView in vmWithInstanceView.InstanceView.Disks)
            {
                if (diskInstanceView.EncryptionSettings != null)
                {
                    foreach(DiskEncryptionSettings encryptionSettings in diskInstanceView.EncryptionSettings)
                    {
                        if (encryptionSettings.Enabled == true)
                        {
                            // If any of the disk instance views have enabled encryption settings then its SinglePass encrypted
                            return AzureDiskEncryptionMode.SinglePass;
                        }
                    }
                }
            }

            VirtualMachineExtension matchedExtension = this.FindEncryptionExtension(vmWithInstanceView);

            if (matchedExtension == null)
            {
                return AzureDiskEncryptionMode.None;
            }

            string extensionSinglePassVersion = "";

            switch(vmWithInstanceView.StorageProfile.OsDisk.OsType)
            {
                case OperatingSystemTypes.Linux:
                    extensionSinglePassVersion = AzureDiskEncryptionExtensionContext.LinuxExtensionSinglePassVersion;
                    break;
                case OperatingSystemTypes.Windows:
                    extensionSinglePassVersion = AzureDiskEncryptionExtensionContext.ExtensionSinglePassVersion;
                    break;
            }

            if (matchedExtension.TypeHandlerVersion.Split('.')[0] == extensionSinglePassVersion.Split('.')[0])
            {
                return AzureDiskEncryptionMode.SinglePass;
            }
            else
            {
                return AzureDiskEncryptionMode.DualPass;
            }
        }

        private void validateRetreivedVirtualMachine(VirtualMachine vm)
        {
            string errorString = "";
            if (vm == null)
            {
                errorString = "Failed to retrieve virtual machine model";
            }
            else if (vm.StorageProfile == null)
            {
                errorString = "retreived virtual machine does not have storage profile";
            }
            else if (vm.StorageProfile.OsDisk == null)
            {
                errorString = "retreived virtual machine does not have an OS disk in the storage profile";
            }
            else if (vm.StorageProfile.OsDisk.OsType == null)
            {
                errorString = "retreived virtual machine does not have an OS type in the storage profile's OS Disk";
            }
            else if (vm.InstanceView == null)
            {
                errorString = "could not retreive VM Instance View";
            }

            if (errorString != "")
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationFailedException(string.Format(CultureInfo.CurrentUICulture, errorString)),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }
        }

        private bool isVMRunning (VirtualMachine vm)
        {
            string lastCode = "";
            if (vm.InstanceView.Statuses == null)
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationFailedException(string.Format(CultureInfo.CurrentUICulture, "VM instance view statuses array was null. Could not get VM status.")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }
            foreach (InstanceViewStatus ivs in vm.InstanceView.Statuses)
            {
                if (ivs != null && ivs.Code != null && ivs.Code.StartsWith("PowerState/"))
                    lastCode = ivs.Code;
            }

            return lastCode == "PowerState/running";
        }

        private AzureDiskEncryptionStatusContext getStatusDualPass(VirtualMachine vm)
        {
            DiskEncryptionSettings osVolumeEncryptionSettings = GetOsVolumeEncryptionSettingsDualPass(vm);
            AzureDiskEncryptionStatusContext encryptionStatus = null;

            switch (vm.StorageProfile.OsDisk.OsType)
            {
                case OperatingSystemTypes.Windows:
                    EncryptionStatus osVolumeEncrypted = IsWindowsOsVolumeEncryptedDualPass(vm);
                    EncryptionStatus dataVolumesEncrypted = AreWindowsDataVolumesEncryptedDualPass(vm);
                    encryptionStatus = new AzureDiskEncryptionStatusContext
                    {
                        OsVolumeEncrypted = osVolumeEncrypted,
                        DataVolumesEncrypted = dataVolumesEncrypted,
                        OsVolumeEncryptionSettings = osVolumeEncryptionSettings,
                        ProgressMessage = string.Format(CultureInfo.CurrentUICulture, "OsVolume: {0}, DataVolumes: {1}", osVolumeEncrypted, dataVolumesEncrypted)
                    };
                    break;
                case OperatingSystemTypes.Linux:

                    Dictionary<string, string> encryptionStatusParsed = null;
                    try
                    {
                        string encryptionStatusJson = GetExtensionStatusMessage(vm, returnSubstatusMessage: true);
                        encryptionStatusParsed = JsonConvert.DeserializeObject<Dictionary<string, string>>(encryptionStatusJson);
                    }
                    catch(KeyNotFoundException)
                    {
                        encryptionStatusParsed = new Dictionary<string, string>()
                        {
                            { AzureDiskEncryptionExtensionConstants.encryptionResultOsKey, EncryptionStatus.Unknown.ToString() },
                            { AzureDiskEncryptionExtensionConstants.encryptionResultDataKey, EncryptionStatus.Unknown.ToString() }
                        };
                    }

                    string progressMessage = null;
                    try
                    {
                        progressMessage = GetExtensionStatusMessage(vm);
                    }
                    catch(KeyNotFoundException)
                    {
                        progressMessage = string.Format(CultureInfo.CurrentUICulture, "Extension status not available on the VM");
                    }

                    encryptionStatus = new AzureDiskEncryptionStatusContext
                    {
                        OsVolumeEncrypted = (EncryptionStatus)Enum.Parse(typeof(EncryptionStatus), encryptionStatusParsed[AzureDiskEncryptionExtensionConstants.encryptionResultOsKey]),
                        DataVolumesEncrypted = (EncryptionStatus)Enum.Parse(typeof(EncryptionStatus), encryptionStatusParsed[AzureDiskEncryptionExtensionConstants.encryptionResultDataKey]),
                        OsVolumeEncryptionSettings = osVolumeEncryptionSettings,
                        ProgressMessage = progressMessage
                    };
                    break;
                default:
                    ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, "OS type unknown.")),
                                                  "InvalidResult",
                                                  ErrorCategory.InvalidResult,
                                                  null));
                    break;
            }
            return encryptionStatus;
        }

        private bool isNativeDiskVM(VirtualMachine vm)
        {
            return vm.StorageProfile.OsDisk.Vhd != null && vm.StorageProfile.OsDisk.Vhd.Uri != null;
        }

        private AzureDiskEncryptionStatusContext getStatusSinglePass(VirtualMachine vm)
        {
            // First get extension status from disk instance view
            AzureDiskEncryptionStatusContext status = this.GetStatusFromInstanceView(vm);

            // Get Data Disk status from extension for Native Disk VMs
            if ( status.DataVolumesEncrypted != EncryptionStatus.NoDiskFound && isNativeDiskVM(vm))
            {
                // We use logic that's otherwise only used for Windows VMs in Dual Pass
                status.DataVolumesEncrypted = this.AreWindowsDataVolumesEncryptedDualPass(vm);
            }

            // Get the extension status message
            try
            {
                status.ProgressMessage = GetExtensionStatusMessage(vm);
            }
            catch(KeyNotFoundException)
            {
                status.ProgressMessage = string.Format(CultureInfo.CurrentUICulture, "Extension status not available on the VM");
            }

            // While this is enough for Windows, we may need more information for Linux from the extension substatus
            if (vm.StorageProfile.OsDisk.OsType == OperatingSystemTypes.Linux)
            {
                try
                {
                    Dictionary<string, string> encryptionStatusParsed = null;
                    string encryptionStatusJson = GetExtensionStatusMessage(vm, returnSubstatusMessage: true);
                    encryptionStatusParsed = JsonConvert.DeserializeObject<Dictionary<string, string>>(encryptionStatusJson);
                    status.OsVolumeEncrypted = (EncryptionStatus)Enum.Parse(typeof(EncryptionStatus), encryptionStatusParsed[AzureDiskEncryptionExtensionConstants.encryptionResultOsKey]);
                    status.DataVolumesEncrypted = (EncryptionStatus)Enum.Parse(typeof(EncryptionStatus), encryptionStatusParsed[AzureDiskEncryptionExtensionConstants.encryptionResultDataKey]);
                }
                catch (KeyNotFoundException)
                {
                    ;// Do nothing
                }
            }

            return status;
        }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                VirtualMachine virtualMachineResponse = this.ComputeClient.ComputeManagementClient.VirtualMachines.GetWithInstanceView(
                    this.ResourceGroupName, this.VMName).Body;

                this.validateRetreivedVirtualMachine(virtualMachineResponse);

                AzureDiskEncryptionMode adeMode = GetAzureDiskEncryptionMode(virtualMachineResponse);

                AzureDiskEncryptionStatusContext status = null;

                switch (adeMode)
                {
                    case AzureDiskEncryptionMode.SinglePass:
                        status = this.getStatusSinglePass(virtualMachineResponse);
                        break;
                    case AzureDiskEncryptionMode.DualPass:
                        status = this.getStatusDualPass(virtualMachineResponse);
                        break;
                    case AzureDiskEncryptionMode.None:
                        status = new AzureDiskEncryptionStatusContext
                        {
                            OsVolumeEncrypted = EncryptionStatus.NotEncrypted,
                            DataVolumesEncrypted = EncryptionStatus.NotEncrypted,
                            OsVolumeEncryptionSettings = null,
                            ProgressMessage = "No Encryption extension or metadata found on the VM"
                        };
                        break;
                }

                WriteObject(status);

                return;
            });
        }
    }
}
