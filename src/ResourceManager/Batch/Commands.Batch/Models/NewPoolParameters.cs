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
    public class NewPoolParameters
    {
        /// <summary>
        /// The account details
        /// </summary>
        public BatchAccountContext Context { get; set; }

        /// <summary>
        /// The name of the Pool to create.
        /// </summary>
        public string PoolName { get; set; }

        /// <summary>
        /// The size of the VMs in the Pool.
        /// </summary>
        public string VMSize { get; set; }

        /// <summary>
        /// The OS family of the VMs in the Pool.
        /// </summary>
        public string OSFamily { get; set; }

        /// <summary>
        /// The target OS version of the VMs in the Pool.
        /// </summary>
        public string TargetOSVersion { get; set; }

        /// <summary>
        /// The timeout for allocating VMs to the Pool.
        /// </summary>
        public TimeSpan? ResizeTimeout { get; set; }

        /// <summary>
        /// The target number of VMs to allocate to the Pool.
        /// </summary>
        public int? TargetDedicated { get; set; }

        /// <summary>
        /// The AutoScale formula to use with the Pool.
        /// </summary>
        public string AutoScaleFormula { get; set; }

        /// <summary>
        /// The maximum number of Tasks that can run on a VM.
        /// </summary>
        public int? MaxTasksPerVM { get; set; }

        /// <summary>
        /// The scheduling policy.
        /// </summary>
        public PSSchedulingPolicy SchedulingPolicy { get; set; }

        /// <summary>
        /// Metadata to add to the new Pool.
        /// </summary>
        public IDictionary Metadata { get; set; }

        /// <summary>
        /// Whether the VMs in the Pool need to communicate with each other.
        /// </summary>
        public bool Communication { get; set; }

        /// <summary>
        /// The Start Task the VMs in the Pool will run.
        /// </summary>
        public PSStartTask StartTask { get; set; }

        /// <summary>
        /// Certificate References for the Pool.
        /// </summary>
        public PSCertificateReference[] CertificateReferences { get; set; }

        /// <summary>
        /// Additional client behaviors to perform
        /// </summary>
        public IEnumerable<BatchClientBehavior> AdditionalBehaviors { get; set; }
    }
}
