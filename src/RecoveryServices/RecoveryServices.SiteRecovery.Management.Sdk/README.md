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
commit: 7a8d3c583d7c9238eea971223c2ccadb18c14412
input-file:
  - D:/Work/azure-rest-api-specs-pr/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/SiteRecovery/preview/2026-09-30-preview/service.json
# Local preview path used for local-only regen. Before pushing the PR, switch back to the
# commit-pinned -pr blob URL once the preview swagger commit is published:
#  - https://github.com/sisunkar/azure-rest-api-specs-pr/blob/$(commit)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/SiteRecovery/preview/2026-09-30-preview/service.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.SiteRecovery
```