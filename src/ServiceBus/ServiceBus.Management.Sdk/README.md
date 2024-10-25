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
commit: 226c70f75acef9073d7634dd1506605a9b1db6c7
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/namespace-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/DisasterRecoveryConfig.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/migrationconfigs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/networksets.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/AuthorizationRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/Queue.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/topics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/Rules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/subscriptions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/CheckNameAvailability.json


output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceBus
```