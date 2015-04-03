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
        /// Lists the vms matching the specified filter options
        /// </summary>
        /// <param name="options">The options to use when querying for vms</param>
        /// <returns>The vms matching the specified filter options</returns>
        public IEnumerable<PSVM> ListVMs(ListVMOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (string.IsNullOrWhiteSpace(options.PoolName) && options.Pool == null)
            {
                throw new ArgumentNullException(Resources.GBVM_NoPoolSpecified);
            }
            string poolName = options.Pool == null ? options.PoolName : options.Pool.Name;

            // Get the single vm matching the specified name
            if (!string.IsNullOrEmpty(options.VMName))
            {
                WriteVerbose(string.Format(Resources.GBVM_GetByName, options.VMName, poolName));
                using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                {
                    IVM vm = poolManager.GetVM(poolName, options.VMName, additionalBehaviors: options.AdditionalBehaviors);
                    PSVM psVM = new PSVM(vm);
                    return new PSVM[] { psVM };
                }
            }
            // List vms using the specified filter
            else
            {
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GBVM_GetByOData, poolName);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = string.Format(Resources.GBVM_NoFilter, poolName);
                }
                WriteVerbose(verboseLogString);

                using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                {
                    IEnumerableAsyncExtended<IVM> vms = poolManager.ListVMs(poolName, odata, options.AdditionalBehaviors);
                    Func<IVM, PSVM> mappingFunction = v => { return new PSVM(v); };
                    return PSAsyncEnumerable<PSVM, IVM>.CreateWithMaxCount(
                        vms, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
                }
            }
        }
    }
}
