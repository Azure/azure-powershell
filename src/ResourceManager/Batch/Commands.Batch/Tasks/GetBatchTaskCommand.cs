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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchTask", DefaultParameterSetName = Constants.ODataFilterParameterSet), OutputType(typeof(PSCloudTask))]
    public class GetBatchTaskCommand : BatchObjectModelCmdletBase
    {
        private int maxCount = Constants.DefaultMaxCount;

        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the WorkItem containing the Tasks to query.")]
        [Parameter(Position = 0, ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Job containing the Tasks to query.")]
        [Parameter(Position = 1, ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, ParameterSetName = Constants.NameParameterSet, HelpMessage = "The name of the Task to query.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Job containing the Tasks to query.")]
        [ValidateNotNullOrEmpty]
        public PSCloudJob Job { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "OData filter to use when querying for Tasks.")]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "The maximum number of Tasks to return. If a value of 0 or less is specified, then no upper limit will be used.")]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        public override void ExecuteCmdlet()
        {
            ListTaskOptions options = new ListTaskOptions()
            {
                Context = this.BatchContext,
                WorkItemName = this.WorkItemName,
                JobName = this.JobName,
                TaskName = this.Name,
                Job = this.Job,
                Filter = this.Filter,
                MaxCount = this.MaxCount,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            // The enumerator will internally query the service in chunks. Using WriteObject with the enumerate flag will enumerate
            // the entire collection first and then write the items out one by one in a single group.  Using foreach, we can take 
            // advantage of the enumerator's behavior and write output to the pipeline in bursts.
            foreach (PSCloudTask task in BatchClient.ListTasks(options))
            {
                WriteObject(task);
            }
        }
    }
}
