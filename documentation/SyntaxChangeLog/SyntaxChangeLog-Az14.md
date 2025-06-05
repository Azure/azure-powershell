## 14.1.0 - June 2025
#### Az.Migrate 2.8.0 
* Added cmdlet `Get-AzMigrateServerMigrationStatus`
#### Az.MySql 1.4.0 
* Modified cmdlet `Restore-AzMySqlFlexibleServer`
   - Added parameters `-Location`, `-UseGeoRestore`, `-Sku`, `-Tag`
#### Az.PostgreSql 1.3.0 
* Modified cmdlet `Restore-AzPostgreSqlFlexibleServer`
   - Added parameters `-UseGeoRestore`, `-Sku`, `-Tag`

## 14.0.0 - May 2025
#### Az.Aks 7.0.0 
* Modified cmdlet `Get-AzAksMaintenanceConfiguration`
   - Added parameter `-ManagedClusterInputObject`
* Modified cmdlet `Get-AzAksManagedClusterCommandResult`
   - Added parameter `-ManagedClusterInputObject`
* Modified cmdlet `Get-AzAksNodePoolUpgradeProfile`
   - Added parameter `-ManagedClusterInputObject`
* Modified cmdlet `Invoke-AzAksAbortAgentPoolLatestOperation`
   - Added parameter `-ManagedclusterInputObject`
* Modified cmdlet `New-AzAksMaintenanceConfiguration`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzAksSnapshot`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SnapshotType` from `SnapshotType` to `String`
* Modified cmdlet `New-AzAksTimeInWeekObject`
   - Changed the type of parameter `-Day` from `WeekDay` to `String`
* Modified cmdlet `Remove-AzAksMaintenanceConfiguration`
   - Added parameter `-ManagedClusterInputObject`
* Modified cmdlet `Start-AzAksManagedClusterCommand`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Added cmdlet `Update-AzAksMaintenanceConfiguration`
#### Az.AppConfiguration 2.0.0 
* Modified cmdlet `New-AzAppConfigurationStore`
   - Removed parameter `-IdentityType`
   - Added parameters `-EnableSystemAssignedIdentity`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-CreateMode` from `CreateMode` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Modified cmdlet `New-AzAppConfigurationStoreKey`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Test-AzAppConfigurationStoreNameAvailability`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzAppConfigurationStore`
   - Removed parameter `-IdentityType`
   - Added parameters `-EnableSystemAssignedIdentity`, `-SoftDeleteRetentionInDay`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
#### Az.Cdn 5.0.0 
* Modified cmdlet `Clear-AzCdnEndpointContent`
   - Added parameters `-ProfileInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Clear-AzFrontDoorCdnEndpointContent`
   - Added parameters `-ProfileInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Disable-AzCdnCustomDomainCustomHttps`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Enable-AzCdnCustomDomainCustomHttps`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`, `-CertificateSource`, `-MinimumTlsVersion`, `-ProtocolType`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Get-AzCdnCustomDomain`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Get-AzCdnEndpoint`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Get-AzCdnOrigin`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Get-AzCdnOriginGroup`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnCustomDomain`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnEndpoint`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnOrigin`
   - Added parameters `-OriginGroupInputObject`, `-ProfileInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnOriginGroup`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnRoute`
   - Added parameters `-AfdEndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnRule`
   - Added parameters `-ProfileInputObject`, `-RuleSetInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnRuleSet`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnSecret`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Get-AzFrontDoorCdnSecurityPolicy`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Import-AzCdnEndpointContent`
   - Added parameters `-ProfileInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzCdnCustomDomain`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`, `-CustomDomainProperty`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzCdnDeliveryRuleCacheExpirationActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterCacheBehavior` from `CacheBehavior` to `String`
