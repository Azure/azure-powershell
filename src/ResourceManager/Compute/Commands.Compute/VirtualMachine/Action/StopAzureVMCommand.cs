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

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsLifecycle.Stop, ProfileNouns.VirtualMachine, DefaultParameterSetName = ResourceGroupNameParameterSet, 
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class StopAzureVMCommand : VirtualMachineActionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 1,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "To force the stopping.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "To keep the VM provisioned.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter StayProvisioned { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.ShouldProcess(Name, VerbsLifecycle.Stop) 
                    && (this.Force.IsPresent || this.ShouldContinue(Properties.Resources.VirtualMachineStoppingConfirmation, Properties.Resources.VirtualMachineStoppingCaption)))
                {
                    Action<Func<string, string, Dictionary<string, List<string>>, CancellationToken, Task<Rest.Azure.AzureOperationResponse>>> call = f =>
                    {
                        Rest.Azure.AzureOperationResponse op = f(this.ResourceGroupName, this.Name, null, CancellationToken.None).GetAwaiter().GetResult();
                        var result = Mapper.Map<PSComputeLongRunningOperation>(op);
                        WriteObject(result);
                    };

                    if (this.StayProvisioned)
                    {
                        call(this.VirtualMachineClient.PowerOffWithHttpMessagesAsync);
                    }
                    else
                    {
                        call(this.VirtualMachineClient.DeallocateWithHttpMessagesAsync);
                    }
                }
            });
        }
    }
}
