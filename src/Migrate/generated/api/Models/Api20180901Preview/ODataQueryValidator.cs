namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class ODataQueryValidator :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryValidator,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryValidatorInternal
    {

        /// <summary>Creates an new <see cref="ODataQueryValidator" /> instance.</summary>
        public ODataQueryValidator()
        {

        }
    }
    public partial interface IODataQueryValidator :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {

    }
    internal partial interface IODataQueryValidatorInternal

    {

    }
}