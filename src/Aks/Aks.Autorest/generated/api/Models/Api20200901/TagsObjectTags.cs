namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class TagsObjectTags :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObjectTags,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObjectTagsInternal
    {

        /// <summary>Creates an new <see cref="TagsObjectTags" /> instance.</summary>
        public TagsObjectTags()
        {

        }
    }
    /// Resource tags.
    public partial interface ITagsObjectTags :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface ITagsObjectTagsInternal

    {

    }
}