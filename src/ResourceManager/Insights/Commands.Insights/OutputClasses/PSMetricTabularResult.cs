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
using System;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Represents a single value of a metric
    /// </summary>
    public class PSMetricTabularResult
    {
        /// <summary>
        /// Gets or sets the Name of the metric
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the TimestampUTC of the metric value
        /// </summary>
        public string TimestampUTC { get; set; }

        /// <summary>
        /// Gets or sets the Count of the metric
        /// </summary>
        public long? Count { get; set; }

        /// <summary>
        /// Gets or sets the Last value of the metric
        /// </summary>
        public double? Last { get; set; }

        /// <summary>
        /// Gets or sets the Maximum value of the metric
        /// </summary>
        public double? Maximum { get; set; }

        /// <summary>
        /// Gets or sets the Minimum value of the metric
        /// </summary>
        public double? Minimum { get; set; }

        /// <summary>
        /// Gets or sets the Total of the metric
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        /// Gets or sets the Average of the metric
        /// </summary>
        public double? Average { get; set; }

        /// <summary>
        /// Gets or sets the StartTimeUTC of the metric time range
        /// </summary>
        public string StartTimeUTC { get; set; }

        /// <summary>
        /// Gets or sets the EndTimeUTC of the metric time range
        /// </summary>
        public string EndTimeUTC { get; set; }

        /// <summary>
        /// Gets or sets the TimeGrain of the metric
        /// </summary>
        public TimeSpan TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets the Unit of the metric
        /// </summary>
        public Unit Unit { get; set; }

        /// <summary>
        /// Gets or sets the DimensionName of the metric
        /// </summary>
        public string DimensionName { get; set; }

        /// <summary>
        /// Gets or sets the DimensionValue of the metric
        /// </summary>
        public string DimensionValue { get; set; }

        /// <summary>
        /// Gets or sets the ResourceId of the metric
        /// </summary>
        public string ResourceId { get; set; }
    }
}
