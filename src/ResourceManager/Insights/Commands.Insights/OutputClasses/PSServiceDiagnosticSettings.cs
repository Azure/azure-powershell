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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the ServiceDiagnosticSettings
    /// </summary>
    public class PSServiceDiagnosticSettings : ServiceDiagnosticSettingsResource
    {
        /// <summary>
        /// Gets or sets the metric settings.
        /// </summary>
        public new List<PSMetricSettings> Metrics { get; set; }

        /// <summary>
        /// Gets or sets the log settings.
        /// </summary>
        public new List<PSLogSettings> Logs { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSServiceDiagnosticSettings class.
        /// </summary>
        public PSServiceDiagnosticSettings(ServiceDiagnosticSettingsResource serviceDiagnosticSettings)
            : base(
                id: serviceDiagnosticSettings.Id, 
                location: serviceDiagnosticSettings.Location, 
                metrics: serviceDiagnosticSettings.Metrics, 
                logs: serviceDiagnosticSettings.Logs)
        {
            this.StorageAccountId = serviceDiagnosticSettings.StorageAccountId;
            this.ServiceBusRuleId = serviceDiagnosticSettings.ServiceBusRuleId;
            this.Metrics = new List<PSMetricSettings>();
            foreach (MetricSettings metricSettings in serviceDiagnosticSettings.Metrics)
            {
                this.Metrics.Add(new PSMetricSettings(metricSettings));
            }

            this.Logs = new List<PSLogSettings>();
            foreach (LogSettings LogSettings in serviceDiagnosticSettings.Logs)
            {
                this.Logs.Add(new PSLogSettings(LogSettings));
            }

            this.WorkspaceId = serviceDiagnosticSettings.WorkspaceId;
            this.Name = serviceDiagnosticSettings.Name;
            this.Tags = serviceDiagnosticSettings.Tags;
        }
    }
}
