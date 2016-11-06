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
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.AzureDiskEncryptionStatus),
    OutputType(typeof(AzureDiskEncryptionExtensionContext))]
    public class GetAzureDiskEncryptionStatusCommand : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource group name of the virtual machine")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name. If this parameter is not specified, default values used are AzureDiskEncryption for Windows VMs and AzureDiskEncryptionForLinux for Linux VMs")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        private VirtualMachineExtension GetVmExtensionParameters(VirtualMachine vmParameters, OSType currentOSType)
        {
            Hashtable publicSettings = new Hashtable();
            Hashtable protectedSettings = new Hashtable();

            publicSettings.Add(AzureDiskEncryptionExtensionConstants.encryptionOperationKey, AzureDiskEncryptionExtensionConstants.queryEncryptionStatusOperation);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.sequenceVersionKey, Guid.NewGuid().ToString());

            if (vmParameters == null)
            {
                ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, "Get-AzureDiskEncryptionExtension can enable encryption only on a VM that was already created ")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
            }

            VirtualMachineExtension vmExtensionParameters = null;

            if (OSType.Windows.Equals(currentOSType))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.ExtensionDefaultName;
                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Publisher = AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher,
                    VirtualMachineExtensionType = AzureDiskEncryptionExtensionContext.ExtensionDefaultName,
                    TypeHandlerVersion = AzureDiskEncryptionExtensionContext.ExtensionDefaultVersion,
                    Settings = publicSettings,
                    ProtectedSettings = protectedSettings
                };
            }
            else if (OSType.Linux.Equals(currentOSType))
            {
                this.Name = this.Name ?? AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                vmExtensionParameters = new VirtualMachineExtension
                {
                    Location = vmParameters.Location,
                    Publisher = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher,
                    VirtualMachineExtensionType = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName,
                    TypeHandlerVersion = AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultVersion,
                    Settings = publicSettings,
                    ProtectedSettings = protectedSettings
                };
            }

            return vmExtensionParameters;
        }

        private string GetExtensionStatusMessage(OSType currentOSType, bool returnSubstatusMessage=false)
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
            if (OSType.Linux.Equals(currentOSType))
            {
                if (returnedExtension.Publisher.Equals(AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                    returnedExtension.ExtensionType.Equals(AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase))
                {
                    publisherMatch = true;
                }
            }
            else if (OSType.Windows.Equals(currentOSType))
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
                    throw new KeyNotFoundException(string.Format(CultureInfo.CurrentUICulture, "Invalid extension status"));
                }

                if (returnSubstatusMessage)
                {
                    if((context == null) ||
                       (context.SubStatuses == null) ||
                       (context.SubStatuses.Count < 1))
                    {
                        throw new KeyNotFoundException(string.Format(CultureInfo.CurrentUICulture, "Invalid extension substatus"));
                    }
                    else
                    {
                        return context.SubStatuses[0].Message;
                    }
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

        private OSType GetOSType(VirtualMachine vmParameters)
        {
            if (vmParameters == null || vmParameters.StorageProfile == null || vmParameters.StorageProfile.OsDisk == null)
            {
                return OSType.Unknown;
            }
            else
            {
                if (OperatingSystemTypes.Linux == vmParameters.StorageProfile.OsDisk.OsType)
                {
                    return OSType.Linux;
                }
                if (OperatingSystemTypes.Windows == vmParameters.StorageProfile.OsDisk.OsType)
                {
                    return OSType.Windows;
                }
                return OSType.Unknown;
            }
        }
        private EncryptionStatus IsOsVolumeEncrypted(VirtualMachine vmParameters)
        {
            OSType osType = this.GetOSType(vmParameters);
            switch (osType)
            {
                case OSType.Windows:
                    DiskEncryptionSettings osEncryptionSettings = GetOsVolumeEncryptionSettings(vmParameters);

                    if (osEncryptionSettings != null
                        && osEncryptionSettings.DiskEncryptionKey != null
                        && !String.IsNullOrEmpty(osEncryptionSettings.DiskEncryptionKey.SecretUrl)
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

        private DiskEncryptionSettings GetOsVolumeEncryptionSettings(VirtualMachine vmParameters)
        {
            if ((vmParameters != null) &&
                (vmParameters.StorageProfile != null) &&
                (vmParameters.StorageProfile.OsDisk != null))
            {
                return vmParameters.StorageProfile.OsDisk.EncryptionSettings;
            }
            return null;
        }

        private bool IsAzureDiskEncryptionExtension(OSType osType, VirtualMachineExtension vmExtension)
        {
            switch (osType)
            {
                case OSType.Windows:
                    if ((vmExtension != null) &&
                        (vmExtension.Publisher != null) &&
                        (vmExtension.VirtualMachineExtensionType != null) &&
                        (vmExtension.Publisher.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase)) &&
                        (vmExtension.VirtualMachineExtensionType.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        return true;
                    }

                    return false;
                case OSType.Linux:
                    if ((vmExtension != null) &&
                        (vmExtension.Publisher != null) &&
                        (vmExtension.VirtualMachineExtensionType != null) &&
                        (vmExtension.Publisher.Equals(AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase)) &&
                        (vmExtension.VirtualMachineExtensionType.Equals(AzureDiskEncryptionExtensionContext.LinuxExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        return true;
                    }

                    return false;
                case OSType.Unknown:
                    return false;
                default:
                    return false;
            }
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

        private EncryptionStatus AreDataVolumesEncrypted(VirtualMachine vmParameters)
        {
            if (vmParameters == null || vmParameters.Resources == null)
            {
                return EncryptionStatus.Unknown;
            }

            OSType osType = this.GetOSType(vmParameters);
            foreach (VirtualMachineExtension vmExtension in vmParameters.Resources)
            {
                switch (osType)
                {
                    case OSType.Windows:
                    case OSType.Linux:
                        if (IsAzureDiskEncryptionExtension(osType, vmExtension))
                        {
                            AzureDiskEncryptionExtensionContext adeExtension = new AzureDiskEncryptionExtensionContext(vmExtension.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName));
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
                        }
                        break;
                    case OSType.Unknown:
                        return EncryptionStatus.Unknown;
                    default:
                        return EncryptionStatus.Unknown;
                }
            }
            return EncryptionStatus.NotEncrypted;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                VirtualMachine vmParameters = (this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName));

                EncryptionStatus osVolumeEncrypted = IsOsVolumeEncrypted(vmParameters);
                DiskEncryptionSettings osVolumeEncryptionSettings = GetOsVolumeEncryptionSettings(vmParameters);
                EncryptionStatus dataVolumesEncrypted = AreDataVolumesEncrypted(vmParameters);
                AzureDiskEncryptionStatusContext encryptionStatus = null;
                string progressMessage = null;

                OSType osType = GetOSType(vmParameters);
                switch (osType)
                {
                    case OSType.Windows:                        
                        encryptionStatus = new AzureDiskEncryptionStatusContext
                        {
                            OsVolumeEncrypted = osVolumeEncrypted,
                            DataVolumesEncrypted = dataVolumesEncrypted,
                            OsVolumeEncryptionSettings = osVolumeEncryptionSettings,
                            ProgressMessage = string.Format(CultureInfo.CurrentUICulture, "OsVolume: {0}, DataVolumes: {1}", osVolumeEncrypted, dataVolumesEncrypted)
                        };
                        WriteObject(encryptionStatus);
                        break;
                    case OSType.Linux:
                        VirtualMachine virtualMachineResponse = this.ComputeClient.ComputeManagementClient.VirtualMachines.GetWithInstanceView(
                            this.ResourceGroupName, VMName).Body;
                        VirtualMachineExtension parameters = GetVmExtensionParameters(virtualMachineResponse, osType);

                        this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.VMName,
                            this.Name,
                            parameters).GetAwaiter().GetResult();

                        Dictionary<string, string> encryptionStatusParsed = null;
                        try
                        {
                            string encryptionStatusJson = GetExtensionStatusMessage(osType, returnSubstatusMessage: true);
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

                        try
                        {
                            progressMessage = GetExtensionStatusMessage(osType);
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
                        WriteObject(encryptionStatus);
                        break;
                    case OSType.Unknown:
                        ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture, "OS type unknown.")),
                                                      "InvalidResult",
                                                      ErrorCategory.InvalidResult,
                                                      null));
                        break;
                }
            });
        }
    }
}
