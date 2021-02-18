namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>The dashboard part's metadata.</summary>
    public partial class DashboardPartsMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsMetadataInternal
    {

        /// <summary>Creates an new <see cref="DashboardPartsMetadata" /> instance.</summary>
        public DashboardPartsMetadata()
        {

        }
    }
    /// The dashboard part's metadata.
    public partial interface IDashboardPartsMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// The dashboard part's metadata.
    internal partial interface IDashboardPartsMetadataInternal

    {

    }
}