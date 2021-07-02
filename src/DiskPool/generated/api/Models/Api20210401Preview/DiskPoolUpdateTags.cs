namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class DiskPoolUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="DiskPoolUpdateTags" /> instance.</summary>
        public DiskPoolUpdateTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IDiskPoolUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IDiskPoolUpdateTagsInternal

    {

    }
}