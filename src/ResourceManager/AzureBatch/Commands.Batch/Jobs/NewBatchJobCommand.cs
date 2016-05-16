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

using System.Collections;
using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, Constants.AzureBatchJob)]
    public class NewBatchJobCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of the job to create.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public IDictionary CommonEnvironmentSettings { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSJobConstraints Constraints { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSJobManagerTask JobManagerTask { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSJobPreparationTask JobPreparationTask { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSJobReleaseTask JobReleaseTask { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public IDictionary Metadata { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The pool information for the job.")]
        [ValidateNotNullOrEmpty]
        public PSPoolInformation PoolInformation { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public int Priority { get; set; }

        [Parameter]
        public SwitchParameter UsesTaskDependencies { get; set; }

        public override void ExecuteCmdlet()
        {
            NewJobParameters parameters = new NewJobParameters(this.BatchContext, this.Id, this.AdditionalBehaviors)
            {
                CommonEnvironmentSettings = this.CommonEnvironmentSettings,
                DisplayName = this.DisplayName,
                Constraints = this.Constraints,
                JobManagerTask = this.JobManagerTask,
                JobPreparationTask = this.JobPreparationTask,
                JobReleaseTask = this.JobReleaseTask,
                Metadata = this.Metadata,
                PoolInformation = this.PoolInformation,
                Priority = this.Priority,
                UsesTaskDependencies = this.UsesTaskDependencies.IsPresent,
            };

            BatchClient.CreateJob(parameters);
        }
    }
}
