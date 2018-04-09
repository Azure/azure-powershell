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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using System.Management.Automation.Language;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchPoolNodeCounts, DefaultParameterSetName = Constants.PoolIdParameterSet),
     OutputType(typeof(PSPoolNodeCounts))]
    public class GetBatchPoolNodeCountsCommand : BatchObjectModelCmdletBase
    {
        private const int defaultMaxCount = 10;

        [Parameter(Position = 0, ParameterSetName = Constants.PoolIdParameterSet, Mandatory = false,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the pool for which to get node counts.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, ValueFromPipeline = true, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSCloudPool Pool { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet)]
        public int MaxCount { get; set; } = defaultMaxCount;

        public override void ExecuteCmdlet()
        {
            ListPoolNodeCountsOptions options = new ListPoolNodeCountsOptions(this.BatchContext, this.PoolId, this.Pool, this.MaxCount, this.AdditionalBehaviors);

            IEnumerable<PSPoolNodeCounts> pagedPoolNodeCounts = BatchClient.ListPoolNodeCounts(options);

            foreach (var poolNodeCounts in pagedPoolNodeCounts)
            {
                WriteObject(poolNodeCounts);
            }
        }
    }
}
