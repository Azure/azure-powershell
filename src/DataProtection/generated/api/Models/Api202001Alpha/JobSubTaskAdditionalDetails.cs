namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Sub Tasks's additional details</summary>
    public partial class JobSubTaskAdditionalDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobSubTaskAdditionalDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobSubTaskAdditionalDetailsInternal
    {

        /// <summary>Creates an new <see cref="JobSubTaskAdditionalDetails" /> instance.</summary>
        public JobSubTaskAdditionalDetails()
        {

        }
    }
    /// Sub Tasks's additional details
    public partial interface IJobSubTaskAdditionalDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IAssociativeArray<string>
    {

    }
    /// Sub Tasks's additional details
    internal partial interface IJobSubTaskAdditionalDetailsInternal

    {

    }
}