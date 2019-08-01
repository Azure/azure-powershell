### AzApplicationGateway [Get, New, Remove, Set, Start, Stop] `IApplicationGateway, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ApplicationGateway `IApplicationGateway`
  - AuthenticationCertificate `IApplicationGatewayAuthenticationCertificate[]`
  - AutoscaleMaximumCapacity `Int32`
  - AutoscaleMinimumCapacity `Int32`
  - BackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - BackendHttpSetting `IApplicationGatewayBackendHttpSettings[]`
  - CheckWafRequestBody `SwitchParameter`
  - CustomError `IApplicationGatewayCustomError[]`
  - EnableFips `SwitchParameter`
  - EnableHttp2 `SwitchParameter`
  - EnableWaf `SwitchParameter`
  - Etag `String`
  - FirewallPolicyId `String`
  - FrontendIPConfiguration `IApplicationGatewayFrontendIPConfiguration[]`
  - FrontendPort `IApplicationGatewayFrontendPort[]`
  - GatewayIPConfiguration `IApplicationGatewayIPConfiguration[]`
  - HttpListener `IApplicationGatewayHttpListener[]`
  - Id `String`
  - IdentityType `ResourceIdentityType`
  - Location `String`
  - Probe `IApplicationGatewayProbe[]`
  - ProvisioningState `String`
  - RedirectConfiguration `IApplicationGatewayRedirectConfiguration[]`
  - RequestRoutingRule `IApplicationGatewayRequestRoutingRule[]`
  - ResourceGuid `String`
  - RewriteRuleSet `IApplicationGatewayRewriteRuleSet[]`
  - SkuCapacity `Int32`
  - SkuName `ApplicationGatewaySkuName`
  - SkuTier `ApplicationGatewayTier`
  - SslCertificate `IApplicationGatewaySslCertificate[]`
  - SslCipherSuite `ApplicationGatewaySslCipherSuite[]`
  - SslDisabledProtocol `ApplicationGatewaySslProtocol[]`
  - SslMinimumProtocolVersion `ApplicationGatewaySslProtocol`
  - SslPolicyName `ApplicationGatewaySslPolicyName`
  - SslPolicyType `ApplicationGatewaySslPolicyType`
  - Tag `Hashtable`
  - TrustedRootCertificate `IApplicationGatewayTrustedRootCertificate[]`
  - UrlPathMap `IApplicationGatewayUrlPathMap[]`
  - UserAssignedIdentity `Hashtable`
  - WafDisabledRuleGroup `IApplicationGatewayFirewallDisabledRuleGroup[]`
  - WafExclusion `IApplicationGatewayFirewallExclusion[]`
  - WafFileUploadLimitInMb `Int32`
  - WafFirewallMode `ApplicationGatewayFirewallMode`
  - WafMaximumRequestBodySize `Int32`
  - WafMaximumRequestBodySizeInKb `Int32`
  - WafRuleSetType `String`
  - WafRuleSetVersion `String`
  - Zone `String[]`

### AzApplicationGatewayAvailableInfo [Get] `ApplicationGatewayAvailableInfo`
  - SubscriptionId `String[]`
  - IncludeRequestHeaders `SwitchParameter`
  - IncludeResponseHeaders `SwitchParameter`
  - IncludeServerVariables `SwitchParameter`

### AzApplicationGatewayAvailableSslOption [Get] `IApplicationGatewayAvailableSslOptions`
  - SubscriptionId `String[]`

### AzApplicationGatewayAvailableSslPredefinedPolicy [Get] `IApplicationGatewaySslPredefinedPolicy`
  - SubscriptionId `String[]`

### AzApplicationGatewayAvailableWafRuleSet [Get] `IApplicationGatewayFirewallRuleSet`
  - SubscriptionId `String[]`

### AzApplicationGatewayBackendHealth [Get] `IApplicationGatewayBackendHealthPool`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - AsOnDemand `SwitchParameter`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - BackendHttpSettingName `String`
  - BackendPoolName `String`
  - Host `String`
  - MatchBody `String`
  - MatchStatusCode `String[]`
  - Path `String`
  - PickHostNameFromBackendHttpSetting `SwitchParameter`
  - Protocol `ApplicationGatewayProtocol`
  - Timeout `Int32`

### AzApplicationGatewaySslPredefinedPolicy [Get] `IApplicationGatewaySslPredefinedPolicy`
  - Name `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzApplicationGatewayWafPolicy [Get, New, Remove, Set] `IWebApplicationFirewallPolicy, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - WafPolicy `IWebApplicationFirewallPolicy`
  - CustomRule `IWebApplicationFirewallCustomRule[]`
  - EnabledState `WebApplicationFirewallEnabledState`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Mode `WebApplicationFirewallMode`
  - Tag `Hashtable`

### AzApplicationSecurityGroup [Get, New, Remove, Set] `IApplicationSecurityGroup, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - SecurityGroup `IApplicationSecurityGroup`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`

### AzBgpServiceCommunity [Get] `IBgpServiceCommunity`
  - SubscriptionId `String[]`

### AzDdosCustomPolicy [Get, New, Remove, Set] `IDdosCustomPolicy, Boolean`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - DdosCustomPolicy `IDdosCustomPolicy`
  - Format `IProtocolCustomSettingsFormat[]`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`

### AzDdosProtectionPlan [Get, New, Remove, Set] `IDdosProtectionPlan, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - DdosProtectionPlan `IDdosProtectionPlan`
  - Location `String`
  - Tag `Hashtable`

### AzDefaultSecurityRule [Get] `ISecurityRule`
  - NsgName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzDnsNameAvailability [Test] `SwitchParameter`
  - Location `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - DomainNameLabel `String`

### AzDummy [Test] `IOperation`
  - Name `String`
  - ApplicationGatewayName `String`

### AzExpressRouteCircuit [Get, New, Remove, Set] `IExpressRouteCircuit, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpressRouteCircuit `IExpressRouteCircuit`
  - AllowClassicOperations `SwitchParameter`
  - Authorization `IExpressRouteCircuitAuthorization[]`
  - BandwidthInGbps `Single`
  - CircuitProvisioningState `String`
  - EnableGlobalReach `SwitchParameter`
  - ExpressRoutePortId `String`
  - GatewayManagerEtag `String`
  - Id `String`
  - Location `String`
  - Peering `IExpressRouteCircuitPeering[]`
  - ProvisioningState `String`
  - ServiceKey `String`
  - ServiceProviderBandwidthInMbps `Int32`
  - ServiceProviderName `String`
  - ServiceProviderNote `String`
  - ServiceProviderPeeringLocation `String`
  - ServiceProviderProvisioningState `ServiceProviderProvisioningState`
  - SkuFamily `ExpressRouteCircuitSkuFamily`
  - SkuName `String`
  - SkuTier `ExpressRouteCircuitSkuTier`
  - Tag `Hashtable`

