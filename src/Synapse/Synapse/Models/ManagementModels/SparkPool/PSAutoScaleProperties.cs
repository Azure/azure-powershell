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

using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSAutoScaleProperties
    {
        public PSAutoScaleProperties(AutoScaleProperties autoScale)
        {
            this.MinNodeCount = autoScale?.MinNodeCount;
            this.Enabled = autoScale?.Enabled;
            this.MaxNodeCount = autoScale?.MaxNodeCount;
        }

        /// <summary>
        /// Gets the minimum number of nodes the Big Data pool can
        /// support.
        /// </summary>
        public int? MinNodeCount { get; set; }

        /// <summary>
        /// Gets whether automatic scaling is enabled for the Big Data
        /// pool.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets the maximum number of nodes the Big Data pool can
        /// support.
        /// </summary>
        public int? MaxNodeCount { get; set; }
    }
}