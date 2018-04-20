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
    [Cmdlet(VerbsCommon.Add, Constants.AzureBatchComputeNodeServiceLogs, DefaultParameterSetName = Constants.AzureBatchComputeNodeServiceLogs), 
         OutputType(typeof(PSAddComputeNodeServiceLogsResult))]
    public class AddBatchComputeNodeServiceLogsCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the pool that contains the compute node.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the compute node.")]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSComputeNode ComputeNode { get; set; }

        [Parameter(Position = 2, Mandatory = true,
            HelpMessage = "The container url to Azure Storage.")]
        [ValidateNotNullOrEmpty]
        public string ContainerUrl { get; set; }

        [Parameter(Position = 3, Mandatory = true,
            HelpMessage = "The start time of service log to be added.")]
        [ValidateNotNullOrEmpty]
        public DateTime StartTime { get; set; }

        [Parameter(Position = 4, Mandatory = false,
            HelpMessage = "The end time of service log to be added (optional).")]
        public DateTime? EndTime { get; set; }

        public override void ExecuteCmdlet()
        {
            AddComputeNodeServiceLogsParameters parameters = new AddComputeNodeServiceLogsParameters(
                this.BatchContext,
                this.PoolId,
                this.ComputeNodeId,
                this.ComputeNode,
                this.ContainerUrl,
                this.StartTime,
                this.EndTime,
                this.AdditionalBehaviors);

            WriteObject(BatchClient.AddComputeNodeServiceLogs(parameters));
        }
    }
}
