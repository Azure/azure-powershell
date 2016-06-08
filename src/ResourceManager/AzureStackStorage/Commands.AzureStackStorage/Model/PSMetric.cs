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


using Microsoft.AzureStack.Management.StorageAdmin.Models;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    /// Wrapps around the Metric and exposes a summary of the properties properties
    /// </summary>
    internal class PSMetric : PSMetricNoDetails
    {
        /// <summary>
        /// Gets or sets the MetricValues collection of the metric
        /// </summary>
        public new PSMetricValuesCollection MetricValues { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSMetric class.
        /// </summary>
        /// <param name="metric">The input Metric object</param>
        public PSMetric(Metric metric) : base(metric)
        {
            this.MetricValues = new PSMetricValuesCollection(metric.MetricValues);
        }
    }
}
