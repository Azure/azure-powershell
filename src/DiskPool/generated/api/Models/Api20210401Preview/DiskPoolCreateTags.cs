namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class DiskPoolCreateTags :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolCreateTags,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolCreateTagsInternal
    {

        /// <summary>Creates an new <see cref="DiskPoolCreateTags" /> instance.</summary>
        public DiskPoolCreateTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IDiskPoolCreateTags :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IDiskPoolCreateTagsInternal

    {

    }
}