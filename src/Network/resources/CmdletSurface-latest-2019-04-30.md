### AzApplicationGateway [Get, New, Remove, Set, Start, Stop] `IApplicationGateway, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
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
  - ApplicationGateway `IApplicationGateway`

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
  - Expand `String`
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
  - CustomRule `IWebApplicationFirewallCustomRule[]`
  - EnabledState `WebApplicationFirewallEnabledState`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Mode `WebApplicationFirewallMode`
  - Tag `Hashtable`
  - WafPolicy `IWebApplicationFirewallPolicy`

### AzApplicationSecurityGroup [Get, New, Remove, Set] `IApplicationSecurityGroup, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`
  - SecurityGroup `IApplicationSecurityGroup`

### AzBgpServiceCommunity [Get] `IBgpServiceCommunity`
  - SubscriptionId `String[]`

### AzDdosCustomPolicy [Get, New, Remove, Set] `IDdosCustomPolicy, Boolean`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - Format `IProtocolCustomSettingsFormat[]`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`
  - DdosCustomPolicy `IDdosCustomPolicy`

### AzDdosProtectionPlan [Get, New, Remove, Set] `IDdosProtectionPlan, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Location `String`
  - Tag `Hashtable`
  - DdosProtectionPlan `IDdosProtectionPlan`

### AzDefaultSecurityRule [Get] `ISecurityRule`
  - NsgName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzDnsNameAvailability [Test] `Boolean`
  - Location `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - DomainNameLabel `String`

### AzExpressRouteCircuit [Get, New, Remove, Set] `IExpressRouteCircuit, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - AllowClassicOperations `SwitchParameter`
  - Authorization `IExpressRouteCircuitAuthorization_Reference[]`
  - BandwidthInGbps `Single`
  - CircuitProvisioningState `String`
  - EnableGlobalReach `SwitchParameter`
  - ExpressRoutePortId `String`
  - GatewayManagerEtag `String`
  - Id `String`
  - Location `String`
  - Peering `IExpressRouteCircuitPeering_Reference[]`
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
  - ExpressRouteCircuit `IExpressRouteCircuit`

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
  - Id `String`
  - Key `String`
  - ProvisioningState `String`
  - ResourceName `String`
  - UseStatus `AuthorizationUseStatus`
  - Authorization `IExpressRouteCircuitAuthorization`

### AzExpressRouteCircuitConnection [Get, New, Remove, Set] `IExpressRouteCircuitConnection, Boolean`
  - CircuitName `String`
  - PeeringName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - AddressPrefix `String`
  - AuthorizationKey `String`
  - CircuitPeeringId `String`
  - Id `String`
  - PeerCircuitPeeringId `String`
  - ResourceName `String`
  - ExpressRouteCircuitConnection `IExpressRouteCircuitConnection`

### AzExpressRouteCircuitPeering [Get, New, Remove, Set] `IExpressRouteCircuitPeering, Boolean`
  - CircuitName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - AdvertisedCommunity `String[]`
  - AdvertisedPublicPrefix `String[]`
  - AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState`
  - AzureAsn `Int32`
  - Connection `IExpressRouteCircuitConnection_Reference[]`
  - CustomerAsn `Int32`
  - GatewayManagerEtag `String`
  - IPv6AdvertisedCommunity `String[]`
  - IPv6AdvertisedPublicPrefix `String[]`
  - IPv6AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState`
  - IPv6CustomerAsn `Int32`
  - IPv6LegacyMode `Int32`
  - IPv6PrimaryPeerAddressPrefix `String`
  - IPv6RouteFilter `IRouteFilter_Reference`
  - IPv6RoutingRegistryName `String`
  - IPv6SecondaryPeerAddressPrefix `String`
  - IPv6State `ExpressRouteCircuitPeeringState`
  - Id `String`
  - LastModifiedBy `String`
  - LegacyMode `Int32`
  - PeerAsn `Int64`
  - PeeringType `ExpressRoutePeeringType`
  - PrimaryAzurePort `String`
  - PrimaryBytesIn `Int64`
  - PrimaryBytesOut `Int64`
  - PrimaryPeerAddressPrefix `String`
  - ProvisioningState `String`
  - ResourceName `String`
  - RouteFilter `IRouteFilter_Reference`
  - RoutingRegistryName `String`
  - SecondaryAzurePort `String`
  - SecondaryBytesIn `Int64`
  - SecondaryBytesOut `Int64`
  - SecondaryPeerAddressPrefix `String`
  - SharedKey `String`
  - State `ExpressRoutePeeringState`
  - VlanId `Int32`
  - Peering `IExpressRouteCircuitPeering`

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
  - ResourceName `String`
  - AuthorizationKey `String`
  - ExpressRouteCircuitPeeringId `String`
  - Id `String`
  - RoutingWeight `Int32`
  - ExpressRouteConnection `IExpressRouteConnection`

