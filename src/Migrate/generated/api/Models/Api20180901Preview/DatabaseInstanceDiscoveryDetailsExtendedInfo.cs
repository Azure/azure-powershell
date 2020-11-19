namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the extended properties of the database server.</summary>
    public partial class DatabaseInstanceDiscoveryDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetailsExtendedInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetailsExtendedInfoInternal
    {

        /// <summary>
        /// Creates an new <see cref="DatabaseInstanceDiscoveryDetailsExtendedInfo" /> instance.
        /// </summary>
        public DatabaseInstanceDiscoveryDetailsExtendedInfo()
        {

        }
    }
    /// Gets or sets the extended properties of the database server.
    public partial interface IDatabaseInstanceDiscoveryDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the extended properties of the database server.
    internal partial interface IDatabaseInstanceDiscoveryDetailsExtendedInfoInternal

    {

    }
}