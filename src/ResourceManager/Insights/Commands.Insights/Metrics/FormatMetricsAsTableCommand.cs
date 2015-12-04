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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.Metrics
{
    /// <summary>
    /// Get the list of metric definition for a resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Format, "MetricsAsTable"), OutputType(typeof(PSMetricTabularResult[]))]
    public class FormatMetricsAsTableCommand : AzureRMCmdlet
    {
        /// <summary>
        /// Gets or sets the array of metrics of the cmdlet
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The array of metrics")]
        public Metric[] Metrics { get; set; }

        /// <summary>
        /// Processes the Metrics parameter flatting it and converting it to a tabular format
        /// </summary>
        /// <returns>A tabular format of the input parameters</returns>
        public PSMetricTabularResult[] ProcessParameter()
        {
            var metricsTable = new List<PSMetricTabularResult>();
            foreach (var metric in this.Metrics ?? Enumerable.Empty<Metric>())
            {
                metricsTable.AddRange(
                    metric.MetricValues.Select(
                        metricValue =>
                            new PSMetricTabularResult
                            {
                                // Values common to the metric spec
                                Name = metric.Name != null ? metric.Name.Value : null,
                                DimensionName = metric.DimensionName != null ? metric.DimensionName.Value : null,
                                DimensionValue = metric.DimensionValue != null ? metric.DimensionValue.Value : null,
                                ResourceId = metric.ResourceId,
                                TimeGrain = metric.TimeGrain,
                                Unit = metric.Unit,
                                EndTimeUTC = metric.EndTime.ToUniversalTime().ToString("u"),
                                StartTimeUTC = metric.StartTime.ToUniversalTime().ToString("u"),

                                // Values from a single metricValue record
                                Average = metricValue.Average,
                                Count = metricValue.Count,
                                Last = metricValue.Last,
                                Maximum = metricValue.Maximum,
                                Minimum = metricValue.Minimum,
                                TimestampUTC = metricValue.Timestamp.ToUniversalTime().ToString("u"),
                                Total = metricValue.Total
                            }));
            }

            return metricsTable.ToArray();
        }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteObject(this.ProcessParameter());
        }
    }
}
