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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchSubtask, DefaultParameterSetName = Constants.ODataFilterParameterSet),
        OutputType(typeof(PSSubtaskInformation))]
    public class GetBatchSubtaskCommand : BatchObjectModelCmdletBase
    {
        private int maxCount = Constants.DefaultMaxCount;

        [Parameter(Position = 0, ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the job which contains the task.")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the task.")]
        [ValidateNotNullOrEmpty]
        public string TaskId { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCloudTask Task { get; set; }

        [Parameter]
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        public override void ExecuteCmdlet()
        {
            ListSubtaskOptions options = new ListSubtaskOptions(this.BatchContext, this.JobId,
                this.TaskId, this.Task, this.AdditionalBehaviors)
            {
                MaxCount = this.MaxCount
            };

            foreach (PSSubtaskInformation subtask in BatchClient.ListSubtasks(options))
            {
                WriteObject(subtask);
            }
        }
    }
}
