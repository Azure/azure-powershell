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
previewapiversion: "2025-11-01-preview"
input-file:
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/cosmos-db.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/dataTransferService.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/managedCassandra.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/mongorbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/notebook.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/privateEndpointConnection.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/rbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/restorable.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/services.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/fleet.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/tablerbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/gremlinrbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/cassandrarbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/mongoMIrbac.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CosmosDB

```