# Overall
This directory contains management plane service clients of Az.RecoveryServices SiteRecovery APIs.

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
  - https://github.com/Azure/azure-rest-api-specs/blob/51d4c24a011e300b9713179e0515fef35bf3f678/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/stable/2022-10-01/service.json
  
output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.SiteRecovery
```