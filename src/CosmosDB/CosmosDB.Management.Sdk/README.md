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
commit: b99dfe6606f232f454660bf361bc32c0dfade9fb
apiversion: "2025-10-15"
previewapiversion: "2024-12-01-preview"
input-file:
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/cosmos-db.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/managedCassandra.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/mongorbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/notebook.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/privateEndpointConnection.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/rbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/restorable.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/services.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/fleet.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/tablerbac.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CosmosDB

```