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
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the pools matching the specified filter options.
        /// </summary>
        /// <param name="options">The options to use when querying for pools.</param>
        /// <returns>The pools matching the specified filter options.</returns>
        public IEnumerable<PSCloudPool> ListPools(ListPoolOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single pool matching the specified id
            if (!string.IsNullOrWhiteSpace(options.PoolId))
            {
                WriteVerbose(string.Format(Resources.GetPoolById, options.PoolId));
                PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
                ODATADetailLevel getDetailLevel = new ODATADetailLevel(selectClause: options.Select, expandClause: options.Expand);
                CloudPool pool = poolOperations.GetPool(options.PoolId, detailLevel: getDetailLevel, additionalBehaviors: options.AdditionalBehaviors);
                PSCloudPool psPool = new PSCloudPool(pool);
                return new PSCloudPool[] { psPool };
            }
            // List pools using the specified filter
            else
            {
                string verboseLogString = null;
                ODATADetailLevel listDetailLevel = new ODATADetailLevel(selectClause: options.Select, expandClause: options.Expand);
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = Resources.GetPoolByOData;
                    listDetailLevel.FilterClause = options.Filter;
                }
                else
                {
                    verboseLogString = Resources.GetPoolNoFilter;
                }
                WriteVerbose(verboseLogString);

                PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
                IPagedEnumerable<CloudPool> pools = poolOperations.ListPools(listDetailLevel, options.AdditionalBehaviors);
                Func<CloudPool, PSCloudPool> mappingFunction = p => { return new PSCloudPool(p); };
                return PSPagedEnumerable<PSCloudPool, CloudPool>.CreateWithMaxCount(
                    pools, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Gets all pools lifetime summary statistics
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public PSPoolStatistics GetAllPoolsLifetimeStatistics(BatchAccountContext context, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            PoolOperations poolOperations = context.BatchOMClient.PoolOperations;

            WriteVerbose(string.Format(Resources.GetAllPoolsLifetimeStatistics));

            PoolStatistics poolStatistics = poolOperations.GetAllPoolsLifetimeStatistics(additionBehaviors);
            PSPoolStatistics psPoolStatistics = new PSPoolStatistics(poolStatistics);
            return psPoolStatistics;
        }

        /// <summary>
        /// Creates a new pool.
        /// </summary>
        /// <param name="parameters">The parameters to use when creating the pool.</param>
        public void CreatePool(NewPoolParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;

            CloudPool pool = poolOperations.CreatePool();
            pool.Id = parameters.PoolId;
            pool.VirtualMachineSize = parameters.VirtualMachineSize;
            pool.DisplayName = parameters.DisplayName;
            pool.ResizeTimeout = parameters.ResizeTimeout;
            pool.MaxTasksPerComputeNode = parameters.MaxTasksPerComputeNode;
            pool.InterComputeNodeCommunicationEnabled = parameters.InterComputeNodeCommunicationEnabled;

            if (!string.IsNullOrEmpty(parameters.AutoScaleFormula))
            {
                pool.AutoScaleEnabled = true;
                pool.AutoScaleEvaluationInterval = parameters.AutoScaleEvaluationInterval;
                pool.AutoScaleFormula = parameters.AutoScaleFormula;
            }
            else if (parameters.TargetDedicated.HasValue)
            {
                pool.TargetDedicated = parameters.TargetDedicated;
            }

            if (parameters.TaskSchedulingPolicy != null)
            {
                pool.TaskSchedulingPolicy = parameters.TaskSchedulingPolicy.omObject;
            }

            if (parameters.StartTask != null)
            {
                Utils.Utils.StartTaskSyncCollections(parameters.StartTask);
                pool.StartTask = parameters.StartTask.omObject;
            }

            if (parameters.Metadata != null)
            {
                pool.Metadata = new List<MetadataItem>();
                foreach (DictionaryEntry m in parameters.Metadata)
                {
                    pool.Metadata.Add(new MetadataItem(m.Key.ToString(), m.Value.ToString()));
                }
            }

            if (parameters.CertificateReferences != null)
            {
                pool.CertificateReferences = new List<CertificateReference>();
                foreach (PSCertificateReference c in parameters.CertificateReferences)
                {
                    pool.CertificateReferences.Add(c.omObject);
                }
            }

            if (parameters.ApplicationPackageReferences != null)
            {
                pool.ApplicationPackageReferences = parameters.ApplicationPackageReferences.ToList().ConvertAll(apr => apr.omObject);
            }

            if (parameters.CloudServiceConfiguration != null)
            {
                pool.CloudServiceConfiguration = parameters.CloudServiceConfiguration.omObject;
            }

            if (parameters.VirtualMachineConfiguration != null)
            {
                pool.VirtualMachineConfiguration = parameters.VirtualMachineConfiguration.omObject;
            }

            if (parameters.NetworkConfiguration != null)
            {
                pool.NetworkConfiguration = parameters.NetworkConfiguration.omObject;
            }

            WriteVerbose(string.Format(Resources.CreatingPool, parameters.PoolId));
            pool.Commit(parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Commits changes to a PSCloudPool object to the Batch Service.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="pool">The PSCloudPool object representing the pool to update.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void UpdatePool(BatchAccountContext context, PSCloudPool pool, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (pool == null)
            {
                throw new ArgumentNullException("pool");
            }

            WriteVerbose(string.Format(Resources.UpdatingPool, pool.Id));

            Utils.Utils.BoundPoolSyncCollections(pool);
            pool.omObject.Commit(additionBehaviors);
        }

        /// <summary>
        /// Deletes the specified pool.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="poolId">The id of the pool to delete.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void DeletePool(BatchAccountContext context, string poolId, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(poolId))
            {
                throw new ArgumentNullException("poolId");
            }

            PoolOperations poolOperations = context.BatchOMClient.PoolOperations;
            poolOperations.DeletePool(poolId, additionBehaviors);
        }

        /// <summary>
        /// Resizes the specified pool.
        /// </summary>
        /// <param name="parameters">The parameters to use when resizing the pool.</param>
        public void ResizePool(PoolResizeParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string poolId = parameters.Pool == null ? parameters.PoolId : parameters.Pool.Id;

            WriteVerbose(string.Format(Resources.ResizingPool, poolId, parameters.TargetDedicated));
            PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
            poolOperations.ResizePool(poolId, parameters.TargetDedicated, parameters.ResizeTimeout, parameters.ComputeNodeDeallocationOption, parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Stops the resize operation on the specified pool.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="additionalBehaviors">Additional client behaviors to perform.</param>
        public void StopResizePool(BatchAccountContext context, string poolId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(poolId))
            {
                throw new ArgumentNullException("poolId");
            }

            WriteVerbose(string.Format(Resources.StopResizingPool, poolId));
            PoolOperations poolOperations = context.BatchOMClient.PoolOperations;
            poolOperations.StopResizePool(poolId, additionalBehaviors);
        }

        /// <summary>
        /// Enables automatic scaling on the specified pool.
        /// </summary>
        /// <param name="parameters">The parameters specifying the pool and autoscale parameters.</param>
        public void EnableAutoScale(EnableAutoScaleParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string poolId = parameters.Pool == null ? parameters.PoolId : parameters.Pool.Id;

            WriteVerbose(string.Format(Resources.EnableAutoScale, poolId, parameters.AutoScaleFormula));
            PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
            poolOperations.EnableAutoScale(poolId, parameters.AutoScaleFormula, parameters.AutoScaleEvaluationInterval,
                parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Disables automatic scaling on the specified pool.
        /// </summary>
        /// <param name="parameters">The parameters specifying the target pool.</param>
        public void DisableAutoScale(PoolOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string poolId = parameters.Pool == null ? parameters.PoolId : parameters.Pool.Id;

            WriteVerbose(string.Format(Resources.DisableAutoScale, poolId));
            PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
            poolOperations.DisableAutoScale(poolId, parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Gets the result of evaluating an automatic scaling formula on the specified pool.
        /// </summary>
        /// <param name="parameters">The parameters specifying the pool and autoscale formula.</param>
        public PSAutoScaleRun EvaluateAutoScale(EvaluateAutoScaleParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string poolId = parameters.Pool == null ? parameters.PoolId : parameters.Pool.Id;

            WriteVerbose(string.Format(Resources.EvaluateAutoScale, poolId, parameters.AutoScaleFormula));
            PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
            AutoScaleRun evaluation = poolOperations.EvaluateAutoScale(poolId, parameters.AutoScaleFormula, parameters.AdditionalBehaviors);
            return new PSAutoScaleRun(evaluation);
        }

        /// <summary>
        /// Changes the operating system version of the specified pool.
        /// </summary>
        /// <param name="parameters">The parameters specifying the pool and target OS version.</param>
        public void ChangeOSVersion(ChangeOSVersionParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string poolId = parameters.Pool == null ? parameters.PoolId : parameters.Pool.Id;

            WriteVerbose(string.Format(Resources.ChangeOSVersion, poolId, parameters.TargetOSVersion));
            PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
            poolOperations.ChangeOSVersion(poolId, parameters.TargetOSVersion, parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Lists the usage metrics, aggregated by pool across individual time intervals, for the specified account.
        /// </summary>
        /// <param name="options">The options to use when aggregating usage for pools.</param>
        public IEnumerable<PSPoolUsageMetrics> ListPoolUsageMetrics(ListPoolUsageOptions options)
        {
            string verboseLogString = null;
            ODATADetailLevel detailLevel = null;

            if (!string.IsNullOrEmpty(options.Filter))
            {
                verboseLogString = Resources.GetPoolUsageMetricsByFilter;
                detailLevel = new ODATADetailLevel(filterClause: options.Filter);
            }
            else
            {
                verboseLogString = Resources.GetPoolUsageMetricsByNoFilter;
            }

            PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
            IPagedEnumerable<PoolUsageMetrics> poolUsageMetrics =
                poolOperations.ListPoolUsageMetrics(options.StartTime, options.EndTime, detailLevel, options.AdditionalBehaviors);

            return PSPagedEnumerable<PSPoolUsageMetrics, PoolUsageMetrics>.CreateWithMaxCount(
                poolUsageMetrics, p => new PSPoolUsageMetrics(p), Int32.MaxValue, () => WriteVerbose(verboseLogString));
        }
    }
}
