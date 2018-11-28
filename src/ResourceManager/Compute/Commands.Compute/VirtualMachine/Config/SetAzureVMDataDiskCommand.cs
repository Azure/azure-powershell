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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
#if NETSTANDARD
    [CmdletOutputBreakingChange(typeof(PSVirtualMachineIdentity), DeprecatedOutputProperties = new string[] { "IdentityIds" })]
#endif
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMDataDisk"),OutputType(typeof(PSVirtualMachine))]
    public class SetAzureVMDataDiskCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        private const string NameParameterSet = "ChangeWithName";
        private const string LunParameterSet = "ChangeWithLun";

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = NameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = LunParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskLun)]
        [ValidateNotNullOrEmpty]
        public int? Lun { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskCaching)]
        public CachingTypes? Caching { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskSizeInGB)]
        [AllowNull]
        public int? DiskSizeInGB { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMManagedDiskAccountType)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard_LRS", "Premium_LRS", "StandardSSD_LRS", "UltraSSD_LRS")]
        public string StorageAccountType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        public SwitchParameter WriteAccelerator { get; set; }

        public override void ExecuteCmdlet()
        {
            var storageProfile = this.VM.StorageProfile;

            if (storageProfile == null || storageProfile.DataDisks == null)
            {
                ThrowDataDiskNotExistError();
            }

            var dataDisk = (this.ParameterSetName.Equals(LunParameterSet))
                ? storageProfile.DataDisks.SingleOrDefault(disk => disk.Lun == this.Lun)
                : storageProfile.DataDisks.SingleOrDefault(disk => disk.Name == this.Name);

            if (dataDisk == null)
            {
                ThrowDataDiskNotExistError();
            }
            else
            {
                if (this.Caching != null)
                {
                    dataDisk.Caching = this.Caching;
                }
                if (this.DiskSizeInGB != null)
                {
                    dataDisk.DiskSizeGB = this.DiskSizeInGB;
                }
                if (this.StorageAccountType != null)
                {
                    if (dataDisk.ManagedDisk == null)
                    {
                        ThrowTerminatingError
                            (new ErrorRecord(
                                new InvalidOperationException(Properties.Resources.NotManagedDisk),
                                string.Empty,
                                ErrorCategory.InvalidData,
                                null));
                    }
                    else
                    {
                        dataDisk.ManagedDisk.StorageAccountType = this.StorageAccountType;
                    }
                }

                dataDisk.WriteAcceleratorEnabled = this.WriteAccelerator.IsPresent;
            }

            this.VM.StorageProfile = storageProfile;

            WriteObject(this.VM);
        }

        private void ThrowDataDiskNotExistError()
        {
            var missingDisk = (this.ParameterSetName.Equals(LunParameterSet))
                   ? string.Format("LUN # {0}", this.Lun)
                   : "Name: " + this.Name;

            ThrowTerminatingError
                (new ErrorRecord(
                    new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        Microsoft.Azure.Commands.Compute.Properties.Resources.DataDiskNotAssignedForVM, missingDisk)),
                    string.Empty,
                    ErrorCategory.InvalidData,
                    null));
        }
    }
}
