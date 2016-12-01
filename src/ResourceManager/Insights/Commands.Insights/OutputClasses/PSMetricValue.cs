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

using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the MetricValue and exposes all the localized strings as invariant/localized properties
    /// </summary>
    public class PSMetricValue : MetricValue
    {
        /// <summary>
        /// Initializes a new instance of the PSMetricValue class.
        /// </summary>
        /// <param name="metricValue">The input MetricValue object</param>
        public PSMetricValue(MetricValue metricValue)
            : base(average: metricValue.Average, count: metricValue.Count, maximum: metricValue.Maximum, minimum: metricValue.Minimum, total: metricValue.Total, timeStamp: metricValue.TimeStamp)
        {
        }
    }
}
