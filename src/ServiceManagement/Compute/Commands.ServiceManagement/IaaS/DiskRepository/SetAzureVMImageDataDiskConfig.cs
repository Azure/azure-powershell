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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(
        VerbsCommon.Set,
        AzureDataDiskConfigurationNoun,
        DefaultParameterSetName = UpdateAzureVMImageParamSet),
    OutputType(
        typeof(VirtualMachineImageDiskConfigSet))]
    public class SetAzureVMImageDataDiskConfig : PSCmdlet
    {
        protected const string AzureDataDiskConfigurationNoun = "AzureVMImageDataDiskConfig";
        protected const string UpdateAzureVMImageParamSet = "UpdateAzureVMImageParamSet";
        protected const string AddAzureVMImageParamSet = "AddAzureVMImageParamSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disk Configuration Set")]
        [ValidateNotNullOrEmpty]
        public VirtualMachineImageDiskConfigSet DiskConfig { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureVMImageParamSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Data Disk Name")]
        [ValidateNotNullOrEmpty]
        public string DataDiskName { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureVMImageParamSet,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Lun")]
        [Parameter(
            ParameterSetName = AddAzureVMImageParamSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Lun")]
        [ValidateNotNullOrEmpty]
        public int Lun { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureVMImageParamSet,
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Controls the platform caching behavior of the data disk blob for read efficiency.")]
        [Parameter(
            ParameterSetName = AddAzureVMImageParamSet,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Controls the platform caching behavior of the data disk blob for read efficiency.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("ReadOnly", "ReadWrite", "None", IgnoreCase = true)]
        public string HostCaching { get; set; }

        [Parameter(
            ParameterSetName = AddAzureVMImageParamSet,
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The media link.")]
        [ValidateNotNullOrEmpty]
        public Uri MediaLink { get; set; }

        protected override void ProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (DiskConfig.DataDiskConfigurations == null)
            {
                DiskConfig.DataDiskConfigurations = new DataDiskConfigurationList();
            }

            var diskConfig = DiskConfig.DataDiskConfigurations.FirstOrDefault(
                d => this.ParameterSetName == UpdateAzureVMImageParamSet
                    ? string.Equals(d.Name, this.DataDiskName, StringComparison.OrdinalIgnoreCase)
                    : d.MediaLink == this.MediaLink);

            if (diskConfig == null)
            {
                diskConfig = new DataDiskConfiguration();
                DiskConfig.DataDiskConfigurations.Add(diskConfig);
            }

            diskConfig.Name = this.DataDiskName;
            diskConfig.HostCaching = this.HostCaching;
            diskConfig.Lun = this.Lun;
            diskConfig.MediaLink  = this.MediaLink;

            WriteObject(DiskConfig);
        }
    }
}
