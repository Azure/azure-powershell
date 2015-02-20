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

using System.Linq;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the Pools matching the specified filter options
        /// </summary>
        /// <param name="context">The account details</param>
        /// <param name="poolName">If specified, the single Pool with this name will be returned</param>
        /// <param name="filter">The OData filter to use when querying for Pools</param>
        /// <param name="maxCount">The maximum number of Pools to return</param>
        /// <param name="additionalBehaviors">Additional client behaviors to perform</param>
        /// <returns>The Pools matching the specified filter options</returns>
        public IEnumerable<PSCloudPool> ListPools(BatchAccountContext context, string poolName, string filter, int maxCount,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // Get the single Pool matching the specified name
            if (!string.IsNullOrEmpty(poolName))
            {
                WriteVerbose(string.Format(Resources.GBP_GetByName, poolName));
                using (IPoolManager poolManager = context.BatchOMClient.OpenPoolManager())
                {
                    ICloudPool pool = poolManager.GetPool(poolName, additionalBehaviors: additionalBehaviors);
                    PSCloudPool psPool = new PSCloudPool(pool);
                    return new PSCloudPool[] { psPool };
                }
            }
            // List Pools using the specified filter
            else
            {
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(filter))
                {
                    WriteVerbose(string.Format(Resources.GBP_GetByOData, maxCount));
                    odata = new ODATADetailLevel(filterClause: filter);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.GBP_NoFilter, maxCount));
                }
                using (IPoolManager poolManager = context.BatchOMClient.OpenPoolManager())
                {
                    IEnumerableAsyncExtended<ICloudPool> pools = poolManager.ListPools(odata, additionalBehaviors);
                    Func<ICloudPool, PSCloudPool> mappingFunction = p => { return new PSCloudPool(p); };
                    return new PSAsyncEnumerable<PSCloudPool, ICloudPool>(pools, mappingFunction).Take(maxCount);
                }
            }
        }
    }
}
