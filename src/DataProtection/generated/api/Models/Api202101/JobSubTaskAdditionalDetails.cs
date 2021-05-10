namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Additional details of Sub Tasks</summary>
    public partial class JobSubTaskAdditionalDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobSubTaskAdditionalDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobSubTaskAdditionalDetailsInternal
    {

        /// <summary>Creates an new <see cref="JobSubTaskAdditionalDetails" /> instance.</summary>
        public JobSubTaskAdditionalDetails()
        {

        }
    }
    /// Additional details of Sub Tasks
    public partial interface IJobSubTaskAdditionalDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IAssociativeArray<string>
    {

    }
    /// Additional details of Sub Tasks
    internal partial interface IJobSubTaskAdditionalDetailsInternal

    {

    }
}