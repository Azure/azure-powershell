namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class ResourceProvidersUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceProvidersUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceProvidersUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceProvidersUpdateTags" /> instance.</summary>
        public ResourceProvidersUpdateTags()
        {

        }
    }
    /// Resource tags
    public partial interface IResourceProvidersUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IResourceProvidersUpdateTagsInternal

    {

    }
}