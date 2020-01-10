namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Description of metrics specification.</summary>
    public partial class MetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecificationInternal
    {

        /// <summary>Backing field for <see cref="AggregationType" /> property.</summary>
        private string _aggregationType;

        /// <summary>The aggregation type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AggregationType { get => this._aggregationType; set => this._aggregationType = value; }

        /// <summary>Backing field for <see cref="Availability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAvailability[] _availability;

        /// <summary>List of availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAvailability[] Availability { get => this._availability; set => this._availability = value; }

        /// <summary>Backing field for <see cref="Dimension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDimension[] _dimension;

        /// <summary>List of dimensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDimension[] Dimension { get => this._dimension; set => this._dimension = value; }

        /// <summary>Backing field for <see cref="DisplayDescription" /> property.</summary>
        private string _displayDescription;

        /// <summary>The description of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DisplayDescription { get => this._displayDescription; set => this._displayDescription = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="EnableRegionalMdmAccount" /> property.</summary>
        private bool? _enableRegionalMdmAccount;

        /// <summary>Whether regional MDM account enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableRegionalMdmAccount { get => this._enableRegionalMdmAccount; set => this._enableRegionalMdmAccount = value; }

        /// <summary>Backing field for <see cref="FillGapWithZero" /> property.</summary>
        private bool? _fillGapWithZero;

        /// <summary>Whether gaps would be filled with zeros.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? FillGapWithZero { get => this._fillGapWithZero; set => this._fillGapWithZero = value; }

        /// <summary>Backing field for <see cref="IsInternal" /> property.</summary>
        private bool? _isInternal;

        /// <summary>Whether the metric is internal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? IsInternal { get => this._isInternal; set => this._isInternal = value; }

        /// <summary>Backing field for <see cref="MetricFilterPattern" /> property.</summary>
        private string _metricFilterPattern;

        /// <summary>Pattern for the filter of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string MetricFilterPattern { get => this._metricFilterPattern; set => this._metricFilterPattern = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ResourceIdDimensionNameOverride" /> property.</summary>
        private string _resourceIdDimensionNameOverride;

        /// <summary>The resource Id dimension name override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceIdDimensionNameOverride { get => this._resourceIdDimensionNameOverride; set => this._resourceIdDimensionNameOverride = value; }

        /// <summary>Backing field for <see cref="SourceMdmAccount" /> property.</summary>
        private string _sourceMdmAccount;

        /// <summary>The source MDM account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SourceMdmAccount { get => this._sourceMdmAccount; set => this._sourceMdmAccount = value; }

        /// <summary>Backing field for <see cref="SourceMdmNamespace" /> property.</summary>
        private string _sourceMdmNamespace;

        /// <summary>The source MDM namespace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SourceMdmNamespace { get => this._sourceMdmNamespace; set => this._sourceMdmNamespace = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Units the metric to be displayed in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="MetricSpecification" /> instance.</summary>
        public MetricSpecification()
        {

        }
    }
    /// Description of metrics specification.
    public partial interface IMetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The aggregation type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The aggregation type.",
        SerializedName = @"aggregationType",
        PossibleTypes = new [] { typeof(string) })]
        string AggregationType { get; set; }
        /// <summary>List of availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of availability.",
        SerializedName = @"availabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAvailability) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAvailability[] Availability { get; set; }
        /// <summary>List of dimensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of dimensions.",
        SerializedName = @"dimensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDimension) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDimension[] Dimension { get; set; }
        /// <summary>The description of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the metric.",
        SerializedName = @"displayDescription",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>The display name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The display name of the metric.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Whether regional MDM account enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether regional MDM account enabled.",
        SerializedName = @"enableRegionalMdmAccount",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableRegionalMdmAccount { get; set; }
        /// <summary>Whether gaps would be filled with zeros.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether gaps would be filled with zeros.",
        SerializedName = @"fillGapWithZero",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FillGapWithZero { get; set; }
        /// <summary>Whether the metric is internal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the metric is internal.",
        SerializedName = @"isInternal",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsInternal { get; set; }
        /// <summary>Pattern for the filter of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Pattern for the filter of the metric.",
        SerializedName = @"metricFilterPattern",
        PossibleTypes = new [] { typeof(string) })]
        string MetricFilterPattern { get; set; }
        /// <summary>The name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the metric.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The resource Id dimension name override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource Id dimension name override.",
        SerializedName = @"resourceIdDimensionNameOverride",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceIdDimensionNameOverride { get; set; }
        /// <summary>The source MDM account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source MDM account.",
        SerializedName = @"sourceMdmAccount",
        PossibleTypes = new [] { typeof(string) })]
        string SourceMdmAccount { get; set; }
        /// <summary>The source MDM namespace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source MDM namespace.",
        SerializedName = @"sourceMdmNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string SourceMdmNamespace { get; set; }
        /// <summary>Units the metric to be displayed in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Units the metric to be displayed in.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    /// Description of metrics specification.
    internal partial interface IMetricSpecificationInternal

    {
        /// <summary>The aggregation type.</summary>
        string AggregationType { get; set; }
        /// <summary>List of availability.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAvailability[] Availability { get; set; }
        /// <summary>List of dimensions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDimension[] Dimension { get; set; }
        /// <summary>The description of the metric.</summary>
        string DisplayDescription { get; set; }
        /// <summary>The display name of the metric.</summary>
        string DisplayName { get; set; }
        /// <summary>Whether regional MDM account enabled.</summary>
        bool? EnableRegionalMdmAccount { get; set; }
        /// <summary>Whether gaps would be filled with zeros.</summary>
        bool? FillGapWithZero { get; set; }
        /// <summary>Whether the metric is internal.</summary>
        bool? IsInternal { get; set; }
        /// <summary>Pattern for the filter of the metric.</summary>
        string MetricFilterPattern { get; set; }
        /// <summary>The name of the metric.</summary>
        string Name { get; set; }
        /// <summary>The resource Id dimension name override.</summary>
        string ResourceIdDimensionNameOverride { get; set; }
        /// <summary>The source MDM account.</summary>
        string SourceMdmAccount { get; set; }
        /// <summary>The source MDM namespace.</summary>
        string SourceMdmNamespace { get; set; }
        /// <summary>Units the metric to be displayed in.</summary>
        string Unit { get; set; }

    }
}