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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, Constants.AzureBatchJobSchedule)]
    public class NewBatchJobScheduleCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of the job schedule to create.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Specifies the schedule according to which jobs will be created.")]
        [ValidateNotNullOrEmpty]
        public PSSchedule Schedule { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Specifies details of the jobs to be created on this schedule.")]
        [ValidateNotNullOrEmpty]
        public PSJobSpecification JobSpecification { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public IDictionary Metadata { get; set; }

        public override void ExecuteCmdlet()
        {
            NewJobScheduleParameters parameters = new NewJobScheduleParameters(this.BatchContext, this.Id, this.AdditionalBehaviors)
            {
                DisplayName = this.DisplayName,
                Schedule = this.Schedule,
                JobSpecification = this.JobSpecification,
                Metadata = this.Metadata
            };

            BatchClient.CreateJobSchedule(parameters);
        }
    }
}
