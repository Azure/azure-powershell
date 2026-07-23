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
commit: ede2366d262175182edacdb02bdf4b58b881fe70
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/search/resource-manager/Microsoft.Search/stable/2025-05-01/search.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Search
```
