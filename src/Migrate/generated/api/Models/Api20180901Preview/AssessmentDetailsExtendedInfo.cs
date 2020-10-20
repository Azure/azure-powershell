namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the ISV specific extended information.</summary>
    public partial class AssessmentDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsExtendedInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsExtendedInfoInternal
    {

        /// <summary>Creates an new <see cref="AssessmentDetailsExtendedInfo" /> instance.</summary>
        public AssessmentDetailsExtendedInfo()
        {

        }
    }
    /// Gets or sets the ISV specific extended information.
    public partial interface IAssessmentDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the ISV specific extended information.
    internal partial interface IAssessmentDetailsExtendedInfoInternal

    {

    }
}