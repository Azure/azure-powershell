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
using Microsoft.Azure.Commands.Batch.Properties;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Remove, "AzureBatchTask")]
    public class RemoveBatchTaskCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the WorkItem containing the Task to delete.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Job containing the Task to delete.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Task to delete.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Task to delete.")]
        [ValidateNotNullOrEmpty]
        public PSCloudTask InputObject { get; set; }

        [Parameter(HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string taskName = InputObject == null ? Name : InputObject.Name;
            RemoveTaskParameters parameters = new RemoveTaskParameters()
            {
                Context = this.BatchContext,
                WorkItemName = this.WorkItemName,
                JobName = this.JobName,
                TaskName = this.Name,
                Task = this.InputObject,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RBT_RemoveConfirm, taskName),
                Resources.RBT_RemoveTask,
                taskName,
                () => BatchClient.DeleteTask(parameters));
        }
    }
}
