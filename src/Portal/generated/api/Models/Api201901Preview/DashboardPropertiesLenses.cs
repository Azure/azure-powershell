namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>The dashboard lenses.</summary>
    public partial class DashboardPropertiesLenses :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesLenses,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesLensesInternal
    {

        /// <summary>Creates an new <see cref="DashboardPropertiesLenses" /> instance.</summary>
        public DashboardPropertiesLenses()
        {

        }
    }
    /// The dashboard lenses.
    public partial interface IDashboardPropertiesLenses :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>
    {

    }
    /// The dashboard lenses.
    internal partial interface IDashboardPropertiesLensesInternal

    {

    }
}