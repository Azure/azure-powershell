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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.StreamAnalytics.Models;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    [Cmdlet(VerbsCommon.Get, Constants.StreamAnalyticsJob), OutputType(typeof(List<PSJob>), typeof(PSJob))]
    public class GetAzureStreamAnalyticsJobCommand : StreamAnalyticsBaseCmdlet
    {
        [Parameter(ParameterSetName = SingleStreamAnalyticsObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = StreamAnalyticsObjectsList, Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = SingleStreamAnalyticsObject, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The azure stream analytics job name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SingleStreamAnalyticsObject, Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The switch to specify whether the job entity should be expanded.")]
        [Parameter(ParameterSetName = StreamAnalyticsObjectsList, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The switch to specify whether the job entity should be expanded.")]
        public SwitchParameter NoExpand { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == SingleStreamAnalyticsObject)
            {
                if (ResourceGroupName != null && string.IsNullOrWhiteSpace(ResourceGroupName))
                {
                    throw new PSArgumentNullException("ResourceGroupName");
                }

                if (Name != null && string.IsNullOrWhiteSpace(Name))
                {
                    throw new PSArgumentNullException("Name");
                }
            }

            string propertiesToExpand = "inputs,transformation,outputs";
            if (NoExpand.IsPresent)
            {
                propertiesToExpand = string.Empty;
            }

            JobFilterOptions filterOptions = new JobFilterOptions
            {
                JobName = Name,
                ResourceGroupName = ResourceGroupName,
                PropertiesToExpand = propertiesToExpand
            };

            List<PSJob> jobs = StreamAnalyticsClient.FilterPSJobs(filterOptions);

            if (jobs != null)
            {
                if (jobs.Count == 1 && Name != null)
                {
                    WriteObject(jobs[0]);
                }
                else
                {
                    WriteObject(jobs, true);
                }
            }
        }
    }
}