### AzExpressRouteCircuitArpTable [Get] `IExpressRouteCircuitArpTable, IExpressRouteCircuitsArpTableListResult`
  - CircuitName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - DevicePath `String`
  - PeeringName `String`

### AzExpressRouteCircuitAuthorization [Get, New, Remove, Set] `IExpressRouteCircuitAuthorization, Boolean`
  - CircuitName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - Authorization `IExpressRouteCircuitAuthorization`
  - Id `String`
  - Key `String`
  - ProvisioningState `String`
  - ResourceName `String`
  - UseStatus `AuthorizationUseStatus`

### AzExpressRouteCircuitConnection [Get, New, Remove, Set] `IExpressRouteCircuitConnection, Boolean`
  - CircuitName `String`
  - PeeringName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - ExpressRouteCircuitConnection `IExpressRouteCircuitConnection`
  - AddressPrefix `String`
  - AuthorizationKey `String`
  - CircuitPeeringId `String`
  - Id `String`
  - PeerCircuitPeeringId `String`
  - ResourceName `String`

### AzExpressRouteCircuitPeering [Get, New, Remove, Set] `IExpressRouteCircuitPeering, Boolean`
  - CircuitName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - Peering `IExpressRouteCircuitPeering`
  - AdvertisedCommunity `String[]`
  - AdvertisedPublicPrefix `String[]`
  - AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState`
  - AzureAsn `Int32`
  - Connection `IExpressRouteCircuitConnection[]`
  - CustomerAsn `Int32`
  - GatewayManagerEtag `String`
  - IPv6AdvertisedCommunity `String[]`
  - IPv6AdvertisedPublicPrefix `String[]`
  - IPv6AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState`
  - IPv6CustomerAsn `Int32`
  - IPv6LegacyMode `Int32`
  - IPv6PrimaryPeerAddressPrefix `String`
  - IPv6RouteFilterId `String`
  - IPv6RouteFilterLocation `String`
  - IPv6RouteFilterPeering `IExpressRouteCircuitPeering[]`
  - IPv6RouteFilterRule `IRouteFilterRule[]`
  - IPv6RouteFilterTag `Hashtable`
  - IPv6RoutingRegistryName `String`
  - IPv6SecondaryPeerAddressPrefix `String`
  - IPv6State `ExpressRouteCircuitPeeringState`
  - Id `String`
  - LastModifiedBy `String`
  - LegacyMode `Int32`
  - Location `String`
  - PeerAsn `Int64`
  - PeeringType `ExpressRoutePeeringType`
  - PrimaryAzurePort `String`
  - PrimaryBytesIn `Int64`
  - PrimaryBytesOut `Int64`
  - PrimaryPeerAddressPrefix `String`
  - ProvisioningState `String`
  - ResourceName `String`
  - RouteFilterId `String`
  - RouteFilterPeering `IExpressRouteCircuitPeering[]`
  - RouteFilterRule `IRouteFilterRule[]`
  - RoutingRegistryName `String`
  - SecondaryAzurePort `String`
  - SecondaryBytesIn `Int64`
  - SecondaryBytesOut `Int64`
  - SecondaryPeerAddressPrefix `String`
  - SharedKey `String`
  - State `ExpressRoutePeeringState`
  - Tag `Hashtable`
  - VlanId `Int32`

### AzExpressRouteCircuitRouteTableSummary [Get] `IExpressRouteCircuitsRoutesTableSummaryListResult`
  - CircuitName `String`
  - DevicePath `String`
  - PeeringName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`

### AzExpressRouteCircuitStatistic [Get] `IExpressRouteCircuitStats`
  - CircuitName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - PeeringName `String`
  - InputObject `INetworkIdentity`

### AzExpressRouteConnection [Get, New, Remove, Set] `IExpressRouteConnection, Boolean`
  - ExpressRouteGatewayName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - ExpressRouteConnection `IExpressRouteConnection`
  - AuthorizationKey `String`
  - ExpressRouteCircuitPeeringId `String`
  - Id `String`
  - ResourceName `String`
  - RoutingWeight `Int32`

### AzExpressRouteCrossConnection [Get, New, Set] `IExpressRouteCrossConnection`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpressRouteCrossConnection `IExpressRouteCrossConnection`
  - BandwidthInMbps `Int32`
  - ExpressRouteCircuitId `String`
  - Id `String`
  - Location `String`
  - Peering `IExpressRouteCrossConnectionPeering[]`
  - PeeringLocation `String`
  - ServiceProviderNote `String`
  - ServiceProviderProvisioningState `ServiceProviderProvisioningState`
  - Tag `Hashtable`

### AzExpressRouteCrossConnectionArpTable [Get] `IExpressRouteCircuitsArpTableListResult`
  - CrossConnectionName `String`
  - DevicePath `String`
  - PeeringName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`

