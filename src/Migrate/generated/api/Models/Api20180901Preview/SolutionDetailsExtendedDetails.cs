namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the extended details reported by the solution.</summary>
    public partial class SolutionDetailsExtendedDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetailsInternal
    {

        /// <summary>Creates an new <see cref="SolutionDetailsExtendedDetails" /> instance.</summary>
        public SolutionDetailsExtendedDetails()
        {

        }
    }
    /// Gets or sets the extended details reported by the solution.
    public partial interface ISolutionDetailsExtendedDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the extended details reported by the solution.
    internal partial interface ISolutionDetailsExtendedDetailsInternal

    {

    }
}