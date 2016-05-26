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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, Constants.AzureBatchTask, DefaultParameterSetName = JobIdAndSingleAddParameterSet)]
    public class NewBatchTaskCommand : BatchObjectModelCmdletBase
    {
        internal const string JobIdAndBulkAddParameterSet = "JobId_Bulk";
        internal const string JobObjectAndBulkAddParameterSet = "JobObject_Bulk";
        internal const string JobIdAndSingleAddParameterSet = "JobId_Single";
        internal const string JobObjectAndSingleAddParameterSet = "JobObject_Single";

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet, Mandatory = true,
            HelpMessage = "The id of the job to which to add the task.")]
        [Parameter(ParameterSetName = JobIdAndBulkAddParameterSet, Mandatory = true,
            HelpMessage = "The id of the job to which to add the task.")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(ParameterSetName = JobObjectAndBulkAddParameterSet, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCloudJob Job { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet, Mandatory = true, HelpMessage = "The id of the task to add.")]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet, Mandatory = true, HelpMessage = "The id of the task to add.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CommandLine { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        [ValidateNotNullOrEmpty]
        public IDictionary ResourceFiles { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        [ValidateNotNullOrEmpty]
        public IDictionary EnvironmentSettings { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        public SwitchParameter RunElevated { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAffinityInformation AffinityInformation { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSTaskConstraints Constraints { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSMultiInstanceSettings MultiInstanceSettings { get; set; }

        [Parameter(ParameterSetName = JobIdAndSingleAddParameterSet)]
        [Parameter(ParameterSetName = JobObjectAndSingleAddParameterSet)]
        [ValidateNotNullOrEmpty]
        public TaskDependencies DependsOn { get; set; }

        [Parameter(ParameterSetName = JobObjectAndBulkAddParameterSet,
            HelpMessage = "The collection of tasks to add to a job.")]
        [Parameter(ParameterSetName = JobIdAndBulkAddParameterSet,
            HelpMessage = "The collection of tasks to add to a job.")]
        [ValidateNotNullOrEmpty]
        public PSCloudTask[] Tasks { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Tasks != null)
            {
                NewBulkTaskParameters parameters = new NewBulkTaskParameters(this.BatchContext, this.JobId, this.Job, this.Tasks, this.AdditionalBehaviors);
                BatchClient.AddTaskCollection(parameters);
            }
            else
            {
                NewTaskParameters parameters = new NewTaskParameters(this.BatchContext, this.JobId, this.Job,
                    this.Id, this.AdditionalBehaviors)
                {
                    DisplayName = this.DisplayName,
                    CommandLine = this.CommandLine,
                    ResourceFiles = this.ResourceFiles,
                    EnvironmentSettings = this.EnvironmentSettings,
                    RunElevated = this.RunElevated.IsPresent,
                    AffinityInformation = this.AffinityInformation,
                    Constraints = this.Constraints,
                    MultiInstanceSettings = this.MultiInstanceSettings,
                    DependsOn = this.DependsOn,
                };

                BatchClient.CreateTask(parameters);
            }
        }
    }
}
