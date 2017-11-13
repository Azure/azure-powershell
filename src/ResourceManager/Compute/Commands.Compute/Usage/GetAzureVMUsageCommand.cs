﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.VirtualMachineUsage)]
    [OutputType(typeof(PSUsage))]
    public class GetAzureVMUsageCommand : VirtualMachineUsageBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The location name.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                AzureOperationResponse<IPage<Usage>> result = this.UsageClient.ListWithHttpMessagesAsync(this.Location.Canonicalize()).GetAwaiter().GetResult();

                var psResultList = new List<PSUsage>();
                foreach (var item in result.Body)
                {
                    var psItem = ComputeAutoMapperProfile.Mapper.Map<PSUsage>(result);
                    psItem = ComputeAutoMapperProfile.Mapper.Map(item, psItem);
                    psResultList.Add(psItem);
                }

                WriteObject(psResultList, true);
            });
        }
    }
}
