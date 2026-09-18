# Overall
This directory contains management plane service clients of Az.LogicApp module.

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
title: LogicManagementClient
openapi-type: arm
clear-output-folder: true
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```

###
``` yaml
commit: 5c9d5f957d76d9fea9c513f494660c6c5d3e809a
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/logic/resource-manager/Microsoft.Logic/preview/2018-07-01-preview/logic.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Logic

directive:
  - where:
      - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/listExpressionTraces"].post.responses["200"].schema
    suppress:
      - CollectionObjectPropertiesNaming
  - where:
      - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/repetitions/{repetitionName}/listExpressionTraces"].post.responses["200"].schema
    suppress:
      - CollectionObjectPropertiesNaming
  - suppress: R3016
    reason: Existing properties, can't be changed without breaking API.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/triggers/{triggerName}/run"].post.responses.default.schema["$ref"]
    transform: return "#/definitions/ErrorResponse"
  - where:
     model-name: PartnerContent
     property-name: B2B
    set:
     property-name: B2b
```