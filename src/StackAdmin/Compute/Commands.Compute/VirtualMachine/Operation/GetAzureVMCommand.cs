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
        private const string InfoNotAvailable = "Info Not Available";

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
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = ListNextLinkVirtualMachinesParamSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Uri NextLink { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = GetVirtualMachineInResourceGroupParamSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public DisplayHintType DisplayHint { get; set; }

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

                    var psResultListStatus = new List<PSVirtualMachineListStatus>();

                    while (vmListResult != null)
                    {
                        psResultListStatus = GetPowerstate(vmListResult, psResultListStatus);

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

                    if (this.Status.IsPresent)
                    {
                        WriteObject(psResultListStatus, true);
                    }
                    else
                    {
                        var psResultList = new List<PSVirtualMachineList>();
                        foreach (var item in psResultListStatus)
                        {
                            var psItem = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachineList>(item);
                            psResultList.Add(psItem);
                        }
                        WriteObject(psResultList, true);
                    }
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

                        var psResult = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachine>(result);
                        if (result.Body != null)
                        {
                            psResult = ComputeAutoMapperProfile.Mapper.Map(result.Body, psResult);
                        }
                        psResult.DisplayHint = this.DisplayHint;
                        WriteObject(psResult);
                    }
                }
                else
                {
                    AzureOperationResponse<IPage<VirtualMachine>> vmListResult = null;
                    vmListResult = this.VirtualMachineClient.ListWithHttpMessagesAsync(this.ResourceGroupName)
                            .GetAwaiter().GetResult();

                    var psResultListStatus = new List<PSVirtualMachineListStatus>();
                    psResultListStatus = GetPowerstate(vmListResult, psResultListStatus);

                    if (this.Status.IsPresent)
                    {
                        WriteObject(psResultListStatus, true);
                    }
                    else
                    {
                        var psResultList = new List<PSVirtualMachineList>();
                        foreach (var item in psResultListStatus)
                        {
                            var psItem = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachineList>(item);
                            psResultList.Add(psItem);
                        }
                        WriteObject(psResultList, true);
                    }
                }
            });
        }

        private List<PSVirtualMachineListStatus> GetPowerstate(
            AzureOperationResponse<IPage<VirtualMachine>> vmListResult,
            List<PSVirtualMachineListStatus> psResultListStatus)
        {
            if (vmListResult.Body != null)
            {
                foreach (var item in vmListResult.Body)
                {
                    var psItem = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachineListStatus>(vmListResult);
                    psItem = ComputeAutoMapperProfile.Mapper.Map(item, psItem);
                    if (this.Status.IsPresent)
                    {
                        VirtualMachine state = null;
                        try
                        {
                            // Call additional Get InstanceView of each VM to get the power states of all VM.
                            state = this.VirtualMachineClient.Get(psItem.ResourceGroupName, psItem.Name, InstanceViewExpand);
                        }
                        catch
                        {
                            // Swallow any exception during getting instance view information.
                        }

                        if (state == null)
                        {
                            psItem.PowerState = InfoNotAvailable;
                            psItem.MaintenanceRedeployStatus = null;
                        }
                        else
                        {
                            var psstate = state.ToPSVirtualMachineInstanceView(psItem.ResourceGroupName, psItem.Name);
                            if (psstate != null && psstate.Statuses != null && psstate.Statuses.Count > 1)
                            {
                                psItem.PowerState = psstate.Statuses[1].DisplayStatus;
                            }
                            else
                            {
                                psItem.PowerState = InfoNotAvailable;
                            }
                            psItem.MaintenanceRedeployStatus = psstate.MaintenanceRedeployStatus;
                        }
                    }
                    psItem.DisplayHint = this.DisplayHint;
                    psResultListStatus.Add(psItem);
                }
            }

            return psResultListStatus;
        }
    }
}
