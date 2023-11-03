namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>The dashboard parts.</summary>
    public partial class DashboardLensParts :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLensParts,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLensPartsInternal
    {

        /// <summary>Creates an new <see cref="DashboardLensParts" /> instance.</summary>
        public DashboardLensParts()
        {

        }
    }
    /// The dashboard parts.
    public partial interface IDashboardLensParts :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardParts>
    {

    }
    /// The dashboard parts.
    internal partial interface IDashboardLensPartsInternal

    {

    }
}