namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Gets or sets the database instances summary per solution. The key of dictionary is the solution name and value is the
    /// corresponding database instance summary object.
    /// </summary>
    public partial class DatabaseInstancePropertiesSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstancePropertiesSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstancePropertiesSummaryInternal
    {

        /// <summary>Creates an new <see cref="DatabaseInstancePropertiesSummary" /> instance.</summary>
        public DatabaseInstancePropertiesSummary()
        {

        }
    }
    /// Gets or sets the database instances summary per solution. The key of dictionary is the solution name and value is the
    /// corresponding database instance summary object.
    public partial interface IDatabaseInstancePropertiesSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceSummary>
    {

    }
    /// Gets or sets the database instances summary per solution. The key of dictionary is the solution name and value is the
    /// corresponding database instance summary object.
    internal partial interface IDatabaseInstancePropertiesSummaryInternal

    {

    }
}