namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>The dashboard len's metadata.</summary>
    public partial class DashboardLensMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLensMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLensMetadataInternal
    {

        /// <summary>Creates an new <see cref="DashboardLensMetadata" /> instance.</summary>
        public DashboardLensMetadata()
        {

        }
    }
    /// The dashboard len's metadata.
    public partial interface IDashboardLensMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// The dashboard len's metadata.
    internal partial interface IDashboardLensMetadataInternal

    {

    }
}