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
using System.IO;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchNodeFileContent)]
    public class GetBatchNodeFileContentCommand : BatchObjectModelCmdletBase
    {
        internal const string TaskAndIdAndPathParameterSet = "Task_Id_Path";
        internal const string TaskAndIdAndStreamParameterSet = "Task_Id_Stream";
        internal const string ComputeNodeAndIdAndPathParameterSet = "ComputeNode_Id_Path";
        internal const string ComputeNodeAndIdAndStreamParameterSet = "ComputeNode_Id_Stream";

        [Parameter(ParameterSetName = TaskAndIdAndPathParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the job containing the target task.")]
        [Parameter(ParameterSetName = TaskAndIdAndStreamParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(ParameterSetName = TaskAndIdAndPathParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the task.")]
        [Parameter(ParameterSetName = TaskAndIdAndStreamParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string TaskId { get; set; }

        [Parameter(Position = 0, ParameterSetName = ComputeNodeAndIdAndPathParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the pool containing the compute node.")]
        [Parameter(Position = 0, ParameterSetName = ComputeNodeAndIdAndStreamParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = ComputeNodeAndIdAndPathParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the compute node.")]
        [Parameter(Position = 1, ParameterSetName = ComputeNodeAndIdAndStreamParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 2, ParameterSetName = ComputeNodeAndIdAndPathParameterSet, Mandatory = true,
            HelpMessage = "The name of the node file to download.")]
        [Parameter(Position = 2, ParameterSetName = ComputeNodeAndIdAndStreamParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = TaskAndIdAndPathParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = TaskAndIdAndStreamParameterSet, Mandatory = true)]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectAndPathParameterSet, ValueFromPipeline = true)]
        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectAndStreamParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSNodeFile InputObject { get; set; }

        [Parameter(ParameterSetName = ComputeNodeAndIdAndPathParameterSet, Mandatory = true,
            HelpMessage = "The file path where the node file will be downloaded.")]
        [Parameter(ParameterSetName = TaskAndIdAndPathParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = Constants.InputObjectAndPathParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DestinationPath { get; set; }

        [Parameter(ParameterSetName = ComputeNodeAndIdAndStreamParameterSet, Mandatory = true,
            HelpMessage = "The Stream into which the node file contents will be written. This stream will not be closed or rewound by this call.")]
        [Parameter(ParameterSetName = TaskAndIdAndStreamParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = Constants.InputObjectAndStreamParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Stream DestinationStream { get; set; }

        [Parameter(HelpMessage = "The start of the byte range to be downloaded. If this is not specified and ByteRangeEnd is, this defaults to 0.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, long.MaxValue)]
        public long? ByteRangeStart { get; set; }

        [Parameter(HelpMessage = "The end of the byte range to be downloaded. If this is not specified and ByteRangeStart is, this defaults to the end of the file.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, long.MaxValue)]
        public long? ByteRangeEnd { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ByteRangeEnd != null && this.ByteRangeStart == null)
            {
                this.ByteRangeStart = 0;
            }

            if (this.ByteRangeEnd == null && this.ByteRangeStart != null)
            {
                this.ByteRangeEnd = long.MaxValue;
            }

            var byteRange = this.ByteRangeStart != null && this.ByteRangeEnd != null
                ? new DownloadNodeFileOptions.ByteRange(this.ByteRangeStart.Value, this.ByteRangeEnd.Value)
                : null;

            DownloadNodeFileOptions options = new DownloadNodeFileOptions(
                this.BatchContext,
                this.JobId,
                this.TaskId,
                this.PoolId,
                this.ComputeNodeId,
                this.Path,
                this.InputObject,
                this.DestinationPath,
                this.DestinationStream,
                byteRange,
                this.AdditionalBehaviors);

            BatchClient.DownloadNodeFile(options);
        }
    }
}