### AzExpressRouteCrossConnectionPeering [Get, New, Remove, Set] `IExpressRouteCrossConnectionPeering, Boolean`
  - CrossConnectionName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - CrossConnectionPeering `IExpressRouteCrossConnectionPeering`
  - AdvertisedCommunity `String[]`
  - AdvertisedPublicPrefix `String[]`
  - AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState`
  - CustomerAsn `Int32`
  - GatewayManagerEtag `String`
  - IPv6AdvertisedCommunity `String[]`
  - IPv6AdvertisedPublicPrefix `String[]`
  - IPv6AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState`
  - IPv6CustomerAsn `Int32`
  - IPv6LegacyMode `Int32`
  - IPv6PrimaryPeerAddressPrefix `String`
  - IPv6RoutingRegistryName `String`
  - IPv6SecondaryPeerAddressPrefix `String`
  - IPv6State `ExpressRouteCircuitPeeringState`
  - Id `String`
  - LastModifiedBy `String`
  - LegacyMode `Int32`
  - PeerAsn `Int64`
  - Peering `IExpressRouteCircuitPeering[]`
  - PeeringType `ExpressRoutePeeringType`
  - PrimaryPeerAddressPrefix `String`
  - ResourceName `String`
  - RouteFilterId `String`
  - RouteFilterLocation `String`
  - RouteFilterTag `Hashtable`
  - RoutingRegistryName `String`
  - Rule `IRouteFilterRule[]`
  - SecondaryPeerAddressPrefix `String`
  - SharedKey `String`
  - State `ExpressRoutePeeringState`
  - VlanId `Int32`

### AzExpressRouteCrossConnectionRouteTableSummary [Get] `IExpressRouteCrossConnectionsRoutesTableSummaryListResult`
  - CrossConnectionName `String`
  - DevicePath `String`
  - PeeringName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`

### AzExpressRouteGateway [Get, New, Remove, Set] `IExpressRouteGateway, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpressRouteGateway `IExpressRouteGateway`
  - Id `String`
  - Location `String`
  - MaximumScaleUnits `Int32`
  - MinimumScaleUnits `Int32`
  - Tag `Hashtable`
  - VirtualHubId `String`

### AzExpressRouteLink [Get] `IExpressRouteLink`
  - ExpressRoutePortName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - LinkName `String`
  - InputObject `INetworkIdentity`

### AzExpressRoutePort [Get, New, Remove, Set] `IExpressRoutePort, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpressRoutePort `IExpressRoutePort`
  - BandwidthInGbps `Int32`
  - Encapsulation `ExpressRoutePortsEncapsulation`
  - Id `String`
  - Link `IExpressRouteLink[]`
  - Location `String`
  - PeeringLocation `String`
  - ResourceGuid `String`
  - Tag `Hashtable`

### AzExpressRoutePortsLocation [Get] `IExpressRoutePortsLocation`
  - SubscriptionId `String[]`
  - LocationName `String`
  - InputObject `INetworkIdentity`

### AzExpressRouteRouteTable [Get] `IExpressRouteCircuitRoutesTable, IExpressRouteCircuitsRoutesTableListResult`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - CircuitName `String`
  - DevicePath `String`
  - PeeringName `String`
  - CrossConnectionName `String`

### AzExpressRouteServiceProvider [Get] `IExpressRouteServiceProvider`
  - SubscriptionId `String[]`

### AzFirewall [Get, New, Remove, Set] `IAzureFirewall, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Firewall `IAzureFirewall`
  - ApplicationRule `IAzureFirewallApplicationRuleCollection[]`
  - IPConfiguration `IAzureFirewallIPConfiguration[]`
  - Id `String`
  - Location `String`
  - NatRule `IAzureFirewallNatRuleCollection[]`
  - NetworkRule `IAzureFirewallNetworkRuleCollection[]`
  - Tag `Hashtable`
  - ThreatIntelligenceMode `AzureFirewallThreatIntelMode`

### AzFirewallFqdnTag [Get] `IAzureFirewallFqdnTag`
  - SubscriptionId `String[]`

### AzInterfaceEndpoint [Get, New, Remove, Set] `IInterfaceEndpoint, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - InterfaceEndpoint `IInterfaceEndpoint`
  - EndpointServiceId `String`
  - Etag `String`
  - Fqdn `String`
  - Id `String`
  - Location `String`
  - Subnet `ISubnet`
  - Tag `Hashtable`

### AzLoadBalancer [Get, New, Remove, Set] `ILoadBalancer, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - LoadBalancer `ILoadBalancer`
  - BackendAddressPool `IBackendAddressPool[]`
  - Etag `String`
  - FrontendIPConfiguration `IFrontendIPConfiguration[]`
  - Id `String`
  - InboundNatPool `IInboundNatPool[]`
  - InboundNatRule `IInboundNatRule[]`
  - LoadBalancingRule `ILoadBalancingRule[]`
  - Location `String`
  - OutboundRule `IOutboundRule[]`
  - Probe `IProbe[]`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SkuName `LoadBalancerSkuName`
  - Tag `Hashtable`

### AzLoadBalancerBackendAddressPool [Get] `IBackendAddressPool`
  - LoadBalancerName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzLoadBalancerFrontendIPConfiguration [Get] `IFrontendIPConfiguration`
  - LoadBalancerName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzLoadBalancerInboundNatRule [Get, New, Remove, Set] `IInboundNatRule, Boolean`
  - LoadBalancerName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - ResourceName `String`
  - Expand `String`
  - InboundNatRule `IInboundNatRule`
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - BackendIPConfigurationEtag `String`
  - BackendIPConfigurationId `String`
  - BackendIPConfigurationName `String`
  - BackendIPConfigurationProvisioningState `String`
  - BackendPort `Int32`
  - EnableFloatingIP `SwitchParameter`
  - EnableTcpReset `SwitchParameter`
  - Etag `String`
  - FrontendIPConfigurationId `String`
  - FrontendPort `Int32`
  - Id `String`
  - IdleTimeoutInMinutes `Int32`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - Primary `SwitchParameter`
  - PrivateIPAddress `String`
  - PrivateIPAddressVersion `IPVersion`
  - PrivateIPAllocationMethod `IPAllocationMethod`
  - Protocol `TransportProtocol`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - Subnet `ISubnet`
  - VnetTap `IVirtualNetworkTap[]`

### AzLoadBalancerLoadBalancingRule [Get] `ILoadBalancingRule`
  - LoadBalancerName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzLoadBalancerNetworkInterface [Get] `INetworkInterface`
  - LoadBalancerName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`

### AzLoadBalancerOutboundRule [Get] `IOutboundRule`
  - LoadBalancerName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzLoadBalancerProbe [Get] `IProbe`
  - LoadBalancerName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzLocalNetworkGateway [Get, New, Remove, Set] `ILocalNetworkGateway, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - LocalNetworkGateway `ILocalNetworkGateway`
  - AddressPrefix `String[]`
  - BgpAsn `Int64`
  - BgpPeerWeight `Int32`
  - BgpPeeringAddress `String`
  - Etag `String`
  - GatewayIPAddress `String`
  - Id `String`
  - Location `String`
  - ResourceGuid `String`
  - Tag `Hashtable`

