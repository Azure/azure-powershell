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
    public class ListPoolOptions : BatchClientParametersBase
    {
        public ListPoolOptions(BatchAccountContext context, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, additionalBehaviors)
        { }

        /// <summary>
        /// If specified, the single pool with this id will be returned.
        /// </summary>
        public string PoolId { get; set; }

        /// <summary>
        /// The OData filter to use when querying for pools.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// The OData select clause to use.
        /// </summary>
        public string Select { get; set; }

        /// <summary>
        /// The OData expand clause to use.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The maximum number of pools to return.
        /// </summary>
        public int MaxCount { get; set; }
    }
}
