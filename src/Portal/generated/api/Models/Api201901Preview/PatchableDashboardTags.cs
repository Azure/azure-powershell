namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class PatchableDashboardTags :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IPatchableDashboardTags,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IPatchableDashboardTagsInternal
    {

        /// <summary>Creates an new <see cref="PatchableDashboardTags" /> instance.</summary>
        public PatchableDashboardTags()
        {

        }
    }
    /// Resource tags
    public partial interface IPatchableDashboardTags :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IPatchableDashboardTagsInternal

    {

    }
}