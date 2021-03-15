namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>An Confluent REST API operation.</summary>
    public partial class OperationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationResult,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationResultInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplay _display;

        /// <summary>The object that represents the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OperationDisplay()); set => this._display = value; }

        /// <summary>Description of the operation, e.g., 'Write confluent'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplayInternal)Display).Description = value ?? null; }

        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplayInternal)Display).Operation = value ?? null; }

        /// <summary>Service provider: Microsoft.Confluent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplayInternal)Display).Provider = value ?? null; }

        /// <summary>Type on which the operation is performed, e.g., 'clusters'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplayInternal)Display).Resource = value ?? null; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; set => this._isDataAction = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationResultInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name: {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="OperationResult" /> instance.</summary>
        public OperationResult()
        {

        }
    }
    /// An Confluent REST API operation.
    public partial interface IOperationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable
    {
        /// <summary>Description of the operation, e.g., 'Write confluent'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the operation, e.g., 'Write confluent'.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation type, e.g., read, write, delete, etc.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Service provider: Microsoft.Confluent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service provider: Microsoft.Confluent",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Type on which the operation is performed, e.g., 'clusters'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type on which the operation is performed, e.g., 'clusters'.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the operation is a data action",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation name: {provider}/{resource}/{operation}",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// An Confluent REST API operation.
    internal partial interface IOperationResultInternal

    {
        /// <summary>The object that represents the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationDisplay Display { get; set; }
        /// <summary>Description of the operation, e.g., 'Write confluent'.</summary>
        string DisplayDescription { get; set; }
        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Service provider: Microsoft.Confluent</summary>
        string DisplayProvider { get; set; }
        /// <summary>Type on which the operation is performed, e.g., 'clusters'.</summary>
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        bool? IsDataAction { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}</summary>
        string Name { get; set; }

    }
}