// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Extensions;

    /// <summary>A signal configuration for an Azure resource type</summary>
    public partial class SignalConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal
    {

        /// <summary>Backing field for <see cref="ApplicableResourceType" /> property.</summary>
        private System.Collections.Generic.List<string> _applicableResourceType;

        /// <summary>Azure resource types to which the recommended signal configuration applies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> ApplicableResourceType { get => this._applicableResourceType; set => this._applicableResourceType = value; }

        /// <summary>Backing field for <see cref="Configuration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration _configuration;

        /// <summary>Kind-specific settings for the recommended signal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration Configuration { get => (this._configuration = this._configuration ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalRecommendationConfiguration()); set => this._configuration = value; }

        /// <summary>Kind of the recommended signal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Inlined)]
        public string ConfigurationSignalKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)Configuration).SignalKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)Configuration).SignalKind = value ; }

        /// <summary>Backing field for <see cref="DataUnit" /> property.</summary>
        private string _dataUnit;

        /// <summary>
        /// Unit of the recommended signal result (e.g. Bytes, MilliSeconds, Percent, Count).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string DataUnit { get => this._dataUnit; set => this._dataUnit = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the recommended signal configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name of the recommended signal configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="EvaluationRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEvaluationRule _evaluationRule;

        /// <summary>Evaluation rules with recommended thresholds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEvaluationRule EvaluationRule { get => (this._evaluationRule = this._evaluationRule ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.EvaluationRule()); set => this._evaluationRule = value; }

        /// <summary>Internal Acessors for Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal.Configuration { get => (this._configuration = this._configuration ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalRecommendationConfiguration()); set { {_configuration = value;} } }

        /// <summary>Backing field for <see cref="RefreshInterval" /> property.</summary>
        private string _refreshInterval;

        /// <summary>Interval in which the recommended signal is evaluated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string RefreshInterval { get => this._refreshInterval; set => this._refreshInterval = value; }

        /// <summary>Backing field for <see cref="SignalId" /> property.</summary>
        private string _signalId;

        /// <summary>Unique identifier of the recommended signal configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string SignalId { get => this._signalId; set => this._signalId = value; }

        /// <summary>Creates an new <see cref="SignalConfiguration" /> instance.</summary>
        public SignalConfiguration()
        {

        }
    }
    /// A signal configuration for an Azure resource type
    public partial interface ISignalConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IJsonSerializable
    {
        /// <summary>Azure resource types to which the recommended signal configuration applies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Azure resource types to which the recommended signal configuration applies.",
        SerializedName = @"applicableResourceTypes",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ApplicableResourceType { get; set; }
        /// <summary>Kind of the recommended signal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Kind of the recommended signal.",
        SerializedName = @"signalKind",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("AzureResourceMetric", "LogAnalyticsQuery", "PrometheusMetricsQuery")]
        string ConfigurationSignalKind { get; set; }
        /// <summary>
        /// Unit of the recommended signal result (e.g. Bytes, MilliSeconds, Percent, Count).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Unit of the recommended signal result (e.g. Bytes, MilliSeconds, Percent, Count).",
        SerializedName = @"dataUnit",
        PossibleTypes = new [] { typeof(string) })]
        string DataUnit { get; set; }
        /// <summary>Description of the recommended signal configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Description of the recommended signal configuration.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Display name of the recommended signal configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Display name of the recommended signal configuration.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Evaluation rules with recommended thresholds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Evaluation rules with recommended thresholds.",
        SerializedName = @"evaluationRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEvaluationRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEvaluationRule EvaluationRule { get; set; }
        /// <summary>Interval in which the recommended signal is evaluated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Interval in which the recommended signal is evaluated.",
        SerializedName = @"refreshInterval",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("PT1M", "PT5M", "PT10M", "PT15M", "PT30M", "PT1H", "PT2H")]
        string RefreshInterval { get; set; }
        /// <summary>Unique identifier of the recommended signal configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Unique identifier of the recommended signal configuration.",
        SerializedName = @"signalId",
        PossibleTypes = new [] { typeof(string) })]
        string SignalId { get; set; }

    }
    /// A signal configuration for an Azure resource type
    internal partial interface ISignalConfigurationInternal

    {
        /// <summary>Azure resource types to which the recommended signal configuration applies.</summary>
        System.Collections.Generic.List<string> ApplicableResourceType { get; set; }
        /// <summary>Kind-specific settings for the recommended signal.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration Configuration { get; set; }
        /// <summary>Kind of the recommended signal.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("AzureResourceMetric", "LogAnalyticsQuery", "PrometheusMetricsQuery")]
        string ConfigurationSignalKind { get; set; }
        /// <summary>
        /// Unit of the recommended signal result (e.g. Bytes, MilliSeconds, Percent, Count).
        /// </summary>
        string DataUnit { get; set; }
        /// <summary>Description of the recommended signal configuration.</summary>
        string Description { get; set; }
        /// <summary>Display name of the recommended signal configuration.</summary>
        string DisplayName { get; set; }
        /// <summary>Evaluation rules with recommended thresholds.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEvaluationRule EvaluationRule { get; set; }
        /// <summary>Interval in which the recommended signal is evaluated.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("PT1M", "PT5M", "PT10M", "PT15M", "PT30M", "PT1H", "PT2H")]
        string RefreshInterval { get; set; }
        /// <summary>Unique identifier of the recommended signal configuration.</summary>
        string SignalId { get; set; }

    }
}