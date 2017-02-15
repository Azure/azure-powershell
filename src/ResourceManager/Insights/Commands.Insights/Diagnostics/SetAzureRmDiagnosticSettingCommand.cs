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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Xml;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Get the list of events for at a subscription level.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmDiagnosticSetting"), OutputType(typeof(PSServiceDiagnosticSettings))]
    public class SetAzureRmDiagnosticSettingCommand : ManagementCmdletBase
    {
        public const string StorageAccountIdParamName = "StorageAccountId";
        public const string ServiceBusRuleIdParamName = "ServiceBusRuleId";
        public const string WorkspacetIdParamName = "WorkspaceId";

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the storage account parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The storage account id")]
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the service bus rule id parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The service bus rule id")]
        public string ServiceBusRuleId { get; set; }

        /// <summary>
        /// Gets or sets the enable parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether the diagnostics should be enabled or disabled")]
        [ValidateNotNullOrEmpty]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the categories parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The log categories")]
        [ValidateNotNullOrEmpty]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the timegrain parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The timegrains")]
        [ValidateNotNullOrEmpty]
        public List<string> Timegrains { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether retention should be enabled
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether the retention should be enabled")]
        [ValidateNotNullOrEmpty]
        public bool? RetentionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the OMS workspace Id
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id of the Log Analytics workspace to send logs/metrics to")]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the retention in days
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The retention in days.")]
        public int? RetentionInDays { get; set; }

        #endregion

        private bool isStorageParamPresent;

        private bool isServiceBusParamPresent;

        private bool isWorkspaceParamPresent;

        protected override void ProcessRecordInternal()
        {
            HashSet<string> usedParams = new HashSet<string>(this.MyInvocation.BoundParameters.Keys, StringComparer.OrdinalIgnoreCase);

            this.isStorageParamPresent = usedParams.Contains(StorageAccountIdParamName);
            this.isServiceBusParamPresent = usedParams.Contains(ServiceBusRuleIdParamName);
            this.isWorkspaceParamPresent = usedParams.Contains(WorkspacetIdParamName);

            if (!this.isStorageParamPresent &&
                !this.isServiceBusParamPresent &&
                !this.isWorkspaceParamPresent &&
                !this.Enabled.HasValue)
            {
                throw new ArgumentException("No operation is specified");
            }

            ServiceDiagnosticSettingsResource getResponse = this.InsightsManagementClient.ServiceDiagnosticSettings.GetAsync(resourceUri: this.ResourceId, cancellationToken: CancellationToken.None).Result;

            ServiceDiagnosticSettingsResource properties = getResponse;

            SetStorage(properties);

            SetServiceBus(properties);

            SetWorkspace(properties);

            if (this.Categories == null && this.Timegrains == null)
            {
                SetAllCategoriesAndTimegrains(properties);
            }
            else
            {
                if (this.Categories != null)
                {
                    SetSelectedCategories(properties);
                }

                if (this.Timegrains != null)
                {
                    SetSelectedTimegrains(properties);
                }
            }

            if (this.RetentionEnabled.HasValue)
            {
                SetRetention(properties);
            }

            var putParameters = CopySettings(properties);

            ServiceDiagnosticSettingsResource result = this.InsightsManagementClient.ServiceDiagnosticSettings.CreateOrUpdateAsync(resourceUri: this.ResourceId, parameters: putParameters, cancellationToken: CancellationToken.None).Result;
            WriteObject(result);
        }

        private static ServiceDiagnosticSettingsResource CopySettings(ServiceDiagnosticSettingsResource properties)
        {
            var putParameters = new ServiceDiagnosticSettingsResource(location: string.Empty);
            putParameters.Logs = properties.Logs;
            putParameters.Metrics = properties.Metrics;
            putParameters.ServiceBusRuleId = properties.ServiceBusRuleId;
            putParameters.StorageAccountId = properties.StorageAccountId;
            putParameters.WorkspaceId = properties.WorkspaceId;
            return putParameters;
        }

        private void SetRetention(ServiceDiagnosticSettingsResource properties)
        {
            var retentionPolicy = new RetentionPolicy
            {
                Enabled = this.RetentionEnabled.Value,
                Days = this.RetentionInDays.Value
            };

            if (properties.Logs != null)
            {
                foreach (LogSettings logSettings in properties.Logs)
                {
                    logSettings.RetentionPolicy = retentionPolicy;
                }
            }

            if (properties.Metrics != null)
            {
                foreach (MetricSettings metricSettings in properties.Metrics)
                {
                    metricSettings.RetentionPolicy = retentionPolicy;
                }
            }
        }

        private void SetSelectedTimegrains(ServiceDiagnosticSettingsResource properties)
        {
            if (!this.Enabled.HasValue)
            {
                throw new ArgumentException("Parameter 'Enabled' is required by 'Timegrains' parameter.");
            }

            foreach (string timegrainString in this.Timegrains)
            {
                TimeSpan timegrain = XmlConvert.ToTimeSpan(timegrainString);
                MetricSettings metricSettings = properties.Metrics.FirstOrDefault(x => TimeSpan.Equals(x.TimeGrain, timegrain));

                if (metricSettings == null)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Metric timegrain '{0}' is not available", timegrainString));
                }
                metricSettings.Enabled = this.Enabled.Value;
            }
        }

        private void SetSelectedCategories(ServiceDiagnosticSettingsResource properties)
        {
            if (!this.Enabled.HasValue)
            {
                throw new ArgumentException("Parameter 'Enabled' is required by 'Categories' parameter.");
            }

            foreach (string category in this.Categories)
            {
                LogSettings logSettings = properties.Logs.FirstOrDefault(x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));

                if (logSettings == null)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Log category '{0}' is not available", category));
                }

                logSettings.Enabled = this.Enabled.Value;
            }
        }

        private void SetAllCategoriesAndTimegrains(ServiceDiagnosticSettingsResource properties)
        {
            if (!this.Enabled.HasValue)
            {
                return;
            }

            foreach (var log in properties.Logs)
            {
                log.Enabled = this.Enabled.Value;
            }

            foreach (var metric in properties.Metrics)
            {
                metric.Enabled = this.Enabled.Value;
            }
        }

        private void SetWorkspace(ServiceDiagnosticSettingsResource properties)
        {
            if (this.isWorkspaceParamPresent)
            {
                properties.WorkspaceId = this.WorkspaceId;
            }
        }

        private void SetServiceBus(ServiceDiagnosticSettingsResource properties)
        {
            if (this.isServiceBusParamPresent)
            {
                properties.ServiceBusRuleId = this.ServiceBusRuleId;
            }
        }

        private void SetStorage(ServiceDiagnosticSettingsResource properties)
        {
            if (this.isStorageParamPresent)
            {
                properties.StorageAccountId = this.StorageAccountId;
            }
        }
    }
}
