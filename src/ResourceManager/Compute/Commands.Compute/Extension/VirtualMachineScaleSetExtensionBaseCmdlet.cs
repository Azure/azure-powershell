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

using Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    public abstract class VirtualMachineScaleSetExtensionBaseCmdlet : ComputeClientBaseCmdlet
    {
        protected OperatingSystemTypes? CurrentOSType = null;

        public IVirtualMachineScaleSetsOperations VirtualMachineScaleSetClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineScaleSets;
            }
        }

        public IVirtualMachineScaleSetVMsOperations VirtualMachineScaleSetVMsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineScaleSetVMs;
            }
        }

        public IVirtualMachineScaleSetExtensionsOperations VirtualMachineScaleSetExtensionsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineScaleSetExtensions;
            }
        }

        protected void SetOSType(VirtualMachineScaleSetVMProfile vmProfile)
        {
            if (vmProfile.StorageProfile != null
                && vmProfile.StorageProfile.OsDisk != null
                && vmProfile.StorageProfile.OsDisk.OsType != null)
            {
                this.CurrentOSType = vmProfile.StorageProfile.OsDisk.OsType.Value;
            }
            else if (vmProfile.OsProfile != null
                && vmProfile.OsProfile.LinuxConfiguration != null)
            {
                this.CurrentOSType = OperatingSystemTypes.Linux;
            }
            else
            {
                this.CurrentOSType = OperatingSystemTypes.Windows;
            }
        }

        protected void SetOSType(VirtualMachineScaleSetVM vmProfile)
        {
            if (vmProfile.StorageProfile != null
                && vmProfile.StorageProfile.OsDisk != null
                && vmProfile.StorageProfile.OsDisk.OsType != null)
            {
                this.CurrentOSType = vmProfile.StorageProfile.OsDisk.OsType.Value;
            }
            else if (vmProfile.OsProfile != null
                && vmProfile.OsProfile.LinuxConfiguration != null)
            {
                this.CurrentOSType = OperatingSystemTypes.Linux;
            }
            else
            {
                this.CurrentOSType = OperatingSystemTypes.Windows;
            }
        }

        protected string GetVolumeType(string VolumeType, VirtualMachineScaleSetStorageProfile storageProfile)
        {
            if (string.IsNullOrWhiteSpace(VolumeType))
            {
                return this.CurrentOSType == OperatingSystemTypes.Windows 
                    ? AzureVmssDiskEncryptionExtensionContext.VolumeTypeAll 
                    : AzureVmssDiskEncryptionExtensionContext.VolumeTypeData;
            }
            else
            {
                return VolumeType;
            }
        }

        protected void ThrowInvalidArgumentError(string errorMessage, string arg)
        {
            ThrowTerminatingError
                (new ErrorRecord(
                    new ArgumentException(string.Format(CultureInfo.InvariantCulture,
                        errorMessage, arg)),
                    "InvalidArgument",
                    ErrorCategory.InvalidArgument,
                    null));
        }
    }
}
