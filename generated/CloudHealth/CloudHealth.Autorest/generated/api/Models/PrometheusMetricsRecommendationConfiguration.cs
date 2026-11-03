// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Extensions;

    /// <summary>Prometheus Metrics Query recommendation configuration.</summary>
    public partial class PrometheusMetricsRecommendationConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IPrometheusMetricsRecommendationConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IPrometheusMetricsRecommendationConfigurationInternal,
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
        /// Query text in PromQL syntax. Supported entity template variables, such as `{{entity.name}}`, may appear in the query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string QueryText { get => this._queryText; set => this._queryText = value; }

        /// <summary>Backing field for <see cref="RequiredMetric" /> property.</summary>
        private System.Collections.Generic.List<string> _requiredMetric;

        /// <summary>Prometheus metrics required by the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> RequiredMetric { get => this._requiredMetric; set => this._requiredMetric = value; }

        /// <summary>Backing field for <see cref="RequiredScrapeTarget" /> property.</summary>
        private System.Collections.Generic.List<string> _requiredScrapeTarget;

        /// <summary>Prometheus scrape targets required to populate the query's metrics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> RequiredScrapeTarget { get => this._requiredScrapeTarget; set => this._requiredScrapeTarget = value; }

        /// <summary>Kind of the recommended signal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Inherited)]
        public string SignalKind { get => "PrometheusMetricsQuery"; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)__signalRecommendationConfiguration).SignalKind = "PrometheusMetricsQuery"; }

        /// <summary>Backing field for <see cref="TimeGrain" /> property.</summary>
        private string _timeGrain;

        /// <summary>Time range of the signal in ISO 8601 duration format (e.g. 'PT5M').</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string TimeGrain { get => this._timeGrain; set => this._timeGrain = value; }

        /// <summary>
        /// Creates an new <see cref="PrometheusMetricsRecommendationConfiguration" /> instance.
        /// </summary>
        public PrometheusMetricsRecommendationConfiguration()
        {
            this.__signalRecommendationConfiguration.SignalKind = "PrometheusMetricsQuery";
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
    /// Prometheus Metrics Query recommendation configuration.
    public partial interface IPrometheusMetricsRecommendationConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration
    {
        /// <summary>
        /// Query text in PromQL syntax. Supported entity template variables, such as `{{entity.name}}`, may appear in the query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Query text in PromQL syntax. Supported entity template variables, such as `{{entity.name}}`, may appear in the query.",
        SerializedName = @"queryText",
        PossibleTypes = new [] { typeof(string) })]
        string QueryText { get; set; }
        /// <summary>Prometheus metrics required by the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Prometheus metrics required by the query.",
        SerializedName = @"requiredMetrics",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> RequiredMetric { get; set; }
        /// <summary>Prometheus scrape targets required to populate the query's metrics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Prometheus scrape targets required to populate the query's metrics.",
        SerializedName = @"requiredScrapeTargets",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> RequiredScrapeTarget { get; set; }
        /// <summary>Time range of the signal in ISO 8601 duration format (e.g. 'PT5M').</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Time range of the signal in ISO 8601 duration format (e.g. 'PT5M').",
        SerializedName = @"timeGrain",
        PossibleTypes = new [] { typeof(string) })]
        string TimeGrain { get; set; }

    }
    /// Prometheus Metrics Query recommendation configuration.
    internal partial interface IPrometheusMetricsRecommendationConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal
    {
        /// <summary>
        /// Query text in PromQL syntax. Supported entity template variables, such as `{{entity.name}}`, may appear in the query.
        /// </summary>
        string QueryText { get; set; }
        /// <summary>Prometheus metrics required by the query.</summary>
        System.Collections.Generic.List<string> RequiredMetric { get; set; }
        /// <summary>Prometheus scrape targets required to populate the query's metrics.</summary>
        System.Collections.Generic.List<string> RequiredScrapeTarget { get; set; }
        /// <summary>Time range of the signal in ISO 8601 duration format (e.g. 'PT5M').</summary>
        string TimeGrain { get; set; }

    }
}