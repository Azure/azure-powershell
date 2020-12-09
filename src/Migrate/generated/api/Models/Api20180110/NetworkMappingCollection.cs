namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// List of network mappings. As with NetworkMapping, it should be possible to reuse a prev version of this class. It doesn't
    /// seem likely this class could be anything more than a slightly bespoke collection of NetworkMapping. Hence it makes sense
    /// to override Load with Base.NetworkMapping instead of existing CurrentVersion.NetworkMapping.
    /// </summary>
    public partial class NetworkMappingCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping[] _value;

        /// <summary>The Network Mappings list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="NetworkMappingCollection" /> instance.</summary>
        public NetworkMappingCollection()
        {

        }
    }
    /// List of network mappings. As with NetworkMapping, it should be possible to reuse a prev version of this class. It doesn't
    /// seem likely this class could be anything more than a slightly bespoke collection of NetworkMapping. Hence it makes sense
    /// to override Load with Base.NetworkMapping instead of existing CurrentVersion.NetworkMapping.
    public partial interface INetworkMappingCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The Network Mappings list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Network Mappings list.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping[] Value { get; set; }

    }
    /// List of network mappings. As with NetworkMapping, it should be possible to reuse a prev version of this class. It doesn't
    /// seem likely this class could be anything more than a slightly bespoke collection of NetworkMapping. Hence it makes sense
    /// to override Load with Base.NetworkMapping instead of existing CurrentVersion.NetworkMapping.
    internal partial interface INetworkMappingCollectionInternal

    {
        /// <summary>The value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>The Network Mappings list.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping[] Value { get; set; }

    }
}