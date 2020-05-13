namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Description of an operation available for Microsoft.Web resource provider.</summary>
    public partial class CsmOperationDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescription,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplay _display;

        /// <summary>Meta data about operation used for display in portal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDisplay()); set => this._display = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplayInternal)Display).Description = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplayInternal)Display).Operation = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplayInternal)Display).Provider = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplayInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDescriptionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal.ServiceSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionPropertiesInternal)Property).ServiceSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionPropertiesInternal)Property).ServiceSpecification = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionProperties _property;

        /// <summary>Properties available for a Microsoft.Web resource provider operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDescriptionProperties()); set => this._property = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] ServiceSpecificationLogSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionPropertiesInternal)Property).ServiceSpecificationLogSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionPropertiesInternal)Property).ServiceSpecificationLogSpecification = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionPropertiesInternal)Property).ServiceSpecificationMetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionPropertiesInternal)Property).ServiceSpecificationMetricSpecification = value; }

        /// <summary>Creates an new <see cref="CsmOperationDescription" /> instance.</summary>
        public CsmOperationDescription()
        {

        }
    }
    /// Description of an operation available for Microsoft.Web resource provider.
    public partial interface ICsmOperationDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }

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
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"logSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Description of an operation available for Microsoft.Web resource provider.
    internal partial interface ICsmOperationDescriptionInternal

    {
        /// <summary>Meta data about operation used for display in portal.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplay Display { get; set; }

        string DisplayDescription { get; set; }

        string DisplayOperation { get; set; }

        string DisplayProvider { get; set; }

        string DisplayResource { get; set; }

        string Name { get; set; }

        string Origin { get; set; }
        /// <summary>Properties available for a Microsoft.Web resource provider operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionProperties Property { get; set; }
        /// <summary>Resource metrics service provided by Microsoft.Insights resource provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification ServiceSpecification { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}