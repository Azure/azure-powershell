namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class TagsResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.ITagsResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.ITagsResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TagsResourceTags" /> instance.</summary>
        public TagsResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface ITagsResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface ITagsResourceTagsInternal

    {

    }
}