### AddressSpace [Api20171001]
  - AddressPrefix `String[]`

### ApplicationGateway [Api20171001, Api20190201]
  - AuthenticationCertificate `IApplicationGatewayAuthenticationCertificate[]`
  - AutoscaleMaximumCapacity `Int32?`
  - AutoscaleMinimumCapacity `Int32`
  - BackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - BackendHttpSetting `IApplicationGatewayBackendHttpSettings[]`
  - CheckWafRequestBody `Boolean?`
  - CustomError `IApplicationGatewayCustomError[]`
  - EnableFips `Boolean?`
  - EnableHttp2 `Boolean?`
  - EnableWaf `Boolean`
  - Etag `String`
  - FirewallPolicyId `String`
  - FrontendIPConfiguration `IApplicationGatewayFrontendIPConfiguration[]`
  - FrontendPort `IApplicationGatewayFrontendPort[]`
  - GatewayIPConfiguration `IApplicationGatewayIPConfiguration[]`
  - HttpListener `IApplicationGatewayHttpListener[]`
  - Id `String`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?`
  - Location `String`
  - Name `String`
  - OperationalState `ApplicationGatewayOperationalState?`
  - Probe `IApplicationGatewayProbe[]`
  - ProvisioningState `String`
  - RedirectConfiguration `IApplicationGatewayRedirectConfiguration[]`
  - RequestRoutingRule `IApplicationGatewayRequestRoutingRule[]`
  - ResourceGuid `String`
  - RewriteRuleSet `IApplicationGatewayRewriteRuleSet[]`
  - SkuCapacity `Int32?`
  - SkuName `ApplicationGatewaySkuName?`
  - SkuTier `ApplicationGatewayTier?`
  - SslCertificate `IApplicationGatewaySslCertificate[]`
  - SslCipherSuite `ApplicationGatewaySslCipherSuite[]`
  - SslDisabledProtocol `ApplicationGatewaySslProtocol[]`
  - SslMinimumProtocolVersion `ApplicationGatewaySslProtocol?`
  - SslPolicyName `ApplicationGatewaySslPolicyName?`
  - SslPolicyType `ApplicationGatewaySslPolicyType?`
  - Tag `IResourceTags`
  - TrustedRootCertificate `IApplicationGatewayTrustedRootCertificate[]`
  - Type `String`
  - UrlPathMap `IApplicationGatewayUrlPathMap[]`
  - UserAssignedIdentity `IManagedServiceIdentityUserAssignedIdentities`
  - WafDisabledRuleGroup `IApplicationGatewayFirewallDisabledRuleGroup[]`
  - WafExclusion `IApplicationGatewayFirewallExclusion[]`
  - WafFileUploadLimitInMb `Int32?`
  - WafFirewallMode `ApplicationGatewayFirewallMode`
  - WafMaximumRequestBodySize `Int32?`
  - WafMaximumRequestBodySizeInKb `Int32?`
  - WafRuleSetType `String`
  - WafRuleSetVersion `String`
  - Zone `String[]`

### ApplicationGatewayAuthenticationCertificate [Api20171001]
  - Data `String`
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Type `String`

### ApplicationGatewayAuthenticationCertificatePropertiesFormat [Api20171001]
  - Data `String`
  - ProvisioningState `String`

### ApplicationGatewayAutoscaleConfiguration [Api20190201]
  - MaxCapacity `Int32?`
  - MinCapacity `Int32`

### ApplicationGatewayAvailableInfo [Models]
  - AvailableRequestHeaders `String[]`
  - AvailableResponseHeaders `String[]`
  - AvailableServerVariables `String[]`

### ApplicationGatewayAvailableSslOptions [Api20171001]
  - AvailableCipherSuite `ApplicationGatewaySslCipherSuite[]`
  - AvailableProtocol `ApplicationGatewaySslProtocol[]`
  - DefaultPolicy `ApplicationGatewaySslPolicyName?`
  - Id `String`
  - Location `String`
  - Name `String`
  - PredefinedPolicy `ISubResource[]`
  - Tag `IResourceTags`
  - Type `String`

### ApplicationGatewayAvailableSslOptionsPropertiesFormat [Api20171001]
  - AvailableCipherSuite `ApplicationGatewaySslCipherSuite[]`
  - AvailableProtocol `ApplicationGatewaySslProtocol[]`
  - DefaultPolicy `ApplicationGatewaySslPolicyName?`
  - PredefinedPolicy `ISubResource[]`

### ApplicationGatewayAvailableSslPredefinedPolicies [Api20190201]
  - NextLink `String`
  - Value `IApplicationGatewaySslPredefinedPolicy[]`

### ApplicationGatewayAvailableWafRuleSetsResult [Api20190201]
  - Value `IApplicationGatewayFirewallRuleSet[]`

### ApplicationGatewayBackendAddress [Api20171001]
  - Fqdn `String`
  - IPAddress `String`

### ApplicationGatewayBackendAddressPool [Api20171001, Api20190201]
  - BackendAddress `IApplicationGatewayBackendAddress[]`
  - BackendIPConfiguration `INetworkInterfaceIPConfiguration[]`
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Type `String`

### ApplicationGatewayBackendAddressPoolPropertiesFormat [Api20171001, Api20190201]
  - BackendAddress `IApplicationGatewayBackendAddress[]`
  - BackendIPConfiguration `INetworkInterfaceIPConfiguration[]`
  - ProvisioningState `String`

### ApplicationGatewayBackendHealth [Api20190201]
  - BackendAddressPool `IApplicationGatewayBackendHealthPool[]`

### ApplicationGatewayBackendHealthHttpSettings [Api20190201]
  - AffinityCookieName `String`
  - AuthenticationCertificate `ISubResource[]`
  - BackendHttpSettingEtag `String`
  - BackendHttpSettingId `String`
  - BackendHttpSettingName `String`
  - BackendHttpSettingType `String`
  - ConnectionDrainingDrainTimeoutInSec `Int32`
  - ConnectionDrainingEnabled `Boolean`
  - CookieBasedAffinity `ApplicationGatewayCookieBasedAffinity?`
  - HostName `String`
  - Path `String`
  - PickHostNameFromBackendAddress `Boolean?`
  - Port `Int32?`
  - ProbeEnabled `Boolean?`
  - ProbeId `String`
  - Protocol `ApplicationGatewayProtocol?`
  - ProvisioningState `String`
  - RequestTimeout `Int32?`
  - Server `IApplicationGatewayBackendHealthServer[]`
  - TrustedRootCertificate `ISubResource[]`

### ApplicationGatewayBackendHealthOnDemand [Api20190201]
  - BackendAddress `IApplicationGatewayBackendAddress[]`
  - BackendAddressPoolEtag `String`
  - BackendAddressPoolId `String`
  - BackendAddressPoolName `String`
  - BackendAddressPoolType `String`
  - BackendHealthHttpSetting `IApplicationGatewayBackendHealthHttpSettings`
  - BackendIPConfiguration `INetworkInterfaceIPConfiguration[]`
  - ProvisioningState `String`

### ApplicationGatewayBackendHealthPool [Api20190201]
  - BackendAddress `IApplicationGatewayBackendAddress[]`
  - BackendAddressPoolEtag `String`
  - BackendAddressPoolId `String`
  - BackendAddressPoolName `String`
  - BackendAddressPoolType `String`
  - BackendHttpSettingsCollection `IApplicationGatewayBackendHealthHttpSettings[]`
  - BackendIPConfiguration `INetworkInterfaceIPConfiguration[]`
  - ProvisioningState `String`

### ApplicationGatewayBackendHealthServer [Api20190201]
  - Address `String`
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - Health `ApplicationGatewayBackendHealthServerHealth?`
  - HealthProbeLog `String`
  - IPConfigurationEtag `String`
  - IPConfigurationId `String`
  - IPConfigurationName `String`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - Primary `Boolean?`
  - PrivateIPAddress `String`
  - PrivateIPAddressVersion `IPVersion?`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - Subnet `ISubnet`
  - VnetTap `IVirtualNetworkTap[]`

### ApplicationGatewayBackendHttpSettings [Api20171001, Api20190201]
  - AffinityCookieName `String`
  - AuthenticationCertificate `ISubResource[]`
  - ConnectionDrainingDrainTimeoutInSec `Int32`
  - ConnectionDrainingEnabled `Boolean`
  - CookieBasedAffinity `ApplicationGatewayCookieBasedAffinity?`
  - Etag `String`
  - HostName `String`
  - Id `String`
  - Name `String`
  - Path `String`
  - PickHostNameFromBackendAddress `Boolean?`
  - Port `Int32?`
  - ProbeEnabled `Boolean?`
  - ProbeId `String`
  - Protocol `ApplicationGatewayProtocol?`
  - ProvisioningState `String`
  - RequestTimeout `Int32?`
  - TrustedRootCertificate `ISubResource[]`
  - Type `String`

### ApplicationGatewayBackendHttpSettingsPropertiesFormat [Api20171001, Api20190201]
  - AffinityCookieName `String`
  - AuthenticationCertificate `ISubResource[]`
  - ConnectionDraining `IApplicationGatewayConnectionDraining`
  - ConnectionDrainingDrainTimeoutInSec `Int32`
  - ConnectionDrainingEnabled `Boolean`
  - CookieBasedAffinity `ApplicationGatewayCookieBasedAffinity?`
  - HostName `String`
  - Path `String`
  - PickHostNameFromBackendAddress `Boolean?`
  - Port `Int32?`
  - Probe `ISubResource`
  - ProbeEnabled `Boolean?`
  - ProbeId `String`
  - Protocol `ApplicationGatewayProtocol?`
  - ProvisioningState `String`
  - RequestTimeout `Int32?`
  - TrustedRootCertificate `ISubResource[]`

### ApplicationGatewayConnectionDraining [Api20171001]
  - DrainTimeoutInSec `Int32`
  - Enabled `Boolean`

### ApplicationGatewayCustomError [Api20190201]
  - CustomErrorPageUrl `String`
  - StatusCode `ApplicationGatewayCustomErrorStatusCode?`

### ApplicationGatewayFirewallDisabledRuleGroup [Api20171001]
  - Rule `Int32[]`
  - RuleGroupName `String`

### ApplicationGatewayFirewallExclusion [Api20190201]
  - MatchVariable `String`
  - Selector `String`
  - SelectorMatchOperator `String`

### ApplicationGatewayFirewallRule [Api20171001]
  - Description `String`
  - RuleId `Int32`

### ApplicationGatewayFirewallRuleGroup [Api20171001]
  - Description `String`
  - Rule `IApplicationGatewayFirewallRule[]`
  - RuleGroupName `String`

### ApplicationGatewayFirewallRuleSet [Api20171001]
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - RuleGroup `IApplicationGatewayFirewallRuleGroup[]`
  - RuleSetType `String`
  - RuleSetVersion `String`
  - Tag `IResourceTags`
  - Type `String`

### ApplicationGatewayFirewallRuleSetPropertiesFormat [Api20171001]
  - ProvisioningState `String`
  - RuleGroup `IApplicationGatewayFirewallRuleGroup[]`
  - RuleSetType `String`
  - RuleSetVersion `String`

### ApplicationGatewayFrontendIPConfiguration [Api20171001]
  - Etag `String`
  - Id `String`
  - Name `String`
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddressId `String`
  - SubnetId `String`
  - Type `String`

### ApplicationGatewayFrontendIPConfigurationPropertiesFormat [Api20171001]
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddressId `String`
  - SubnetId `String`

### ApplicationGatewayFrontendPort [Api20171001]
  - Etag `String`
  - Id `String`
  - Name `String`
  - Port `Int32?`
  - ProvisioningState `String`
  - Type `String`

### ApplicationGatewayFrontendPortPropertiesFormat [Api20171001]
  - Port `Int32?`
  - ProvisioningState `String`

### ApplicationGatewayHeaderConfiguration [Api20190201]
  - HeaderName `String`
  - HeaderValue `String`

### ApplicationGatewayHttpListener [Api20171001, Api20190201]
  - CustomErrorConfiguration `IApplicationGatewayCustomError[]`
  - Etag `String`
  - FrontendIPConfigurationId `String`
  - FrontendPortId `String`
  - HostName `String`
  - Id `String`
  - Name `String`
  - Protocol `ApplicationGatewayProtocol?`
  - ProvisioningState `String`
  - RequireServerNameIndication `Boolean?`
  - SslCertificateId `String`
  - Type `String`

### ApplicationGatewayHttpListenerPropertiesFormat [Api20171001, Api20190201]
  - CustomErrorConfiguration `IApplicationGatewayCustomError[]`
  - FrontendIPConfiguration `ISubResource`
  - FrontendIPConfigurationId `String`
  - FrontendPort `ISubResource`
  - FrontendPortId `String`
  - HostName `String`
  - Protocol `ApplicationGatewayProtocol?`
  - ProvisioningState `String`
  - RequireServerNameIndication `Boolean?`
  - SslCertificate `ISubResource`
  - SslCertificateId `String`

### ApplicationGatewayIPConfiguration [Api20171001]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - SubnetId `String`
  - Type `String`

### ApplicationGatewayIPConfigurationPropertiesFormat [Api20171001]
  - ProvisioningState `String`
  - SubnetId `String`

### ApplicationGatewayListResult [Api20190201]
  - NextLink `String`
  - Value `IApplicationGateway[]`

### ApplicationGatewayOnDemandProbe [Api20190201]
  - BackendHttpSettingName `String`
  - BackendPoolName `String`
  - Host `String`
  - MatchBody `String`
  - MatchStatusCode `String[]`
  - Path `String`
  - PickHostNameFromBackendHttpSetting `Boolean?`
  - Protocol `ApplicationGatewayProtocol?`
  - Timeout `Int32?`

### ApplicationGatewayPathRule [Api20171001, Api20190201]
  - BackendAddressPoolId `String`
  - BackendHttpSettingId `String`
  - Etag `String`
  - Id `String`
  - Name `String`
  - Path `String[]`
  - ProvisioningState `String`
  - RedirectConfigurationId `String`
  - RewriteRuleSetId `String`
  - Type `String`

### ApplicationGatewayPathRulePropertiesFormat [Api20171001, Api20190201]
  - BackendAddressPool `ISubResource`
  - BackendAddressPoolId `String`
  - BackendHttpSetting `ISubResource`
  - BackendHttpSettingId `String`
  - Path `String[]`
  - ProvisioningState `String`
  - RedirectConfiguration `ISubResource`
  - RedirectConfigurationId `String`
  - RewriteRuleSetId `String`

### ApplicationGatewayProbe [Api20171001]
  - Etag `String`
  - Host `String`
  - Id `String`
  - Interval `Int32?`
  - MatchBody `String`
  - MatchStatusCode `String[]`
  - MinServer `Int32?`
  - Name `String`
  - Path `String`
  - PickHostNameFromBackendHttpSetting `Boolean?`
  - Protocol `ApplicationGatewayProtocol?`
  - ProvisioningState `String`
  - Timeout `Int32?`
  - Type `String`
  - UnhealthyThreshold `Int32?`

### ApplicationGatewayProbeHealthResponseMatch [Api20171001]
  - Body `String`
  - StatusCode `String[]`

### ApplicationGatewayProbePropertiesFormat [Api20171001]
  - Host `String`
  - Interval `Int32?`
  - MatchBody `String`
  - MatchStatusCode `String[]`
  - MinServer `Int32?`
  - Path `String`
  - PickHostNameFromBackendHttpSetting `Boolean?`
  - Protocol `ApplicationGatewayProtocol?`
  - ProvisioningState `String`
  - Timeout `Int32?`
  - UnhealthyThreshold `Int32?`

### ApplicationGatewayPropertiesFormat [Api20171001, Api20190201]
  - AuthenticationCertificate `IApplicationGatewayAuthenticationCertificate[]`
  - AutoscaleConfigurationMaxCapacity `Int32?`
  - AutoscaleConfigurationMinCapacity `Int32`
  - BackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - BackendHttpSettingsCollection `IApplicationGatewayBackendHttpSettings[]`
  - CustomErrorConfiguration `IApplicationGatewayCustomError[]`
  - EnableFips `Boolean?`
  - EnableHttp2 `Boolean?`
  - FirewallPolicyId `String`
  - FrontendIPConfiguration `IApplicationGatewayFrontendIPConfiguration[]`
  - FrontendPort `IApplicationGatewayFrontendPort[]`
  - GatewayIPConfiguration `IApplicationGatewayIPConfiguration[]`
  - HttpListener `IApplicationGatewayHttpListener[]`
  - OperationalState `ApplicationGatewayOperationalState?`
  - Probe `IApplicationGatewayProbe[]`
  - ProvisioningState `String`
  - RedirectConfiguration `IApplicationGatewayRedirectConfiguration[]`
  - RequestRoutingRule `IApplicationGatewayRequestRoutingRule[]`
  - ResourceGuid `String`
  - RewriteRuleSet `IApplicationGatewayRewriteRuleSet[]`
  - SkuCapacity `Int32?`
  - SkuName `ApplicationGatewaySkuName?`
  - SkuTier `ApplicationGatewayTier?`
  - SslCertificate `IApplicationGatewaySslCertificate[]`
  - SslPolicyCipherSuite `ApplicationGatewaySslCipherSuite[]`
  - SslPolicyDisabledSslProtocol `ApplicationGatewaySslProtocol[]`
  - SslPolicyMinProtocolVersion `ApplicationGatewaySslProtocol?`
  - SslPolicyName `ApplicationGatewaySslPolicyName?`
  - SslPolicyType `ApplicationGatewaySslPolicyType?`
  - TrustedRootCertificate `IApplicationGatewayTrustedRootCertificate[]`
  - UrlPathMap `IApplicationGatewayUrlPathMap[]`
  - WafConfigurationDisabledRuleGroup `IApplicationGatewayFirewallDisabledRuleGroup[]`
  - WafConfigurationEnabled `Boolean`
  - WafConfigurationExclusion `IApplicationGatewayFirewallExclusion[]`
  - WafConfigurationFileUploadLimitInMb `Int32?`
  - WafConfigurationFirewallMode `ApplicationGatewayFirewallMode`
  - WafConfigurationMaxRequestBodySize `Int32?`
  - WafConfigurationMaxRequestBodySizeInKb `Int32?`
  - WafConfigurationRequestBodyCheck `Boolean?`
  - WafConfigurationRuleSetType `String`
  - WafConfigurationRuleSetVersion `String`

### ApplicationGatewayRedirectConfiguration [Api20171001, Api20190201]
  - Etag `String`
  - Id `String`
  - IncludePath `Boolean?`
  - IncludeQueryString `Boolean?`
  - Name `String`
  - PathRule `ISubResource[]`
  - RedirectType `ApplicationGatewayRedirectType?`
  - RequestRoutingRule `ISubResource[]`
  - TargetListenerId `String`
  - TargetUrl `String`
  - Type `String`
  - UrlPathMap `ISubResource[]`

### ApplicationGatewayRedirectConfigurationPropertiesFormat [Api20171001, Api20190201]
  - IncludePath `Boolean?`
  - IncludeQueryString `Boolean?`
  - PathRule `ISubResource[]`
  - RedirectType `ApplicationGatewayRedirectType?`
  - RequestRoutingRule `ISubResource[]`
  - TargetListenerId `String`
  - TargetUrl `String`
  - UrlPathMap `ISubResource[]`

### ApplicationGatewayRequestRoutingRule [Api20171001, Api20190201]
  - BackendAddressPoolId `String`
  - BackendHttpSettingId `String`
  - Etag `String`
  - HttpListenerId `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - RedirectConfigurationId `String`
  - RewriteRuleSetId `String`
  - RuleType `ApplicationGatewayRequestRoutingRuleType?`
  - Type `String`
  - UrlPathMapId `String`

