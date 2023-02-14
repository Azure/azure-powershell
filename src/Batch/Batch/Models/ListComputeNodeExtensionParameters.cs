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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class ListComputeNodeExtensionParameters : PoolOperationParameters
    {
        public ListComputeNodeExtensionParameters(BatchAccountContext context, string poolId, PSCloudPool pool, string computeNodeId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, poolId, pool, additionalBehaviors)
        {
            ComputeNodeId = computeNodeId;
        }

        public ListComputeNodeExtensionParameters(BatchAccountContext context, string poolId, PSCloudPool pool, string computeNodeId, string extensionName, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : this(context, poolId, pool, computeNodeId, additionalBehaviors)
        {
            ExtensionName = extensionName;
        }

        /// <summary>
        /// The Id of the compute node that the extension(s) searched for belong to.
        /// </summary>
        public string ComputeNodeId { get; set; }

        /// <summary>
        /// If specified, the single extension with this name will be returned.
        /// </summary>
        public string ExtensionName { get; set; }

        /// <summary>
        /// The OData select clause to use.
        /// </summary>
        public string Select { get; set; }

        /// <summary>
        /// The maximum number of compute nodes to return.
        /// </summary>
        public int MaxCount { get; set; }
    }
}
