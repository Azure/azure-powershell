namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class TagsObjectTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITagsObjectTags,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITagsObjectTagsInternal
    {

        /// <summary>Creates an new <see cref="TagsObjectTags" /> instance.</summary>
        public TagsObjectTags()
        {

        }
    }
    /// Resource tags.
    public partial interface ITagsObjectTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface ITagsObjectTagsInternal

    {

    }
}