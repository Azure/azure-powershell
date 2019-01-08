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
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class NewComputeNodeUserParameters : ComputeNodeOperationParameters
    {
        public NewComputeNodeUserParameters(BatchAccountContext context, string poolId, string computeNodeId, PSComputeNode computeNode,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, poolId, computeNodeId, computeNode, additionalBehaviors)
        { }

        /// <summary>
        /// The name of the local windows account created.
        /// </summary>
        public string ComputeNodeUserName { get; set; }

        /// <summary>
        /// The account password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The expiry time.
        /// </summary>
        public DateTime ExpiryTime { get; set; }

        /// <summary>
        /// The administrative privilege level of the user account.
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
