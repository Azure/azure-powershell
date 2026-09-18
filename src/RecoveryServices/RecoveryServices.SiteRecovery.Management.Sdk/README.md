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
commit: 15ee622aae980f65fb1c0c544030a1d20fd868bf
input-file:
  - https://github.com/sisunkar/azure-rest-api-specs-pr/blob/$(commit)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/SiteRecovery/stable/2026-10-01/service.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.SiteRecovery
```