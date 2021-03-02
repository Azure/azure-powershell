namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>Specifications of the Metrics for Azure Monitoring</summary>
    public partial class MetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecificationInternal
    {

        /// <summary>Backing field for <see cref="AggregationType" /> property.</summary>
        private string _aggregationType;

        /// <summary>
        /// Only provide one value for this field. Valid values: Average, Minimum, Maximum, Total, Count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string AggregationType { get => this._aggregationType; set => this._aggregationType = value; }

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>
        /// Name of the metric category that the metric belongs to. A metric can only belong to a single category.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="Dimension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricDimension[] _dimension;

        /// <summary>Dimensions of the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricDimension[] Dimension { get => this._dimension; set => this._dimension = value; }

        /// <summary>Backing field for <see cref="DisplayDescription" /> property.</summary>
        private string _displayDescription;

        /// <summary>Localized friendly description of the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string DisplayDescription { get => this._displayDescription; set => this._displayDescription = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Localized friendly display name of the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="EnableRegionalMdmAccount" /> property.</summary>
        private string _enableRegionalMdmAccount;

        /// <summary>Whether or not the service is using regional MDM accounts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string EnableRegionalMdmAccount { get => this._enableRegionalMdmAccount; set => this._enableRegionalMdmAccount = value; }

        /// <summary>Backing field for <see cref="FillGapWithZero" /> property.</summary>
        private bool? _fillGapWithZero;

        /// <summary>
        /// Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public bool? FillGapWithZero { get => this._fillGapWithZero; set => this._fillGapWithZero = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="SourceMdmAccount" /> property.</summary>
        private string _sourceMdmAccount;

        /// <summary>The name of the MDM account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string SourceMdmAccount { get => this._sourceMdmAccount; set => this._sourceMdmAccount = value; }

        /// <summary>Backing field for <see cref="SourceMdmNamespace" /> property.</summary>
        private string _sourceMdmNamespace;

        /// <summary>The name of the MDM namespace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string SourceMdmNamespace { get => this._sourceMdmNamespace; set => this._sourceMdmNamespace = value; }

        /// <summary>Backing field for <see cref="SupportedAggregationType" /> property.</summary>
        private string[] _supportedAggregationType;

        /// <summary>Supported aggregation types</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string[] SupportedAggregationType { get => this._supportedAggregationType; set => this._supportedAggregationType = value; }

        /// <summary>Backing field for <see cref="SupportedTimeGrainType" /> property.</summary>
        private string[] _supportedTimeGrainType;

        /// <summary>Supported time grain types</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string[] SupportedTimeGrainType { get => this._supportedTimeGrainType; set => this._supportedTimeGrainType = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Unit that makes sense for the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="MetricSpecification" /> instance.</summary>
        public MetricSpecification()
        {

        }
    }
    /// Specifications of the Metrics for Azure Monitoring
    public partial interface IMetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Only provide one value for this field. Valid values: Average, Minimum, Maximum, Total, Count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Only provide one value for this field. Valid values: Average, Minimum, Maximum, Total, Count.",
        SerializedName = @"aggregationType",
        PossibleTypes = new [] { typeof(string) })]
        string AggregationType { get; set; }
        /// <summary>
        /// Name of the metric category that the metric belongs to. A metric can only belong to a single category.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the metric category that the metric belongs to. A metric can only belong to a single category.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get; set; }
        /// <summary>Dimensions of the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dimensions of the metric",
        SerializedName = @"dimensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricDimension) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricDimension[] Dimension { get; set; }
        /// <summary>Localized friendly description of the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly description of the metric",
        SerializedName = @"displayDescription",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly display name of the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly display name of the metric",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Whether or not the service is using regional MDM accounts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether or not the service is using regional MDM accounts.",
        SerializedName = @"enableRegionalMdmAccount",
        PossibleTypes = new [] { typeof(string) })]
        string EnableRegionalMdmAccount { get; set; }
        /// <summary>
        /// Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.",
        SerializedName = @"fillGapWithZero",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FillGapWithZero { get; set; }
        /// <summary>Name of the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the metric",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The name of the MDM account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the MDM account.",
        SerializedName = @"sourceMdmAccount",
        PossibleTypes = new [] { typeof(string) })]
        string SourceMdmAccount { get; set; }
        /// <summary>The name of the MDM namespace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the MDM namespace.",
        SerializedName = @"sourceMdmNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string SourceMdmNamespace { get; set; }
        /// <summary>Supported aggregation types</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Supported aggregation types",
        SerializedName = @"supportedAggregationTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] SupportedAggregationType { get; set; }
        /// <summary>Supported time grain types</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Supported time grain types",
        SerializedName = @"supportedTimeGrainTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] SupportedTimeGrainType { get; set; }
        /// <summary>Unit that makes sense for the metric</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unit that makes sense for the metric",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    /// Specifications of the Metrics for Azure Monitoring
    internal partial interface IMetricSpecificationInternal

    {
        /// <summary>
        /// Only provide one value for this field. Valid values: Average, Minimum, Maximum, Total, Count.
        /// </summary>
        string AggregationType { get; set; }
        /// <summary>
        /// Name of the metric category that the metric belongs to. A metric can only belong to a single category.
        /// </summary>
        string Category { get; set; }
        /// <summary>Dimensions of the metric</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricDimension[] Dimension { get; set; }
        /// <summary>Localized friendly description of the metric</summary>
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly display name of the metric</summary>
        string DisplayName { get; set; }
        /// <summary>Whether or not the service is using regional MDM accounts.</summary>
        string EnableRegionalMdmAccount { get; set; }
        /// <summary>
        /// Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.
        /// </summary>
        bool? FillGapWithZero { get; set; }
        /// <summary>Name of the metric</summary>
        string Name { get; set; }
        /// <summary>The name of the MDM account.</summary>
        string SourceMdmAccount { get; set; }
        /// <summary>The name of the MDM namespace.</summary>
        string SourceMdmNamespace { get; set; }
        /// <summary>Supported aggregation types</summary>
        string[] SupportedAggregationType { get; set; }
        /// <summary>Supported time grain types</summary>
        string[] SupportedTimeGrainType { get; set; }
        /// <summary>Unit that makes sense for the metric</summary>
        string Unit { get; set; }

    }
}