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

using System;
using System.Linq;
using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsLifecycle.Start, 
        Constants.AzureBatchComputeNodeServiceLogUpload,
        SupportsShouldProcess = true,
        DefaultParameterSetName = Constants.AzureBatchComputeNodeServiceLogUpload),         
         OutputType(typeof(PSStartComputeNodeServiceLogUploadResult))]
    public class StartBatchComputeNodeServiceLogUploadCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the pool that contains the compute node.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the compute node.")]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.ParentObjectParameterSet, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSComputeNode ComputeNode { get; set; }

        [Parameter(Position = 2, Mandatory = true,
            HelpMessage = "The URL of the container within Azure Blob Storage to which to upload the Batch Service log file(s)")]
        [ValidateNotNullOrEmpty]
        public string ContainerUrl { get; set; }

        [Parameter(Position = 3, Mandatory = true,
            HelpMessage = "The start of the time range from which to upload Batch Service log file(s).")]
        [ValidateNotNullOrEmpty]
        public DateTime StartTime { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The end of the time range from which to upload Batch Service log file(s).")]
        public DateTime? EndTime { get; set; }

        public override void ExecuteCmdlet()
        {
            StartComputeNodeServiceLogUploadParameters parameters = new StartComputeNodeServiceLogUploadParameters(
                this.BatchContext,
                this.PoolId,
                this.ComputeNodeId,
                this.ComputeNode,
                this.ContainerUrl,
                this.StartTime,
                this.EndTime,
                this.AdditionalBehaviors);

            WriteObject(BatchClient.StartComputeNodeServiceLogUpload(parameters));
        }
    }
}
