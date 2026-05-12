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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssLifecycleHookEvent", DefaultParameterSetName = ListParameterSet)]
    [OutputType(typeof(VMScaleSetLifecycleHookEvent))]
    public class GetAzureRmVmssLifecycleHookEventCommand : ComputeAutomationBaseCmdlet
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetParameterSet = "GetParameterSet";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ListParameterSet,
            HelpMessage = "The name of the resource group.")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetParameterSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ListParameterSet,
            HelpMessage = "The name of the VM scale set.")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetParameterSet,
            HelpMessage = "The name of the VM scale set.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachineScaleSets", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [Alias("VMScaleSetName")]
        public string VMScaleSetName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetParameterSet,
            HelpMessage = "The name (GUID) of the lifecycle hook event to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (this.ParameterSetName.Equals(GetParameterSet))
                {
                    var result = VirtualMachineScaleSetLifeCycleHookEventsClient.Get(
                        this.ResourceGroupName,
                        this.VMScaleSetName,
                        this.Name);
                    WriteObject(result);
                }
                else
                {
                    var result = VirtualMachineScaleSetLifeCycleHookEventsClient.List(
                        this.ResourceGroupName,
                        this.VMScaleSetName);
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = VirtualMachineScaleSetLifeCycleHookEventsClient.ListNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    WriteObject(resultList, true);
                }
            });
        }
    }
}
