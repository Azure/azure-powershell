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
commit: da0cfefaa0e6c237e1e3819f1cb2e11d7606878d
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2022-09-01/storage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2022-09-01/blob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/stable/2022-09-01/file.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Storage
```