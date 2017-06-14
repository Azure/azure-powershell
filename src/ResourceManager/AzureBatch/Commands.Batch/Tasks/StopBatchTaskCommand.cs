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

using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsLifecycle.Stop, Constants.AzureBatchTask)]
    public class StopBatchTaskCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the job containing the task to terminate.")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the task to terminate.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, Mandatory = true,
            ValueFromPipeline = true, HelpMessage = "The PSCloudTask object representing the task to terminate.")]
        [ValidateNotNullOrEmpty]
        public PSCloudTask Task { get; set; }

        public override void ExecuteCmdlet()
        {
            TaskOperationParameters parameters = new TaskOperationParameters(this.BatchContext, this.JobId,
                this.Id, this.Task, this.AdditionalBehaviors);
            BatchClient.TerminateTask(parameters);
        }
    }
}
