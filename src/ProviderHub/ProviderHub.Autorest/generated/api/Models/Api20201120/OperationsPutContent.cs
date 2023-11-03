namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class OperationsPutContent :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsPutContent,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsPutContentInternal
    {

        /// <summary>Backing field for <see cref="Content" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition[] _content;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition[] Content { get => this._content; set => this._content = value; }

        /// <summary>Creates an new <see cref="OperationsPutContent" /> instance.</summary>
        public OperationsPutContent()
        {

        }
    }
    public partial interface IOperationsPutContent :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"contents",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition[] Content { get; set; }

    }
    internal partial interface IOperationsPutContentInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition[] Content { get; set; }

    }
}