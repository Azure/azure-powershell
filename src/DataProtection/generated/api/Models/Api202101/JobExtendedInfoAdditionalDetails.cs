namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Job's Additional Details</summary>
    public partial class JobExtendedInfoAdditionalDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobExtendedInfoAdditionalDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobExtendedInfoAdditionalDetailsInternal
    {

        /// <summary>Creates an new <see cref="JobExtendedInfoAdditionalDetails" /> instance.</summary>
        public JobExtendedInfoAdditionalDetails()
        {

        }
    }
    /// Job's Additional Details
    public partial interface IJobExtendedInfoAdditionalDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IAssociativeArray<string>
    {

    }
    /// Job's Additional Details
    internal partial interface IJobExtendedInfoAdditionalDetailsInternal

    {

    }
}