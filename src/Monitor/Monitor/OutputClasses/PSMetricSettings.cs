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

using System.Text;
using System.Xml;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the MetricSettings
    /// </summary>
    public class PSMetricSettings : PSDiagnosticDetailSettings
    {
        /// <summary>
        /// Initializes a new instance of the PSMetricSettings class.
        /// </summary>
        public PSMetricSettings(MetricSettings metricSettings)
        {
            if (metricSettings != null)
            {
                this.Category = metricSettings.Category;
                this.Enabled = metricSettings.Enabled;
                this.RetentionPolicy = new PSRetentionPolicy(metricSettings.RetentionPolicy);
                this.TimeGrain = metricSettings.TimeGrain ?? default(System.TimeSpan);
            }
            this.CategoryType = PSDiagnosticSettingCategoryType.Metrics;
        }

        public PSMetricSettings()
        {
        }

        public System.TimeSpan TimeGrain { get; set; }

        /// <summary>
        /// A string representation of the PSMetricSettings
        /// </summary>
        /// <returns>A string representation of the PSMetricSettings</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("Category        : " + Category);
            output.AppendLine("Enabled         : " + Enabled);
            output.AppendLine("TimeGrain       : " + XmlConvert.ToString((System.TimeSpan)TimeGrain));
            output.Append("RetentionPolicy : " + RetentionPolicy.ToString(1));
            return output.ToString();
        }

        public MetricSettings GetMetricSetting()
        {
            return new MetricSettings()
            {
                Enabled = this.Enabled,
                Category = this.Category,
                RetentionPolicy = this.RetentionPolicy,
                TimeGrain = this.TimeGrain
            };
        }
    }
}