### ApplicationGatewayRequestRoutingRulePropertiesFormat [Api20171001, Api20190201]
  - BackendAddressPool `ISubResource`
  - BackendAddressPoolId `String`
  - BackendHttpSetting `ISubResource`
  - BackendHttpSettingId `String`
  - HttpListener `ISubResource`
  - HttpListenerId `String`
  - ProvisioningState `String`
  - RedirectConfiguration `ISubResource`
  - RedirectConfigurationId `String`
  - RewriteRuleSetId `String`
  - RuleType `ApplicationGatewayRequestRoutingRuleType?`
  - UrlPathMap `ISubResource`
  - UrlPathMapId `String`

### ApplicationGatewayRewriteRule [Api20190201]
  - ActionSetRequestHeaderConfiguration `IApplicationGatewayHeaderConfiguration[]`
  - ActionSetResponseHeaderConfiguration `IApplicationGatewayHeaderConfiguration[]`
  - Condition `IApplicationGatewayRewriteRuleCondition[]`
  - Name `String`
  - RuleSequence `Int32?`

### ApplicationGatewayRewriteRuleActionSet [Api20190201]
  - RequestHeaderConfiguration `IApplicationGatewayHeaderConfiguration[]`
  - ResponseHeaderConfiguration `IApplicationGatewayHeaderConfiguration[]`

### ApplicationGatewayRewriteRuleCondition [Api20190201]
  - IgnoreCase `Boolean?`
  - Negate `Boolean?`
  - Pattern `String`
  - Variable `String`

### ApplicationGatewayRewriteRuleSet [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - RewriteRule `IApplicationGatewayRewriteRule[]`

### ApplicationGatewayRewriteRuleSetPropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - RewriteRule `IApplicationGatewayRewriteRule[]`

### ApplicationGatewaySku [Api20171001, Api20190201]
  - Capacity `Int32?`
  - Name `ApplicationGatewaySkuName?`
  - Tier `ApplicationGatewayTier?`

### ApplicationGatewaySslCertificate [Api20171001, Api20190201]
  - Data `String`
  - Etag `String`
  - Id `String`
  - KeyVaultSecretId `String`
  - Name `String`
  - Password `String`
  - ProvisioningState `String`
  - PublicCertData `String`
  - Type `String`

### ApplicationGatewaySslCertificatePropertiesFormat [Api20171001, Api20190201]
  - Data `String`
  - KeyVaultSecretId `String`
  - Password `String`
  - ProvisioningState `String`
  - PublicCertData `String`

### ApplicationGatewaySslPolicy [Api20171001, Api20190201]
  - CipherSuite `ApplicationGatewaySslCipherSuite[]`
  - DisabledSslProtocol `ApplicationGatewaySslProtocol[]`
  - MinProtocolVersion `ApplicationGatewaySslProtocol?`
  - PolicyName `ApplicationGatewaySslPolicyName?`
  - PolicyType `ApplicationGatewaySslPolicyType?`

### ApplicationGatewaySslPredefinedPolicy [Api20171001]
  - CipherSuite `ApplicationGatewaySslCipherSuite[]`
  - Id `String`
  - MinProtocolVersion `ApplicationGatewaySslProtocol?`
  - Name `String`

### ApplicationGatewaySslPredefinedPolicyPropertiesFormat [Api20171001]
  - CipherSuite `ApplicationGatewaySslCipherSuite[]`
  - MinProtocolVersion `ApplicationGatewaySslProtocol?`

### ApplicationGatewayTrustedRootCertificate [Api20190201]
  - Data `String`
  - Etag `String`
  - Id `String`
  - KeyVaultSecretId `String`
  - Name `String`
  - ProvisioningState `String`
  - Type `String`

### ApplicationGatewayTrustedRootCertificatePropertiesFormat [Api20190201]
  - Data `String`
  - KeyVaultSecretId `String`
  - ProvisioningState `String`

### ApplicationGatewayUrlPathMap [Api20171001, Api20190201]
  - DefaultBackendAddressPoolId `String`
  - DefaultBackendHttpSettingId `String`
  - DefaultRedirectConfigurationId `String`
  - DefaultRewriteRuleSetId `String`
  - Etag `String`
  - Id `String`
  - Name `String`
  - PathRule `IApplicationGatewayPathRule[]`
  - ProvisioningState `String`
  - Type `String`

### ApplicationGatewayUrlPathMapPropertiesFormat [Api20171001, Api20190201]
  - DefaultBackendAddressPoolId `String`
  - DefaultBackendHttpSettingId `String`
  - DefaultRedirectConfigurationId `String`
  - DefaultRewriteRuleSetId `String`
  - PathRule `IApplicationGatewayPathRule[]`
  - ProvisioningState `String`

### ApplicationGatewayWebApplicationFirewallConfiguration [Api20171001, Api20190201]
  - DisabledRuleGroup `IApplicationGatewayFirewallDisabledRuleGroup[]`
  - Enabled `Boolean`
  - Exclusion `IApplicationGatewayFirewallExclusion[]`
  - FileUploadLimitInMb `Int32?`
  - FirewallMode `ApplicationGatewayFirewallMode`
  - MaxRequestBodySize `Int32?`
  - MaxRequestBodySizeInKb `Int32?`
  - RequestBodyCheck `Boolean?`
  - RuleSetType `String`
  - RuleSetVersion `String`

### ApplicationSecurityGroup [Api20171001]
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Tag `IResourceTags`
  - Type `String`

### ApplicationSecurityGroupListResult [Api20190201]
  - NextLink `String`
  - Value `IApplicationSecurityGroup[]`

### ApplicationSecurityGroupPropertiesFormat [Api20171001]
  - ProvisioningState `String`
  - ResourceGuid `String`

### AuthorizationListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCircuitAuthorization[]`

### AuthorizationPropertiesFormat [Api20171001]
  - AuthorizationKey `String`
  - AuthorizationUseStatus `AuthorizationUseStatus?`
  - ProvisioningState `String`

### Availability [Api20171001]
  - BlobDuration `String`
  - Retention `String`
  - TimeGrain `String`

### AvailableDelegation [Api20190201]
  - Action `String[]`
  - Id `String`
  - Name `String`
  - ServiceName `String`
  - Type `String`

### AvailableDelegationsResult [Api20190201]
  - NextLink `String`
  - Value `IAvailableDelegation[]`

### AvailableProvidersList [Api20190201]
  - Country `IAvailableProvidersListCountry[]`

### AvailableProvidersListCity [Api20190201]
  - CityName `String`
  - Provider `String[]`

### AvailableProvidersListCountry [Api20190201]
  - CountryName `String`
  - Provider `String[]`
  - State `IAvailableProvidersListState[]`

### AvailableProvidersListParameters [Api20190201]
  - AzureLocation `String[]`
  - City `String`
  - Country `String`
  - State `String`

### AvailableProvidersListState [Api20190201]
  - City `IAvailableProvidersListCity[]`
  - Provider `String[]`
  - StateName `String`

### AzureFirewall [Api20190201]
  - ApplicationRule `IAzureFirewallApplicationRuleCollection[]`
  - Etag `String`
  - Id `String`
  - IPConfiguration `IAzureFirewallIPConfiguration[]`
  - Location `String`
  - Name `String`
  - NatRule `IAzureFirewallNatRuleCollection[]`
  - NetworkRule `IAzureFirewallNetworkRuleCollection[]`
  - ProvisioningState `ProvisioningState?`
  - Tag `IResourceTags`
  - ThreatIntelligenceMode `AzureFirewallThreatIntelMode?`
  - Type `String`

### AzureFirewallApplicationRule [Api20190201]
  - Description `String`
  - FqdnTag `String[]`
  - Name `String`
  - Protocol `IAzureFirewallApplicationRuleProtocol[]`
  - SourceAddress `String[]`
  - TargetFqdn `String[]`

### AzureFirewallApplicationRuleCollection [Api20190201]
  - ActionType `AzureFirewallRcActionType?`
  - Etag `String`
  - Id `String`
  - Name `String`
  - Priority `Int32?`
  - ProvisioningState `ProvisioningState?`
  - Rule `IAzureFirewallApplicationRule[]`

### AzureFirewallApplicationRuleCollectionPropertiesFormat [Api20190201]
  - ActionType `AzureFirewallRcActionType?`
  - Priority `Int32?`
  - ProvisioningState `ProvisioningState?`
  - Rule `IAzureFirewallApplicationRule[]`

### AzureFirewallApplicationRuleProtocol [Api20190201]
  - Port `Int32?`
  - ProtocolType `AzureFirewallApplicationRuleProtocolType?`

