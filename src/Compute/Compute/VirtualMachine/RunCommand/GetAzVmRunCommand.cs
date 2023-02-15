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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;


namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMRunCommand")]
    [OutputType(typeof(PSVirtualMachineRunCommand))]
    public class GetAzureVmRunCommand : ComputeAutomationBaseCmdlet
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of the resource group for the run command.")]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of the virtual machine of the run command.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        public string VMName { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Name of the run command.")]
        public string RunCommandName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "For instance view, pass in \"InstanceView\".")]
        [PSArgumentCompleter("InstanceView")]
        public string Expand { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {

                if (this.IsParameterBound(c => c.RunCommandName))
                {
                    VirtualMachineRunCommand vmRc = VirtualMachineRunCommandsClient.GetByVirtualMachine(this.ResourceGroupName, this.VMName, this.RunCommandName, this.Expand);
                    PSVirtualMachineRunCommand psObject = new PSVirtualMachineRunCommand();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<VirtualMachineRunCommand, PSVirtualMachineRunCommand>(vmRc, psObject);
                    WriteObject(psObject);
                }
                else
                {
                    var vmRc = VirtualMachineRunCommandsClient.ListByVirtualMachine(this.ResourceGroupName, this.VMName, this.Expand);
                    var resultList = vmRc.ToList();
                    var nextPageLink = vmRc.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = VirtualMachineRunCommandsClient.ListByVirtualMachineNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSVirtualMachineRunCommand>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<VirtualMachineRunCommand, PSVirtualMachineRunCommandList>(r));
                    }
                    WriteObject(psObject);
                }
            });
        }
    }
}
