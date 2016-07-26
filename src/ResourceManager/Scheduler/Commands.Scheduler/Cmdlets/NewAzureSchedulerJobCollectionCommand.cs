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

namespace Microsoft.Azure.Commands.Scheduler.Cmdlets
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Scheduler.Models;
    using Microsoft.Azure.Commands.Scheduler.Properties;
    using Microsoft.Azure.Commands.Scheduler.Utilities;
    using Microsoft.Azure.Management.Scheduler.Models;

    /// <summary>
    /// Create new job collection.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSchedulerJobCollection", SupportsShouldProcess = true), OutputType(typeof(PSJobCollectionDefinition))]
    public class NewAzureSchedulerJobCollectionCommand : SchedulerBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The targeted resource group for job collection.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job collection.")]
        [Alias("Name", "ResourceName")]
        [ValidateNotNullOrEmpty]
        public string JobCollectionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The region the job collection to be created.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The job collection plan.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.FreePlan, Constants.StandardPlan, Constants.P10PremiumPlan, Constants.P20PremiumPlan, IgnoreCase = true)]
        public string Plan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Maximum number of jobs that can be created in this job collection. Maximum value is dependent on the Plan.")]
        public int? MaxJobCount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Maximum frequency that can be specified on any job in this job collection.")]
        [ValidateSet(Constants.FrequencyTypeMinute, Constants.FrequencyTypeHour, Constants.FrequencyTypeDay, Constants.FrequencyTypeWeek, Constants.FrequencyTypeMonth, IgnoreCase = true)]
        public string Frequency { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Interval of the recurrence at the given frequency.")]
        public int? Interval { get; set; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
 	        base.ExecuteCmdlet();
            
            var createJobCollectionParams = new PSJobCollectionsParams()
            {
                ResourceGroupName = this.ResourceGroupName,
                JobCollectionName = this.JobCollectionName,
                Plan = this.Plan,
                Region = this.Location,
                Frequency = this.Frequency,
                Interval = this.Interval,  
                MaxJobCount = this.MaxJobCount,                                                            
            };

            this.ConfirmAction(
                processMessage: string.Format(Resources.NewJobCollectionResourceDescription, this.JobCollectionName),
                target: this.JobCollectionName,
                action: () => 
                    {
                        this.WriteObject(this.SchedulerClient.CreateJobCollection(createJobCollectionParams));
                    }
            );
        }

    }
}
