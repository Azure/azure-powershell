# Overall
This directory contains management plane service clients of Az.KeyVault module.

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
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```

###
``` yaml
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/fead0dec636e7554fb8401370418085136d4f052/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2022-07-01/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/fead0dec636e7554fb8401370418085136d4f052/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2022-07-01/keyvault.json
  - https://github.com/Azure/azure-rest-api-specs/blob/fead0dec636e7554fb8401370418085136d4f052/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2022-07-01/managedHsm.json

### there are 2 same "reason" property with same x-ms-enum.name="Reason" defined in both keyvault.json and managedHsm.json. Rename one of them to avoid autorest converting error.
### 
directive:
  - from: swagger-document
    where: $.definitions.CheckMhsmNameAvailabilityResult.properties.reason["x-ms-enum"]
    transform: $.name = "ReasonForCheckMhsmNameAvailabilityResult"

output-folder: Generated
namespace: Microsoft.Azure.Management.KeyVault
```