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
commit: ae38b76a7e681922a05b0b1e4d44cc725eb94802
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/ebab090bea24de986af8988fb18202e5465015e2/specification/storage/resource-manager/Microsoft.Storage/stable/2025-01-01/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Storage

directive:
  - where:
      subject: .*NetworkSecurityPerimeter.*|.*Table.*|.*Queue.*
    remove: true
```