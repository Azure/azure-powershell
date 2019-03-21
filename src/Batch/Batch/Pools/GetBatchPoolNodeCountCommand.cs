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
using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Batch
{
    [GenericBreakingChange("Get-AzBatchPoolNodeCounts alias will be removed in an upcoming breaking change release", "2.0.0")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchPoolNodeCount",DefaultParameterSetName = Constants.AzureBatchPoolNodeCounts),OutputType(typeof(PSPoolNodeCounts))]
    [Alias("Get-AzBatchPoolNodeCounts")]
    public class GetBatchPoolNodeCountCommand : BatchObjectModelCmdletBase
    {
        private const int defaultMaxCount = 10;

        [Parameter(ParameterSetName = Constants.PoolIdParameterSet, Mandatory = false,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the pool for which to get node counts.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet, 
            ValueFromPipeline = true, Mandatory = false, HelpMessage = "The pool object for which to get node counts.")]
        [ValidateNotNullOrEmpty]
        public PSCloudPool Pool { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet), ValidateRange(1, defaultMaxCount)]
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
