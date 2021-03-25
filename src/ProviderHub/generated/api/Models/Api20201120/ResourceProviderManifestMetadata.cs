namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    /// <summary>Dictionary of <string></summary>
    public partial class ResourceProviderManifestMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestMetadataInternal
    {

        /// <summary>Creates an new <see cref="ResourceProviderManifestMetadata" /> instance.</summary>
        public ResourceProviderManifestMetadata()
        {

        }
    }
    /// Dictionary of <string>
    public partial interface IResourceProviderManifestMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IAssociativeArray<string>
    {

    }
    /// Dictionary of <string>
    internal partial interface IResourceProviderManifestMetadataInternal

    {

    }
}