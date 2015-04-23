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
        protected const string GetVirtualMachineParamSet = "GetVirtualMachineParamSet";
        protected const string ListVirtualMachineParamSet = "ListVirtualMachineParamSet";
        protected const string ListAllVirtualMachinesParamSet = "ListAllVirtualMachinesParamSet";
        protected const string ListNextVirtualMachinesParamSet = "ListNextVirtualMachinesParamSet";

        [Parameter(
           Mandatory = true,
           Position = 0,
            ParameterSetName = ListVirtualMachineParamSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
            ParameterSetName = GetVirtualMachineParamSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VMName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = GetVirtualMachineParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = GetVirtualMachineParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To show the status.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }

        [Parameter(
            Position = 1,
            ParameterSetName = ListAllVirtualMachinesParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To list all virtual machines.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter All { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = ListNextVirtualMachinesParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The link to the next page of virtual machines.")]
        [ValidateNotNullOrEmpty]
        public Uri NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

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
                    WriteObject(psResult);
                }
            }
            else
            {
                VirtualMachineListResponse result = null;

                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    result = this.VirtualMachineClient.List(this.ResourceGroupName);
                }
                else if (this.NextLink != null)
                {
                    result = this.VirtualMachineClient.ListNext(this.NextLink.ToString());
                }
                else
                {
                    var listParams = new ListParameters();
                    result = this.VirtualMachineClient.ListAll(listParams);
                }

                var psResultList = new List<PSVirtualMachine>();
                foreach (var item in result.VirtualMachines)
                {
                    var psItem = Mapper.Map<PSVirtualMachine>(item);
                    psResultList.Add(psItem);
                }


                WriteObject(psResultList, true);
            }
        }
    }
}
