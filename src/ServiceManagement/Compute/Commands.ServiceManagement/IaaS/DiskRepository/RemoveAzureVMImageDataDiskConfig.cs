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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(
        VerbsCommon.Remove,
        AzureDataDiskConfigurationNoun,
        DefaultParameterSetName = RemoveByDiskNameParamSet),
    OutputType(
        typeof(VirtualMachineImageDiskConfigSet))]
    public class RemoveAzureVMImageDataDiskConfig : PSCmdlet
    {
        protected const string AzureDataDiskConfigurationNoun = "AzureVMImageDataDiskConfig";
        protected const string RemoveByDiskNameParamSet = "RemoveByDiskName";
        protected const string RemoveByDiskLunParamSet = "RemoveByDiskLun";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disk Configuration Set")]
        [ValidateNotNullOrEmpty]
        public VirtualMachineImageDiskConfigSet DiskConfig { get; set; }

        [Parameter(
            ParameterSetName = RemoveByDiskNameParamSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Data Disk Name")]
        [ValidateNotNullOrEmpty]
        public string DataDiskName { get; set; }

        [Parameter(
            ParameterSetName = RemoveByDiskLunParamSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Data Disk Lun")]
        [ValidateNotNullOrEmpty]
        public int Lun { get; set; }

        protected override void ProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (DiskConfig.DataDiskConfigurations != null)
            {
                IEnumerable<DataDiskConfiguration> dataDisks = null;

                if (string.Equals(this.ParameterSetName, RemoveByDiskNameParamSet))
                {
                    dataDisks = DiskConfig.DataDiskConfigurations.Where(
                        d => !string.Equals(d.Name, this.DataDiskName, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    dataDisks = DiskConfig.DataDiskConfigurations.Where(
                        d => d.Lun != this.Lun
                    );
                }

                if (dataDisks != null)
                {
                    DiskConfig.DataDiskConfigurations = new DataDiskConfigurationList();
                    foreach (var dataDisk in dataDisks)
                    {
                        DiskConfig.DataDiskConfigurations.Add(dataDisk);
                    }
                }
            }

            WriteObject(DiskConfig);
        }
    }
}
