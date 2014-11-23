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

using System.Collections.Generic;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Commands.Compute.Models;
using MCM = Microsoft.Azure.Management.Compute.Models;


namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.VirtualMachine)]
    [OutputType(typeof(VirtualMachine))]
    public class GetAzureVMCommand : VirtualMachineBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!string.IsNullOrEmpty(this.Name))
            {
                var result = this.VirtualMachineClient.Get(this.ResourceGroupName, this.Name);
                var vm = Mapper.Map<VirtualMachine>(result.VirtualMachine);
                WriteObject(vm);
            }
            else
            {
                var result = this.VirtualMachineClient.List(this.ResourceGroupName);
                var vmList = Mapper.Map<List<VirtualMachine>>(result.VirtualMachines);
                WriteObject(vmList, true);
            }
        }
    }
}
