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
using System.Collections;
using Microsoft.Azure.Batch;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class NewPoolParameters : BatchClientParametersBase
    {
        public NewPoolParameters(BatchAccountContext context, string poolId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(poolId))
            {
                throw new ArgumentNullException("poolId");
            }

            this.PoolId = poolId;
        }

        /// <summary>
        /// The id of the pool to create.
        /// </summary>
        public string PoolId { get; private set; }

        /// <summary>
        /// The display name of the pool to create.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The size of the virtual machines in the pool.
        /// </summary>
        public string VirtualMachineSize { get; set; }

        /// <summary>
        /// The OS family of the compute nodes in the pool.
        /// </summary>
        public string OSFamily { get; set; }

        /// <summary>
        /// The target OS version of the compute nodes in the pool.
        /// </summary>
        public string TargetOSVersion { get; set; }

        /// <summary>
        /// The timeout for allocating compute nodes to the pool.
        /// </summary>
        public TimeSpan? ResizeTimeout { get; set; }

        /// <summary>
        /// The target number of compute nodes to allocate to the pool.
        /// </summary>
        public int? TargetDedicated { get; set; }

        /// <summary>
        /// The time interval at which to automatically adjust the pool size according to the AutoScaleFormula.
        /// </summary>
        public TimeSpan? AutoScaleEvaluationInterval { get; set; }

        /// <summary>
        /// The AutoScale formula to use with the pool.
        /// </summary>
        public string AutoScaleFormula { get; set; }

        /// <summary>
        /// The maximum number of tasks that can run on a compute node.
        /// </summary>
        public int? MaxTasksPerComputeNode { get; set; }

        /// <summary>
        /// The task scheduling policy.
        /// </summary>
        public PSTaskSchedulingPolicy TaskSchedulingPolicy { get; set; }

        /// <summary>
        /// Metadata to add to the new pool.
        /// </summary>
        public IDictionary Metadata { get; set; }

        /// <summary>
        /// Specifies whether the pool permits direct communication between compute nodes. 
        /// </summary>
        public bool InterComputeNodeCommunicationEnabled { get; set; }

        /// <summary>
        /// The start task the compute nodes in the pool will run.
        /// </summary>
        public PSStartTask StartTask { get; set; }

        /// <summary>
        /// Certificate references for the pool.
        /// </summary>
        public PSCertificateReference[] CertificateReferences { get; set; }
    }
}
