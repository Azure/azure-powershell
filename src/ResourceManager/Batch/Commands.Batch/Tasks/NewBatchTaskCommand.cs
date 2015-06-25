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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System;
using System.Collections;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, "AzureBatchTask")]
    public class NewBatchTaskCommand : BatchObjectModelCmdletBase
    {
        [Parameter(ParameterSetName = Constants.NameParameterSet, Mandatory = true, HelpMessage = "The name of the workitem to create the task under.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(ParameterSetName = Constants.NameParameterSet, Mandatory = true, HelpMessage = "The name of the job to create the task under.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The PSCloudJob object representing the job to create the task under.")]
        [ValidateNotNullOrEmpty]
        public PSCloudJob Job { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the task to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "The commandline for the task.")]
        [ValidateNotNullOrEmpty]
        public string CommandLine { get; set; }

        [Parameter(HelpMessage = "Resource files required by the task.")]
        [ValidateNotNullOrEmpty]
        public IDictionary ResourceFiles { get; set; }

        [Parameter(HelpMessage = "Environment settings to add to the new task.")]
        [ValidateNotNullOrEmpty]
        public IDictionary EnvironmentSettings { get; set; }

        [Parameter(HelpMessage = "Run the process under elevation as Administrator.")]
        public SwitchParameter RunElevated { get; set; }

        [Parameter(HelpMessage = "The locality hints for the task.")]
        [ValidateNotNullOrEmpty]
        public PSAffinityInformation AffinityInformation { get; set; }

        [Parameter(HelpMessage = "The execution constraints for the task.")]
        [ValidateNotNullOrEmpty]
        public PSTaskConstraints TaskConstraints { get; set; }

        public override void ExecuteCmdlet()
        {
            NewTaskParameters parameters = new NewTaskParameters(this.BatchContext, this.WorkItemName, this.JobName, this.Job, 
                this.Name, this.AdditionalBehaviors)
            {
                CommandLine = this.CommandLine,
                ResourceFiles = this.ResourceFiles,
                EnvironmentSettings = this.EnvironmentSettings,
                RunElevated = this.RunElevated.IsPresent,
                AffinityInformation = this.AffinityInformation,
                TaskConstraints = this.TaskConstraints
            };

            BatchClient.CreateTask(parameters);
        }
    }
}
