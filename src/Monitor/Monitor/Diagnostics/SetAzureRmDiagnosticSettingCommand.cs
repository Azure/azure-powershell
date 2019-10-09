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
        public List<string> Category { get; set; }

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
        public List<string> Timegrain { get; set; }

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

        /// <summary>
        /// Gets or sets the retention in days
        /// </summary>
        [Parameter(ParameterSetName = SetAzureRmDiagnosticSettingOldParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether to export (to ODS) to resource-specific (if present) or to AzureDiagnostics (default, not present)")]
        public SwitchParameter ExportToResourceSpecific { get; set; }

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

                    try
                    {
                        WriteDebugWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Listing existing diagnostics settings for resourceId '{0}'", this.ResourceId));
                        IList<DiagnosticSettingsResource> listSettings = this.MonitorManagementClient.DiagnosticSettings.ListAsync(resourceUri: this.ResourceId, cancellationToken: CancellationToken.None).Result.Value;
                        DiagnosticSettingsResource singleResource = listSettings.FirstOrDefault(e => string.Equals(e.Name, settingName, StringComparison.OrdinalIgnoreCase));
                        if (singleResource == null)
                        {
                            // Creating a new setting with settingName as name
                            WriteDebugWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Diagnostic setting named: '{0}' not found in list of {1} settings. Creating a new one.", settingName, listSettings.Count));

                            properties = new DiagnosticSettingsResource();
                            properties.Logs = new List<LogSettings>();
                            properties.Metrics = new List<MetricSettings>();

                            WriteDebugWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Retrieving supported categories for resource: '{0}'", this.ResourceId));
                            IList<DiagnosticSettingsCategoryResource> supportedCategories = this.MonitorManagementClient.DiagnosticSettingsCategory.ListAsync(resourceUri: this.ResourceId, cancellationToken: CancellationToken.None).Result.Value;
                            if (supportedCategories != null)
                            {
                                WriteDebugWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Setting supported categories for resource: '{0}'", this.ResourceId));
                                foreach (var category in supportedCategories)
                                {
                                    if (category.CategoryType == CategoryType.Metrics)
                                    {
                                        properties.Metrics.Add(
                                            new MetricSettings(
                                                enabled: false,
                                                category: category.Name,
                                                retentionPolicy: null,
                                                timeGrain: null));
                                    }
                                    else
                                    {
                                        properties.Logs.Add(
                                            new LogSettings(
                                                enabled: false,
                                                category: category.Name,
                                                retentionPolicy: null));
                                    }
                                }
                            }
                            else
                            {
                                WriteWarningWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Resource: '{0}' does not support any category yet.", this.ResourceId));
                            }
                        }
                        else
                        {
                            // Updating existing name, regardless of name
                            WriteDebugWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Updating existing diagnostic setting '{0}'", settingName));
                            properties = singleResource;
                        }
                    }
                    catch (AggregateException ex)
                    {
                        WriteDebugWithTimestamp("Aggregate exception {0}", ex.ToString());
                        ErrorResponseException ex1 = ex.InnerException as ErrorResponseException;
                        if (ex1 != null && ex1.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            WriteDebugWithTimestamp("Inner exception is NotFound");
                            properties = new DiagnosticSettingsResource();
                            properties.Logs = new List<LogSettings>();
                            properties.Metrics = new List<MetricSettings>();
                        }
                        else
                        {
                            WriteDebugWithTimestamp("Inner exception is different NotFound: {0}", ex.InnerException.ToString());
                            throw ex.InnerException;
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteDebugWithTimestamp("Unexpected exception thrown: {0}", ex.ToString());
                        throw;
                    }

                    WriteDebugWithTimestamp("Merging data. Existing setting is: {0}", properties == null ? "null" : "not null");
                    SetStorage(properties);

                    SetServiceBus(properties);

                    SetEventHubRule(properties);

                    SetWorkspace(properties);

                    if (this.Category == null && this.MetricCategory == null && this.Timegrain == null)
                    {
                        WriteDebugWithTimestamp("Changing the enable properties");
                        SetAllCategoriesAndTimegrains(properties);
                    }
                    else
                    {
                        WriteDebugWithTimestamp("Setting categories and time grains");
                        if (this.Category != null)
                        {
                            SetSelectedCategories(properties);
                        }

                        if (this.MetricCategory != null)
                        {
                            SetSelectedMetricsCategories(properties);
                        }

                        if (this.Timegrain != null)
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

                WriteDebugWithTimestamp("Copying diagnostic settings");
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
                EventHubAuthorizationRuleId = properties.EventHubAuthorizationRuleId,
                ServiceBusRuleId = properties.ServiceBusRuleId,
                LogAnalyticsDestinationType = properties.LogAnalyticsDestinationType
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
                WriteDebugWithTimestamp("Setting retention policy for logs");
                foreach (LogSettings logSettings in properties.Logs)
                {
                    logSettings.RetentionPolicy = retentionPolicy;
                }
            }

            if (properties.Metrics != null)
            {
                WriteDebugWithTimestamp("Setting retention policy for metrics");
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
                throw new ArgumentException("Parameter 'Enabled' is required by 'Timegrain' parameter.");
            }

            if (this.Timegrain != null && this.Timegrain.Count > 0)
            {
                if (properties.Metrics == null)
                {
                    properties.Metrics = new List<MetricSettings>();
                }

                WriteWarningWithTimestamp("Deprecation: The timegain argument for metrics will be deprecated since the back end supports only PT1M. Currently it is ignored for backwards compatibility.");
                WriteDebugWithTimestamp("Setting Enabled property for metrics since timegrain argument is non-empty");
                foreach (MetricSettings metric in properties.Metrics)
                {
                    metric.Enabled = this.Enabled;
                }
            }
        }

        private void SetSelectedCategories(DiagnosticSettingsResource properties)
        {
            if (!this.isEnbledParameterPresent)
            {
                throw new ArgumentException("Parameter 'Enabled' is required by 'Category' parameter.");
            }

            WriteDebugWithTimestamp("Setting log categories, including Enabled property");
            if (properties.Logs == null)
            {
                properties.Logs = new List<LogSettings>();
            }

            foreach (string category in this.Category)
            {
                LogSettings logSettings = properties.Logs.FirstOrDefault(x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));
                if (logSettings == null)
                {
                    // if not there add it
                    logSettings = new LogSettings()
                    {
                        Category = category,
                        RetentionPolicy = new RetentionPolicy
                        {
                            Days = 0,
                            Enabled = false
                        },
                        Enabled = this.Enabled
                    };

                    properties.Logs.Add(logSettings);
                }
                else
                {
                    // else update it
                    logSettings.Enabled = this.Enabled;
                }
            }
        }

        private void SetSelectedMetricsCategories(DiagnosticSettingsResource properties)
        {
            if (!this.isEnbledParameterPresent)
            {
                throw new ArgumentException("Parameter 'Enabled' is required by 'MetricCategory' parameter.");
            }

            WriteDebugWithTimestamp("Setting metric categories, including Enabled property");
            if (properties.Metrics == null)
            {
                properties.Metrics = new List<MetricSettings>();
            }

            foreach (string category in this.MetricCategory)
            {
                MetricSettings metricSettings = properties.Metrics.FirstOrDefault(x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));

                if (metricSettings == null)
                {
                    // If not there add it
                    metricSettings = new MetricSettings
                    {
                        Category = category,
                        Enabled = this.Enabled,
                        RetentionPolicy = new RetentionPolicy
                        {
                            Days = 0,
                            Enabled = false
                        },
                        TimeGrain = null
                    };

                    properties.Metrics.Add(metricSettings);
                }
                else
                {
                    // else update it
                    metricSettings.Enabled = this.Enabled;
                }
            }
        }

        private void SetAllCategoriesAndTimegrains(DiagnosticSettingsResource properties)
        {
            if (!this.isEnbledParameterPresent)
            {
                return;
            }

            WriteDebugWithTimestamp("Setting Enabled property for logs");
            if (properties.Logs == null)
            {
                properties.Logs = new List<LogSettings>();
            }

            foreach (var log in properties.Logs)
            {
                log.Enabled = this.Enabled;
            }

            WriteDebugWithTimestamp("Setting Enabled property for metrics");
            if (properties.Metrics == null)
            {
                properties.Metrics = new List<MetricSettings>();
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
                WriteDebugWithTimestamp("Setting workspace Id");
                properties.WorkspaceId = this.WorkspaceId;

                WriteDebugWithTimestamp("Setting LogAnalyticsDestinationType");
                properties.LogAnalyticsDestinationType = this.ExportToResourceSpecific.IsPresent
                    ? "Dedicated"
                    : null;
            }
        }

        private void SetServiceBus(DiagnosticSettingsResource properties)
        {
            if (this.isServiceBusParamPresent)
            {
                WriteDebugWithTimestamp("Setting service bus rule Id");
                properties.ServiceBusRuleId = this.ServiceBusRuleId;
            }

            if (this.isEventHubParamPresent)
            {
                WriteDebugWithTimestamp("Setting event hub name");
                properties.EventHubName = this.EventHubName;
            }
        }

        private void SetEventHubRule(DiagnosticSettingsResource properties)
        {
            if (this.isEventHubRuleParamPresent)
            {
                WriteDebugWithTimestamp("Setting event hub rule Id");
                properties.EventHubAuthorizationRuleId = this.EventHubAuthorizationRuleId;
            }
        }

        private void SetStorage(DiagnosticSettingsResource properties)
        {
            if (this.isStorageParamPresent)
            {
                WriteDebugWithTimestamp("Setting storage account Id");
                properties.StorageAccountId = this.StorageAccountId;
            }
        }
    }
}
