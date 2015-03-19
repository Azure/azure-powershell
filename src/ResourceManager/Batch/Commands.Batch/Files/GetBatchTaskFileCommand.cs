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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchTaskFile", DefaultParameterSetName = Constants.ODataFilterParameterSet), OutputType(typeof(PSTaskFile))]
    public class GetBatchTaskFileCommand : BatchObjectModelCmdletBase
    {
        private int maxCount = Constants.DefaultMaxCount;

        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the workitem which contains the specified target task.")]
        [Parameter(Position = 0, ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job containing the specified target task.")]
        [Parameter(Position = 1, ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the task.")]
        [Parameter(Position = 2, ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string TaskName { get; set; }

        [Parameter(Position = 3, ParameterSetName = Constants.NameParameterSet, HelpMessage = "The name of the task file to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Task object to use as the basis for the file query.")]
        [ValidateNotNullOrEmpty]
        public PSCloudTask Task { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "OData filter to use when querying for Task files.")]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "The maximum number of Task files to return. If a value of 0 or less is specified, then no upper limit will be used.")]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "If present, performs a recursive list of files of the task. Otherwise, returns only the files at the task directory root.")]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        public SwitchParameter Recursive { get; set; }

        public override void ExecuteCmdlet()
        {
            ListTaskFileOptions options = new ListTaskFileOptions()
            {
                Context = this.BatchContext,
                WorkItemName = this.WorkItemName,
                JobName = this.JobName,
                TaskName = this.TaskName,
                TaskFileName = this.Name,
                Task = this.Task,
                Filter = this.Filter,
                MaxCount = this.MaxCount,
                Recursive = this.Recursive.IsPresent,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            // The enumerator will internally query the service in chunks. Using WriteObject with the enumerate flag will enumerate
            // the entire collection first and then write the items out one by one in a single group.  Using foreach, we can take 
            // advantage of the enumerator's behavior and write output to the pipeline in bursts.
            foreach (PSTaskFile taskFile in BatchClient.ListTaskFiles(options))
            {
                WriteObject(taskFile);
            }
        }
    }
}
