---
Module Name: Az.Cdn
Module Guid: f9fae843-9c26-4513-9442-17f4379802bf
Download Help Link: https://learn.microsoft.com/powershell/module/az.cdn
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Cdn Module
## Description
Microsoft Azure PowerShell: Cdn cmdlets

## Az.Cdn Cmdlets
### [Clear-AzCdnEndpointContent](Clear-AzCdnEndpointContent.md)
Removes a content from CDN.

### [Clear-AzFrontDoorCdnEndpointContent](Clear-AzFrontDoorCdnEndpointContent.md)
Removes a content from AzureFrontDoor.

### [Disable-AzCdnCustomDomainCustomHttps](Disable-AzCdnCustomDomainCustomHttps.md)
Disable https delivery of the custom domain.

### [Enable-AzCdnCustomDomainCustomHttps](Enable-AzCdnCustomDomainCustomHttps.md)
Enable https delivery of the custom domain.

### [Enable-AzFrontDoorCdnProfileMigration](Enable-AzFrontDoorCdnProfileMigration.md)
Commit the migrated Azure Front Door(Standard/Premium) profile..

### [Get-AzCdnCustomDomain](Get-AzCdnCustomDomain.md)
Gets an existing custom domain within an endpoint.

### [Get-AzCdnEdgeNode](Get-AzCdnEdgeNode.md)
Edgenodes are the global Point of Presence (POP) locations used to deliver CDN content to end users.

### [Get-AzCdnEndpoint](Get-AzCdnEndpoint.md)
Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [Get-AzCdnEndpointResourceUsage](Get-AzCdnEndpointResourceUsage.md)
Checks the quota and usage of geo filters and custom domains under the given endpoint.

### [Get-AzCdnOrigin](Get-AzCdnOrigin.md)
Gets an existing origin within an endpoint.

### [Get-AzCdnOriginGroup](Get-AzCdnOriginGroup.md)
Gets an existing origin group within an endpoint.

### [Get-AzCdnProfile](Get-AzCdnProfile.md)
Gets an CDN profile with the specified profile name under the specified subscription and resource group.

### [Get-AzCdnProfileResourceUsage](Get-AzCdnProfileResourceUsage.md)
Checks the quota and actual usage of endpoints under the given Azure Front Door Standard or Azure Front Door Premium or CDN profile.

### [Get-AzCdnProfileSupportedOptimizationType](Get-AzCdnProfileSupportedOptimizationType.md)
Gets the supported optimization types for the current profile.
A user can create an endpoint with an optimization type from the listed values.

### [Get-AzCdnSubscriptionResourceUsage](Get-AzCdnSubscriptionResourceUsage.md)
Check the quota and actual usage of the CDN profiles under the given subscription.

### [Get-AzFrontDoorCdnCustomDomain](Get-AzFrontDoorCdnCustomDomain.md)
Gets an existing AzureFrontDoor domain with the specified domain name under the specified subscription, resource group and profile.

### [Get-AzFrontDoorCdnEndpoint](Get-AzFrontDoorCdnEndpoint.md)
Gets an existing AzureFrontDoor endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [Get-AzFrontDoorCdnEndpointResourceUsage](Get-AzFrontDoorCdnEndpointResourceUsage.md)
Checks the quota and actual usage of endpoints under the given Azure Front Door profile.

### [Get-AzFrontDoorCdnOrigin](Get-AzFrontDoorCdnOrigin.md)
Gets an existing origin within an origin group.

### [Get-AzFrontDoorCdnOriginGroup](Get-AzFrontDoorCdnOriginGroup.md)
Gets an existing origin group within a profile.

### [Get-AzFrontDoorCdnOriginGroupResourceUsage](Get-AzFrontDoorCdnOriginGroupResourceUsage.md)
Checks the quota and actual usage of endpoints under the given Azure Front Door profile..

### [Get-AzFrontDoorCdnProfile](Get-AzFrontDoorCdnProfile.md)
Gets an Azure Front Door Standard or Azure Front Door Premium or CDN profile with the specified profile name under the specified subscription and resource group.

