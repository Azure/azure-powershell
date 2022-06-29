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

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the MetricSettings, but in the old namespace
    /// </summary>
    public class MetricSettings : Monitor.Models.MetricSettings
    {
        /// <summary>
        /// Gets or sets the RetentionPolicy of the MetricSettings
        /// </summary>
        public new RetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Gets or sets the TimeGrain of the MetricSettings
        /// </summary>
        public new TimeSpan TimeGrain { get; set; }

        /// <summary>
        /// Initializes a new instance of the MetricSettings class.
        /// </summary>
        /// <param name="metricSettings">The metric settings</param>
        public MetricSettings(Monitor.Models.MetricSettings metricSettings)
            : base()
        {
            if (metricSettings != null)
            {
                this.Enabled = metricSettings.Enabled;
                this.Category = metricSettings.Category;
                base.RetentionPolicy = metricSettings.RetentionPolicy;
                base.TimeGrain = metricSettings.TimeGrain;
                this.RetentionPolicy = metricSettings.RetentionPolicy != null ? new RetentionPolicy(metricSettings.RetentionPolicy) : null;
                this.TimeGrain = metricSettings.TimeGrain ?? default(TimeSpan);
            }
        }
    }
}
