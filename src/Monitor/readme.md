<!-- region Generated -->
# Az.Monitor
This directory contains the PowerShell module for the Monitor service.

---
## Status
[![Az.Monitor](https://img.shields.io/powershellgallery/v/Az.Monitor.svg?style=flat-square&label=Az.Monitor "Az.Monitor")](https://www.powershellgallery.com/packages/Az.Monitor/)

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
For information on how to develop for `Az.Monitor`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/monitor/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/monitor/resource-manager/readme.md
  - $(repo)/specification/monitor/data-plane/readme.enable-multi-api.md
  - $(repo)/specification/monitor/data-plane/readme.md

subject-prefix: ''
module-version: 0.0.1
title: Monitor

directive:
  - where:
      enum-name: ComparisonOperationType|^Operator$
      enum-value-name: Equals
    set:
      enum-value-name: Equal
  # ActivityLogAlert
  - where:
      subject: ActivityLogAlert
      parameter-name: ConditionAllOf
    set:
      parameter-name: Condition
  # Log
  - where:
      verb: Get
      subject: ^ActivityLog$
    set:
      alias: Get-AzLog
  # MetricAlert
  - where:
      verb: Get
      subject: ^MetricAlert$
    set:
      alias: Get-AzMetricAlertRuleV2
  - where:
      verb: New
      subject: ^MetricAlert$
    set:
      alias: Add-AzMetricAlertRuleV2
  - where:
      verb: Remove
      subject: ^MetricAlert$
    set:
      alias: Remove-AzMetricAlertRuleV2
  #- where:
  #    subject: ^MetricAlertsStatu$|^MetricAlertStatus$
  #  set:
  #    subject: MetricAlertStatus
  # AlertRule
  - where:
      verb: New
      subject: ^AlertRule$
    set:
      alias: Add-AzMetricAlertRule
  # LogProfile
  - where:
      verb: Set
      subject: ^LogProfile$
    set:
      alias: Add-AzLogProfile
  # Autoscale
  - where:
      verb: Set
      subject: ^AutoscaleSetting$
    set:
      alias: Add-AzAutoscaleSetting
  # Fix Help Generation Bug
  - where:
      verb: Update
      subject: ^AutoscaleSetting$
      parameter-name: ^Name$
    clear-alias: true
    

```
