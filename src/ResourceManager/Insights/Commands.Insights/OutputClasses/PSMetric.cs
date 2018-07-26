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

using System.Collections.Generic;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps around the PSMetricNoDetails and exposes all the localized strings as invariant/localized properties
    /// </summary>
    public class PSMetric
    {
        /// <summary>
        /// Resource id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Metric name (This should be the public facing display name)
        /// </summary>
        public LocalizableString Name { get; set; }

        /// <summary>
        /// Resource type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Metric Unit
        /// </summary>
        public Unit Unit { get; set; }

        /// <summary>
        /// Metric data
        /// </summary>
        public IList<MetricValue> Data { get; set; }

        /// <summary>
        /// Gets or sets the time series returned when a data query is performed.
        /// </summary>
        public IList<TimeSeriesElement> Timeseries { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSMetric class.
        /// </summary>
        /// <param name="metric">The input Metric object</param>
        public PSMetric(Metric metric)
        {
            this.Name = metric.Name;
            this.Unit = metric.Unit;
            this.Id = metric.Id;
            this.Type = metric.Type;
            this.Data = ((metric.Timeseries != null && metric.Timeseries.Count > 0)? new PSMetricValuesCollection(metric.Timeseries[0].Data) : null);
            this.Timeseries = metric.Timeseries;
        }
    }
}
