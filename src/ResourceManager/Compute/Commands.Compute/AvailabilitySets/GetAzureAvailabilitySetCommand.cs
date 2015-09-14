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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.AvailabilitySet)]
    [OutputType(typeof(PSAvailabilitySet))]
    public class GetAzureAvailabilitySetCommand : AvailabilitySetBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "AvailabilitySetName")]
        [Parameter(
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The availability set name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ExecuteClientAction(() =>
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    var result = this.AvailabilitySetClient.List(this.ResourceGroupName);

                    List<PSAvailabilitySet> psResultList = new List<PSAvailabilitySet>();
                    foreach (var item in result.AvailabilitySets)
                    {
                        var psItem = Mapper.Map<PSAvailabilitySet>(item);
                        psItem = Mapper.Map<AzureOperationResponse, PSAvailabilitySet>(result, psItem);
                        psResultList.Add(psItem);
                    }

                    WriteObject(psResultList, true);
                }
                else
                {
                    var result = this.AvailabilitySetClient.Get(this.ResourceGroupName, this.Name);
                    var psResult = Mapper.Map<PSAvailabilitySet>(result.AvailabilitySet);
                    psResult = Mapper.Map<AzureOperationResponse, PSAvailabilitySet>(result, psResult);
                    WriteObject(psResult);
                }
            });
        }
    }
}
