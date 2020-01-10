namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of express route cross connection peering.</summary>
    public partial class ExpressRouteCrossConnectionPeeringProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal
    {

        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] AdvertisedCommunity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedCommunity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedCommunity = value; }

        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] AdvertisedPublicPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedPublicPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedPublicPrefix = value; }

        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? AdvertisedPublicPrefixesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedPublicPrefixesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).AdvertisedPublicPrefixesState = value; }

        /// <summary>Backing field for <see cref="AzureAsn" /> property.</summary>
        private int? _azureAsn;

        /// <summary>The Azure ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? AzureAsn { get => this._azureAsn; }

        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? CustomerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).CustomerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).CustomerAsn = value; }

        /// <summary>Backing field for <see cref="GatewayManagerEtag" /> property.</summary>
        private string _gatewayManagerEtag;

        /// <summary>The GatewayManager Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string GatewayManagerEtag { get => this._gatewayManagerEtag; set => this._gatewayManagerEtag = value; }

        /// <summary>Backing field for <see cref="Ipv6PeeringConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfig _ipv6PeeringConfig;

        /// <summary>The IPv6 peering configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfig Ipv6PeeringConfig { get => (this._ipv6PeeringConfig = this._ipv6PeeringConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Ipv6ExpressRouteCircuitPeeringConfig()); set => this._ipv6PeeringConfig = value; }

        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigAdvertisedCommunity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigAdvertisedCommunity = value; }

        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigAdvertisedPublicPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigAdvertisedPublicPrefix = value; }

        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigAdvertisedPublicPrefixesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigAdvertisedPublicPrefixesState = value; }

        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigCustomerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigCustomerAsn = value; }

        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigLegacyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigLegacyMode = value; }

        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigRoutingRegistryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfigRoutingRegistryName = value; }

        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigPrimaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).PrimaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).PrimaryPeerAddressPrefix = value; }

        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).ProvisioningState; }

        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigSecondaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).SecondaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).SecondaryPeerAddressPrefix = value; }

        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? Ipv6PeeringConfigState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).State = value; }

        /// <summary>Backing field for <see cref="LastModifiedBy" /> property.</summary>
        private string _lastModifiedBy;

        /// <summary>Gets whether the provider or the customer last modified the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LastModifiedBy { get => this._lastModifiedBy; set => this._lastModifiedBy = value; }

        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? LegacyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).LegacyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).LegacyMode = value; }

        /// <summary>Internal Acessors for AzureAsn</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.AzureAsn { get => this._azureAsn; set { {_azureAsn = value;} } }

        /// <summary>Internal Acessors for Ipv6PeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.Ipv6PeeringConfig { get => (this._ipv6PeeringConfig = this._ipv6PeeringConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Ipv6ExpressRouteCircuitPeeringConfig()); set { {_ipv6PeeringConfig = value;} } }

        /// <summary>Internal Acessors for Ipv6PeeringConfigMicrosoftPeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.Ipv6PeeringConfigMicrosoftPeeringConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).MicrosoftPeeringConfig = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.Ipv6PeeringConfigRouteFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilter = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilterPropertiesProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).ProvisioningState = value; }

        /// <summary>Internal Acessors for MicrosoftPeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.MicrosoftPeeringConfig { get => (this._microsoftPeeringConfig = this._microsoftPeeringConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitPeeringConfig()); set { {_microsoftPeeringConfig = value;} } }

        /// <summary>Internal Acessors for PrimaryAzurePort</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.PrimaryAzurePort { get => this._primaryAzurePort; set { {_primaryAzurePort = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for RouteFilterEtag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.RouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterEtag = value; }

        /// <summary>Internal Acessors for RouteFilterName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.RouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterName = value; }

        /// <summary>Internal Acessors for RouteFilterProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.RouteFilterProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterProperty = value; }

        /// <summary>Internal Acessors for RouteFilterType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.RouteFilterType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterType = value; }

        /// <summary>Internal Acessors for SecondaryAzurePort</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal.SecondaryAzurePort { get => this._secondaryAzurePort; set { {_secondaryAzurePort = value;} } }

        /// <summary>Backing field for <see cref="MicrosoftPeeringConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig _microsoftPeeringConfig;

        /// <summary>The Microsoft peering configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get => (this._microsoftPeeringConfig = this._microsoftPeeringConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitPeeringConfig()); set => this._microsoftPeeringConfig = value; }

        /// <summary>Backing field for <see cref="PeerAsn" /> property.</summary>
        private long? _peerAsn;

        /// <summary>The peer ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? PeerAsn { get => this._peerAsn; set => this._peerAsn = value; }

        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[] Peering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).Peering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).Peering = value; }

        /// <summary>Backing field for <see cref="PeeringType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType? _peeringType;

        /// <summary>The peering type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType? PeeringType { get => this._peeringType; set => this._peeringType = value; }

        /// <summary>Backing field for <see cref="PrimaryAzurePort" /> property.</summary>
        private string _primaryAzurePort;

        /// <summary>The primary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PrimaryAzurePort { get => this._primaryAzurePort; }

        /// <summary>Backing field for <see cref="PrimaryPeerAddressPrefix" /> property.</summary>
        private string _primaryPeerAddressPrefix;

        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PrimaryPeerAddressPrefix { get => this._primaryPeerAddressPrefix; set => this._primaryPeerAddressPrefix = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterEtag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterId = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterLocation = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterName; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags RouteFilterTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterTag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).RouteFilterType; }

        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RoutingRegistryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).RoutingRegistryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfigInternal)MicrosoftPeeringConfig).RoutingRegistryName = value; }

        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[] Rule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).Rule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfigInternal)Ipv6PeeringConfig).Rule = value; }

        /// <summary>Backing field for <see cref="SecondaryAzurePort" /> property.</summary>
        private string _secondaryAzurePort;

        /// <summary>The secondary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SecondaryAzurePort { get => this._secondaryAzurePort; }

        /// <summary>Backing field for <see cref="SecondaryPeerAddressPrefix" /> property.</summary>
        private string _secondaryPeerAddressPrefix;

        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SecondaryPeerAddressPrefix { get => this._secondaryPeerAddressPrefix; set => this._secondaryPeerAddressPrefix = value; }

        /// <summary>Backing field for <see cref="SharedKey" /> property.</summary>
        private string _sharedKey;

        /// <summary>The shared key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SharedKey { get => this._sharedKey; set => this._sharedKey = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringState? _state;

        /// <summary>The peering state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringState? State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="VlanId" /> property.</summary>
        private int? _vlanId;

        /// <summary>The VLAN ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? VlanId { get => this._vlanId; set => this._vlanId = value; }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteCrossConnectionPeeringProperties" /> instance.
        /// </summary>
        public ExpressRouteCrossConnectionPeeringProperties()
        {

        }
    }
    /// Properties of express route cross connection peering.
    public partial interface IExpressRouteCrossConnectionPeeringProperties :
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
        /// <summary>The Azure ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Azure ASN.",
        SerializedName = @"azureASN",
        PossibleTypes = new [] { typeof(int) })]
        int? AzureAsn { get;  }
        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CustomerASN of the peering.",
        SerializedName = @"customerASN",
        PossibleTypes = new [] { typeof(int) })]
        int? CustomerAsn { get; set; }
        /// <summary>The GatewayManager Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The GatewayManager Etag.",
        SerializedName = @"gatewayManagerEtag",
        PossibleTypes = new [] { typeof(string) })]
        string GatewayManagerEtag { get; set; }
        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The communities of bgp peering. Specified for microsoft peering",
        SerializedName = @"advertisedCommunities",
        PossibleTypes = new [] { typeof(string) })]
        string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity { get; set; }
        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of AdvertisedPublicPrefixes.",
        SerializedName = @"advertisedPublicPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState { get; set; }
        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CustomerASN of the peering.",
        SerializedName = @"customerASN",
        PossibleTypes = new [] { typeof(int) })]
        int? Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The legacy mode of the peering.",
        SerializedName = @"legacyMode",
        PossibleTypes = new [] { typeof(int) })]
        int? Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode { get; set; }
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RoutingRegistryName of the configuration.",
        SerializedName = @"routingRegistryName",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName { get; set; }
        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary address prefix.",
        SerializedName = @"primaryPeerAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigPrimaryPeerAddressPrefix { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get;  }
        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secondary address prefix.",
        SerializedName = @"secondaryPeerAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigSecondaryPeerAddressPrefix { get; set; }
        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state of peering. Possible values are: 'Disabled' and 'Enabled'",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? Ipv6PeeringConfigState { get; set; }
        /// <summary>Gets whether the provider or the customer last modified the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets whether the provider or the customer last modified the peering.",
        SerializedName = @"lastModifiedBy",
        PossibleTypes = new [] { typeof(string) })]
        string LastModifiedBy { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The legacy mode of the peering.",
        SerializedName = @"legacyMode",
        PossibleTypes = new [] { typeof(int) })]
        int? LegacyMode { get; set; }
        /// <summary>The peer ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The peer ASN.",
        SerializedName = @"peerASN",
        PossibleTypes = new [] { typeof(long) })]
        long? PeerAsn { get; set; }
        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of references to express route circuit peerings.",
        SerializedName = @"peerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[] Peering { get; set; }
        /// <summary>The peering type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The peering type.",
        SerializedName = @"peeringType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType? PeeringType { get; set; }
        /// <summary>The primary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The primary port.",
        SerializedName = @"primaryAzurePort",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryAzurePort { get;  }
        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary address prefix.",
        SerializedName = @"primaryPeerAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryPeerAddressPrefix { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
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
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RoutingRegistryName of the configuration.",
        SerializedName = @"routingRegistryName",
        PossibleTypes = new [] { typeof(string) })]
        string RoutingRegistryName { get; set; }
        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of RouteFilterRules contained within a route filter.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[] Rule { get; set; }
        /// <summary>The secondary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The secondary port.",
        SerializedName = @"secondaryAzurePort",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryAzurePort { get;  }
        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secondary address prefix.",
        SerializedName = @"secondaryPeerAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryPeerAddressPrefix { get; set; }
        /// <summary>The shared key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The shared key.",
        SerializedName = @"sharedKey",
        PossibleTypes = new [] { typeof(string) })]
        string SharedKey { get; set; }
        /// <summary>The peering state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The peering state.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringState? State { get; set; }
        /// <summary>The VLAN ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The VLAN ID.",
        SerializedName = @"vlanId",
        PossibleTypes = new [] { typeof(int) })]
        int? VlanId { get; set; }

    }
    /// Properties of express route cross connection peering.
    internal partial interface IExpressRouteCrossConnectionPeeringPropertiesInternal

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
        /// <summary>The Azure ASN.</summary>
        int? AzureAsn { get; set; }
        /// <summary>The CustomerASN of the peering.</summary>
        int? CustomerAsn { get; set; }
        /// <summary>The GatewayManager Etag.</summary>
        string GatewayManagerEtag { get; set; }
        /// <summary>The IPv6 peering configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfig Ipv6PeeringConfig { get; set; }
        /// <summary>The Microsoft peering configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig Ipv6PeeringConfigMicrosoftPeeringConfig { get; set; }
        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity { get; set; }
        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix { get; set; }
        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState { get; set; }
        /// <summary>The CustomerASN of the peering.</summary>
        int? Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        int? Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode { get; set; }
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        string Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName { get; set; }
        /// <summary>The primary address prefix.</summary>
        string Ipv6PeeringConfigPrimaryPeerAddressPrefix { get; set; }
        /// <summary>The reference of the RouteFilter resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter Ipv6PeeringConfigRouteFilter { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        string Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get; set; }
        /// <summary>The secondary address prefix.</summary>
        string Ipv6PeeringConfigSecondaryPeerAddressPrefix { get; set; }
        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? Ipv6PeeringConfigState { get; set; }
        /// <summary>Gets whether the provider or the customer last modified the peering.</summary>
        string LastModifiedBy { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        int? LegacyMode { get; set; }
        /// <summary>The Microsoft peering configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get; set; }
        /// <summary>The peer ASN.</summary>
        long? PeerAsn { get; set; }
        /// <summary>A collection of references to express route circuit peerings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[] Peering { get; set; }
        /// <summary>The peering type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType? PeeringType { get; set; }
        /// <summary>The primary port.</summary>
        string PrimaryAzurePort { get; set; }
        /// <summary>The primary address prefix.</summary>
        string PrimaryPeerAddressPrefix { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
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
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        string RoutingRegistryName { get; set; }
        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[] Rule { get; set; }
        /// <summary>The secondary port.</summary>
        string SecondaryAzurePort { get; set; }
        /// <summary>The secondary address prefix.</summary>
        string SecondaryPeerAddressPrefix { get; set; }
        /// <summary>The shared key.</summary>
        string SharedKey { get; set; }
        /// <summary>The peering state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringState? State { get; set; }
        /// <summary>The VLAN ID.</summary>
        int? VlanId { get; set; }

    }
}