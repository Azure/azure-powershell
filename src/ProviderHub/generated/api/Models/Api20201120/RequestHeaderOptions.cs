namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class RequestHeaderOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptionsInternal
    {

        /// <summary>Backing field for <see cref="OptInHeader" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? _optInHeader;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? OptInHeader { get => this._optInHeader; set => this._optInHeader = value; }

        /// <summary>Creates an new <see cref="RequestHeaderOptions" /> instance.</summary>
        public RequestHeaderOptions()
        {

        }
    }
    public partial interface IRequestHeaderOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"optInHeaders",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? OptInHeader { get; set; }

    }
    internal partial interface IRequestHeaderOptionsInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? OptInHeader { get; set; }

    }
}