### AzureFirewallFqdnTag [Api20190201]
  - Etag `String`
  - FqdnTagName `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - Tag `IResourceTags`
  - Type `String`

### AzureFirewallFqdnTagListResult [Api20190201]
  - NextLink `String`
  - Value `IAzureFirewallFqdnTag[]`

### AzureFirewallFqdnTagPropertiesFormat [Api20190201]
  - FqdnTagName `String`
  - ProvisioningState `String`

### AzureFirewallIPConfiguration [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - PrivateIPAddress `String`
  - ProvisioningState `ProvisioningState?`
  - PublicIPAddressId `String`
  - SubnetId `String`

### AzureFirewallIPConfigurationPropertiesFormat [Api20190201]
  - PrivateIPAddress `String`
  - ProvisioningState `ProvisioningState?`
  - PublicIPAddressId `String`
  - SubnetId `String`

### AzureFirewallListResult [Api20190201]
  - NextLink `String`
  - Value `IAzureFirewall[]`

### AzureFirewallNatRcAction [Api20190201]
  - Type `AzureFirewallNatRcActionType?`

### AzureFirewallNatRule [Api20190201]
  - Description `String`
  - DestinationAddress `String[]`
  - DestinationPort `String[]`
  - Name `String`
  - Protocol `AzureFirewallNetworkRuleProtocol[]`
  - SourceAddress `String[]`
  - TranslatedAddress `String`
  - TranslatedPort `String`

### AzureFirewallNatRuleCollection [Api20190201]
  - ActionType `AzureFirewallNatRcActionType?`
  - Etag `String`
  - Id `String`
  - Name `String`
  - Priority `Int32?`
  - ProvisioningState `ProvisioningState?`
  - Rule `IAzureFirewallNatRule[]`

### AzureFirewallNatRuleCollectionProperties [Api20190201]
  - ActionType `AzureFirewallNatRcActionType?`
  - Priority `Int32?`
  - ProvisioningState `ProvisioningState?`
  - Rule `IAzureFirewallNatRule[]`

### AzureFirewallNetworkRule [Api20190201]
  - Description `String`
  - DestinationAddress `String[]`
  - DestinationPort `String[]`
  - Name `String`
  - Protocol `AzureFirewallNetworkRuleProtocol[]`
  - SourceAddress `String[]`

### AzureFirewallNetworkRuleCollection [Api20190201]
  - ActionType `AzureFirewallRcActionType?`
  - Etag `String`
  - Id `String`
  - Name `String`
  - Priority `Int32?`
  - ProvisioningState `ProvisioningState?`
  - Rule `IAzureFirewallNetworkRule[]`

### AzureFirewallNetworkRuleCollectionPropertiesFormat [Api20190201]
  - ActionType `AzureFirewallRcActionType?`
  - Priority `Int32?`
  - ProvisioningState `ProvisioningState?`
  - Rule `IAzureFirewallNetworkRule[]`

### AzureFirewallPropertiesFormat [Api20190201]
  - ApplicationRuleCollection `IAzureFirewallApplicationRuleCollection[]`
  - IPConfiguration `IAzureFirewallIPConfiguration[]`
  - NatRuleCollection `IAzureFirewallNatRuleCollection[]`
  - NetworkRuleCollection `IAzureFirewallNetworkRuleCollection[]`
  - ProvisioningState `ProvisioningState?`
  - ThreatIntelMode `AzureFirewallThreatIntelMode?`

### AzureFirewallRcAction [Api20190201]
  - Type `AzureFirewallRcActionType?`

### AzureReachabilityReport [Api20190201]
  - AggregationLevel `String`
  - ProviderLocationCity `String`
  - ProviderLocationCountry `String`
  - ProviderLocationState `String`
  - ReachabilityReport `IAzureReachabilityReportItem[]`

### AzureReachabilityReportItem [Api20190201]
  - AzureLocation `String`
  - Latency `IAzureReachabilityReportLatencyInfo[]`
  - Provider `String`

### AzureReachabilityReportLatencyInfo [Api20190201]
  - Score `Int32?`
  - TimeStamp `DateTime?`

### AzureReachabilityReportLocation [Api20190201]
  - City `String`
  - Country `String`
  - State `String`

### AzureReachabilityReportParameters [Api20190201]
  - AzureLocation `String[]`
  - EndTime `DateTime`
  - Provider `String[]`
  - ProviderLocationCity `String`
  - ProviderLocationCountry `String`
  - ProviderLocationState `String`
  - StartTime `DateTime`

### BackendAddressPool [Api20171001, Api20190201]
  - BackendIPConfiguration `INetworkInterfaceIPConfiguration[]`
  - Etag `String`
  - Id `String`
  - LoadBalancingRule `ISubResource[]`
  - Name `String`
  - OutboundNatRuleId `String`
  - OutboundRuleId `String`
  - ProvisioningState `String`

### BackendAddressPoolPropertiesFormat [Api20171001, Api20190201]
  - BackendIPConfiguration `INetworkInterfaceIPConfiguration[]`
  - LoadBalancingRule `ISubResource[]`
  - OutboundNatRuleId `String`
  - OutboundRuleId `String`
  - ProvisioningState `String`

### BgpCommunity [Api20171001]
  - CommunityName `String`
  - CommunityPrefix `String[]`
  - CommunityValue `String`
  - IsAuthorizedToUse `Boolean?`
  - ServiceGroup `String`
  - ServiceSupportedRegion `String`

### BgpPeerStatus [Api20171001]
  - Asn `Int32?`
  - ConnectedDuration `String`
  - LocalAddress `String`
  - MessagesReceived `Int64?`
  - MessagesSent `Int64?`
  - Neighbor `String`
  - RoutesReceived `Int64?`
  - State `BgpPeerState?`

### BgpPeerStatusListResult [Api20171001]
  - Value `IBgpPeerStatus[]`

### BgpServiceCommunity [Api20171001]
  - BgpCommunity `IBgpCommunity[]`
  - Id `String`
  - Location `String`
  - Name `String`
  - ServiceName `String`
  - Tag `IResourceTags`
  - Type `String`

### BgpServiceCommunityListResult [Api20190201]
  - NextLink `String`
  - Value `IBgpServiceCommunity[]`

### BgpServiceCommunityPropertiesFormat [Api20171001]
  - BgpCommunity `IBgpCommunity[]`
  - ServiceName `String`

### BgpSettings [Api20171001]
  - Asn `Int64?`
  - BgpPeeringAddress `String`
  - PeerWeight `Int32?`

### CloudError [Api20190201]
  - ErrorCode `String`
  - ErrorDetail `ICloudErrorBody[]`
  - ErrorMessage `String`
  - ErrorTarget `String`

### CloudErrorBody [Api20190201]
  - Code `String`
  - Detail `ICloudErrorBody[]`
  - Message `String`
  - Target `String`

### ComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties [Api20190201]
  - ClientId `String`
  - PrincipalId `String`

### ConnectionMonitor [Api20190201]
  - AutoStart `Boolean?`
  - DestinationAddress `String`
  - DestinationPort `Int32?`
  - DestinationResourceId `String`
  - Location `String`
  - MonitoringIntervalInSeconds `Int32?`
  - SourcePort `Int32?`
  - SourceResourceId `String`
  - Tag `IConnectionMonitorTags`

### ConnectionMonitorDestination [Api20190201]
  - Address `String`
  - Port `Int32?`
  - ResourceId `String`

### ConnectionMonitorListResult [Api20190201]
  - Value `IConnectionMonitorResult[]`

### ConnectionMonitorParameters [Api20190201]
  - AutoStart `Boolean?`
  - DestinationAddress `String`
  - DestinationPort `Int32?`
  - DestinationResourceId `String`
  - MonitoringIntervalInSeconds `Int32?`
  - SourcePort `Int32?`
  - SourceResourceId `String`

### ConnectionMonitorQueryResult [Api20190201]
  - SourceStatus `ConnectionMonitorSourceStatus?`
  - State `IConnectionStateSnapshot[]`

### ConnectionMonitorResult [Api20190201]
  - AutoStart `Boolean?`
  - DestinationAddress `String`
  - DestinationPort `Int32?`
  - DestinationResourceId `String`
  - Etag `String`
  - Id `String`
  - Location `String`
  - MonitoringIntervalInSeconds `Int32?`
  - MonitoringStatus `String`
  - Name `String`
  - ProvisioningState `ProvisioningState?`
  - SourcePort `Int32?`
  - SourceResourceId `String`
  - StartTime `DateTime?`
  - Tag `IConnectionMonitorResultTags`
  - Type `String`

### ConnectionMonitorResultProperties [Api20190201]
  - AutoStart `Boolean?`
  - Destination `IConnectionMonitorDestination`
  - DestinationAddress `String`
  - DestinationPort `Int32?`
  - DestinationResourceId `String`
  - MonitoringIntervalInSeconds `Int32?`
  - MonitoringStatus `String`
  - ProvisioningState `ProvisioningState?`
  - Source `IConnectionMonitorSource`
  - SourcePort `Int32?`
  - SourceResourceId `String`
  - StartTime `DateTime?`

### ConnectionMonitorResultTags [Api20190201]
  - Item `String`

### ConnectionMonitorSource [Api20190201]
  - Port `Int32?`
  - ResourceId `String`

### ConnectionMonitorTags [Api20190201]
  - Item `String`

### ConnectionResetSharedKey [Api20171001]
  - KeyLength `Int32`

### ConnectionSharedKey [Api20171001, Api20190201]
  - Id `String`
  - Value `String`

### ConnectionStateSnapshot [Api20190201]
  - AvgLatencyInMS `Int32?`
  - ConnectionState `ConnectionState?`
  - EndTime `DateTime?`
  - EvaluationState `EvaluationState?`
  - Hop `IConnectivityHop[]`
  - MaxLatencyInMS `Int32?`
  - MinLatencyInMS `Int32?`
  - ProbesFailed `Int32?`
  - ProbesSent `Int32?`
  - StartTime `DateTime?`

### ConnectivityDestination [Api20190201]
  - Address `String`
  - Port `Int32?`
  - ResourceId `String`

### ConnectivityHop [Api20190201]
  - Address `String`
  - Id `String`
  - Issue `IConnectivityIssue[]`
  - NextHopId `String[]`
  - ResourceId `String`
  - Type `String`

### ConnectivityInformation [Api20190201]
  - AvgLatencyInMS `Int32?`
  - ConnectionStatus `ConnectionStatus?`
  - Hop `IConnectivityHop[]`
  - MaxLatencyInMS `Int32?`
  - MinLatencyInMS `Int32?`
  - ProbesFailed `Int32?`
  - ProbesSent `Int32?`

### ConnectivityIssue [Api20190201]
  - Context `IIssueContext[]`
  - Origin `Origin?`
  - Severity `Severity?`
  - Type `IssueType?`

### ConnectivityParameters [Api20190201]
  - DestinationAddress `String`
  - DestinationPort `Int32?`
  - DestinationResourceId `String`
  - HttpConfigurationHeader `IHttpHeader[]`
  - HttpConfigurationMethod `HttpMethod?`
  - HttpConfigurationValidStatusCode `Int32[]`
  - Protocol `Protocol?`
  - SourcePort `Int32?`
  - SourceResourceId `String`

### ConnectivitySource [Api20190201]
  - Port `Int32?`
  - ResourceId `String`

### Container [Api20190201]
  - Id `String`

### ContainerNetworkInterface [Api20190201]
  - ConfigurationEtag `String`
  - ConfigurationId `String`
  - ConfigurationName `String`
  - ConfigurationPropertiesIPConfiguration `IIPConfigurationProfile[]`
  - ConfigurationPropertiesProvisioningState `String`
  - ConfigurationType `String`
  - ContainerId `String`
  - Etag `String`
  - Id `String`
  - IPConfiguration `IContainerNetworkInterfaceIPConfiguration[]`
  - Name `String`
  - PropertiesContainerNetworkInterfaceConfigurationPropertiesContainerNetworkInterfaces `ISubResource[]`
  - ProvisioningState `String`
  - Type `String`

### ContainerNetworkInterfaceConfiguration [Api20190201]
  - ContainerNetworkInterface `ISubResource[]`
  - Etag `String`
  - Id `String`
  - IPConfiguration `IIPConfigurationProfile[]`
  - Name `String`
  - ProvisioningState `String`
  - Type `String`

### ContainerNetworkInterfaceConfigurationPropertiesFormat [Api20190201]
  - ContainerNetworkInterface `ISubResource[]`
  - IPConfiguration `IIPConfigurationProfile[]`
  - ProvisioningState `String`

### ContainerNetworkInterfaceIPConfiguration [Api20190201]
  - Etag `String`
  - Name `String`
  - ProvisioningState `String`
  - Type `String`

### ContainerNetworkInterfaceIPConfigurationPropertiesFormat [Api20190201]
  - ProvisioningState `String`

### ContainerNetworkInterfacePropertiesFormat [Api20190201]
  - ContainerId `String`
  - ContainerNetworkInterface `ISubResource[]`
  - ContainerNetworkInterfaceConfigurationEtag `String`
  - ContainerNetworkInterfaceConfigurationId `String`
  - ContainerNetworkInterfaceConfigurationName `String`
  - ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration `IIPConfigurationProfile[]`
  - ContainerNetworkInterfaceConfigurationPropertiesProvisioningState `String`
  - ContainerNetworkInterfaceConfigurationType `String`
  - IPConfiguration `IContainerNetworkInterfaceIPConfiguration[]`
  - ProvisioningState `String`

### DdosCustomPolicy [Api20190201]
  - Etag `String`
  - Format `IProtocolCustomSettingsFormat[]`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - PublicIPAddress `ISubResource[]`
  - ResourceGuid `String`
  - Tag `IResourceTags`
  - Type `String`

### DdosCustomPolicyPropertiesFormat [Api20190201]
  - ProtocolCustomSetting `IProtocolCustomSettingsFormat[]`
  - ProvisioningState `String`
  - PublicIPAddress `ISubResource[]`
  - ResourceGuid `String`

### DdosProtectionPlan [Api20190201]
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Tag `IDdosProtectionPlanTags`
  - Type `String`
  - Vnet `ISubResource[]`

### DdosProtectionPlanListResult [Api20190201]
  - NextLink `String`
  - Value `IDdosProtectionPlan[]`

### DdosProtectionPlanPropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Vnet `ISubResource[]`

### DdosProtectionPlanTags [Api20190201]
  - Item `String`

### DdosSettings [Api20190201]
  - DdosCustomPolicyId `String`
  - ProtectionCoverage `DdosSettingsProtectionCoverage?`

### Delegation [Api20190201]
  - Action `String[]`
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - ServiceName `String`

### DeviceProperties [Api20190201]
  - DeviceModel `String`
  - DeviceVendor `String`
  - LinkSpeedInMbps `Int32?`

### DhcpOptions [Api20171001]
  - DnsServer `String[]`

### Dimension [Api20171001]
  - DisplayName `String`
  - InternalName `String`
  - Name `String`

### DnsNameAvailabilityResult [Api20171001]
  - Available `Boolean?`

### EffectiveNetworkSecurityGroup [Api20171001]
  - EffectiveSecurityRule `IEffectiveNetworkSecurityRule[]`
  - NetworkInterfaceId `String`
  - NsgId `String`
  - SubnetId `String`
  - TagMap `String`

### EffectiveNetworkSecurityGroupAssociation [Api20171001]
  - NetworkInterfaceId `String`
  - SubnetId `String`

### EffectiveNetworkSecurityGroupListResult [Api20171001]
  - NextLink `String`
  - Value `IEffectiveNetworkSecurityGroup[]`

### EffectiveNetworkSecurityRule [Api20171001]
  - Access `SecurityRuleAccess?`
  - DestinationAddressPrefix `String`
  - DestinationAddressPrefixes `String[]`
  - DestinationPortRange `String`
  - DestinationPortRanges `String[]`
  - Direction `SecurityRuleDirection?`
  - ExpandedDestinationAddressPrefix `String[]`
  - ExpandedSourceAddressPrefix `String[]`
  - Name `String`
  - Priority `Int32?`
  - Protocol `EffectiveSecurityRuleProtocol?`
  - SourceAddressPrefix `String`
  - SourceAddressPrefixes `String[]`
  - SourcePortRange `String`
  - SourcePortRanges `String[]`

### EffectiveRoute [Api20171001, Api20190201]
  - AddressPrefix `String[]`
  - DisableBgpRoutePropagation `Boolean?`
  - Name `String`
  - NextHopIPAddress `String[]`
  - NextHopType `RouteNextHopType?`
  - Source `EffectiveRouteSource?`
  - State `EffectiveRouteState?`

### EffectiveRouteListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IEffectiveRoute[]`

### EndpointService [Api20190201]
  - Id `String`

### EndpointServiceResult [Api20171001]
  - Id `String`
  - Name `String`
  - Type `String`

### EndpointServicesListResult [Api20171001]
  - NextLink `String`
  - Value `IEndpointServiceResult[]`

### Error [Api20190201]
  - Code `String`
  - Detail `IErrorDetails[]`
  - InnerError `String`
  - Message `String`
  - Target `String`

### ErrorDetails [Api20190201]
  - Code `String`
  - Message `String`
  - Target `String`

### ErrorResponse [Api20190201]
  - ErrorCode `String`
  - ErrorMessage `String`
  - ErrorTarget `String`

### EvaluatedNetworkSecurityGroup [Api20190201]
  - AppliedTo `String`
  - MatchedRuleAction `String`
  - MatchedRuleName `String`
  - NsgId `String`
  - RulesEvaluationResult `INetworkSecurityRulesEvaluationResult[]`

### ExpressRouteCircuit [Api20171001, Api20190201]
  - AllowClassicOperations `Boolean?`
  - Authorization `IExpressRouteCircuitAuthorization[]`
  - BandwidthInGbps `Single?`
  - CircuitProvisioningState `String`
  - EnableGlobalReach `Boolean?`
  - Etag `String`
  - ExpressRoutePortId `String`
  - GatewayManagerEtag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - Peering `IExpressRouteCircuitPeering[]`
  - ProvisioningState `String`
  - ServiceKey `String`
  - ServiceProviderBandwidthInMbps `Int32?`
  - ServiceProviderName `String`
  - ServiceProviderNote `String`
  - ServiceProviderPeeringLocation `String`
  - ServiceProviderProvisioningState `ServiceProviderProvisioningState?`
  - SkuFamily `ExpressRouteCircuitSkuFamily?`
  - SkuName `String`
  - SkuTier `ExpressRouteCircuitSkuTier?`
  - Stag `Int32?`
  - Tag `IResourceTags`
  - Type `String`

### ExpressRouteCircuitArpTable [Api20150501Preview, Api20190201]
  - Age `Int32?`
  - Interface `String`
  - IPAddress `String`
  - MacAddress `String`

### ExpressRouteCircuitAuthorization [Api20171001]
  - AuthorizationKey `String`
  - AuthorizationUseStatus `AuthorizationUseStatus?`
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`

### ExpressRouteCircuitConnection [Api20190201]
  - AddressPrefix `String`
  - AuthorizationKey `String`
  - CircuitConnectionStatus `CircuitConnectionStatus?`
  - Etag `String`
  - ExpressRouteCircuitPeeringId `String`
  - Id `String`
  - Name `String`
  - PeerExpressRouteCircuitPeeringId `String`
  - ProvisioningState `String`

### ExpressRouteCircuitConnectionListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCircuitConnection[]`

### ExpressRouteCircuitConnectionPropertiesFormat [Api20190201]
  - AddressPrefix `String`
  - AuthorizationKey `String`
  - CircuitConnectionStatus `CircuitConnectionStatus?`
  - ExpressRouteCircuitPeeringId `String`
  - PeerExpressRouteCircuitPeeringId `String`
  - ProvisioningState `String`

### ExpressRouteCircuitListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCircuit[]`

### ExpressRouteCircuitPeering [Api20171001, Api20190201]
  - AdvertisedCommunity `String[]`
  - AdvertisedPublicPrefix `String[]`
  - AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - AzureAsn `Int32?`
  - Connection `IExpressRouteCircuitConnection[]`
  - CustomerAsn `Int32?`
  - Etag `String`
  - ExpressRouteConnectionId `String`
  - GatewayManagerEtag `String`
  - Id `String`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity `String[]`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix `String[]`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn `Int32?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode `Int32?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName `String`
  - Ipv6PeeringConfigPrimaryPeerAddressPrefix `String`
  - Ipv6PeeringConfigRouteFilter `IRouteFilter`
  - Ipv6PeeringConfigRouteFilterEtag `String`
  - Ipv6PeeringConfigRouteFilterId `String`
  - Ipv6PeeringConfigRouteFilterLocation `String`
  - Ipv6PeeringConfigRouteFilterName `String`
  - Ipv6PeeringConfigRouteFilterPropertiesPeering `IExpressRouteCircuitPeering[]`
  - Ipv6PeeringConfigRouteFilterPropertiesProvisioningState `String`
  - Ipv6PeeringConfigRouteFilterPropertiesRule `IRouteFilterRule[]`
  - Ipv6PeeringConfigRouteFilterTag `IResourceTags`
  - Ipv6PeeringConfigRouteFilterType `String`
  - Ipv6PeeringConfigSecondaryPeerAddressPrefix `String`
  - Ipv6PeeringConfigState `ExpressRouteCircuitPeeringState?`
  - LastModifiedBy `String`
  - LegacyMode `Int32?`
  - Location `String`
  - Name `String`
  - PeerAsn `Int64?`
  - PeeredConnection `IPeerExpressRouteCircuitConnection[]`
  - PeeringType `ExpressRoutePeeringType?`
  - PrimaryAzurePort `String`
  - PrimaryPeerAddressPrefix `String`
  - PropertiesRouteFilterEtag `String`
  - PropertiesRouteFilterId `String`
  - PropertiesRouteFilterName `String`
  - ProvisioningState `String`
  - RouteFilter `IRouteFilter`
  - RouteFilterPropertiesPeering `IExpressRouteCircuitPeering[]`
  - RouteFilterPropertiesProvisioningState `String`
  - RouteFilterPropertiesRule `IRouteFilterRule[]`
  - RoutingRegistryName `String`
  - SecondaryAzurePort `String`
  - SecondaryPeerAddressPrefix `String`
  - SharedKey `String`
  - State `ExpressRoutePeeringState?`
  - StatPrimarybytesIn `Int64?`
  - StatPrimarybytesOut `Int64?`
  - StatSecondarybytesIn `Int64?`
  - StatSecondarybytesOut `Int64?`
  - Tag `IResourceTags`
  - Type `String`
  - VlanId `Int32?`

### ExpressRouteCircuitPeeringConfig [Api20171001]
  - AdvertisedCommunity `String[]`
  - AdvertisedPublicPrefix `String[]`
  - AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - CustomerAsn `Int32?`
  - LegacyMode `Int32?`
  - RoutingRegistryName `String`

### ExpressRouteCircuitPeeringId [Api20190201]
  - Id `String`

### ExpressRouteCircuitPeeringListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCircuitPeering[]`

### ExpressRouteCircuitPeeringPropertiesFormat [Api20171001, Api20190201]
  - AdvertisedCommunity `String[]`
  - AdvertisedPublicPrefix `String[]`
  - AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - AzureAsn `Int32?`
  - Connection `IExpressRouteCircuitConnection[]`
  - CustomerAsn `Int32?`
  - Etag `String`
  - ExpressRouteConnectionId `String`
  - GatewayManagerEtag `String`
  - Id `String`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity `String[]`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix `String[]`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn `Int32?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode `Int32?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName `String`
  - Ipv6PeeringConfigPrimaryPeerAddressPrefix `String`
  - Ipv6PeeringConfigRouteFilter `IRouteFilter`
  - Ipv6PeeringConfigRouteFilterEtag `String`
  - Ipv6PeeringConfigRouteFilterId `String`
  - Ipv6PeeringConfigRouteFilterLocation `String`
  - Ipv6PeeringConfigRouteFilterName `String`
  - Ipv6PeeringConfigRouteFilterPropertiesPeering `IExpressRouteCircuitPeering[]`
  - Ipv6PeeringConfigRouteFilterPropertiesProvisioningState `String`
  - Ipv6PeeringConfigRouteFilterPropertiesRule `IRouteFilterRule[]`
  - Ipv6PeeringConfigRouteFilterTag `IResourceTags`
  - Ipv6PeeringConfigRouteFilterType `String`
  - Ipv6PeeringConfigSecondaryPeerAddressPrefix `String`
  - Ipv6PeeringConfigState `ExpressRouteCircuitPeeringState?`
  - LastModifiedBy `String`
  - LegacyMode `Int32?`
  - Location `String`
  - Name `String`
  - PeerAsn `Int64?`
  - PeeredConnection `IPeerExpressRouteCircuitConnection[]`
  - PeeringType `ExpressRoutePeeringType?`
  - PrimaryAzurePort `String`
  - PrimaryPeerAddressPrefix `String`
  - ProvisioningState `String`
  - RouteFilter `IRouteFilter`
  - RouteFilterPropertiesPeering `IExpressRouteCircuitPeering[]`
  - RouteFilterPropertiesProvisioningState `String`
  - RouteFilterPropertiesRule `IRouteFilterRule[]`
  - RoutingRegistryName `String`
  - SecondaryAzurePort `String`
  - SecondaryPeerAddressPrefix `String`
  - SharedKey `String`
  - State `ExpressRoutePeeringState?`
  - StatPrimarybytesIn `Int64?`
  - StatPrimarybytesOut `Int64?`
  - StatSecondarybytesIn `Int64?`
  - StatSecondarybytesOut `Int64?`
  - Tag `IResourceTags`
  - Type `String`
  - VlanId `Int32?`

