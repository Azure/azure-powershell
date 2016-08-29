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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the compute nodes matching the specified filter options.
        /// </summary>
        /// <param name="options">The options to use when querying for compute nodes.</param>
        /// <returns>The compute nodes matching the specified filter options.</returns>
        public IEnumerable<PSComputeNode> ListComputeNodes(ListComputeNodeOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            string poolId = options.Pool == null ? options.PoolId : options.Pool.Id;

            // Get the single compute node matching the specified id
            if (!string.IsNullOrEmpty(options.ComputeNodeId))
            {
                WriteVerbose(string.Format(Resources.GetComputeNodeById, options.ComputeNodeId, poolId));
                PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
                ODATADetailLevel getDetailLevel = new ODATADetailLevel(selectClause: options.Select);
                ComputeNode computeNode = poolOperations.GetComputeNode(poolId, options.ComputeNodeId, detailLevel: getDetailLevel, additionalBehaviors: options.AdditionalBehaviors);
                PSComputeNode psComputeNode = new PSComputeNode(computeNode);
                return new PSComputeNode[] { psComputeNode };
            }
            // List compute nodes using the specified filter
            else
            {
                string verboseLogString = null;
                ODATADetailLevel listDetailLevel = new ODATADetailLevel(selectClause: options.Select);
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GetComputeNodeByOData, poolId);
                    listDetailLevel.FilterClause = options.Filter;
                }
                else
                {
                    verboseLogString = string.Format(Resources.GetComputeNodeNoFilter, poolId);
                }
                WriteVerbose(verboseLogString);

                PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
                IPagedEnumerable<ComputeNode> computeNodes = poolOperations.ListComputeNodes(poolId, listDetailLevel, options.AdditionalBehaviors);
                Func<ComputeNode, PSComputeNode> mappingFunction = c => { return new PSComputeNode(c); };
                return PSPagedEnumerable<PSComputeNode, ComputeNode>.CreateWithMaxCount(
                    computeNodes, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Removes the specified compute nodes from the specified pool.
        /// </summary>
        /// <param name="parameters">The parameters specifying the pool and the compute nodes.</param>
        public void RemoveComputeNodesFromPool(RemoveComputeNodeParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            if (parameters.ComputeNode != null)
            {
                parameters.ComputeNode.omObject.RemoveFromPool(parameters.DeallocationOption, parameters.ResizeTimeout, parameters.AdditionalBehaviors);
            }
            else
            {
                PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
                poolOperations.RemoveFromPool(parameters.PoolId, parameters.ComputeNodeIds, parameters.DeallocationOption, parameters.ResizeTimeout, parameters.AdditionalBehaviors);
            }
        }

        /// <summary>
        /// Reboots the specified compute node.
        /// </summary>
        /// <param name="parameters">The parameters specifying the compute node to reboot and the reboot option.</param>
        public void RebootComputeNode(RebootComputeNodeParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string computeNodeId = parameters.ComputeNode == null ? parameters.ComputeNodeId : parameters.ComputeNode.Id;
            WriteVerbose(string.Format(Resources.RebootComputeNode, computeNodeId));

            if (parameters.ComputeNode != null)
            {
                parameters.ComputeNode.omObject.Reboot(parameters.RebootOption, parameters.AdditionalBehaviors);
            }
            else
            {
                PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
                poolOperations.Reboot(parameters.PoolId, parameters.ComputeNodeId, parameters.RebootOption, parameters.AdditionalBehaviors);
            }
        }


        /// <summary>
        /// Reinstalls the operating system on the specified compute node.
        /// </summary>
        /// <param name="parameters">The parameters specifying the compute node to reimage and the reimage option.</param>
        public void ReimageComputeNode(ReimageComputeNodeParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string computeNodeId = parameters.ComputeNode == null ? parameters.ComputeNodeId : parameters.ComputeNode.Id;
            WriteVerbose(string.Format(Resources.ReimageComputeNode, computeNodeId));

            if (parameters.ComputeNode != null)
            {
                parameters.ComputeNode.omObject.Reimage(parameters.ReimageOption, parameters.AdditionalBehaviors);
            }
            else
            {
                PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
                poolOperations.Reimage(parameters.PoolId, parameters.ComputeNodeId, parameters.ReimageOption, parameters.AdditionalBehaviors);
            }
        }

        /// <summary>
        /// Enables task scheduling on the specified compute node.
        /// </summary>
        /// <param name="parameters">The parameters specifying the compute node.</param>
        public void EnableComputeNodeScheduling(ComputeNodeOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string computeNodeId = parameters.ComputeNode == null ? parameters.ComputeNodeId : parameters.ComputeNode.Id;
            WriteVerbose(string.Format(Resources.EnableComputeNodeScheduling, computeNodeId));

            if (parameters.ComputeNode != null)
            {
                parameters.ComputeNode.omObject.EnableScheduling(parameters.AdditionalBehaviors);
            }
            else
            {
                PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
                poolOperations.EnableComputeNodeScheduling(parameters.PoolId, parameters.ComputeNodeId, parameters.AdditionalBehaviors);
            }
        }

        /// <summary>
        /// Disables task scheduling on the specified compute node.
        /// </summary>
        /// <param name="parameters">The parameters specifying the compute node.</param>
        public void DisableComputeNodeScheduling(DisableComputeNodeSchedulingParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string computeNodeId = parameters.ComputeNode == null ? parameters.ComputeNodeId : parameters.ComputeNode.Id;
            WriteVerbose(string.Format(Resources.DisableComputeNodeScheduling, computeNodeId));

            if (parameters.ComputeNode != null)
            {
                parameters.ComputeNode.omObject.DisableScheduling(parameters.DisableSchedulingOption, parameters.AdditionalBehaviors);
            }
            else
            {
                PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
                poolOperations.DisableComputeNodeScheduling(parameters.PoolId, parameters.ComputeNodeId, parameters.DisableSchedulingOption,
                    parameters.AdditionalBehaviors);
            }
        }

        /// <summary>
        /// Get the settings required for remote login to a compute node
        /// </summary>
        /// <returns>The remote login settings for this compute node.</returns>
        public PSRemoteLoginSettings ListComputeNodeRemoteLoginSettings(ComputeNodeOperationParameters parameters)
        {
            RemoteLoginSettings remoteLoginSettings;

            if (parameters.ComputeNode != null)
            {
                remoteLoginSettings = parameters.ComputeNode.omObject.GetRemoteLoginSettings(parameters.AdditionalBehaviors);
            }
            else
            {
                PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
                remoteLoginSettings = poolOperations.GetRemoteLoginSettings(parameters.PoolId, parameters.ComputeNodeId, parameters.AdditionalBehaviors);
            }

            PSRemoteLoginSettings psRemoteLoginSettings = new PSRemoteLoginSettings(remoteLoginSettings);
            return psRemoteLoginSettings;
        }
    }
}
