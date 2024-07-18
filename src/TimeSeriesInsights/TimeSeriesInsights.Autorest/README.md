<!-- region Generated -->
# Az.TimeSeriesInsights
This directory contains the PowerShell module for the TimeSeriesInsights service.

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
commit: 4d7a4424bf14aaf73fcca5a3158336305c3d7ac1
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/timeseriesinsights/resource-manager/Microsoft.TimeSeriesInsights/stable/2020-05-15/timeseriesinsights.json

module-version: 0.0.1
title: TimeSeriesInsights
subject-prefix: $(service-name)

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
  - from: swagger-document
    where: $.definitions.Gen1EnvironmentResourceProperties.allOf
    transform: >
      return [
        {
          "$ref": "#/definitions/Gen1EnvironmentCreationProperties"
        },
        {
          "$ref": "#/definitions/EnvironmentResourceProperties"
        }
      ]
  - from: swagger-document
    where: $.definitions.Gen2EnvironmentResourceProperties.allOf
    transform: >
      return [
        {
          "$ref": "#/definitions/EnvironmentResourceProperties"
        }
      ]
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
        model-name: Gen1EnvironmentResource
    set:      
        suppress-format: true
  - where:
        model-name: Gen2EnvironmentResource
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
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen1EnvironmentCreationProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen1EnvironmentCreationProperties Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationProperties Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventHubEventSourceCreationProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventHubEventSourceCreationProperties Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIoTHubEventSourceCreationProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIoTHubEventSourceCreationProperties Property');
```
