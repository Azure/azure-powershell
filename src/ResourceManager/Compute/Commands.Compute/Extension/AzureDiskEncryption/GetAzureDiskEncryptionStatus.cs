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
using System;
using System.Management.Automation;
using Microsoft.Azure.Management.Compute.Models;
using System.Globalization;

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

        private bool IsOsVolumeEncrypted(VirtualMachine vmParameters)
        {
            return (GetOsVolumeEncryptionSettings(vmParameters) != null);
        }

        private DiskEncryptionSettings GetOsVolumeEncryptionSettings(VirtualMachine vmParameters)
        {
            if ((vmParameters != null) &&
                (vmParameters.StorageProfile != null) &&
                (vmParameters.StorageProfile.OSDisk != null))
            {
                return vmParameters.StorageProfile.OSDisk.EncryptionSettings;
            }
            return null;
        }
        private bool IsAzureDiskEncryptionExtension(VirtualMachineExtension vmExtension)
        {
            if ((vmExtension != null) &&
                (vmExtension.Publisher != null) &&
                (vmExtension.ExtensionType != null) &&
                (vmExtension.Publisher.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase)) &&
                (vmExtension.ExtensionType.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase)))
            {
                return true;
            }

            return false;
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
            VirtualMachineExtensionGetResponse extensionStatusViewresult = this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName, this.VMName, adeExtension.Name);
            PSVirtualMachineExtension extensionStatusView = extensionStatusViewresult.ToPSVirtualMachineExtension(this.ResourceGroupName);
            AzureDiskEncryptionExtensionContext adeExtensionWithStatus = new AzureDiskEncryptionExtensionContext(extensionStatusView);
            if (adeExtensionWithStatus.ProvisioningState.Equals(AzureDiskEncryptionExtensionContext.StatusSucceeded, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private bool AreDataVolumesEncrypted(VirtualMachine vmParameters)
        {
            if (vmParameters == null || vmParameters.Extensions == null)
            {
                return false;
            }

            foreach (VirtualMachineExtension vmExtension in vmParameters.Extensions)
            {
                if (IsAzureDiskEncryptionExtension(vmExtension))
                {
                    AzureDiskEncryptionExtensionContext adeExtension = new AzureDiskEncryptionExtensionContext(vmExtension.ToPSVirtualMachineExtension(this.ResourceGroupName));
                    if (DataVolumeInExtensionConfig(adeExtension))
                    {
                        if (ExtensionProvisioningSucceeded(adeExtension))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                VirtualMachine vmParameters = (this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName)).VirtualMachine;

                bool osVolumeEncrypted = IsOsVolumeEncrypted(vmParameters);
                DiskEncryptionSettings osVolumeEncryptionSettings = GetOsVolumeEncryptionSettings(vmParameters);
                bool dataVolumesEncrypted = AreDataVolumesEncrypted(vmParameters);

                AzureDiskEncryptionStatusContext encryptionStatus = new AzureDiskEncryptionStatusContext
                {
                    OsVolumeEncrypted = osVolumeEncrypted,
                    OsVolumeEncryptionSettings = osVolumeEncryptionSettings,
                    DataVolumesEncrypted = dataVolumesEncrypted
                };
                WriteObject(encryptionStatus);
            });

        }
    }
}
