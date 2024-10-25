# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```



###
``` yaml
commit: 805e16a53f0a725471e0caa6007b48986c7722d9
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/AvailableClusterRegions-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/Clusters-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/namespaces-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/quotaConfiguration-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/networkrulessets-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/AuthorizationRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/CheckNameAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/consumergroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/disasterRecoveryConfigs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/eventhubs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/SchemaRegistry.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/ApplicationGroups.json

output-folder: Generated

namespace: Microsoft.Azure.Management.EventHub

directive:
  - suppress: R4007
    reason: DefaultErrorResponseSchema - we will be Implementing in new API version
```