namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the ISV specific extended information.</summary>
    public partial class DiscoveryDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetailsExtendedInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetailsExtendedInfoInternal
    {

        /// <summary>Creates an new <see cref="DiscoveryDetailsExtendedInfo" /> instance.</summary>
        public DiscoveryDetailsExtendedInfo()
        {

        }
    }
    /// Gets or sets the ISV specific extended information.
    public partial interface IDiscoveryDetailsExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the ISV specific extended information.
    internal partial interface IDiscoveryDetailsExtendedInfoInternal

    {

    }
}