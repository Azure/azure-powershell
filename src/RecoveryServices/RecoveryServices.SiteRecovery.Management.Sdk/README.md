# Overall
This directory contains management plane service clients of Az.RecoveryServices SiteRecovery APIs.

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
# Pre-public bind for api-version 2026-06-01 (CVM A2A).
# 2026-06-01 is not yet published to Azure/azure-rest-api-specs, so this points at the
# locally compiled swagger from azure-rest-api-specs-pr. Restore the remote input-file
# (commit + stable/2026-06-01/service.json) once the clubbed version is published.
# commit: 00677addbec2520127aada73ce8ec5f9788a405e
# input-file:
#   - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/SiteRecovery/stable/2026-06-01/service.json
input-file:
  - D:/Work/azure-rest-api-specs-pr/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/SiteRecovery/stable/2026-06-01/service.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.SiteRecovery
```