namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Message parameters.</summary>
    public partial class HealthErrorDetailsMessageParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsMessageParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsMessageParametersInternal
    {

        /// <summary>Creates an new <see cref="HealthErrorDetailsMessageParameters" /> instance.</summary>
        public HealthErrorDetailsMessageParameters()
        {

        }
    }
    /// Message parameters.
    public partial interface IHealthErrorDetailsMessageParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Message parameters.
    internal partial interface IHealthErrorDetailsMessageParametersInternal

    {

    }
}