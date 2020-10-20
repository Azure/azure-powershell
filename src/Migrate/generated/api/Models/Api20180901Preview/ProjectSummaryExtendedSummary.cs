namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the extended summary.</summary>
    public partial class ProjectSummaryExtendedSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummaryInternal
    {

        /// <summary>Creates an new <see cref="ProjectSummaryExtendedSummary" /> instance.</summary>
        public ProjectSummaryExtendedSummary()
        {

        }
    }
    /// Gets or sets the extended summary.
    public partial interface IProjectSummaryExtendedSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the extended summary.
    internal partial interface IProjectSummaryExtendedSummaryInternal

    {

    }
}