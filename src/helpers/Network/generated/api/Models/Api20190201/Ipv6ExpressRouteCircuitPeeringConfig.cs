namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains IPv6 peering config.</summary>
    public partial class Ipv6ExpressRouteCircuitPeeringConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal
    {

        /// <summary>Internal Acessors for MicrosoftPeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal.MicrosoftPeeringConfig { get => (this._microsoftPeeringConfig = this._microsoftPeeringConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitPeeringConfig()); set { {_microsoftPeeringConfig = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).ProvisioningState = value; }

        /// <summary>Internal Acessors for RouteFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal.RouteFilter { get => (this._routeFilter = this._routeFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RouteFilter()); set { {_routeFilter = value;} } }

        /// <summary>Internal Acessors for RouteFilterEtag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal.RouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Etag = value; }

        /// <summary>Internal Acessors for RouteFilterName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal.RouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Name = value; }

        /// <summary>Internal Acessors for RouteFilterProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal.RouteFilterProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Property = value; }

        /// <summary>Internal Acessors for RouteFilterType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal.RouteFilterType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Type = value; }

        /// <summary>Backing field for <see cref="MicrosoftPeeringConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig _microsoftPeeringConfig;

        /// <summary>The Microsoft peering configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get => (this._microsoftPeeringConfig = this._microsoftPeeringConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitPeeringConfig()); set => this._microsoftPeeringConfig = value; }

        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] MicrosoftPeeringConfigAdvertisedCommunity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedCommunity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedCommunity = value; }

        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] MicrosoftPeeringConfigAdvertisedPublicPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedPublicPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedPublicPrefix = value; }

        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? MicrosoftPeeringConfigAdvertisedPublicPrefixesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedPublicPrefixesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedPublicPrefixesState = value; }

        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? MicrosoftPeeringConfigCustomerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).CustomerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).CustomerAsn = value; }

        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? MicrosoftPeeringConfigLegacyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).LegacyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).LegacyMode = value; }

        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string MicrosoftPeeringConfigRoutingRegistryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).RoutingRegistryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).RoutingRegistryName = value; }

        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[] Peering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Peering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Peering = value; }

        /// <summary>Backing field for <see cref="PrimaryPeerAddressPrefix" /> property.</summary>
        private string _primaryPeerAddressPrefix;

        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PrimaryPeerAddressPrefix { get => this._primaryPeerAddressPrefix; set => this._primaryPeerAddressPrefix = value; }

        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).ProvisioningState; }

        /// <summary>Backing field for <see cref="RouteFilter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter _routeFilter;

        /// <summary>The reference of the RouteFilter resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter RouteFilter { get => (this._routeFilter = this._routeFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RouteFilter()); set => this._routeFilter = value; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Etag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Name; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags RouteFilterTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteFilter).Type; }

        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[] Rule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Rule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterInternal)RouteFilter).Rule = value; }

        /// <summary>Backing field for <see cref="SecondaryPeerAddressPrefix" /> property.</summary>
        private string _secondaryPeerAddressPrefix;

        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SecondaryPeerAddressPrefix { get => this._secondaryPeerAddressPrefix; set => this._secondaryPeerAddressPrefix = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? _state;

        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="Ipv6ExpressRouteCircuitPeeringConfig" /> instance.</summary>
        public Ipv6ExpressRouteCircuitPeeringConfig()
        {

        }
    }
    /// Contains IPv6 peering config.
    public partial interface IIpv6ExpressRouteCircuitPeeringConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The communities of bgp peering. Specified for microsoft peering",
        SerializedName = @"advertisedCommunities",
        PossibleTypes = new [] { typeof(string) })]
        string[] MicrosoftPeeringConfigAdvertisedCommunity { get; set; }
        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of AdvertisedPublicPrefixes.",
        SerializedName = @"advertisedPublicPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] MicrosoftPeeringConfigAdvertisedPublicPrefix { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? MicrosoftPeeringConfigAdvertisedPublicPrefixesState { get; set; }
        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CustomerASN of the peering.",
        SerializedName = @"customerASN",
        PossibleTypes = new [] { typeof(int) })]
        int? MicrosoftPeeringConfigCustomerAsn { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The legacy mode of the peering.",
        SerializedName = @"legacyMode",
        PossibleTypes = new [] { typeof(int) })]
        int? MicrosoftPeeringConfigLegacyMode { get; set; }
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RoutingRegistryName of the configuration.",
        SerializedName = @"routingRegistryName",
        PossibleTypes = new [] { typeof(string) })]
        string MicrosoftPeeringConfigRoutingRegistryName { get; set; }
        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of references to express route circuit peerings.",
        SerializedName = @"peerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[] Peering { get; set; }
        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary address prefix.",
        SerializedName = @"primaryPeerAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryPeerAddressPrefix { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string RouteFilterEtag { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string RouteFilterId { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string RouteFilterLocation { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string RouteFilterName { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags RouteFilterTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string RouteFilterType { get;  }
        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of RouteFilterRules contained within a route filter.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[] Rule { get; set; }
        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secondary address prefix.",
        SerializedName = @"secondaryPeerAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryPeerAddressPrefix { get; set; }
        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state of peering. Possible values are: 'Disabled' and 'Enabled'",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? State { get; set; }

    }
    /// Contains IPv6 peering config.
    internal partial interface IIpv6ExpressRouteCircuitPeeringConfigInternal

    {
        /// <summary>The Microsoft peering configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get; set; }
        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        string[] MicrosoftPeeringConfigAdvertisedCommunity { get; set; }
        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        string[] MicrosoftPeeringConfigAdvertisedPublicPrefix { get; set; }
        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? MicrosoftPeeringConfigAdvertisedPublicPrefixesState { get; set; }
        /// <summary>The CustomerASN of the peering.</summary>
        int? MicrosoftPeeringConfigCustomerAsn { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        int? MicrosoftPeeringConfigLegacyMode { get; set; }
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        string MicrosoftPeeringConfigRoutingRegistryName { get; set; }
        /// <summary>A collection of references to express route circuit peerings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[] Peering { get; set; }
        /// <summary>The primary address prefix.</summary>
        string PrimaryPeerAddressPrefix { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the RouteFilter resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter RouteFilter { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string RouteFilterEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string RouteFilterId { get; set; }
        /// <summary>Resource location.</summary>
        string RouteFilterLocation { get; set; }
        /// <summary>Resource name.</summary>
        string RouteFilterName { get; set; }
        /// <summary>Properties of the route filter.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterPropertiesFormat RouteFilterProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags RouteFilterTag { get; set; }
        /// <summary>Resource type.</summary>
        string RouteFilterType { get; set; }
        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[] Rule { get; set; }
        /// <summary>The secondary address prefix.</summary>
        string SecondaryPeerAddressPrefix { get; set; }
        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? State { get; set; }

    }
}