namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class MoveCollectionTags :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollectionTags,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollectionTagsInternal
    {

        /// <summary>Creates an new <see cref="MoveCollectionTags" /> instance.</summary>
        public MoveCollectionTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IMoveCollectionTags :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IMoveCollectionTagsInternal

    {

    }
}