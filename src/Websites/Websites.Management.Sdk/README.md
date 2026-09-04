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
description: WebSite Management Client
openapi-type: arm
azure-arm: true
clear-output-folder: true
reflect-api-versions: true
license-header: MICROSOFT_MIT_NO_VERSION
```

###
``` yaml
commit: 9e9017617ee84fd46b0be3fe6a431e13bde18bd2
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

# Preserve the property names produced by the retired autorest.csharp (track 1) generator.
# Without these, modelerfour renames Ip -> IP (and similar), which is a breaking change
# for every Az.Websites output object that surfaces these models.
directive:
  # Microsoft.Web marks 404 responses as `x-ms-error-response: true`, which makes
  # modelerfour file them under operation.exceptions instead of operation.responses.
  # The SDK generator then omits 404 from the success-code predicate and throws,
  # whereas the Track 1 SDK returned a null body. Dropping the annotation restores
  # `(int)_statusCode != 200 && (int)_statusCode != 404`. 409/429 are left alone.
  - from: swagger-document
    where: $.paths[*][*].responses["404"]
    transform: delete $["x-ms-error-response"]
  - where:
      model-name: AddressResponse
      property-name: ServiceIPAddress
    set:
      property-name: ServiceIpAddress
  - where:
      model-name: AddressResponse
      property-name: InternalIPAddress
    set:
      property-name: InternalIpAddress
  - where:
      model-name: AddressResponse
      property-name: OutboundIPAddresses
    set:
      property-name: OutboundIpAddresses
  - where:
      model-name: ApplicationStackResource
      property-name: PropertiesName
    set:
      property-name: ApplicationStackResourceName
  - where:
      model-name: AppServiceEnvironment
      property-name: UserWhitelistedIPRanges
    set:
      property-name: UserWhitelistedIpRanges
  - where:
      model-name: AppServiceEnvironmentPatchResource
      property-name: UserWhitelistedIPRanges
    set:
      property-name: UserWhitelistedIpRanges
  - where:
      model-name: AppServiceEnvironmentResource
      property-name: UserWhitelistedIPRanges
    set:
      property-name: UserWhitelistedIpRanges
  - where:
      model-name: AseV3NetworkingConfiguration
      property-name: WindowsOutboundIPAddresses
    set:
      property-name: WindowsOutboundIpAddresses
  - where:
      model-name: AseV3NetworkingConfiguration
      property-name: LinuxOutboundIPAddresses
    set:
      property-name: LinuxOutboundIpAddresses
  - where:
      model-name: AutoHealTriggers
      property-name: PrivateBytesInKb
    set:
      property-name: PrivateBytesInKB
  - where:
      model-name: AzureActiveDirectoryLogin
      property-name: DisableWwwAuthenticate
    set:
      property-name: DisableWWWAuthenticate
  - where:
      model-name: BackupItem
      property-name: PropertiesName
    set:
      property-name: BackupItemName
  - where:
      model-name: BillingMeter
      property-name: OSType
    set:
      property-name: OsType
  - where:
      model-name: DeletedAppRestoreRequest
      property-name: UseDrSecondary
    set:
      property-name: UseDRSecondary
  - where:
      model-name: DeletedSite
      property-name: PropertiesKind
    set:
      property-name: DeletedSiteKind
  - where:
      model-name: EndpointDetail
      property-name: IPAddress
    set:
      property-name: IpAddress
  - where:
      model-name: FunctionAppStack
      property-name: PreferredOS
    set:
      property-name: PreferredOs
  - where:
      model-name: IpSecurityRestriction
      property-name: IPAddress
    set:
      property-name: IpAddress
  - where:
      model-name: KubeEnvironment
      property-name: StaticIP
    set:
      property-name: StaticIp
  - where:
      model-name: KubeEnvironment
      property-name: AksResourceId
    set:
      property-name: AksResourceID
  - where:
      model-name: KubeEnvironmentPatchResource
      property-name: StaticIP
    set:
      property-name: StaticIp
  - where:
      model-name: KubeEnvironmentPatchResource
      property-name: AksResourceId
    set:
      property-name: AksResourceID
  - where:
      model-name: RemotePrivateEndpointConnection
      property-name: IPAddresses
    set:
      property-name: IpAddresses
  - where:
      model-name: RemotePrivateEndpointConnectionARMResource
      property-name: IPAddresses
    set:
      property-name: IpAddresses
  - where:
      model-name: ResourceMetricDefinition
      property-name: ResourceMetricDefinitionProperties
    set:
      property-name: Properties
  - where:
      model-name: Site
      property-name: OutboundIPAddresses
    set:
      property-name: OutboundIpAddresses
  - where:
      model-name: Site
      property-name: PossibleOutboundIPAddresses
    set:
      property-name: PossibleOutboundIpAddresses
  - where:
      model-name: SiteConfig
      property-name: AcrUserManagedIdentityId
    set:
      property-name: AcrUserManagedIdentityID
  - where:
      model-name: SiteConfig
      property-name: IPSecurityRestrictions
    set:
      property-name: IpSecurityRestrictions
  - where:
      model-name: SiteConfig
      property-name: ScmIPSecurityRestrictions
    set:
      property-name: ScmIpSecurityRestrictions
  - where:
      model-name: SiteConfig
      property-name: ScmIPSecurityRestrictionsUseMain
    set:
      property-name: ScmIpSecurityRestrictionsUseMain
  - where:
      model-name: SiteConfigResource
      property-name: AcrUserManagedIdentityId
    set:
      property-name: AcrUserManagedIdentityID
  - where:
      model-name: SiteConfigResource
      property-name: IPSecurityRestrictions
    set:
      property-name: IpSecurityRestrictions
  - where:
      model-name: SiteConfigResource
      property-name: ScmIPSecurityRestrictions
    set:
      property-name: ScmIpSecurityRestrictions
  - where:
      model-name: SiteConfigResource
      property-name: ScmIPSecurityRestrictionsUseMain
    set:
      property-name: ScmIpSecurityRestrictionsUseMain
  - where:
      model-name: SitePatchResource
      property-name: OutboundIPAddresses
    set:
      property-name: OutboundIpAddresses
  - where:
      model-name: SitePatchResource
      property-name: PossibleOutboundIPAddresses
    set:
      property-name: PossibleOutboundIpAddresses
  - where:
      model-name: SnapshotRestoreRequest
      property-name: UseDrSecondary
    set:
      property-name: UseDRSecondary
  - where:
      model-name: WebAppStack
      property-name: PreferredOS
    set:
      property-name: PreferredOs
```
