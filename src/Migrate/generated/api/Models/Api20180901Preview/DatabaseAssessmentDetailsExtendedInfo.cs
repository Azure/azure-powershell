namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the extended properties of the database.</summary>
    public partial class DatabaseAssessmentDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfoInternal
    {

        /// <summary>Creates an new <see cref="DatabaseAssessmentDetailsExtendedInfo" /> instance.</summary>
        public DatabaseAssessmentDetailsExtendedInfo()
        {

        }
    }
    /// Gets or sets the extended properties of the database.
    public partial interface IDatabaseAssessmentDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the extended properties of the database.
    internal partial interface IDatabaseAssessmentDetailsExtendedInfoInternal

    {

    }
}