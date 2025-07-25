# Overall
This directory contains management plane service clients of Az.RecoveryServices module.

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
commit: 72f52bc8847a889488da885f40d6871a89e0470b
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/stable/2024-04-01/registeredidentities.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/stable/2024-04-01/replicationusages.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/stable/2024-04-01/vaults.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/stable/2024-04-01/vaultusages.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices
```