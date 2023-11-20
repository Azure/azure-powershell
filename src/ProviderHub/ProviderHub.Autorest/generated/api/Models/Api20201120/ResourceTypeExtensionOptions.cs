namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeExtensionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptionsInternal
    {

        /// <summary>Internal Acessors for ResourceCreationBegin</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptionsInternal.ResourceCreationBegin { get => (this._resourceCreationBegin = this._resourceCreationBegin ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ExtensionOptions()); set { {_resourceCreationBegin = value;} } }

        /// <summary>Backing field for <see cref="ResourceCreationBegin" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptions _resourceCreationBegin;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptions ResourceCreationBegin { get => (this._resourceCreationBegin = this._resourceCreationBegin ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ExtensionOptions()); set => this._resourceCreationBegin = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptionsInternal)ResourceCreationBegin).Request; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptionsInternal)ResourceCreationBegin).Request = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginResponse { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptionsInternal)ResourceCreationBegin).Response; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptionsInternal)ResourceCreationBegin).Response = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="ResourceTypeExtensionOptions" /> instance.</summary>
        public ResourceTypeExtensionOptions()
        {

        }
    }
    public partial interface IResourceTypeExtensionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"request",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginRequest { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"response",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginResponse { get; set; }

    }
    internal partial interface IResourceTypeExtensionOptionsInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptions ResourceCreationBegin { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginRequest { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginResponse { get; set; }

    }
}