### AzExpressRouteCrossConnection [Get, New, Set] `IExpressRouteCrossConnection`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - BandwidthInMbps `Int32`
  - ExpressRouteCircuitId `String`
  - Id `String`
  - Location `String`
  - Peering `IExpressRouteCrossConnectionPeering_Reference[]`
  - PeeringLocation `String`
  - ServiceProviderNote `String`
  - ServiceProviderProvisioningState `ServiceProviderProvisioningState`
  - Tag `Hashtable`
  - ExpressRouteCrossConnection `IExpressRouteCrossConnection`

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
  - IPv6RouteFilter `IRouteFilter_Reference`
  - IPv6RoutingRegistryName `String`
  - IPv6SecondaryPeerAddressPrefix `String`
  - IPv6State `ExpressRouteCircuitPeeringState`
  - Id `String`
  - LastModifiedBy `String`
  - LegacyMode `Int32`
  - PeerAsn `Int64`
  - PeeringType `ExpressRoutePeeringType`
  - PrimaryPeerAddressPrefix `String`
  - ResourceName `String`
  - RoutingRegistryName `String`
  - SecondaryPeerAddressPrefix `String`
  - SharedKey `String`
  - State `ExpressRoutePeeringState`
  - VlanId `Int32`
  - CrossConnectionPeering `IExpressRouteCrossConnectionPeering`

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
  - Id `String`
  - Location `String`
  - MaximumScaleUnit `Int32`
  - MinimumScaleUnit `Int32`
  - Tag `Hashtable`
  - VirtualHubId `String`
  - ExpressRouteGateway `IExpressRouteGateway`

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
  - BandwidthInGbps `Int32`
  - Encapsulation `ExpressRoutePortsEncapsulation`
  - Id `String`
  - Link `IExpressRouteLink[]`
  - Location `String`
  - PeeringLocation `String`
  - ResourceGuid `String`
  - Tag `Hashtable`
  - ExpressRoutePort `IExpressRoutePort`

### AzExpressRoutePortsLocation [Get] `IExpressRoutePortsLocation`
  - SubscriptionId `String[]`
  - LocationName `String`
  - InputObject `INetworkIdentity`

### AzExpressRouteRouteTable [Get] `IExpressRouteCircuitRoutesTable, IExpressRouteCircuitsRoutesTableListResult`
  - ResourceGroupName `String`
  - CircuitName `String`
  - SubscriptionId `String[]`
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
  - ApplicationRule `IAzureFirewallApplicationRuleCollection[]`
  - IPConfiguration `IAzureFirewallIPConfiguration[]`
  - Id `String`
  - Location `String`
  - NatRule `IAzureFirewallNatRuleCollection[]`
  - NetworkRule `IAzureFirewallNetworkRuleCollection[]`
  - Tag `Hashtable`
  - ThreatIntelligenceMode `AzureFirewallThreatIntelMode`
  - Firewall `IAzureFirewall`

### AzFirewallFqdnTag [Get] `IAzureFirewallFqdnTag`
  - SubscriptionId `String[]`

### AzInterfaceEndpoint [Get, New, Remove, Set] `IInterfaceEndpoint, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - EndpointServiceId `String`
  - Etag `String`
  - Fqdn `String`
  - Id `String`
  - Location `String`
  - Subnet `ISubnet_Reference`
  - Tag `Hashtable`
  - InterfaceEndpoint `IInterfaceEndpoint`

