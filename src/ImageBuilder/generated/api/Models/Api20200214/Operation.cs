namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>A REST API operation</summary>
    public partial class Operation :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperation,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplay _display;

        /// <summary>The object that describes the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.OperationDisplay()); set => this._display = value; }

        /// <summary>The friendly name of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplayInternal)Display).Description = value ?? null; }

        /// <summary>For example: read, write, delete, or listKeys/action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplayInternal)Display).Operation = value ?? null; }

        /// <summary>Friendly name of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplayInternal)Display).Provider = value ?? null; }

        /// <summary>The resource type on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplayInternal)Display).Resource = value ?? null; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>The flag that indicates whether the operation applies to data plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; set => this._isDataAction = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>This is of the format {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>The intended executor of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IAny _property;

        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IAny Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Any()); set => this._property = value; }

        /// <summary>Creates an new <see cref="Operation" /> instance.</summary>
        public Operation()
        {

        }
    }
    /// A REST API operation
    public partial interface IOperation :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>The friendly name of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The friendly name of the operation",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>For example: read, write, delete, or listKeys/action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"For example: read, write, delete, or listKeys/action",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Friendly name of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of the resource provider.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>The resource type on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource type on which the operation is performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>The flag that indicates whether the operation applies to data plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The flag that indicates whether the operation applies to data plane.",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get; set; }
        /// <summary>This is of the format {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This is of the format {provider}/{resource}/{operation}",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The intended executor of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The intended executor of the operation.",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get; set; }
        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any object",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IAny Property { get; set; }

    }
    /// A REST API operation
    public partial interface IOperationInternal

    {
        /// <summary>The object that describes the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationDisplay Display { get; set; }
        /// <summary>The friendly name of the operation</summary>
        string DisplayDescription { get; set; }
        /// <summary>For example: read, write, delete, or listKeys/action</summary>
        string DisplayOperation { get; set; }
        /// <summary>Friendly name of the resource provider.</summary>
        string DisplayProvider { get; set; }
        /// <summary>The resource type on which the operation is performed.</summary>
        string DisplayResource { get; set; }
        /// <summary>The flag that indicates whether the operation applies to data plane.</summary>
        bool? IsDataAction { get; set; }
        /// <summary>This is of the format {provider}/{resource}/{operation}</summary>
        string Name { get; set; }
        /// <summary>The intended executor of the operation.</summary>
        string Origin { get; set; }
        /// <summary>Any object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IAny Property { get; set; }

    }
}