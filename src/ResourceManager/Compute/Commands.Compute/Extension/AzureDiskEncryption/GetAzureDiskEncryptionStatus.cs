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
using System;
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

                OSType osType = GetOSType(vmParameters);
                switch (osType)
                {
                    case OSType.Windows:
                    case OSType.Linux:
                        AzureDiskEncryptionStatusContext encryptionStatus = new AzureDiskEncryptionStatusContext
                        {
                            OsVolumeEncrypted = osVolumeEncrypted,
                            DataVolumesEncrypted = dataVolumesEncrypted,
                            OsVolumeEncryptionSettings = osVolumeEncryptionSettings
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
