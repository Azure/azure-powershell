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
using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure;
using Microsoft.Azure.Commands.Compute.Properties;
using PSM = Microsoft.Azure.Commands.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Remove, ProfileNouns.VirtualMachine)]
    public class RemoveAzureVMCommand : VirtualMachineBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "To force the removal.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Force.IsPresent
             || this.ShouldContinue(Resources.VirtualMachineRemovalConfirmation, Resources.VirtualMachineRemovalCaption))
            {
                var op = this.VirtualMachineClient.Delete(this.ResourceGroupName, this.Name);
                WriteObject(op);
            }
        }
    }
}
