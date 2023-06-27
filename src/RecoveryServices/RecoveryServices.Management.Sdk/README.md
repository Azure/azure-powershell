# Overall
This directory contains management plane service clients of Az.RecoveryServices module.

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
commit: fdf43f2fdacf17bd78c0621df44a5c024b61db82
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/stable/2023-02-01/registeredidentities.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/stable/2023-02-01/replicationusages.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/stable/2023-02-01/vaults.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/stable/2023-02-01/vaultusages.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices
```