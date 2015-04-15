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
    [Cmdlet(VerbsCommon.Get, "AzureBatchTaskFileContent", DefaultParameterSetName = Constants.NameAndPathParameterSet)]
    public class GetBatchTaskFileContentCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameAndPathParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the workitem containing the target task.")]
        [Parameter(Position = 0, ParameterSetName = Constants.NameAndStreamParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameAndPathParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job containing the target task.")]
        [Parameter(Position = 1, ParameterSetName = Constants.NameAndStreamParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, ParameterSetName = Constants.NameAndPathParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the task.")]
        [Parameter(Position = 2, ParameterSetName = Constants.NameAndStreamParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string TaskName { get; set; }

        [Parameter(Position = 3, ParameterSetName = Constants.NameAndPathParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the task file to download.")]
        [Parameter(Position = 3, ParameterSetName = Constants.NameAndStreamParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectAndPathParameterSet, ValueFromPipeline = true, HelpMessage = "The PSTaskFile object representing the task file to download.")]
        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectAndStreamParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSTaskFile InputObject { get; set; }

        [Parameter(ParameterSetName = Constants.NameAndPathParameterSet, Mandatory = true, HelpMessage = "The file path where the task file will be downloaded.")]
        [Parameter(ParameterSetName = Constants.InputObjectAndPathParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DestinationPath { get; set; }

        [Parameter(ParameterSetName = Constants.NameAndStreamParameterSet, Mandatory = true, HelpMessage = "The Stream into which the task file contents will be written. This stream will not be closed or rewound by this call.")]
        [Parameter(ParameterSetName = Constants.InputObjectAndStreamParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Stream DestinationStream { get; set; }

        public override void ExecuteCmdlet()
        {
            DownloadTaskFileOptions options = new DownloadTaskFileOptions(this.BatchContext, this.WorkItemName, this.JobName, 
                this.TaskName, this.Name, this.InputObject, this.DestinationPath, this.DestinationStream, this.AdditionalBehaviors);

            BatchClient.DownloadTaskFile(options);
        }
    }
}
