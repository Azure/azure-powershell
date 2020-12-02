namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets the summary of the migrate project.</summary>
    public partial class MigrateProjectPropertiesSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesSummaryInternal
    {

        /// <summary>Creates an new <see cref="MigrateProjectPropertiesSummary" /> instance.</summary>
        public MigrateProjectPropertiesSummary()
        {

        }
    }
    /// Gets the summary of the migrate project.
    public partial interface IMigrateProjectPropertiesSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummary>
    {

    }
    /// Gets the summary of the migrate project.
    internal partial interface IMigrateProjectPropertiesSummaryInternal

    {

    }
}