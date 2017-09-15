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

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    var result = this.AvailabilitySetClient.ListWithHttpMessagesAsync(this.ResourceGroupName).GetAwaiter().GetResult();

                    var psResultList = new List<PSAvailabilitySet>();
                    foreach (var item in result.Body)
                    {
                        var psItem = Mapper.Map<PSAvailabilitySet>(result);
                        psItem = Mapper.Map(item, psItem);
                        psResultList.Add(psItem);
                    }

                    WriteObject(psResultList, true);
                }
                else
                {
                    var result = this.AvailabilitySetClient.GetWithHttpMessagesAsync(this.ResourceGroupName, this.Name).GetAwaiter().GetResult();
                    var psResult = Mapper.Map<PSAvailabilitySet>(result);
                    if (result.Body != null)
                    {
                        psResult = Mapper.Map(result.Body, psResult);
                    }
                    WriteObject(psResult);
                }
            });
        }
    }
}
