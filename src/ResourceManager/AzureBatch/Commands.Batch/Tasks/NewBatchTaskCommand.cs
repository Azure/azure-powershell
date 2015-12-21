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
using System;
using System.Collections;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, Constants.AzureBatchTask)]
    public class NewBatchTaskCommand : BatchObjectModelCmdletBase
    {
        [Parameter(ParameterSetName = Constants.IdParameterSet, Mandatory = true, 
            HelpMessage = "The id of the job to create the task under.")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCloudJob Job { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The id of the task to create.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The command line for the task.")]
        [ValidateNotNullOrEmpty]
        public string CommandLine { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public IDictionary ResourceFiles { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public IDictionary EnvironmentSettings { get; set; }

        [Parameter]
        public SwitchParameter RunElevated { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSAffinityInformation AffinityInformation { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSTaskConstraints Constraints { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSMultiInstanceSettings MultiInstanceSettings { get; set; }

        public override void ExecuteCmdlet()
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
                MultiInstanceSettings = this.MultiInstanceSettings
            };

            BatchClient.CreateTask(parameters);
        }
    }
}
