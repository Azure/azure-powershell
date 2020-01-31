<!-- region Generated -->
# Azs.InfrastructureInsights.Admin
This directory contains the PowerShell module for the InfrastructureInsightsAdmin service.

---
## Status
[![Azs.InfrastructureInsights.Admin](https://img.shields.io/powershellgallery/v/Azs.InfrastructureInsights.Admin.svg?style=flat-square&label=Azs.InfrastructureInsights.Admin "Azs.InfrastructureInsights.Admin")](https://www.powershellgallery.com/packages/Azs.InfrastructureInsights.Admin/)

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
For information on how to develop for `Azs.InfrastructureInsights.Admin`, see [how-to.md](how-to.md).
<!-- endregion -->

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
  - $(this-folder)/../readme.azurestack.md
  - $(repo)/specification/azsadmin/resource-manager/infrastructureinsights/readme.md

input-file:
  - $(repo)/specification/azsadmin/resource-manager/infrastructureinsights/Microsoft.InfrastructureInsights.Admin/preview/2016-05-01/InfrastructureInsights.json
  - $(repo)/specification/azsadmin/resource-manager/infrastructureinsights/Microsoft.InfrastructureInsights.Admin/preview/2016-05-01/Alert.json
  - $(repo)/specification/azsadmin/resource-manager/infrastructureinsights/Microsoft.InfrastructureInsights.Admin/preview/2016-05-01/RegionHealth.json
  - $(repo)/specification/azsadmin/resource-manager/infrastructureinsights/Microsoft.InfrastructureInsights.Admin/preview/2016-05-01/ResourceHealth.json
  - $(repo)/specification/azsadmin/resource-manager/infrastructureinsights/Microsoft.InfrastructureInsights.Admin/preview/2016-05-01/ServiceHealth.json

subject-prefix: ''
module-version: 0.0.1

### File Renames 
module-name: Azs.InfrastructureInsights.Admin 
csproj: Azs.InfrastructureInsights.Admin.csproj 
psd1: Azs.InfrastructureInsights.Admin.psd1 
psm1: Azs.InfrastructureInsights.Admin.psm1

### Parameter default values
directive:
  - where:
      parameter-name: ResourceGroupName
    set:
      default:
        script: -join("System.",(Get-AzLocation)[0].Name)
  - where:
      model-name: Alert
    set:
      format-table:
        properties:
          - Title
          - State
          - Severity
          - ImpactedResourceDisplayName
          - CreatedTimestamp
          - ClosedTimestamp
        labels:
          ImpactedResourceDisplayName: Impacted Resource
          CreatedTimestamp: Created
          ClosedTimestamp: Closed
        width:
          Title: 24
          State: 10
          Severity: 10
          ImpactedResourceDisplayName: 24
          CreateTimestamp: 20
          ClosedTimestamp: 20
  - where:
      model-name: ServiceHealth
    set:
      format-table:
        properties:
          - DisplayName
          - HealthState
          - AlertSummaryCriticalAlertCount
          - AlertSummaryWarningAlertCount
        labels:
          HealthState: Health State
          AlertSummaryCriticalAlertCount: Alert Critical Summary
          AlertSummaryWarningAlertCount: Alert Warning Summary
        width:
          DisplayName: 24
          HealthState: 20
          AlertSummaryCriticalAlertCount: 17
          AlertSummaryWarningAlertCount: 17
  - where:
      model-name: ResourceHealth
    set:
      format-table:
        properties:
          - ResourceDisplayName
          - HealthState
          - AlertSummaryCriticalAlertCount
          - AlertSummaryWarningAlertCount
        labels:
          ResourceDisplayName: Resource
          HealthState: Health
          AlertSummaryCriticalAlertCount: Alert Critical Summary
          AlertSummaryWarningAlertCount: Alert Warning Summary
        width:
          Resource: 45
          Health: 10
          AlertSummaryCriticalAlertCount: 17
          AlertSummaryWarningAlertCount: 17
  - where:
      model-name: RegionHealth
    set:
      format-table:
        properties:
          - Name
          - AlertSummaryCriticalAlertCount
          - AlertSummaryWarningAlertCount
          - UsageMetric
        labels:
          AlertSummaryCriticalAlertCount: Alert Critical Summary
          AlertSummaryWarningAlertCount: Alert Warning Summary
          UsageMetric: UsageMetrics
        width:
          Name: 16
          AlertSummaryCriticalAlertCount: 15
          AlertSummaryWarningAlertCount: 15
          UsageMetric: 30
  - where:
      model-name: UsageMetrics
    set:
      format-table:
        properties:
          - Name
          - metricsvalue
        labels:
          metricsvalue: Capacity Metrics
        width:
          Name: 30
          UsageMetric: 50
```
