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
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchPool", DefaultParameterSetName = Constants.NameParameterSet), 
        OutputType(typeof(PSCloudPool), ParameterSetName = new string[] { Constants.NameParameterSet }),
        OutputType(typeof(IEnumerableAsyncExtended<PSCloudPool>), ParameterSetName = new string[] { Constants.ODataFilterParameterSet })]
    public class GetBatchPoolCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Pool to query.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "OData filter to use when querying for Pools.")]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                WriteVerboseWithTimestamp(Resources.GBP_GetByName, Name);
                PSCloudPool pool = GetPool(Name, additionalBehaviors: AdditionalBehaviors);
                WriteObject(pool);
            }
            else
            {
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(Filter))
                {
                    WriteVerboseWithTimestamp(Resources.GBP_GetByOData);
                    odata = new ODATADetailLevel(filterClause: Filter);
                }
                else
                {
                    WriteVerboseWithTimestamp(Resources.GBP_NoFilter);
                }
                PSAsyncEnumerable<PSCloudPool, ICloudPool> poolEnumerator = ListPools(odata, AdditionalBehaviors);
                WriteObject(poolEnumerator);
            }
        }

        private PSCloudPool GetPool(string poolName, ODATADetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (IPoolManager poolManager = BatchContext.BatchOMClient.OpenPoolManager())
            {
                ICloudPool pool = poolManager.GetPool(poolName, detailLevel, additionalBehaviors);
                return new PSCloudPool(pool);
            }
        }

        private PSAsyncEnumerable<PSCloudPool, ICloudPool> ListPools(ODATADetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (IPoolManager poolManager = BatchContext.BatchOMClient.OpenPoolManager())
            {
                IEnumerableAsyncExtended<ICloudPool> poolEnumerator = poolManager.ListPools(detailLevel, additionalBehaviors);
                Func<ICloudPool, PSCloudPool> mappingFunction = p => { return new PSCloudPool(p); };
                return new PSAsyncEnumerable<PSCloudPool, ICloudPool>(poolEnumerator, mappingFunction);
            }
        }
    }
}
