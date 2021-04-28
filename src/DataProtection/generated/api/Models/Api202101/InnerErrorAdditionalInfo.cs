namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>
    /// Any Key value pairs that can be provided to the client for additional verbose information.
    /// </summary>
    public partial class InnerErrorAdditionalInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IInnerErrorAdditionalInfo,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IInnerErrorAdditionalInfoInternal
    {

        /// <summary>Creates an new <see cref="InnerErrorAdditionalInfo" /> instance.</summary>
        public InnerErrorAdditionalInfo()
        {

        }
    }
    /// Any Key value pairs that can be provided to the client for additional verbose information.
    public partial interface IInnerErrorAdditionalInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IAssociativeArray<string>
    {

    }
    /// Any Key value pairs that can be provided to the client for additional verbose information.
    internal partial interface IInnerErrorAdditionalInfoInternal

    {

    }
}