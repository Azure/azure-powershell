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

using Microsoft.Azure.Management.Insights.Models;
using System.Xml;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the MetricSettings
    /// </summary>
    public class PSMetricSettings
    {
        /// <summary>
        /// The storageAccount Id
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The timegrain
        /// </summary>
        public string Timegrain { get; set; }

        /// <summary>
        /// The retention policy
        /// </summary>
        public PSRetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSMetricSettings class.
        /// </summary>
        public PSMetricSettings(MetricSettings metricSettings)
        {
            this.Enabled = metricSettings.Enabled;
            this.Timegrain = XmlConvert.ToString(metricSettings.TimeGrain);
            this.RetentionPolicy = new PSRetentionPolicy(metricSettings.RetentionPolicy);
        }
    }
}
