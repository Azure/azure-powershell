﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Insights.Legacy.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the MetricValue and exposes all the localized strings as invariant/localized properties
    /// </summary>
    public class PSMetricValue : MetricValue
    {
        /// <summary>
        /// Gets or sets the Properties of the metric value
        /// </summary>
        public new PSDictionaryElement Properties { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSMetricValue class.
        /// </summary>
        /// <param name="metricValue">The input MetricValue object</param>
        public PSMetricValue(MetricValue metricValue)
        {
            this.Average = metricValue.Average;
            this.Count = metricValue.Count;
            this.Last = metricValue.Last;
            this.Maximum = metricValue.Maximum;
            this.Minimum = metricValue.Minimum;
            this.Properties = new PSDictionaryElement(metricValue.Properties);
            this.Timestamp = metricValue.Timestamp;
            this.Total = metricValue.Total;
        }
    }
}
