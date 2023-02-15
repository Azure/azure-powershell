<!-- region Generated -->
# Az.Functions
This directory contains the PowerShell module for the Functions service.

---
## Status
[![Az.Functions](https://img.shields.io/powershellgallery/v/Az.Functions.svg?style=flat-square&label=Az.Functions "Az.Functions")](https://www.powershellgallery.com/packages/Az.Functions/)

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
For information on how to develop for `Az.Functions`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

### Suppression

``` yaml
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
```

``` yaml
branch: main
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/web/resource-manager/Microsoft.CertificateRegistration/stable/2019-08-01/AppServiceCertificateOrders.json
  - $(repo)/specification/web/resource-manager/Microsoft.CertificateRegistration/stable/2019-08-01/CertificateRegistrationProvider.json
  - $(repo)/specification/web/resource-manager/Microsoft.DomainRegistration/stable/2019-08-01/Domains.json
  - $(repo)/specification/web/resource-manager/Microsoft.DomainRegistration/stable/2019-08-01/TopLevelDomains.json
  - $(repo)/specification/web/resource-manager/Microsoft.DomainRegistration/stable/2019-08-01/DomainRegistrationProvider.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/Certificates.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/CommonDefinitions.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/DeletedWebApps.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/Diagnostics.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/Provider.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/Recommendations.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/ResourceProvider.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/WebApps.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/StaticSites.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/AppServiceEnvironments.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/AppServicePlans.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2019-08-01/ResourceHealthMetadata.json
module-version: 1.0.1
title: Functions
subject-prefix: ''

metadata:
  authors: Microsoft Corporation
  owners: Microsoft Corporation
  description: 'Microsoft Azure PowerShell - Azure Functions service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor information on Azure Functions, please visit the following: https://learn.microsoft.com/azure/azure-functions/'
  copyright: Microsoft Corporation. All rights reserved.
  tags: Azure ResourceManager ARM PSModule Functions
  companyName: Microsoft Corporation
  requireLicenseAcceptance: true
  licenseUri: https://aka.ms/azps-license
  projectUri: https://github.com/Azure/azure-powershell
  typesToProcess:
    - ./custom/Functions.types.ps1xml
  scriptsToProcess:
    - ./custom/HelperFunctions.ps1
  functionsToExport:
    - Get-AzFunctionApp
    - Get-AzFunctionAppAvailableLocation
    - Get-AzFunctionAppPlan
    - Get-AzFunctionAppSetting
    - New-AzFunctionApp
    - New-AzFunctionAppPlan
    - Remove-AzFunctionApp
    - Remove-AzFunctionAppPlan
    - Remove-AzFunctionAppSetting
    - Restart-AzFunctionApp
    - Start-AzFunctionApp
    - Stop-AzFunctionApp
    - Update-AzFunctionApp
    - Update-AzFunctionAppPlan
    - Update-AzFunctionAppSetting

directive:
  - from: WebApps.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections/{privateEndpointConnectionName}"].delete.responses.200
    transform: delete $.schema
  - from: WebApps.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections/{privateEndpointConnectionName}"].delete.responses.202
    transform: delete $.schema
  - from: WebApps.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections/{privateEndpointConnectionName}"].delete.responses.204
    transform: delete $.schema
  - from: Diagnostics.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses/{analysisName}/execute"].post
    transform: delete $."x-ms-examples"
  - from: swagger-document
    where: $..produces
    #transform: $ = $.filter( each => each === 'application/json');
    transform: $ = ["application/json"];
    reason: this spec adds produces application/xml and text/json erronously.
  - where:
      subject: Operation
    hide: true
  - where: $.definitions.Identifier.properties
    suppress: R3019
# Cmdlet renames
  - where:
      verb: Backup|Get|New|Remove|Restart|Restore|Publish|Set|Start|Stop|Update
      subject: WebApp
      variant: (.*)
    set:
      subject: FunctionApp
    hide: true
  - where:
      subject: WebAppFunction
    set:
      subject: Function
    hide: true
  - where:
      subject: GeoRegion
    set:
      subject: FunctionAppAvailableLocation
    hide: true
  - where:
      subject: AppServicePlan
    set:
      subject: FunctionAppPlan
    hide: true
  # Formats.ps1xml
  - where:
      model-name: Site
    set:
      suppress-format: true
  - where:
      model-name: GeoRegion
    set:
      format-table:
        properties:
          - Name
  - where:
      model-name: AppServicePlan
    set:
      suppress-format: true
  # Parameter renames
  - where:
      subject: Function
      parameter-name: Name
    set:
      parameter-name: FunctionAppName
  - where:
      verb: New
      subject: Connection
      parameter-name: Name
    clear-alias: true
  - where:
      verb: Set
      subject: Connection
      parameter-name: Name
    clear-alias: true
# Cmdlets to hide
  - where:
      subject: (.*)WebAppApplicationSetting(.*)
    hide: true
  - where:
      subject: (.*)AzWebAppSlot(.*)
    hide: true
  - where:
      subject: (.*)NameAvailability(.*)
    hide: true
  - where:
      subject: (.*)WebAppConfiguration(.*)
    hide: true
  - where:
      subject: SystemAssignedIdentity(.*)
    hide: true
  - where:
      subject: WebAppBasicPublishingCredentialsPolicy
    hide: true
  - where:
      subject: WebAppFunctionKey(.*)
    hide: true
  - where:
      subject: WebAppScmAllowed
    hide: true
  - where:
      subject: WebAppSettingKeyVaultReference
    hide: true
  - where:
      subject: WebAppSyncStatus(.*)
    hide: true
  - where:
      verb: Sync
      subject: WebAppFunctionSlot(.*)
    hide: true
  - where:
      verb: Move
    hide: true
  - where:
      verb: Test
    hide: true
# Cmdlets to remove
  - where:
      subject: WebAppFtpAllowed
    remove: true
  - where:
      subject: WebAppPremierAddOn(.*)
    remove: true
  - where:
      subject: WebAppVnetConnection(.*)
    remove: true
  - where:
      subject: WebAppSwiftVirtualNetworkConnection(.*)
    remove: true
  - where:
      subject: WebAppRelayServiceConnection(.*)
    remove: true
  - where:
      subject: WebAppPremierAddOnSlot(.*)
    remove: true
  - where:
      subject: WebAppHybridConnection(.*)
    remove: true
  - where:
      subject: WebAppDomainOwnershipIdentifier(.*)
    remove: true
  - where:
      subject: SiteVnetConnection(.*)
    remove: true
  - where:
      subject: SiteRelayServiceConnection(.*)
    remove: true
  - where:
      subject: (.*)Domain(.*)
    remove: true
  - where:
      subject: (.*)Certificate(.*)
    remove: true
  - where:
      subject: AppServicePlanVnetRoute(.*)
    remove: true
  - where:
      subject: AppServiceEnvironmentWorkerPool(.*)
    remove: true
  - where:
      subject: AppServiceEnvironmentMultiRolePool(.*)
    remove: true
  - where:
      subject: WebAppCustomHostname(.*)
    remove: true
  - where:
      subject: HostingEnvironmentVnet(.*)
    remove: true
  - where:
      subject: GlobalDomainRegistrationDomainPurchase(.*)
    remove: true
  - where:
      subject: WebAppWebSiteNetworkTrace(.*)
    remove: true
  - where:
      subject: WebAppWebSiteNetworkTraceSlot(.*)
    remove: true
  - where:
      subject: WebAppNetworkTrace(.*)
    remove: true
  - where:
      subject: WebAppPublicCertificate(.*)
    remove: true
  - where:
      subject: WebAppDiagnosticLog(.*)
    remove: true
  - where:
      subject: WebAppPerfMonCounter(.*)
    remove: true
  - where:
      subject: WebAppMigrateMySqlStatus(.*)
    remove: true
  - where:
      subject: WebAppMetric(.*)
    remove: true
  - where:
      subject: SiteNetworkFeature(.*)
    remove: true
  - where:
      subject: ResourceHealthMetadata(.*)
    remove: true
  - where:
      subject: (.*)MultiRolePoolInstanceMetric(.*)
    remove: true
  - where:
      subject: (.*)MultiRoleMetricDefinition(.*)
    remove: true
  - where:
      subject: (.*)PremierAddOn(.*)
    remove: true
  - where:
      subject: (.*)WebAppSlot(.*)
    remove: true
  - where:
      subject: (.*)ConnectionConsent(.*)
    remove: true
  - where:
      subject: (.*)WebAppBackup(.*)
    remove: true
  - where:
      subject: (.*)AppServiceEnvironment(.*)
    remove: true
  - where:
      subject: (.*)AppServicePlanHybridConnection(.*)
    remove: true
  - where:
      subject: (.*)AppServicePlanMetric(.*)
    remove: true
  - where:
      subject: (.*)BillingMeter(.*)
    remove: true
  - where:
      subject: (.*)DeletedWebApp(.*)
    remove: true
  - where:
      subject: (.*)DiagnosticSite(.*)
    remove: true
  - where:
      subject: (.*)Global(.*)
    remove: true  
  - where:
      subject: (.*)Recommendation(.*)
    remove: true
  - where:
      subject: (.*)ManagedApi(.*)
    remove: true
  - where:
      subject: (.*)ManagedHosting(.*)
    remove: true
  - where:
      subject: (.*)Provider(.*)
    remove: true
  - where:
      subject: (.*)ServerFarm(.*)
    remove: true
  - where:
      subject: (.*)SiteInstance(.*)
    remove: true
  - where:
      subject: (.*)SiteOperation(.*)
    remove: true
  - where:
      subject: (.*)SourceControl(.*)
    remove: true
  - where:
      subject: (.*)SubscriptionDeployment(.*)
    remove: true
  - where:
      subject: (.*)WebAppAzureStorage(.*)
    remove: true
  - where:
      subject: (.*)WebAppConnection(.*)
    remove: true  
  - where:
      subject: (.*)WebAppContainer(.*)
    remove: true  
  - where:
      subject: (.*)WebAppContinuou(.*)
    remove: true  
  - where:
      subject: (.*)WebAppDeployment(.*)
    remove: true
  - where:
      subject: (.*)WebAppInstance(.*)
    remove: true
  - where:
      subject: (.*)WebAppMetadata(.*)
    remove: true
  - where:
      subject: (.*)WebAppMS(.*)
    remove: true
  - where:
      subject: (.*)WebAppNetwork(.*)
    remove: true  
  - where:
      subject: (.*)WebAppPrivate(.*)
    remove: true
  - where:
      subject: (.*)WebAppPublishing(.*)
    remove: true
  - where:
      subject: (.*)WebAppSite(.*)
    remove: true
  - where:
      subject: (.*)WebAppSnapshot(.*)
    remove: true  
  - where:
      subject: (.*)WebAppSourceControl(.*)
    remove: true
  - where:
      subject: (.*)WebAppSyncFunction(.*)
    remove: true
  - where:
      subject: (.*)WebAppTriggered(.*)
    remove: true
  - where:
      subject: (.*)WebAppUsage(.*)
    remove: true
  - where:
      subject: (.*)AzWebAppWeb(.*)
    remove: true
  - where:
      subject: (.*)Execute(.*)
    remove: true
  - where:
      subject: (.*)WebAppMySql(.*)
    remove: true
  - where:
      subject: (.*)WebAppStorage(.*)
    remove: true
  - where:
      subject: (.*)Connection(.*)
    remove: true
  - where:
      subject: (.*)WebAppDeployment(.*)
    remove: true
  - where:
      subject: (.*)WebAppHost(.*)
    remove: true
  - where:
      subject: (.*)ManagedHosting(.*)
    remove: true
  - where:
      subject: (.*)WebAppFrom(.*)
    remove: true
  - where:
      subject: (.*)WebAppAuthSetting(.*)
    remove: true
  - where:
      subject: (.*)AppServicePlan(.*)
    remove: true
  - where:
      subject: (.*)ClassicMobile(.*)
    remove: true
  - where:
      subject: (.*)Hosting(.*)
    remove: true
  - where:
      subject: (.*)PublishingUser(.*)
    remove: true
  - where:
      subject: (.*)SiteIdentifier(.*)
    remove: true
  - where:
      subject: (.*)WebAppFunctionAdmin(.*)
    remove: true
  - where:
      subject: (.*)WebAppFunctionSecret(.*)
    remove: true
  - where:
      subject: (.*)WebAppProcess(.*)
    remove: true
  - where:
      subject: (.*)WebAppWebJob(.*)
    remove: true
  - where:
      subject: (.*)WebAppWebSite(.*)
    remove: true
  - where:
      subject: (.*)WebAppNewSite(.*)
    remove: true
  - where:
      subject: (.*)WebAppClone(.*)
    remove: true
  - where:
      subject: Move(.*)
    remove: true
  - where:
      subject: (.*)WebAppRepository(.*)
    remove: true
  - where:
      subject: (.*)WebAppFunctionTrigger(.*)
    remove: true
  - where:
      subject: AppServicePlanWebApp
    remove: true
  - where:
      subject: (.*)WebAppSwift(.*)
    remove: true
  - where:
      subject: (.*)WebAppProduction(.*)
    remove: true
  - where:
      subject: (.*)WebAppCloneable(.*)
    remove: true
  - where:
      subject: (.*)ContainerSetting(.*)
    remove: true
  - where:
      subject: (.*)StaticSite(.*)
    remove: true
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}AliasesToExport = \{aliasesList\}\"\);/, '')
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}FunctionsToExport = \{cmdletsList\}\"\);/, '')
```

``` yaml

# Add Storage and AppInsights cmdlet subset
require:
  - $(this-folder)/../helpers/Storage/readme.noprofile.md
  - $(this-folder)/../helpers/AppInsights/readme.noprofile.md
  - $(this-folder)/../helpers/ManagedIdentity/readme.noprofile.md
  
```
