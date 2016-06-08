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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Add, "AzureDisk"), OutputType(typeof(DiskContext))]
    public class AddAzureDiskCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the disk in the disk library.")]
        [ValidateNotNullOrEmpty]
        public string DiskName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the physical blob backing the disk. This link refers to a blob in a storage account.")]
        [ValidateNotNullOrEmpty]
        public string MediaLocation { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Label of the disk.")]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "OS on Disk.")]
        [ValidateNotNullOrEmpty]
        public string OS { get; set; }

        public void ExecuteCommand()
        {
            var parameters = new VirtualMachineDiskCreateParameters
            {
                Name = this.DiskName,
                MediaLinkUri = new Uri(this.MediaLocation),
                OperatingSystemType = this.OS,
                Label = string.IsNullOrEmpty(this.Label) ? this.DiskName : this.Label
            };

            this.ExecuteClientActionNewSM(
                null,
                this.CommandRuntime.ToString(),
                () => this.ComputeClient.VirtualMachineDisks.CreateDisk(parameters),
                (s, response) => this.ContextFactory<VirtualMachineDiskCreateResponse, DiskContext>(response, s));
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            this.ExecuteCommand();
        }
    }
}
