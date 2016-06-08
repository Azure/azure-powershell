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
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.DataDisk),
    OutputType(
        typeof(PSVirtualMachine))]
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
