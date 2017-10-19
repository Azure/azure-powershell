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

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet(
        VerbsLifecycle.Disable  ,
        ProfileNouns.AzureVmssDiskEncryption,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachineScaleSet))]
    public class RemoveAzureVmssDiskEncryptionCommand : VirtualMachineScaleSetExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMScaleSetName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name. If this parameter is not specified, default values used are AzureDiskEncryption for windows VMs and AzureDiskEncryptionForLinux for Linux VMs")]
        [ValidateNotNullOrEmpty]
        public string ExtensionName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Type of the volume (OS or Data) to perform encryption operation")]
        [ValidateSet(
            AzureVmssDiskEncryptionExtensionContext.VolumeTypeOS,
            AzureVmssDiskEncryptionExtensionContext.VolumeTypeData,
            AzureVmssDiskEncryptionExtensionContext.VolumeTypeAll)]
        public string VolumeType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Generate a tag for force update.  This should be given to perform repeated encryption operations on the same VM.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ForceUpdate { get; set; }

        [Parameter(HelpMessage = "To force the removal of the extension from the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.ShouldProcess(VMScaleSetName, Properties.Resources.RemoveDiskEncryptionAction)
                    && (this.Force.IsPresent
                    || this.ShouldContinue(Properties.Resources.VirtualMachineExtensionRemovalConfirmation, Properties.Resources.VirtualMachineExtensionRemovalCaption)))
                {
                    VirtualMachineScaleSet vmss = this.VirtualMachineScaleSetClient.Get(this.ResourceGroupName, this.VMScaleSetName);

                    if (vmss == null || vmss.VirtualMachineProfile == null)
                    {
                        ThrowTerminatingError(new ErrorRecord(
                            new ArgumentException("The given VM Scale Set does not exist."),
                            "InvalidArgument",
                            ErrorCategory.InvalidArgument,
                            null));
                    }

                    SetOSType(vmss.VirtualMachineProfile);

                    if (OperatingSystemTypes.Windows.Equals(this.CurrentOSType))
                    {
                        this.ExtensionName = this.ExtensionName ?? AzureVmssDiskEncryptionExtensionContext.ExtensionDefaultName;
                    }
                    else if (OperatingSystemTypes.Linux.Equals(this.CurrentOSType))
                    {
                        this.ExtensionName = this.ExtensionName ?? AzureVmssDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                    }

                    this.VolumeType = GetVolumeType(this.VolumeType, vmss.VirtualMachineProfile.StorageProfile);

                    if (vmss.VirtualMachineProfile.ExtensionProfile == null
                       || vmss.VirtualMachineProfile.ExtensionProfile.Extensions == null
                       || vmss.VirtualMachineProfile.ExtensionProfile.Extensions.Count == 0)
                    {
                        ThrowTerminatingError(new ErrorRecord(
                            new ArgumentException("Disk Encryption extension is not installed in the VM Scale Set."),
                            "InvalidArgument",
                            ErrorCategory.InvalidArgument,
                            null));
                    }

                    foreach (var ext in vmss.VirtualMachineProfile.ExtensionProfile.Extensions)
                    {
                        if (ext.Name.Equals(this.ExtensionName))
                        {
                            ext.Settings = GetDisalbeEncryptionSetting();
                            ext.ProtectedSettings = null;
                            ext.ForceUpdateTag = this.ForceUpdate.IsPresent ? Guid.NewGuid().ToString() : null;

                            VirtualMachineScaleSetExtension result = this.VirtualMachineScaleSetExtensionsClient.CreateOrUpdate(
                                this.ResourceGroupName,
                                this.VMScaleSetName,
                                this.ExtensionName,
                                ext);
                            var psResult = result.ToPSVirtualMachineScaleSetExtension(this.ResourceGroupName, this.VMScaleSetName);
                            WriteObject(psResult);
                            break;
                        }

                        ThrowTerminatingError(new ErrorRecord(
                            new ArgumentException(string.Format("Extension, {0},  is not installed in the VM Scale Set.", this.ExtensionName)),
                            "InvalidArgument",
                            ErrorCategory.InvalidArgument,
                            null));
                    }
                }
            });
        }

        private Hashtable GetDisalbeEncryptionSetting()
        {
            Hashtable publicSettings = new Hashtable();
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.volumeTypeKey, this.VolumeType ?? string.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.encryptionOperationKey, AzureDiskEncryptionExtensionConstants.disableEncryptionOperation);

            return publicSettings;
        }
    }
}
