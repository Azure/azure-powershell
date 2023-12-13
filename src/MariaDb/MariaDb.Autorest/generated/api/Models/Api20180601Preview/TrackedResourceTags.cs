namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
    public partial class TrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ITrackedResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ITrackedResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TrackedResourceTags" /> instance.</summary>
        public TrackedResourceTags()
        {

        }
    }
    /// Application-specific metadata in the form of key-value pairs.
    public partial interface ITrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IAssociativeArray<string>
    {

    }
    /// Application-specific metadata in the form of key-value pairs.
    internal partial interface ITrackedResourceTagsInternal

    {

    }
}