namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>REST API operation supported by CommunicationService resource provider.</summary>
    public partial class Operation :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperation,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplay _display;

        /// <summary>The object that describes the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.OperationDisplay()); set => this._display = value; }

        /// <summary>The localized friendly description for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplayInternal)Display).Description = value; }

        /// <summary>The localized friendly name for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplayInternal)Display).Operation = value; }

        /// <summary>Friendly name of the resource provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplayInternal)Display).Provider = value; }

        /// <summary>Resource type on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplayInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationProperties Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.OperationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationInternal.ServiceSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationPropertiesInternal)Property).ServiceSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationPropertiesInternal)Property).ServiceSpecification = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the operation with format: {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>
        /// Optional. The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs
        /// UX.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationProperties _property;

        /// <summary>Extra properties for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.OperationProperties()); set => this._property = value; }

        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationPropertiesInternal)Property).ServiceSpecificationMetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationPropertiesInternal)Property).ServiceSpecificationMetricSpecification = value; }

        /// <summary>Creates an new <see cref="Operation" /> instance.</summary>
        public Operation()
        {

        }
    }
    /// REST API operation supported by CommunicationService resource provider.
    public partial interface IOperation :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>The localized friendly description for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The localized friendly description for the operation",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>The localized friendly name for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The localized friendly name for the operation.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Friendly name of the resource provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of the resource provider",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Resource type on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource type on which the operation is performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Name of the operation with format: {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the operation with format: {provider}/{resource}/{operation}",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Optional. The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs
        /// UX.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional. The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX.",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get; set; }
        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifications of the Metrics for Azure Monitoring.",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// REST API operation supported by CommunicationService resource provider.
    internal partial interface IOperationInternal

    {
        /// <summary>The object that describes the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationDisplay Display { get; set; }
        /// <summary>The localized friendly description for the operation</summary>
        string DisplayDescription { get; set; }
        /// <summary>The localized friendly name for the operation.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Friendly name of the resource provider</summary>
        string DisplayProvider { get; set; }
        /// <summary>Resource type on which the operation is performed.</summary>
        string DisplayResource { get; set; }
        /// <summary>Name of the operation with format: {provider}/{resource}/{operation}</summary>
        string Name { get; set; }
        /// <summary>
        /// Optional. The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs
        /// UX.
        /// </summary>
        string Origin { get; set; }
        /// <summary>Extra properties for the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationProperties Property { get; set; }
        /// <summary>The service specifications.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecification ServiceSpecification { get; set; }
        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}