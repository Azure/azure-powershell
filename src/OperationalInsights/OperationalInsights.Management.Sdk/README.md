# Overall
This directory contains management plane service clients of Az.OperationalInsights module.

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
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 1
title: OperationalInsightsManagementClient
```



###
``` yaml
commit: 9673e2239f4f8257b2e916df2d15e1ef41c5bfd1
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Workspaces.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Tables.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/DataExports.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/DataSources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/IntelligencePacks.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/LinkedServices.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/LinkedStorageAccounts.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/ManagementGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/OperationStatuses.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/SharedKeys.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/Usages.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/StorageInsightConfigs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/SavedSearches.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/AvailableServiceTiers.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/Gateways.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/Schema.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/SharedKeys.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2020-08-01/WorkspacePurge.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/stable/2021-06-01/Clusters.json

output-folder: Generated

namespace: Microsoft.Azure.Management.OperationalInsights

directive:
  # README suppress
  - from: OperationalInsights.json
    suppress: R3006  # BodyTopLevelProperties/R3006/RPCViolation
    reason: properties etag defined as eTag in model
  # Model property rename
  - where: 
        model-name: DataExport
        property-name: PropertiesDestinationType
    set:
        property-name: DataExportType
  # XML format error fix
  - from: Tables.json
    where: $.definitions.Column.properties.dataTypeHint
    transform: >-
      return {
          "type": "string",
          "description": "Column data type logical hint.",
          "enum": [
            "uri",
            "guid",
            "armPath",
            "ip"
          ],
          "x-ms-enum": {
            "name": "ColumnDataTypeHintEnum",
            "modelAsString": true,
            "values": [
              {
                "value": "uri",
                "description": "A string that matches the pattern of a URI, for example, scheme://username:password@host:1234/this/is/a/path?k1=v1&amp;k2=v2#fragment"
              },
              {
                "value": "guid",
                "description": "A standard 128-bit GUID following the standard shape, xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
              },
              {
                "value": "armPath",
                "description": "An Azure Resource Model (ARM) path: /subscriptions/{...}/resourceGroups/{...}/providers/Microsoft.{...}/{...}/{...}/{...}..."
              },
              {
                "value": "ip",
                "description": "A standard V4/V6 ip address following the standard shape, x.x.x.x/y:y:y:y:y:y:y:y"
              }
            ]
          }
        }
```