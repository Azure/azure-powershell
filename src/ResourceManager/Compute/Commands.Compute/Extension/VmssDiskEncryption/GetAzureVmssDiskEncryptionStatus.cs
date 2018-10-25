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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssDiskEncryption"), OutputType(typeof(PSVmssDiskEncryptionStatusContext))]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssDiskEncryptionStatus")]
    public class GetAzureVmssDiskEncryptionStatusCommand : VirtualMachineScaleSetExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = false,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource group name of the virtual machine scale set.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine scale set name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachineScaleSets", "ResourceGroupName")]
        public string VMScaleSetName { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The extension name. If this parameter is not specified, defaults to AzureDiskEncryption for Windows and AzureDiskEncryptionForLinux for Linux.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachineScaleSets/extensions", "ResourceGroupName", "VMScaleSetName")]
        [ValidateNotNullOrEmpty]
        public string ExtensionName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (!string.IsNullOrWhiteSpace(this.ResourceGroupName) && !string.IsNullOrWhiteSpace(this.VMScaleSetName))
                {
                    var psResult = GetVmssDiskStatus(this.ResourceGroupName, this.VMScaleSetName);
                    WriteObject(psResult);
                }
                else
                {
                    IPage<VirtualMachineScaleSet> result;
                    if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
                    {
                        result = this.VirtualMachineScaleSetClient.ListAll();
                    }
                    else
                    {
                        result = this.VirtualMachineScaleSetClient.List(this.ResourceGroupName);
                    }

                    List<VirtualMachineScaleSet> resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = VirtualMachineScaleSetClient.ListNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }

                    var psResultList = new List<PSVmssDiskEncryptionStatusContextList>();
                    foreach (var vmss in resultList)
                    {
                        Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
                        Match m = r.Match(vmss.Id);
                        var vmssDiskStatus = GetVmssDiskStatus(m.Groups["rgname"].Value, vmss.Name);
                        var psResult = ComputeAutoMapperProfile.Mapper.Map<PSVmssDiskEncryptionStatusContextList>(vmssDiskStatus);
                        psResultList.Add(psResult);
                    }

                    WriteObject(psResultList, true);
                }
            });
        }

        private PSVmssDiskEncryptionStatusContext GetVmssDiskStatus(string rgName, string vmssName)
        {
            VirtualMachineScaleSetExtension ext;
            VirtualMachineScaleSetVMExtensionsSummary extSummary;
            PSVmssDiskEncryptionStatusContext psResult = new PSVmssDiskEncryptionStatusContext
            {
                ResourceGroupName = rgName,
                VmScaleSetName = vmssName,
                EncryptionEnabled = false,
                EncryptionExtensionInstalled = false
            };

            var vmssResult = this.VirtualMachineScaleSetClient.Get(rgName, vmssName);
            if (vmssResult.VirtualMachineProfile == null
                || vmssResult.VirtualMachineProfile.ExtensionProfile == null
                || vmssResult.VirtualMachineProfile.ExtensionProfile.Extensions == null
                || vmssResult.VirtualMachineProfile.ExtensionProfile.Extensions.Count == 0)
            {
                return psResult;
            }

            // retrieve installation status of the extension 
            SetOSType(vmssResult.VirtualMachineProfile);
            try
            {
                if (string.IsNullOrWhiteSpace(this.ExtensionName))
                {
                    if (this.CurrentOSType == OperatingSystemTypes.Windows)
                    {
                        this.ExtensionName = AzureVmssDiskEncryptionExtensionContext.ExtensionDefaultName;
                    }
                    else
                    {
                        this.ExtensionName = AzureVmssDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                    }
                }

                ext = vmssResult.VirtualMachineProfile.ExtensionProfile.Extensions.First(
                         e => e.Type.Equals(this.ExtensionName));
            }
            catch (InvalidOperationException)
            {
                return psResult;
            }
            psResult.EncryptionExtensionInstalled = true;

            // retrieve public configuration settings for the extension
            psResult.EncryptionSettings = JsonConvert.DeserializeObject<AzureVmssDiskEncryptionExtensionPublicSettings>(
                ext.Settings.ToString());

            // retrieve any status summary for the extension 
            var vmssInstanceView = this.VirtualMachineScaleSetClient.GetInstanceView(rgName, vmssName);
            if (vmssInstanceView.Extensions == null
                || vmssInstanceView.Extensions.Count == 0)
            {
                return psResult;
            }
            try
            {
                extSummary = vmssInstanceView.Extensions.First(e => e.Name.Equals(this.ExtensionName));
            }
            catch (InvalidOperationException)
            {
                return psResult;
            }
            psResult.EncryptionSummary = extSummary.StatusesSummary;

            // check if encryption is enabled on any disk in the scale set 
            // stop evaluation at the first occurrence of an encrypted disk 
            var page = this.VirtualMachineScaleSetVMsClient.List(rgName, vmssName);
            while (!psResult.EncryptionEnabled && page!=null)
            { 
                foreach (var pageItem in page)
                {
                    if (psResult.EncryptionEnabled) break;
                    VirtualMachineScaleSetVMInstanceView vmiv = this.VirtualMachineScaleSetVMsClient.GetInstanceView(rgName, vmssName, pageItem.InstanceId);
                    if (vmiv != null && vmiv.Disks != null)
                    {
                        foreach (DiskInstanceView div in vmiv.Disks)
                        {
                            List<InstanceViewStatus> perDiskEncryptionStatuses = new List<InstanceViewStatus>();
                            bool isEncrypted = false;
                            foreach (InstanceViewStatus ivs in div.Statuses)
                            {
                                if (ivs != null && ivs.Code != null && ivs.Code.StartsWith("EncryptionState"))
                                {
                                    if (!psResult.EncryptionEnabled)
                                    {
                                        isEncrypted = ivs.Code.Equals("EncryptionState/encrypted");
                                    }
                                }
                            }
                            if (isEncrypted)
                            {
                                psResult.EncryptionEnabled = true;
                                break;
                            }
                        }
                    }
                }
                // advance to the next page as needed
                page = (page.NextPageLink != null) ? VirtualMachineScaleSetVMsClient.ListNext(page.NextPageLink) : null;
            }

            return psResult;
        }
    }
}
