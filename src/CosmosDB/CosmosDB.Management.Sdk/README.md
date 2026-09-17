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
commit: 4e7bdd0d0f908762fa1f1da726f31542d0e2f731
previewapiversion: "2026-09-01-preview"
input-file:
  - https://github.com/pjohari-ms/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/preview/$(previewapiversion)/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CosmosDB

```