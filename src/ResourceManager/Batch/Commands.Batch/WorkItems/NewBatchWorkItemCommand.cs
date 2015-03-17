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
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, "AzureBatchWorkItem")]
    public class NewBatchWorkItemCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the WorkItem to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "The Schedule to use when creating a new WorkItem")]
        [ValidateNotNullOrEmpty]
        public PSWorkItemSchedule Schedule { get; set; }

        [Parameter(HelpMessage = "The Job Specification to use when creating a new WorkItem")]
        [ValidateNotNullOrEmpty]
        public PSJobSpecification JobSpecification { get; set; }

        [Parameter(HelpMessage = "The Job Execution Enviornment to use when creating a new WorkItem")]
        [ValidateNotNullOrEmpty]
        public PSJobExecutionEnvironment JobExecutionEnvironment { get; set; }

        [Parameter(HelpMessage = "Metadata to add to the new WorkItem. For each key/value pair, set the key to the Metadata name, and the value to the Metadata value.")]
        [ValidateNotNullOrEmpty]
        public IDictionary Metadata { get; set; }

        public override void ExecuteCmdlet()
        {
            NewWorkItemParameters parameters = new NewWorkItemParameters()
            {
                Context = this.BatchContext,
                WorkItemName = this.Name,
                Schedule = this.Schedule,
                JobSpecification = this.JobSpecification,
                JobExecutionEnvironment = this.JobExecutionEnvironment,
                Metadata = this.Metadata,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            BatchClient.CreateWorkItem(parameters);
        }
    }
}
