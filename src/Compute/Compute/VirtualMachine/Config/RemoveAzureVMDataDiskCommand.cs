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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMDataDisk",SupportsShouldProcess = true),OutputType(typeof(PSVirtualMachine))]
    public class RemoveAzureVMDataDiskCommand : ComputeClientBaseCmdlet
    {
        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [ValidateNotNullOrEmpty]
        public string[] DataDiskNames { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Sets provided disks' detachOption property to ForceDetach. Only applicable for managed data disks.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ForceDetach { get; set; }

        public override void ExecuteCmdlet()
        {
            // DryRun interception (preview only, no mutation of the live VM object)
            if (this.DryRun.IsPresent && TryHandleDryRun(BuildDryRunPreviewScript()))
            {
                return;
            }

            if (this.ShouldProcess("DataDisk", VerbsCommon.Remove))
            {
                ApplyRemoval();
            }
        }

        private void ApplyRemoval()
        {
            var storageProfile = this.VM.StorageProfile;

            if (storageProfile != null && storageProfile.DataDisks != null)
            {
                var disks = storageProfile.DataDisks.ToList();
                var comp = StringComparison.OrdinalIgnoreCase;

                if (!this.ForceDetach.IsPresent)
                {
                    if (DataDiskNames == null || DataDiskNames.Length == 0)
                    {
                        disks.Clear();
                    }
                    else
                    {
                        foreach (var diskName in DataDiskNames)
                        {
                            disks.RemoveAll(d => string.Equals(d.Name, diskName, comp));
                        }
                    }
                }
                else
                {
                    if (this.DataDiskNames == null || DataDiskNames.Length == 0)
                    {
                        foreach (var disk in disks)
                        {
                            disk.DetachOption = "ForceDetach";
                            disk.ToBeDetached = true;
                        }
                    }
                    else
                    {
                        foreach (var disk in disks)
                        {
                            if (DataDiskNames.Contains(disk.Name, StringComparer.OrdinalIgnoreCase))
                            {
                                disk.ToBeDetached = true;
                                disk.DetachOption = "ForceDetach";
                            }
                        }
                    }
                }

                storageProfile.DataDisks = disks;
            }
            this.VM.StorageProfile = storageProfile;

            WriteObject(this.VM);
        }

        private string BuildDryRunPreviewScript()
        {
            try
            {
                string vmVar = GetVmVariableNameFromInvocation(); // Variable name used by user in -VM parameter (e.g. $myvm)
                string previewVar = vmVar;           // Name of the constructed preview object variable

                var lines = new List<string>();
                lines.Add("# DryRun preview: resulting " + vmVar + " (simplified) after Remove-AzVMDataDisk would execute");

                string vmName = VM?.Name ?? "<null>";
                string rgName = VM?.ResourceGroupName ?? "<null>";
                string vmId = VM?.Id ?? "<null>";

                // Build preview PowerShell object
                lines.Add(previewVar + " = [PSCustomObject]@{");
                lines.Add("    Name='" + vmName + "'");
                lines.Add("    ResourceGroupName='" + rgName + "'");
                lines.Add("    Id='" + vmId + "'");
                lines.Add("}" );
                lines.Add("# You can inspect" + previewVar + " to see the projected state.");
                lines.Add("# Original invocation follows:");

                return string.Join(Environment.NewLine, lines);
            }
            catch
            {
                return null;
            }
        }

        private string GetVmVariableNameFromInvocation()
        {
            try
            {
                var line = this.MyInvocation?.Line;
                if (!string.IsNullOrWhiteSpace(line))
                {
                    // Match variations like: -VM $myvm  OR  -VM:$myvm  OR  -VM $myvm -OtherParam
                    var m = Regex.Match(line, @"-VM\s*[:=]?\s*(\$[a-zA-Z_][a-zA-Z0-9_]*)");
                    if (m.Success)
                    {
                        return m.Groups[1].Value;
                    }
                }
            }
            catch { }
            return "$vm"; // Fallback default if parsing fails
        }

        private static Microsoft.Azure.Management.Compute.Models.DataDisk CloneDisk(Microsoft.Azure.Management.Compute.Models.DataDisk d)
        {
            if (d == null) return null;
            // Only copy fields needed for the preview
            return new Microsoft.Azure.Management.Compute.Models.DataDisk
            {
                Name = d.Name,
                Lun = d.Lun,
                CreateOption = d.CreateOption,
                DiskSizeGB = d.DiskSizeGB,
                Caching = d.Caching,
                Vhd = d.Vhd,
                Image = d.Image,
                ManagedDisk = d.ManagedDisk,
                WriteAcceleratorEnabled = d.WriteAcceleratorEnabled,
                ToBeDetached = d.ToBeDetached,
                DetachOption = d.DetachOption,
                DeleteOption = d.DeleteOption,
                SourceResource = d.SourceResource
            };
        }
    }
}
