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
commit: de2e5e370c722f374f1c827bca96bac9de0a64a6
input-file:
  - https://github.com/sisunkar/azure-rest-api-specs-pr/blob/$(commit)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/SiteRecovery/stable/2026-06-01/service.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.SiteRecovery
```