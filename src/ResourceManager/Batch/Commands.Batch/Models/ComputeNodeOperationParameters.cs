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
    public class ComputeNodeOperationParameters : BatchClientParametersBase
    {
        public ComputeNodeOperationParameters(BatchAccountContext context, string poolId, string computeNodeId, PSComputeNode computeNode,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if ((string.IsNullOrWhiteSpace(poolId) || string.IsNullOrWhiteSpace(computeNodeId)) && computeNode == null)
            {
                throw new ArgumentNullException(Resources.NoComputeNode);
            }

            this.PoolId = poolId;
            this.ComputeNodeId = computeNodeId;
            this.ComputeNode = computeNode;
        }

        /// <summary>
        /// The id of the pool containing the compute node.
        /// </summary>
        public string PoolId { get; private set; }

        /// <summary>
        /// The id of the compute node.
        /// </summary>
        public string ComputeNodeId { get; private set; }

        /// <summary>
        /// The PSComputeNode object representing the target compute node.
        /// </summary>
        public PSComputeNode ComputeNode { get; private set; }
    }
}