### ExpressRouteCircuitPropertiesFormat [Api20171001, Api20190201]
  - AllowClassicOperation `Boolean?`
  - Authorization `IExpressRouteCircuitAuthorization[]`
  - BandwidthInGbps `Single?`
  - CircuitProvisioningState `String`
  - ExpressRoutePortId `String`
  - GatewayManagerEtag `String`
  - GlobalReachEnabled `Boolean?`
  - Peering `IExpressRouteCircuitPeering[]`
  - ProvisioningState `String`
  - ServiceKey `String`
  - ServiceProviderNote `String`
  - ServiceProviderPropertyBandwidthInMbps `Int32?`
  - ServiceProviderPropertyPeeringLocation `String`
  - ServiceProviderPropertyServiceProviderName `String`
  - ServiceProviderProvisioningState `ServiceProviderProvisioningState?`
  - Stag `Int32?`

### ExpressRouteCircuitReference [Api20190201]
  - Id `String`

### ExpressRouteCircuitRoutesTable [Api20150501Preview, Api20171001]
  - AddressPrefix `String`
  - AsPath `String`
  - LocPrf `String`
  - Network `String`
  - NextHop `String`
  - NextHopIP `String`
  - NextHopType `RouteNextHopType`
  - Path `String`
  - Weight `Int32?`

### ExpressRouteCircuitRoutesTableSummary [Api20190201]
  - As `Int32?`
  - Neighbor `String`
  - StatePfxRcd `String`
  - UpDown `String`
  - V `Int32?`

### ExpressRouteCircuitsArpTableListResult [Api20150501Preview, Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCircuitArpTable[]`

### ExpressRouteCircuitServiceProviderProperties [Api20171001]
  - BandwidthInMbps `Int32?`
  - PeeringLocation `String`
  - ServiceProviderName `String`

### ExpressRouteCircuitSku [Api20171001, Api20190201]
  - Family `ExpressRouteCircuitSkuFamily?`
  - Name `String`
  - Tier `ExpressRouteCircuitSkuTier?`

### ExpressRouteCircuitsRoutesTableListResult [Api20150501Preview, Api20171001]
  - NextLink `String`
  - Value `IExpressRouteCircuitRoutesTable[]`

### ExpressRouteCircuitsRoutesTableSummaryListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCircuitRoutesTableSummary[]`

### ExpressRouteCircuitsStatsListResult [Api20150501Preview]
  - NextLink `String`
  - Value `IExpressRouteCircuitStats[]`

### ExpressRouteCircuitStats [Api20150501Preview, Api20171001]
  - BytesIn `Int32?`
  - BytesOut `Int32?`
  - PrimarybytesIn `Int64?`
  - PrimarybytesOut `Int64?`
  - SecondarybytesIn `Int64?`
  - SecondarybytesOut `Int64?`

### ExpressRouteConnection [Api20190201]
  - AuthorizationKey `String`
  - ExpressRouteCircuitPeeringId `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `ProvisioningState?`
  - RoutingWeight `Int32?`

### ExpressRouteConnectionId [Api20190201]
  - Id `String`

### ExpressRouteConnectionList [Api20190201]
  - Value `IExpressRouteConnection[]`

### ExpressRouteConnectionProperties [Api20190201]
  - AuthorizationKey `String`
  - ExpressRouteCircuitPeeringId `String`
  - ProvisioningState `ProvisioningState?`
  - RoutingWeight `Int32?`

### ExpressRouteCrossConnection [Api20190201]
  - BandwidthInMbps `Int32?`
  - Etag `String`
  - ExpressRouteCircuitId `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - Peering `IExpressRouteCrossConnectionPeering[]`
  - PeeringLocation `String`
  - PrimaryAzurePort `String`
  - ProvisioningState `String`
  - SecondaryAzurePort `String`
  - ServiceProviderNote `String`
  - ServiceProviderProvisioningState `ServiceProviderProvisioningState?`
  - STag `Int32?`
  - Tag `IResourceTags`
  - Type `String`

### ExpressRouteCrossConnectionListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCrossConnection[]`

### ExpressRouteCrossConnectionPeering [Api20190201]
  - AdvertisedCommunity `String[]`
  - AdvertisedPublicPrefix `String[]`
  - AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - AzureAsn `Int32?`
  - CustomerAsn `Int32?`
  - Etag `String`
  - GatewayManagerEtag `String`
  - Id `String`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity `String[]`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix `String[]`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn `Int32?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode `Int32?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName `String`
  - Ipv6PeeringConfigPrimaryPeerAddressPrefix `String`
  - Ipv6PeeringConfigRouteFilter `IRouteFilter`
  - Ipv6PeeringConfigSecondaryPeerAddressPrefix `String`
  - Ipv6PeeringConfigState `ExpressRouteCircuitPeeringState?`
  - LastModifiedBy `String`
  - LegacyMode `Int32?`
  - Name `String`
  - PeerAsn `Int64?`
  - PeeringType `ExpressRoutePeeringType?`
  - PrimaryAzurePort `String`
  - PrimaryPeerAddressPrefix `String`
  - ProvisioningState `String`
  - RoutingRegistryName `String`
  - SecondaryAzurePort `String`
  - SecondaryPeerAddressPrefix `String`
  - SharedKey `String`
  - State `ExpressRoutePeeringState?`
  - VlanId `Int32?`

### ExpressRouteCrossConnectionPeeringList [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCrossConnectionPeering[]`

### ExpressRouteCrossConnectionPeeringProperties [Api20190201]
  - AdvertisedCommunity `String[]`
  - AdvertisedPublicPrefix `String[]`
  - AdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - AzureAsn `Int32?`
  - CustomerAsn `Int32?`
  - GatewayManagerEtag `String`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity `String[]`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix `String[]`
  - Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn `Int32?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode `Int32?`
  - Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName `String`
  - Ipv6PeeringConfigPrimaryPeerAddressPrefix `String`
  - Ipv6PeeringConfigRouteFilter `IRouteFilter`
  - Ipv6PeeringConfigSecondaryPeerAddressPrefix `String`
  - Ipv6PeeringConfigState `ExpressRouteCircuitPeeringState?`
  - LastModifiedBy `String`
  - LegacyMode `Int32?`
  - PeerAsn `Int64?`
  - PeeringType `ExpressRoutePeeringType?`
  - PrimaryAzurePort `String`
  - PrimaryPeerAddressPrefix `String`
  - ProvisioningState `String`
  - RoutingRegistryName `String`
  - SecondaryAzurePort `String`
  - SecondaryPeerAddressPrefix `String`
  - SharedKey `String`
  - State `ExpressRoutePeeringState?`
  - VlanId `Int32?`

### ExpressRouteCrossConnectionProperties [Api20190201]
  - BandwidthInMbps `Int32?`
  - ExpressRouteCircuitId `String`
  - Peering `IExpressRouteCrossConnectionPeering[]`
  - PeeringLocation `String`
  - PrimaryAzurePort `String`
  - ProvisioningState `String`
  - SecondaryAzurePort `String`
  - ServiceProviderNote `String`
  - ServiceProviderProvisioningState `ServiceProviderProvisioningState?`
  - STag `Int32?`

### ExpressRouteCrossConnectionRoutesTableSummary [Api20190201]
  - Asn `Int32?`
  - Neighbor `String`
  - StateOrPrefixesReceived `String`
  - UpDown `String`

### ExpressRouteCrossConnectionsRoutesTableSummaryListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteCrossConnectionRoutesTableSummary[]`

### ExpressRouteGateway [Api20190201]
  - Etag `String`
  - ExpressRouteConnection `IExpressRouteConnection[]`
  - Id `String`
  - Location `String`
  - MaximumScaleUnit `Int32?`
  - MinimumScaleUnit `Int32?`
  - Name `String`
  - ProvisioningState `ProvisioningState?`
  - Tag `IResourceTags`
  - Type `String`
  - VirtualHubId `String`

### ExpressRouteGatewayList [Api20190201]
  - Value `IExpressRouteGateway[]`

### ExpressRouteGatewayProperties [Api20190201]
  - BoundMax `Int32?`
  - BoundMin `Int32?`
  - ExpressRouteConnection `IExpressRouteConnection[]`
  - ProvisioningState `ProvisioningState?`
  - VirtualHubId `String`

### ExpressRouteGatewayPropertiesAutoScaleConfiguration [Api20190201]
  - BoundMax `Int32?`
  - BoundMin `Int32?`

### ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds [Api20190201]
  - Max `Int32?`
  - Min `Int32?`

### ExpressRouteLink [Api20190201]
  - AdminState `ExpressRouteLinkAdminState?`
  - ConnectorType `ExpressRouteLinkConnectorType?`
  - Etag `String`
  - Id `String`
  - InterfaceName `String`
  - Name `String`
  - PatchPanelId `String`
  - ProvisioningState `String`
  - RackId `String`
  - RouterName `String`

### ExpressRouteLinkListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteLink[]`

### ExpressRouteLinkPropertiesFormat [Api20190201]
  - AdminState `ExpressRouteLinkAdminState?`
  - ConnectorType `ExpressRouteLinkConnectorType?`
  - InterfaceName `String`
  - PatchPanelId `String`
  - ProvisioningState `String`
  - RackId `String`
  - RouterName `String`

### ExpressRoutePort [Api20190201]
  - AllocationDate `String`
  - BandwidthInGbps `Int32?`
  - Circuit `ISubResource[]`
  - Encapsulation `ExpressRoutePortsEncapsulation?`
  - Etag `String`
  - EtherType `String`
  - Id `String`
  - Link `IExpressRouteLink[]`
  - Location `String`
  - Mtu `String`
  - Name `String`
  - PeeringLocation `String`
  - ProvisionedBandwidthInGbps `Single?`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Tag `IResourceTags`
  - Type `String`

### ExpressRoutePortListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRoutePort[]`

### ExpressRoutePortPropertiesFormat [Api20190201]
  - AllocationDate `String`
  - BandwidthInGbps `Int32?`
  - Circuit `ISubResource[]`
  - Encapsulation `ExpressRoutePortsEncapsulation?`
  - EtherType `String`
  - Link `IExpressRouteLink[]`
  - Mtu `String`
  - PeeringLocation `String`
  - ProvisionedBandwidthInGbps `Single?`
  - ProvisioningState `String`
  - ResourceGuid `String`

### ExpressRoutePortsLocation [Api20190201]
  - Address `String`
  - AvailableBandwidth `IExpressRoutePortsLocationBandwidths[]`
  - Contact `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - Tag `IResourceTags`
  - Type `String`

### ExpressRoutePortsLocationBandwidths [Api20190201]
  - OfferName `String`
  - ValueInGbps `Int32?`

### ExpressRoutePortsLocationListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRoutePortsLocation[]`

### ExpressRoutePortsLocationPropertiesFormat [Api20190201]
  - Address `String`
  - AvailableBandwidth `IExpressRoutePortsLocationBandwidths[]`
  - Contact `String`
  - ProvisioningState `String`

### ExpressRouteServiceProvider [Api20171001]
  - BandwidthsOffered `IExpressRouteServiceProviderBandwidthsOffered[]`
  - Id `String`
  - Location `String`
  - Name `String`
  - PeeringLocation `String[]`
  - ProvisioningState `String`
  - Tag `IResourceTags`
  - Type `String`

### ExpressRouteServiceProviderBandwidthsOffered [Api20171001]
  - OfferName `String`
  - ValueInMbps `Int32?`

### ExpressRouteServiceProviderListResult [Api20190201]
  - NextLink `String`
  - Value `IExpressRouteServiceProvider[]`

### ExpressRouteServiceProviderPropertiesFormat [Api20171001]
  - BandwidthsOffered `IExpressRouteServiceProviderBandwidthsOffered[]`
  - PeeringLocation `String[]`
  - ProvisioningState `String`

### FlowLogFormatParameters [Api20190201]
  - Type `FlowLogFormatType?`
  - Version `Int32?`

### FlowLogInformation [Api20190201]
  - Enabled `Boolean`
  - FormatType `FlowLogFormatType?`
  - FormatVersion `Int32?`
  - NetworkWatcherFlowAnalyticConfigurationEnabled `Boolean`
  - NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval `Int32?`
  - NetworkWatcherFlowAnalyticConfigurationWorkspaceId `String`
  - NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion `String`
  - NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId `String`
  - RetentionPolicyDay `Int32?`
  - RetentionPolicyEnabled `Boolean?`
  - StorageId `String`
  - TargetResourceId `String`

### FlowLogProperties [Api20190201]
  - Enabled `Boolean`
  - FormatType `FlowLogFormatType?`
  - FormatVersion `Int32?`
  - RetentionPolicyDay `Int32?`
  - RetentionPolicyEnabled `Boolean?`
  - StorageId `String`

### FlowLogStatusParameters [Api20190201]
  - TargetResourceId `String`

### FrontendIPConfiguration [Api20171001, Api20190201]
  - Etag `String`
  - Id `String`
  - InboundNatPool `ISubResource[]`
  - InboundNatRule `ISubResource[]`
  - LoadBalancingRule `ISubResource[]`
  - Name `String`
  - OutboundNatRule `ISubResource[]`
  - OutboundRule `ISubResource[]`
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - PublicIPPrefixId `String`
  - Subnet `ISubnet`
  - Zone `String[]`

### FrontendIPConfigurationPropertiesFormat [Api20171001, Api20190201]
  - InboundNatPool `ISubResource[]`
  - InboundNatRule `ISubResource[]`
  - LoadBalancingRule `ISubResource[]`
  - OutboundNatRule `ISubResource[]`
  - OutboundRule `ISubResource[]`
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - PublicIPPrefixId `String`
  - Subnet `ISubnet`

### GatewayRoute [Api20171001]
  - AsPath `String`
  - LocalAddress `String`
  - Network `String`
  - NextHop `String`
  - Origin `String`
  - SourcePeer `String`
  - Weight `Int32?`

### GatewayRouteListResult [Api20171001]
  - Value `IGatewayRoute[]`

### GetVpnSitesConfigurationRequest [Api20190201]
  - OutputBlobSasUrl `String`
  - VpnSite `String[]`

### HttpConfiguration [Api20190201]
  - Header `IHttpHeader[]`
  - Method `HttpMethod?`
  - ValidStatusCode `Int32[]`

### HttpHeader [Api20190201]
  - Name `String`
  - Value `String`

### HubVirtualNetworkConnection [Api20190201]
  - AllowHubToRemoteVnetTransit `Boolean?`
  - AllowRemoteVnetToUseHubVnetGateway `Boolean?`
  - EnableInternetSecurity `Boolean?`
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `ProvisioningState?`
  - RemoteVnetId `String`

### HubVirtualNetworkConnectionProperties [Api20190201]
  - AllowHubToRemoteVnetTransit `Boolean?`
  - AllowRemoteVnetToUseHubVnetGateway `Boolean?`
  - EnableInternetSecurity `Boolean?`
  - ProvisioningState `ProvisioningState?`
  - RemoteVnetId `String`

### InboundNatPool [Api20171001, Api20190201]
  - BackendPort `Int32`
  - EnableFloatingIP `Boolean?`
  - EnableTcpReset `Boolean?`
  - Etag `String`
  - FrontendIPConfigurationId `String`
  - FrontendPortRangeEnd `Int32`
  - FrontendPortRangeStart `Int32`
  - Id `String`
  - IdleTimeoutInMinutes `Int32?`
  - Name `String`
  - Protocol `TransportProtocol`
  - ProvisioningState `String`

### InboundNatPoolPropertiesFormat [Api20171001, Api20190201]
  - BackendPort `Int32`
  - EnableFloatingIP `Boolean?`
  - EnableTcpReset `Boolean?`
  - FrontendIPConfigurationId `String`
  - FrontendPortRangeEnd `Int32`
  - FrontendPortRangeStart `Int32`
  - IdleTimeoutInMinutes `Int32?`
  - Protocol `TransportProtocol`
  - ProvisioningState `String`

### InboundNatRule [Api20171001, Api20190201]
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - BackendIPConfigurationEtag `String`
  - BackendIPConfigurationId `String`
  - BackendIPConfigurationName `String`
  - BackendIPConfigurationPropertiesProvisioningState `String`
  - BackendPort `Int32?`
  - EnableFloatingIP `Boolean?`
  - EnableTcpReset `Boolean?`
  - Etag `String`
  - FrontendIPConfigurationId `String`
  - FrontendPort `Int32?`
  - Id `String`
  - IdleTimeoutInMinutes `Int32?`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - Name `String`
  - Primary `Boolean?`
  - PrivateIPAddress `String`
  - PrivateIPAddressVersion `IPVersion?`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - Protocol `TransportProtocol?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - Subnet `ISubnet`
  - VnetTap `IVirtualNetworkTap[]`

### InboundNatRuleListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IInboundNatRule[]`

### InboundNatRulePropertiesFormat [Api20171001, Api20190201]
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - BackendIPConfigurationEtag `String`
  - BackendIPConfigurationId `String`
  - BackendIPConfigurationName `String`
  - BackendIPConfigurationPropertiesProvisioningState `String`
  - BackendPort `Int32?`
  - EnableFloatingIP `Boolean?`
  - EnableTcpReset `Boolean?`
  - FrontendIPConfigurationId `String`
  - FrontendPort `Int32?`
  - IdleTimeoutInMinutes `Int32?`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - Primary `Boolean?`
  - PrivateIPAddress `String`
  - PrivateIPAddressVersion `IPVersion?`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - Protocol `TransportProtocol?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - Subnet `ISubnet`
  - VnetTap `IVirtualNetworkTap[]`

### InterfaceEndpoint [Api20190201]
  - EndpointServiceId `String`
  - Etag `String`
  - Fqdn `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - NetworkInterface `INetworkInterface[]`
  - Owner `String`
  - ProvisioningState `String`
  - Subnet `ISubnet`
  - Tag `IResourceTags`
  - Type `String`