### [Get-AzFrontDoorCdnProfileResourceUsage](Get-AzFrontDoorCdnProfileResourceUsage.md)
Checks the quota and actual usage of endpoints under the given Azure Front Door profile.

### [Get-AzFrontDoorCdnRoute](Get-AzFrontDoorCdnRoute.md)
Gets an existing route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

### [Get-AzFrontDoorCdnRule](Get-AzFrontDoorCdnRule.md)
Gets an existing delivery rule within a rule set.

### [Get-AzFrontDoorCdnRuleSet](Get-AzFrontDoorCdnRuleSet.md)
Gets an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.

### [Get-AzFrontDoorCdnRuleSetResourceUsage](Get-AzFrontDoorCdnRuleSetResourceUsage.md)
Checks the quota and actual usage of endpoints under the given Azure Front Door profile..

### [Get-AzFrontDoorCdnSecret](Get-AzFrontDoorCdnSecret.md)
Gets an existing Secret within a profile.

### [Get-AzFrontDoorCdnSecurityPolicy](Get-AzFrontDoorCdnSecurityPolicy.md)
Gets an existing security policy within a profile.

### [Import-AzCdnEndpointContent](Import-AzCdnEndpointContent.md)
Pre-loads a content to CDN.
Available for Verizon Profiles.

### [New-AzCdnCustomDomain](New-AzCdnCustomDomain.md)
Creates a new custom domain within an endpoint.

### [New-AzCdnDeliveryRuleCacheExpirationActionObject](New-AzCdnDeliveryRuleCacheExpirationActionObject.md)
Create an in-memory object for DeliveryRuleCacheExpirationAction.

### [New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject](New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject.md)
Create an in-memory object for DeliveryRuleCacheKeyQueryStringAction.

### [New-AzCdnDeliveryRuleCookiesConditionObject](New-AzCdnDeliveryRuleCookiesConditionObject.md)
Create an in-memory object for DeliveryRuleCookiesCondition.

### [New-AzCdnDeliveryRuleHttpVersionConditionObject](New-AzCdnDeliveryRuleHttpVersionConditionObject.md)
Create an in-memory object for DeliveryRuleHttpVersionCondition.

### [New-AzCdnDeliveryRuleIsDeviceConditionObject](New-AzCdnDeliveryRuleIsDeviceConditionObject.md)
Create an in-memory object for DeliveryRuleIsDeviceCondition.

### [New-AzCdnDeliveryRuleObject](New-AzCdnDeliveryRuleObject.md)
Create an in-memory object for DeliveryRule.

### [New-AzCdnDeliveryRulePostArgsConditionObject](New-AzCdnDeliveryRulePostArgsConditionObject.md)
Create an in-memory object for DeliveryRulePostArgsCondition.

### [New-AzCdnDeliveryRuleQueryStringConditionObject](New-AzCdnDeliveryRuleQueryStringConditionObject.md)
Create an in-memory object for DeliveryRuleQueryStringCondition.

### [New-AzCdnDeliveryRuleRemoteAddressConditionObject](New-AzCdnDeliveryRuleRemoteAddressConditionObject.md)
Create an in-memory object for DeliveryRuleRemoteAddressCondition.

### [New-AzCdnDeliveryRuleRequestBodyConditionObject](New-AzCdnDeliveryRuleRequestBodyConditionObject.md)
Create an in-memory object for DeliveryRuleRequestBodyCondition.

### [New-AzCdnDeliveryRuleRequestHeaderActionObject](New-AzCdnDeliveryRuleRequestHeaderActionObject.md)
Create an in-memory object for DeliveryRuleRequestHeaderAction.

### [New-AzCdnDeliveryRuleRequestHeaderConditionObject](New-AzCdnDeliveryRuleRequestHeaderConditionObject.md)
Create an in-memory object for DeliveryRuleRequestHeaderCondition.

### [New-AzCdnDeliveryRuleRequestMethodConditionObject](New-AzCdnDeliveryRuleRequestMethodConditionObject.md)
Create an in-memory object for DeliveryRuleRequestMethodCondition.

