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
using Microsoft.Rest.Azure;
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
                if (string.IsNullOrEmpty(this.ResourceGroupName) && string.IsNullOrEmpty(this.Name))
                {
                    AzureOperationResponse<IPage<VirtualMachine>> vmListResult = null;

                    if (this.NextLink != null)
                    {
                        vmListResult = this.VirtualMachineClient.ListAllNextWithHttpMessagesAsync(this.NextLink.ToString())
                            .GetAwaiter().GetResult();
                    }
                    else
                    {
                        vmListResult = this.VirtualMachineClient.ListAllWithHttpMessagesAsync().GetAwaiter().GetResult();
                    }

                    var psResultList = new List<PSVirtualMachine>();

                    while (vmListResult != null)
                    {
                        if (vmListResult.Body != null)
                        {
                            foreach (var item in vmListResult.Body)
                            {
                                var psItem = Mapper.Map<PSVirtualMachine>(item);
                                psItem = Mapper.Map(vmListResult, psItem);
                                psResultList.Add(psItem);
                            }
                        }

                        if (!string.IsNullOrEmpty(vmListResult.Body.NextPageLink))
                        {
                            vmListResult = this.VirtualMachineClient.ListAllNextWithHttpMessagesAsync(vmListResult.Body.NextPageLink)
                                 .GetAwaiter().GetResult();
                        }
                        else
                        {
                            vmListResult = null;
                        }
                    }

                    WriteObject(psResultList, true);
                }
                else if (!string.IsNullOrEmpty(this.Name))
                {
                    if (Status)
                    {
                        var result = this.VirtualMachineClient.Get(this.ResourceGroupName, this.Name, InstanceViewExpand);
                        WriteObject(result.ToPSVirtualMachineInstanceView(this.ResourceGroupName, this.Name));
                    }
                    else
                    {
                        var result = this.VirtualMachineClient.GetWithHttpMessagesAsync(
                            this.ResourceGroupName, this.Name).GetAwaiter().GetResult();

                        var psResult = Mapper.Map<PSVirtualMachine>(result);
                        if (result.Body != null)
                        {
                            psResult = Mapper.Map(result.Body, psResult);
                        }
                        WriteObject(psResult);
                    }
                }
                else
                {
                    AzureOperationResponse<IPage<VirtualMachine>> vmListResult = null;
                    vmListResult = this.VirtualMachineClient.ListWithHttpMessagesAsync(this.ResourceGroupName)
                            .GetAwaiter().GetResult();
                    var psResultList = new List<PSVirtualMachine>();
                    if (vmListResult.Body != null)
                    {
                        foreach (var item in vmListResult.Body)
                        {
                            var psItem = Mapper.Map<PSVirtualMachine>(vmListResult);
                            psItem = Mapper.Map(item, psItem);
                            psResultList.Add(psItem);
                        }
                    }
                    WriteObject(psResultList, true);
                }
            });
        }
    }
}
