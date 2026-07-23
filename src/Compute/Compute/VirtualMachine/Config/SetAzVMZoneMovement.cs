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
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMZoneMovement"), OutputType(typeof(PSVirtualMachine))]
    public class SetAzVMZoneMovement : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
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
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies whether zone movement is enabled.")]
        public bool IsEnabled { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VM.ResiliencyProfile == null)
            {
                this.VM.ResiliencyProfile = new ResiliencyProfile();
            }

            if (this.VM.ResiliencyProfile.ZoneMovement == null)
            {
                this.VM.ResiliencyProfile.ZoneMovement = new ZoneMovement();
            }

            this.VM.ResiliencyProfile.ZoneMovement.IsEnabled = this.IsEnabled;

            WriteObject(this.VM);
        }
    }
}