### [New-AzCdnDeliveryRuleRequestSchemeConditionObject](New-AzCdnDeliveryRuleRequestSchemeConditionObject.md)
Create an in-memory object for DeliveryRuleRequestSchemeCondition.

### [New-AzCdnDeliveryRuleRequestUriConditionObject](New-AzCdnDeliveryRuleRequestUriConditionObject.md)
Create an in-memory object for DeliveryRuleRequestUriCondition.

### [New-AzCdnDeliveryRuleResponseHeaderActionObject](New-AzCdnDeliveryRuleResponseHeaderActionObject.md)
Create an in-memory object for DeliveryRuleResponseHeaderAction.

### [New-AzCdnDeliveryRuleUrlFileExtensionConditionObject](New-AzCdnDeliveryRuleUrlFileExtensionConditionObject.md)
Create an in-memory object for DeliveryRuleUrlFileExtensionCondition.

### [New-AzCdnDeliveryRuleUrlFileNameConditionObject](New-AzCdnDeliveryRuleUrlFileNameConditionObject.md)
Create an in-memory object for DeliveryRuleUrlFileNameCondition.

### [New-AzCdnDeliveryRuleUrlPathConditionObject](New-AzCdnDeliveryRuleUrlPathConditionObject.md)
Create an in-memory object for DeliveryRuleUrlPathCondition.

### [New-AzCdnEndpoint](New-AzCdnEndpoint.md)
Creates a new CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [New-AzCdnHealthProbeParametersObject](New-AzCdnHealthProbeParametersObject.md)
Create an in-memory object for HealthProbeParameters.

### [New-AzCdnLoadParametersObject](New-AzCdnLoadParametersObject.md)
Create an in-memory object for LoadParameters.

### [New-AzCdnManagedHttpsParametersObject](New-AzCdnManagedHttpsParametersObject.md)
Create an in-memory object for CdnManagedHttpsParameters.

### [New-AzCdnOrigin](New-AzCdnOrigin.md)
Creates a new origin within the specified endpoint.

### [New-AzCdnOriginGroup](New-AzCdnOriginGroup.md)
Creates a new origin group within the specified endpoint.

### [New-AzCdnOriginGroupOverrideActionObject](New-AzCdnOriginGroupOverrideActionObject.md)
Create an in-memory object for OriginGroupOverrideAction.

### [New-AzCdnProfile](New-AzCdnProfile.md)
Creates an CDN profile with the specified profile name under the specified subscription and resource group.

### [New-AzCdnPurgeParametersObject](New-AzCdnPurgeParametersObject.md)
Create an in-memory object for PurgeParameters.

### [New-AzCdnResourceReferenceObject](New-AzCdnResourceReferenceObject.md)
Create an in-memory object for ResourceReference.

### [New-AzCdnResponseBasedOriginErrorDetectionParametersObject](New-AzCdnResponseBasedOriginErrorDetectionParametersObject.md)
Create an in-memory object for ResponseBasedOriginErrorDetectionParameters.

### [New-AzCdnUrlRedirectActionObject](New-AzCdnUrlRedirectActionObject.md)
Create an in-memory object for UrlRedirectAction.

### [New-AzCdnUrlRewriteActionObject](New-AzCdnUrlRewriteActionObject.md)
Create an in-memory object for UrlRewriteAction.

### [New-AzCdnUrlSigningActionObject](New-AzCdnUrlSigningActionObject.md)
Create an in-memory object for UrlSigningAction.

### [New-AzCdnUserManagedHttpsParametersObject](New-AzCdnUserManagedHttpsParametersObject.md)
Create an in-memory object for UserManagedHttpsParameters.

### [New-AzFrontDoorCdnCustomDomain](New-AzFrontDoorCdnCustomDomain.md)
Creates a new domain within the specified profile.

### [New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject](New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject.md)
Create an in-memory object for AFDDomainHttpsParameters.

### [New-AzFrontDoorCdnEndpoint](New-AzFrontDoorCdnEndpoint.md)
Creates a new AzureFrontDoor endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [New-AzFrontDoorCdnMigrationParametersObject](New-AzFrontDoorCdnMigrationParametersObject.md)
Create an in-memory object for MigrationParameters.

