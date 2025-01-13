# Overall
This directory contains management plane service clients of Az.Websites module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
title: WebSiteManagementClient
openapi-type: arm
clear-output-folder: true
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```

###
``` yaml
commit: d9249ed91d16c8ff8bf81e2df13e54bd0439bb64
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.CertificateRegistration/stable/2021-01-15/AppServiceCertificateOrders.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.CertificateRegistration/stable/2021-01-15/CertificateOrdersDiagnostics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.CertificateRegistration/stable/2021-01-15/CertificateRegistrationProvider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.DomainRegistration/stable/2021-01-15/Domains.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.DomainRegistration/stable/2021-01-15/TopLevelDomains.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.DomainRegistration/stable/2021-01-15/DomainRegistrationProvider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/AppServiceEnvironments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/AppServicePlans.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/Certificates.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/CommonDefinitions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/DeletedWebApps.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/Diagnostics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/Global.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/KubeEnvironments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/Provider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/Recommendations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/ResourceHealthMetadata.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/ResourceProvider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/StaticSites.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/web/resource-manager/Microsoft.Web/stable/2021-01-15/WebApps.json
output-folder: Generated

namespace: Microsoft.Azure.Management.WebSites

directive:
  - suppress: XmsResourceInPutResponse
    from: WebApps.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}/keys/{keyName}"].put
    reason: Model type is not an Azure resource
  - suppress: RequiredPropertiesMissingInResourceModel
    from: WebApps.json
    where: $.definitions.KeyInfo
    reason: Model type is not an Azure resource
  - suppress: BodyTopLevelProperties
    from: WebApps.json
    where: $.definitions.KeyInfo.properties
    reason: Model type is not an Azure resource
    # suppress each RPC 3016 error
  - where: $.definitions.FunctionSecrets.properties.trigger_url
    suppress: R3016
    reason: This requires a breaking change in functions runtime API.
  - where: $.definitions.Identifier.properties
    suppress: R3019
    reason: It's an old API, will resolve in next API version
  - where: $.definitions.VnetGateway
    suppress: R4015
    reason: Does not have list operation
  - where: $.definitions.VnetInfo
    suppress: R4015
    reason: Does not have list operation
  - suppress: R4009
    from: AppServiceCertificateOrders.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: CertificateOrdersDiagnostics.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: CertificateRegistrationProvider.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: Domains.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: TopLevelDomains.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: DomainRegistrationProvider.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: Certificates.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: CommonDefinitions.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: DeletedWebApps.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: Diagnostics.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: Global.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: Provider.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: Recommendations.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: WebApps.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: StaticSites.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: AppServiceEnvironments.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: AppServicePlans.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: ResourceHealthMetadata.json
    reason: SystemData will implement in next version.
  - suppress: R4009
    from: KubeEnvironments.json
    reason: SystemData will implement in next version.
  - suppress: R4015
    from: WebApps.json
    where: $.definitions.NetworkFeatures
    reason: Will fix in next version
  - suppress: R4019
    from: Recommendations.json
    reason: Will fix in next version
  - suppress: R4019
    from: WebApps.json
    reason: Will fix in next version
  - suppress: R3021
    from: WebApps.json
    reason: Will fix in next version
  - suppress: R4011
    from: WebApps.json
    reason: Will fix in next version
  - suppress: R4011
    from: AppServiceEnvironments.json
    reason: Will fix in next version
  - suppress: R4011
    from: StaticSites.json
    reason: Will fix in next version
  - suppress: R4011
    from: AppServicePlans.json
    reason: Will fix in next version
  - suppress: D5001
    reason: Will fix in next version
  - suppress: R1003
    reason: Will fix in next version
  - suppress: R2001
    reason: Will fix in next version
  - suppress: R2029
    reason: Will fix in next version
  - suppress: R2063
    reason: Will fix in next version
  - suppress: R3010
    reason: Will fix in next version

  - where:
     model-name: AutoHealTriggers
     property-name: PrivateBytesInKb
    set:
     property-name: PrivateBytesInKB
  - from: swagger-document
    where: $.definitions.PushSettings
    transform: >-
      return {
        "description": "Push settings for the App.",
        "type": "object",
        "required": [
          "isPushEnabled"
        ],
        "allOf": [
          {
            "$ref": "#/definitions/ProxyOnlyResource"
          }
        ],
        "properties": {
          "isPushEnabled": {
            "description": "Gets or sets a flag indicating whether the Push endpoint is enabled.",
            "type": "boolean"
          },
          "tagWhitelistJson": {
            "description": "Gets or sets a JSON string containing a list of tags that are in the allowed list for use by the push registration endpoint.",
            "type": "string"
          },
          "tagsRequiringAuth": {
            "description": "Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.\nTags can consist of alphanumeric characters and the following:\n'_', '@', '#', '.', ':', '-'. \nValidation should be performed at the PushRequestHandler.",
            "type": "string"
          },
          "dynamicTagsJson": {
            "description": "Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.",
            "type": "string"
          }
        }
      }
  - where:
     model-name: SiteConfig
     property-name: ScmIPSecurityRestrictions
    set:
     property-name: ScmIpSecurityRestrictions
  - where:
     model-name: SiteConfig
     property-name: IPSecurityRestrictions
    set:
     property-name: IpSecurityRestrictions
  - where:
     model-name: SiteConfig
     property-name: ScmIPSecurityRestrictionsUseMain
    set:
     property-name: ScmIpSecurityRestrictionsUseMain
  - where:
     model-name: SiteConfig
     property-name: AcrUserManagedIdentityId
    set:
     property-name: AcrUserManagedIdentityID
  - where:
     model-name: Site
     property-name: PossibleOutboundIPAddresses
    set:
     property-name: PossibleOutboundIpAddresses
  - where:
     model-name: Site
     property-name: OutboundIPAddresses
    set:
     property-name: OutboundIpAddresses
  - where:
     model-name: BackupItem
     property-name: PropertiesName
    set:
     property-name: BackupItemName
  - where:
     model-name: IpSecurityRestriction
     property-name: IPAddress
    set:
     property-name: IpAddress
```