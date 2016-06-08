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
    /// Wrapps around the PSMetricNoDetails and exposes all the localized strings as invariant/localized properties
    /// </summary>
    public sealed class PSMetric : PSMetricNoDetails
    {
        /// <summary>
        /// Gets or sets the MetricValues collection of the metric
        /// </summary>
        public new PSMetricValuesCollection MetricValues { get; set; }

        /// <summary>
        /// Gets or sets the Properties of the metric
        /// </summary>
        public new PSDictionaryElement Properties { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSMetric class.
        /// </summary>
        /// <param name="metric">The input Metric object</param>
        public PSMetric(Metric metric)
            : base(metric)
        {
            this.DimensionName = metric.DimensionName == null ? null : metric.DimensionName.Value;
            this.DimensionValue = metric.DimensionValue == null ? null : metric.DimensionValue.Value;
            this.EndTime = metric.EndTime;
            this.MetricValues = new PSMetricValuesCollection(metric.MetricValues);
            this.Name = metric.Name == null ? null : metric.Name.Value;
            this.Properties = new PSDictionaryElement(metric.Properties);
            this.ResourceId = metric.ResourceId;
            this.StartTime = metric.StartTime;
            this.TimeGrain = metric.TimeGrain;
            this.Unit = metric.Unit;
        }
    }
}
