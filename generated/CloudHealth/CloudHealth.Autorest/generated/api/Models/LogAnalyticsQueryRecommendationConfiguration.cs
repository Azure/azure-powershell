// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Extensions;

    /// <summary>Log Analytics Query recommendation configuration.</summary>
    public partial class LogAnalyticsQueryRecommendationConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ILogAnalyticsQueryRecommendationConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ILogAnalyticsQueryRecommendationConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration __signalRecommendationConfiguration = new Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalRecommendationConfiguration();

        /// <summary>Backing field for <see cref="QueryText" /> property.</summary>
        private string _queryText;

        /// <summary>
        /// Query text in KQL syntax. Supported entity template variables, such as `{{entity.azureResourceId}}`, may appear in the
        /// query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string QueryText { get => this._queryText; set => this._queryText = value; }

        /// <summary>Backing field for <see cref="RequiredDiagnosticSettingCategory" /> property.</summary>
        private System.Collections.Generic.List<string> _requiredDiagnosticSettingCategory;

        /// <summary>Diagnostic setting categories required to populate the query's tables.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> RequiredDiagnosticSettingCategory { get => this._requiredDiagnosticSettingCategory; set => this._requiredDiagnosticSettingCategory = value; }

        /// <summary>Backing field for <see cref="RequiredTable" /> property.</summary>
        private System.Collections.Generic.List<string> _requiredTable;

        /// <summary>Log Analytics tables required by the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> RequiredTable { get => this._requiredTable; set => this._requiredTable = value; }

        /// <summary>Kind of the recommended signal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Inherited)]
        public string SignalKind { get => "LogAnalyticsQuery"; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)__signalRecommendationConfiguration).SignalKind = "LogAnalyticsQuery"; }

        /// <summary>Backing field for <see cref="TimeGrain" /> property.</summary>
        private string _timeGrain;

        /// <summary>
        /// Time range of the signal in ISO 8601 duration format (e.g. 'PT5M'). If not specified, the KQL query must define a time
        /// range.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string TimeGrain { get => this._timeGrain; set => this._timeGrain = value; }

        /// <summary>Backing field for <see cref="ValueColumnName" /> property.</summary>
        private string _valueColumnName;

        /// <summary>Name of the numeric result column to evaluate against the thresholds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string ValueColumnName { get => this._valueColumnName; set => this._valueColumnName = value; }

        /// <summary>
        /// Creates an new <see cref="LogAnalyticsQueryRecommendationConfiguration" /> instance.
        /// </summary>
        public LogAnalyticsQueryRecommendationConfiguration()
        {
            this.__signalRecommendationConfiguration.SignalKind = "LogAnalyticsQuery";
        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__signalRecommendationConfiguration), __signalRecommendationConfiguration);
            await eventListener.AssertObjectIsValid(nameof(__signalRecommendationConfiguration), __signalRecommendationConfiguration);
        }
    }
    /// Log Analytics Query recommendation configuration.
    public partial interface ILogAnalyticsQueryRecommendationConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration
    {
        /// <summary>
        /// Query text in KQL syntax. Supported entity template variables, such as `{{entity.azureResourceId}}`, may appear in the
        /// query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Query text in KQL syntax. Supported entity template variables, such as `{{entity.azureResourceId}}`, may appear in the query.",
        SerializedName = @"queryText",
        PossibleTypes = new [] { typeof(string) })]
        string QueryText { get; set; }
        /// <summary>Diagnostic setting categories required to populate the query's tables.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Diagnostic setting categories required to populate the query's tables.",
        SerializedName = @"requiredDiagnosticSettingCategories",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> RequiredDiagnosticSettingCategory { get; set; }
        /// <summary>Log Analytics tables required by the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Log Analytics tables required by the query.",
        SerializedName = @"requiredTables",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> RequiredTable { get; set; }
        /// <summary>
        /// Time range of the signal in ISO 8601 duration format (e.g. 'PT5M'). If not specified, the KQL query must define a time
        /// range.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Time range of the signal in ISO 8601 duration format (e.g. 'PT5M'). If not specified, the KQL query must define a time range.",
        SerializedName = @"timeGrain",
        PossibleTypes = new [] { typeof(string) })]
        string TimeGrain { get; set; }
        /// <summary>Name of the numeric result column to evaluate against the thresholds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the numeric result column to evaluate against the thresholds.",
        SerializedName = @"valueColumnName",
        PossibleTypes = new [] { typeof(string) })]
        string ValueColumnName { get; set; }

    }
    /// Log Analytics Query recommendation configuration.
    internal partial interface ILogAnalyticsQueryRecommendationConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal
    {
        /// <summary>
        /// Query text in KQL syntax. Supported entity template variables, such as `{{entity.azureResourceId}}`, may appear in the
        /// query.
        /// </summary>
        string QueryText { get; set; }
        /// <summary>Diagnostic setting categories required to populate the query's tables.</summary>
        System.Collections.Generic.List<string> RequiredDiagnosticSettingCategory { get; set; }
        /// <summary>Log Analytics tables required by the query.</summary>
        System.Collections.Generic.List<string> RequiredTable { get; set; }
        /// <summary>
        /// Time range of the signal in ISO 8601 duration format (e.g. 'PT5M'). If not specified, the KQL query must define a time
        /// range.
        /// </summary>
        string TimeGrain { get; set; }
        /// <summary>Name of the numeric result column to evaluate against the thresholds.</summary>
        string ValueColumnName { get; set; }

    }
}