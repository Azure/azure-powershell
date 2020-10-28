namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The categorized resource counts.</summary>
    public partial class ResourceHealthSummaryCategorizedResourceCounts :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCountsInternal
    {

        /// <summary>
        /// Creates an new <see cref="ResourceHealthSummaryCategorizedResourceCounts" /> instance.
        /// </summary>
        public ResourceHealthSummaryCategorizedResourceCounts()
        {

        }
    }
    /// The categorized resource counts.
    public partial interface IResourceHealthSummaryCategorizedResourceCounts :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<int>
    {

    }
    /// The categorized resource counts.
    internal partial interface IResourceHealthSummaryCategorizedResourceCountsInternal

    {

    }
}