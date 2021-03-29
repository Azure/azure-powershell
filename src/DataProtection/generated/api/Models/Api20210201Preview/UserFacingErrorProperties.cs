namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Any key value pairs that can be injected inside error object</summary>
    public partial class UserFacingErrorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingErrorProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingErrorPropertiesInternal
    {

        /// <summary>Creates an new <see cref="UserFacingErrorProperties" /> instance.</summary>
        public UserFacingErrorProperties()
        {

        }
    }
    /// Any key value pairs that can be injected inside error object
    public partial interface IUserFacingErrorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IAssociativeArray<string>
    {

    }
    /// Any key value pairs that can be injected inside error object
    internal partial interface IUserFacingErrorPropertiesInternal

    {

    }
}