### AzNatGateway [Get, New, Remove, Set] `INatGateway, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - NatGateway `INatGateway`
  - Etag `String`
  - Id `String`
  - IdleTimeoutInMinutes `Int32`
  - Location `String`
  - ProvisioningState `String`
  - PublicIPAddress `ISubResource[]`
  - PublicIPPrefix `ISubResource[]`
  - ResourceGuid `String`
  - SkuName `NatGatewaySkuName`
  - Tag `Hashtable`

### AzNetworkInterface [Get, New, Remove, Set] `INetworkInterface, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - VMIndex `String`
  - VmssName `String`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - NetworkInterface `INetworkInterface`
  - AppliedDnsServer `String[]`
  - DefaultSecurityRule `ISecurityRule[]`
  - DnsServer `String[]`
  - EnableAcceleratedNetworking `SwitchParameter`
  - EnableIPForwarding `SwitchParameter`
  - EndpointServiceId `String`
  - Etag `String`
  - Fqdn `String`
  - IPConfiguration `INetworkInterfaceIPConfiguration[]`
  - Id `String`
  - InterfaceEndpointEtag `String`
  - InterfaceEndpointId `String`
  - InterfaceEndpointLocation `String`
  - InterfaceEndpointTag `Hashtable`
  - InternalDnsNameLabel `String`
  - InternalDomainNameSuffix `String`
  - InternalFqdn `String`
  - Location `String`
  - MacAddress `String`
  - NsgEtag `String`
  - NsgId `String`
  - NsgLocation `String`
  - NsgProvisioningState `String`
  - NsgResourceGuid `String`
  - NsgTag `Hashtable`
  - Primary `SwitchParameter`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SecurityRule `ISecurityRule[]`
  - Subnet `ISubnet`
  - Tag `Hashtable`
  - TapConfiguration `INetworkInterfaceTapConfiguration[]`
  - VMId `String`
  - DnsAppliedDnsServer `String[]`
  - DnsDnsServer `String[]`
  - DnsInternalDnsNameLabel `String`
  - DnsInternalDomainNameSuffix `String`
  - DnsInternalFqdn `String`
  - NsgNsgProvisioningState `String`
  - NsgNsgResourceGuid `String`

### AzNetworkInterfaceEffectiveNsg [Get] `IEffectiveNetworkSecurityGroupListResult`
  - NetworkInterfaceName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`

### AzNetworkInterfaceEffectiveRouteTable [Get] `IEffectiveRouteListResult`
  - NetworkInterfaceName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzNetworkInterfaceIPConfiguration [Get] `INetworkInterfaceIPConfiguration`
  - NetworkInterfaceName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - VMIndex `String`
  - VmssName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`

### AzNetworkInterfaceLoadBalancer [Get] `ILoadBalancer`
  - NetworkInterfaceName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`

### AzNetworkInterfaceTapConfiguration [Get, New, Remove, Set] `INetworkInterfaceTapConfiguration, Boolean`
  - NetworkInterfaceName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - TapConfigurationName `String`
  - TapConfiguration `INetworkInterfaceTapConfiguration`
  - Etag `String`
  - Id `String`
  - VnetTap `IVirtualNetworkTap`

### AzNetworkProfile [Get, New, Remove, Set] `INetworkProfile, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - NetworkProfile `INetworkProfile`
  - ContainerNetworkInterface `IContainerNetworkInterface[]`
  - ContainerNetworkInterfaceConfiguration `IContainerNetworkInterfaceConfiguration[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`

### AzNetworkSecurityRule [Get, New, Remove, Set] `ISecurityRule, Boolean`
  - NsgName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - SecurityRuleName `String`
  - SecurityRule `ISecurityRule`
  - Access `SecurityRuleAccess`
  - Description `String`
  - DestinationAddressPrefix `String`
  - DestinationApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - DestinationPortRange `String`
  - Direction `SecurityRuleDirection`
  - Etag `String`
  - Id `String`
  - Priority `Int32`
  - PropertiesDestinationAddressPrefixes `String[]`
  - PropertiesDestinationPortRanges `String[]`
  - PropertiesSourceAddressPrefixes `String[]`
  - PropertiesSourcePortRanges `String[]`
  - Protocol `SecurityRuleProtocol`
  - ProvisioningState `String`
  - SourceAddressPrefix `String`
  - SourceApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - SourcePortRange `String`

### AzNetworkUsage [Get] `IUsage`
  - Location `String`
  - SubscriptionId `String[]`

### AzNetworkWatcher [Get, New, Remove, Set] `INetworkWatcher, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - NetworkWatcher `INetworkWatcher`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`

### AzNetworkWatcherAvailableProvider [Get] `IAvailableProvidersListCountry`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - AvailableProvider `IAvailableProvidersListParameters`
  - City `String`
  - Country `String`
  - Location `String[]`
  - State `String`

### AzNetworkWatcherConnectionMonitor [Get, New, Remove, Set, Start, Stop] `IConnectionMonitorResult, Boolean`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - ConnectionMonitor `IConnectionMonitor`
  - AutoStart `SwitchParameter`
  - DestinationAddress `String`
  - DestinationPort `Int32`
  - DestinationResourceId `String`
  - Location `String`
  - MonitoringIntervalInSeconds `Int32`
  - SourcePort `Int32`
  - SourceResourceId `String`
  - Tag `Hashtable`

### AzNetworkWatcherConnectionMonitorState [Get] `IConnectionMonitorQueryResult`
  - ConnectionMonitorName `String`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzNetworkWatcherConnectivity [Test] `IConnectivityInformation`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - Connectivity `IConnectivityParameters`
  - DestinationAddress `String`
  - DestinationPort `Int32`
  - DestinationResourceId `String`
  - HttpConfigurationHeader `IHttpHeader[]`
  - HttpConfigurationMethod `HttpMethod`
  - HttpConfigurationValidStatusCode `Int32[]`
  - Protocol `Protocol`
  - SourcePort `Int32`
  - SourceResourceId `String`

