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

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the compute node extensions matching the specified filter options.
        /// </summary>
        /// <param name="options">The options to use when querying for compute node extensions.</param>
        /// <returns>The compute node extensions matching the specified filter options.</returns>
        public IEnumerable<PSNodeVMExtension> ListComputeNodeExtension(ListComputeNodeExtensionParameters options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            string poolId = options.Pool == null ? options.PoolId : options.Pool.Id;
            if (string.IsNullOrEmpty(poolId))
            {
                throw new ArgumentNullException("options.PoolId");
            }

            string nodeId = options.ComputeNodeId;
            if (string.IsNullOrEmpty(options.ComputeNodeId))
            {
                throw new ArgumentNullException("options.ComputeNodeId");
            }

            PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;

            string extensionName = options.ExtensionName;
            if (!string.IsNullOrEmpty(options.ExtensionName))
            {
                // Get the single compute node extension matching the specified id.
                return GetExtensionByName(poolId, nodeId, extensionName, poolOperations, options);
            }
            else
            {
                // List compute nodes on the specified pool and compute node.
                return ListExtensions(poolId, nodeId, poolOperations, options);
            }
        }

        private IEnumerable<PSNodeVMExtension> GetExtensionByName(string poolId, string nodeId, string extensionName, PoolOperations poolOperations, ListComputeNodeExtensionParameters options)
        {
            WriteVerbose(string.Format(Resources.GetComputeNodeExtensionByName, extensionName, nodeId, poolId));

            ODATADetailLevel getDetailLevel = new ODATADetailLevel(selectClause: options.Select);
            NodeVMExtension extension = poolOperations.GetComputeNodeExtension(poolId, nodeId, extensionName, detailLevel: getDetailLevel, additionalBehaviors: options.AdditionalBehaviors);
            PSNodeVMExtension psExtension = new PSNodeVMExtension(extension);

            return new PSNodeVMExtension[] { psExtension };
        }

        private IEnumerable<PSNodeVMExtension> ListExtensions(string poolId, string nodeId, PoolOperations poolOperations, ListComputeNodeExtensionParameters options)
        {
            WriteVerbose(string.Format(Resources.GetComputeNodeExtensions, poolId, nodeId));

            IPagedEnumerable<NodeVMExtension> extensions = poolOperations.ListComputeNodeExtensions(poolId, nodeId, options.AdditionalBehaviors);
            return PSPagedEnumerable<PSNodeVMExtension, NodeVMExtension>.CreateWithMaxCount
            (
                extensions,
                e => { return new PSNodeVMExtension(e); },
                options.MaxCount,
                () => WriteMaxCount(options.MaxCount)
            );
        }
    }
}
