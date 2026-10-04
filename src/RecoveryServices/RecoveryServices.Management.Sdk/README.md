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
# Lock to the merged Swagger PR commit so SDK generation remains reproducible.
commit: 53fc184a55bd2214e3bec2f1d9098501072e7d1e
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservices/resource-manager/Microsoft.RecoveryServices/RecoveryServices/stable/2026-07-01/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices

directive:
  # Use a service-specific name to avoid conflicts with CloudError models from other SDKs.
  - from: swagger-document
    where: $.definitions["CloudError"]
    transform: >
      $["x-ms-client-name"] = "CloudErrorRecoveryService";
```