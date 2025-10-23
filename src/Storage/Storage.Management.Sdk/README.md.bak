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
commit: 04b87408ba3b8afed159b3d3059bd1594c7f2dd3
input-file:
  - https://github.com/welovej/azure-rest-api-specs/blob/TspMig-storage/specification/storage/resource-manager/Microsoft.Storage/stable/2025-01-01/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Storage

directive:
  - where:
      subject: .*NetworkSecurityPerimeter.*|.*Table.*|.*Queue.*
    remove: true

```