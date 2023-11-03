namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class DashboardTags :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardTags,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardTagsInternal
    {

        /// <summary>Creates an new <see cref="DashboardTags" /> instance.</summary>
        public DashboardTags()
        {

        }
    }
    /// Resource tags
    public partial interface IDashboardTags :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IDashboardTagsInternal

    {

    }
}