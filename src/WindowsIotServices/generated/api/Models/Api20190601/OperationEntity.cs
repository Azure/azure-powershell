namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>The operation supported by Azure Data Catalog Service.</summary>
    public partial class OperationEntity :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfo _display;

        /// <summary>The operation supported by Azure Data Catalog Service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfo Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.OperationDisplayInfo()); set => this._display = value; }

        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfoInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfoInternal)Display).Description = value; }

        /// <summary>The action that users can perform, based on their permission level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfoInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfoInternal)Display).Operation = value; }

        /// <summary>Service provider: Azure Data Catalog Service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfoInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfoInternal)Display).Provider = value; }

        /// <summary>Resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfoInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfoInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfo Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.OperationDisplayInfo()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="OperationEntity" /> instance.</summary>
        public OperationEntity()
        {

        }
    }
    /// The operation supported by Azure Data Catalog Service.
    public partial interface IOperationEntity :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IJsonSerializable
    {
        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>The action that users can perform, based on their permission level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The action that users can perform, based on their permission level.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Service provider: Azure Data Catalog Service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service provider: Azure Data Catalog Service.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource on which the operation is performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation name: {provider}/{resource}/{operation}.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The operation supported by Azure Data Catalog Service.
    internal partial interface IOperationEntityInternal

    {
        /// <summary>The operation supported by Azure Data Catalog Service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfo Display { get; set; }
        /// <summary>The description of the operation.</summary>
        string DisplayDescription { get; set; }
        /// <summary>The action that users can perform, based on their permission level.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Service provider: Azure Data Catalog Service.</summary>
        string DisplayProvider { get; set; }
        /// <summary>Resource on which the operation is performed.</summary>
        string DisplayResource { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        string Name { get; set; }

    }
}