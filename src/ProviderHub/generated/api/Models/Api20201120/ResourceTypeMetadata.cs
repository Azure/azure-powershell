namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    /// <summary>Dictionary of <string></summary>
    public partial class ResourceTypeMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeMetadataInternal
    {

        /// <summary>Creates an new <see cref="ResourceTypeMetadata" /> instance.</summary>
        public ResourceTypeMetadata()
        {

        }
    }
    /// Dictionary of <string>
    public partial interface IResourceTypeMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IAssociativeArray<string>
    {

    }
    /// Dictionary of <string>
    internal partial interface IResourceTypeMetadataInternal

    {

    }
}