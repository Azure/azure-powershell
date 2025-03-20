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
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2024-09-01/afdx.json
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2024-09-01/cdn.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Cdn
subject-prefix: $(service-name)
commit: cf9f241708ed82f2dad218fed3c09ca5fd191311

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
  # Generate memory object as parameter of the cmelet.
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
    # AFDX profile LogScrubbing, need to rename the memory ojects, not sure how to rename a memory object currently.
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
  - where:
      subject: NameAvailability
      variant: ^CheckViaJsonFilePath1ViaJsonFilePath$
    remove: true
  - where:
      subject: NameAvailability
      variant: ^CheckViaJsonString1ViaJsonString$
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
              "$ref": "../../../../../common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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

  # announce upcoming MI-related breaking changes
  - where:
      parameter-name: IdentityType
    set:
      breaking-change:
        change-description: IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      breaking-change:
        old-parameter-type: Hashtable
        new-parameter-type: string[]
        change-description: IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: EndpointContent
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: 	The type of property 'ContentPath' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: EndpointContent
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: 	The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: EdgeNode
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup]
        change-description: The type of property 'IPAddressGroup' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEdgeNode' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedCustomDomain
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedCustomDomain]
        change-description: The type of property 'CustomDomain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedCustomDomain' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedCustomDomain]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedOrigin
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedOrigin]
        change-description: The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedOrigin' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedOrigin]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedOriginGroup
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedOriginGroup]
        change-description: The type of property 'OriginGroup' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedOriginGroup' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeepCreatedOriginGroup]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: MMicrosoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRule
        replacement-cmdlet-output-type:  System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRule]
        change-description: The type of property 'DeliveryPolicyRule' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRule' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRule]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: MMicrosoft.Azure.PowerShell.Cmdlets.Cdn.Models.IGeoFilter
        replacement-cmdlet-output-type:  System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IGeoFilter]
        change-description: The type of property 'GeoFilter' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IGeoFilter' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IGeoFilter]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: MMicrosoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningKey
        replacement-cmdlet-output-type:  System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningKey]
        change-description: The type of property 'UrlSigningKey' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningKey' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningKey]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ContentTypesToCompress, CountryCode' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEndpoint' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  # New-AzCdnEndpoint
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction1
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction]
        change-description: The type of property 'Action' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction1' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]
        change-description: The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Endpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]
        change-description: The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: OriginGroup
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]
        change-description: The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: OriginGroup
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]
        change-description: 	The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: Profile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules]
        change-description: The type of property 'LogScrubbingRule' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: Profile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules]
        change-description: The type of property 'LogScrubbingRule' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
# Update-AzFrontDoorCdnProfileSku
  - where:
      subjectPrefix: FrontDoorCdn
      subject: ProfileSku
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules]
        change-description: The type of property 'LogScrubbingRule' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: ProfileSku
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileChangeSkuWafMapping
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileChangeSkuWafMapping]
        change-description: The type of property 'WafMappingList' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfileUpgradeParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileChangeSkuWafMapping' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileChangeSkuWafMapping]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: Route
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference]
        change-description: The type of property 'CustomDomain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: Route
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]
        change-description: The type of property 'RuleSet' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: Route
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: Rule
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction1
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction]
        change-description: breaking change caused by autorest upgrade
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: Rule
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction
        change-description: The type of property 'Action' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction1' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: Rule
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]
        change-description: The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
# Test-AzFrontDoorCdnProfileMigration
  - where:
      subjectPrefix: FrontDoorCdn
      subject: ProfileMigration
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorType
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorType]
        change-description: The type of property 'Error' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ICanMigrateResult' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorType' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorType]'.	
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      parameter-name: Action
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction
        change-description: The element type for parameter 'Action' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      parameter-name: Action
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction
        change-description: The element type for parameter 'Action' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