### AzNetworkWatcherFlowLogConfiguration [Set] `IFlowLogInformation`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - FlowLogConfiguration `IFlowLogInformation`
  - EnableFlowLog `SwitchParameter`
  - EnableRetention `SwitchParameter`
  - EnableTrafficAnalytics `SwitchParameter`
  - FormatType `FlowLogFormatType`
  - FormatVersion `Int32`
  - RetentionInDays `Int32`
  - StorageAccountId `String`
  - TargetResourceId `String`
  - TrafficAnalyticsInterval `Int32`
  - WorkspaceGuid `String`
  - WorkspaceLocation `String`
  - WorkspaceResourceId `String`

### AzNetworkWatcherFlowLogStatus [Get] `IFlowLogInformation`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - FlowLogStatus `IFlowLogStatusParameters`
  - TargetResourceId `String`

### AzNetworkWatcherIPFlow [Test] `IVerificationIPFlowResult`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - IPFlow `IVerificationIPFlowParameters`
  - Direction `Direction`
  - LocalIPAddress `String`
  - LocalPort `String`
  - NetworkInterfaceResourceId `String`
  - Protocol `IPFlowProtocol`
  - RemoteIPAddress `String`
  - RemotePort `String`
  - TargetResourceId `String`

### AzNetworkWatcherNetworkConfigurationDiagnostic [Get] `INetworkConfigurationDiagnosticResult`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - ConfigurationDiagnostic `INetworkConfigurationDiagnosticParameters`
  - Profile `INetworkConfigurationDiagnosticProfile[]`
  - TargetResourceId `String`
  - VerbosityLevel `VerbosityLevel`

### AzNetworkWatcherNextHop [Get] `INextHopResult`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - NextHop `INextHopParameters`
  - DestinationIPAddress `String`
  - SourceIPAddress `String`
  - TargetNicResourceId `String`
  - TargetVMResourceId `String`

### AzNetworkWatcherPacketCapture [Get, New, Remove, Stop] `IPacketCaptureResult, Boolean`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - PacketCapture `IPacketCapture`
  - BytesToCapturePerPacket `Int32`
  - Filter `IPacketCaptureFilter[]`
  - StorageAccountId `String`
  - StorageFilePath `String`
  - StoragePathUri `String`
  - TargetResourceId `String`
  - TimeLimitInSeconds `Int32`
  - TotalBytesPerSession `Int32`

### AzNetworkWatcherPacketCaptureStatus [Get] `IPacketCaptureQueryStatusResult`
  - Name `String`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzNetworkWatcherReachabilityReport [Get] `IAzureReachabilityReport`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - ReachabilityReport `IAzureReachabilityReportParameters`
  - EndTime `DateTime`
  - Location `String[]`
  - Provider `String[]`
  - ProviderCity `String`
  - ProviderCountry `String`
  - ProviderState `String`
  - StartTime `DateTime`

### AzNetworkWatcherTopology [Get] `ITopology`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - Topology `ITopologyParameters`
  - TargetResourceGroupName `String`
  - TargetSubnetId `String`
  - TargetVnetId `String`

### AzNetworkWatcherTroubleshooting [Start] `ITroubleshootingResult`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - Troubleshooting `ITroubleshootingParameters`
  - StorageId `String`
  - StoragePath `String`
  - TargetResourceId `String`

### AzNetworkWatcherTroubleshootingResult [Get] `ITroubleshootingResult`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - Troubleshooting `IQueryTroubleshootingParameters`
  - TargetResourceId `String`

### AzNetworkWatcherVMSecurityRule [Get] `ISecurityGroupNetworkInterface`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - SecurityGroupView `ISecurityGroupViewParameters`
  - TargetResourceId `String`

### AzNsg [Get, New, Remove, Set] `INetworkSecurityGroup, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - Nsg `INetworkSecurityGroup`
  - DefaultSecurityRule `ISecurityRule[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SecurityRule `ISecurityRule[]`
  - Tag `Hashtable`

### AzP2SVpnGateway [Get, New, Remove, Set] `IP2SVpnGateway, Boolean`
  - SubscriptionId `String[]`
  - GatewayName `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - P2SVpnGateway `IP2SVpnGateway`
  - CustomRouteAddressPrefix `String[]`
  - Id `String`
  - Location `String`
  - P2SVpnServerConfigurationId `String`
  - Tag `Hashtable`
  - VirtualHubId `String`
  - VpnClientAddressPoolAddressPrefix `String[]`
  - VpnClientConnectionHealthAllocatedIPAddress `String[]`
  - VpnClientConnectionHealthVpnClientConnectionsCount `Int32`
  - VpnGatewayScaleUnit `Int32`

### AzP2SVpnGatewayVpnProfile [New] `String`
  - GatewayName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - VpnProfile `IP2SVpnProfileParameters`
  - AuthenticationMethod `AuthenticationMethod`

### AzP2SVpnServerConfiguration [Get, New, Remove, Set] `IP2SVpnServerConfiguration, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VirtualWanName `String`
  - Name `String`
  - InputObject `INetworkIdentity`
  - P2SVpnServerConfigurationName `String`
  - P2SVpnServerConfiguration `IP2SVpnServerConfiguration`
  - Id `String`
  - P2SVpnServerConfigRadiusClientRootCertificate `IP2SVpnServerConfigRadiusClientRootCertificate[]`
  - P2SVpnServerConfigRadiusServerRootCertificate `IP2SVpnServerConfigRadiusServerRootCertificate[]`
  - P2SVpnServerConfigVpnClientRevokedCertificate `IP2SVpnServerConfigVpnClientRevokedCertificate[]`
  - P2SVpnServerConfigVpnClientRootCertificate `IP2SVpnServerConfigVpnClientRootCertificate[]`
  - PropertiesEtag `String`
  - PropertiesName `String`
  - RadiusServerAddress `String`
  - RadiusServerSecret `String`
  - VpnClientIPsecPolicy `IIpsecPolicy[]`
  - VpnProtocol `VpnGatewayTunnelingProtocol[]`

### AzPeerExpressRouteCircuitConnection [Get] `IPeerExpressRouteCircuitConnection`
  - CircuitName `String`
  - PeeringName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - ConnectionName `String`
  - InputObject `INetworkIdentity`

