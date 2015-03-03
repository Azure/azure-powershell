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
        /// <param name="options">The options to use when querying for Pools</param>
        /// <returns>The Pools matching the specified filter options</returns>
        public IEnumerable<PSCloudPool> ListPools(ListPoolOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single Pool matching the specified name
            if (!string.IsNullOrEmpty(options.PoolName))
            {
                WriteVerbose(string.Format(Resources.GBP_GetByName, options.PoolName));
                using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                {
                    ICloudPool pool = poolManager.GetPool(options.PoolName, additionalBehaviors: options.AdditionalBehaviors);
                    PSCloudPool psPool = new PSCloudPool(pool);
                    return new PSCloudPool[] { psPool };
                }
            }
            // List Pools using the specified filter
            else
            {
                if (options.MaxCount <= 0)
                {
                    options.MaxCount = Int32.MaxValue;
                }
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    WriteVerbose(string.Format(Resources.GBP_GetByOData, options.MaxCount));
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.GBP_NoFilter, options.MaxCount));
                }
                using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                {
                    IEnumerableAsyncExtended<ICloudPool> pools = poolManager.ListPools(odata, options.AdditionalBehaviors);
                    Func<ICloudPool, PSCloudPool> mappingFunction = p => { return new PSCloudPool(p); };
                    return new PSAsyncEnumerable<PSCloudPool, ICloudPool>(pools, mappingFunction).Take(options.MaxCount);
                }
            }
        }
    }
}
