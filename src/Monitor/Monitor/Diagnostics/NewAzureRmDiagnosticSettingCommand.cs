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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiagnosticSetting"), OutputType(typeof(PSServiceDiagnosticSettings))]
    public class NewAzureRmDiagnosticSettingCommand : ManagementCmdletBase
    {
        public const string StorageAccountIdParamName = "StorageAccountId";
        public const string ServiceBusRuleIdParamName = "ServiceBusRuleId";
        public const string EventHubNameParamName = "EventHubName";
        public const string EventHubRuleIdParamName = "EventHubAuthorizationRuleId";
        public const string WorkspacetIdParamName = "WorkspaceId";
        public const string EnabledParamName = "Enabled";
        public const string EnableLogParamName = "EnableLog";
        public const string EnableMetricsParamName = "EnableMetrics";

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the diagnostic setting. Defaults to 'service'")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = "service";

        /// <summary>
        /// Gets or sets the storage account parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The storage account id")]
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the service bus rule id parameter of the cmdlet
        /// </summary>
        [Parameter( Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The service bus rule id")]
        public string ServiceBusRuleId { get; set; }

        /// <summary>
        /// Gets or sets the service bus rule id parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The service bus rule id")]
        public string EventHubName { get; set; }

        /// <summary>
        /// Gets or sets the event hub authorization rule id parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The event hub rule id")]
        public string EventHubAuthorizationRuleId { get; set; }

        /// <summary>
        /// Gets or sets the OMS workspace Id
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id of the Log Analytics workspace to send logs/metrics to")]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the retention in days
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether to export (to ODS) to resource-specific (if present) or to AzureDiagnostics (default, not present)")]
        public SwitchParameter DedicatedLogAnalyticsDestinationType { get; set; }

        /// <summary>
        /// Set list of diagnostic settings
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Metric settings or Log settings")]
        public PSDiagnosticDetailSettings[] Setting { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            Validate();

            IList<MetricSettings> metrics = new List<MetricSettings>();
            IList<LogSettings> logs = new List<LogSettings>();

            if (this.IsParameterBound(c => c.Setting) && Setting.Length != 0)
            {
                foreach (PSDiagnosticDetailSettings setting in Setting)
                {
                    switch (setting.CategoryType)
                    {
                        case PSDiagnosticSettingCategoryType.Metrics:
                            metrics.Add(((PSMetricSettings)setting).GetMetricSetting());
                            break;
                        case PSDiagnosticSettingCategoryType.Logs:
                            logs.Add(((PSLogSettings)setting).GetLogSetting());
                            break;
                        default:
                            throw new ArgumentException("Invalid diagnostic setting type");
                    }
                }
            }

            PSServiceDiagnosticSettings DiagnosticSetting = new PSServiceDiagnosticSettings(id: this.TargetResourceId + "/diagnosticSettings/" + this.Name, name: this.Name)
            {
                StorageAccountId = this.IsParameterBound(c => c.StorageAccountId) ? this.StorageAccountId : null,
                ServiceBusRuleId = this.IsParameterBound(c => c.ServiceBusRuleId) ? this.ServiceBusRuleId : null,
                EventHubName = this.IsParameterBound(c => c.EventHubName) ? this.EventHubName : null,
                EventHubAuthorizationRuleId = this.IsParameterBound(c => c.EventHubAuthorizationRuleId) ? this.EventHubAuthorizationRuleId : null,
                WorkspaceId = this.IsParameterBound(c => c.WorkspaceId) ? this.WorkspaceId : null,
                LogAnalyticsDestinationType = this.IsParameterBound(c => c.DedicatedLogAnalyticsDestinationType) ? "Dedicated" : null,
                Metrics = metrics,
                Logs = logs
            };

            WriteObject(DiagnosticSetting);
        }

        protected void Validate()
        {
            if (!this.IsParameterBound(c => c.StorageAccountId) && 
                !this.IsParameterBound(c => c.ServiceBusRuleId) && 
                !this.IsParameterBound(c => c.EventHubName) && 
                !this.IsParameterBound(c => c.EventHubAuthorizationRuleId) && 
                !this.IsParameterBound(c => c.WorkspaceId))
            {
                throw new ArgumentException("No operation is specified, please specify storage account Id/service bus rule Id/eventhub name/eventhub authorization rule Id/workspace Id");
            }

            if (!this.IsParameterBound(c => c.WorkspaceId) && this.IsParameterBound(c => c.DedicatedLogAnalyticsDestinationType))
            {
                throw new ArgumentException("Please provide workspace Id if want to use dedicated log analytics destination type");
            }
        }
    }
}