### AzPublicIPAddress [Get, New, Remove, Set] `IPublicIPAddress, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - IPConfigurationName `String`
  - NetworkInterfaceName `String`
  - VMIndex `String`
  - VmssName `String`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - PublicIPAddress `IPublicIPAddress`
  - AllocationMethod `IPAllocationMethod`
  - DdosCustomPolicyId `String`
  - DdosProtectionCoverage `DdosSettingsProtectionCoverage`
  - DomainNameLabel `String`
  - Etag `String`
  - Fqdn `String`
  - IPAddress `String`
  - IPConfigurationEtag `String`
  - IPConfigurationId `String`
  - IPConfigurationProperty `IIPConfigurationPropertiesFormat`
  - IPTag `IIPTag[]`
  - Id `String`
  - IdleTimeoutInMinutes `Int32`
  - IpAddressVersion `IPVersion`
  - Location `String`
  - PrefixId `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - ReverseFqdn `String`
  - SkuName `PublicIPAddressSkuName`
  - Tag `Hashtable`
  - Zone `String[]`
  - DdosSettingProtectionCoverage `DdosSettingsProtectionCoverage`
  - DnsSettingDomainNameLabel `String`
  - DnsSettingFqdn `String`
  - DnsSettingReverseFqdn `String`
  - PublicIPAddressVersion `IPVersion`
  - PublicIPAllocationMethod `IPAllocationMethod`
  - PublicIPPrefixId `String`

### AzPublicIPPrefix [Get, New, Remove, Set] `IPublicIPPrefix, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - PublicIPPrefix `IPublicIPPrefix`
  - Etag `String`
  - IPPrefix `String`
  - IPTag `IIPTag[]`
  - Id `String`
  - Location `String`
  - PrefixLength `Int32`
  - ProvisioningState `String`
  - PublicIPAddress `IReferencedPublicIPAddress[]`
  - PublicIPAddressVersion `IPVersion`
  - ResourceGuid `String`
  - SkuName `PublicIPPrefixSkuName`
  - Tag `Hashtable`
  - Zone `String[]`

### AzRouteFilter [Get, New, Remove, Set, Update] `IRouteFilter, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - RouteFilter `IRouteFilter`
  - Id `String`
  - Location `String`
  - Peering `IExpressRouteCircuitPeering[]`
  - Rule `IRouteFilterRule[]`
  - Tag `Hashtable`

### AzRouteFilterRule [Get, New, Remove, Set, Update] `IRouteFilterRule, Boolean`
  - ResourceGroupName `String`
  - RouteFilterName `String`
  - SubscriptionId `String[]`
  - RuleName `String`
  - InputObject `INetworkIdentity`
  - RouteFilterRule `IRouteFilterRule`
  - Access `Access`
  - Community `String[]`
  - Id `String`
  - Location `String`
  - Name `String`

### AzRouteTable [Get, New, Remove, Set] `IRouteTable, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - RouteTable `IRouteTable`
  - DisableBgpRoutePropagation `SwitchParameter`
  - Etag `String`
  - Id `String`
  - Location `String`
  - ProvisioningState `String`
  - Route `IRoute[]`
  - Tag `Hashtable`

### AzRouteTableRoute [Get, New, Remove, Set] `IRoute, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - TableName `String`
  - Name `String`
  - InputObject `INetworkIdentity`
  - RouteName `String`
  - Route `IRoute`
  - AddressPrefix `String`
  - Etag `String`
  - Id `String`
  - NextHopIPAddress `String`
  - NextHopType `RouteNextHopType`
  - ProvisioningState `String`

### AzServiceEndpointPolicy [Get, New, Remove, Set, Update] `IServiceEndpointPolicy, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - ServiceEndpointPolicy `IServiceEndpointPolicy`
  - Etag `String`
  - Id `String`
  - Location `String`
  - ServiceEndpointPolicyDefinition `IServiceEndpointPolicyDefinition[]`
  - Tag `Hashtable`

### AzServiceEndpointPolicyDefinition [Get, New, Remove, Set] `IServiceEndpointPolicyDefinition, Boolean`
  - ResourceGroupName `String`
  - ServiceEndpointPolicyName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - ServiceEndpointPolicyDefinitionName `String`
  - ServiceEndpointPolicyDefinition `IServiceEndpointPolicyDefinition`
  - Description `String`
  - Etag `String`
  - Id `String`
  - Service `String`
  - ServiceResource `String[]`

### AzVirtualHub [Get, New, Remove, Set] `IVirtualHub, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - VirtualHub `IVirtualHub`
  - AddressPrefix `String`
  - ExpressRouteGatewayId `String`
  - Id `String`
  - Location `String`
  - P2SVpnGatewayId `String`
  - Route `IVirtualHubRoute[]`
  - Tag `Hashtable`
  - VirtualWanId `String`
  - VnetConnection `IHubVirtualNetworkConnection[]`
  - VpnGatewayId `String`
  - RouteTableRoute `IVirtualHubRoute[]`

### AzVirtualHubVnetConnection [Get] `IHubVirtualNetworkConnection`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VirtualHubName `String`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzVirtualWan [Get, New, Remove, Set] `IVirtualWan, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - VirtualWan `IVirtualWan`
  - AllowBranchToBranchTraffic `SwitchParameter`
  - AllowVnetToVnetTraffic `SwitchParameter`
  - DisableVpnEncryption `SwitchParameter`
  - Id `String`
  - Location `String`
  - P2SVpnServerConfiguration `IP2SVpnServerConfiguration[]`
  - SecurityProviderName `String`
  - Tag `Hashtable`

### AzVirtualWanSupportedSecurityProvider [Get] `IVirtualWanSecurityProvider`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VirtualWanName `String`
  - InputObject `INetworkIdentity`

