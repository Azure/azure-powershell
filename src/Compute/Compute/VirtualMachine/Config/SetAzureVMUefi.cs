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
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMUefi"), OutputType(typeof(PSVirtualMachine))]
    public class SetAzureVMUefi : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
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
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        public bool EnableVtpm { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        public bool EnableSecureBoot { get; set; }

        public override void ExecuteCmdlet()
        {
            if(this.VM.SecurityProfile == null)
            {
                this.VM.SecurityProfile = new SecurityProfile();
            }
            this.VM.SecurityProfile.UefiSettings = new UefiSettings
            {
                VTpmEnabled = this.EnableVtpm,
                SecureBootEnabled = this.EnableSecureBoot
            };

            WriteObject(this.VM);
        }
    }

}