### [New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject](New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject.md)
Create an in-memory object for MigrationWebApplicationFirewallMapping.

### [New-AzFrontDoorCdnOrigin](New-AzFrontDoorCdnOrigin.md)
Creates a new origin within the specified origin group.

### [New-AzFrontDoorCdnOriginGroup](New-AzFrontDoorCdnOriginGroup.md)
Creates a new origin group within the specified profile.

### [New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject](New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject.md)
Create an in-memory object for HealthProbeParameters.

### [New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject](New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject.md)
Create an in-memory object for LoadBalancingSettingsParameters.

### [New-AzFrontDoorCdnProfile](New-AzFrontDoorCdnProfile.md)
Creates a new Azure Front Door Standard or Azure Front Door Premium or CDN profile with a profile name under the specified subscription and resource group.

### [New-AzFrontDoorCdnProfileChangeSkuWafMappingObject](New-AzFrontDoorCdnProfileChangeSkuWafMappingObject.md)
Create an in-memory object for ProfileChangeSkuWafMapping.

### [New-AzFrontDoorCdnProfileUpgradeParametersObject](New-AzFrontDoorCdnProfileUpgradeParametersObject.md)
Create an in-memory object for ProfileUpgradeParameters.

### [New-AzFrontDoorCdnPurgeParametersObject](New-AzFrontDoorCdnPurgeParametersObject.md)
Create an in-memory object for AfdPurgeParameters.

### [New-AzFrontDoorCdnResourceReferenceObject](New-AzFrontDoorCdnResourceReferenceObject.md)
Create an in-memory object for ResourceReference.

### [New-AzFrontDoorCdnRoute](New-AzFrontDoorCdnRoute.md)
Creates a new route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

### [New-AzFrontDoorCdnRule](New-AzFrontDoorCdnRule.md)
Creates a new delivery rule within the specified rule set.

### [New-AzFrontDoorCdnRuleClientPortConditionObject](New-AzFrontDoorCdnRuleClientPortConditionObject.md)
Create an in-memory object for DeliveryRuleClientPortCondition.

### [New-AzFrontDoorCdnRuleCookiesConditionObject](New-AzFrontDoorCdnRuleCookiesConditionObject.md)
Create an in-memory object for DeliveryRuleCookiesCondition.

### [New-AzFrontDoorCdnRuleHostNameConditionObject](New-AzFrontDoorCdnRuleHostNameConditionObject.md)
Create an in-memory object for DeliveryRuleHostNameCondition.

### [New-AzFrontDoorCdnRuleHttpVersionConditionObject](New-AzFrontDoorCdnRuleHttpVersionConditionObject.md)
Create an in-memory object for DeliveryRuleHttpVersionCondition.

### [New-AzFrontDoorCdnRuleIsDeviceConditionObject](New-AzFrontDoorCdnRuleIsDeviceConditionObject.md)
Create an in-memory object for DeliveryRuleIsDeviceCondition.

### [New-AzFrontDoorCdnRulePostArgsConditionObject](New-AzFrontDoorCdnRulePostArgsConditionObject.md)
Create an in-memory object for DeliveryRulePostArgsCondition.

### [New-AzFrontDoorCdnRuleQueryStringConditionObject](New-AzFrontDoorCdnRuleQueryStringConditionObject.md)
Create an in-memory object for DeliveryRuleQueryStringCondition.

### [New-AzFrontDoorCdnRuleRemoteAddressConditionObject](New-AzFrontDoorCdnRuleRemoteAddressConditionObject.md)
Create an in-memory object for DeliveryRuleRemoteAddressCondition.

### [New-AzFrontDoorCdnRuleRequestBodyConditionObject](New-AzFrontDoorCdnRuleRequestBodyConditionObject.md)
Create an in-memory object for DeliveryRuleRequestBodyCondition.

### [New-AzFrontDoorCdnRuleRequestHeaderActionObject](New-AzFrontDoorCdnRuleRequestHeaderActionObject.md)
Create an in-memory object for DeliveryRuleRequestHeaderAction.

