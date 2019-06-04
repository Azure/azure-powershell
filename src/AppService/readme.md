<!-- region Generated -->
# Az.WebSite
This directory contains the PowerShell module for the WebSite service.

---
## Status
[![Az.WebSite](https://img.shields.io/powershellgallery/v/Az.WebSite.svg?style=flat-square&label=Az.WebSite "Az.WebSite")](https://www.powershellgallery.com/packages/Az.WebSite/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.4.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.WebSite`, see [how-to.md](how-to.md).
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

``` yaml
require:
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/web/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/web/resource-manager/readme.md

module-version: 0.0.1

directive:
  - from: swagger-document
    where: $..produces
    transform: $ = $.filter( each => each === 'application/json');
    reason: this spec adds produces application/xml and text/json erronously.
  - where:
      subject: .*AppService.*
    set:
      subject-prefix: ''
  - where:
      subject: .*WebApp.*
    set:
      subject-prefix: ''
  - where:
      verb: Get
      subject: AppServicePlanMetric
    set:
      alias: Get-AzAppServicePlanMetrics
  - where:
      subject: ^Certificate.*
    set:
      subject-prefix: WebApp
  - where:
      verb: Get
      subject: WebAppMetric
    set:
      alias: Get-AzWebAppMetrics
  - where:
      verb: Get
      subject: WebAppPublishingProfileXml
    set:
      subject: WebAppPublishingProfile
      alias: [Get-AzWebAppPublishingProfile, Get-AzWebAppSlotPublishingProfile]
  - where:
      subject: WebAppSlotConfigurationName
    set:
      alias: ${verb}-AzWebAppSlotConfigName
  - where:
      verb: Get
      subject: WebAppMetricSlot
    set:
      subject: WebAppSlotMetric
      alias: Get-AzWebAppSlotMetrics
  - where:
      verb: Backup
      subject: WebApp
    set:
      alias: New-AzWebAppBackup
  - where:
      verb: Backup
      subject: WebAppSlot
    set:
      alias: New-AzWebAppSlotBackup
  - where:
      subject: WebAppNewSitePublishingPassword
    set:
      subject: WebAppPublishingPassword
      alias: Reset-AzWebAppPublishingProfile
  - where:
      subject: WebAppNewSitePublishingPasswordSlot
    set:
      subject: WebAppSlotPublishingPassword
      alias: Reset-AzWebAppSlotPublishingProfile
  - where:
      verb: Restore
      subject: WebAppFromDeletedApp
    set:
      subject: DeletedWebApp
  - where:
      verb: Restore
      subject: WebAppFromDeletedAppSlot
    set:
      subject: DeletedWebAppSlot
  - where:
      subject: WebApp
      parameter-name: InputObject
    set:
      alias: WebApp
  - where:
      subject: AppServicePlan
      parameter-name: InputObject
    set:
      alias: AppServicePlan
  - where:
      subject: WebAppBackupConfiguration
      parameter-name: InputObject
    set:
      alias: WebApp
  - where:
      subject: WebAppPublishingProfile
      parameter-name: OutFile
    set:
      parameter-name: OutputFile
  - where:
      subject: WebAppPublishingProfile
      parameter-name: IncludeDisasterRecoveryEndpoint
    set:
      parameter-name: IncludeDisasterRecoveryEndpoints
  - where:
      subject: WebAppSlot
      parameter-name: InputObject
    set:
      alias: WebApp
  - where:
      subject: WebAppPublishingPassword
      parameter-name: InputObject
    set:
      alias: WebApp
  - where:
      subject: WebAppSlotPublishingPassword
      parameter-name: InputObject
    set:
      alias: WebApp
  - where:
      subject: WebAppBackup
      parameter-name: InputObject
    set:
      alias: WebApp
  - where:
      subject: WebAppSnapshot
      parameter-name: InputObject
    set:
      alias: WebApp
  - where:
      subject: WebAppSlotConfigurationName
      parameter-name: InputObject
    set:
      alias: WebApp
  - where:
      verb: Switch
      subject: WebAppSlot
      parameter-name: Slot
    set:
      alias: SourceSlotName
  - where:
      verb: Switch
      subject: WebAppSlot
      parameter-name: TargetSlot
    set:
      alias: DestinationSlotName
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
  - where:
      verb: Get
      subject: AppServicePlanMetric
      parameter-name: Detail
    set:
      alias: InstanceDetails
  - where:
      subject: AppServicePlan
      parameter-name: SkuTier
    set:
      alias: Tier
  - where:
      subject: AppServicePlan
      parameter-name: Capacity
    set:
      alias: NumberOfWorkers
  - where:
      verb: Get
      subject: WebAppMetric
      parameter-name: Detail
    set:
      alias: InstanceDetails
  - where:
      verb: Get
      subject: WebAppPublishingCredentials
    set:
      alias: Get-AzWebAppContainerContinuousDeploymentUrl
  - where:
      verb: Restore
      subject: DeletedWebApp
      parameter-name: RecoverConfiguration
    set:
      alias: RestoreContentOnly
  - where:
      verb: Set
      subject: WebAppBackupConfiguration
    set:
      alias: Edit-AzWebAppBackupConfiguration
  - where:
      verb: Restore
      subject: WebApp
    set:
      alias: Restore-AzWebAppBackup
```
