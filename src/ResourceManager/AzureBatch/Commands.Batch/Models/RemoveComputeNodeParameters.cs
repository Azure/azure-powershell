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
using Microsoft.Azure.Batch.Common;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class RemoveComputeNodeParameters : ComputeNodeOperationParameters
    {
        public RemoveComputeNodeParameters(BatchAccountContext context, string poolId, string computeNodeId, PSComputeNode computeNode,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, poolId, computeNodeId, computeNode, additionalBehaviors)
        { }

        /// <summary>
        /// Specifies when nodes may be removed from the pool.
        /// </summary>
        public ComputeNodeDeallocationOption? DeallocationOption { get; set; }

        /// <summary>
        /// Specifies the timeout for removal of compute nodes from the pool. The default value is 10 minutes. The minimum value is 5 minutes.
        /// </summary>
        public TimeSpan? ResizeTimeout { get; set; }
    }
}
