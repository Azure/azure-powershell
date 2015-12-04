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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(
        VerbsCommon.Set,
        AzureOSDiskConfigurationNoun,
        DefaultParameterSetName = UpdateAzureVMImageParamSet),
    OutputType(
        typeof(VirtualMachineImageDiskConfigSet))]
    public class SetAzureVMImageOSDiskConfig : PSCmdlet
    {
        protected const string AzureOSDiskConfigurationNoun = "AzureVMImageOSDiskConfig";
        protected const string UpdateAzureVMImageParamSet = "UpdateAzureVMImageParamSet";
        protected const string AddAzureVMImageParamSet = "AddAzureVMImageParamSet";
        protected const string GeneralizedStr = "Generalized";
        protected const string SpecializedStr = "Specialized";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disk Configuration Set")]
        [ValidateNotNullOrEmpty]
        public VirtualMachineImageDiskConfigSet DiskConfig { get; set; }

        [Parameter(
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Controls the platform caching behavior of the OS disk blob for read efficiency.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("ReadOnly", "ReadWrite", IgnoreCase = true)]
        public string HostCaching { get; set; }

        [Parameter(
            ParameterSetName = AddAzureVMImageParamSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The media link.")]
        [ValidateNotNullOrEmpty]
        public Uri MediaLink { get; set; }

        [Parameter(
            ParameterSetName = AddAzureVMImageParamSet,
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The OS state.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(GeneralizedStr, SpecializedStr, IgnoreCase = true)]
        public string OSState { get; set; }

        [Parameter(
            ParameterSetName = AddAzureVMImageParamSet,
            Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The OS type.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Windows", "Linux", IgnoreCase = true)]
        public string OS { get; set; }

        protected override void ProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (DiskConfig.OSDiskConfiguration == null)
            {
                DiskConfig.OSDiskConfiguration = new OSDiskConfiguration();
            }

            DiskConfig.OSDiskConfiguration.HostCaching = this.HostCaching;
            DiskConfig.OSDiskConfiguration.MediaLink = this.MediaLink;
            DiskConfig.OSDiskConfiguration.OS = this.OS;
            DiskConfig.OSDiskConfiguration.OSState = this.OSState;

            WriteObject(DiskConfig);
        }
    }
}