### [New-AzFrontDoorCdnRuleRequestHeaderConditionObject](New-AzFrontDoorCdnRuleRequestHeaderConditionObject.md)
Create an in-memory object for DeliveryRuleRequestHeaderCondition.

### [New-AzFrontDoorCdnRuleRequestMethodConditionObject](New-AzFrontDoorCdnRuleRequestMethodConditionObject.md)
Create an in-memory object for DeliveryRuleRequestMethodCondition.

### [New-AzFrontDoorCdnRuleRequestSchemeConditionObject](New-AzFrontDoorCdnRuleRequestSchemeConditionObject.md)
Create an in-memory object for DeliveryRuleRequestSchemeCondition.

### [New-AzFrontDoorCdnRuleRequestUriConditionObject](New-AzFrontDoorCdnRuleRequestUriConditionObject.md)
Create an in-memory object for DeliveryRuleRequestUriCondition.

### [New-AzFrontDoorCdnRuleResponseHeaderActionObject](New-AzFrontDoorCdnRuleResponseHeaderActionObject.md)
Create an in-memory object for DeliveryRuleResponseHeaderAction.

### [New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject](New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject.md)
Create an in-memory object for DeliveryRuleRouteConfigurationOverrideAction.

### [New-AzFrontDoorCdnRuleServerPortConditionObject](New-AzFrontDoorCdnRuleServerPortConditionObject.md)
Create an in-memory object for DeliveryRuleServerPortCondition.

### [New-AzFrontDoorCdnRuleSet](New-AzFrontDoorCdnRuleSet.md)
Creates a new rule set within the specified profile.

### [New-AzFrontDoorCdnRuleSocketAddrConditionObject](New-AzFrontDoorCdnRuleSocketAddrConditionObject.md)
Create an in-memory object for DeliveryRuleSocketAddrCondition.

### [New-AzFrontDoorCdnRuleSslProtocolConditionObject](New-AzFrontDoorCdnRuleSslProtocolConditionObject.md)
Create an in-memory object for DeliveryRuleSslProtocolCondition.

### [New-AzFrontDoorCdnRuleUrlFileExtensionConditionObject](New-AzFrontDoorCdnRuleUrlFileExtensionConditionObject.md)
Create an in-memory object for DeliveryRuleUrlFileExtensionCondition.

### [New-AzFrontDoorCdnRuleUrlFileNameConditionObject](New-AzFrontDoorCdnRuleUrlFileNameConditionObject.md)
Create an in-memory object for DeliveryRuleUrlFileNameCondition.

### [New-AzFrontDoorCdnRuleUrlPathConditionObject](New-AzFrontDoorCdnRuleUrlPathConditionObject.md)
Create an in-memory object for DeliveryRuleUrlPathCondition.

### [New-AzFrontDoorCdnRuleUrlRedirectActionObject](New-AzFrontDoorCdnRuleUrlRedirectActionObject.md)
Create an in-memory object for UrlRedirectAction.

### [New-AzFrontDoorCdnRuleUrlRewriteActionObject](New-AzFrontDoorCdnRuleUrlRewriteActionObject.md)
Create an in-memory object for UrlRewriteAction.

### [New-AzFrontDoorCdnRuleUrlSigningActionObject](New-AzFrontDoorCdnRuleUrlSigningActionObject.md)
Create an in-memory object for UrlSigningAction.

### [New-AzFrontDoorCdnSecret](New-AzFrontDoorCdnSecret.md)
Creates a new Secret within the specified profile.

### [New-AzFrontDoorCdnSecretCustomerCertificateParametersObject](New-AzFrontDoorCdnSecretCustomerCertificateParametersObject.md)
Create an in-memory object for CustomerCertificateParameters.

### [New-AzFrontDoorCdnSecretFirstPartyManagedCertificateParametersObject](New-AzFrontDoorCdnSecretFirstPartyManagedCertificateParametersObject.md)
Create an in-memory object for AzureFirstPartyManagedCertificateParameters.

### [New-AzFrontDoorCdnSecretManagedCertificateParametersObject](New-AzFrontDoorCdnSecretManagedCertificateParametersObject.md)
Create an in-memory object for ManagedCertificateParameters.