### AzLoadBalancer [Get, New, Remove, Set] `ILoadBalancer, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - BackendAddressPool `IBackendAddressPool[]`
  - Etag `String`
  - FrontendIPConfiguration `IFrontendIPConfiguration[]`
  - Id `String`
  - InboundNatPool `IInboundNatPool[]`
  - InboundNatRule `IInboundNatRule_Reference[]`
  - LoadBalancingRule `ILoadBalancingRule[]`
  - Location `String`
  - OutboundRule `IOutboundRule[]`
  - Probe `IProbe[]`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SkuName `LoadBalancerSkuName`
  - Tag `Hashtable`
  - LoadBalancer `ILoadBalancer`

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
  - Expand `String`
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup_Reference[]`
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
  - LoadBalancerInboundNatRule `IInboundNatRule_Reference[]`
  - Primary `SwitchParameter`
  - PrivateIPAddress `String`
  - PrivateIPAddressVersion `IPVersion`
  - PrivateIPAllocationMethod `IPAllocationMethod`
  - Protocol `TransportProtocol`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress_Reference`
  - ResourceName `String`
  - Subnet `ISubnet_Reference`
  - VnetTap `IVirtualNetworkTap_Reference[]`
  - InboundNatRule `IInboundNatRule`

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
  - LocalNetworkGateway `ILocalNetworkGateway`

### AzNatGateway [Get, New, Remove, Set] `INatGateway, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
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
  - NatGateway `INatGateway`

### AzNetworkInterface [Get, New, Remove, Set] `INetworkInterface, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - VMIndex `String`
  - VmssName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - AppliedDnsServer `String[]`
  - DnsServer `String[]`
  - EnableAcceleratedNetworking `SwitchParameter`
  - EnableIPForwarding `SwitchParameter`
  - Etag `String`
  - IPConfiguration `INetworkInterfaceIPConfiguration[]`
  - Id `String`
  - InternalDnsNameLabel `String`
  - InternalDomainNameSuffix `String`
  - InternalFqdn `String`
  - Location `String`
  - MacAddress `String`
  - Nsg `INetworkSecurityGroup_Reference`
  - Primary `SwitchParameter`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Tag `Hashtable`
  - TapConfiguration `INetworkInterfaceTapConfiguration_Reference[]`
  - VMId `String`
  - NetworkInterface `INetworkInterface`

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
  - Etag `String`
  - Id `String`
  - ResourceName `String`
  - VnetTap `IVirtualNetworkTap_Reference`
  - TapConfiguration `INetworkInterfaceTapConfiguration`

### AzNetworkProfile [Get, New, Remove, Set] `INetworkProfile, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - ContainerNetworkInterface `IContainerNetworkInterface[]`
  - ContainerNetworkInterfaceConfiguration `IContainerNetworkInterfaceConfiguration[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`
  - NetworkProfile `INetworkProfile`

### AzNetworkSecurityRule [Get, New, Remove, Set] `ISecurityRule, Boolean`
  - NsgName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - Access `SecurityRuleAccess`
  - AdditionalDestinationAddressPrefix `String[]`
  - AdditionalDestinationPortRange `String[]`
  - AdditionalSourceAddressPrefix `String[]`
  - AdditionalSourcePortRange `String[]`
  - Description `String`
  - DestinationAddressPrefix `String`
  - DestinationApplicationSecurityGroup `IApplicationSecurityGroup_Reference[]`
  - DestinationPortRange `String`
  - Direction `SecurityRuleDirection`
  - Etag `String`
  - Id `String`
  - Priority `Int32`
  - Protocol `SecurityRuleProtocol`
  - ProvisioningState `String`
  - ResourceName `String`
  - SourceAddressPrefix `String`
  - SourceApplicationSecurityGroup `IApplicationSecurityGroup_Reference[]`
  - SourcePortRange `String`
  - SecurityRule `ISecurityRule`

### AzNetworkUsage [Get] `IUsage`
  - Location `String`
  - SubscriptionId `String[]`

### AzNetworkWatcher [Get, New, Remove, Set] `INetworkWatcher, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`
  - NetworkWatcher `INetworkWatcher`

### AzNetworkWatcherAvailableProvider [Get] `IAvailableProvidersListCountry`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - City `String`
  - Country `String`
  - Location `String[]`
  - State `String`
  - AvailableProvider `IAvailableProvidersListParameters`

### AzNetworkWatcherConnectionMonitor [Get, New, Remove, Set, Start, Stop] `IConnectionMonitorResult, Boolean`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - SourceResourceId `String`
  - AutoStart `SwitchParameter`
  - DestinationAddress `String`
  - DestinationPort `Int32`
  - DestinationResourceId `String`
  - Location `String`
  - MonitoringIntervalInSeconds `Int32`
  - SourcePort `Int32`
  - Tag `Hashtable`
  - ConnectionMonitor `IConnectionMonitor`

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
  - SourceResourceId `String`
  - DestinationAddress `String`
  - DestinationPort `Int32`
  - DestinationResourceId `String`
  - HttpHeader `IHttpHeader[]`
  - HttpMethod `HttpMethod`
  - HttpValidStatusCode `Int32[]`
  - Protocol `Protocol`
  - SourcePort `Int32`
  - Connectivity `IConnectivityParameters`

