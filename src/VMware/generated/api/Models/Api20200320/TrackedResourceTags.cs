namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class TrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ITrackedResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ITrackedResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TrackedResourceTags" /> instance.</summary>
        public TrackedResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface ITrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface ITrackedResourceTagsInternal

    {

    }
}