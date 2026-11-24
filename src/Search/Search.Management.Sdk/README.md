# Overall
This directory contains management plane service clients of Az.Search module.

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
commit: b339d04156b39ad2275e44d78ce2b035acd8a19d
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/search/resource-manager/Microsoft.Search/Search/stable/2026-11-01/search.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Search
```
