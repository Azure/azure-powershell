namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class TrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ITrackedResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ITrackedResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TrackedResourceTags" /> instance.</summary>
        public TrackedResourceTags()
        {

        }
    }
    /// Resource tags.
    public partial interface ITrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface ITrackedResourceTagsInternal

    {

    }
}