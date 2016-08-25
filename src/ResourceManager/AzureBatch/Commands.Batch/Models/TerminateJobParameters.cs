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
    public class TerminateJobParameters : JobOperationParameters
    {
        public TerminateJobParameters(BatchAccountContext context, string jobId, PSCloudJob job, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, jobId, job, additionalBehaviors)
        { }

        /// <summary>
        /// The text you want to appear as the job's TerminateReason.
        /// </summary>
        public string TerminateReason { get; set; }
    }
}
