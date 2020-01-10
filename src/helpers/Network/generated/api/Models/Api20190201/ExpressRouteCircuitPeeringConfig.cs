namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Specifies the peering configuration.</summary>
    public partial class ExpressRouteCircuitPeeringConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal
    {

        /// <summary>Backing field for <see cref="AdvertisedCommunity" /> property.</summary>
        private string[] _advertisedCommunity;

        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AdvertisedCommunity { get => this._advertisedCommunity; set => this._advertisedCommunity = value; }

        /// <summary>Backing field for <see cref="AdvertisedPublicPrefix" /> property.</summary>
        private string[] _advertisedPublicPrefix;

        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AdvertisedPublicPrefix { get => this._advertisedPublicPrefix; set => this._advertisedPublicPrefix = value; }

        /// <summary>Backing field for <see cref="AdvertisedPublicPrefixesState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? _advertisedPublicPrefixesState;

        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? AdvertisedPublicPrefixesState { get => this._advertisedPublicPrefixesState; set => this._advertisedPublicPrefixesState = value; }

        /// <summary>Backing field for <see cref="CustomerAsn" /> property.</summary>
        private int? _customerAsn;

        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? CustomerAsn { get => this._customerAsn; set => this._customerAsn = value; }

        /// <summary>Backing field for <see cref="LegacyMode" /> property.</summary>
        private int? _legacyMode;

        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? LegacyMode { get => this._legacyMode; set => this._legacyMode = value; }

        /// <summary>Backing field for <see cref="RoutingRegistryName" /> property.</summary>
        private string _routingRegistryName;

        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RoutingRegistryName { get => this._routingRegistryName; set => this._routingRegistryName = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitPeeringConfig" /> instance.</summary>
        public ExpressRouteCircuitPeeringConfig()
        {

        }
    }
    /// Specifies the peering configuration.
    public partial interface IExpressRouteCircuitPeeringConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The communities of bgp peering. Specified for microsoft peering",
        SerializedName = @"advertisedCommunities",
        PossibleTypes = new [] { typeof(string) })]
        string[] AdvertisedCommunity { get; set; }
        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of AdvertisedPublicPrefixes.",
        SerializedName = @"advertisedPublicPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AdvertisedPublicPrefix { get; set; }
        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.",
        SerializedName = @"advertisedPublicPrefixesState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? AdvertisedPublicPrefixesState { get; set; }
        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CustomerASN of the peering.",
        SerializedName = @"customerASN",
        PossibleTypes = new [] { typeof(int) })]
        int? CustomerAsn { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The legacy mode of the peering.",
        SerializedName = @"legacyMode",
        PossibleTypes = new [] { typeof(int) })]
        int? LegacyMode { get; set; }
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RoutingRegistryName of the configuration.",
        SerializedName = @"routingRegistryName",
        PossibleTypes = new [] { typeof(string) })]
        string RoutingRegistryName { get; set; }

    }
    /// Specifies the peering configuration.
    internal partial interface IExpressRouteCircuitPeeringConfigInternal

    {
        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        string[] AdvertisedCommunity { get; set; }
        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        string[] AdvertisedPublicPrefix { get; set; }
        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? AdvertisedPublicPrefixesState { get; set; }
        /// <summary>The CustomerASN of the peering.</summary>
        int? CustomerAsn { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        int? LegacyMode { get; set; }
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        string RoutingRegistryName { get; set; }

    }
}