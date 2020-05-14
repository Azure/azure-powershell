namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class TagsResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TagsResourceTags" /> instance.</summary>
        public TagsResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface ITagsResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface ITagsResourceTagsInternal

    {

    }
}