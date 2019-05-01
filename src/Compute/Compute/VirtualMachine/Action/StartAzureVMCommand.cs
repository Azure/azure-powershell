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
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", DefaultParameterSetName = ResourceGroupNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class StartAzureVMCommand : VirtualMachineActionBaseCmdlet
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

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(Name, VerbsLifecycle.Start))
            {
                base.ExecuteCmdlet();
                ExecuteClientAction(() =>
                {
                    if (ParameterSetName.Equals(IdParameterSet) && string.IsNullOrEmpty(Name))
                    {
                        ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                        this.ResourceGroupName = parsedId.ResourceGroupName;
                        this.Name = parsedId.ResourceName;
                    }

                    var op = this.VirtualMachineClient.StartWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.Name).GetAwaiter().GetResult();
                    var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                    result.StartTime = this.StartTime;
                    result.EndTime = DateTime.Now;
                    WriteObject(result);
                });
            }
        }
    }
}
