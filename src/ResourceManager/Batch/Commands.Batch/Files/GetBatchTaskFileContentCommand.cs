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

using System.IO;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchTaskFileContent")]
    public class GetBatchTaskFileContentCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the WorkItem.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Job.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Task.")]
        [ValidateNotNullOrEmpty]
        public string TaskName { get; set; }

        [Parameter(Position = 3, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Task file to download.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Task file to download.")]
        [ValidateNotNullOrEmpty]
        public PSTaskFile InputObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The destination path where the Task file will be downloaded.")]
        [ValidateNotNullOrEmpty]
        public string DestinationPath { get; set; }

        /// <summary>
        /// Used for testing. If not null, the file contents will be copied to this Stream instead of hitting the file system.
        /// </summary>
        internal Stream Stream;

        public override void ExecuteCmdlet()
        {
            DownloadTaskFileOptions options = new DownloadTaskFileOptions()
            {
                Context = this.BatchContext,
                WorkItemName = this.WorkItemName,
                JobName = this.JobName,
                TaskName = this.TaskName,
                TaskFileName = this.Name,
                TaskFile = this.InputObject,
                DestinationPath = this.DestinationPath,
                Stream = this.Stream,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            BatchClient.DownloadTaskFile(options);
        }
    }
}
