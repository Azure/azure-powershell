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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(
        VerbsCommon.Remove,
        AzureOSDiskConfigurationNoun),
    OutputType(
        typeof(VirtualMachineImageDiskConfigSet))]
    public class RemoveAzureVMImageOSDiskConfig : PSCmdlet
    {
        protected const string AzureOSDiskConfigurationNoun = "AzureVMImageOSDiskConfig";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disk Configuration Set")]
        [ValidateNotNullOrEmpty]
        public VirtualMachineImageDiskConfigSet DiskConfig { get; set; }

        protected override void ProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            DiskConfig.OSDiskConfiguration = null;
            WriteObject(DiskConfig);
        }
    }
}
