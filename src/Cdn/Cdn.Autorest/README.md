<!-- region Generated -->
# Az.Cdn
This directory contains the PowerShell module for the Cdn service.

---
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
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2025-06-01/afdx.json
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2025-06-01/cdn.json
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/preview/2024-07-22-preview/edgeaction.json

# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Cdn
subject-prefix: $(service-name)
commit: 9b87e611b5016ed5c8d0eea2ee4578be782e7feb

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

resourcegroup-append: true
nested-object-to-string: true

disable-transform-identity-type: true
flatten-userassignedidentity: false

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
  # Generate memory object as parameter of the cmdlet.
  - model-cmdlet:
    - model-name: ResourceReference
      cmdlet-name: New-AzCdnResourceReferenceObject
    - model-name: ResourceReference
      cmdlet-name: New-AzFrontDoorCdnResourceReferenceObject
    # origin group parameters
    - model-name: HealthProbeParameters
      cmdlet-name: New-AzCdnHealthProbeParametersObject
    - model-name: ResponseBasedOriginErrorDetectionParameters
      cmdlet-name: New-AzCdnResponseBasedOriginErrorDetectionParametersObject
    # https
    # - model-name: UserManagedHttpsParameters
    #   cmdlet-name: New-AzCdnUserManagedHttpsParametersObject
    # - model-name: CdnManagedHttpsParameters
    #   cmdlet-name: New-AzCdnManagedHttpsParametersObject
    - model-name: DeliveryRule
      cmdlet-name: New-AzCdnDeliveryRuleObject
    # CDN condition
    # - model-name: DeliveryRuleRemoteAddressCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleRemoteAddressConditionObject
    # - model-name: DeliveryRuleRequestMethodCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleRequestMethodConditionObject
    # - model-name: DeliveryRuleQueryStringCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleQueryStringConditionObject
    # - model-name: DeliveryRulePostArgsCondition
    #   cmdlet-name: New-AzCdnDeliveryRulePostArgsConditionObject
    # - model-name: DeliveryRuleRequestUriCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleRequestUriConditionObject
    # - model-name: DeliveryRuleRequestHeaderCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleRequestHeaderConditionObject
    # - model-name: DeliveryRuleRequestBodyCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleRequestBodyConditionObject
    # - model-name: DeliveryRuleRequestSchemeCondition
    # #   cmdlet-name: New-AzCdnDeliveryRuleRequestSchemeConditionObject
    # - model-name: DeliveryRuleUrlPathCondition 
    #   cmdlet-name: New-AzCdnDeliveryRuleUrlPathConditionObject
    # - model-name: DeliveryRuleUrlFileExtensionCondition 
    #   cmdlet-name: New-AzCdnDeliveryRuleUrlFileExtensionConditionObject
    # - model-name:  DeliveryRuleUrlFileNameCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleUrlFileNameConditionObject
    # - model-name:  DeliveryRuleHttpVersionCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleHttpVersionConditionObject
    # - model-name:  DeliveryRuleCookiesCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleCookiesConditionObject
    # - model-name:  DeliveryRuleIsDeviceCondition
    #   cmdlet-name: New-AzCdnDeliveryRuleIsDeviceConditionObject

    # - model-name: DeliveryRuleRequestBodyCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleRequestBodyConditionObject
    # - model-name:  DeliveryRuleCookiesCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleCookiesConditionObject
    # - model-name:  DeliveryRuleHttpVersionCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleHttpVersionConditionObject
    # - model-name:  DeliveryRuleIsDeviceCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleIsDeviceConditionObject
    # - model-name: DeliveryRulePostArgsCondition
    #   cmdlet-name: New-AzFrontDoorCdnRulePostArgsConditionObject
    # - model-name: DeliveryRuleQueryStringCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleQueryStringConditionObject
    # - model-name: DeliveryRuleRemoteAddressCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleRemoteAddressConditionObject
    # - model-name: DeliveryRuleRequestHeaderCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleRequestHeaderConditionObject
    # - model-name: DeliveryRuleRequestMethodCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleRequestMethodConditionObject
    # - model-name: DeliveryRuleRequestSchemeCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleRequestSchemeConditionObject
    # - model-name: DeliveryRuleRequestUriCondition
    #    cmdlet-name: New-AzFrontDoorCdnRuleRequestUriConditionObject
    # - model-name: DeliveryRuleUrlFileExtensionCondition 
    #    cmdlet-name: New-AzFrontDoorCdnRuleUrlFileExtensionConditionObject
    # - model-name:  DeliveryRuleUrlFileNameCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleUrlFileNameConditionObject
    # - model-name: DeliveryRuleUrlPathCondition 
    #   cmdlet-name: New-AzFrontDoorCdnRuleUrlPathConditionObject
    # - model-name:  DeliveryRuleServerPortCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleServerPortConditionObject
    # - model-name:  DeliveryRuleClientPortCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleClientPortConditionObject
    # - model-name: DeliveryRuleHostNameCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleHostNameConditionObject
    # - model-name: DeliveryRuleSocketAddrCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleSocketAddrConditionObject
    # - model-name: DeliveryRuleSslProtocolCondition
    #   cmdlet-name: New-AzFrontDoorCdnRuleSslProtocolConditionObject

    - model-name: AfdDomainHttpsParameters
      cmdlet-name: New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject

    - model-name: AfdPurgeParameters
      cmdlet-name: New-AzFrontDoorCdnPurgeParametersObject
    
    # - model-name: CustomerCertificateParameters
    #   cmdlet-name: New-AzFrontDoorCdnSecretCustomerCertificateParametersObject

    # - model-name: AzureFirstPartyManagedCertificateParameters
    #   cmdlet-name: New-AzFrontDoorCdnSecretFirstPartyManagedCertificateParametersObject
    # - model-name: ManagedCertificateParameters
    #   cmdlet-name: New-AzFrontDoorCdnSecretManagedCertificateParametersObject
    # - model-name: UrlSigningKeyParameters
    #   cmdlet-name: New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject

    - model-name: SecurityPolicyWebApplicationFirewallAssociation
      cmdlet-name: New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject
    - model-name: SecurityPolicyWebApplicationFirewallParameters
      cmdlet-name: New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject

    # OriginGroup Parameters
    - model-name: HealthProbeParameters
      cmdlet-name: New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject
    - model-name: LoadBalancingSettingsParameters
      cmdlet-name: New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject

    # CDN action

    # - model-name:  DeliveryRuleCacheExpirationAction
    #   cmdlet-name: New-AzCdnDeliveryRuleCacheExpirationActionObject
    # - model-name:  DeliveryRuleCacheKeyQueryStringAction
    #   cmdlet-name: New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject
    # - model-name:  OriginGroupOverrideAction
    #   cmdlet-name: New-AzCdnOriginGroupOverrideActionObject
    # - model-name:  UrlRedirectAction
    #   cmdlet-name: New-AzFrontDoorCdnRuleUrlRedirectActionObject
    # - model-name:  UrlRewriteAction
    #   cmdlet-name: New-AzFrontDoorCdnRuleUrlRewriteActionObject
    # - model-name:  UrlAction
    #   cmdlet-name: New-AzFrontDoorCdnRuleUrlActionObject
    # - model-name: UrlSigningAction
    #   cmdlet-name: New-AzFrontDoorCdnRuleUrlSigningActionObject
    # - model-name:  DeliveryRuleRequestHeaderAction
    #   cmdlet-name: New-AzCdnDeliveryRuleRequestHeaderActionObject
    # - model-name:  DeliveryRuleResponseHeaderAction
    #   cmdlet-name: New-AzCdnDeliveryRuleResponseHeaderActionObject  

    # - model-name:  UrlRedirectAction
    #   cmdlet-name: New-AzCdnUrlRedirectActionObject
    # - model-name:  UrlRewriteAction
    #   cmdlet-name: New-AzCdnUrlRewriteActionObject
    # - model-name: UrlSigningAction
    #   cmdlet-name: New-AzCdnUrlSigningActionObject
    # - model-name:  DeliveryRuleRequestHeaderAction
    #   cmdlet-name: New-AzFrontDoorCdnRuleRequestHeaderActionObject
    # - model-name:  DeliveryRuleResponseHeaderAction
    #   cmdlet-name: New-AzFrontDoorCdnRuleResponseHeaderActionObject
    # - model-name: DeliveryRuleRouteConfigurationOverrideAction
    #   cmdlet-name: New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject

    # CDN content
    - model-name: PurgeParameters
      cmdlet-name: New-AzCdnPurgeParametersObject
    - model-name: LoadParameters
      cmdlet-name: New-AzCdnLoadParametersObject
    - model-name: MigrationEndpointMapping
      cmdlet-name: New-AzCdnMigrationEndpointMappingObject
    # AFDX profile LogScrubbing, need to rename the memory objects, not sure how to rename a memory object currently.
    - model-name: ProfileLogScrubbing
      cmdlet-name: New-AzFrontDoorCdnProfileLogScrubbingObject
    - model-name: ProfileScrubbingRules
      cmdlet-name: New-AzFrontDoorCdnProfileScrubbingRulesObject
    # Migration to AFDx
    - model-name: MigrationParameters
      cmdlet-name: New-AzFrontDoorCdnMigrationParametersObject
    - model-name: MigrationWebApplicationFirewallMapping
      cmdlet-name: New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject
    # Upgrade sku
    - model-name: ProfileUpgradeParameters
      cmdlet-name: New-AzFrontDoorCdnProfileUpgradeParametersObject
    - model-name: ProfileChangeSkuWafMapping
      cmdlet-name: New-AzFrontDoorCdnProfileChangeSkuWafMappingObject

    - model-name: OriginGroupHealthProbeSetting
      cmdlet-name: New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject

  # 

  # rename CdnProfiles_CdnMigrateToAfd to avoid conflict with Profiles_Migrate
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^Profiles_CdnMigrateToAfd$/g, "CdnProfilesToAfd_CdnMigrateToAfd")

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
  # Remove some cmdlets' ViaIdentity which are inconvenient to call
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
      subject: NameAvailability
      variant: ^CheckViaJsonFilePath1$
    remove: true
  - where:
      subject: NameAvailability
      variant: ^CheckViaJsonString1$
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
      verb: Invoke
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

  # Hide check the availability of an afdx endpoint name
  - where:
      subject: (.*)ProfileEndpointNameAvailability
      verb: Test
    hide: true

  # Hide key group api for 2024-05-01-preview
  - where:
      subject: KeyGroup
    hide: true
  - where:
      subject: KeyGroupUpdate
    hide: true
    
  # Hide New-AzFrontDoorCdnRoute to customize
  - where:
      subject: Route 
      verb: New
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
  - where:
      subject: CdnProfileTo
    set:
      subject: CdnProfileToAFD
  # Hide classicCdn migrate command and customize, must be put after rename
  - where:
      subject-prefix: FrontDoorCdn
      subject: CdnProfilesTo
      verb: Move
    hide: true

  - where:
      subject: AbortProfileMigration
    set:
      subject: AbortProfileToAFDMigration
  - where:
      verb: Invoke
      subjectPrefix: Cdn
      subject: CanProfile
    set:
      verb: Test
      subject: ProfileMigrationCompatibility

  # Customize the output table formatting
  - where:
      model-name: CanMigrateResult
    set:
      format-table:
        properties:
          - CanMigrate
          - DefaultSku
          - Error

  - where:
      model-name: MigrateResult
    set:
      format-table:
        properties:
          - PropertiesMigratedProfileResourceIdId
        labels:
          PropertiesMigratedProfileResourceIdId: MigratedProfileResourceId

  - where:
      model-name: EdgeNode
    set:
      format-table:
        properties:
          - Id
  # Abort 
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/migrationAbort"].post.responses
    transform: >-
      return {
          "200": {
            "description": "Accepted and the operation will complete asynchronously.",
            "headers": {
              "location": {
                "type": "string"
              }
            }
          },
          "202": {
            "description": "Accepted and the operation will complete asynchronously.",
            "headers": {
              "location": {
                "type": "string"
              }
            }
          },
          "default": {
            "description": "CDN error response describing why the operation failed.",
            "schema": {
              "$ref": "../../../../../common-types/resource-management/v6/types.json#/definitions/ErrorResponse"
            }
          }
      }

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

  - where:
      subjectPrefix: Cdn
      subject: Profile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUserAssignedIdentities
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IManagedServiceIdentityUserAssignedIdentities
        change-description: 	The type of property 'IdentityUserAssignedIdentity' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUserAssignedIdentities' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IManagedServiceIdentityUserAssignedIdentities'.
        deprecated-by-version: 5.3.0
        deprecated-by-azversion: 14.4.0
        change-effective-date: 2025/11/01
  - where:
      subjectPrefix: FrontDoorCdn
      subject: Profile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUserAssignedIdentities
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IManagedServiceIdentityUserAssignedIdentities
        change-description: 	The type of property 'IdentityUserAssignedIdentity' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUserAssignedIdentities' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IManagedServiceIdentityUserAssignedIdentities'.
        deprecated-by-version: 5.3.0
        deprecated-by-azversion: 14.4.0
        change-effective-date: 2025/11/01
  - where:
      subjectPrefix: FrontDoorCdn
      subject: ProfileSku
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUserAssignedIdentities
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IManagedServiceIdentityUserAssignedIdentities
        change-description: 	The type of property 'IdentityUserAssignedIdentity' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUserAssignedIdentities' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IManagedServiceIdentityUserAssignedIdentities'.
        deprecated-by-version: 5.3.0
        deprecated-by-azversion: 14.4.0
        change-effective-date: 2025/11/01
```
