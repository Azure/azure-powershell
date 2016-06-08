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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Add, ProfileNouns.DataDisk, DefaultParameterSetName = "CreateNew"), OutputType(typeof(IPersistentVM))]
    public class AddAzureDataDiskCommand : VirtualMachineConfigurationCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "CreateNew", HelpMessage = "Specify to create a new data disk.")]
        public SwitchParameter CreateNew
        {
            get;
            set;
        }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Import", HelpMessage = "Specify to import an existing data disk from the disk library.")]
        public SwitchParameter Import
        {
            get;
            set;
        }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "ImportFrom", HelpMessage = "Specify to import an existing data disk from a storage location.")]
        public SwitchParameter ImportFrom
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = "Import", ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the data disk in the disk library.")]
        [ValidateNotNullOrEmpty]
        public string DiskName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = "CreateNew", HelpMessage = "Logical disk size in gigabytes.")]
        [ValidateNotNullOrEmpty]
        public int DiskSizeInGB
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = "CreateNew", HelpMessage = "Label of the disk.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = "ImportFrom", HelpMessage = "Label of the disk.")]
        [ValidateNotNullOrEmpty]
        public string DiskLabel
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "Numerical value that defines the slot where the data drive will be mounted in the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public int LUN
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = "CreateNew", ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the physical blob backing the data disk to be created.")]
        [Parameter(Mandatory = true, ParameterSetName = "ImportFrom", ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the physical blob backing the data disk. This link refers to a blob in a storage account.")]
        [ValidateNotNullOrEmpty]
        public string MediaLocation
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Controls the platform caching behavior of data disk blob for read efficiency.")]
        [ValidateSet("ReadOnly", "ReadWrite", "None", IgnoreCase = true)]
        public string HostCaching
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            var dataDisks = GetDataDisks();
            var dataDisk = dataDisks.SingleOrDefault(disk => disk.Lun == LUN);

            if (dataDisk != null)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.DataDiskAlreadySpecifiedForVM, this.LUN)),
                            string.Empty,
                            ErrorCategory.InvalidData,
                            null));
            }

            dataDisk = new DataVirtualHardDisk { HostCaching = HostCaching, Lun = LUN };

            switch (ParameterSetName)
            {
                case "CreateNew":
                    dataDisk.DiskLabel = DiskLabel;
                    dataDisk.LogicalDiskSizeInGB = DiskSizeInGB;
                    dataDisk.MediaLink = string.IsNullOrEmpty(MediaLocation) ? null : new Uri(MediaLocation);
                    break;
                case "Import":
                    dataDisk.DiskName = DiskName;
                    break;
                case "ImportFrom":
                    dataDisk.DiskName = DiskName;
                    dataDisk.SourceMediaLink = string.IsNullOrEmpty(MediaLocation) ? null : new Uri(MediaLocation);
                    break;
            }

            dataDisks.Add(dataDisk);

            WriteObject(VM, true);
        }

        protected override void ProcessRecord()
        {
            try
            {
                ValidateParameters();
                base.ProcessRecord();
                ExecuteCommand();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        protected Collection<DataVirtualHardDisk> GetDataDisks()
        {
            var role = VM.GetInstance();

            if (role.DataVirtualHardDisks == null)
            {
                role.DataVirtualHardDisks = new Collection<DataVirtualHardDisk>();
            }

            return role.DataVirtualHardDisks;
        }

        protected void ValidateParameters()
        {
            var currentSubscription = Profile.Context.Subscription;
            if ((currentSubscription == null || currentSubscription.GetProperty(AzureSubscription.Property.StorageAccount) == null) && this.MediaLocation == null && string.Compare(this.ParameterSetName, "CreateNew", StringComparison.OrdinalIgnoreCase) == 0)
            {
                throw new ArgumentException(Resources.MediaLocationOrDefaultStorageAccountMustBeSpecified);
            }
        }
    }
}