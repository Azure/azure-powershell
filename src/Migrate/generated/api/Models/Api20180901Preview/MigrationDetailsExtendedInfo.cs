namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the ISV specific extended information.</summary>
    public partial class MigrationDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsExtendedInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsExtendedInfoInternal
    {

        /// <summary>Creates an new <see cref="MigrationDetailsExtendedInfo" /> instance.</summary>
        public MigrationDetailsExtendedInfo()
        {

        }
    }
    /// Gets or sets the ISV specific extended information.
    public partial interface IMigrationDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the ISV specific extended information.
    internal partial interface IMigrationDetailsExtendedInfoInternal

    {

    }
}