// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Extensions;

    /// <summary>Azure Resource Metric recommendation configuration.</summary>
    public partial class AzureResourceMetricRecommendationConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration __signalRecommendationConfiguration = new Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalRecommendationConfiguration();

        /// <summary>Backing field for <see cref="AggregationType" /> property.</summary>
        private string _aggregationType;

        /// <summary>Type of aggregation to apply to the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string AggregationType { get => this._aggregationType; set => this._aggregationType = value; }

        /// <summary>Backing field for <see cref="DimensionFilter" /> property.</summary>
        private string _dimensionFilter;

        /// <summary>Optional dimension filter to apply to the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string DimensionFilter { get => this._dimensionFilter; set => this._dimensionFilter = value; }

        /// <summary>Backing field for <see cref="MetricName" /> property.</summary>
        private string _metricName;

        /// <summary>Name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string MetricName { get => this._metricName; set => this._metricName = value; }

        /// <summary>Backing field for <see cref="MetricNamespace" /> property.</summary>
        private string _metricNamespace;

        /// <summary>Metric namespace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string MetricNamespace { get => this._metricNamespace; set => this._metricNamespace = value; }

        /// <summary>Kind of the recommended signal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Inherited)]
        public string SignalKind { get => "AzureResourceMetric"; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)__signalRecommendationConfiguration).SignalKind = "AzureResourceMetric"; }

        /// <summary>Backing field for <see cref="TimeGrain" /> property.</summary>
        private string _timeGrain;

        /// <summary>Time range of the metric in ISO 8601 duration format (e.g. 'PT5M').</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string TimeGrain { get => this._timeGrain; set => this._timeGrain = value; }

        /// <summary>
        /// Creates an new <see cref="AzureResourceMetricRecommendationConfiguration" /> instance.
        /// </summary>
        public AzureResourceMetricRecommendationConfiguration()
        {
            this.__signalRecommendationConfiguration.SignalKind = "AzureResourceMetric";
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
    /// Azure Resource Metric recommendation configuration.
    public partial interface IAzureResourceMetricRecommendationConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration
    {
        /// <summary>Type of aggregation to apply to the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of aggregation to apply to the metric.",
        SerializedName = @"aggregationType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("None", "Average", "Count", "Minimum", "Maximum", "Total")]
        string AggregationType { get; set; }
        /// <summary>Optional dimension filter to apply to the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Optional dimension filter to apply to the metric.",
        SerializedName = @"dimensionFilter",
        PossibleTypes = new [] { typeof(string) })]
        string DimensionFilter { get; set; }
        /// <summary>Name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the metric.",
        SerializedName = @"metricName",
        PossibleTypes = new [] { typeof(string) })]
        string MetricName { get; set; }
        /// <summary>Metric namespace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Metric namespace.",
        SerializedName = @"metricNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string MetricNamespace { get; set; }
        /// <summary>Time range of the metric in ISO 8601 duration format (e.g. 'PT5M').</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Time range of the metric in ISO 8601 duration format (e.g. 'PT5M').",
        SerializedName = @"timeGrain",
        PossibleTypes = new [] { typeof(string) })]
        string TimeGrain { get; set; }

    }
    /// Azure Resource Metric recommendation configuration.
    internal partial interface IAzureResourceMetricRecommendationConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal
    {
        /// <summary>Type of aggregation to apply to the metric.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("None", "Average", "Count", "Minimum", "Maximum", "Total")]
        string AggregationType { get; set; }
        /// <summary>Optional dimension filter to apply to the metric.</summary>
        string DimensionFilter { get; set; }
        /// <summary>Name of the metric.</summary>
        string MetricName { get; set; }
        /// <summary>Metric namespace.</summary>
        string MetricNamespace { get; set; }
        /// <summary>Time range of the metric in ISO 8601 duration format (e.g. 'PT5M').</summary>
        string TimeGrain { get; set; }

    }
}