namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Dictionary of <string></summary>
    public partial class DppWorkerRequestParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestParameters,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestParametersInternal
    {

        /// <summary>Creates an new <see cref="DppWorkerRequestParameters" /> instance.</summary>
        public DppWorkerRequestParameters()
        {

        }
    }
    /// Dictionary of <string>
    public partial interface IDppWorkerRequestParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IAssociativeArray<string>
    {

    }
    /// Dictionary of <string>
    internal partial interface IDppWorkerRequestParametersInternal

    {

    }
}