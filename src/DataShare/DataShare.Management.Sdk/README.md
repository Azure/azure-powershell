# Overall
This directory contains management plane service clients of Az.DataShare module.

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
commit: 9505236faa86b99b6dc58b5655d8e1c4a758d89c
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datashare/resource-manager/Microsoft.DataShare/stable/2019-11-01/DataShare.json

output-folder: Generated

namespace: Microsoft.Azure.Management.DataShare
```