### [New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject](New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject.md)
Create an in-memory object for UrlSigningKeyParameters.

### [New-AzFrontDoorCdnSecurityPolicy](New-AzFrontDoorCdnSecurityPolicy.md)
Creates a new security policy within the specified profile.

### [New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject](New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject.md)
Create an in-memory object for SecurityPolicyWebApplicationFirewallAssociation.

### [New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject](New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject.md)
Create an in-memory object for SecurityPolicyWebApplicationFirewallParameters.

### [Remove-AzCdnCustomDomain](Remove-AzCdnCustomDomain.md)
Deletes an existing custom domain within an endpoint.

### [Remove-AzCdnEndpoint](Remove-AzCdnEndpoint.md)
Deletes an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [Remove-AzCdnOrigin](Remove-AzCdnOrigin.md)
Deletes an existing origin within an endpoint.

### [Remove-AzCdnOriginGroup](Remove-AzCdnOriginGroup.md)
Deletes an existing origin group within an endpoint.

### [Remove-AzCdnProfile](Remove-AzCdnProfile.md)
Deletes an existing CDN profile with the specified profile name under the specified subscription.
Deleting a profile will result in the deletion of all of the sub-resources including endpoints, origins and custom domains.

### [Remove-AzFrontDoorCdnCustomDomain](Remove-AzFrontDoorCdnCustomDomain.md)
Deletes an existing AzureFrontDoor domain with the specified domain name under the specified subscription, resource group and profile.

### [Remove-AzFrontDoorCdnEndpoint](Remove-AzFrontDoorCdnEndpoint.md)
Deletes an existing AzureFrontDoor endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [Remove-AzFrontDoorCdnOrigin](Remove-AzFrontDoorCdnOrigin.md)
Deletes an existing origin within an origin group.

### [Remove-AzFrontDoorCdnOriginGroup](Remove-AzFrontDoorCdnOriginGroup.md)
Deletes an existing origin group within a profile.

### [Remove-AzFrontDoorCdnProfile](Remove-AzFrontDoorCdnProfile.md)
Deletes an existing  Azure Front Door Standard or Azure Front Door Premium or CDN profile with the specified parameters.
Deleting a profile will result in the deletion of all of the sub-resources including endpoints, origins and custom domains.

### [Remove-AzFrontDoorCdnRoute](Remove-AzFrontDoorCdnRoute.md)
Deletes an existing route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

### [Remove-AzFrontDoorCdnRule](Remove-AzFrontDoorCdnRule.md)
Deletes an existing delivery rule within a rule set.

### [Remove-AzFrontDoorCdnRuleSet](Remove-AzFrontDoorCdnRuleSet.md)
Deletes an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.

### [Remove-AzFrontDoorCdnSecret](Remove-AzFrontDoorCdnSecret.md)
Deletes an existing Secret within profile.

### [Remove-AzFrontDoorCdnSecurityPolicy](Remove-AzFrontDoorCdnSecurityPolicy.md)
Deletes an existing security policy within profile.

### [Start-AzCdnEndpoint](Start-AzCdnEndpoint.md)
Starts an existing CDN endpoint that is on a stopped state.

### [Start-AzFrontDoorCdnProfilePrepareMigration](Start-AzFrontDoorCdnProfilePrepareMigration.md)
Migrate the classic AFD instance to Azure Front Door(Standard/Premium) profile.
MigrationWebApplicationFirewallMapping should be associated if the front door has WAF policy.
Managed Identity should be associated if the frontdoor has Customer Certificates.
The change need to be committed after this.

### [Stop-AzCdnEndpoint](Stop-AzCdnEndpoint.md)
Stops an existing running CDN endpoint.

### [Stop-AzFrontDoorCdnProfileMigration](Stop-AzFrontDoorCdnProfileMigration.md)
Abort classic cdn migrate to AFDx.
Your new Front Door Profile will be deleted and your existing profile will remain active.
WAF policies will not be deleted.

### [Test-AzCdnEndpointCustomDomain](Test-AzCdnEndpointCustomDomain.md)
Validates the custom domain mapping to ensure it maps to the correct CDN endpoint in DNS.

