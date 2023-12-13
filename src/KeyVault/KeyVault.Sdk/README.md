# Overall
This directory contains management plane service clients of Az.KeyVault module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.0.631
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
use-extension:
  "@autorest/powershell": "4.0.631"
```

###
``` yaml
commit: b594fd4145904c9bbd018f4a2ddea75c7134aee7
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2022-07-01/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2022-07-01/keyvault.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2023-07-01/managedHsm.json

### there are 2 same "reason" property with same x-ms-enum.name="Reason" defined in both keyvault.json and managedHsm.json. Rename one of them to avoid autorest converting error.
### 
directive:
  - no-inline:
      - Error
  - from: swagger-document
    where: $.definitions.CheckMhsmNameAvailabilityResult.properties.reason["x-ms-enum"]
    transform: $.name = "ReasonForCheckMhsmNameAvailabilityResult"

output-folder: Generated
namespace: Microsoft.Azure.Management.KeyVault
```
