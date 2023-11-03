namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeExtension :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtension,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionInternal
    {

        /// <summary>Backing field for <see cref="EndpointUri" /> property.</summary>
        private string _endpointUri;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string EndpointUri { get => this._endpointUri; set => this._endpointUri = value; }

        /// <summary>Backing field for <see cref="ExtensionCategory" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionCategory[] _extensionCategory;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionCategory[] ExtensionCategory { get => this._extensionCategory; set => this._extensionCategory = value; }

        /// <summary>Backing field for <see cref="Timeout" /> property.</summary>
        private global::System.TimeSpan? _timeout;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public global::System.TimeSpan? Timeout { get => this._timeout; set => this._timeout = value; }

        /// <summary>Creates an new <see cref="ResourceTypeExtension" /> instance.</summary>
        public ResourceTypeExtension()
        {

        }
    }
    public partial interface IResourceTypeExtension :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"endpointUri",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointUri { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"extensionCategories",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionCategory) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionCategory[] ExtensionCategory { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"timeout",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? Timeout { get; set; }

    }
    internal partial interface IResourceTypeExtensionInternal

    {
        string EndpointUri { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionCategory[] ExtensionCategory { get; set; }

        global::System.TimeSpan? Timeout { get; set; }

    }
}