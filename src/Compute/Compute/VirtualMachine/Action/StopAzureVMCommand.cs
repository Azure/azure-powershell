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
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", DefaultParameterSetName = ResourceGroupNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class StopAzureVMCommand : VirtualMachineActionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = ResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "To request non-graceful VM shutdown when keeping the VM provisioned.")]
        public SwitchParameter SkipShutdown { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.ShouldProcess(Name, VerbsLifecycle.Stop) 
                    && (this.Force.IsPresent || this.ShouldContinue(Properties.Resources.VirtualMachineStoppingConfirmation, Properties.Resources.VirtualMachineStoppingCaption)))
                {
                    if (ParameterSetName.Equals(IdParameterSet) && string.IsNullOrEmpty(Name))
                    {
                        ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                        this.ResourceGroupName = parsedId.ResourceGroupName;
                        this.Name = parsedId.ResourceName;
                    }

                    Rest.Azure.AzureOperationResponse op;

                    if (this.StayProvisioned)
                    {
                        bool? skipShutdown = this.SkipShutdown.IsPresent ? (bool?)true : null;
                        op = this.VirtualMachineClient.PowerOffWithHttpMessagesAsync(this.ResourceGroupName, this.Name, skipShutdown, null, CancellationToken.None).GetAwaiter().GetResult();
                    }
                    else
                    {
                        op = this.VirtualMachineClient.DeallocateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, null, CancellationToken.None).GetAwaiter().GetResult();
                    }

                    var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                    result.StartTime = this.StartTime;
                    result.EndTime = DateTime.Now;
                    WriteObject(result);
                }
                else
                {
                    WriteDebugWithTimestamp("[Stop-AureRmVMJob]: ShouldMethod returned false");
                }
            });
        }
    }
}
