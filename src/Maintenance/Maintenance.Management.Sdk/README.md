# Overall
This directory contains management plane service clients of Az.Maintenance module.

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
commit: fa64058384cb457552f54428f32667d384b794d4
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/maintenance/resource-manager/Microsoft.Maintenance/preview/2023-09-01-preview/Maintenance.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Maintenance
```