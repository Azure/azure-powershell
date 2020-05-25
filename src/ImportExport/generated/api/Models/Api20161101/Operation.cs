namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Describes a supported operation by the Storage Import/Export job API.</summary>
    public partial class Operation :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperation,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplay _display;

        /// <summary>operation display properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.OperationDisplay()); set => this._display = value; }

        /// <summary>Short description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplayInternal)Display).Description = value; }

        /// <summary>The display name of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplayInternal)Display).Operation = value; }

        /// <summary>The resource provider name to which the operation belongs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplayInternal)Display).Provider = value; }

        /// <summary>The name of the resource to which the operation belongs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplayInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Operation" /> instance.</summary>
        public Operation()
        {

        }
    }
    /// Describes a supported operation by the Storage Import/Export job API.
    public partial interface IOperation :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>Short description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Short description of the operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>The display name of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The display name of the operation.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>The resource provider name to which the operation belongs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource provider name to which the operation belongs.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>The name of the resource to which the operation belongs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource to which the operation belongs.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Name of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the operation.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Describes a supported operation by the Storage Import/Export job API.
    internal partial interface IOperationInternal

    {
        /// <summary>operation display properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IOperationDisplay Display { get; set; }
        /// <summary>Short description of the operation.</summary>
        string DisplayDescription { get; set; }
        /// <summary>The display name of the operation.</summary>
        string DisplayOperation { get; set; }
        /// <summary>The resource provider name to which the operation belongs.</summary>
        string DisplayProvider { get; set; }
        /// <summary>The name of the resource to which the operation belongs.</summary>
        string DisplayResource { get; set; }
        /// <summary>Name of the operation.</summary>
        string Name { get; set; }

    }
}