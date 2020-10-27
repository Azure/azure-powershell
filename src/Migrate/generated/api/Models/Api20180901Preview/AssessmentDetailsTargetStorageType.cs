namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the target storage type.</summary>
    public partial class AssessmentDetailsTargetStorageType :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsTargetStorageType,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsTargetStorageTypeInternal
    {

        /// <summary>Creates an new <see cref="AssessmentDetailsTargetStorageType" /> instance.</summary>
        public AssessmentDetailsTargetStorageType()
        {

        }
    }
    /// Gets or sets the target storage type.
    public partial interface IAssessmentDetailsTargetStorageType :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the target storage type.
    internal partial interface IAssessmentDetailsTargetStorageTypeInternal

    {

    }
}