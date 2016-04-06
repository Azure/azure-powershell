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
using System.Management.Automation;
using Microsoft.Azure.Batch;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Pools
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchAccountNodeAgentSku, DefaultParameterSetName = Constants.ODataFilterParameterSet),
        OutputType(typeof(PSNodeAgentSku))]
    public class GetBatchAccountNodeAgentSkusCommand : BatchObjectModelCmdletBase
    {
        private int maxCount = Constants.DefaultMaxCount;

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        public override void ExecuteCmdlet()
        {
            foreach(PSNodeAgentSku nodeAgentSku in BatchClient.ListNodeAgentSkus(this.BatchContext, this.Filter, this.MaxCount, this.AdditionalBehaviors))
            {
                WriteObject(nodeAgentSku);
            }
        }
    }
}
