namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>System keys.</summary>
    public partial class HostKeysSystemKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeys,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeysInternal
    {

        /// <summary>Creates an new <see cref="HostKeysSystemKeys" /> instance.</summary>
        public HostKeysSystemKeys()
        {

        }
    }
    /// System keys.
    public partial interface IHostKeysSystemKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// System keys.
    internal partial interface IHostKeysSystemKeysInternal

    {

    }
}