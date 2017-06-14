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

using Microsoft.Azure.Commands.Batch.Models;
using System.IO;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchRemoteDesktopProtocolFile, DefaultParameterSetName = IdAndPathParameterSet)]
    public class GetBatchRemoteDesktopProtocolFileCommand : BatchObjectModelCmdletBase
    {
        internal const string IdAndPathParameterSet = "Id_Path";
        internal const string IdAndStreamParameterSet = "Id_Stream";

        [Parameter(Position = 0, ParameterSetName = IdAndPathParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the pool which contains the compute node.")]
        [Parameter(Position = 0, ParameterSetName = IdAndStreamParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = IdAndPathParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the compute node to which the Remote Desktop Protocol file will point.")]
        [Parameter(Position = 1, ParameterSetName = IdAndStreamParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectAndPathParameterSet,
            ValueFromPipeline = true)]
        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectAndStreamParameterSet,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSComputeNode ComputeNode { get; set; }

        [Parameter(ParameterSetName = IdAndPathParameterSet, Mandatory = true,
            HelpMessage = "The file path where the Remote Desktop Protocol file will be downloaded.")]
        [Parameter(ParameterSetName = Constants.InputObjectAndPathParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DestinationPath { get; set; }

        [Parameter(ParameterSetName = IdAndStreamParameterSet, Mandatory = true,
            HelpMessage = "The Stream into which the Remote Desktop Protocol file data will be written. This stream will not be closed or rewound by this call.")]
        [Parameter(ParameterSetName = Constants.InputObjectAndStreamParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Stream DestinationStream { get; set; }

        public override void ExecuteCmdlet()
        {
            DownloadRemoteDesktopProtocolFileOptions options = new DownloadRemoteDesktopProtocolFileOptions(this.BatchContext, this.PoolId, this.ComputeNodeId,
                this.ComputeNode, this.DestinationPath, this.DestinationStream, this.AdditionalBehaviors);

            this.BatchClient.DownloadRemoteDesktopProtocolFile(options);
        }
    }
}