### InterfaceEndpointListResult [Api20190201]
  - NextLink `String`
  - Value `IInterfaceEndpoint[]`

### InterfaceEndpointProperties [Api20190201]
  - EndpointServiceId `String`
  - Fqdn `String`
  - NetworkInterface `INetworkInterface[]`
  - Owner `String`
  - ProvisioningState `String`
  - Subnet `ISubnet`

### IPAddressAvailabilityResult [Api20171001]
  - Available `Boolean?`
  - AvailableIPAddress `String[]`

### IPConfiguration [Api20171001, Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - Property `IIPConfigurationPropertiesFormat`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - Subnet `ISubnet`

### IPConfigurationProfile [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Subnet `ISubnet`
  - Type `String`

### IPConfigurationProfilePropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - Subnet `ISubnet`

### IPConfigurationPropertiesFormat [Api20171001, Api20190201]
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - Subnet `ISubnet`

### IpsecPolicy [Api20171001, Api20190201]
  - DhGroup `DhGroup`
  - IkeEncryption `IkeEncryption`
  - IkeIntegrity `IkeIntegrity`
  - IpsecEncryption `IpsecEncryption`
  - IpsecIntegrity `IpsecIntegrity`
  - PfsGroup `PfsGroup`
  - SaDataSizeKilobyte `Int32`
  - SaLifeTimeSecond `Int32`

### IPTag [Api20190201]
  - Tag `String`
  - Type `String`

### Ipv6ExpressRouteCircuitPeeringConfig [Api20171001, Api20190201]
  - MicrosoftPeeringConfigAdvertisedCommunity `String[]`
  - MicrosoftPeeringConfigAdvertisedPublicPrefix `String[]`
  - MicrosoftPeeringConfigAdvertisedPublicPrefixesState `ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?`
  - MicrosoftPeeringConfigCustomerAsn `Int32?`
  - MicrosoftPeeringConfigLegacyMode `Int32?`
  - MicrosoftPeeringConfigRoutingRegistryName `String`
  - Peering `IExpressRouteCircuitPeering[]`
  - PrimaryPeerAddressPrefix `String`
  - ProvisioningState `String`
  - RouteFilter `IRouteFilter`
  - RouteFilterEtag `String`
  - RouteFilterId `String`
  - RouteFilterLocation `String`
  - RouteFilterName `String`
  - RouteFilterTag `IResourceTags`
  - RouteFilterType `String`
  - Rule `IRouteFilterRule[]`
  - SecondaryPeerAddressPrefix `String`
  - State `ExpressRouteCircuitPeeringState?`

### IssueContext [Api20190201]
  - Item `String`

### ListHubVirtualNetworkConnectionsResult [Api20190201]
  - NextLink `String`
  - Value `IHubVirtualNetworkConnection[]`

### ListP2SVpnGatewaysResult [Api20190201]
  - NextLink `String`
  - Value `IP2SVpnGateway[]`

### ListP2SVpnServerConfigurationsResult [Api20190201]
  - NextLink `String`
  - Value `IP2SVpnServerConfiguration[]`

### ListVirtualHubsResult [Api20190201]
  - NextLink `String`
  - Value `IVirtualHub[]`

### ListVirtualWaNsResult [Api20190201]
  - NextLink `String`
  - Value `IVirtualWan[]`

### ListVpnConnectionsResult [Api20190201]
  - NextLink `String`
  - Value `IVpnConnection[]`

### ListVpnGatewaysResult [Api20190201]
  - NextLink `String`
  - Value `IVpnGateway[]`

### ListVpnSitesResult [Api20190201]
  - NextLink `String`
  - Value `IVpnSite[]`

### LoadBalancer [Api20171001, Api20190201]
  - BackendAddressPool `IBackendAddressPool[]`
  - Etag `String`
  - FrontendIPConfiguration `IFrontendIPConfiguration[]`
  - Id `String`
  - InboundNatPool `IInboundNatPool[]`
  - InboundNatRule `IInboundNatRule[]`
  - LoadBalancingRule `ILoadBalancingRule[]`
  - Location `String`
  - Name `String`
  - OutboundNatRule `IOutboundNatRule[]`
  - OutboundRule `IOutboundRule[]`
  - Probe `IProbe[]`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SkuName `LoadBalancerSkuName?`
  - Tag `IResourceTags`
  - Type `String`

### LoadBalancerBackendAddressPoolListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IBackendAddressPool[]`

### LoadBalancerFrontendIPConfigurationListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IFrontendIPConfiguration[]`

### LoadBalancerListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `ILoadBalancer[]`

### LoadBalancerLoadBalancingRuleListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `ILoadBalancingRule[]`

### LoadBalancerOutboundRuleListResult [Api20190201]
  - NextLink `String`
  - Value `IOutboundRule[]`

### LoadBalancerProbeListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IProbe[]`

### LoadBalancerPropertiesFormat [Api20171001, Api20190201]
  - BackendAddressPool `IBackendAddressPool[]`
  - FrontendIPConfiguration `IFrontendIPConfiguration[]`
  - InboundNatPool `IInboundNatPool[]`
  - InboundNatRule `IInboundNatRule[]`
  - LoadBalancingRule `ILoadBalancingRule[]`
  - OutboundNatRule `IOutboundNatRule[]`
  - OutboundRule `IOutboundRule[]`
  - Probe `IProbe[]`
  - ProvisioningState `String`
  - ResourceGuid `String`

### LoadBalancerSku [Api20171001]
  - Name `LoadBalancerSkuName?`

### LoadBalancingRule [Api20171001, Api20190201]
  - BackendAddressPoolId `String`
  - BackendPort `Int32?`
  - DisableOutboundSnat `Boolean?`
  - EnableFloatingIP `Boolean?`
  - EnableTcpReset `Boolean?`
  - Etag `String`
  - FrontendIPConfigurationId `String`
  - FrontendPort `Int32`
  - Id `String`
  - IdleTimeoutInMinutes `Int32?`
  - LoadDistribution `LoadDistribution?`
  - Name `String`
  - ProbeId `String`
  - Protocol `TransportProtocol`
  - ProvisioningState `String`

### LoadBalancingRulePropertiesFormat [Api20171001, Api20190201]
  - BackendAddressPoolId `String`
  - BackendPort `Int32?`
  - DisableOutboundSnat `Boolean?`
  - EnableFloatingIP `Boolean?`
  - EnableTcpReset `Boolean?`
  - FrontendIPConfigurationId `String`
  - FrontendPort `Int32`
  - IdleTimeoutInMinutes `Int32?`
  - LoadDistribution `LoadDistribution?`
  - ProbeId `String`
  - Protocol `TransportProtocol`
  - ProvisioningState `String`

