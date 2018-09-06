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

using System;
using Microsoft.Azure.Batch;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class StartComputeNodeServiceLogUploadParameters : ComputeNodeOperationParameters
    {
        public string ContainerUrl { get; }

        public DateTime StartTime { get; }

        public DateTime? EndTime { get; }

        public StartComputeNodeServiceLogUploadParameters(BatchAccountContext context, 
            string poolId, 
            string computeNodeId, 
            PSComputeNode computeNode, 
            string containerUrl, 
            DateTime startTime, 
            DateTime? endTime,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, poolId, computeNodeId, computeNode, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(containerUrl))
            {
                throw new ArgumentNullException(nameof(containerUrl), Properties.Resources.NoContainerUrl);
            }

            if (startTime <= DateTime.MinValue)
            {
                throw new ArgumentException(nameof(startTime), Properties.Resources.NoStartTime);
            }

            this.ContainerUrl = containerUrl;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