### AzVnet [Get, New, Remove, Set] `IVirtualNetwork, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - ExpandResource `String`
  - Vnet `IVirtualNetwork`
  - AddressPrefix `String[]`
  - DdosProtectionPlanId `String`
  - DnsServer `String[]`
  - EnableDdosProtection `SwitchParameter`
  - EnableVMProtection `SwitchParameter`
  - Etag `String`
  - Id `String`
  - Location `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Subnet `ISubnet[]`
  - Tag `Hashtable`
  - VnetPeering `IVirtualNetworkPeering[]`
  - AddressSpaceAddressPrefix `String[]`
  - DhcpOptionDnsServer `String[]`

### AzVnetAvailableEndpointService [Get] `IEndpointServiceResult`
  - Location `String`
  - SubscriptionId `String[]`

### AzVnetAvailableSubnetDelegation [Get] `IAvailableDelegation`
  - Location `String`
  - SubscriptionId `String[]`
  - ResourceGroupName `String`

### AzVnetGateway [Get, New, Remove, Reset, Set] `IVirtualNetworkGateway, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - GatewayVip `String`
  - VnetGateway `IVirtualNetworkGateway`
  - BgpAsn `Int64`
  - BgpPeerWeight `Int32`
  - BgpPeeringAddress `String`
  - CustomRouteAddressPrefix `String[]`
  - EnableActiveActive `SwitchParameter`
  - EnableBgp `SwitchParameter`
  - Etag `String`
  - GatewayDefaultSiteId `String`
  - GatewayType `VirtualNetworkGatewayType`
  - IPConfiguration `IVirtualNetworkGatewayIPConfiguration[]`
  - Id `String`
  - Location `String`
  - ResourceGuid `String`
  - SkuCapacity `Int32`
  - SkuName `VirtualNetworkGatewaySkuName`
  - SkuTier `VirtualNetworkGatewaySkuTier`
  - Tag `Hashtable`
  - VpnClientAddressPrefix `String[]`
  - VpnClientIPsecPolicy `IIpsecPolicy[]`
  - VpnClientProtocol `VpnClientProtocol[]`
  - VpnClientRadiusServerAddress `String`
  - VpnClientRadiusServerSecret `String`
  - VpnClientRevokedCertificate `IVpnClientRevokedCertificate[]`
  - VpnClientRootCertificate `IVpnClientRootCertificate[]`
  - VpnType `VpnType`

### AzVnetGatewayAdvertisedRoute [Get] `IGatewayRoute`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`
  - Peer `String`

### AzVnetGatewayBgpPeerStatus [Get] `IBgpPeerStatus`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`
  - Peer `String`

### AzVnetGatewayConnection [Get, New, Remove, Set] `IVirtualNetworkGatewayConnection, IVirtualNetworkGatewayConnectionListEntity, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`
  - VnetGatewayConnection `IVirtualNetworkGatewayConnection`
  - AuthorizationKey `String`
  - BgpSettingAsn `Int64`
  - BgpSettingBgpPeeringAddress `String`
  - BgpSettingPeerWeight `Int32`
  - ConnectionProtocol `VirtualNetworkGatewayConnectionProtocol`
  - ConnectionType `VirtualNetworkGatewayConnectionType`
  - EnableBgp `SwitchParameter`
  - Etag `String`
  - ExpressRouteGatewayBypass `SwitchParameter`
  - GatewayIPAddress `String`
  - IPsecPolicy `IIpsecPolicy[]`
  - Id `String`
  - LocalNetworkAddressPrefix `String[]`
  - LocalNetworkGateway2Etag `String`
  - LocalNetworkGateway2Id `String`
  - LocalNetworkGateway2Location `String`
  - LocalNetworkGateway2PropertiesResourceGuid `String`
  - LocalNetworkGateway2Tag `Hashtable`
  - Location `String`
  - PeerId `String`
  - ResourceGuid `String`
  - RoutingWeight `Int32`
  - SharedKey `String`
  - Tag `Hashtable`
  - UsePolicyBasedTrafficSelectors `SwitchParameter`
  - VnetGateway1 `IVirtualNetworkGateway`
  - VnetGateway2 `IVirtualNetworkGateway`

### AzVnetGatewayConnectionSharedKey [Get, Reset, Set] `IConnectionSharedKey, Int32`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - ConnectionSharedKey `IConnectionResetSharedKey`
  - KeyLength `Int32`
  - Id `String`
  - Value `String`

### AzVnetGatewayLearnedRoute [Get] `IGatewayRoute`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`

### AzVnetGatewaySupportedVpnDevice [Get] `String`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzVnetGatewayVpnClientIPsecPolicy [Get, Set] `IVpnClientIPsecParameters`
  - VnetGatewayName `String`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - VpnClientIPsecPolicy `IVpnClientIPsecParameters`
  - DhGroup `DhGroup`
  - IPsecEncryption `IpsecEncryption`
  - IPsecIntegrity `IpsecIntegrity`
  - IkeEncryption `IkeEncryption`
  - IkeIntegrity `IkeIntegrity`
  - PfsGroup `PfsGroup`
  - SaDataSizeKilobyte `Int32`
  - SaLifeTimeSecond `Int32`

### AzVnetGatewayVpnClientPackage [New] `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`
  - VpnClientPackage `IVpnClientParameters`
  - AuthenticationMethod `AuthenticationMethod`
  - ClientRootCertificate `String[]`
  - ProcessorArchitecture `ProcessorArchitecture`
  - RadiusServerAuthCertificate `String`

### AzVnetGatewayVpnClientSharedKey [Reset] `Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`

### AzVnetGatewayVpnDeviceConfigurationScript [Get] `String`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - VpnDeviceConfigurationScript `IVpnDeviceScriptParameters`
  - DeviceFamily `String`
  - FirmwareVersion `String`
  - Vendor `String`

### AzVnetGatewayVpnProfile [New] `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`
  - VpnProfile `IVpnClientParameters`
  - AuthenticationMethod `AuthenticationMethod`
  - ClientRootCertificate `String[]`
  - ProcessorArchitecture `ProcessorArchitecture`
  - RadiusServerAuthCertificate `String`

### AzVnetGatewayVpnProfilePackageUrl [Get] `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`

### AzVnetIPAddressAvailability [Test] `IIPAddressAvailabilityResult`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - VnetName `String`
  - InputObject `INetworkIdentity`
  - IPAddress `String`

