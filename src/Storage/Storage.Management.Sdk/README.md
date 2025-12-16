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
commit: ec3df311a63c6e653824b4018bb1a39d483bf9fc
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/storage/resource-manager/Microsoft.Storage/stable/2025-06-01/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Storage
```