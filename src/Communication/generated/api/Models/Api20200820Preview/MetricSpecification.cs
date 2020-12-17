namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
    public partial class MetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecificationInternal
    {

        /// <summary>Backing field for <see cref="AggregationType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.AggregationType? _aggregationType;

        /// <summary>The method for aggregating the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.AggregationType? AggregationType { get => this._aggregationType; set => this._aggregationType = value; }

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>
        /// The name of the metric category that the metric belongs to. A metric can only belong to a single category.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="Dimension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IDimension[] _dimension;

        /// <summary>The dimensions of the metrics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IDimension[] Dimension { get => this._dimension; set => this._dimension = value; }

        /// <summary>Backing field for <see cref="DisplayDescription" /> property.</summary>
        private string _displayDescription;

        /// <summary>Localized friendly description of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string DisplayDescription { get => this._displayDescription; set => this._displayDescription = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Localized friendly display name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="FillGapWithZero" /> property.</summary>
        private string _fillGapWithZero;

        /// <summary>
        /// Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.
        /// Ex. a metric that returns the number of times a particular error code was emitted. The error code may not appear
        /// often, instead of the RP publishing 0, Shoebox can auto fill in 0s for time periods where nothing was emitted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string FillGapWithZero { get => this._fillGapWithZero; set => this._fillGapWithZero = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>The unit that makes sense for the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="MetricSpecification" /> instance.</summary>
        public MetricSpecification()
        {

        }
    }
    /// Specifications of the Metrics for Azure Monitoring.
    public partial interface IMetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>The method for aggregating the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The method for aggregating the metric.",
        SerializedName = @"aggregationType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.AggregationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.AggregationType? AggregationType { get; set; }
        /// <summary>
        /// The name of the metric category that the metric belongs to. A metric can only belong to a single category.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the metric category that the metric belongs to. A metric can only belong to a single category.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get; set; }
        /// <summary>The dimensions of the metrics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The dimensions of the metrics.",
        SerializedName = @"dimensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IDimension) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IDimension[] Dimension { get; set; }
        /// <summary>Localized friendly description of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly description of the metric.",
        SerializedName = @"displayDescription",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly display name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly display name of the metric.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>
        /// Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.
        /// Ex. a metric that returns the number of times a particular error code was emitted. The error code may not appear
        /// often, instead of the RP publishing 0, Shoebox can auto fill in 0s for time periods where nothing was emitted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.
        Ex. a metric that returns the number of times a particular error code was emitted. The error code may not appear
        often, instead of the RP publishing 0, Shoebox can auto fill in 0s for time periods where nothing was emitted.",
        SerializedName = @"fillGapWithZero",
        PossibleTypes = new [] { typeof(string) })]
        string FillGapWithZero { get; set; }
        /// <summary>Name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the metric.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The unit that makes sense for the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The unit that makes sense for the metric.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    /// Specifications of the Metrics for Azure Monitoring.
    internal partial interface IMetricSpecificationInternal

    {
        /// <summary>The method for aggregating the metric.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.AggregationType? AggregationType { get; set; }
        /// <summary>
        /// The name of the metric category that the metric belongs to. A metric can only belong to a single category.
        /// </summary>
        string Category { get; set; }
        /// <summary>The dimensions of the metrics.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IDimension[] Dimension { get; set; }
        /// <summary>Localized friendly description of the metric.</summary>
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly display name of the metric.</summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.
        /// Ex. a metric that returns the number of times a particular error code was emitted. The error code may not appear
        /// often, instead of the RP publishing 0, Shoebox can auto fill in 0s for time periods where nothing was emitted.
        /// </summary>
        string FillGapWithZero { get; set; }
        /// <summary>Name of the metric.</summary>
        string Name { get; set; }
        /// <summary>The unit that makes sense for the metric.</summary>
        string Unit { get; set; }

    }
}