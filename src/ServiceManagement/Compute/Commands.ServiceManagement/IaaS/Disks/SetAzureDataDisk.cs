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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Set, ProfileNouns.DataDisk), OutputType(typeof(IPersistentVM))]
    public class SetAzureDataDiskCommand : VirtualMachineConfigurationCmdletBase
    {
        private const string ResizeParameterSet = "Resize";
        private const string NoResizeParameteSet = "NoResize";

        [Parameter(Position = 0,
            ParameterSetName = NoResizeParameteSet,
            Mandatory = true,
            HelpMessage = "Controls the platform caching behavior of data disk blob for read efficiency.")]
        [ValidateSet("None", "ReadOnly", "ReadWrite", IgnoreCase = true)]
        public string HostCaching
        {
            get;
            set;
        }

        [Parameter(Position = 1,
            ParameterSetName = NoResizeParameteSet,
            Mandatory = true,
            HelpMessage = "Numerical value that defines the slot where the data drive will be mounted in the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public int LUN
        {
            get;
            set;
        }

        [Parameter(Position = 3,
            ParameterSetName = ResizeParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The Name of the DataDiskConfiguration being referenced to")]
        [ValidateNotNullOrEmpty]
        public string DiskName
        {
            get;
            set;
        }

        [Parameter(Position = 4,
            ParameterSetName = ResizeParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Resize the new data disk to a larger size.")]
        [ValidateNotNullOrEmpty]
        public int ResizedSizeInGB
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            if (this.ParameterSetName == NoResizeParameteSet)
            {
                var dataDisks = GetDataDisks();
                var dataDisk = dataDisks.SingleOrDefault(disk => disk.Lun == LUN);

                if (dataDisk == null)
                {
                    ThrowTerminatingError(
                        new ErrorRecord(
                                new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.DataDiskNotAssignedForVM, this.LUN)),
                                string.Empty,
                                ErrorCategory.InvalidData,
                                null));
                }

                dataDisk.HostCaching = HostCaching;
            }
            else
            {
                PersistentVM role = VM.GetInstance();

                if (role.VMImageInput == null)
                {
                    role.VMImageInput = new VMImageInput();
                }

                if (role.VMImageInput.DataDiskConfigurations == null)
                {
                    role.VMImageInput.DataDiskConfigurations = new DataDiskConfigurationList();
                };

                bool diskNameAlreadyExist = false;

                foreach (var dataDiskConfig in role.VMImageInput.DataDiskConfigurations)
                {
                    if (string.Equals(dataDiskConfig.Name, this.DiskName, StringComparison.OrdinalIgnoreCase))
                    {
                        dataDiskConfig.ResizedSizeInGB = this.ResizedSizeInGB;
                        diskNameAlreadyExist = true;
                    }
                }

                if (! diskNameAlreadyExist)
                {
                    role.VMImageInput.DataDiskConfigurations.Add(
                    new DataDiskConfiguration()
                    {
                        Name = this.DiskName,
                        ResizedSizeInGB = this.ResizedSizeInGB,
                    });
                }
            }

            WriteObject(VM, true);
        }

        protected override void ProcessRecord()
        {
            try
            {
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
    }
}