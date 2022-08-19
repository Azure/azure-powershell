# Overall
This directory contains the service clients of Az.CosmosDB module.

## Run Generation
In this directory, run AutoRest:
```
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

title: CosmosDBManagementClient
```


### 
``` yaml 
input-file:
  - https://github.com/Azure/azure-rest-api-specs/tree/9918d83b021f4abe956ca3be5df358482f50433a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/2022-05-15-preview/cosmos-db.json
  - https://github.com/Azure/azure-rest-api-specs/tree/9918d83b021f4abe956ca3be5df358482f50433a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/2022-05-15-preview/dataTransferService.json
  - https://github.com/Azure/azure-rest-api-specs/tree/9918d83b021f4abe956ca3be5df358482f50433a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/2022-05-15-preview/managedCassandra.json
  - https://github.com/Azure/azure-rest-api-specs/tree/9918d83b021f4abe956ca3be5df358482f50433a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/2022-05-15-preview/mongorbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/9918d83b021f4abe956ca3be5df358482f50433a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/2022-05-15-preview/notebook.json
  - https://github.com/Azure/azure-rest-api-specs/tree/9918d83b021f4abe956ca3be5df358482f50433a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/2022-05-15-preview/rbac.json
  - https://github.com/Azure/azure-rest-api-specs/tree/9918d83b021f4abe956ca3be5df358482f50433a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/2022-05-15-preview/restorable.json
  - https://github.com/Azure/azure-rest-api-specs/tree/9918d83b021f4abe956ca3be5df358482f50433a/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/preview/2022-05-15-preview/services.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CosmosDB
```