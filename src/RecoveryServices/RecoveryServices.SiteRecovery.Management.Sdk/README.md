# Overall
This directory contains management plane service clients of Az.RecoveryServices SiteRecovery APIs.

## Run Generation
In this directory, run AutoRest:
```
autorest --version=3.10.9 --use:@autorest/powershell@4.0.754
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
commit: c0dbc0940a76df3eb4b2747d66ac41944b427d61
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/SiteRecovery/stable/2026-11-01/service.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.SiteRecovery
```