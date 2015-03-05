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
    [Cmdlet(VerbsCommon.New, "AzureBatchTask")]
    public class NewBatchTaskCommand : BatchObjectModelCmdletBase
    {
        [Parameter(ParameterSetName = Constants.NameParameterSet, Mandatory = true, HelpMessage = "The name of the WorkItem to create the Task under.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(ParameterSetName = Constants.NameParameterSet, Mandatory = true, HelpMessage = "The name of the Job to create the Task under.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Job to create the Task under.")]
        [ValidateNotNullOrEmpty]
        public PSCloudJob Job { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the Task to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "The command the Task will execute.")]
        [ValidateNotNullOrEmpty]
        public string CommandLine { get; set; }

        [Parameter(HelpMessage = "Resource Files to add to the new Task. For each key/value pair, set the key to the Resource File path, and the value to the Resource File blob source.")]
        [ValidateNotNullOrEmpty]
        public IDictionary ResourceFiles { get; set; }

        [Parameter(HelpMessage = "Environment Settings to add to the new Task. For each key/value pair, set the key to the Environment Setting name, and the value to the Environment Setting value.")]
        [ValidateNotNullOrEmpty]
        public IDictionary EnvironmentSettings { get; set; }

        [Parameter(HelpMessage = "Run the Task in elevated mode.")]
        public SwitchParameter RunElevated { get; set; }

        [Parameter(HelpMessage = "The Affinity Information for the Task.")]
        [ValidateNotNullOrEmpty]
        public PSAffinityInformation AffinityInformation { get; set; }

        [Parameter(HelpMessage = "The Task Constraints.")]
        [ValidateNotNullOrEmpty]
        public PSTaskConstraints TaskConstraints { get; set; }

        public override void ExecuteCmdlet()
        {
            NewTaskParameters parameters = new NewTaskParameters()
            {
                Context = this.BatchContext,
                WorkItemName = this.WorkItemName,
                JobName = this.JobName,
                Job = this.Job,
                TaskName = this.Name,
                CommandLine = this.CommandLine,
                ResourceFiles = this.ResourceFiles,
                EnvironmentSettings = this.EnvironmentSettings,
                RunElevated = this.RunElevated.IsPresent,
                AffinityInformation = this.AffinityInformation,
                TaskConstraints = this.TaskConstraints,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            BatchClient.CreateTask(parameters);
        }
    }
}
