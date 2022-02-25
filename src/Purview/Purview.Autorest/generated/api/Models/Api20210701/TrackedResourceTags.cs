namespace Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Extensions;

    /// <summary>Tags on the azure resource.</summary>
    public partial class TrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TrackedResourceTags" /> instance.</summary>
        public TrackedResourceTags()
        {

        }
    }
    /// Tags on the azure resource.
    public partial interface ITrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.IAssociativeArray<string>
    {

    }
    /// Tags on the azure resource.
    internal partial interface ITrackedResourceTagsInternal

    {

    }
}