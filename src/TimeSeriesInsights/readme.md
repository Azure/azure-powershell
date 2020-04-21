<!-- region Generated -->
# Az.TimeSeriesInsights
This directory contains the PowerShell module for the TimeSeriesInsights service.

---
## Status
[![Az.TimeSeriesInsights](https://img.shields.io/powershellgallery/v/Az.TimeSeriesInsights.svg?style=flat-square&label=Az.TimeSeriesInsights "Az.TimeSeriesInsights")](https://www.powershellgallery.com/packages/Az.TimeSeriesInsights/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.7.2 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.TimeSeriesInsights`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/timeseriesinsights/resource-manager/Microsoft.TimeSeriesInsights/preview/2018-08-15-preview/timeseriesinsights.json

module-version: 0.0.1
title: TimeSeriesInsights
subject-prefix: $(service-name)

directive:
  # Fix errors in swagger
  - from: swagger-document
    where: $
    transform: return $.replace(/Microsoft.IotHub/g, "Microsoft.IoTHub")
  - from: swagger-document
    where: $
    transform: return $.replace(/\/eventSources\//g, "/eventsources/")
  - from: swagger-document
    where: $
    transform: return $.replace(/\/accessPolicies\//g, "/accesspolicies/")
  # Remove the unneeded parameter set
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      subject: ReferenceDataSet|AccessPolicy
      variant: ^Create$
    remove: true
  - where:
      subject: EventSource|Environment
      variant: ^Create$|^CreateExpanded$
    hide: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Hide the operation cmdlet
  - where:
      subject: Operation
    hide: true
  # correct some names
  - where:
      parameter-name: SkuCapacity
    set:
      parameter-name: Capacity
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku
  # Suppress the table format
  - where:
        model-name: StandardEnvironmentResource
    set:      
        suppress-format: true
  - where:
        model-name: LongTermEnvironmentResource
    set:      
        suppress-format: true
  - where:
        model-name: EventHubEventSourceResource
    set:      
        suppress-format: true
  - where:
        model-name: IoTHubEventSourceResource
    set:      
        suppress-format: true
  # Correct some generated code
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationProperties Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreationProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreationProperties Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationProperties Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IIoTHubEventSourceCreationProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IIoTHubEventSourceCreationProperties Property');
```