### AzNetworkWatcherFlowLogInformation [Get, Set] `IFlowLogInformation`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - TargetResourceId `String`
  - FlowLogStatus `IFlowLogStatusParameters`
  - EnableFlowLog `SwitchParameter`
  - StorageAccountId `String`
  - EnableRetention `SwitchParameter`
  - EnableTrafficAnalytics `SwitchParameter`
  - FormatType `FlowLogFormatType`
  - FormatVersion `Int32`
  - RetentionInDays `Int32`
  - TrafficAnalyticsInterval `Int32`
  - WorkspaceGuid `String`
  - WorkspaceLocation `String`
  - WorkspaceResourceId `String`
  - FlowLogConfiguration `IFlowLogInformation`

### AzNetworkWatcherIPFlow [Test] `IVerificationIPFlowResult`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - Direction `Direction`
  - LocalIPAddress `String`
  - LocalPort `String`
  - Protocol `IPFlowProtocol`
  - RemoteIPAddress `String`
  - RemotePort `String`
  - TargetResourceId `String`
  - NetworkInterfaceResourceId `String`
  - IPFlow `IVerificationIPFlowParameters`

### AzNetworkWatcherNetworkConfigurationDiagnostic [Get] `INetworkConfigurationDiagnosticResult`
  - InputObject `INetworkIdentity`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - NetworkConfigurationDiagnostic `INetworkConfigurationDiagnosticParameters`
  - Profile `INetworkConfigurationDiagnosticProfile[]`
  - TargetResourceId `String`
  - VerbosityLevel `VerbosityLevel`

### AzNetworkWatcherNextHop [Get] `INextHopResult`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - DestinationIPAddress `String`
  - SourceIPAddress `String`
  - TargetVMResourceId `String`
  - TargetNetworkInterfaceResourceId `String`
  - NextHop `INextHopParameters`

### AzNetworkWatcherPacketCapture [Get, New, Remove, Stop] `IPacketCaptureResult, Boolean`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - TargetResourceId `String`
  - BytesToCapturePerPacket `Int32`
  - Filter `IPacketCaptureFilter[]`
  - StorageAccountId `String`
  - StorageFilePath `String`
  - StoragePathUri `String`
  - TimeLimitInSeconds `Int32`
  - TotalBytesPerSession `Int32`
  - PacketCapture `IPacketCapture`

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
  - EndTime `DateTime`
  - ProviderCountry `String`
  - StartTime `DateTime`
  - Location `String[]`
  - Provider `String[]`
  - ProviderCity `String`
  - ProviderState `String`
  - ReachabilityReport `IAzureReachabilityReportParameters`

### AzNetworkWatcherTopology [Get] `ITopology`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - TargetResourceGroupName `String`
  - TargetSubnetId `String`
  - TargetVnetId `String`
  - Topology `ITopologyParameters`

### AzNetworkWatcherTroubleshooting [Get, Start] `ITroubleshootingResult`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - TargetResourceId `String`
  - Troubleshooting `IQueryTroubleshootingParameters`
  - StorageId `String`
  - StoragePath `String`

### AzNetworkWatcherVMSecurityRule [Get] `ISecurityGroupNetworkInterface`
  - NetworkWatcherName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - TargetResourceId `String`
  - SecurityGroupView `ISecurityGroupViewParameters`

### AzNsg [Get, New, Remove, Set] `INetworkSecurityGroup, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - DefaultSecurityRule `ISecurityRule_Reference[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SecurityRule `ISecurityRule_Reference[]`
  - Tag `Hashtable`
  - Nsg `INetworkSecurityGroup`

### AzP2SVpnGateway [Get, New, Remove, Set] `IP2SVpnGateway, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Location `String`
  - CustomRouteAddressPrefix `String[]`
  - Id `String`
  - P2SVpnServerConfigurationId `String`
  - ScaleUnit `Int32`
  - Tag `Hashtable`
  - VirtualHubId `String`
  - VpnClientAddressPrefix `String[]`
  - VpnClientAllocatedIPAddress `String[]`
  - VpnClientConnectionCount `Int32`
  - P2SVpnGateway `IP2SVpnGateway`

