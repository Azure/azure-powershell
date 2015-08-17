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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.VirtualMachine, DefaultParameterSetName = ListAllVirtualMachinesParamSet)]
    [OutputType(typeof(PSVirtualMachine), typeof(PSVirtualMachineInstanceView))]
    public class GetAzureVMCommand : VirtualMachineBaseCmdlet
    {
        protected const string GetVirtualMachineInResourceGroupParamSet = "GetVirtualMachineInResourceGroupParamSet";
        protected const string ListVirtualMachineInResourceGroupParamSet = "ListVirtualMachineInResourceGroupParamSet";
        protected const string ListAllVirtualMachinesParamSet = "ListAllVirtualMachinesParamSet";
        protected const string ListNextLinkVirtualMachinesParamSet = "ListNextLinkVirtualMachinesParamSet";

        [Parameter(
           Mandatory = true,
           Position = 0,
            ParameterSetName = ListVirtualMachineInResourceGroupParamSet,
           ValueFromPipelineByPropertyName = true)]
        [Parameter(
           Mandatory = true,
           Position = 0,
            ParameterSetName = GetVirtualMachineInResourceGroupParamSet,
           ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VMName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = GetVirtualMachineInResourceGroupParamSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = GetVirtualMachineInResourceGroupParamSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = ListNextLinkVirtualMachinesParamSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Uri NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (!string.IsNullOrEmpty(this.Name))
                {
                    if (Status)
                    {
                        var result = this.VirtualMachineClient.GetWithInstanceView(this.ResourceGroupName, this.Name);
                        WriteObject(result.ToPSVirtualMachineInstanceView(this.ResourceGroupName, this.Name));
                    }
                    else
                    {
                        var result = this.VirtualMachineClient.Get(this.ResourceGroupName, this.Name);
                        var psResult = Mapper.Map<PSVirtualMachine>(result.VirtualMachine);
                        psResult = Mapper.Map<AzureOperationResponse, PSVirtualMachine>(result, psResult);
                        WriteObject(psResult);
                    }
                }
                else
                {
                    VirtualMachineListResponse vmListResult = null;
                    if (!string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        vmListResult = this.VirtualMachineClient.List(this.ResourceGroupName);
                    }
                    else if (this.NextLink != null)
                    {
                        vmListResult = this.VirtualMachineClient.ListNext(this.NextLink.ToString());
                    }
                    else
                    {
                        var listParams = new ListParameters();
                        vmListResult = this.VirtualMachineClient.ListAll(listParams);
                    }

                    var psResultList = new List<PSVirtualMachine>();

                    while (vmListResult != null)
                    {
                        if (vmListResult.VirtualMachines != null)
                        {
                            foreach (var item in vmListResult.VirtualMachines)
                            {
                                var psItem = Mapper.Map<PSVirtualMachine>(item);
                                psItem = Mapper.Map<AzureOperationResponse, PSVirtualMachine>(vmListResult, psItem);
                                psResultList.Add(psItem);
                            }
                        }

                        if (!string.IsNullOrEmpty(vmListResult.NextLink))
                        {
                            vmListResult = this.VirtualMachineClient.ListNext(vmListResult.NextLink);
                        }
                        else
                        {
                            vmListResult = null;
                        }
                    }

                    WriteObject(psResultList, true);
                }
            });
        }
    }
}
