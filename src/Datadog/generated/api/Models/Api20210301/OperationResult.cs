namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>A Microsoft.Datadog REST API operation.</summary>
    public partial class OperationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationResult,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationResultInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplay _display;

        /// <summary>The object that represents the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.OperationDisplay()); set => this._display = value; }

        /// <summary>Description of the operation, e.g., 'Write monitors'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal)Display).Description = value ?? null; }

        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal)Display).Operation = value ?? null; }

        /// <summary>Service provider, i.e., Microsoft.Datadog.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal)Display).Provider = value ?? null; }

        /// <summary>Type on which the operation is performed, e.g., 'monitors'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal)Display).Resource = value ?? null; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; set => this._isDataAction = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationResultInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name, i.e., {provider}/{resource}/{operation}.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="OperationResult" /> instance.</summary>
        public OperationResult()
        {

        }
    }
    /// A Microsoft.Datadog REST API operation.
    public partial interface IOperationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Description of the operation, e.g., 'Write monitors'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the operation, e.g., 'Write monitors'.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation type, e.g., read, write, delete, etc.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Service provider, i.e., Microsoft.Datadog.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service provider, i.e., Microsoft.Datadog.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Type on which the operation is performed, e.g., 'monitors'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type on which the operation is performed, e.g., 'monitors'.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the operation is a data action",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get; set; }
        /// <summary>Operation name, i.e., {provider}/{resource}/{operation}.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation name, i.e., {provider}/{resource}/{operation}.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// A Microsoft.Datadog REST API operation.
    internal partial interface IOperationResultInternal

    {
        /// <summary>The object that represents the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplay Display { get; set; }
        /// <summary>Description of the operation, e.g., 'Write monitors'.</summary>
        string DisplayDescription { get; set; }
        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Service provider, i.e., Microsoft.Datadog.</summary>
        string DisplayProvider { get; set; }
        /// <summary>Type on which the operation is performed, e.g., 'monitors'.</summary>
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        bool? IsDataAction { get; set; }
        /// <summary>Operation name, i.e., {provider}/{resource}/{operation}.</summary>
        string Name { get; set; }

    }
}