### AzVnetPeering [Get, New, Remove, Set] `IVirtualNetworkPeering, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VnetName `String`
  - Name `String`
  - InputObject `INetworkIdentity`
  - VnetPeeringName `String`
  - VnetPeering `IVirtualNetworkPeering`
  - AllowForwardedTraffic `SwitchParameter`
  - AllowGatewayTransit `SwitchParameter`
  - AllowVnetAccess `SwitchParameter`
  - Etag `String`
  - Id `String`
  - PeeringState `VirtualNetworkPeeringState`
  - ProvisioningState `String`
  - RemoteAddressSpaceAddressPrefix `String[]`
  - RemoteVnetId `String`
  - UseRemoteGateway `SwitchParameter`

### AzVnetSubnet [Get, New, Remove, Set] `ISubnet, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VnetName `String`
  - Name `String`
  - InputObject `INetworkIdentity`
  - SubnetName `String`
  - Expand `String`
  - Subnet `ISubnet`
  - AddressPrefix `String`
  - DefaultSecurityRule `ISecurityRule[]`
  - Delegation `IDelegation[]`
  - DisableBgpRoutePropagation `SwitchParameter`
  - Etag `String`
  - Id `String`
  - NatGatewayId `String`
  - NsgEtag `String`
  - NsgId `String`
  - NsgLocation `String`
  - NsgPropertiesProvisioningState `String`
  - NsgTag `Hashtable`
  - PropertiesAddressPrefixes `String[]`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - ResourceNavigationLink `IResourceNavigationLink[]`
  - Route `IRoute[]`
  - RouteTableEtag `String`
  - RouteTableId `String`
  - RouteTableLocation `String`
  - RouteTablePropertiesProvisioningState `String`
  - RouteTableTag `Hashtable`
  - SecurityRule `ISecurityRule[]`
  - ServiceAssociationLink `IServiceAssociationLink[]`
  - ServiceEndpoint `IServiceEndpointPropertiesFormat[]`
  - ServiceEndpointPolicy `IServiceEndpointPolicy[]`

### AzVnetSubnetNetworkPolicy [Set] `Boolean`
  - ResourceGroupName `String`
  - SubnetName `String`
  - SubscriptionId `String`
  - VnetName `String`
  - NetworkPoliciesRequest `IPrepareNetworkPoliciesRequest`
  - NetworkIntentPolicyConfiguration `INetworkIntentPolicyConfiguration[]`
  - ResourceGroupName1 `String`
  - ServiceName `String`

### AzVnetTap [Get, New, Remove, Set] `IVirtualNetworkTap, Boolean`
  - TapName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - VnetTapProperties `IVirtualNetworkTap`
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - DestinationLoadBalancerFrontEndIPConfigurationEtag `String`
  - DestinationLoadBalancerFrontEndIPConfigurationId `String`
  - DestinationLoadBalancerFrontEndIPConfigurationName `String`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIPAddress `String`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIPAllocationMethod `IPAllocationMethod`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesProvisioningState `String`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesPublicIPAddress `IPublicIPAddress`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesSubnet `ISubnet`
  - DestinationLoadBalancerFrontEndIPConfigurationZone `String[]`
  - DestinationNetworkInterfaceIPConfigurationEtag `String`
  - DestinationNetworkInterfaceIPConfigurationId `String`
  - DestinationNetworkInterfaceIPConfigurationName `String`
  - DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIPAddress `String`
  - DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIPAllocationMethod `IPAllocationMethod`
  - DestinationNetworkInterfaceIPConfigurationPropertiesProvisioningState `String`
  - DestinationNetworkInterfaceIPConfigurationPropertiesPublicIPAddress `IPublicIPAddress`
  - DestinationNetworkInterfaceIPConfigurationPropertiesSubnet `ISubnet`
  - DestinationPort `Int32`
  - Etag `String`
  - Id `String`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - Location `String`
  - Primary `SwitchParameter`
  - PrivateIPAddressVersion `IPVersion`
  - PublicIPPrefixId `String`
  - Tag `Hashtable`
  - VnetTap `IVirtualNetworkTap[]`

### AzVnetUsage [Get] `IVirtualNetworkUsage`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`

### AzVpnConnection [Get, New, Remove, Set] `IVpnConnection, Boolean`
  - GatewayName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - ConnectionName `String`
  - VpnConnection `IVpnConnection`
  - ConnectionBandwidth `Int32`
  - EnableBgp `SwitchParameter`
  - EnableInternetSecurity `SwitchParameter`
  - EnableRateLimiting `SwitchParameter`
  - IPsecPolicy `IIpsecPolicy[]`
  - Id `String`
  - RemoteVpnSiteId `String`
  - RoutingWeight `Int32`
  - SharedKey `String`
  - UseLocalAzureIPAddress `SwitchParameter`
  - VpnConnectionProtocolType `VirtualNetworkGatewayConnectionProtocol`

### AzVpnGateway [Get, New, Remove, Set] `IVpnGateway, Boolean`
  - GatewayName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - VpnGateway `IVpnGateway`
  - BgpSettingAsn `Int64`
  - BgpSettingBgpPeeringAddress `String`
  - BgpSettingPeerWeight `Int32`
  - Connection `IVpnConnection[]`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`
  - VirtualHubId `String`
  - VpnGatewayScaleUnit `Int32`

### AzVpnSite [Get, New, Remove, Set] `IVpnSite, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - VpnSite `IVpnSite`
  - AddressPrefix `String[]`
  - BgpAsn `Int64`
  - BgpPeerWeight `Int32`
  - BgpPeeringAddress `String`
  - DeviceModel `String`
  - DeviceVendor `String`
  - IPAddress `String`
  - Id `String`
  - IsSecuritySite `SwitchParameter`
  - LinkSpeedInMbps `Int32`
  - Location `String`
  - SiteKey `String`
  - Tag `Hashtable`
  - VirtualWanId `String`
  - AddressSpaceAddressPrefix `String[]`
  - DevicePropertyDeviceModel `String`
  - DevicePropertyDeviceVendor `String`
  - DevicePropertyLinkSpeedInMbps `Int32`

### AzVpnSiteConfiguration [Get] `Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - VirtualWanName `String`
  - InputObject `INetworkIdentity`
  - Request `IGetVpnSitesConfigurationRequest`
  - OutputBlobSasUrl `String`
  - VpnSite `String[]`