### [Test-AzCdnNameAvailability](Test-AzCdnNameAvailability.md)
Check the availability of a resource name.
This is needed for resources where name is globally unique, such as a CDN endpoint.

### [Test-AzCdnProbe](Test-AzCdnProbe.md)
Check if the probe path is a valid path and the file can be accessed.
Probe path is the path to a file hosted on the origin server to help accelerate the delivery of dynamic content via the CDN endpoint.
This path is relative to the origin path specified in the endpoint configuration.

### [Test-AzFrontDoorCdnEndpointCustomDomain](Test-AzFrontDoorCdnEndpointCustomDomain.md)
Validates the custom domain mapping to ensure it maps to the correct Azure Front Door endpoint in DNS.

### [Test-AzFrontDoorCdnEndpointNameAvailability](Test-AzFrontDoorCdnEndpointNameAvailability.md)
Check the availability of a resource name.
This is needed for resources where name is globally unique, such as a afdx endpoint.

### [Test-AzFrontDoorCdnProfileHostNameAvailability](Test-AzFrontDoorCdnProfileHostNameAvailability.md)
Validates the custom domain mapping to ensure it maps to the correct Azure Front Door endpoint in DNS.

### [Test-AzFrontDoorCdnProfileMigration](Test-AzFrontDoorCdnProfileMigration.md)
Check if a classic AFD instance can be migrated to Azure Front Door(Standard/Premium) profile.

### [Update-AzCdnEndpoint](Update-AzCdnEndpoint.md)
Updates an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
Only tags can be updated after creating an endpoint.
To update origins, use the Update Origin operation.
To update origin groups, use the Update Origin group operation.
To update custom domains, use the Update Custom Domain operation.

### [Update-AzCdnOrigin](Update-AzCdnOrigin.md)
Updates an existing origin within an endpoint.

### [Update-AzCdnOriginGroup](Update-AzCdnOriginGroup.md)
Updates an existing origin group within an endpoint.

### [Update-AzCdnProfile](Update-AzCdnProfile.md)
Updates an existing CDN profile with the specified profile name under the specified subscription and resource group.

### [Update-AzFrontDoorCdnCustomDomain](Update-AzFrontDoorCdnCustomDomain.md)
Updates an existing domain within a profile.

### [Update-AzFrontDoorCdnCustomDomainValidationToken](Update-AzFrontDoorCdnCustomDomainValidationToken.md)
Updates the domain validation token.

### [Update-AzFrontDoorCdnEndpoint](Update-AzFrontDoorCdnEndpoint.md)
Updates an existing AzureFrontDoor endpoint with the specified endpoint name under the specified subscription, resource group and profile.
Only tags can be updated after creating an endpoint.
To update origins, use the Update Origin operation.
To update origin groups, use the Update Origin group operation.
To update domains, use the Update Custom Domain operation.

### [Update-AzFrontDoorCdnOrigin](Update-AzFrontDoorCdnOrigin.md)
Updates an existing origin within an origin group.

### [Update-AzFrontDoorCdnOriginGroup](Update-AzFrontDoorCdnOriginGroup.md)
Updates an existing origin group within a profile.

### [Update-AzFrontDoorCdnProfile](Update-AzFrontDoorCdnProfile.md)
Updates an existing Azure Front Door Standard or Azure Front Door Premium or CDN profile with the specified profile name under the specified subscription and resource group.

### [Update-AzFrontDoorCdnProfileSku](Update-AzFrontDoorCdnProfileSku.md)
Upgrade a profile from Standard_AzureFrontDoor to Premium_AzureFrontDoor.

### [Update-AzFrontDoorCdnRoute](Update-AzFrontDoorCdnRoute.md)
Updates an existing route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

### [Update-AzFrontDoorCdnRule](Update-AzFrontDoorCdnRule.md)
Updates an existing delivery rule within a rule set.

### [Update-AzFrontDoorCdnSecurityPolicy](Update-AzFrontDoorCdnSecurityPolicy.md)
Updates an existing security policy within a profile.

