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

using System.Collections;
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
            if (!string.IsNullOrWhiteSpace(options.PoolName))
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
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = Resources.GBP_GetByOData;
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = Resources.GBP_NoFilter;
                }
                WriteVerbose(verboseLogString);

                using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                {
                    IEnumerableAsyncExtended<ICloudPool> pools = poolManager.ListPools(odata, options.AdditionalBehaviors);
                    Func<ICloudPool, PSCloudPool> mappingFunction = p => { return new PSCloudPool(p); };
                    return PSAsyncEnumerable<PSCloudPool, ICloudPool>.CreateWithMaxCount(
                        pools, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));            
                }
            }
        }

        /// <summary>
        /// Creates a new Pool
        /// </summary>
        /// <param name="parameters">The parameters to use when creating the Pool</param>
        public void CreatePool(NewPoolParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (string.IsNullOrWhiteSpace(parameters.PoolName))
            {
                throw new ArgumentNullException("PoolName");
            }

            using (IPoolManager poolManager = parameters.Context.BatchOMClient.OpenPoolManager())
            {
                ICloudPool pool = poolManager.CreatePool(poolName: parameters.PoolName, osFamily: parameters.OSFamily);
                pool.ResizeTimeout = parameters.ResizeTimeout;
                pool.MaxTasksPerVM = parameters.MaxTasksPerVM;
                pool.Communication = parameters.Communication;

                if (!string.IsNullOrEmpty(parameters.VMSize))
                {
                    // Don't override OM default if unspecified
                    pool.VMSize = parameters.VMSize;
                }

                if (!string.IsNullOrEmpty(parameters.AutoScaleFormula))
                {
                    pool.AutoScaleEnabled = true;
                    pool.AutoScaleFormula = parameters.AutoScaleFormula;
                    // Clear OM default to avoid server errors
                    pool.TargetDedicated = null;
                }
                else if (parameters.TargetDedicated.HasValue)
                {
                    // Don't override OM default if unspecified
                    pool.TargetDedicated = parameters.TargetDedicated;
                }

                if (parameters.SchedulingPolicy != null)
                {
                    pool.SchedulingPolicy = parameters.SchedulingPolicy.omObject;
                }

                if (parameters.StartTask != null)
                {
                    Utils.Utils.StartTaskSyncCollections(parameters.StartTask);
                    pool.StartTask = parameters.StartTask.omObject;
                }

                if (parameters.Metadata != null)
                {
                    pool.Metadata = new List<IMetadataItem>();
                    foreach (DictionaryEntry m in parameters.Metadata)
                    {
                        pool.Metadata.Add(new MetadataItem(m.Key.ToString(), m.Value.ToString()));
                    }
                }

                if (parameters.CertificateReferences != null)
                {
                    pool.CertificateReferences = new List<ICertificateReference>();
                    foreach (PSCertificateReference c in parameters.CertificateReferences)
                    {
                        pool.CertificateReferences.Add(c.omObject);
                    }
                }

                WriteVerbose(string.Format(Resources.NBP_CreatingPool, parameters.PoolName));
                pool.Commit(parameters.AdditionalBehaviors);
            }
        }

        /// <summary>
        /// Deletes the specified Pool
        /// </summary>
        /// <param name="context">The account to use</param>
        /// <param name="poolName">The name of the Pool to delete</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform</param>
        public void DeletePool(BatchAccountContext context, string poolName, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(poolName))
            {
                throw new ArgumentNullException("poolName");
            }

            using (IPoolManager poolManager = context.BatchOMClient.OpenPoolManager())
            {
                poolManager.DeletePool(poolName, additionBehaviors);
            }
        }
    }
}