### AzP2SVpnGatewayVpnProfile [New] `String`
  - GatewayName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - AuthenticationMethod `AuthenticationMethod`
  - VpnProfile `IP2SVpnProfileParameters`

### AzP2SVpnServerConfiguration [Get, New, Remove, Set] `IP2SVpnServerConfiguration, Boolean`
  - ResourceGroupName `String`
  - VirtualWanName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - Etag `String`
  - Id `String`
  - RadiusClientRootCertificate `IP2SVpnServerConfigRadiusClientRootCertificate[]`
  - RadiusServerAddress `String`
  - RadiusServerRootCertificate `IP2SVpnServerConfigRadiusServerRootCertificate[]`
  - RadiusServerSecret `String`
  - ResourceName `String`
  - ResourceName2 `String`
  - VpnClientIPsecPolicy `IIpsecPolicy[]`
  - VpnClientRevokedCertificate `IP2SVpnServerConfigVpnClientRevokedCertificate[]`
  - VpnClientRootCertificate `IP2SVpnServerConfigVpnClientRootCertificate[]`
  - VpnProtocol `VpnGatewayTunnelingProtocol[]`
  - P2SVpnServerConfiguration `IP2SVpnServerConfiguration`

### AzPeerExpressRouteCircuitConnection [Get] `IPeerExpressRouteCircuitConnection`
  - CircuitName `String`
  - PeeringName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
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
  - Expand `String`
  - Address `IPublicIPAddress_Reference`
  - AllocationMethod `IPAllocationMethod`
  - DdosCustomPolicyId `String`
  - DdosProtectionCoverage `DdosSettingsProtectionCoverage`
  - DomainNameLabel `String`
  - Etag `String`
  - Fqdn `String`
  - IPAddress `String`
  - IPAddressVersion `IPVersion`
  - IPConfigurationEtag `String`
  - IPConfigurationId `String`
  - IPConfigurationPropertiesProvisioningState `String`
  - IPTag `IIPTag[]`
  - Id `String`
  - IdleTimeoutInMinutes `Int32`
  - Location `String`
  - PrefixId `String`
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - ReverseFqdn `String`
  - SkuName `PublicIPAddressSkuName`
  - Subnet `ISubnet_Reference`
  - Tag `Hashtable`
  - Zone `String[]`
  - PublicIPAddress `IPublicIPAddress`

### AzPublicIPPrefix [Get, New, Remove, Set] `IPublicIPPrefix, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - Etag `String`
  - IPPrefix `String`
  - IPTag `IIPTag[]`
  - Id `String`
  - LoadBalancerFrontendIPConfigurationId `String`
  - Location `String`
  - PrefixLength `Int32`
  - ProvisioningState `String`
  - PublicIPAddress `IReferencedPublicIPAddress[]`
  - PublicIPAddressVersion `IPVersion`
  - ResourceGuid `String`
  - SkuName `PublicIPPrefixSkuName`
  - Tag `Hashtable`
  - Zone `String[]`
  - PublicIPPrefix `IPublicIPPrefix`

### AzResourceNavigationLink [Get] `IResourceNavigationLinksListResult`
  - ResourceGroupName `String`
  - SubnetName `String`
  - VnetName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzRouteFilter [Get, New, Remove, Set, Update] `IRouteFilter, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - Location `String`
  - Id `String`
  - Peering `IExpressRouteCircuitPeering_Reference[]`
  - Rule `IRouteFilterRule_Reference[]`
  - Tag `Hashtable`
  - RouteFilter `IRouteFilter`

### AzRouteFilterRule [Get, New, Remove, Set, Update] `IRouteFilterRule, Boolean`
  - ResourceGroupName `String`
  - RouteFilterName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - Access `Access`
  - Community `String[]`
  - Id `String`
  - Location `String`
  - ResourceName `String`
  - RouteFilterRule `IRouteFilterRule`

### AzRouteTable [Get, New, Remove, Set] `IRouteTable, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - DisableBgpRoutePropagation `SwitchParameter`
  - Etag `String`
  - Id `String`
  - Location `String`
  - ProvisioningState `String`
  - Route `IRoute_Reference[]`
  - Tag `Hashtable`
  - RouteTable `IRouteTable`

### AzRouteTableRoute [Get, New, Remove, Set] `IRoute, Boolean`
  - ResourceGroupName `String`
  - TableName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - AddressPrefix `String`
  - Etag `String`
  - Id `String`
  - NextHopIPAddress `String`
  - NextHopType `RouteNextHopType`
  - ProvisioningState `String`
  - ResourceName `String`
  - Route `IRoute`

