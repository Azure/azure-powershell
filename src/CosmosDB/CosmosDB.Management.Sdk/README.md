# Overall
This directory contains the service clients of Az.CosmosDB module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.0.758
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
commit: 38af0cfe0b5b32270a01d4e5c1c56e0dd241a873
apiversion: "2026-07-15"
previewapiversion: "2026-04-01-preview"
input-file:
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/DocumentDB/stable/$(apiversion)/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CosmosDB

```