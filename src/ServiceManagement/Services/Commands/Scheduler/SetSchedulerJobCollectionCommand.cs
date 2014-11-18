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
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model;

namespace Microsoft.WindowsAzure.Commands.Scheduler
{
    /// <summary>
    /// Cmdlet to update Job collection
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSchedulerJobCollection"), OutputType(typeof(string))]
    public class SetSchedulerJobCollectionCommand : SchedulerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The location name.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The job collection name.")]
        [ValidateNotNullOrEmpty]
        public string JobCollectionName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The job collection plan.")]
        [ValidateSet("Free", "Standard", "Premium", IgnoreCase = true)]
        public string Plan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Maximum number of jobs that can be created in this job collection. Maximum value is dependent on the Plan.")]
        public int? MaxJobCount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Maximum frequency that can be specified on any job in this job collection.")]
        [ValidateSet("Minute", "Hour", "Day", "Week", "Month", "Year", IgnoreCase = true)]
        public string Frequency { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Interval of the recurrence at the given frequency.")]
        public int? Interval { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string status = string.Empty;  
            if (PassThru.IsPresent)
            {
                WriteObject(SMClient.UpdateJobCollection(new PSCreateJobCollectionParams
                {
                    Region = Location,
                    JobCollectionName = JobCollectionName,
                    JobCollectionPlan = Plan,
                    MaxJobCount = MaxJobCount,
                    MaxJobFrequency = Frequency,
                    MaxJobInterval = Interval
                }, out status), true);
                WriteObject(status);
            }
            else
            {
                SMClient.UpdateJobCollection(new PSCreateJobCollectionParams
                {
                    Region = Location,
                    JobCollectionName = JobCollectionName,
                    JobCollectionPlan = Plan,
                    MaxJobCount = MaxJobCount,
                    MaxJobFrequency = Frequency,
                    MaxJobInterval = Interval
                }, out status);
                WriteDebug(status);
            }
        }
    }
}
