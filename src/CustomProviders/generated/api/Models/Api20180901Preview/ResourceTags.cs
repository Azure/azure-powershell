namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IResourceTagsInternal

    {

    }
}