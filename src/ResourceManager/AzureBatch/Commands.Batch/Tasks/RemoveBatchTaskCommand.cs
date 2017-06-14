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
using Microsoft.Azure.Commands.Batch.Properties;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Remove, Constants.AzureBatchTask, SupportsShouldProcess = true)]
    public class RemoveBatchTaskCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the job containing the task to delete.")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the task to delete.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, Mandatory = true,
            ValueFromPipeline = true, HelpMessage = "The PSCloudTask object representing the task to delete.")]
        [ValidateNotNullOrEmpty]
        public PSCloudTask InputObject { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string taskId = InputObject == null ? this.Id : InputObject.Id;
            TaskOperationParameters parameters = new TaskOperationParameters(this.BatchContext, this.JobId,
                this.Id, this.InputObject, this.AdditionalBehaviors);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveTaskConfirm, taskId),
                Resources.RemoveTask,
                taskId,
                () => BatchClient.DeleteTask(parameters));
        }
    }
}
