﻿// ----------------------------------------------------------------------------------
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
    [Cmdlet(VerbsCommon.Remove, "AzureBatchJob")]
    public class RemoveBatchJobCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the workitem containing the job to delete.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job to delete.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The PSCloudJob object representing the job to delete.")]
        [ValidateNotNullOrEmpty]
        public PSCloudJob InputObject { get; set; }

        [Parameter(HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string jobName = InputObject == null ? this.Name : InputObject.Name;
            JobOperationParameters parameters = new JobOperationParameters(this.BatchContext, this.WorkItemName,
                this.Name, this.InputObject, this.AdditionalBehaviors);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RBJ_RemoveConfirm, jobName),
                Resources.RBJ_RemoveJob,
                jobName,
                () => BatchClient.DeleteJob(parameters));
        }
    }
}
