# Overall
This directory contains management plane service clients of Az.Storage module.

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
payload-flattening-threshold: 2
```



###
``` yaml
commit: 09c187c9589a143a477ed02c6639e914a4818179
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2023-05-01/storage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2023-05-01/blob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2023-05-01/file.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Storage
```