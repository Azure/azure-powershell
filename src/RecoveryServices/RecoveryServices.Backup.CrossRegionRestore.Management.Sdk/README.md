# Overall
This directory contains management plane service clients of Az.RecoveryServices Backup CrossRegionRestore APIs.

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
commit: 1f9b94d9f01369d1438a80aaf6a658e27209c594
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/stable/2021-11-15/bms.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore
```