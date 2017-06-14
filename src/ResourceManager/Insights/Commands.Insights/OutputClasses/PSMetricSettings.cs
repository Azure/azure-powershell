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

using System;
using System.Text;
using Microsoft.Azure.Management.Monitor.Management.Models;
using System.Xml;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the MetricSettings
    /// </summary>
    public class PSMetricSettings : MetricSettings
    {
        /// <summary>
        /// Initializes a new instance of the PSMetricSettings class.
        /// </summary>
        public PSMetricSettings(MetricSettings metricSettings)
        {
            this.Enabled = metricSettings.Enabled;
            this.TimeGrain = metricSettings.TimeGrain;
            this.RetentionPolicy = metricSettings.RetentionPolicy;
        }

        /// <summary>
        /// A string representation of the PSMetricSettings
        /// </summary>
        /// <returns>A string representation of the PSMetricSettings</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("Enabled         : " + Enabled);
            output.AppendLine("TimeGrain       : " + XmlConvert.ToString(TimeGrain));
            output.Append("RetentionPolicy : " + RetentionPolicy.ToString(1));
            return output.ToString();
        }
    }
}
