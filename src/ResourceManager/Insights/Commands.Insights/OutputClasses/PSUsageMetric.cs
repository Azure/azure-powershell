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

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the UsageMetric and exposes a summary of the properties properties
    /// </summary>
    public class PSUsageMetric : UsageMetric
    {
        /// <summary>
        /// Gets or sets the Name of the usage metric
        /// </summary>
        public new string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSUsageMetric class.
        /// </summary>
        /// <param name="usageMetric">The input UsageMetric object</param>
        public PSUsageMetric(UsageMetric usageMetric) : base(name: usageMetric.Name)
        {
            this.Name = usageMetric.Name != null ? usageMetric.Name.LocalizedValue : null;

            this.CurrentValue = usageMetric.CurrentValue;
            this.Limit = usageMetric.Limit;
            this.NextResetTime = usageMetric.NextResetTime;
            this.QuotaPeriod = usageMetric.QuotaPeriod;
            this.Unit = usageMetric.Unit;
            this.Id = usageMetric.Id;
        }
    }
}