# Object
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleCookiesCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleCookiesCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleHttpVersionCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleCookiesCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleIsDeviceCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleCookiesCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRule
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction1
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction]
        change-description: The type of property 'Action' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction1' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRule
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]
        change-description: The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRule
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]
        change-description: The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      parameter-name: Action
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction
        change-description: The element type for parameter 'Action' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRulePostArgsCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRulePostArgsCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleQueryStringCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: 	The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleQueryStringCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleRemoteAddressCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRemoteAddressCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleRequestBodyCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestBodyCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleRequestHeaderCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestHeaderCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleRequestMethodCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestMethodCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleRequestSchemeCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestSchemeCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleRequestUriCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestUriCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleUrlFileExtensionCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleUrlFileExtensionCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleUrlFileNameCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleUrlFileNameCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: DeliveryRuleUrlPathCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleUrlPathCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: LoadParameters
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ContentPath, ContentPath' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.LoadParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: ResponseBasedOriginErrorDetectionParameters
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]
        change-description: The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: UrlSigningAction
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier]
        change-description: The type of property 'ParameterNameOverride' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.UrlSigningAction' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: Cdn
      subject: UrlSigningAction
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier]
        change-description: The type of property 'ParameterNameOverride' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.UrlSigningAction' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: MigrationParameters
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationWebApplicationFirewallMapping
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationWebApplicationFirewallMapping]
        change-description: The type of property 'MigrationWebApplicationFirewallMapping' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.MigrationParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationWebApplicationFirewallMapping' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationWebApplicationFirewallMapping]'.	
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: ProfileLogScrubbing
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules]IMigrationWebApplicationFirewallMapping]
        change-description: The type of property 'ScrubbingRule' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ProfileLogScrubbing' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileScrubbingRules]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: ProfileUpgradeParameters
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileChangeSkuWafMapping
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileChangeSkuWafMapping]
        change-description: The type of property 'WafMappingList' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ProfileUpgradeParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileChangeSkuWafMapping' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IProfileChangeSkuWafMapping]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: PurgeParameters
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.AfdPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: PurgeParameters
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.AfdPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleClientPortCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleClientPortCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleCookiesCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: 	The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleCookiesCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleHostNameCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleHostNameCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleHttpVersionCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleHttpVersionCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleIsDeviceCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleIsDeviceCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RulePostArgsCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRulePostArgsCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleQueryStringCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleQueryStringCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleRemoteAddressCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRemoteAddressCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleRequestBodyCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestBodyCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleRequestHeaderCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestHeaderCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleRequestMethodCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestMethodCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleRequestSchemeCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestSchemeCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleRequestUriCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleRequestUriCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleServerPortCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleServerPortCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleSocketAddrCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleSocketAddrCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleUrlFileNameCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleUrlFileNameCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleUrlPathCondition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'ParameterMatchValue' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.DeliveryRuleUrlPathCondition' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: RuleUrlSigningAction
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier]
        change-description: The type of property 'ParameterNameOverride' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.UrlSigningAction' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: SecretCustomerCertificateParameters
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'SubjectAlternativeName' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.CustomerCertificateParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: SecretFirstPartyManagedCertificateParameters
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'SubjectAlternativeName' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.AzureFirstPartyManagedCertificateParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: SecurityPolicyWebApplicationFirewallAssociation
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference]
        change-description: The type of property 'Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.SecurityPolicyWebApplicationFirewallAssociation' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: SecurityPolicyWebApplicationFirewallAssociation
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'PatternsToMatch' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.SecurityPolicyWebApplicationFirewallAssociation' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: SecurityPolicyWebApplicationFirewallAssociation
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecurityPolicyWebApplicationFirewallAssociation
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecurityPolicyWebApplicationFirewallAssociation]
        change-description: The type of property 'Association' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.SecurityPolicyWebApplicationFirewallParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecurityPolicyWebApplicationFirewallAssociation' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecurityPolicyWebApplicationFirewallAssociation]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: SecurityPolicyWebApplicationFirewallAssociation
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference]
        change-description: The type of property 'Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ISecurityPolicyWebApplicationFirewallAssociation' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: SecurityPolicyWebApplicationFirewallAssociation
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'PatternsToMatch' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ISecurityPolicyWebApplicationFirewallAssociation' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoorCdn
      subject: SecurityPolicyWebApplicationFirewallAssociation
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.String[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.String]
        change-description: The type of property 'PatternsToMatch' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ISecurityPolicyWebApplicationFirewallAssociation' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  # # New-AzCdnManagedHttpsParametersObject
  # - where:
  #     verb: New
  #     subject: ManagedHttpsParameters
  #     variant: Create
  #   set:
  #     breaking-change:
  #       change-description: Add a new mandatory parameter CertificateSourceParameterTypeName
  #       deprecated-by-version: 5.0.0
  #       deprecated-by-azversion: 14.0.0
  #       change-effective-date: 2025/5/19
  # # New-AzCdnUserManagedHttpsParametersObject
  # - where:
  #     verb: New
  #     subject: UserManagedHttpsParameters
  #     variant: Create
  #   set:
  #     breaking-change:
  #       change-description: Add a new mandatory parameter CertificateSourceParameterTypeName
  #       deprecated-by-version: 5.0.0
  #       deprecated-by-azversion: 14.0.0
  #       change-effective-date: 2025/5/19
```