### AzServiceAssociationLink [Get] `IServiceAssociationLinksListResult`
  - ResourceGroupName `String`
  - SubnetName `String`
  - VnetName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzServiceEndpointPolicy [Get, New, Remove, Set, Update] `IServiceEndpointPolicy, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - Definition `IServiceEndpointPolicyDefinition_Reference[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Tag `Hashtable`
  - ServiceEndpointPolicy `IServiceEndpointPolicy`

### AzServiceEndpointPolicyDefinition [Get, New, Remove, Set] `IServiceEndpointPolicyDefinition, Boolean`
  - ResourceGroupName `String`
  - ServiceEndpointPolicyName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - Description `String`
  - Etag `String`
  - Id `String`
  - ResourceName `String`
  - Service `String`
  - ServiceResource `String[]`
  - ServiceEndpointPolicyDefinition `IServiceEndpointPolicyDefinition`

### AzVirtualHub [Get, New, Remove, Set] `IVirtualHub, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Location `String`
  - AddressPrefix `String`
  - ExpressRouteGatewayId `String`
  - Id `String`
  - P2SVpnGatewayId `String`
  - Route `IVirtualHubRoute[]`
  - Tag `Hashtable`
  - VirtualWanId `String`
  - VnetConnection `IHubVirtualNetworkConnection[]`
  - VpnGatewayId `String`
  - VirtualHub `IVirtualHub`

### AzVirtualHubVnetConnection [Get] `IHubVirtualNetworkConnection`
  - ResourceGroupName `String`
  - VirtualHubName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`

### AzVirtualWan [Get, New, Remove, Set] `IVirtualWan, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Location `String`
  - AllowBranchToBranchTraffic `SwitchParameter`
  - AllowVnetToVnetTraffic `SwitchParameter`
  - DisableVpnEncryption `SwitchParameter`
  - Id `String`
  - P2SVpnServerConfiguration `IP2SVpnServerConfiguration_Reference[]`
  - SecurityProviderName `String`
  - Tag `Hashtable`
  - VirtualWan `IVirtualWan`

### AzVirtualWanSupportedSecurityProvider [Get] `IVirtualWanSecurityProvider`
  - ResourceGroupName `String`
  - VirtualWanName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzVnet [Get, New, Remove, Set] `IVirtualNetwork, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
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
  - Subnet `ISubnet_Reference[]`
  - Tag `Hashtable`
  - VnetPeering `IVirtualNetworkPeering_Reference[]`
  - Vnet `IVirtualNetwork`

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
  - AddressPrefix `String[]`
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
  - IPsecPolicy `IIpsecPolicy[]`
  - Id `String`
  - Location `String`
  - Protocol `VpnClientProtocol[]`
  - RadiusServerAddress `String`
  - RadiusServerSecret `String`
  - ResourceGuid `String`
  - RevokedCertificate `IVpnClientRevokedCertificate[]`
  - RootCertificate `IVpnClientRootCertificate[]`
  - SkuCapacity `Int32`
  - SkuName `VirtualNetworkGatewaySkuName`
  - SkuTier `VirtualNetworkGatewaySkuTier`
  - Tag `Hashtable`
  - VpnType `VpnType`
  - VnetGateway `IVirtualNetworkGateway`
  - GatewayVip `String`

### AzVnetGatewayAdvertisedRoute [Get] `IGatewayRoute`
  - ResourceGroupName `String`
  - VnetGatewayName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - Peer `String`

### AzVnetGatewayBgpPeerStatus [Get] `IBgpPeerStatus`
  - ResourceGroupName `String`
  - VnetGatewayName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - Peer `String`

### AzVnetGatewayConnection [Get, New, Remove, Set] `IVirtualNetworkGatewayConnection, IVirtualNetworkGatewayConnectionListEntity, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - VnetGatewayName `String`
  - InputObject `INetworkIdentity`
  - VnetGatewayConnection `IVirtualNetworkGatewayConnection`
  - ConnectionType `VirtualNetworkGatewayConnectionType`
  - VnetGateway1 `IVirtualNetworkGateway_Reference`
  - AuthorizationKey `String`
  - BypassExpressRouteGateway `SwitchParameter`
  - ConnectionProtocol `VirtualNetworkGatewayConnectionProtocol`
  - EnableBgp `SwitchParameter`
  - Etag `String`
  - IPsecPolicy `IIpsecPolicy[]`
  - Id `String`
  - LocalNetworkGateway2 `ILocalNetworkGateway_Reference`
  - Location `String`
  - PeerId `String`
  - ResourceGuid `String`
  - RoutingWeight `Int32`
  - SharedKey `String`
  - Tag `Hashtable`
  - UsePolicyBasedTrafficSelectors `SwitchParameter`
  - VnetGateway2 `IVirtualNetworkGateway_Reference`

### AzVnetGatewayConnectionSharedKey [Get, Reset, Set] `IConnectionSharedKey, Int32`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - KeyLength `Int32`
  - ConnectionSharedKey `IConnectionResetSharedKey`
  - Value `String`
  - Id `String`

### AzVnetGatewayLearnedRoute [Get] `IGatewayRoute`
  - ResourceGroupName `String`
  - VnetGatewayName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzVnetGatewaySupportedVpnDevice [Get] `String`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzVnetGatewayVpnClientIPsecPolicy [Get, Set] `IVpnClientIPsecParameters`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - VnetGatewayName `String`
  - DHGroup `DhGroup`
  - IPsecEncryption `IpsecEncryption`
  - IPsecIntegrity `IpsecIntegrity`
  - IkeEncryption `IkeEncryption`
  - IkeIntegrity `IkeIntegrity`
  - PfsGroup `PfsGroup`
  - SADataSizeInKilobytes `Int32`
  - SALifetimeInSeconds `Int32`
  - VpnClientIPsecPolicy `IVpnClientIPsecParameters`

### AzVnetGatewayVpnClientPackage [New] `String`
  - ResourceGroupName `String`
  - VnetGatewayName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - AuthenticationMethod `AuthenticationMethod`
  - ClientRootCertificate `String[]`
  - ProcessorArchitecture `ProcessorArchitecture`
  - RadiusServerAuthenticationCertificate `String`
  - VpnClientPackage `IVpnClientParameters`

### AzVnetGatewayVpnClientSharedKey [Reset] `Boolean`
  - ResourceGroupName `String`
  - VnetGatewayName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`

### AzVnetGatewayVpnDeviceConfigurationScript [Get] `String`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - DeviceFamily `String`
  - FirmwareVersion `String`
  - Vendor `String`
  - VpnDeviceConfigurationScript `IVpnDeviceScriptParameters`

### AzVnetGatewayVpnProfile [New] `String`
  - ResourceGroupName `String`
  - VnetGatewayName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - AuthenticationMethod `AuthenticationMethod`
  - ClientRootCertificate `String[]`
  - ProcessorArchitecture `ProcessorArchitecture`
  - RadiusServerAuthenticationCertificate `String`
  - VpnProfile `IVpnClientParameters`

### AzVnetGatewayVpnProfilePackageUrl [Get] `String`
  - ResourceGroupName `String`
  - VnetGatewayName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`

### AzVnetIPAddressAvailability [Test] `IIPAddressAvailabilityResult`
  - ResourceGroupName `String`
  - VnetName `String`
  - SubscriptionId `String`
  - InputObject `INetworkIdentity`
  - IPAddress `String`

### AzVnetPeering [Get, New, Remove, Set] `IVirtualNetworkPeering, Boolean`
  - ResourceGroupName `String`
  - VnetName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - AllowForwardedTraffic `SwitchParameter`
  - AllowGatewayTransit `SwitchParameter`
  - AllowVnetAccess `SwitchParameter`
  - Etag `String`
  - Id `String`
  - PeeringState `VirtualNetworkPeeringState`
  - ProvisioningState `String`
  - RemoteAddressPrefix `String[]`
  - RemoteVnetId `String`
  - ResourceName `String`
  - UseRemoteGateway `SwitchParameter`
  - VnetPeering `IVirtualNetworkPeering`

### AzVnetSubnet [Get, New, Remove, Set] `ISubnet, Boolean`
  - ResourceGroupName `String`
  - VnetName `String`
  - SubscriptionId `String[]`
  - Name `String`
  - InputObject `INetworkIdentity`
  - Expand `String`
  - AdditionalAddressPrefix `String[]`
  - AddressPrefix `String`
  - Delegation `IDelegation[]`
  - Etag `String`
  - Id `String`
  - NatGatewayId `String`
  - Nsg `INetworkSecurityGroup_Reference`
  - ProvisioningState `String`
  - ResourceName `String`
  - ResourceNavigationLink `IResourceNavigationLink[]`
  - RouteTable `IRouteTable_Reference`
  - ServiceAssociationLink `IServiceAssociationLink[]`
  - ServiceEndpoint `IServiceEndpointPropertiesFormat[]`
  - ServiceEndpointPolicy `IServiceEndpointPolicy_Reference[]`
  - Subnet `ISubnet`

### AzVnetSubnetNetworkPolicy [Set] `Boolean`
  - ResourceGroupName `String`
  - SubnetName `String`
  - VnetName `String`
  - SubscriptionId `String`
  - IntentPolicyResourceGroupName `String`
  - NetworkIntentPolicyConfiguration `INetworkIntentPolicyConfiguration[]`
  - ServiceName `String`
  - NetworkPolicyRequest `IPrepareNetworkPoliciesRequest`

### AzVnetTap [Get, New, Remove, Set] `IVirtualNetworkTap, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - AdditionalVnetTap `IVirtualNetworkTap_Reference[]`
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup_Reference[]`
  - DestinationLoadBalancerEtag `String`
  - DestinationLoadBalancerId `String`
  - DestinationLoadBalancerName `String`
  - DestinationLoadBalancerPrivateIPAddress `String`
  - DestinationLoadBalancerPrivateIPAllocationMethod `IPAllocationMethod`
  - DestinationLoadBalancerProvisioningState `String`
  - DestinationLoadBalancerPublicIPAddress `IPublicIPAddress_Reference`
  - DestinationLoadBalancerSubnet `ISubnet_Reference`
  - DestinationLoadBalancerZone `String[]`
  - DestinationNetworkInterfaceEtag `String`
  - DestinationNetworkInterfaceId `String`
  - DestinationNetworkInterfaceName `String`
  - DestinationNetworkInterfacePrivateIPAddress `String`
  - DestinationNetworkInterfacePrivateIPAllocationMethod `IPAllocationMethod`
  - DestinationNetworkInterfaceProvisioningState `String`
  - DestinationNetworkInterfacePublicIPAddress `IPublicIPAddress_Reference`
  - DestinationNetworkInterfaceSubnet `ISubnet_Reference`
  - DestinationPort `Int32`
  - Etag `String`
  - Id `String`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule_Reference[]`
  - Location `String`
  - Primary `SwitchParameter`
  - PrivateIPAddressVersion `IPVersion`
  - PublicIPPrefixId `String`
  - Tag `Hashtable`
  - VnetTap `IVirtualNetworkTap`

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
  - ConnectionBandwidth `Int32`
  - EnableBgp `SwitchParameter`
  - EnableInternetSecurity `SwitchParameter`
  - EnableRateLimiting `SwitchParameter`
  - IPsecPolicy `IIpsecPolicy[]`
  - Id `String`
  - ProtocolType `VirtualNetworkGatewayConnectionProtocol`
  - RemoteVpnSiteId `String`
  - ResourceName `String`
  - RoutingWeight `Int32`
  - SharedKey `String`
  - UseLocalAzureIPAddress `SwitchParameter`
  - VpnConnection `IVpnConnection`

### AzVpnGateway [Get, New, Remove, Set] `IVpnGateway, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Location `String`
  - BgpAsn `Int64`
  - BgpPeerWeight `Int32`
  - BgpPeeringAddress `String`
  - Connection `IVpnConnection_Reference[]`
  - Id `String`
  - ScaleUnit `Int32`
  - Tag `Hashtable`
  - VirtualHubId `String`
  - VpnGateway `IVpnGateway`

### AzVpnSite [Get, New, Remove, Set] `IVpnSite, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `INetworkIdentity`
  - Location `String`
  - AddressPrefix `String[]`
  - BgpAsn `Int64`
  - BgpPeerWeight `Int32`
  - BgpPeeringAddress `String`
  - DeviceModel `String`
  - DeviceVendor `String`
  - IPAddress `String`
  - Id `String`
  - LinkSpeedInMbps `Int32`
  - SecuritySite `SwitchParameter`
  - SiteKey `String`
  - Tag `Hashtable`
  - VirtualWanId `String`
  - VpnSite `IVpnSite`

### AzVpnSiteConfiguration [Get] `Boolean`
  - ResourceGroupName `String`
  - VirtualWanName `String`
  - SubscriptionId `String[]`
  - InputObject `INetworkIdentity`
  - OutputBlobSasUrl `String`
  - VpnSite `String[]`
  - Request `IGetVpnSitesConfigurationRequest`

