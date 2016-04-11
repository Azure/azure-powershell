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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchRemoteLoginSettings, DefaultParameterSetName = Constants.IdParameterSet),
        OutputType(typeof(PSRemoteLoginSettings))]
    public class GetBatchComputeNodeRemoteLoginSettingsCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the pool containing the compute node for which to get remote login settings.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the compute node for which to get remote login settings.")]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSComputeNode ComputeNode { get; set; }

        public override void ExecuteCmdlet()
        {
            ComputeNodeOperationParameters parameters = new ComputeNodeOperationParameters(this.BatchContext, this.PoolId, this.ComputeNodeId, this.ComputeNode, this.AdditionalBehaviors);

            PSRemoteLoginSettings remoteLoginSettings = BatchClient.ListComputeNodeRemoteLoginSettings(parameters);
            WriteObject(remoteLoginSettings);
        }
    }
}
