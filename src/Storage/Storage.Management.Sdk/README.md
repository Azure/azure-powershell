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
payload-flattening-threshold: 2
```



###
``` yaml
commit: 3e6b4ddca225530c27273d0f816466a905c0151b
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2023-01-01/storage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2023-01-01/blob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2023-01-01/file.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Storage
```