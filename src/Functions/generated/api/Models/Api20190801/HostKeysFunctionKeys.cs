namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Host level function keys.</summary>
    public partial class HostKeysFunctionKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeys,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeysInternal
    {

        /// <summary>Creates an new <see cref="HostKeysFunctionKeys" /> instance.</summary>
        public HostKeysFunctionKeys()
        {

        }
    }
    /// Host level function keys.
    public partial interface IHostKeysFunctionKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Host level function keys.
    internal partial interface IHostKeysFunctionKeysInternal

    {

    }
}