namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ExtensionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptionsInternal
    {

        /// <summary>Backing field for <see cref="Request" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] _request;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] Request { get => this._request; set => this._request = value; }

        /// <summary>Backing field for <see cref="Response" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] _response;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] Response { get => this._response; set => this._response = value; }

        /// <summary>Creates an new <see cref="ExtensionOptions" /> instance.</summary>
        public ExtensionOptions()
        {

        }
    }
    public partial interface IExtensionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"request",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] Request { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"response",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] Response { get; set; }

    }
    internal partial interface IExtensionOptionsInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] Request { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] Response { get; set; }

    }
}