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
using Microsoft.Azure.Management.Compute.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.New, ProfileNouns.AvailabilitySet)]
    [OutputType(typeof(PSAvailabilitySet))]
    public class NewAzureAvailabilitySetCommand : AvailabilitySetBaseCmdlet
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
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Platform Update Domain Count.")]
        [ValidateNotNullOrEmpty]
        public int? PlatformUpdateDomainCount { get; set; }

        [Parameter(
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Platform Fault Domain Count.")]
        [ValidateNotNullOrEmpty]
        public int? PlatformFaultDomainCount { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var avSetParams = new AvailabilitySet
                {
                    Location = this.Location,
                    PlatformUpdateDomainCount = this.PlatformUpdateDomainCount,
                    PlatformFaultDomainCount = this.PlatformFaultDomainCount
                };

                var result = this.AvailabilitySetClient.CreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.Name,
                    avSetParams).GetAwaiter().GetResult();

                var psResult = Mapper.Map<PSAvailabilitySet>(result);
                if (result.Body != null)
                {
                    psResult = Mapper.Map(result.Body, psResult);
                }
                WriteObject(psResult);
            });
        }
    }
}