* Modified cmdlet `New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterQueryStringBehavior` from `QueryStringBehavior` to `String`
* Modified cmdlet `New-AzCdnDeliveryRuleCookiesConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `CookiesOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleHttpVersionConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleIsDeviceConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleObject`
   - Changed the type of parameter `-Action` from `IDeliveryRuleAction1[]` to `IDeliveryRuleAction[]`
* Modified cmdlet `New-AzCdnDeliveryRulePostArgsConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `PostArgsOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleQueryStringConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `QueryStringOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleRemoteAddressConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `RemoteAddressOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleRequestBodyConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `RequestBodyOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleRequestHeaderActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterHeaderAction` from `HeaderAction` to `String`
* Modified cmdlet `New-AzCdnDeliveryRuleRequestHeaderConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `RequestHeaderOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleRequestMethodConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleRequestSchemeConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleRequestUriConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `RequestUriOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleResponseHeaderActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterHeaderAction` from `HeaderAction` to `String`
* Modified cmdlet `New-AzCdnDeliveryRuleUrlFileExtensionConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `UrlFileExtensionOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleUrlFileNameConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `UrlFileNameOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnDeliveryRuleUrlPathConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `UrlPathOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzCdnEndpoint`
   - Added parameters `-ProfileInputObject`, `-Endpoint`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-OptimizationType` from `OptimizationType` to `String`
   - Changed the type of parameter `-QueryStringCachingBehavior` from `QueryStringCachingBehavior` to `String`
* Modified cmdlet `New-AzCdnHealthProbeParametersObject`
   - Changed the type of parameter `-ProbeProtocol` from `ProbeProtocol` to `String`
   - Changed the type of parameter `-ProbeRequestType` from `HealthProbeRequestType` to `String`
* Modified cmdlet `New-AzCdnManagedHttpsParametersObject`
   - Added parameter `-CertificateSourceParameterTypeName`
   - Changed the type of parameter `-CertificateSourceParameterCertificateType` from `CertificateType` to `String`
   - Changed the type of parameter `-CertificateSource` from `CertificateSource` to `String`
   - Changed the type of parameter `-ProtocolType` from `ProtocolType` to `String`
   - Changed the type of parameter `-MinimumTlsVersion` from `MinimumTlsVersion` to `String`
* Modified cmdlet `New-AzCdnOrigin`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`, `-Origin`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzCdnOriginGroup`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`, `-OriginGroup`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzCdnOriginGroupOverrideActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
* Modified cmdlet `New-AzCdnProfile`
   - Changed the type of parameter `-SkuName` from `SkuName` to `String`
* Modified cmdlet `New-AzCdnResponseBasedOriginErrorDetectionParametersObject`
   - Changed the type of parameter `-ResponseBasedDetectedErrorType` from `ResponseBasedDetectedErrorTypes` to `String`
* Modified cmdlet `New-AzCdnUrlRedirectActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterRedirectType` from `RedirectType` to `String`
   - Changed the type of parameter `-ParameterDestinationProtocol` from `DestinationProtocol` to `String`
* Modified cmdlet `New-AzCdnUrlRewriteActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
* Modified cmdlet `New-AzCdnUrlSigningActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterAlgorithm` from `Algorithm` to `String`
* Modified cmdlet `New-AzCdnUserManagedHttpsParametersObject`
   - Added parameter `-CertificateSourceParameterTypeName`
   - Changed the type of parameter `-CertificateSource` from `CertificateSource` to `String`
   - Changed the type of parameter `-ProtocolType` from `ProtocolType` to `String`
   - Changed the type of parameter `-MinimumTlsVersion` from `MinimumTlsVersion` to `String`
* Modified cmdlet `New-AzFrontDoorCdnCustomDomain`
   - Added parameters `-ProfileInputObject`, `-CustomDomain`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject`
   - Added parameters `-CipherSuiteSetType`, `-CustomizedCipherSuiteSet`
   - Changed the type of parameter `-CertificateType` from `AfdCertificateType` to `String`
   - Changed the type of parameter `-MinimumTlsVersion` from `AfdMinimumTlsVersion` to `String`
* Modified cmdlet `New-AzFrontDoorCdnEndpoint`
   - Added parameters `-ProfileInputObject`, `-Endpoint`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-AutoGeneratedDomainNameLabelScope` from `AutoGeneratedDomainNameLabelScope` to `String`
   - Changed the type of parameter `-EnabledState` from `EnabledState` to `String`
* Modified cmdlet `New-AzFrontDoorCdnMigrationParametersObject`
   - Changed the type of parameter `-SkuName` from `SkuName` to `String`
* Modified cmdlet `New-AzFrontDoorCdnOrigin`
   - Added parameters `-OriginGroupInputObject`, `-ProfileInputObject`, `-Origin`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-EnabledState` from `EnabledState` to `String`
   - Changed the type of parameter `-SharedPrivateLinkResourceStatus` from `SharedPrivateLinkResourceStatus` to `String`
