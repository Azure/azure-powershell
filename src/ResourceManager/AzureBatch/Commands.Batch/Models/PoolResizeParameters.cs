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
    public class PoolResizeParameters : PoolOperationParameters
    {
        public PoolResizeParameters(BatchAccountContext context, string poolId, PSCloudPool pool, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, poolId, pool, additionalBehaviors)
        { }

        /// <summary>
        /// The number of target dedicated compute nodes.
        /// </summary>
        public int TargetDedicated { get; set; }

        /// <summary>
        /// The resize timeout.  If the pool has not reached the targets after this time the resize is automatically stopped.
        /// </summary>
        public TimeSpan? ResizeTimeout { get; set; }

        /// <summary>
        /// The deallocation option associated with this resize.
        /// </summary>
        public ComputeNodeDeallocationOption? ComputeNodeDeallocationOption { get; set; }
    }
}
