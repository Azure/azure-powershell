namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Peering in an ExpressRoute Cross Connection resource.</summary>
    public partial class ExpressRouteCrossConnectionPeering :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource();

        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] AdvertisedCommunity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AdvertisedCommunity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AdvertisedCommunity = value; }

        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] AdvertisedPublicPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AdvertisedPublicPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AdvertisedPublicPrefix = value; }

        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? AdvertisedPublicPrefixesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AdvertisedPublicPrefixesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AdvertisedPublicPrefixesState = value; }

        /// <summary>The Azure ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? AzureAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AzureAsn; }

        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? CustomerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).CustomerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).CustomerAsn = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; }

        /// <summary>The GatewayManager Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string GatewayManagerEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).GatewayManagerEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).GatewayManagerEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity = value; }

        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix = value; }

        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState = value; }

        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn = value; }

        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode = value; }

        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName = value; }

        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigPrimaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigPrimaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigPrimaryPeerAddressPrefix = value; }

        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesProvisioningState; }

        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigSecondaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigSecondaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigSecondaryPeerAddressPrefix = value; }

        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? Ipv6PeeringConfigState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigState = value; }

        /// <summary>Gets whether the provider or the customer last modified the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).LastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).LastModifiedBy = value; }

        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? LegacyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).LegacyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).LegacyMode = value; }

        /// <summary>Internal Acessors for AzureAsn</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.AzureAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AzureAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).AzureAsn = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for Ipv6PeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpv6ExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.Ipv6PeeringConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfig = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigMicrosoftPeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.Ipv6PeeringConfigMicrosoftPeeringConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfig = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.Ipv6PeeringConfigRouteFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigRouteFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigRouteFilter = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilterPropertiesProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesProvisioningState = value; }

        /// <summary>Internal Acessors for MicrosoftPeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.MicrosoftPeeringConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).MicrosoftPeeringConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).MicrosoftPeeringConfig = value; }

        /// <summary>Internal Acessors for PrimaryAzurePort</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.PrimaryAzurePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PrimaryAzurePort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PrimaryAzurePort = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCrossConnectionPeeringProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for RouteFilterEtag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.RouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterEtag = value; }

        /// <summary>Internal Acessors for RouteFilterName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.RouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterName = value; }

        /// <summary>Internal Acessors for RouteFilterProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.RouteFilterProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterProperty = value; }

        /// <summary>Internal Acessors for RouteFilterType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.RouteFilterType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterType = value; }

        /// <summary>Internal Acessors for SecondaryAzurePort</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringInternal.SecondaryAzurePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).SecondaryAzurePort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).SecondaryAzurePort = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>The peer ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? PeerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PeerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PeerAsn = value; }

        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[] Peering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Peering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Peering = value; }

        /// <summary>The peering type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType? PeeringType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PeeringType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PeeringType = value; }

        /// <summary>The primary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PrimaryAzurePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PrimaryAzurePort; }

        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PrimaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PrimaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).PrimaryPeerAddressPrefix = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringProperties _property;

        /// <summary>Properties of the express route cross connection peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCrossConnectionPeeringProperties()); set => this._property = value; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterEtag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterId = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterLocation = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterName; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags RouteFilterTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterTag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RouteFilterType; }

        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RoutingRegistryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RoutingRegistryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).RoutingRegistryName = value; }

        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[] Rule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Rule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).Rule = value; }

        /// <summary>The secondary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SecondaryAzurePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).SecondaryAzurePort; }

        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SecondaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).SecondaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).SecondaryPeerAddressPrefix = value; }

        /// <summary>The shared key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SharedKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).SharedKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).SharedKey = value; }

        /// <summary>The peering state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringState? State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).State = value; }

        /// <summary>The VLAN ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? VlanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).VlanId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringPropertiesInternal)Property).VlanId = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCrossConnectionPeering" /> instance.</summary>
        public ExpressRouteCrossConnectionPeering()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__subResource), __subResource);
            await eventListener.AssertObjectIsValid(nameof(__subResource), __subResource);
        }
    }
    /// Peering in an ExpressRoute Cross Connection resource.
    public partial interface IExpressRouteCrossConnectionPeering :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
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
        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
    /// Peering in an ExpressRoute Cross Connection resource.
    internal partial interface IExpressRouteCrossConnectionPeeringInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
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
        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
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
        /// <summary>Properties of the express route cross connection peering.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeeringProperties Property { get; set; }
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