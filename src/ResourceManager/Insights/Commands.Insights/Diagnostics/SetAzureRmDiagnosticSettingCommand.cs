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
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Get the list of events for at a subscription level.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiagnosticSetting", SupportsShouldProcess = true, DefaultParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup), OutputType(typeof(PSServiceDiagnosticSettings))]
    public class SetAzureRmDiagnosticSettingCommand : ManagementCmdletBase
    {
        internal const string SetAzureRmDiagnosticSettingOldParamGroup = "OldSetDiagnosticSetting";
        internal const string SetAzureRmDiagnosticSettingNewParamGroup = "NewSetDiagnosticSetting";

        public const string StorageAccountIdParamName = "StorageAccountId";
        public const string ServiceBusRuleIdParamName = "ServiceBusRuleId";
        public const string EventHubNameParamName = "EventHubName";
        public const string EventHubRuleIdParamName = "EventHubAuthorizationRuleId";
        public const string WorkspacetIdParamName = "WorkspaceId";
        public const string EnabledParamName = "Enabled";

        /// <summary>
        /// This is a temporary constant to provide backwards compatibility
        /// </summary>
        internal const string TempServiceName = "service";

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the InputObject parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingNewParamGroup, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The complete spec of a DiagnosticSettingSetting")]
        [ValidateNotNullOrEmpty]
        public PSServiceDiagnosticSettings InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the diagnostic setting. Defaults to 'service'")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the storage account parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The storage account id")]
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the service bus rule id parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The service bus rule id")]
        public string ServiceBusRuleId { get; set; }

        /// <summary>
        /// Gets or sets the service bus rule id parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The service bus rule id")]
        public string EventHubName { get; set; }

        /// <summary>
        /// Gets or sets the event hub authorization rule id parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The event hub rule id")]
        public string EventHubAuthorizationRuleId { get; set; }

        /// <summary>
        /// Gets or sets the enable parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether the diagnostics should be enabled or disabled")]
        [ValidateNotNullOrEmpty]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the categories parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The log categories")]
        [ValidateNotNullOrEmpty]
        [Alias("Category")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the metrics category parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of metric categories")]
        [ValidateNotNullOrEmpty]
        public List<string> MetricCategory { get; set; }

        /// <summary>
        /// Gets or sets the timegrain parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The timegrains")]
        [ValidateNotNullOrEmpty]
        [Alias("Timegrain")]
        public List<string> Timegrains { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether retention should be enabled
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether the retention should be enabled")]
        [ValidateNotNullOrEmpty]
        public bool? RetentionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the OMS workspace Id
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id of the Log Analytics workspace to send logs/metrics to")]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the retention in days
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The retention in days.")]
        public int? RetentionInDays { get; set; }

        #endregion

        private bool isStorageParamPresent;

        private bool isServiceBusParamPresent;

        private bool isEventHubParamPresent;

        private bool isEventHubRuleParamPresent;

        private bool isWorkspaceParamPresent;

        private bool isEnbledParameterPresent;

        protected override void ProcessRecordInternal()
        {
            if (ShouldProcess(
                target: string.Format("Create/update a diagnostic setting for resource Id: {0}", this.ResourceId),
                action: "Create/update a diagnostic setting"))
            {
                WriteWarningWithTimestamp("The arguments Categories and Timegrains now have aliases Category and Timegrain respectively. The plural names will be removed in future releases.");
                DiagnosticSettingsResource properties;

                // Name defaults to 'service'
                string settingName = string.IsNullOrWhiteSpace(this.Name) ? TempServiceName : this.Name.Trim();

                if (this.InputObject == null)
                {
                    // If InputObject is null process the way it was done before
                    WriteDebugWithTimestamp("Processing using command line arguments");
                    HashSet<string> usedParams = new HashSet<string>(this.MyInvocation.BoundParameters.Keys, StringComparer.OrdinalIgnoreCase);

                    this.isStorageParamPresent = usedParams.Contains(StorageAccountIdParamName);
                    this.isServiceBusParamPresent = usedParams.Contains(ServiceBusRuleIdParamName);
                    this.isEventHubParamPresent = usedParams.Contains(EventHubNameParamName);
                    this.isEventHubRuleParamPresent = usedParams.Contains(EventHubRuleIdParamName);
                    this.isWorkspaceParamPresent = usedParams.Contains(WorkspacetIdParamName);
                    this.isEnbledParameterPresent = usedParams.Contains(EnabledParamName);

                    if (!this.isStorageParamPresent &&
                        !this.isServiceBusParamPresent &&
                        !this.isEventHubParamPresent &&
                        !this.isEventHubRuleParamPresent &&
                        !this.isWorkspaceParamPresent &&
                        !this.isEnbledParameterPresent)
                    {
                        throw new ArgumentException("No operation is specified");
                    }

                    WriteDebugWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Getting existing diagnostics setting called '{0}'", settingName));
                    properties = this.MonitorManagementClient.DiagnosticSettings.GetAsync(resourceUri: this.ResourceId, name: settingName, cancellationToken: CancellationToken.None).Result;

                    WriteDebugWithTimestamp("Merging data. Existing setting is: {0}", properties == null ? "null" : "not null");
                    SetStorage(properties);

                    // TODO: make sure that ServiceBusRuleId is not being used anymore.
                    SetServiceBus(properties);

                    SetEventHubRule(properties);

                    SetWorkspace(properties);

                    if (this.Categories == null && this.MetricCategory == null && this.Timegrains == null)
                    {
                        WriteDebugWithTimestamp("Changing the enable properties");
                        SetAllCategoriesAndTimegrains(properties);
                    }
                    else
                    {
                        WriteDebugWithTimestamp("Setting categories and time grains");
                        if (this.Categories != null)
                        {
                            SetSelectedCategories(properties);
                        }

                        if (this.MetricCategory != null)
                        {
                            SetSelectedMetricsCategories(properties);
                        }

                        if (this.Timegrains != null)
                        {
                            SetSelectedTimegrains(properties);
                        }
                    }

                    if (this.RetentionEnabled.HasValue)
                    {
                        WriteDebugWithTimestamp("Setting retention");
                        SetRetention(properties);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.InputObject.Id) || string.IsNullOrWhiteSpace(this.InputObject.Name))
                    {
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "InputObject is inconsistent: Id is incomplete or malformed, Id: '{0}', Name: '{1}'", this.InputObject.Id, this.InputObject.Name));
                    }

                    // This is new functionality to keep the previous as it was before
                    WriteDebugWithTimestamp("Processing using InputObject");
                    properties = this.InputObject;

                    // Take Name and ResourceId from the input Object
                    string idSuffix = "/diagnosticSettings/" + this.InputObject.Name;
                    bool foundCue = this.InputObject.Id.EndsWith(idSuffix);
                    if (foundCue)
                    {
                        this.ResourceId = this.InputObject.Id.Substring(0, this.InputObject.Id.Length - idSuffix.Length);
                        settingName = this.InputObject.Name;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "InputObject is inconsistent: Id is incomplete or malformed, Id: '{0}', Name: '{1}'", this.InputObject.Id, this.InputObject.Name));
                    }
                }

                DiagnosticSettingsResource putParameters = CopySettings(properties);

                WriteDebugWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Sending create/update request setting: {0}", settingName));
                DiagnosticSettingsResource result = this.MonitorManagementClient.DiagnosticSettings.CreateOrUpdateAsync(
                    resourceUri: this.ResourceId, 
                    name: settingName, 
                    parameters: putParameters, 
                    cancellationToken: CancellationToken.None).Result;

                WriteDebugWithTimestamp("Successful operation. Sending output");
                WriteObject(new PSServiceDiagnosticSettings(result));
            }
        }

        private static DiagnosticSettingsResource CopySettings(DiagnosticSettingsResource properties)
        {
            // Location is marked as required, but the get operation returns Location as null. So use an empty string instead of null to avoid validation errors
            var putParameters = new DiagnosticSettingsResource(name: properties.Name, id: properties.Id, type: properties.Type)
            {
                Logs = properties.Logs,
                Metrics = properties.Metrics,
                EventHubName = properties.EventHubName,                
                StorageAccountId = properties.StorageAccountId,
                WorkspaceId = properties.WorkspaceId,
                EventHubAuthorizationRuleId = properties.EventHubAuthorizationRuleId
            };
            return putParameters;
        }

        private void SetRetention(DiagnosticSettingsResource properties)
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

        private void SetSelectedTimegrains(DiagnosticSettingsResource properties)
        {
            if (!this.isEnbledParameterPresent)
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
                metricSettings.Enabled = this.Enabled;
            }
        }

        private void SetSelectedCategories(DiagnosticSettingsResource properties)
        {
            if (!this.isEnbledParameterPresent)
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

                logSettings.Enabled = this.Enabled;
            }
        }

        private void SetSelectedMetricsCategories(DiagnosticSettingsResource properties)
        {
            if (!this.isEnbledParameterPresent)
            {
                throw new ArgumentException("Parameter 'Enabled' is required by 'MetricCategory' parameter.");
            }

            foreach (string category in this.MetricCategory)
            {
                MetricSettings metricSettings = properties.Metrics.FirstOrDefault(x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));

                if (metricSettings == null)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Metric category '{0}' is not available", category));
                }

                metricSettings.Enabled = this.Enabled;
            }
        }


        private void SetAllCategoriesAndTimegrains(DiagnosticSettingsResource properties)
        {
            if (!this.isEnbledParameterPresent)
            {
                return;
            }

            foreach (var log in properties.Logs)
            {
                log.Enabled = this.Enabled;
            }

            foreach (var metric in properties.Metrics)
            {
                metric.Enabled = this.Enabled;
            }
        }

        private void SetWorkspace(DiagnosticSettingsResource properties)
        {
            if (this.isWorkspaceParamPresent)
            {
                properties.WorkspaceId = this.WorkspaceId;
            }
        }

        private void SetServiceBus(DiagnosticSettingsResource properties)
        {
            if (this.isServiceBusParamPresent)
            {
                properties.EventHubName = this.ServiceBusRuleId;
            }

            if (this.isEventHubParamPresent)
            {
                properties.EventHubName = this.EventHubName;
            }
        }

        private void SetEventHubRule(DiagnosticSettingsResource properties)
        {
            if (this.isEventHubRuleParamPresent)
            {
                properties.EventHubAuthorizationRuleId = this.EventHubAuthorizationRuleId;
            }
        }


        private void SetStorage(DiagnosticSettingsResource properties)
        {
            if (this.isStorageParamPresent)
            {
                properties.StorageAccountId = this.StorageAccountId;
            }
        }
    }
}
