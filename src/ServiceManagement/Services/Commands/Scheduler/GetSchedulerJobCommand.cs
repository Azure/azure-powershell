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


using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler;

namespace Microsoft.WindowsAzure.Commands.Scheduler
{
    /// <summary>
    /// Cmdlet to list jobs in a job collection
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSchedulerJob"), OutputType(typeof(Job))]
    public class GetSchedulerJobCommand : SchedulerBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location name.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The job collection name.")]
        [ValidateNotNullOrEmpty]
        public string JobCollectionName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The job name.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The job state.")]
        [ValidateSet("Enabled", "Disabled", "Faulted", "Completed", IgnoreCase = true)]
        public string JobState { get; set; }

        public override void ExecuteCmdlet()
        {           
            WriteObject(SMClient.GetJob(region: Location, jobCollection: JobCollectionName, job: JobName, state: JobState), true);
        }
    }
}
