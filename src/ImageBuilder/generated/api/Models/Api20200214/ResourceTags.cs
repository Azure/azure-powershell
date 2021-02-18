namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    public partial interface IResourceTagsInternal

    {

    }
}