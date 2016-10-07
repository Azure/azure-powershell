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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;

    [Cmdlet(VerbsCommon.Get, "AzureRmIotHubJob")]
    [OutputType(typeof(PSIotHubJobResponse), typeof(List<PSIotHubJobResponse>))]
    public class GetAzureRmIotHubJob : IotHubBaseCmdlet
    {
        const string GetIotHubJobParameterSet = "GetIotHubJob";
        const string ListIotHubJobParameterSet = "ListIotHubJob";

        [Parameter(
            ParameterSetName = GetIotHubJobParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name")]
        [Parameter(
            ParameterSetName = ListIotHubJobParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = GetIotHubJobParameterSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name")]
        [Parameter(
            ParameterSetName = ListIotHubJobParameterSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = GetIotHubJobParameterSet,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "JobId")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case GetIotHubJobParameterSet:
                    JobResponse jobResponse = this.IotHubClient.IotHubResource.GetJob(this.ResourceGroupName, this.Name, this.JobId);
                    this.WriteObject(IotHubUtils.ToPSIotHubJobResponse(jobResponse), false);
                    break;
                case ListIotHubJobParameterSet:
                    IEnumerable<JobResponse> jobResponseList = this.IotHubClient.IotHubResource.ListJobs(this.ResourceGroupName, this.Name);
                    this.WriteObject(IotHubUtils.ToPSIotHubJobResponseList(jobResponseList), true);
                    break;
                default:
                    throw new ArgumentException("BadParameterSetName");
            }
        }
    }
}
