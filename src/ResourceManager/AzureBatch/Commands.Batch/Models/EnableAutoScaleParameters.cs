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
    public class EnableAutoScaleParameters : PoolOperationParameters
    {
        public EnableAutoScaleParameters(BatchAccountContext context, string poolId, PSCloudPool pool,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, poolId, pool, additionalBehaviors)
        { }

        /// <summary>
        /// The formula for the desired number of compute nodes in the pool. 
        /// </summary>
        public string AutoScaleFormula { get; set; }

        /// <summary>
        /// The time interval at which to automatically adjust the pool size according to the AutoScale formula.
        /// </summary>
        public TimeSpan? AutoScaleEvaluationInterval { get; set; }
    }
}
