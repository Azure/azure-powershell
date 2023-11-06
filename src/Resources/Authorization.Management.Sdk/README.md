# Overall
This directory contains management plane service clients of Az.Resources module.

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
commit: 526e6049f46d58a5077850731dce19ab9767988f
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2022-05-01-preview/authorization-RoleDefinitionsCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2022-05-01-preview/common-types.json

output-folder: Generated

namespace: Microsoft.Authorization
```