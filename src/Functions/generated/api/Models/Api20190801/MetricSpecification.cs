namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Definition of a single resource metric.</summary>
    public partial class MetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecificationInternal
    {

        /// <summary>Backing field for <see cref="AggregationType" /> property.</summary>
        private string _aggregationType;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AggregationType { get => this._aggregationType; set => this._aggregationType = value; }

        /// <summary>Backing field for <see cref="Availability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricAvailability[] _availability;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricAvailability[] Availability { get => this._availability; set => this._availability = value; }

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="Dimension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDimension[] _dimension;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDimension[] Dimension { get => this._dimension; set => this._dimension = value; }

        /// <summary>Backing field for <see cref="DisplayDescription" /> property.</summary>
        private string _displayDescription;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayDescription { get => this._displayDescription; set => this._displayDescription = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="EnableRegionalMdmAccount" /> property.</summary>
        private bool? _enableRegionalMdmAccount;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? EnableRegionalMdmAccount { get => this._enableRegionalMdmAccount; set => this._enableRegionalMdmAccount = value; }

        /// <summary>Backing field for <see cref="FillGapWithZero" /> property.</summary>
        private bool? _fillGapWithZero;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? FillGapWithZero { get => this._fillGapWithZero; set => this._fillGapWithZero = value; }

        /// <summary>Backing field for <see cref="IsInternal" /> property.</summary>
        private bool? _isInternal;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsInternal { get => this._isInternal; set => this._isInternal = value; }

        /// <summary>Backing field for <see cref="MetricFilterPattern" /> property.</summary>
        private string _metricFilterPattern;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MetricFilterPattern { get => this._metricFilterPattern; set => this._metricFilterPattern = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="SourceMdmAccount" /> property.</summary>
        private string _sourceMdmAccount;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SourceMdmAccount { get => this._sourceMdmAccount; set => this._sourceMdmAccount = value; }

        /// <summary>Backing field for <see cref="SourceMdmNamespace" /> property.</summary>
        private string _sourceMdmNamespace;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SourceMdmNamespace { get => this._sourceMdmNamespace; set => this._sourceMdmNamespace = value; }

        /// <summary>Backing field for <see cref="SupportedTimeGrainType" /> property.</summary>
        private string[] _supportedTimeGrainType;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] SupportedTimeGrainType { get => this._supportedTimeGrainType; set => this._supportedTimeGrainType = value; }

        /// <summary>Backing field for <see cref="SupportsInstanceLevelAggregation" /> property.</summary>
        private bool? _supportsInstanceLevelAggregation;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? SupportsInstanceLevelAggregation { get => this._supportsInstanceLevelAggregation; set => this._supportsInstanceLevelAggregation = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="MetricSpecification" /> instance.</summary>
        public MetricSpecification()
        {

        }
    }
    /// Definition of a single resource metric.
    public partial interface IMetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"aggregationType",
        PossibleTypes = new [] { typeof(string) })]
        string AggregationType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"availabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricAvailability) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricAvailability[] Availability { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"dimensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDimension) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDimension[] Dimension { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"displayDescription",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableRegionalMdmAccount",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableRegionalMdmAccount { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"fillGapWithZero",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FillGapWithZero { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"isInternal",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsInternal { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"metricFilterPattern",
        PossibleTypes = new [] { typeof(string) })]
        string MetricFilterPattern { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"sourceMdmAccount",
        PossibleTypes = new [] { typeof(string) })]
        string SourceMdmAccount { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"sourceMdmNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string SourceMdmNamespace { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"supportedTimeGrainTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] SupportedTimeGrainType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"supportsInstanceLevelAggregation",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SupportsInstanceLevelAggregation { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    /// Definition of a single resource metric.
    internal partial interface IMetricSpecificationInternal

    {
        string AggregationType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricAvailability[] Availability { get; set; }

        string Category { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDimension[] Dimension { get; set; }

        string DisplayDescription { get; set; }

        string DisplayName { get; set; }

        bool? EnableRegionalMdmAccount { get; set; }

        bool? FillGapWithZero { get; set; }

        bool? IsInternal { get; set; }

        string MetricFilterPattern { get; set; }

        string Name { get; set; }

        string SourceMdmAccount { get; set; }

        string SourceMdmNamespace { get; set; }

        string[] SupportedTimeGrainType { get; set; }

        bool? SupportsInstanceLevelAggregation { get; set; }

        string Unit { get; set; }

    }
}