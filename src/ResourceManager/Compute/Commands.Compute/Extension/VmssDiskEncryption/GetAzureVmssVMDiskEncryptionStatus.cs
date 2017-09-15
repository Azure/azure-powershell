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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.AzureVmssVMDiskEncryptionStatus),
    OutputType(typeof(PSVmssVMDiskEncryptionStatusContext))]
    public class GetAzureVmssVMDiskEncryptionStatusCommand : VirtualMachineScaleSetExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource group name of the virtual machine scale set.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine scale set name.")]
        [ValidateNotNullOrEmpty]
        public string VMScaleSetName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        public string InstanceId { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The extension name. If this parameter is not specified, default values used are AzureDiskEncryption for windows VMs and AzureDiskEncryptionForLinux for Linux VMs")]
        [ValidateNotNullOrEmpty]
        public string ExtensionName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (string.IsNullOrWhiteSpace(this.InstanceId))
                {
                    var result = this.VirtualMachineScaleSetVMsClient.List(this.ResourceGroupName, this.VMScaleSetName);
                    List<VirtualMachineScaleSetVM> resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = VirtualMachineScaleSetVMsClient.ListNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }

                    var psResultList = new List<PSVmssVMDiskEncryptionStatusContextList>();
                    foreach (var vm in resultList)
                    {
                        var diskStatus = GetDiskStatus(this.ResourceGroupName, this.VMScaleSetName, vm.InstanceId);
                        var psResult = Mapper.Map<PSVmssVMDiskEncryptionStatusContextList>(diskStatus);
                        psResultList.Add(psResult);
                    }
                    WriteObject(psResultList);
                }
                else
                {
                    var psResult = GetDiskStatus(this.ResourceGroupName, this.VMScaleSetName, this.InstanceId);
                    WriteObject(psResult);
                }
            });
        }

        private PSVmssVMDiskEncryptionStatusContext GetDiskStatus(string rgName, string vmssName, string instanceID)
        {
            PSVmssVMDiskEncryptionStatusContext psResult = new PSVmssVMDiskEncryptionStatusContext
            {
                InstanceId = instanceID
            };

            var vmssVMInstanceView = this.VirtualMachineScaleSetVMsClient.GetInstanceView(rgName, vmssName, instanceID);
            var vmssVM = this.VirtualMachineScaleSetVMsClient.Get(rgName, vmssName, instanceID);

            SetOSType(vmssVM);

            if (string.IsNullOrWhiteSpace(this.ExtensionName))
            {
                this.ExtensionName = (this.CurrentOSType == OperatingSystemTypes.Windows)
                                     ? AzureVmssDiskEncryptionExtensionContext.ExtensionDefaultName
                                     : AzureVmssDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
            }

            psResult.Disks = new List<DiskInstanceView>();
            foreach (var disk in vmssVMInstanceView.Disks)
            {
                psResult.Disks.Add(disk);
            }

            psResult.OsVolumeEncrypted = GetOsDiskEncryptionStatus(psResult.Disks, vmssVM.StorageProfile);
            psResult.DataVolumesEncrypted = GetDataDiskEncryptionStatus(psResult.Disks, vmssVM.StorageProfile);

            try
            {
                psResult.Extension = vmssVMInstanceView.Extensions.First(e => e.Name.Equals(this.ExtensionName));
            }
            catch (InvalidOperationException)
            {
                psResult.DiskEncryptionStatus = string.Format("The Extension, {0}, is not installed.", this.ExtensionName);
            }

            if (psResult.Extension != null
            && psResult.Extension.Statuses != null
            && psResult.Extension.Statuses.Count > 0)
            {
                psResult.DiskEncryptionStatus = psResult.Extension.Statuses[0].DisplayStatus;
            }

            return psResult;
        }

        private EncryptionStatus GetOsDiskEncryptionStatus(List<DiskInstanceView> disks, StorageProfile storage)
        {
            if (storage == null || storage.OsDisk == null)
            {
                return EncryptionStatus.NotMounted;
            }

            InstanceViewStatus status = null;
            try
            {
                var disk = disks.First(e => e.Name.Equals(storage.OsDisk.Name));

                if (disk == null)
                {
                    return EncryptionStatus.Unknown;
                }
                status = disk.Statuses.First(s => s.Code.Contains(AzureVmssDiskEncryptionExtensionContext.EncryptionStateString));
            }
            catch (InvalidOperationException)
            {
                return EncryptionStatus.NotEncrypted;
            }

            return (status == null)
                ? EncryptionStatus.NotEncrypted
                : ConvertToEncryptionStatus(status.Code.Replace(AzureVmssDiskEncryptionExtensionContext.EncryptionStateString, ""));
        }

        private EncryptionStatus GetDataDiskEncryptionStatus(List<DiskInstanceView> disks, StorageProfile storage)
        {
            if (storage == null || storage.DataDisks == null || storage.DataDisks.Count == 0)
            {
                return EncryptionStatus.NotMounted;
            }

            InstanceViewStatus status = null;
            try
            {
                var disk = disks.First(e => e.Name.Equals(storage.DataDisks[0].Name));

                if (disk == null)
                {
                    return EncryptionStatus.Unknown;
                }

                status = disk.Statuses.First(s => s.Code.Contains(AzureVmssDiskEncryptionExtensionContext.EncryptionStateString));
            }
            catch (InvalidOperationException)
            {
                return EncryptionStatus.NotEncrypted;
            }

            return (status == null)
                ? EncryptionStatus.NotEncrypted
                : ConvertToEncryptionStatus(status.Code.Replace(AzureVmssDiskEncryptionExtensionContext.EncryptionStateString, ""));
        }

        private EncryptionStatus ConvertToEncryptionStatus(string encryptionStatusString)
        {
            string status_string = encryptionStatusString.ToLowerInvariant();
            switch (status_string)
            {
                case "notencrypted":
                    return EncryptionStatus.NotEncrypted;
                case "encrypted":
                    return EncryptionStatus.Encrypted;
                case "notmounted":
                    return EncryptionStatus.NotMounted;
                case "decryptioninprogress":
                    return EncryptionStatus.DecryptionInProgress;
                case "encryptioninprogress":
                    return EncryptionStatus.EncryptionInProgress;
                case "vmrestartpending":
                    return EncryptionStatus.VMRestartPending;
                default:
                    return EncryptionStatus.Unknown;
            }
        }
    }
}
