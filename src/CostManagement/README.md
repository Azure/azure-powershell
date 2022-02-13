<!-- region Generated -->
# Az.CostManagement
This directory contains the PowerShell module for the Cost service.

---
## Status
[![Az.CostManagement](https://img.shields.io/powershellgallery/v/Az.CostManagement.svg?style=flat-square&label=Az.CostManagement "Az.CostManagement")](https://www.powershellgallery.com/packages/Az.CostManagement/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.CostManagement`, see [how-to.md](how-to.md).
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
Branch: 2cb80cf6668074c84cf02cf45b6bb897eff47e9b
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/cost-management/resource-manager/Microsoft.CostManagement/stable/2020-06-01/costmanagement.json
  - $(repo)/specification/cost-management/resource-manager/Microsoft.CostManagement/stable/2020-06-01/costmanagement.exports.json
title: CostManagement
module-version: 0.1.0

service-name: CostManagement

identity-correction-for-post: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/AlertCategory System/, 'AlertCategory System1');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/internal partial interface/, 'public partial interface');
  - where:
      verb: Set
    set:
      verb: Update
  - where:
      subject: UsageQuery
      verb: invoke
    remove: true
  - where:
      subject: ByDimensionExternalCloudProviderType|CloudForecast|DismissAlert|Forecast
      verb: Invoke
    remove: true
  - where:
      subject: Export|ExportExecutionHistory|ExportExecution
      parameter-name: Scope
    set:
      parameter-name: Scope
      parameter-description: This parameter defines the scope of costmanagement from different perspectives 'Subscription','ResourceGroup' and 'Provide Service'.
  - where:
      subject: Export
      verb: New
    hide: true
  - where:
      subject: Export
      verb: Update
    hide: true
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/\/runHistory\$/g, "$");
  - where:
      subject: Alert|AlertExternal|Dimension|View
    remove: true
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/\^\/\(\?<scope>\[\^\/\]\+\)/g, "(?<scope>.+)");
  - where:
      model-name: QueryResult
    set:
      format-table:
        properties:
          - NextLink
          - Column
          - Row
  - where:
      model-name: ExportExecution
    set:
      format-table:
        properties:
          - ExecutionType
          - ProcessingStartTime
          - ProcessingEndTime
          - RunSetting
          - Status
          - FileName
  - from: swagger-document
    where: $.definitions.AlertProperties.properties.details.properties.resourceGroupFilter.items
    transform: >-
        return {
          "type": "string"
        }
  - from: swagger-document
    where: $.definitions.AlertProperties.properties.details.properties.resourceFilter.items
    transform: >-
        return {
          "type": "string"
        }
  - from: swagger-document
    where: $.definitions.AlertProperties.properties.details.properties.meterFilter.items
    transform: >-
        return {
          "type": "string"
        }
  - from: swagger-document
    where: $.definitions.QueryProperties.properties.rows.items.items
    transform: >-
        return {
          "type": "string"
        }
  - from: swagger-document
    where: $.definitions.QueryFilter.properties
    transform: >-
        return {
          "and": {
            "description": "The logical \"AND\" expression. Must have at least 2 items.",
            "type": "array",
            "items": {
              "$ref": "#/definitions/QueryFilter"
            },
            "minItems": 2
          },
          "or": {
            "description": "The logical \"OR\" expression. Must have at least 2 items.",
            "type": "array",
            "items": {
              "$ref": "#/definitions/QueryFilter"
            },
            "minItems": 2
          },
          "not": {
            "description": "The logical \"NOT\" expression.",
            "$ref": "#/definitions/QueryFilter"
          },
          "dimensions": {
            "description": "Has comparison expression for a dimension",
            "$ref": "#/definitions/QueryComparisonExpression"
          },
          "tag": {
            "description": "Has comparison expression for a tag",
            "$ref": "#/definitions/QueryComparisonExpression"
          }
        }
  - where:
      model-name: QueryFilter
      property-name: Dimension
    set:
      property-name: Dimensions
  - where:
      model-name: QueryResult
    set:
      format-table:
        properties:
          - Column
          - Row
  - no-inline:
    - ReportConfigDefinitionAutoGenerated
    - ReportConfigDatasetAutoGenerated
    - ReportConfigFilterAutoGenerated
    - QueryFilter
    - ReportConfigFilter
```
