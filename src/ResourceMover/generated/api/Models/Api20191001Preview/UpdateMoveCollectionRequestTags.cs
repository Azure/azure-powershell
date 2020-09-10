namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Gets or sets the Resource tags.</summary>
    public partial class UpdateMoveCollectionRequestTags :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IUpdateMoveCollectionRequestTags,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IUpdateMoveCollectionRequestTagsInternal
    {

        /// <summary>Creates an new <see cref="UpdateMoveCollectionRequestTags" /> instance.</summary>
        public UpdateMoveCollectionRequestTags()
        {

        }
    }
    /// Gets or sets the Resource tags.
    public partial interface IUpdateMoveCollectionRequestTags :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the Resource tags.
    internal partial interface IUpdateMoveCollectionRequestTagsInternal

    {

    }
}