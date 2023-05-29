<!-- region Generated -->
# Az.Cdn
This directory contains the PowerShell module for the Cdn service.

---
## Status
[![Az.Cdn](https://img.shields.io/powershellgallery/v/Az.Cdn.svg?style=flat-square&label=Az.Cdn "Az.Cdn")](https://www.powershellgallery.com/packages/Az.Cdn/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Cdn`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/preview/2022-11-01-preview/afdx.json
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/preview/2022-11-01-preview/cdn.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Cdn
subject-prefix: $(service-name)
branch: 4903b1ed79e30f689d7c469cfa06734cfcd106d6

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

resourcegroup-append: true
nested-object-to-string: true

directive:
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^AFDProfiles_Upgrade$/g, "AFDProfileSku_Upgrade")
  - no-inline:
    # AFDX
    - SecurityPolicyPropertiesParameters
    - SecretParameters
    - AFDDomainHttpsParameters
    - LoadBalancingSettingsParameters
    # CDN
    - CustomDomainHttpsParameters
    - ResponseBasedOriginErrorDetectionParameters
    # Both CDN and AFDX
    - HealthProbeParameters
  # Generate memory object as parameter of the cmelet.
  - model-cmdlet:
    - ResourceReference
    # origin group parameters
    - HealthProbeParameters
    - ResponseBasedOriginErrorDetectionParameters
    # https
    - UserManagedHttpsParameters
    - CdnManagedHttpsParameters
    - DeliveryRule
    # CDN condition
    - DeliveryRuleRemoteAddressCondition
    - DeliveryRuleRequestMethodCondition
    - DeliveryRuleQueryStringCondition
    - DeliveryRulePostArgsCondition
    - DeliveryRuleRequestUriCondition
    - DeliveryRuleRequestHeaderCondition
    - DeliveryRuleRequestBodyCondition
    - DeliveryRuleRequestSchemeCondition
    - DeliveryRuleUrlPathCondition
    - DeliveryRuleUrlFileExtensionCondition
    - DeliveryRuleUrlFileNameCondition
    - DeliveryRuleHttpVersionCondition
    - DeliveryRuleCookiesCondition
    - DeliveryRuleIsDeviceCondition
    # CDN action
    - DeliveryRuleCacheExpirationAction
    - DeliveryRuleCacheKeyQueryStringAction
    - OriginGroupOverrideAction
    - UrlRedirectAction
    - UrlSigningAction
    - UrlRewriteAction
    - DeliveryRuleRequestHeaderAction
    - DeliveryRuleResponseHeaderAction
    # CDN content
    - PurgeParameters
    - LoadParameters

    # Migration to AFDx
    # - MigrationParameters
    # - MigrationWebApplicationFirewallMapping
    # Upgrade sku
    # - ProfileUpgradeParameters
    # - ProfileChangeSkuWafMapping

  - where:
      model-name: .*
    set:
      format-table:
        exclude-properties:
          - SystemData
          - SystemDataCreatedAt
          - SystemDataCreatedBy
          - SystemDataCreatedByType
          - SystemDataLastModifiedAt
          - SystemDataLastModifiedBy
          - SystemDataLastModifiedByType
          
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Patch$|^PatchViaIdentity$|^Check$|^Check1$|^CheckViaIdentity$|^Validate$|^ValidateViaIdentity$
      subject: ^(?!RuleSet).+$
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: ^RuleSet$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Remove some cmdlets' ViaIdentity which are inconvinient to call
  - where:
      variant: ^CheckViaIdentity$|^CheckViaIdentityExpanded$
      subject: ^NameAvailability$|^EndpointNameAvailability$
    remove: true
  - where:
      variant: ^ValidateViaIdentity$|^ValidateViaIdentityExpanded$
      subject: ^Probe$
    remove: true
  - where:
      variant: ^EnableExpanded$|^EnableViaIdentityExpanded$
      subject: ^CustomDomainCustomHttps$
    remove: true
  - where:
      variant: ^UpgradeExpanded$
      subject: AFDProfileSku
    remove: true

  # Hide Cdn profile
  - where:
      subject: Profile
    hide: true
  - where:
      subject: ProfileSsoUri
    hide: true
  - where:
      subject: SecretValidate
    hide: true
  - where:
      subject: LogAnalytic(.*)
    hide: true
  # Hide classicAfd migrate command and customize
  - where:
      subject: CanProfileMigrate
    hide: true
  - where:
      subject: CommitProfileMigration
    hide: true
  # Hide UpgradeSku command and customize
  - where:
      subject: AFDProfileSku
      verb: Update|Upgrade
    hide: true
  # Hide validate the secret
  - where:
      subject: (.*)ProfileSecret
      verb: Test
    hide: true

  # Rename
  - where:
      subject: Afd(.*)
    set:
      subject-prefix: FrontDoorCdn
      subject: $1

  - where:
      subject: Rule
    set:
      subject-prefix: FrontDoorCdn  
  - where:
      subject: RuleSet
    set:
      subject-prefix: FrontDoorCdn
  - where:
      subject: RuleSetResourceUsage
    set:
      subject-prefix: FrontDoorCdn
    
  - where:
      subject: Route
    set:
      subject-prefix: FrontDoorCdn
      subject: Route
  - where:
      subject: Secret
    set:
      subject-prefix: FrontDoorCdn
      subject: Secret   
  - where:
      subject: SecurityPolicy
    set:
      subject-prefix: FrontDoorCdn
      subject: SecurityPolicy  
  - where:
      subject: EndpointNameAvailability
    set:
      subject-prefix: FrontDoorCdn
  - where:
      subject: ResourceUsage
    set:
      subject: SubscriptionResourceUsage

  # https://github.com/Azure/autorest.powershell/issues/906
  - where:
      model-name: AfdDomainUpdatePropertiesParameters
      property-name: PreValidatedCustomDomainResourceId
    set:
      property-name: AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId
  - where:
      model-name: AfdDomainUpdatePropertiesParameters
      property-name: PreValidatedCustomDomainResourceIdId
    set:
      property-name: PreValidatedCustomDomainResourceId

  # Delete 404
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}"].delete
    transform: >-
      $["x-ms-long-running-operation-options"] = {"final-state-via": "azure-async-operation"}
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/originGroups/{originGroupName}"].delete
    transform: >-
      $["x-ms-long-running-operation-options"] = {"final-state-via": "azure-async-operation"}
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/origins/{originName}"].delete
    transform: >-
      $["x-ms-long-running-operation-options"] = {"final-state-via": "azure-async-operation"}
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}"].delete
    transform: >-
      $["x-ms-long-running-operation-options"] = {"final-state-via": "azure-async-operation"}
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}"].delete
    transform: >-
      $["x-ms-long-running-operation-options"] = {"final-state-via": "azure-async-operation"}
```
