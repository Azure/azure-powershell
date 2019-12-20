<!-- region Generated -->
# Az.AppService
This directory contains the PowerShell module for the AppService service.

---
## Status
[![Az.AppService](https://img.shields.io/powershellgallery/v/Az.AppService.svg?style=flat-square&label=Az.AppService "Az.AppService")](https://www.powershellgallery.com/packages/Az.AppService/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.AppService`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/web/resource-manager/readme.md

title: AppService
module-version: 4.0.2

directive:
  - from: swagger-document
    where: $..produces
    transform: $ = $.filter( each => each === 'application/json');
    reason: this spec adds produces application/xml and text/json erronously.
  - where:
      parameter-name: OutFile
    set:
      alias: OutputFile
  - where:
      subject: .*AppService.*
    set:
      subject-prefix: ''
  - where:
      subject: .*WebApp.*
    set:
      subject-prefix: ''
  - where:
      verb: Backup|New|Remove|Restart|Restore|Set|Start|Stop
      subject: WebAppSlot
      variant: (.*)
    set:
      variant: $1Slot
  - where:
      verb: Backup|New|Remove|Restart|Restore|Set|Start|Stop
      subject: WebAppSlot
    set:
      subject: WebApp
      alias: ${verb}-AzWebAppSlot
  - where:
      subject: WebAppBackup.*Slot
      variant: (.*)
    set:
      variant: $1Slot
  - where:
      subject: WebAppBackup(.*)Slot
    set:
      subject: WebAppBackup$1
      alias: ${verb}-Az${subject}Slot
  - where:
      subject: WebAppSnapshot.*Slot
      variant: (.*)
    set:
      variant: $1Slot
  - where:
      subject: WebAppSnapshot(.*)Slot
    set:
      subject: WebAppSnapshot$1
      alias: ${verb}-Az${subject}Slot
  - where:
      verb: Get
      subject: WebAppMetricSlot
      variant: (.*)
    set:
      variant: $1Slot
  - where:
      verb: Get
      subject: WebAppMetricSlot
    set:
      subject: WebAppMetric
  - where:
      verb: Get
      subject: WebAppPublishingCredentialsSlot
      variant: (.*)
    set:
      variant: $1Slot
  - where:
      verb: Get
      subject: WebAppPublishingCredentialsSlot
    set:
      subject: WebAppPublishingCredentials
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
      alias: ['Get-AzWebAppMetrics', 'Get-AzWebAppSlotMetric', 'Get-AzWebAppSlotMetrics']
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
      verb: Backup
      subject: WebApp
    set:
      alias: ['Backup-AzWebAppSlot', 'New-AzWebAppBackup', 'New-AzWebAppSlotBackup']
  - where:
      subject: WebAppNewSitePublishingPassword
    set:
      subject: WebAppPublishingPassword
      alias: ['Reset-AzWebAppPublishingProfile', 'Reset-AzWebAppSlotPublishingProfile']
  - where:
      subject: WebAppNewSitePublishingPasswordSlot
      variant: (.*)
    set:
      variant: $1Slot
  - where:
      subject: WebAppNewSitePublishingPasswordSlot
    set:
      subject: WebAppPublishingPassword
  - where:
      verb: Restore
      subject: WebAppFromDeletedApp
    set:
      subject: DeletedWebApp
  - where:
      verb: Restore
      subject: WebAppFromDeletedAppSlot
      variant: (.*)
    set:
      variant: $1Slot
  - where:
      verb: Restore
      subject: WebAppFromDeletedAppSlot
    set:
      subject: DeletedWebApp
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
      alias: ['Get-AzWebAppContainerContinuousDeploymentUrl', 'Get-AzWebAppPublishingCredentialsSlot']
  - where:
      verb: Restore
      subject: DeletedWebApp
      parameter-name: RecoverConfiguration
    set:
      alias: RestoreContentOnly
  - where:
      verb: Restore
      subject: DeletedWebApp
      parameter-name: (Name|ResourceGroupName|Slot)
    set:
      alias: Target$1
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
  - where:
      verb: Restore
      subject: WebApp
      parameter-name: (Database|IgnoreConflictingHostName)
    set:
      alias: $1s
  - where:
      variant: (.*)SlotSlot
    set:
      variant: $1Slot
  - where:
      variant: (.*)ViaIdentitySlot
    remove: true
# Fix the name of the module in the nuspec
  - from: Az.AppService.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - App Service (Web Apps) service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor information on App Service, please visit the following$1 https://docs.microsoft.com/azure/app-service-web/');
# Add a better description
  - from: Az.AppService.nuspec
    where: $
    transform: $ = $.replace(/\$\(service-name\)/g,  'AppService');
# Add release notes
  - from: Az.AppService.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview AppService cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
 # Make the nuget package a preview
  - from: Az.AppService.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) AppService cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - App Service (Web Apps) service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor information on App Service, please visit the following$1 https://docs.microsoft.com/azure/app-service-web/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview AppService cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
```
