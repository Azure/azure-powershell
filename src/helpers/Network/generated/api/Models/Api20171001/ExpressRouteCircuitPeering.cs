namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Peering in an ExpressRouteCircuit resource.</summary>
    public partial class ExpressRouteCircuitPeering :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] AdvertisedCommunity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).AdvertisedCommunity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).AdvertisedCommunity = value; }

        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] AdvertisedPublicPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).AdvertisedPublicPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).AdvertisedPublicPrefix = value; }

        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? AdvertisedPublicPrefixesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).AdvertisedPublicPrefixesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).AdvertisedPublicPrefixesState = value; }

        /// <summary>The Azure ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? AzureAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).AzureAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).AzureAsn = value; }

        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? CustomerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).CustomerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).CustomerAsn = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; }

        /// <summary>The GatewayManager Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string GatewayManagerEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).GatewayManagerEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).GatewayManagerEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>The communities of bgp peering. Specified for microsoft peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity = value; }

        /// <summary>The reference of AdvertisedPublicPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix = value; }

        /// <summary>
        /// AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured',
        /// and 'ValidationNeeded'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState? Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState = value; }

        /// <summary>The CustomerASN of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn = value; }

        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode = value; }

        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName = value; }

        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigPrimaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigPrimaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigPrimaryPeerAddressPrefix = value; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigRouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterEtag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigRouteFilterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterId = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigRouteFilterLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterLocation = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigRouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterName; }

        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Ipv6PeeringConfigRouteFilterPropertiesPeering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesPeering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesPeering = value; }

        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesProvisioningState; }

        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[] Ipv6PeeringConfigRouteFilterPropertiesRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesRule = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Ipv6PeeringConfigRouteFilterTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterTag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigRouteFilterType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterType; }

        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Ipv6PeeringConfigSecondaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigSecondaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigSecondaryPeerAddressPrefix = value; }

        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? Ipv6PeeringConfigState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigState = value; }

        /// <summary>Gets whether the provider or the customer last modified the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).LastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).LastModifiedBy = value; }

        /// <summary>The legacy mode of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? LegacyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).LegacyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).LegacyMode = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Location = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for Ipv6PeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Ipv6PeeringConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfig = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigMicrosoftPeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Ipv6PeeringConfigMicrosoftPeeringConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigMicrosoftPeeringConfig = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilter Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Ipv6PeeringConfigRouteFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilter = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilterEtag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Ipv6PeeringConfigRouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterEtag = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilterName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Ipv6PeeringConfigRouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterName = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilterPropertiesProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterPropertiesProvisioningState = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilterProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Ipv6PeeringConfigRouteFilterProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterProperty = value; }

        /// <summary>Internal Acessors for Ipv6PeeringConfigRouteFilterType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Ipv6PeeringConfigRouteFilterType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Ipv6PeeringConfigRouteFilterType = value; }

        /// <summary>Internal Acessors for MicrosoftPeeringConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringConfig Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.MicrosoftPeeringConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).MicrosoftPeeringConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).MicrosoftPeeringConfig = value; }

        /// <summary>Internal Acessors for PropertiesRouteFilterEtag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.PropertiesRouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Etag = value; }

        /// <summary>Internal Acessors for PropertiesRouteFilterName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.PropertiesRouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Name = value; }

        /// <summary>Internal Acessors for PropertiesRouteFilterProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.PropertiesRouteFilterProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Property = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPeeringPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RouteFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilter Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.RouteFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilter = value; }

        /// <summary>Internal Acessors for RouteFilterPropertiesProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.RouteFilterPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilterPropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilterPropertiesProvisioningState = value; }

        /// <summary>Internal Acessors for Stat</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitStats Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Stat { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Stat; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Stat = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Type = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>The peer ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? PeerAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).PeerAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).PeerAsn = value; }

        /// <summary>
        /// The PeeringType. Possible values are: 'AzurePublicPeering', 'AzurePrivatePeering', and 'MicrosoftPeering'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType? PeeringType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).PeeringType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).PeeringType = value; }

        /// <summary>The primary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PrimaryAzurePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).PrimaryAzurePort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).PrimaryAzurePort = value; }

        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PrimaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).PrimaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).PrimaryPeerAddressPrefix = value; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PropertiesRouteFilterEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Etag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PropertiesRouteFilterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Id = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PropertiesRouteFilterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormat _property;

        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPeeringPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] RouteFilterPropertiesPeering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilterPropertiesPeering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilterPropertiesPeering = value; }

        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteFilterPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilterPropertiesProvisioningState; }

        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[] RouteFilterPropertiesRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilterPropertiesRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RouteFilterPropertiesRule = value; }

        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RoutingRegistryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RoutingRegistryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).RoutingRegistryName = value; }

        /// <summary>The secondary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SecondaryAzurePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).SecondaryAzurePort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).SecondaryAzurePort = value; }

        /// <summary>The secondary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SecondaryPeerAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).SecondaryPeerAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).SecondaryPeerAddressPrefix = value; }

        /// <summary>The shared key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SharedKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).SharedKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).SharedKey = value; }

        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? StatPrimarybytesIn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).StatPrimarybytesIn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).StatPrimarybytesIn = value; }

        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? StatPrimarybytesOut { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).StatPrimarybytesOut; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).StatPrimarybytesOut = value; }

        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? StatSecondarybytesIn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).StatSecondarybytesIn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).StatSecondarybytesIn = value; }

        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? StatSecondarybytesOut { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).StatSecondarybytesOut; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).StatSecondarybytesOut = value; }

        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).State = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).Type; }

        /// <summary>The VLAN ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? VlanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).VlanId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormatInternal)Property).VlanId = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitPeering" /> instance.</summary>
        public ExpressRouteCircuitPeering()
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
    /// Peering in an ExpressRouteCircuit resource.
    public partial interface IExpressRouteCircuitPeering :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
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
        ReadOnly = false,
        Description = @"The Azure ASN.",
        SerializedName = @"azureASN",
        PossibleTypes = new [] { typeof(int) })]
        int? AzureAsn { get; set; }
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
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigRouteFilterEtag { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigRouteFilterId { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigRouteFilterLocation { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigRouteFilterName { get;  }
        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of references to express route circuit peerings.",
        SerializedName = @"peerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Ipv6PeeringConfigRouteFilterPropertiesPeering { get; set; }
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
        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of RouteFilterRules contained within a route filter.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[] Ipv6PeeringConfigRouteFilterPropertiesRule { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Ipv6PeeringConfigRouteFilterTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Ipv6PeeringConfigRouteFilterType { get;  }
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
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
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
        /// <summary>
        /// The PeeringType. Possible values are: 'AzurePublicPeering', 'AzurePrivatePeering', and 'MicrosoftPeering'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The PeeringType. Possible values are: 'AzurePublicPeering', 'AzurePrivatePeering', and 'MicrosoftPeering'.",
        SerializedName = @"peeringType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType? PeeringType { get; set; }
        /// <summary>The primary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary port.",
        SerializedName = @"primaryAzurePort",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryAzurePort { get; set; }
        /// <summary>The primary address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary address prefix.",
        SerializedName = @"primaryPeerAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryPeerAddressPrefix { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesRouteFilterEtag { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesRouteFilterId { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesRouteFilterName { get;  }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>A collection of references to express route circuit peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of references to express route circuit peerings.",
        SerializedName = @"peerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] RouteFilterPropertiesPeering { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string RouteFilterPropertiesProvisioningState { get;  }
        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of RouteFilterRules contained within a route filter.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[] RouteFilterPropertiesRule { get; set; }
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RoutingRegistryName of the configuration.",
        SerializedName = @"routingRegistryName",
        PossibleTypes = new [] { typeof(string) })]
        string RoutingRegistryName { get; set; }
        /// <summary>The secondary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secondary port.",
        SerializedName = @"secondaryAzurePort",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryAzurePort { get; set; }
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
        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesIn of the peering.",
        SerializedName = @"primarybytesIn",
        PossibleTypes = new [] { typeof(long) })]
        long? StatPrimarybytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesOut of the peering.",
        SerializedName = @"primarybytesOut",
        PossibleTypes = new [] { typeof(long) })]
        long? StatPrimarybytesOut { get; set; }
        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesIn of the peering.",
        SerializedName = @"secondarybytesIn",
        PossibleTypes = new [] { typeof(long) })]
        long? StatSecondarybytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesOut of the peering.",
        SerializedName = @"secondarybytesOut",
        PossibleTypes = new [] { typeof(long) })]
        long? StatSecondarybytesOut { get; set; }
        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state of peering. Possible values are: 'Disabled' and 'Enabled'",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? State { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Tag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>The VLAN ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The VLAN ID.",
        SerializedName = @"vlanId",
        PossibleTypes = new [] { typeof(int) })]
        int? VlanId { get; set; }

    }
    /// Peering in an ExpressRouteCircuit resource.
    internal partial interface IExpressRouteCircuitPeeringInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfig Ipv6PeeringConfig { get; set; }
        /// <summary>The Microsoft peering configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringConfig Ipv6PeeringConfigMicrosoftPeeringConfig { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilter Ipv6PeeringConfigRouteFilter { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Ipv6PeeringConfigRouteFilterEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string Ipv6PeeringConfigRouteFilterId { get; set; }
        /// <summary>Resource location.</summary>
        string Ipv6PeeringConfigRouteFilterLocation { get; set; }
        /// <summary>Resource name.</summary>
        string Ipv6PeeringConfigRouteFilterName { get; set; }
        /// <summary>A collection of references to express route circuit peerings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Ipv6PeeringConfigRouteFilterPropertiesPeering { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        string Ipv6PeeringConfigRouteFilterPropertiesProvisioningState { get; set; }
        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[] Ipv6PeeringConfigRouteFilterPropertiesRule { get; set; }
        /// <summary>Route Filter Resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterPropertiesFormat Ipv6PeeringConfigRouteFilterProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Ipv6PeeringConfigRouteFilterTag { get; set; }
        /// <summary>Resource type.</summary>
        string Ipv6PeeringConfigRouteFilterType { get; set; }
        /// <summary>The secondary address prefix.</summary>
        string Ipv6PeeringConfigSecondaryPeerAddressPrefix { get; set; }
        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? Ipv6PeeringConfigState { get; set; }
        /// <summary>Gets whether the provider or the customer last modified the peering.</summary>
        string LastModifiedBy { get; set; }
        /// <summary>The legacy mode of the peering.</summary>
        int? LegacyMode { get; set; }
        /// <summary>Resource location.</summary>
        string Location { get; set; }
        /// <summary>The Microsoft peering configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get; set; }
        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>The peer ASN.</summary>
        long? PeerAsn { get; set; }
        /// <summary>
        /// The PeeringType. Possible values are: 'AzurePublicPeering', 'AzurePrivatePeering', and 'MicrosoftPeering'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType? PeeringType { get; set; }
        /// <summary>The primary port.</summary>
        string PrimaryAzurePort { get; set; }
        /// <summary>The primary address prefix.</summary>
        string PrimaryPeerAddressPrefix { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string PropertiesRouteFilterEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string PropertiesRouteFilterId { get; set; }
        /// <summary>Resource name.</summary>
        string PropertiesRouteFilterName { get; set; }
        /// <summary>Route Filter Resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterPropertiesFormat PropertiesRouteFilterProperty { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringPropertiesFormat Property { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the RouteFilter resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilter RouteFilter { get; set; }
        /// <summary>A collection of references to express route circuit peerings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] RouteFilterPropertiesPeering { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        string RouteFilterPropertiesProvisioningState { get; set; }
        /// <summary>Collection of RouteFilterRules contained within a route filter.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[] RouteFilterPropertiesRule { get; set; }
        /// <summary>The RoutingRegistryName of the configuration.</summary>
        string RoutingRegistryName { get; set; }
        /// <summary>The secondary port.</summary>
        string SecondaryAzurePort { get; set; }
        /// <summary>The secondary address prefix.</summary>
        string SecondaryPeerAddressPrefix { get; set; }
        /// <summary>The shared key.</summary>
        string SharedKey { get; set; }
        /// <summary>Gets peering stats.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitStats Stat { get; set; }
        /// <summary>Gets BytesIn of the peering.</summary>
        long? StatPrimarybytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        long? StatPrimarybytesOut { get; set; }
        /// <summary>Gets BytesIn of the peering.</summary>
        long? StatSecondarybytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        long? StatSecondarybytesOut { get; set; }
        /// <summary>The state of peering. Possible values are: 'Disabled' and 'Enabled'</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState? State { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Tag { get; set; }
        /// <summary>Resource type.</summary>
        string Type { get; set; }
        /// <summary>The VLAN ID.</summary>
        int? VlanId { get; set; }

    }
}