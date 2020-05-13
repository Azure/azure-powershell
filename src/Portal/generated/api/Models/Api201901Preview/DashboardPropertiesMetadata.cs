namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>The dashboard metadata.</summary>
    public partial class DashboardPropertiesMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesMetadataInternal
    {

        /// <summary>Creates an new <see cref="DashboardPropertiesMetadata" /> instance.</summary>
        public DashboardPropertiesMetadata()
        {

        }
    }
    /// The dashboard metadata.
    public partial interface IDashboardPropertiesMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// The dashboard metadata.
    internal partial interface IDashboardPropertiesMetadataInternal

    {

    }
}