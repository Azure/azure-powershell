# Overall
This directory contains the service clients of Az.CosmosDB module.

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

title: CosmosDBManagementClient
```


### 
``` yaml 
commit: main
apiversion: "2024-02-15-preview"
input-file:
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/cosmos-db.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/dataTransferService.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/managedCassandra.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/mongorbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/notebook.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/privateEndpointConnection.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/rbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/restorable.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/$(apiversion)/services.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CosmosDB

directive:
  - from: managedCassandra.json
    where: $.parameters.forceDeallocate
    transform: >
        $['type'] = 'string';
    reason: Temporarily needed for autorest gen to work in 2023-09-15-preview api version. Swagger changes to fix type introduced in 2024-02-15-preview api version.
  - from: managedCassandra.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/invokeCommandAsync']
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
    reason: Temporarily removing path due to build errors. This endpoint will be updated in next API version.
```