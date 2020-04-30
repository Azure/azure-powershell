namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
    public partial class TrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ITrackedResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ITrackedResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TrackedResourceTags" /> instance.</summary>
        public TrackedResourceTags()
        {

        }
    }
    /// Application-specific metadata in the form of key-value pairs.
    public partial interface ITrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IAssociativeArray<string>
    {

    }
    /// Application-specific metadata in the form of key-value pairs.
    internal partial interface ITrackedResourceTagsInternal

    {

    }
}