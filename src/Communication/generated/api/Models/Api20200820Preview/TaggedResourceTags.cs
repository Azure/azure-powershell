namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>
    /// Tags of the service which is a list of key value pairs that describe the resource.
    /// </summary>
    public partial class TaggedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TaggedResourceTags" /> instance.</summary>
        public TaggedResourceTags()
        {

        }
    }
    /// Tags of the service which is a list of key value pairs that describe the resource.
    public partial interface ITaggedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IAssociativeArray<string>
    {

    }
    /// Tags of the service which is a list of key value pairs that describe the resource.
    internal partial interface ITaggedResourceTagsInternal

    {

    }
}