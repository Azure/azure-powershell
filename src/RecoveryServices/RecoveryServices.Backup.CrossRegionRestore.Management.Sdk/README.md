# Overall
This directory contains management plane service clients of Az.RecoveryServices Backup CrossRegionRestore APIs.

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
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/0e20dd2e4e2a40e83840c30cce2efc4847fd9cb9/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/stable/2021-11-15/bms.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore
```