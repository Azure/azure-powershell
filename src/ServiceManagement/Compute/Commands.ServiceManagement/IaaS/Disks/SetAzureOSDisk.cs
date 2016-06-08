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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Set, ProfileNouns.OsDisk), OutputType(typeof(IPersistentVM))]
    public class SetAzureOSDiskCommand : VirtualMachineConfigurationCmdletBase
    {
        private const string ResizeParameterSet = "Resize";
        private const string NoResizeParameteSet = "NoResize";

        [Parameter(Position = 0, ParameterSetName = NoResizeParameteSet, Mandatory = true, HelpMessage = "Controls the platform caching behavior of data disk blob for read / write efficiency.")]
        [Parameter(Position = 0, ParameterSetName = ResizeParameterSet, Mandatory = false, HelpMessage = "Controls the platform caching behavior of data disk blob for read / write efficiency.")]
        [ValidateSet("ReadOnly", "ReadWrite", IgnoreCase = true)]
        public string HostCaching
        {
            get;
            set;
        }

        [Parameter(Position = 1,
            ParameterSetName = ResizeParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Resize the new OS Disk to a larger size.")]
        [ValidateNotNullOrEmpty]
        public int ResizedSizeInGB
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            var role = VM.GetInstance();

            if (role.OSVirtualHardDisk == null)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                            new InvalidOperationException(Resources.OSDiskNotDefinedForVM),
                            string.Empty,
                            ErrorCategory.InvalidData,
                            null));
            }

            role.OSVirtualHardDisk.HostCaching = HostCaching;
            if (this.ParameterSetName.Equals(ResizeParameterSet))
            {
                role.OSVirtualHardDisk.ResizedSizeInGB = this.ResizedSizeInGB;

                if (role.VMImageInput == null)
                {
                    role.VMImageInput = new VMImageInput();
                }

                if (role.VMImageInput.OSDiskConfiguration == null)
                {
                    role.VMImageInput.OSDiskConfiguration = new OSDiskConfiguration();
                };

                role.VMImageInput.OSDiskConfiguration.ResizedSizeInGB = this.ResizedSizeInGB;
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
    }
}