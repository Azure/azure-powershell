namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Additional details of Sub Tasks</summary>
    public partial class JobSubTaskAdditionalDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobSubTaskAdditionalDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobSubTaskAdditionalDetailsInternal
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