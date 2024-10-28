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
```



###
``` yaml
commit: d4365e634050481a5d6966cd6dd2e4a361d519dd
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/devtestlabs/resource-manager/Microsoft.DevTestLab/stable/2018-09-15/DTL.json

output-folder: Generated

namespace: Microsoft.Azure.Management.DevTestLabs
```