### LocalNetworkGateway [Api20171001]
  - AddressPrefix `String[]`
  - BgpAsn `Int64?`
  - BgpPeeringAddress `String`
  - BgpPeerWeight `Int32?`
  - Etag `String`
  - GatewayIPAddress `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Tag `IResourceTags`
  - Type `String`

### LocalNetworkGatewayListResult [Api20171001]
  - NextLink `String`
  - Value `ILocalNetworkGateway[]`

### LocalNetworkGatewayPropertiesFormat [Api20171001]
  - BgpSettingAsn `Int64?`
  - BgpSettingBgpPeeringAddress `String`
  - BgpSettingPeerWeight `Int32?`
  - GatewayIPAddress `String`
  - LocalNetworkAddressSpaceAddressPrefix `String[]`
  - ProvisioningState `String`
  - ResourceGuid `String`

### LogSpecification [Api20171001]
  - BlobDuration `String`
  - DisplayName `String`
  - Name `String`

### ManagedServiceIdentity [Api20190201]
  - PrincipalId `String`
  - TenantId `String`
  - Type `ResourceIdentityType?`
  - UserAssignedIdentity `IManagedServiceIdentityUserAssignedIdentities`

### ManagedServiceIdentityUserAssignedIdentities [Api20190201]
  - Item `IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties`

### MatchCondition [Api20190201]
  - MatchValue `String[]`
  - MatchVariable `IMatchVariable[]`
  - NegationConditon `Boolean?`
  - Operator `WebApplicationFirewallOperator`
  - Transform `WebApplicationFirewallTransform[]`

### MatchedRule [Api20190201]
  - Action `String`
  - RuleName `String`

### MatchVariable [Api20190201]
  - Selector `String`
  - VariableName `WebApplicationFirewallMatchVariable`

### MetricSpecification [Api20171001]
  - AggregationType `String`
  - Availability `IAvailability[]`
  - Dimension `IDimension[]`
  - DisplayDescription `String`
  - DisplayName `String`
  - EnableRegionalMdmAccount `Boolean?`
  - FillGapWithZero `Boolean?`
  - IsInternal `Boolean?`
  - MetricFilterPattern `String`
  - Name `String`
  - ResourceIdDimensionNameOverride `String`
  - SourceMdmAccount `String`
  - SourceMdmNamespace `String`
  - Unit `String`

### NatGateway [Api20190201]
  - Etag `String`
  - Id `String`
  - IdleTimeoutInMinutes `Int32?`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - PublicIPAddress `ISubResource[]`
  - PublicIPPrefix `ISubResource[]`
  - ResourceGuid `String`
  - SkuName `NatGatewaySkuName?`
  - Subnet `ISubResource[]`
  - Tag `IResourceTags`
  - Type `String`

### NatGatewayListResult [Api20190201]
  - NextLink `String`
  - Value `INatGateway[]`

### NatGatewayPropertiesFormat [Api20190201]
  - IdleTimeoutInMinutes `Int32?`
  - ProvisioningState `String`
  - PublicIPAddress `ISubResource[]`
  - PublicIPPrefix `ISubResource[]`
  - ResourceGuid `String`
  - Subnet `ISubResource[]`

### NatGatewaySku [Api20190201]
  - Name `NatGatewaySkuName?`

### NetworkConfigurationDiagnosticParameters [Api20190201]
  - Profile `INetworkConfigurationDiagnosticProfile[]`
  - TargetResourceId `String`
  - VerbosityLevel `VerbosityLevel?`

### NetworkConfigurationDiagnosticProfile [Api20190201]
  - Destination `String`
  - DestinationPort `String`
  - Direction `Direction`
  - Protocol `String`
  - Source `String`

### NetworkConfigurationDiagnosticResponse [Api20190201]
  - Result `INetworkConfigurationDiagnosticResult[]`

### NetworkConfigurationDiagnosticResult [Api20190201]
  - NsgResultEvaluatedNsg `IEvaluatedNetworkSecurityGroup[]`
  - NsgResultSecurityRuleAccessResult `SecurityRuleAccess?`
  - ProfileDestination `String`
  - ProfileDestinationPort `String`
  - ProfileDirection `Direction`
  - ProfileProtocol `String`
  - ProfileSource `String`

### NetworkIdentity [Models]
  - ApplicationGatewayName `String`
  - ApplicationSecurityGroupName `String`
  - AuthorizationName `String`
  - AzureFirewallName `String`
  - BackendAddressPoolName `String`
  - CircuitName `String`
  - ConnectionMonitorName `String`
  - ConnectionName `String`
  - CrossConnectionName `String`
  - DdosCustomPolicyName `String`
  - DdosProtectionPlanName `String`
  - DefaultSecurityRuleName `String`
  - DevicePath `String`
  - ExpressRouteGatewayName `String`
  - ExpressRoutePortName `String`
  - FrontendIPConfigurationName `String`
  - GatewayName `String`
  - Id `String`
  - InboundNatRuleName `String`
  - InterfaceEndpointName `String`
  - IPConfigurationName `String`
  - LinkName `String`
  - LoadBalancerName `String`
  - LoadBalancingRuleName `String`
  - LocalNetworkGatewayName `String`
  - Location `String`
  - LocationName `String`
  - NatGatewayName `String`
  - NetworkInterfaceName `String`
  - NetworkProfileName `String`
  - NetworkWatcherName `String`
  - NsgName `String`
  - OutboundRuleName `String`
  - P2SVpnServerConfigurationName `String`
  - PacketCaptureName `String`
  - PeeringName `String`
  - PolicyName `String`
  - PredefinedPolicyName `String`
  - ProbeName `String`
  - PublicIPAddressName `String`
  - PublicIPPrefixName `String`
  - ResourceGroupName `String`
  - RouteFilterName `String`
  - RouteName `String`
  - RouteTableName `String`
  - RuleName `String`
  - SecurityRuleName `String`
  - ServiceEndpointPolicyDefinitionName `String`
  - ServiceEndpointPolicyName `String`
  - SubnetName `String`
  - SubscriptionId `String`
  - TapConfigurationName `String`
  - TapName `String`
  - VirtualHubName `String`
  - VirtualmachineIndex `String`
  - VirtualMachineScaleSetName `String`
  - VirtualWanName `String`
  - VirtualWanName1 `String`
  - VirtualWanName2 `String`
  - VnetGatewayConnectionName `String`
  - VnetGatewayName `String`
  - VnetName `String`
  - VnetPeeringName `String`
  - VpnSiteName `String`

### NetworkIntentPolicy [Api20190201]
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - Tag `IResourceTags`
  - Type `String`

### NetworkIntentPolicyConfiguration [Api20190201]
  - NetworkIntentPolicyName `String`
  - SourceNetworkIntentPolicyEtag `String`
  - SourceNetworkIntentPolicyId `String`
  - SourceNetworkIntentPolicyLocation `String`
  - SourceNetworkIntentPolicyName `String`
  - SourceNetworkIntentPolicyTag `IResourceTags`
  - SourceNetworkIntentPolicyType `String`

### NetworkInterface [Api20171001, Api20190201]
  - AppliedDnsServer `String[]`
  - DnsServer `String[]`
  - EnableAcceleratedNetworking `Boolean?`
  - EnableIPForwarding `Boolean?`
  - Etag `String`
  - HostedWorkload `String[]`
  - Id `String`
  - InterfaceEndpoint `IInterfaceEndpoint`
  - InternalDnsNameLabel `String`
  - InternalDomainNameSuffix `String`
  - InternalFqdn `String`
  - IPConfiguration `INetworkInterfaceIPConfiguration[]`
  - Location `String`
  - MacAddress `String`
  - Name `String`
  - Nsg `INetworkSecurityGroup`
  - Primary `Boolean?`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Tag `IResourceTags`
  - TapConfiguration `INetworkInterfaceTapConfiguration[]`
  - Type `String`
  - VirtualMachineId `String`

### NetworkInterfaceAssociation [Api20190201]
  - Id `String`
  - SecurityRule `ISecurityRule[]`

### NetworkInterfaceDnsSettings [Api20171001]
  - AppliedDnsServer `String[]`
  - DnsServer `String[]`
  - InternalDnsNameLabel `String`
  - InternalDomainNameSuffix `String`
  - InternalFqdn `String`

### NetworkInterfaceIPConfiguration [Api20171001, Api20190201]
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - Etag `String`
  - Id `String`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - Name `String`
  - Primary `Boolean?`
  - PrivateIPAddress `String`
  - PrivateIPAddressVersion `IPVersion?`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - Subnet `ISubnet`
  - VnetTap `IVirtualNetworkTap[]`

### NetworkInterfaceIPConfigurationListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `INetworkInterfaceIPConfiguration[]`

### NetworkInterfaceIPConfigurationPropertiesFormat [Api20171001, Api20190201]
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - Primary `Boolean?`
  - PrivateIPAddress `String`
  - PrivateIPAddressVersion `IPVersion?`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - Subnet `ISubnet`
  - VnetTap `IVirtualNetworkTap[]`

### NetworkInterfaceListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `INetworkInterface[]`

### NetworkInterfaceLoadBalancerListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `ILoadBalancer[]`

### NetworkInterfacePropertiesFormat [Api20171001, Api20190201]
  - DnsSettingAppliedDnsServer `String[]`
  - DnsSettingDnsServer `String[]`
  - DnsSettingInternalDnsNameLabel `String`
  - DnsSettingInternalDomainNameSuffix `String`
  - DnsSettingInternalFqdn `String`
  - EnableAcceleratedNetworking `Boolean?`
  - EnableIPForwarding `Boolean?`
  - HostedWorkload `String[]`
  - InterfaceEndpoint `IInterfaceEndpoint`
  - IPConfiguration `INetworkInterfaceIPConfiguration[]`
  - MacAddress `String`
  - Nsg `INetworkSecurityGroup`
  - Primary `Boolean?`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - TapConfiguration `INetworkInterfaceTapConfiguration[]`
  - VirtualMachineId `String`

### NetworkInterfaceTapConfiguration [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Type `String`
  - VnetTap `IVirtualNetworkTap`

### NetworkInterfaceTapConfigurationListResult [Api20190201]
  - NextLink `String`
  - Value `INetworkInterfaceTapConfiguration[]`

### NetworkInterfaceTapConfigurationPropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - VnetTap `IVirtualNetworkTap`

### NetworkProfile [Api20190201]
  - ContainerNetworkInterface `IContainerNetworkInterface[]`
  - ContainerNetworkInterfaceConfiguration `IContainerNetworkInterfaceConfiguration[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Tag `IResourceTags`
  - Type `String`

### NetworkProfileListResult [Api20190201]
  - NextLink `String`
  - Value `INetworkProfile[]`

### NetworkProfilePropertiesFormat [Api20190201]
  - ContainerNetworkInterface `IContainerNetworkInterface[]`
  - ContainerNetworkInterfaceConfiguration `IContainerNetworkInterfaceConfiguration[]`
  - ProvisioningState `String`
  - ResourceGuid `String`

### NetworkSecurityGroup [Api20171001, Api20190201]
  - DefaultSecurityRule `ISecurityRule[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - NetworkInterface `INetworkInterface[]`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SecurityRule `ISecurityRule[]`
  - Subnet `ISubnet[]`
  - Tag `IResourceTags`
  - Type `String`

### NetworkSecurityGroupListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `INetworkSecurityGroup[]`

### NetworkSecurityGroupPropertiesFormat [Api20171001, Api20190201]
  - DefaultSecurityRule `ISecurityRule[]`
  - NetworkInterface `INetworkInterface[]`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SecurityRule `ISecurityRule[]`
  - Subnet `ISubnet[]`

### NetworkSecurityGroupResult [Api20190201]
  - EvaluatedNsg `IEvaluatedNetworkSecurityGroup[]`
  - SecurityRuleAccessResult `SecurityRuleAccess?`

### NetworkSecurityRulesEvaluationResult [Api20190201]
  - DestinationMatched `Boolean?`
  - DestinationPortMatched `Boolean?`
  - Name `String`
  - ProtocolMatched `Boolean?`
  - SourceMatched `Boolean?`
  - SourcePortMatched `Boolean?`

### NetworkWatcher [Api20171001, Api20190201]
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `ProvisioningState?`
  - Tag `IResourceTags`
  - Type `String`

### NetworkWatcherListResult [Api20190201]
  - Value `INetworkWatcher[]`

### NetworkWatcherPropertiesFormat [Api20171001, Api20190201]
  - ProvisioningState `ProvisioningState?`

### NextHopParameters [Api20190201]
  - DestinationIPAddress `String`
  - SourceIPAddress `String`
  - TargetNicResourceId `String`
  - TargetResourceId `String`

### NextHopResult [Api20190201]
  - NextHopIPAddress `String`
  - NextHopType `NextHopType?`
  - RouteTableId `String`

### Operation [Api20171001]
  - DisplayDescription `String`
  - DisplayOperation `String`
  - DisplayProvider `String`
  - DisplayResource `String`
  - Name `String`
  - Origin `String`
  - ServiceSpecificationLogSpecification `ILogSpecification[]`
  - ServiceSpecificationMetricSpecification `IMetricSpecification[]`

### OperationDisplay [Api20171001]
  - Description `String`
  - Operation `String`
  - Provider `String`
  - Resource `String`

### OperationListResult [Api20171001]
  - NextLink `String`
  - Value `IOperation[]`

### OperationPropertiesFormat [Api20171001]
  - ServiceSpecificationLogSpecification `ILogSpecification[]`
  - ServiceSpecificationMetricSpecification `IMetricSpecification[]`

### OperationPropertiesFormatServiceSpecification [Api20171001]
  - LogSpecification `ILogSpecification[]`
  - MetricSpecification `IMetricSpecification[]`

### OutboundNatRule [Api20171001]
  - AllocatedOutboundPort `Int32?`
  - BackendAddressPoolId `String`
  - Etag `String`
  - FrontendIPConfiguration `ISubResource[]`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`

### OutboundNatRulePropertiesFormat [Api20171001]
  - AllocatedOutboundPort `Int32?`
  - BackendAddressPoolId `String`
  - FrontendIPConfiguration `ISubResource[]`
  - ProvisioningState `String`

### OutboundRule [Api20190201]
  - AllocatedOutboundPort `Int32?`
  - BackendAddressPoolId `String`
  - EnableTcpReset `Boolean?`
  - Etag `String`
  - FrontendIPConfiguration `ISubResource[]`
  - Id `String`
  - IdleTimeoutInMinutes `Int32?`
  - Name `String`
  - Protocol `LoadBalancerOutboundRuleProtocol`
  - ProvisioningState `String`

### OutboundRulePropertiesFormat [Api20190201]
  - AllocatedOutboundPort `Int32?`
  - BackendAddressPoolId `String`
  - EnableTcpReset `Boolean?`
  - FrontendIPConfiguration `ISubResource[]`
  - IdleTimeoutInMinutes `Int32?`
  - Protocol `LoadBalancerOutboundRuleProtocol`
  - ProvisioningState `String`

### P2SVpnGateway [Api20190201]
  - CustomRouteAddressPrefix `String[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - P2SVpnServerConfigurationId `String`
  - ProvisioningState `ProvisioningState?`
  - ScaleUnit `Int32?`
  - Tag `IResourceTags`
  - Type `String`
  - VirtualHubId `String`
  - VpnClientAddressPrefix `String[]`
  - VpnClientAllocatedIPAddress `String[]`
  - VpnClientConnectionCount `Int32?`
  - VpnClientEgressBytesTransferred `Int64?`
  - VpnClientIngressBytesTransferred `Int64?`

### P2SVpnGatewayProperties [Api20190201]
  - CustomRouteAddressPrefix `String[]`
  - P2SVpnServerConfigurationId `String`
  - ProvisioningState `ProvisioningState?`
  - VirtualHubId `String`
  - VpnClientAddressPoolAddressPrefix `String[]`
  - VpnClientConnectionHealthAllocatedIPAddress `String[]`
  - VpnClientConnectionHealthTotalEgressBytesTransferred `Int64?`
  - VpnClientConnectionHealthTotalIngressBytesTransferred `Int64?`
  - VpnClientConnectionHealthVpnClientConnectionsCount `Int32?`
  - VpnGatewayScaleUnit `Int32?`

### P2SVpnProfileParameters [Api20190201]
  - AuthenticationMethod `AuthenticationMethod?`

### P2SVpnServerConfigRadiusClientRootCertificate [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Thumbprint `String`

### P2SVpnServerConfigRadiusClientRootCertificatePropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - Thumbprint `String`

### P2SVpnServerConfigRadiusServerRootCertificate [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - PublicCertData `String`

### P2SVpnServerConfigRadiusServerRootCertificatePropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - PublicCertData `String`

### P2SVpnServerConfiguration [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - P2SVpnGateway `ISubResource[]`
  - P2SVpnServerConfigRadiusClientRootCertificate `IP2SVpnServerConfigRadiusClientRootCertificate[]`
  - P2SVpnServerConfigRadiusServerRootCertificate `IP2SVpnServerConfigRadiusServerRootCertificate[]`
  - P2SVpnServerConfigVpnClientRevokedCertificate `IP2SVpnServerConfigVpnClientRevokedCertificate[]`
  - P2SVpnServerConfigVpnClientRootCertificate `IP2SVpnServerConfigVpnClientRootCertificate[]`
  - PropertiesEtag `String`
  - PropertiesName `String`
  - ProvisioningState `String`
  - RadiusServerAddress `String`
  - RadiusServerSecret `String`
  - VpnClientIpsecPolicy `IIpsecPolicy[]`
  - VpnProtocol `VpnGatewayTunnelingProtocol[]`

### P2SVpnServerConfigurationProperties [Api20190201]
  - Etag `String`
  - Name `String`
  - P2SVpnGateway `ISubResource[]`
  - P2SVpnServerConfigRadiusClientRootCertificate `IP2SVpnServerConfigRadiusClientRootCertificate[]`
  - P2SVpnServerConfigRadiusServerRootCertificate `IP2SVpnServerConfigRadiusServerRootCertificate[]`
  - P2SVpnServerConfigVpnClientRevokedCertificate `IP2SVpnServerConfigVpnClientRevokedCertificate[]`
  - P2SVpnServerConfigVpnClientRootCertificate `IP2SVpnServerConfigVpnClientRootCertificate[]`
  - ProvisioningState `String`
  - RadiusServerAddress `String`
  - RadiusServerSecret `String`
  - VpnClientIpsecPolicy `IIpsecPolicy[]`
  - VpnProtocol `VpnGatewayTunnelingProtocol[]`

### P2SVpnServerConfigVpnClientRevokedCertificate [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Thumbprint `String`

### P2SVpnServerConfigVpnClientRevokedCertificatePropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - Thumbprint `String`

### P2SVpnServerConfigVpnClientRootCertificate [Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - PublicCertData `String`

### P2SVpnServerConfigVpnClientRootCertificatePropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - PublicCertData `String`

### PacketCapture [Api20190201]
  - BytesToCapturePerPacket `Int32?`
  - Filter `IPacketCaptureFilter[]`
  - StorageLocationFilePath `String`
  - StorageLocationStorageId `String`
  - StorageLocationStoragePath `String`
  - Target `String`
  - TimeLimitInSeconds `Int32?`
  - TotalBytesPerSession `Int32?`

### PacketCaptureFilter [Api20190201]
  - LocalIPAddress `String`
  - LocalPort `String`
  - Protocol `PcProtocol?`
  - RemoteIPAddress `String`
  - RemotePort `String`

### PacketCaptureListResult [Api20190201]
  - Value `IPacketCaptureResult[]`

### PacketCaptureParameters [Api20190201]
  - BytesToCapturePerPacket `Int32?`
  - Filter `IPacketCaptureFilter[]`
  - StorageLocationFilePath `String`
  - StorageLocationStorageId `String`
  - StorageLocationStoragePath `String`
  - Target `String`
  - TimeLimitInSeconds `Int32?`
  - TotalBytesPerSession `Int32?`

### PacketCaptureQueryStatusResult [Api20190201]
  - CaptureStartTime `DateTime?`
  - Id `String`
  - Name `String`
  - PacketCaptureError `PcError[]`
  - PacketCaptureStatus `PcStatus?`
  - StopReason `String`

### PacketCaptureResult [Api20190201]
  - BytesToCapturePerPacket `Int32?`
  - Etag `String`
  - Filter `IPacketCaptureFilter[]`
  - Id `String`
  - Name `String`
  - ProvisioningState `ProvisioningState?`
  - StorageLocationFilePath `String`
  - StorageLocationStorageId `String`
  - StorageLocationStoragePath `String`
  - Target `String`
  - TimeLimitInSeconds `Int32?`
  - TotalBytesPerSession `Int32?`

### PacketCaptureResultProperties [Api20190201]
  - BytesToCapturePerPacket `Int32?`
  - Filter `IPacketCaptureFilter[]`
  - ProvisioningState `ProvisioningState?`
  - StorageLocation `IPacketCaptureStorageLocation`
  - StorageLocationFilePath `String`
  - StorageLocationStorageId `String`
  - StorageLocationStoragePath `String`
  - Target `String`
  - TimeLimitInSeconds `Int32?`
  - TotalBytesPerSession `Int32?`

### PacketCaptureStorageLocation [Api20190201]
  - FilePath `String`
  - StorageId `String`
  - StoragePath `String`

### PatchRouteFilter [Api20171001, Api20190201]
  - Etag `String`
  - Id `String`
  - Name `String`
  - Peering `IExpressRouteCircuitPeering[]`
  - ProvisioningState `String`
  - Rule `IRouteFilterRule[]`
  - Tag `IPatchRouteFilterTags`
  - Type `String`

### PatchRouteFilterRule [Api20171001, Api20190201]
  - Access `Access`
  - Community `String[]`
  - Etag `String`
  - Id `String`
  - Name `String`
  - Property `IRouteFilterRulePropertiesFormat`
  - ProvisioningState `String`
  - RouteFilterRuleType `String`
  - Tag `IPatchRouteFilterRuleTags`

### PatchRouteFilterRuleTags [Api20171001]
  - Item `String`

### PatchRouteFilterTags [Api20171001]
  - Item `String`

### PeerExpressRouteCircuitConnection [Api20190201]
  - AddressPrefix `String`
  - AuthResourceGuid `String`
  - CircuitConnectionStatus `CircuitConnectionStatus?`
  - ConnectionName `String`
  - Etag `String`
  - ExpressRouteCircuitPeeringId `String`
  - Id `String`
  - Name `String`
  - PeerExpressRouteCircuitPeeringId `String`
  - ProvisioningState `String`

### PeerExpressRouteCircuitConnectionListResult [Api20190201]
  - NextLink `String`
  - Value `IPeerExpressRouteCircuitConnection[]`

### PeerExpressRouteCircuitConnectionPropertiesFormat [Api20190201]
  - AddressPrefix `String`
  - AuthResourceGuid `String`
  - CircuitConnectionStatus `CircuitConnectionStatus?`
  - ConnectionName `String`
  - ExpressRouteCircuitPeeringId `String`
  - PeerExpressRouteCircuitPeeringId `String`
  - ProvisioningState `String`

### PolicySettings [Api20190201]
  - EnabledState `WebApplicationFirewallEnabledState?`
  - Mode `WebApplicationFirewallMode?`

### PrepareNetworkPoliciesRequest [Api20190201]
  - NetworkIntentPolicyConfiguration `INetworkIntentPolicyConfiguration[]`
  - ResourceGroupName `String`
  - ServiceName `String`

### Probe [Api20171001, Api20190201]
  - Etag `String`
  - Id `String`
  - IntervalInSeconds `Int32?`
  - LoadBalancingRule `ISubResource[]`
  - Name `String`
  - NumberOfProbe `Int32?`
  - Port `Int32`
  - Protocol `ProbeProtocol`
  - ProvisioningState `String`
  - RequestPath `String`

### ProbePropertiesFormat [Api20171001, Api20190201]
  - IntervalInSeconds `Int32?`
  - LoadBalancingRule `ISubResource[]`
  - NumberOfProbe `Int32?`
  - Port `Int32`
  - Protocol `ProbeProtocol`
  - ProvisioningState `String`
  - RequestPath `String`

### ProtocolConfiguration [Api20190201]
  - HttpConfigurationHeader `IHttpHeader[]`
  - HttpConfigurationMethod `HttpMethod?`
  - HttpConfigurationValidStatusCode `Int32[]`

### ProtocolCustomSettingsFormat [Api20190201]
  - Protocol `DdosCustomPolicyProtocol?`
  - SourceRateOverride `String`
  - TriggerRateOverride `String`
  - TriggerSensitivityOverride `DdosCustomPolicyTriggerSensitivityOverride?`

### PublicIPAddress [Api20171001, Api20190201]
  - AllocationMethod `IPAllocationMethod?`
  - DdosCustomPolicyId `String`
  - DdosProtectionCoverage `DdosSettingsProtectionCoverage?`
  - DnsSettingDomainNameLabel `String`
  - DnsSettingFqdn `String`
  - DnsSettingReverseFqdn `String`
  - Etag `String`
  - Id `String`
  - IdleTimeoutInMinutes `Int32?`
  - InnerPublicIPAddress `IPublicIPAddress`
  - IPAddress `String`
  - IPAddressVersion `IPVersion?`
  - IPConfigurationEtag `String`
  - IPConfigurationFormat `IIPConfigurationPropertiesFormat`
  - IPConfigurationId `String`
  - IPConfigurationName `String`
  - IPConfigurationProvisioningState `String`
  - IPTag `IIPTag[]`
  - Location `String`
  - Name `String`
  - PrefixId `String`
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SkuName `PublicIPAddressSkuName?`
  - Subnet `ISubnet`
  - Tag `IResourceTags`
  - Type `String`
  - Zone `String[]`

### PublicIPAddressDnsSettings [Api20171001]
  - DomainNameLabel `String`
  - Fqdn `String`
  - ReverseFqdn `String`

### PublicIPAddressListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IPublicIPAddress[]`

### PublicIPAddressPropertiesFormat [Api20171001, Api20190201]
  - DdosCustomPolicyId `String`
  - DdosSettingProtectionCoverage `DdosSettingsProtectionCoverage?`
  - DnsSettingDomainNameLabel `String`
  - DnsSettingFqdn `String`
  - DnsSettingReverseFqdn `String`
  - IdleTimeoutInMinutes `Int32?`
  - IPAddress `String`
  - IPConfigurationEtag `String`
  - IPConfigurationId `String`
  - IPConfigurationName `String`
  - IPConfigurationPropertiesProvisioningState `String`
  - IPConfigurationProperty `IIPConfigurationPropertiesFormat`
  - IPTag `IIPTag[]`
  - PrivateIPAddress `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddress `IPublicIPAddress`
  - PublicIPAddressVersion `IPVersion?`
  - PublicIPAllocationMethod `IPAllocationMethod?`
  - PublicIPPrefixId `String`
  - ResourceGuid `String`
  - Subnet `ISubnet`

### PublicIPAddressSku [Api20171001]
  - Name `PublicIPAddressSkuName?`

### PublicIPPrefix [Api20190201]
  - Etag `String`
  - Id `String`
  - IPPrefix `String`
  - IPTag `IIPTag[]`
  - Location `String`
  - Name `String`
  - PrefixLength `Int32?`
  - ProvisioningState `String`
  - PublicIPAddress `IReferencedPublicIPAddress[]`
  - PublicIPAddressVersion `IPVersion?`
  - ResourceGuid `String`
  - SkuName `PublicIPPrefixSkuName?`
  - Tag `IResourceTags`
  - Type `String`
  - Zone `String[]`

### PublicIPPrefixListResult [Api20190201]
  - NextLink `String`
  - Value `IPublicIPPrefix[]`

### PublicIPPrefixPropertiesFormat [Api20190201]
  - IPPrefix `String`
  - IPTag `IIPTag[]`
  - PrefixLength `Int32?`
  - ProvisioningState `String`
  - PublicIPAddress `IReferencedPublicIPAddress[]`
  - PublicIPAddressVersion `IPVersion?`
  - ResourceGuid `String`

### PublicIPPrefixSku [Api20190201]
  - Name `PublicIPPrefixSkuName?`

### QueryTroubleshootingParameters [Api20190201]
  - TargetResourceId `String`

### ReferencedPublicIPAddress [Api20190201]
  - Id `String`

### Resource [Api20171001]
  - Id `String`
  - Location `String`
  - Name `String`
  - Tag `IResourceTags`
  - Type `String`

### ResourceNavigationLink [Api20171001]
  - Etag `String`
  - Id `String`
  - Link `String`
  - LinkedResourceType `String`
  - Name `String`
  - ProvisioningState `String`

### ResourceNavigationLinkFormat [Api20171001]
  - Link `String`
  - LinkedResourceType `String`
  - ProvisioningState `String`

### ResourceTags [Api20171001]
  - Item `String`

### RetentionPolicyParameters [Api20190201]
  - Day `Int32?`
  - Enabled `Boolean?`

### Route [Api20171001]
  - AddressPrefix `String`
  - Etag `String`
  - Id `String`
  - Name `String`
  - NextHopIPAddress `String`
  - NextHopType `RouteNextHopType`
  - ProvisioningState `String`

### RouteFilter [Api20171001, Api20190201]
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - Peering `IExpressRouteCircuitPeering[]`
  - ProvisioningState `String`
  - Rule `IRouteFilterRule[]`
  - Tag `IResourceTags`
  - Type `String`

### RouteFilterListResult [Api20190201]
  - NextLink `String`
  - Value `IRouteFilter[]`

### RouteFilterPropertiesFormat [Api20171001, Api20190201]
  - Peering `IExpressRouteCircuitPeering[]`
  - ProvisioningState `String`
  - Rule `IRouteFilterRule[]`

### RouteFilterRule [Api20171001, Api20190201]
  - Access `Access`
  - Community `String[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - Property `IRouteFilterRulePropertiesFormat`
  - ProvisioningState `String`
  - Tag `IRouteFilterRuleTags`
  - Type `String`

### RouteFilterRuleListResult [Api20190201]
  - NextLink `String`
  - Value `IRouteFilterRule[]`

### RouteFilterRulePropertiesFormat [Api20171001]
  - Access `Access`
  - Community `String[]`
  - ProvisioningState `String`
  - RouteFilterRuleType `String`

### RouteFilterRuleTags [Api20171001]
  - Item `String`

### RouteListResult [Api20171001]
  - NextLink `String`
  - Value `IRoute[]`

### RoutePropertiesFormat [Api20171001]
  - AddressPrefix `String`
  - NextHopIPAddress `String`
  - NextHopType `RouteNextHopType`
  - ProvisioningState `String`

### RouteTable [Api20171001, Api20190201]
  - DisableBgpRoutePropagation `Boolean?`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - Route `IRoute[]`
  - Subnet `ISubnet[]`
  - Tag `IResourceTags`
  - Type `String`

### RouteTableListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IRouteTable[]`

### RouteTablePropertiesFormat [Api20171001, Api20190201]
  - DisableBgpRoutePropagation `Boolean?`
  - ProvisioningState `String`
  - Route `IRoute[]`
  - Subnet `ISubnet[]`

### SecurityGroupNetworkInterface [Api20190201]
  - Id `String`
  - NetworkInterfaceAssociationId `String`
  - NetworkInterfaceAssociationSecurityRule `ISecurityRule[]`
  - SecurityRuleAssociationDefaultSecurityRule `ISecurityRule[]`
  - SecurityRuleAssociationEffectiveSecurityRule `IEffectiveNetworkSecurityRule[]`
  - SubnetAssociationId `String`
  - SubnetAssociationSecurityRule `ISecurityRule[]`

### SecurityGroupViewParameters [Api20190201]
  - TargetResourceId `String`

### SecurityGroupViewResult [Api20190201]
  - NetworkInterface `ISecurityGroupNetworkInterface[]`

### SecurityRule [Api20171001, Api20190201]
  - Access `SecurityRuleAccess`
  - Description `String`
  - DestinationAddressPrefix `String`
  - DestinationApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - DestinationPortRange `String`
  - Direction `SecurityRuleDirection`
  - Etag `String`
  - Id `String`
  - Name `String`
  - Priority `Int32?`
  - PropertiesDestinationAddressPrefixes `String[]`
  - PropertiesDestinationPortRanges `String[]`
  - PropertiesSourceAddressPrefixes `String[]`
  - PropertiesSourcePortRanges `String[]`
  - Protocol `SecurityRuleProtocol`
  - ProvisioningState `String`
  - SourceAddressPrefix `String`
  - SourceApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - SourcePortRange `String`

### SecurityRuleAssociations [Api20190201]
  - DefaultSecurityRule `ISecurityRule[]`
  - EffectiveSecurityRule `IEffectiveNetworkSecurityRule[]`
  - NetworkInterfaceAssociationId `String`
  - NetworkInterfaceAssociationSecurityRule `ISecurityRule[]`
  - SubnetAssociationId `String`
  - SubnetAssociationSecurityRule `ISecurityRule[]`

### SecurityRuleListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `ISecurityRule[]`

### SecurityRulePropertiesFormat [Api20171001, Api20190201]
  - Access `SecurityRuleAccess`
  - Description `String`
  - DestinationAddressPrefix `String`
  - DestinationAddressPrefixes `String[]`
  - DestinationApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - DestinationPortRange `String`
  - DestinationPortRanges `String[]`
  - Direction `SecurityRuleDirection`
  - Priority `Int32?`
  - Protocol `SecurityRuleProtocol`
  - ProvisioningState `String`
  - SourceAddressPrefix `String`
  - SourceAddressPrefixes `String[]`
  - SourceApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - SourcePortRange `String`
  - SourcePortRanges `String[]`

### ServiceAssociationLink [Api20190201]
  - Etag `String`
  - Id `String`
  - Link `String`
  - LinkedResourceType `String`
  - Name `String`
  - ProvisioningState `String`

### ServiceAssociationLinkPropertiesFormat [Api20190201]
  - Link `String`
  - LinkedResourceType `String`
  - ProvisioningState `String`

### ServiceDelegationPropertiesFormat [Api20190201]
  - Action `String[]`
  - ProvisioningState `String`
  - ServiceName `String`

### ServiceEndpointPolicy [Api20190201]
  - Definition `IServiceEndpointPolicyDefinition[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Subnet `ISubnet[]`
  - Tag `IResourceTags`
  - Type `String`

### ServiceEndpointPolicyDefinition [Api20190201]
  - Description `String`
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Service `String`
  - ServiceResource `String[]`

### ServiceEndpointPolicyDefinitionListResult [Api20190201]
  - NextLink `String`
  - Value `IServiceEndpointPolicyDefinition[]`

### ServiceEndpointPolicyDefinitionPropertiesFormat [Api20190201]
  - Description `String`
  - ProvisioningState `String`
  - Service `String`
  - ServiceResource `String[]`

### ServiceEndpointPolicyListResult [Api20190201]
  - NextLink `String`
  - Value `IServiceEndpointPolicy[]`

### ServiceEndpointPolicyPropertiesFormat [Api20190201]
  - ProvisioningState `String`
  - ResourceGuid `String`
  - ServiceEndpointPolicyDefinition `IServiceEndpointPolicyDefinition[]`
  - Subnet `ISubnet[]`

### ServiceEndpointPropertiesFormat [Api20171001]
  - Location `String[]`
  - ProvisioningState `String`
  - Service `String`

### Subnet [Api20171001, Api20190201]
  - AddressPrefix `String[]`
  - Delegation `IDelegation[]`
  - Etag `String`
  - Id `String`
  - InterfaceEndpoint `IInterfaceEndpoint[]`
  - IPConfiguration `IIPConfiguration[]`
  - IPConfigurationProfile `IIPConfigurationProfile[]`
  - Name `String`
  - NatGatewayId `String`
  - Nsg `INetworkSecurityGroup`
  - PropertiesAddressPrefix `String`
  - ProvisioningState `String`
  - Purpose `String`
  - ResourceNavigationLink `IResourceNavigationLink[]`
  - RouteTable `IRouteTable`
  - ServiceAssociationLink `IServiceAssociationLink[]`
  - ServiceEndpoint `IServiceEndpointPropertiesFormat[]`
  - ServiceEndpointPolicy `IServiceEndpointPolicy[]`

### SubnetAssociation [Api20190201]
  - Id `String`
  - SecurityRule `ISecurityRule[]`

### SubnetListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `ISubnet[]`

### SubnetPropertiesFormat [Api20171001, Api20190201]
  - AddressPrefix `String`
  - AddressPrefixes `String[]`
  - Delegation `IDelegation[]`
  - InterfaceEndpoint `IInterfaceEndpoint[]`
  - IPConfiguration `IIPConfiguration[]`
  - IPConfigurationProfile `IIPConfigurationProfile[]`
  - NatGatewayId `String`
  - Nsg `INetworkSecurityGroup`
  - ProvisioningState `String`
  - Purpose `String`
  - ResourceNavigationLink `IResourceNavigationLink[]`
  - RouteTable `IRouteTable`
  - ServiceAssociationLink `IServiceAssociationLink[]`
  - ServiceEndpoint `IServiceEndpointPropertiesFormat[]`
  - ServiceEndpointPolicy `IServiceEndpointPolicy[]`

### SubResource [Api20171001]
  - Id `String`

### TagsObject [Api20171001]
  - Tag `ITagsObjectTags`

### TagsObjectTags [Api20171001]
  - Item `String`

### Topology [Api20190201]
  - CreatedDateTime `DateTime?`
  - Id `String`
  - LastModified `DateTime?`
  - Resource `ITopologyResource[]`

### TopologyAssociation [Api20190201]
  - AssociationType `AssociationType?`
  - Name `String`
  - ResourceId `String`

### TopologyParameters [Api20190201]
  - TargetResourceGroupName `String`
  - TargetSubnetId `String`
  - TargetVnetId `String`

### TopologyResource [Api20190201]
  - Association `ITopologyAssociation[]`
  - Id `String`
  - Location `String`
  - Name `String`

### TrafficAnalyticsConfigurationProperties [Api20190201]
  - Enabled `Boolean`
  - TrafficAnalyticsInterval `Int32?`
  - WorkspaceId `String`
  - WorkspaceRegion `String`
  - WorkspaceResourceId `String`

### TrafficAnalyticsProperties [Api20190201]
  - NetworkWatcherFlowAnalyticConfigurationEnabled `Boolean`
  - NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval `Int32?`
  - NetworkWatcherFlowAnalyticConfigurationWorkspaceId `String`
  - NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion `String`
  - NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId `String`

### TroubleshootingDetails [Api20190201]
  - Detail `String`
  - Id `String`
  - ReasonType `String`
  - RecommendedAction `ITroubleshootingRecommendedActions[]`
  - Summary `String`

### TroubleshootingParameters [Api20190201]
  - StorageId `String`
  - StoragePath `String`
  - TargetResourceId `String`

### TroubleshootingProperties [Api20190201]
  - StorageId `String`
  - StoragePath `String`

### TroubleshootingRecommendedActions [Api20190201]
  - ActionId `String`
  - ActionText `String`
  - ActionUri `String`
  - ActionUriText `String`

### TroubleshootingResult [Api20190201]
  - Code `String`
  - EndTime `DateTime?`
  - Result `ITroubleshootingDetails[]`
  - StartTime `DateTime?`

### TunnelConnectionHealth [Api20171001, Api20190201]
  - ConnectionStatus `VirtualNetworkGatewayConnectionStatus?`
  - EgressBytesTransferred `Int64?`
  - IngressBytesTransferred `Int64?`
  - LastConnectionEstablishedUtcTime `String`
  - Tunnel `String`

### Usage [Api20171001]
  - CurrentValue `Int64`
  - Id `String`
  - Limit `Int64`
  - NameLocalizedValue `String`
  - NameValue `String`
  - Unit `String`

### UsageName [Api20171001]
  - LocalizedValue `String`
  - Value `String`

### UsagesListResult [Api20171001]
  - NextLink `String`
  - Value `IUsage[]`

### VerificationIPFlowParameters [Api20190201]
  - Direction `Direction`
  - LocalIPAddress `String`
  - LocalPort `String`
  - Protocol `IPFlowProtocol`
  - RemoteIPAddress `String`
  - RemotePort `String`
  - TargetNicResourceId `String`
  - TargetResourceId `String`

### VerificationIPFlowResult [Api20190201]
  - Access `Access?`
  - RuleName `String`

### VirtualHub [Api20190201]
  - AddressPrefix `String`
  - Etag `String`
  - ExpressRouteGatewayId `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - P2SVpnGatewayId `String`
  - ProvisioningState `ProvisioningState?`
  - Route `IVirtualHubRoute[]`
  - Tag `IResourceTags`
  - Type `String`
  - VirtualWanId `String`
  - VnetConnection `IHubVirtualNetworkConnection[]`
  - VpnGatewayId `String`

### VirtualHubId [Api20190201]
  - Id `String`

### VirtualHubProperties [Api20190201]
  - AddressPrefix `String`
  - ExpressRouteGatewayId `String`
  - P2SVpnGatewayId `String`
  - ProvisioningState `ProvisioningState?`
  - RouteTableRoute `IVirtualHubRoute[]`
  - VirtualWanId `String`
  - VnetConnection `IHubVirtualNetworkConnection[]`
  - VpnGatewayId `String`

### VirtualHubRoute [Api20190201]
  - AddressPrefix `String[]`
  - NextHopIPAddress `String`

### VirtualHubRouteTable [Api20190201]
  - Route `IVirtualHubRoute[]`

### VirtualNetwork [Api20171001, Api20190201]
  - AddressPrefix `String[]`
  - DdosProtectionPlanId `String`
  - DnsServer `String[]`
  - EnableDdosProtection `Boolean?`
  - EnableVMProtection `Boolean?`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - Peering `IVirtualNetworkPeering[]`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Subnet `ISubnet[]`
  - Tag `IResourceTags`
  - Type `String`

### VirtualNetworkConnectionGatewayReference [Api20171001, Api20190201]
  - Id `String`

### VirtualNetworkGateway [Api20171001, Api20190201]
  - AddressPrefix `String[]`
  - BgpAsn `Int64?`
  - BgpPeeringAddress `String`
  - BgpPeerWeight `Int32?`
  - CustomRouteAddressPrefix `String[]`
  - EnableActiveActive `Boolean?`
  - EnableBgp `Boolean?`
  - Etag `String`
  - GatewayDefaultSiteId `String`
  - GatewayType `VirtualNetworkGatewayType?`
  - Id `String`
  - IPConfiguration `IVirtualNetworkGatewayIPConfiguration[]`
  - IPsecPolicy `IIpsecPolicy[]`
  - Location `String`
  - Name `String`
  - Protocol `VpnClientProtocol[]`
  - ProvisioningState `String`
  - RadiusServerAddress `String`
  - RadiusServerSecret `String`
  - ResourceGuid `String`
  - RevokedCertificate `IVpnClientRevokedCertificate[]`
  - RootCertificate `IVpnClientRootCertificate[]`
  - SkuCapacity `Int32?`
  - SkuName `VirtualNetworkGatewaySkuName?`
  - SkuTier `VirtualNetworkGatewaySkuTier?`
  - Tag `IResourceTags`
  - Type `String`
  - VpnType `VpnType?`

### VirtualNetworkGatewayConnection [Api20171001, Api20190201]
  - AuthorizationKey `String`
  - BypassExpressRouteGateway `Boolean?`
  - ConnectionProtocol `VirtualNetworkGatewayConnectionProtocol?`
  - ConnectionStatus `VirtualNetworkGatewayConnectionStatus?`
  - ConnectionType `VirtualNetworkGatewayConnectionType`
  - EgressBytesTransferred `Int64?`
  - EnableBgp `Boolean?`
  - Etag `String`
  - Id `String`
  - IngressBytesTransferred `Int64?`
  - IpsecPolicy `IIpsecPolicy[]`
  - LocalNetworkGateway2 `ILocalNetworkGateway`
  - Location `String`
  - Name `String`
  - PeerId `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - RoutingWeight `Int32?`
  - SharedKey `String`
  - Tag `IResourceTags`
  - TunnelConnectionStatus `ITunnelConnectionHealth[]`
  - Type `String`
  - UsePolicyBasedTrafficSelectors `Boolean?`
  - VnetGateway1 `IVirtualNetworkGateway`
  - VnetGateway2 `IVirtualNetworkGateway`

### VirtualNetworkGatewayConnectionListEntity [Api20171001, Api20190201]
  - AuthorizationKey `String`
  - ConnectionProtocol `VirtualNetworkGatewayConnectionProtocol?`
  - ConnectionStatus `VirtualNetworkGatewayConnectionStatus?`
  - ConnectionType `VirtualNetworkGatewayConnectionType`
  - EgressBytesTransferred `Int64?`
  - EnableBgp `Boolean?`
  - Etag `String`
  - ExpressRouteGatewayBypass `Boolean?`
  - Id `String`
  - IngressBytesTransferred `Int64?`
  - IpsecPolicy `IIpsecPolicy[]`
  - LocalNetworkGateway2Id `String`
  - Location `String`
  - Name `String`
  - PeerId `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - RoutingWeight `Int32?`
  - SharedKey `String`
  - Tag `IResourceTags`
  - TunnelConnectionStatus `ITunnelConnectionHealth[]`
  - Type `String`
  - UsePolicyBasedTrafficSelector `Boolean?`
  - VnetGateway1Id `String`
  - VnetGateway2Id `String`

### VirtualNetworkGatewayConnectionListEntityPropertiesFormat [Api20171001, Api20190201]
  - AuthorizationKey `String`
  - ConnectionProtocol `VirtualNetworkGatewayConnectionProtocol?`
  - ConnectionStatus `VirtualNetworkGatewayConnectionStatus?`
  - ConnectionType `VirtualNetworkGatewayConnectionType`
  - EgressBytesTransferred `Int64?`
  - EnableBgp `Boolean?`
  - ExpressRouteGatewayBypass `Boolean?`
  - IngressBytesTransferred `Int64?`
  - IpsecPolicy `IIpsecPolicy[]`
  - LocalNetworkGateway2Id `String`
  - PeerId `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - RoutingWeight `Int32?`
  - SharedKey `String`
  - TunnelConnectionStatus `ITunnelConnectionHealth[]`
  - UsePolicyBasedTrafficSelector `Boolean?`
  - VnetGateway1Id `String`
  - VnetGateway2Id `String`

### VirtualNetworkGatewayConnectionListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IVirtualNetworkGatewayConnection[]`

### VirtualNetworkGatewayConnectionPropertiesFormat [Api20171001, Api20190201]
  - AuthorizationKey `String`
  - ConnectionProtocol `VirtualNetworkGatewayConnectionProtocol?`
  - ConnectionStatus `VirtualNetworkGatewayConnectionStatus?`
  - ConnectionType `VirtualNetworkGatewayConnectionType`
  - EgressBytesTransferred `Int64?`
  - EnableBgp `Boolean?`
  - ExpressRouteGatewayBypass `Boolean?`
  - IngressBytesTransferred `Int64?`
  - IpsecPolicy `IIpsecPolicy[]`
  - LocalNetworkGateway2 `ILocalNetworkGateway`
  - PeerId `String`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - RoutingWeight `Int32?`
  - SharedKey `String`
  - TunnelConnectionStatus `ITunnelConnectionHealth[]`
  - UsePolicyBasedTrafficSelector `Boolean?`
  - VnetGateway1 `IVirtualNetworkGateway`
  - VnetGateway2 `IVirtualNetworkGateway`

### VirtualNetworkGatewayIPConfiguration [Api20171001]
  - Etag `String`
  - Id `String`
  - Name `String`
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddressId `String`
  - SubnetId `String`

### VirtualNetworkGatewayIPConfigurationPropertiesFormat [Api20171001]
  - PrivateIPAllocationMethod `IPAllocationMethod?`
  - ProvisioningState `String`
  - PublicIPAddressId `String`
  - SubnetId `String`

### VirtualNetworkGatewayListConnectionsResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IVirtualNetworkGatewayConnectionListEntity[]`

### VirtualNetworkGatewayListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IVirtualNetworkGateway[]`

### VirtualNetworkGatewayPropertiesFormat [Api20171001, Api20190201]
  - Active `Boolean?`
  - BgpSettingAsn `Int64?`
  - BgpSettingBgpPeeringAddress `String`
  - BgpSettingPeerWeight `Int32?`
  - CustomRouteAddressPrefix `String[]`
  - EnableBgp `Boolean?`
  - GatewayDefaultSiteId `String`
  - GatewayType `VirtualNetworkGatewayType?`
  - IPConfiguration `IVirtualNetworkGatewayIPConfiguration[]`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - SkuCapacity `Int32?`
  - SkuName `VirtualNetworkGatewaySkuName?`
  - SkuTier `VirtualNetworkGatewaySkuTier?`
  - VpnClientAddressPoolAddressPrefix `String[]`
  - VpnClientConfigurationRadiusServerAddress `String`
  - VpnClientConfigurationRadiusServerSecret `String`
  - VpnClientConfigurationVpnClientIpsecPolicy `IIpsecPolicy[]`
  - VpnClientConfigurationVpnClientProtocol `VpnClientProtocol[]`
  - VpnClientConfigurationVpnClientRevokedCertificate `IVpnClientRevokedCertificate[]`
  - VpnClientConfigurationVpnClientRootCertificate `IVpnClientRootCertificate[]`
  - VpnType `VpnType?`

### VirtualNetworkGatewaySku [Api20171001, Api20190201]
  - Capacity `Int32?`
  - Name `VirtualNetworkGatewaySkuName?`
  - Tier `VirtualNetworkGatewaySkuTier?`

### VirtualNetworkListResult [Api20171001, Api20190201]
  - NextLink `String`
  - Value `IVirtualNetwork[]`

### VirtualNetworkListUsageResult [Api20171001]
  - NextLink `String`
  - Value `IVirtualNetworkUsage[]`

### VirtualNetworkPeering [Api20171001]
  - AllowForwardedTraffic `Boolean?`
  - AllowGatewayTransit `Boolean?`
  - AllowVnetAccess `Boolean?`
  - Etag `String`
  - Id `String`
  - Name `String`
  - PeeringState `VirtualNetworkPeeringState?`
  - ProvisioningState `String`
  - RemoteAddressSpaceAddressPrefix `String[]`
  - RemoteVnetId `String`
  - UseRemoteGateway `Boolean?`

### VirtualNetworkPeeringListResult [Api20171001]
  - NextLink `String`
  - Value `IVirtualNetworkPeering[]`

### VirtualNetworkPeeringPropertiesFormat [Api20171001]
  - AllowForwardedTraffic `Boolean?`
  - AllowGatewayTransit `Boolean?`
  - AllowVnetAccess `Boolean?`
  - PeeringState `VirtualNetworkPeeringState?`
  - ProvisioningState `String`
  - RemoteAddressSpaceAddressPrefix `String[]`
  - RemoteVnetId `String`
  - UseRemoteGateway `Boolean?`

### VirtualNetworkPropertiesFormat [Api20171001, Api20190201]
  - AddressSpaceAddressPrefix `String[]`
  - DdosProtectionPlanId `String`
  - DhcpOptionDnsServer `String[]`
  - EnableDdosProtection `Boolean?`
  - EnableVMProtection `Boolean?`
  - ProvisioningState `String`
  - ResourceGuid `String`
  - Subnet `ISubnet[]`
  - VnetPeering `IVirtualNetworkPeering[]`

### VirtualNetworkTap [Api20190201]
  - AdditionalVnetTap `IVirtualNetworkTap[]`
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - DestinationLoadBalancerEtag `String`
  - DestinationLoadBalancerId `String`
  - DestinationLoadBalancerName `String`
  - DestinationLoadBalancerPrivateIPAddress `String`
  - DestinationLoadBalancerPrivateIPAllocationMethod `IPAllocationMethod?`
  - DestinationLoadBalancerProvisioningState `String`
  - DestinationLoadBalancerPublicIPAddress `IPublicIPAddress`
  - DestinationLoadBalancerSubnet `ISubnet`
  - DestinationLoadBalancerZone `String[]`
  - DestinationNetworkInterfaceEtag `String`
  - DestinationNetworkInterfaceId `String`
  - DestinationNetworkInterfaceName `String`
  - DestinationNetworkInterfacePrivateIPAddress `String`
  - DestinationNetworkInterfacePrivateIPAllocationMethod `IPAllocationMethod?`
  - DestinationNetworkInterfaceProvisioningState `String`
  - DestinationNetworkInterfacePublicIPAddress `IPublicIPAddress`
  - DestinationNetworkInterfaceSubnet `ISubnet`
  - DestinationPort `Int32?`
  - Etag `String`
  - Id `String`
  - InboundNatPool `ISubResource[]`
  - InboundNatRule `ISubResource[]`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - LoadBalancingRule `ISubResource[]`
  - Location `String`
  - Name `String`
  - NetworkInterfaceTapConfiguration `INetworkInterfaceTapConfiguration[]`
  - OutboundRule `ISubResource[]`
  - Primary `Boolean?`
  - PrivateIPAddressVersion `IPVersion?`
  - ProvisioningState `String`
  - PublicIPPrefixId `String`
  - ResourceGuid `String`
  - Tag `IResourceTags`
  - Type `String`

### VirtualNetworkTapListResult [Api20190201]
  - NextLink `String`
  - Value `IVirtualNetworkTap[]`

### VirtualNetworkTapPropertiesFormat [Api20190201]
  - ApplicationGatewayBackendAddressPool `IApplicationGatewayBackendAddressPool[]`
  - ApplicationSecurityGroup `IApplicationSecurityGroup[]`
  - DestinationLoadBalancerFrontEndIPConfigurationEtag `String`
  - DestinationLoadBalancerFrontEndIPConfigurationId `String`
  - DestinationLoadBalancerFrontEndIPConfigurationName `String`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpaddress `String`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpallocationMethod `IPAllocationMethod?`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesProvisioningState `String`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesPublicIpaddress `IPublicIPAddress`
  - DestinationLoadBalancerFrontEndIPConfigurationPropertiesSubnet `ISubnet`
  - DestinationLoadBalancerFrontEndIPConfigurationZone `String[]`
  - DestinationNetworkInterfaceIPConfigurationEtag `String`
  - DestinationNetworkInterfaceIPConfigurationId `String`
  - DestinationNetworkInterfaceIPConfigurationName `String`
  - DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpaddress `String`
  - DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpallocationMethod `IPAllocationMethod?`
  - DestinationNetworkInterfaceIPConfigurationPropertiesProvisioningState `String`
  - DestinationNetworkInterfaceIPConfigurationPropertiesPublicIpaddress `IPublicIPAddress`
  - DestinationNetworkInterfaceIPConfigurationPropertiesSubnet `ISubnet`
  - DestinationPort `Int32?`
  - InboundNatPool `ISubResource[]`
  - InboundNatRule `ISubResource[]`
  - LoadBalancerBackendAddressPool `IBackendAddressPool[]`
  - LoadBalancerInboundNatRule `IInboundNatRule[]`
  - LoadBalancingRule `ISubResource[]`
  - NetworkInterfaceTapConfiguration `INetworkInterfaceTapConfiguration[]`
  - OutboundRule `ISubResource[]`
  - Primary `Boolean?`
  - PrivateIPAddressVersion `IPVersion?`
  - ProvisioningState `String`
  - PublicIPPrefixId `String`
  - ResourceGuid `String`
  - VnetTap `IVirtualNetworkTap[]`

### VirtualNetworkUsage [Api20171001]
  - CurrentValue `Double?`
  - Id `String`
  - Limit `Double?`
  - NameLocalizedValue `String`
  - NameValue `String`
  - Unit `String`

### VirtualNetworkUsageName [Api20171001]
  - LocalizedValue `String`
  - Value `String`

### VirtualWan [Api20190201]
  - AllowBranchToBranchTraffic `Boolean?`
  - AllowVnetToVnetTraffic `Boolean?`
  - DisableVpnEncryption `Boolean?`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - Office365LocalBreakoutCategory `OfficeTrafficCategory?`
  - P2SVpnServerConfiguration `IP2SVpnServerConfiguration[]`
  - ProvisioningState `ProvisioningState?`
  - SecurityProviderName `String`
  - Tag `IResourceTags`
  - Type `String`
  - VirtualHub `ISubResource[]`
  - VpnSite `ISubResource[]`

### VirtualWanProperties [Api20190201]
  - AllowBranchToBranchTraffic `Boolean?`
  - AllowVnetToVnetTraffic `Boolean?`
  - DisableVpnEncryption `Boolean?`
  - Office365LocalBreakoutCategory `OfficeTrafficCategory?`
  - P2SVpnServerConfiguration `IP2SVpnServerConfiguration[]`
  - ProvisioningState `ProvisioningState?`
  - SecurityProviderName `String`
  - VirtualHub `ISubResource[]`
  - VpnSite `ISubResource[]`

### VirtualWanSecurityProvider [Api20190201]
  - Name `String`
  - Type `VirtualWanSecurityProviderType?`
  - Url `String`

### VirtualWanSecurityProviders [Api20190201]
  - SupportedProvider `IVirtualWanSecurityProvider[]`

### VpnClientConfiguration [Api20171001, Api20190201]
  - RadiusServerAddress `String`
  - RadiusServerSecret `String`
  - VpnClientAddressPoolAddressPrefix `String[]`
  - VpnClientIpsecPolicy `IIpsecPolicy[]`
  - VpnClientProtocol `VpnClientProtocol[]`
  - VpnClientRevokedCertificate `IVpnClientRevokedCertificate[]`
  - VpnClientRootCertificate `IVpnClientRootCertificate[]`

### VpnClientConnectionHealth [Api20190201]
  - AllocatedIPAddress `String[]`
  - TotalEgressBytesTransferred `Int64?`
  - TotalIngressBytesTransferred `Int64?`
  - VpnClientConnectionsCount `Int32?`

### VpnClientIPsecParameters [Api20190201]
  - DhGroup `DhGroup`
  - IkeEncryption `IkeEncryption`
  - IkeIntegrity `IkeIntegrity`
  - IpsecEncryption `IpsecEncryption`
  - IpsecIntegrity `IpsecIntegrity`
  - PfsGroup `PfsGroup`
  - SaDataSizeKilobyte `Int32`
  - SaLifeTimeSecond `Int32`

### VpnClientParameters [Api20171001]
  - AuthenticationMethod `AuthenticationMethod?`
  - ClientRootCertificate `String[]`
  - ProcessorArchitecture `ProcessorArchitecture?`
  - RadiusServerAuthCertificate `String`

### VpnClientRevokedCertificate [Api20171001]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Thumbprint `String`

### VpnClientRevokedCertificatePropertiesFormat [Api20171001]
  - ProvisioningState `String`
  - Thumbprint `String`

### VpnClientRootCertificate [Api20171001]
  - Etag `String`
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - PublicCertData `String`

### VpnClientRootCertificatePropertiesFormat [Api20171001]
  - ProvisioningState `String`
  - PublicCertData `String`

### VpnConnection [Api20190201]
  - ConnectionBandwidth `Int32?`
  - ConnectionStatus `VpnConnectionStatus?`
  - EgressBytesTransferred `Int64?`
  - EnableBgp `Boolean?`
  - EnableInternetSecurity `Boolean?`
  - EnableRateLimiting `Boolean?`
  - Etag `String`
  - Id `String`
  - IngressBytesTransferred `Int64?`
  - IpsecPolicy `IIpsecPolicy[]`
  - Name `String`
  - ProtocolType `VirtualNetworkGatewayConnectionProtocol?`
  - ProvisioningState `ProvisioningState?`
  - RemoteVpnSiteId `String`
  - RoutingWeight `Int32?`
  - SharedKey `String`
  - UseLocalAzureIPAddress `Boolean?`

### VpnConnectionProperties [Api20190201]
  - ConnectionBandwidth `Int32?`
  - ConnectionStatus `VpnConnectionStatus?`
  - EgressBytesTransferred `Int64?`
  - EnableBgp `Boolean?`
  - EnableInternetSecurity `Boolean?`
  - EnableRateLimiting `Boolean?`
  - IngressBytesTransferred `Int64?`
  - IpsecPolicy `IIpsecPolicy[]`
  - ProvisioningState `ProvisioningState?`
  - RemoteVpnSiteId `String`
  - RoutingWeight `Int32?`
  - SharedKey `String`
  - UseLocalAzureIPAddress `Boolean?`
  - VpnConnectionProtocolType `VirtualNetworkGatewayConnectionProtocol?`

### VpnDeviceScriptParameters [Api20171001]
  - DeviceFamily `String`
  - FirmwareVersion `String`
  - Vendor `String`

### VpnGateway [Api20190201]
  - BgpAsn `Int64?`
  - BgpPeeringAddress `String`
  - BgpPeerWeight `Int32?`
  - Connection `IVpnConnection[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - ProvisioningState `ProvisioningState?`
  - ScaleUnit `Int32?`
  - Tag `IResourceTags`
  - Type `String`
  - VirtualHubId `String`

### VpnGatewayProperties [Api20190201]
  - BgpSettingAsn `Int64?`
  - BgpSettingBgpPeeringAddress `String`
  - BgpSettingPeerWeight `Int32?`
  - Connection `IVpnConnection[]`
  - ProvisioningState `ProvisioningState?`
  - VirtualHubId `String`
  - VpnGatewayScaleUnit `Int32?`

### VpnProfileResponse [Api20190201]
  - ProfileUrl `String`

### VpnSite [Api20190201]
  - AddressPrefix `String[]`
  - BgpAsn `Int64?`
  - BgpPeeringAddress `String`
  - BgpPeerWeight `Int32?`
  - DeviceModel `String`
  - DeviceVendor `String`
  - Etag `String`
  - Id `String`
  - IPAddress `String`
  - LinkSpeedInMbps `Int32?`
  - Location `String`
  - Name `String`
  - ProvisioningState `ProvisioningState?`
  - SecuritySite `Boolean?`
  - SiteKey `String`
  - Tag `IResourceTags`
  - Type `String`
  - VirtualWanId `String`

### VpnSiteProperties [Api20190201]
  - AddressSpaceAddressPrefix `String[]`
  - BgpPropertyAsn `Int64?`
  - BgpPropertyBgpPeeringAddress `String`
  - BgpPropertyPeerWeight `Int32?`
  - DevicePropertyDeviceModel `String`
  - DevicePropertyDeviceVendor `String`
  - DevicePropertyLinkSpeedInMbps `Int32?`
  - IPAddress `String`
  - IsSecuritySite `Boolean?`
  - ProvisioningState `ProvisioningState?`
  - SiteKey `String`
  - VirtualWanId `String`

### WebApplicationFirewallCustomRule [Api20190201]
  - Action `WebApplicationFirewallAction`
  - Etag `String`
  - MatchCondition `IMatchCondition[]`
  - Name `String`
  - Priority `Int32`
  - RuleType `WebApplicationFirewallRuleType`

### WebApplicationFirewallPolicy [Api20190201]
  - ApplicationGateway `IApplicationGateway[]`
  - CustomRule `IWebApplicationFirewallCustomRule[]`
  - Etag `String`
  - Id `String`
  - Location `String`
  - Name `String`
  - PolicySettingEnabledState `WebApplicationFirewallEnabledState?`
  - PolicySettingMode `WebApplicationFirewallMode?`
  - ProvisioningState `String`
  - ResourceState `WebApplicationFirewallPolicyResourceState?`
  - Tag `IResourceTags`
  - Type `String`

### WebApplicationFirewallPolicyListResult [Api20190201]
  - NextLink `String`
  - Value `IWebApplicationFirewallPolicy[]`

### WebApplicationFirewallPolicyPropertiesFormat [Api20190201]
  - ApplicationGateway `IApplicationGateway[]`
  - CustomRule `IWebApplicationFirewallCustomRule[]`
  - PolicySettingEnabledState `WebApplicationFirewallEnabledState?`
  - PolicySettingMode `WebApplicationFirewallMode?`
  - ProvisioningState `String`
  - ResourceState `WebApplicationFirewallPolicyResourceState?`

