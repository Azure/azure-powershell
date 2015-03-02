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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsData.Update, "AzureDisk"), OutputType(typeof(DiskContext))]
    public class UpdateAzureDiskCommand : ServiceManagementBaseCmdlet
    {
        public const string ResizeParameterSetName = "Resize";
        public const string NoResizeParameterSetName = "NoResize";

        [Parameter(Position = 0, ParameterSetName = ResizeParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the disk in the disk library.")]
        [Parameter(Position = 0, ParameterSetName = NoResizeParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the disk in the disk library.")]
        [ValidateNotNullOrEmpty]
        public string DiskName { get; set; }

        [Parameter(Position = 1, ParameterSetName = ResizeParameterSetName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Label of the disk.")]
        [Parameter(Position = 1, ParameterSetName = NoResizeParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Label of the disk.")]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(Position = 2,
            ParameterSetName = ResizeParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resizes the underlying blob to the indicated size in GB.")]
        [ValidateNotNullOrEmpty]
        public int ResizedSizeInGB { get; set; }

        internal void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();

            VirtualMachineDiskUpdateParameters parameters;

            if (this.ParameterSetName == NoResizeParameterSetName)
            {
                parameters = new VirtualMachineDiskUpdateParameters
                {
                    Name = this.DiskName,
                    Label = this.Label,
                };

                this.ExecuteClientActionNewSM(
                    null,
                    this.CommandRuntime.ToString(),
                    () => this.ComputeClient.VirtualMachineDisks.UpdateDisk(this.DiskName, parameters),
                    (s, response) => this.ContextFactory<VirtualMachineDiskUpdateResponse, DiskContext>(response, s));
            }
            else
            {
                if (this.Label == null)
                {
                    var currentDisk = this.ComputeClient.VirtualMachineDisks.GetDisk(this.DiskName);
                    Label = currentDisk.Label;
                }

                parameters = new VirtualMachineDiskUpdateParameters
                {
                    Name = this.DiskName,
                    Label = this.Label,
                    ResizedSizeInGB = this.ResizedSizeInGB,
                };

                this.ExecuteClientActionNewSM(
                    null,
                    this.CommandRuntime.ToString(),
                    () => this.ComputeClient.VirtualMachineDisks.UpdateDiskSize(this.DiskName, parameters));
            }
        }

        protected override void OnProcessRecord()
        {
            this.ExecuteCommand();
        }
    }
}
