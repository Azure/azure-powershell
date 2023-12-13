namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>Operation detail payload</summary>
    public partial class OperationDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetailInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplay _display;

        /// <summary>Display of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.OperationDisplay()); set => this._display = value; }

        /// <summary>Localized friendly description for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplayInternal)Display).Description = value ?? null; }

        /// <summary>Localized friendly name for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplayInternal)Display).Operation = value ?? null; }

        /// <summary>Resource provider of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplayInternal)Display).Provider = value ?? null; }

        /// <summary>Resource of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplayInternal)Display).Resource = value ?? null; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; set => this._isDataAction = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetailInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationProperties Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetailInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.OperationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetailInternal.ServiceSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationPropertiesInternal)Property).ServiceSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationPropertiesInternal)Property).ServiceSpecification = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>Origin of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationProperties _property;

        /// <summary>Properties of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.OperationProperties()); set => this._property = value; }

        /// <summary>Metric specifications of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationPropertiesInternal)Property).ServiceSpecificationMetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationPropertiesInternal)Property).ServiceSpecificationMetricSpecification = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="OperationDetail" /> instance.</summary>
        public OperationDetail()
        {

        }
    }
    /// Operation detail payload
    public partial interface IOperationDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>Localized friendly description for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly description for the operation",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly name for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly name for the operation",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Resource provider of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource provider of the operation",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Resource of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource of the operation",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the operation is a data action",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get; set; }
        /// <summary>Name of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the operation",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Origin of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Origin of the operation",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get; set; }
        /// <summary>Metric specifications of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metric specifications of operation.",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Operation detail payload
    internal partial interface IOperationDetailInternal

    {
        /// <summary>Display of the operation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDisplay Display { get; set; }
        /// <summary>Localized friendly description for the operation</summary>
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly name for the operation</summary>
        string DisplayOperation { get; set; }
        /// <summary>Resource provider of the operation</summary>
        string DisplayProvider { get; set; }
        /// <summary>Resource of the operation</summary>
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        bool? IsDataAction { get; set; }
        /// <summary>Name of the operation</summary>
        string Name { get; set; }
        /// <summary>Origin of the operation</summary>
        string Origin { get; set; }
        /// <summary>Properties of the operation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationProperties Property { get; set; }
        /// <summary>One property of operation, include metric specifications.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IServiceSpecification ServiceSpecification { get; set; }
        /// <summary>Metric specifications of operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}