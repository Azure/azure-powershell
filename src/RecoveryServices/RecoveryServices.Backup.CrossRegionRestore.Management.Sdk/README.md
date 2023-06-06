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
  - https://github.com/hiaga/azure-rest-api-specs/blob/e741677cd48cd3b612b7108d7db8b52ca0567ce3/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/stable/2021-11-15/bms.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore
```