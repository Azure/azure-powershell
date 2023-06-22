# Overall
This directory contains management plane service clients of Az.Search module.

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
commit: dc0c6649cee30660c0a915fc2c37f99d118749c6
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/search/resource-manager/Microsoft.Search/stable/2022-09-01/search.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Search
```