* Modified cmdlet `New-AzFrontDoorCdnOriginGroup`
   - Added parameters `-ProfileInputObject`, `-OriginGroup`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SessionAffinityState` from `EnabledState` to `String`
* Modified cmdlet `New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject`
   - Changed the type of parameter `-ProbeProtocol` from `ProbeProtocol` to `String`
   - Changed the type of parameter `-ProbeRequestType` from `HealthProbeRequestType` to `String`
* Modified cmdlet `New-AzFrontDoorCdnProfile`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SkuName` from `SkuName` to `String`
   - Changed the type of parameter `-IdentityType` from `ManagedServiceIdentityType` to `String`
   - Changed the type of parameter `-LogScrubbingState` from `ProfileScrubbingState` to `String`
* Modified cmdlet `New-AzFrontDoorCdnProfileLogScrubbingObject`
   - Changed the type of parameter `-State` from `ProfileScrubbingState` to `String`
* Modified cmdlet `New-AzFrontDoorCdnProfileScrubbingRulesObject`
   - Changed the type of parameter `-MatchVariable` from `ScrubbingRuleEntryMatchVariable` to `String`
   - Changed the type of parameter `-State` from `ScrubbingRuleEntryState` to `String`
* Modified cmdlet `New-AzFrontDoorCdnRoute`
   - Added parameters `-AfdEndpointInputObject`, `-ProfileInputObject`, `-Route`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-CacheConfigurationQueryStringCachingBehavior` from `AfdQueryStringCachingBehavior` to `String`
   - Changed the type of parameter `-EnabledState` from `EnabledState` to `String`
   - Changed the type of parameter `-ForwardingProtocol` from `ForwardingProtocol` to `String`
   - Changed the type of parameter `-HttpsRedirect` from `HttpsRedirect` to `String`
   - Changed the type of parameter `-LinkToDefaultDomain` from `LinkToDefaultDomain` to `String`
   - Changed the type of parameter `-SupportedProtocol` from `AfdEndpointProtocols[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRule`
   - Added parameters `-ProfileInputObject`, `-RuleSetInputObject`, `-Rule`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Action` from `IDeliveryRuleAction1[]` to `IDeliveryRuleAction[]`
   - Changed the type of parameter `-MatchProcessingBehavior` from `MatchProcessingBehavior` to `String`
* Modified cmdlet `New-AzFrontDoorCdnRuleClientPortConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `ClientPortOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleCookiesConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `CookiesOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleHostNameConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `HostNameOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleHttpVersionConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleIsDeviceConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRulePostArgsConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `PostArgsOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleQueryStringConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `QueryStringOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleRemoteAddressConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `RemoteAddressOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleRequestBodyConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `RequestBodyOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleRequestHeaderActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterHeaderAction` from `HeaderAction` to `String`
* Modified cmdlet `New-AzFrontDoorCdnRuleRequestHeaderConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `RequestHeaderOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleRequestMethodConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleRequestSchemeConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleRequestUriConditionObject`
   - Changed the type of parameter `-ParameterOperator` from `RequestUriOperator` to `String`
   - Changed the type of parameter `-Name` from `MatchVariable` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleResponseHeaderActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterHeaderAction` from `HeaderAction` to `String`
* Modified cmdlet `New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject`
   - Changed the type of parameter `-Name` from `DeliveryRuleAction` to `String`
   - Changed the type of parameter `-CacheConfigurationCacheBehavior` from `RuleCacheBehavior` to `String`
   - Changed the type of parameter `-CacheConfigurationIsCompressionEnabled` from `RuleIsCompressionEnabled` to `String`
   - Changed the type of parameter `-CacheConfigurationQueryStringCachingBehavior` from `RuleQueryStringCachingBehavior` to `String`
   - Changed the type of parameter `-OriginGroupOverrideForwardingProtocol` from `ForwardingProtocol` to `String`
* Modified cmdlet `New-AzFrontDoorCdnRuleServerPortConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `ServerPortOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleSet`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `New-AzFrontDoorCdnRuleSocketAddrConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `SocketAddrOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleSslProtocolConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterMatchValue` from `SslProtocol[]` to `String[]`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleUrlFileExtensionConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `UrlFileExtensionOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleUrlFileNameConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `UrlFileNameOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleUrlPathConditionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterOperator` from `UrlPathOperator` to `String`
   - Changed the type of parameter `-ParameterTransform` from `Transform[]` to `String[]`
* Modified cmdlet `New-AzFrontDoorCdnRuleUrlRedirectActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterRedirectType` from `RedirectType` to `String`
   - Changed the type of parameter `-ParameterDestinationProtocol` from `DestinationProtocol` to `String`
* Modified cmdlet `New-AzFrontDoorCdnRuleUrlRewriteActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
* Modified cmdlet `New-AzFrontDoorCdnRuleUrlSigningActionObject`
   - Removed parameter `-Name`
   - Added parameter `-ParameterTypeName`
   - Changed the type of parameter `-ParameterAlgorithm` from `Algorithm` to `String`
* Modified cmdlet `New-AzFrontDoorCdnSecret`
   - Added parameters `-ProfileInputObject`, `-Secret`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzFrontDoorCdnSecretCustomerCertificateParametersObject`
   - Changed the type of parameter `-Type` from `SecretType` to `String`
* Modified cmdlet `New-AzFrontDoorCdnSecretFirstPartyManagedCertificateParametersObject`
   - Added parameter `-SubjectAlternativeName`
   - Changed the type of parameter `-Type` from `SecretType` to `String`
* Modified cmdlet `New-AzFrontDoorCdnSecretManagedCertificateParametersObject`
   - Changed the type of parameter `-Type` from `SecretType` to `String`
* Modified cmdlet `New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject`
   - Changed the type of parameter `-Type` from `SecretType` to `String`
* Modified cmdlet `New-AzFrontDoorCdnSecurityPolicy`
   - Added parameters `-ProfileInputObject`, `-SecurityPolicy`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Remove-AzCdnCustomDomain`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Remove-AzCdnEndpoint`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Remove-AzCdnOrigin`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Remove-AzCdnOriginGroup`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnCustomDomain`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnEndpoint`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnOrigin`
   - Added parameters `-OriginGroupInputObject`, `-ProfileInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnOriginGroup`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnRoute`
   - Added parameters `-AfdEndpointInputObject`, `-ProfileInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnRule`
   - Added parameters `-ProfileInputObject`, `-RuleSetInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnRuleSet`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnSecret`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Remove-AzFrontDoorCdnSecurityPolicy`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Start-AzCdnEndpoint`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Start-AzFrontDoorCdnProfilePrepareMigration`
   - Changed the type of parameter `-SkuName` from `SkuName` to `String`
   - Changed the type of parameter `-IdentityType` from `ManagedServiceIdentityType` to `String`
* Modified cmdlet `Stop-AzCdnEndpoint`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Test-AzCdnEndpointCustomDomain`
   - Added parameters `-ProfileInputObject`, `-CustomDomainProperty`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Test-AzCdnNameAvailability`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Type` from `ResourceType` to `String`
* Modified cmdlet `Test-AzCdnProbe`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Test-AzFrontDoorCdnEndpointCustomDomain`
   - Added parameters `-ProfileInputObject`, `-CustomDomainProperty`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Test-AzFrontDoorCdnEndpointNameAvailability`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Type` from `ResourceType` to `String`
   - Changed the type of parameter `-AutoGeneratedDomainNameLabelScope` from `AutoGeneratedDomainNameLabelScope` to `String`
* Modified cmdlet `Test-AzFrontDoorCdnProfileHostNameAvailability`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzCdnEndpoint`
   - Added parameters `-ProfileInputObject`, `-EndpointUpdateProperty`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-OptimizationType` from `OptimizationType` to `String`
   - Changed the type of parameter `-QueryStringCachingBehavior` from `QueryStringCachingBehavior` to `String`
* Modified cmdlet `Update-AzCdnOrigin`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`, `-OriginUpdateProperty`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzCdnOriginGroup`
   - Added parameters `-EndpointInputObject`, `-ProfileInputObject`, `-OriginGroupUpdateProperty`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzFrontDoorCdnCustomDomain`
   - Added parameters `-ProfileInputObject`, `-CustomDomainUpdateProperty`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzFrontDoorCdnCustomDomainValidationToken`
   - Added parameter `-ProfileInputObject`
* Modified cmdlet `Update-AzFrontDoorCdnEndpoint`
   - Added parameters `-ProfileInputObject`, `-EndpointUpdateProperty`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-EnabledState` from `EnabledState` to `String`
* Modified cmdlet `Update-AzFrontDoorCdnOrigin`
   - Added parameters `-OriginGroupInputObject`, `-ProfileInputObject`, `-OriginUpdateProperty`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-EnabledState` from `EnabledState` to `String`
   - Changed the type of parameter `-SharedPrivateLinkResourceStatus` from `SharedPrivateLinkResourceStatus` to `String`
* Modified cmdlet `Update-AzFrontDoorCdnOriginGroup`
   - Added parameters `-ProfileInputObject`, `-OriginGroupUpdateProperty`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SessionAffinityState` from `EnabledState` to `String`
* Modified cmdlet `Update-AzFrontDoorCdnProfile`
   - Added parameters `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-LogScrubbingState` from `ProfileScrubbingState` to `String`
   - Changed the type of parameter `-IdentityType` from `ManagedServiceIdentityType` to `String`
* Modified cmdlet `Update-AzFrontDoorCdnRoute`
   - Added parameters `-AfdEndpointInputObject`, `-ProfileInputObject`, `-RouteUpdateProperty`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-CacheConfigurationQueryStringCachingBehavior` from `AfdQueryStringCachingBehavior` to `String`
   - Changed the type of parameter `-EnabledState` from `EnabledState` to `String`
   - Changed the type of parameter `-ForwardingProtocol` from `ForwardingProtocol` to `String`
   - Changed the type of parameter `-HttpsRedirect` from `HttpsRedirect` to `String`
   - Changed the type of parameter `-LinkToDefaultDomain` from `LinkToDefaultDomain` to `String`
   - Changed the type of parameter `-SupportedProtocol` from `AfdEndpointProtocols[]` to `String[]`
* Modified cmdlet `Update-AzFrontDoorCdnRule`
   - Added parameters `-ProfileInputObject`, `-RuleSetInputObject`, `-RuleUpdateProperty`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Action` from `IDeliveryRuleAction1[]` to `IDeliveryRuleAction[]`
   - Changed the type of parameter `-MatchProcessingBehavior` from `MatchProcessingBehavior` to `String`
* Modified cmdlet `Update-AzFrontDoorCdnSecurityPolicy`
   - Added parameters `-ProfileInputObject`, `-SecurityPolicyUpdateProperty`, `-JsonFilePath`, `-JsonString`
* Added cmdlet `Invoke-AzCdnAbortProfileToAFDMigration`, `Invoke-AzCdnCommitProfileToAFDMigration`, `Move-AzCdnProfileToAFD`, `New-AzCdnMigrationEndpointMappingObject`, `Test-AzCdnProfileMigrationCompatibility`, `Update-AzFrontDoorCdnSecret`
#### Az.Compute 10.0.0 
* Modified cmdlet `Get-AzVMImage`
   - Added parameter `-Expand`
* Modified cmdlet `Get-AzVMSize`
   - Removed parameter `-Location`
* Modified cmdlet `New-AzVmssConfig`
   - Added parameters `-EnableAutomaticZoneRebalance`, `-AutomaticZoneRebalanceStrategy`, `-AutomaticZoneRebalanceBehavior`
* Modified cmdlet `Update-AzVmss`
   - Added parameters `-EnableAutomaticZoneRebalance`, `-AutomaticZoneRebalanceStrategy`, `-AutomaticZoneRebalanceBehavior`
#### Az.EventHub 5.3.0 
* Modified cmdlet `New-AzEventHubNamespace`
   - Added parameters `-GeoDataReplicationMaxReplicationLagDurationInSecond`, `-GeoDataReplicationLocation`
* Modified cmdlet `Set-AzEventHubNamespace`
   - Added parameters `-GeoDataReplicationMaxReplicationLagDurationInSecond`, `-GeoDataReplicationLocation`
* Added cmdlet `New-AzEventHubLocationsNameObject`, `Start-AzEventHubNamespaceFailOver`
#### Az.ManagedServiceIdentity 2.0.0 
* Modified cmdlet `New-AzFederatedIdentityCredential`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzUserAssignedIdentity`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzFederatedIdentityCredential`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzUserAssignedIdentity`
   - Added parameters `-JsonFilePath`, `-JsonString`
#### Az.RedisEnterpriseCache 1.5.0 
* Added cmdlet `Get-AzRedisEnterpriseCacheSku`
#### Az.Storage 9.0.0 
* Modified cmdlet `Start-AzStorageAccountMigration`
   - Added parameter `-Force`



