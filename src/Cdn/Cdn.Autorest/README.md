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
# Upgrade AFD without changing the existing classic CDN or standalone EdgeAction contracts.
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/Cdn/stable/2026-10-01/openapi.json
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/Cdn/preview/2026-04-01-preview/openapi.json
  - https://github.com/Azure/azure-rest-api-specs/blob/9e9079a5d235e0c804e7fbb188258a84b4221571/specification/cdn/resource-manager/Microsoft.Cdn/Cdn/preview/2024-07-22-preview/edgeaction.json

# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Cdn
subject-prefix: $(service-name)
# Change Safety: opt in -AcquirePolicyToken / -ChangeReference on write cmdlets
enable-change-safety: true
# Pin the Swagger revision for reproducible generation.
commit: 77c5c1cbdaefb13ec55c83302b6aaccfee33fd62

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

resourcegroup-append: true
nested-object-to-string: true

disable-transform-identity-type: true
flatten-userassignedidentity: false

directive:
  # Shared profile URLs need private classic operations so AFD can use the stable API independently.
  - from: swagger-document
    where: $
    transform: |
      if (!$.info || !["2026-04-01-preview", "2026-10-01"].includes($.info.version) ||
          !$.definitions.ProfileProperties) { return $; }
      const classic = new Set(["Endpoints", "CustomDomains", "Origins", "OriginGroups",
        "Policies", "ManagedRuleSets", "EdgeNodes", "CheckNameAvailability",
        "CheckNameAvailabilityWithSubscription", "ResourceUsage", "ValidateProbe"]);
      const classicProfile = new Set(["Profiles_ListResourceUsage", "Profiles_GenerateSsoUri",
        "Profiles_ListSupportedOptimizationTypes"]);
      const sharedProfile = new Set(["Profiles_List", "Profiles_ListByResourceGroup",
        "Profiles_Get", "Profiles_Create", "Profiles_Update", "Profiles_Delete"]);
      const legacy = $.info.version === "2026-04-01-preview";
      for (const [path, item] of Object.entries($.paths)) {
        for (const [method, operation] of Object.entries(item)) {
          if (!operation.operationId) { continue; }
          const id = operation.operationId;
          const isClassic = classic.has(id.split("_")[0]) || classicProfile.has(id);
          if (legacy ? !isClassic && !sharedProfile.has(id) : isClassic) {
            delete item[method];
          } else if (legacy && sharedProfile.has(id)) {
            operation.operationId = id.replace(/^Profiles_/, "ClassicProfiles_");
            for (const status of ["201", "202"]) {
              const headers = (operation.responses[status] || {}).headers || {};
              for (const name of ["Location", "Retry-After", "Azure-AsyncOperation"]) { delete headers[name]; }
            }
            if (method === "delete") {
              operation["x-ms-long-running-operation-options"] = { "final-state-via": "azure-async-operation" };
            } else if ((operation["x-ms-long-running-operation-options"] || {})["final-state-via"] === "location") {
              operation["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
            }
          }
        }
        if (!Object.values(item).some(operation => operation.operationId)) {
          delete $.paths[path];
        } else if (legacy && Object.values(item).some(operation =>
            operation.operationId && operation.operationId.startsWith("ClassicProfiles_"))) {
          $["x-ms-paths"] = $["x-ms-paths"] || {};
          $["x-ms-paths"][path + "?api-version=2026-04-01-preview"] = item;
          delete $.paths[path];
        }
      }
      return $;
  # Keep the implementation-only classic profile operations out of the public command surface.
  - where:
      subject: ClassicProfile
    hide: true
  # Existing classic wrappers splat Name, not the generated ProfileName.
  - where:
      subject: ClassicProfile
      parameter-name: ProfileName
    set:
      parameter-name: Name
  # Changing EdgeAction inputs must not change completion metadata on existing CDN models.
  - from: source-file-csharp
    where: $
    transform: |
      if (/partial class (?:EdgeActionAutoGenerated|DeliveryRuleEdgeActionParameters)\b/.test($)) {
        return $.replace(/PSArgumentCompleterAttribute\((?=[^\r\n]*"(?:clientRequest|ClientRequest)")[^\r\n]*\)/g,
          'PSArgumentCompleterAttribute("clientRequest", "originRequest", "originResponse", "clientResponse", "ClientRequest", "OriginRequest", "ClientResponse")');
      }
      if (/partial class CdnWebApplicationFirewallPolicy(?:Properties)?\b/.test($)) {
        return $.replace(/PSArgumentCompleterAttribute\("Creating", "Succeeded", "Failed"\)/g,
          'PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Upgrading")');
      }
      return $;
  # Share the equivalent ARM error schema so legacy EdgeAction callbacks retain IErrorResponse.
  - from: swagger-document
    where: $
    transform: |
      if (!$.info || $.info.version !== "2024-07-22-preview") {
        return $;
      }
      for (const path of Object.values($.paths)) {
        for (const operation of Object.values(path)) {
          if (operation.responses && operation.responses.default && operation.responses.default.schema) {
            operation.responses.default.schema.$ref =
              "https://github.com/Azure/azure-rest-api-specs/blob/77c5c1cbdaefb13ec55c83302b6aaccfee33fd62/specification/common-types/resource-management/v6/types.json#/definitions/ErrorResponse";
          }
        }
      }
      return $;
  # Retain previously published URL signing model/serialization surfaces, not a new October feature.
  # Removing these compatibility shapes requires a separately approved breaking-change release.
  - from: swagger-document
    where: $.definitions
    transform: |
      if (!$.DeliveryRuleActionName || $.AfdUrlSigningAction) {
        return $;
      }
      $.AfdUrlSigningAction = {
        type: "object",
        description: "Defines the url signing action for the delivery rule.",
        properties: {
          parameters: {
            $ref: "#/definitions/AfdUrlSigningActionParameters",
            description: "Defines the parameters for the action."
          }
        },
        required: ["parameters"],
        allOf: [{ $ref: "#/definitions/DeliveryRuleAction" }],
        "x-ms-discriminator-value": "AfdUrlSigning"
      };
      $.AfdUrlSigningActionParameters = {
        type: "object",
        description: "Defines the parameters for the Url Signing action.",
        properties: {
          typeName: { $ref: "#/definitions/TypeName" },
          keyGroupReference: {
            $ref: "#/definitions/ResourceReference",
            description: "Resource reference to the Azure Key Vault secret. Expected to be in format of /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/keyGroups/{keyGroupName}"
          },
          algorithm: {
            $ref: "#/definitions/Algorithm",
            description: "Algorithm to use for URL signing"
          },
          parameterNameOverride: {
            type: "array",
            description: "Defines which query string parameters in the url to be considered for expires, key id etc.",
            items: { $ref: "#/definitions/UrlSigningParamIdentifier" },
            "x-ms-identifiers": ["paramName"]
          }
        },
        required: ["typeName", "keyGroupReference"]
      };
      $.TypeName = {
        type: "string",
        enum: ["DeliveryRuleAfdUrlSigningActionParameters"],
        "x-ms-enum": {
          name: "TypeName",
          modelAsString: true,
          values: [{
            name: "DeliveryRuleAfdUrlSigningActionParameters",
            value: "DeliveryRuleAfdUrlSigningActionParameters"
          }]
        }
      };
      $.DeliveryRuleActionName.enum.push("AfdUrlSigning");
      $.DeliveryRuleActionName["x-ms-enum"].values.push({
        name: "AfdUrlSigning", value: "AfdUrlSigning"
      });
  # Remove unused version-specific schemas before AutoRest merges classic and AFD models.
  - from: swagger-document
    where: $
    transform: |
      if (!$.info || !["2026-04-01-preview", "2026-10-01"].includes($.info.version) ||
          !$.definitions.ProfileProperties) { return $; }
      const definitions = $.definitions;
      const used = new Set();
      const visit = value => {
        if (!value || typeof value !== "object") { return; }
        const ref = value["$ref"];
        if (ref && ref.startsWith("#/definitions/")) {
          const name = ref.slice("#/definitions/".length);
          if (!used.has(name) && definitions[name]) {
            used.add(name);
            visit(definitions[name]);
            if (definitions[name].discriminator) {
              for (const [child, schema] of Object.entries(definitions)) {
                if ((schema.allOf || []).some(parent => parent["$ref"] === ref)) {
                  visit({ "$ref": "#/definitions/" + child });
                }
              }
            }
          }
        }
        Object.values(value).forEach(visit);
      };
      visit([$.paths, $["x-ms-paths"], $.parameters, $.responses]);
      for (const name of Object.keys(definitions)) {
        if (!used.has(name)) { delete definitions[name]; }
      }
      return $;
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

  # Hide retired classic CDN WAF policy API
  - where:
      subject: Policy
      verb: Get|New|Update|Remove
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
              "$ref": "../../../../../../common-types/resource-management/v6/types.json#/definitions/ErrorResponse"
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

  # --------------------------------------------------------------------------
  # LRO contract workaround: rewrite final-state-via location -> original-uri
  # --------------------------------------------------------------------------
  # Many CDN swagger operations declare final-state-via: location but the
  # live service returns 200/201 synchronously with the terminal resource body
  # and does NOT emit a Location header. The autorest.powershell v4 LRO
  # client then calls `new Uri("")` and throws
  #   UriFormatException: Invalid URI: The URI is empty.
  # Rewriting to original-uri makes the client re-GET the original request
  # URL, which already has the completed resource.
  #
  # We apply this to non-delete operations that currently declare
  # final-state-via: location in the CDN openapi spec.

  # --- Microsoft.Cdn/profiles ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  # --- Microsoft.Cdn/profiles/endpoints ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  # --- endpoints/customDomains ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  # --- endpoints/customDomains actions ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}/disableCustomHttps"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}/enableCustomHttps"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;

  # --- endpoints/originGroups ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/originGroups/{originGroupName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/originGroups/{originGroupName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  # --- endpoints/origins ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/origins/{originName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/origins/{originName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  # --- cdnWebApplicationFirewallPolicies ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/cdnWebApplicationFirewallPolicies/{policyName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/cdnWebApplicationFirewallPolicies/{policyName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;

  # --- canMigrate / migrate ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/canMigrate"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/migrate"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;

  # --- profiles/agents ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/agents/{agentName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/agents/{agentName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  # --- profiles/cdnCanMigrateToAfd, cdnMigrateToAfd, migrationAbort, upgrade ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/cdnCanMigrateToAfd"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/cdnMigrateToAfd"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/migrationAbort"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/upgrade"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;

  # --- profiles/deploymentVersions/{versionName}/approve ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/deploymentVersions/{versionName}/approve"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;

  # --- profiles/keyGroups ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/keyGroups/{keyGroupName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/keyGroups/{keyGroupName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  # --- webAgents ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/webAgents/{webAgentName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/webAgents/{webAgentName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  # --- webAgents/knowledgeSources ---
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/webAgents/{webAgentName}/knowledgeSources/{knowledgeSourceName}"].put
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/webAgents/{webAgentName}/knowledgeSources/{knowledgeSourceName}"].patch
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/webAgents/{webAgentName}/knowledgeSources/{knowledgeSourceName}/purge"].post
    transform: >-
      if ($["x-ms-long-running-operation-options"] && $["x-ms-long-running-operation-options"]["final-state-via"] === "location") {
        $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";
      }
      return $;

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
