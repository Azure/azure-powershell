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
  - https://github.com/Azure/azure-rest-api-specs/blob/02892fba4474afacce6fc8a76c08d395dc5c8f26/specification/keyvault/resource-manager/Microsoft.KeyVault/preview/2021-06-01-preview/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/02892fba4474afacce6fc8a76c08d395dc5c8f26/specification/keyvault/resource-manager/Microsoft.KeyVault/preview/2021-06-01-preview/keys.json
  - https://github.com/Azure/azure-rest-api-specs/blob/02892fba4474afacce6fc8a76c08d395dc5c8f26/specification/keyvault/resource-manager/Microsoft.KeyVault/preview/2021-06-01-preview/keyvault.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7854f4e958ad5e97a0325fcc4857cc4648c8ca27/specification/keyvault/resource-manager/Microsoft.KeyVault/preview/2021-06-01-preview/managedHsm.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7854f4e958ad5e97a0325fcc4857cc4648c8ca27/specification/keyvault/resource-manager/Microsoft.KeyVault/preview/2021-06-01-preview/providers.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7854f4e958ad5e97a0325fcc4857cc4648c8ca27/specification/keyvault/resource-manager/Microsoft.KeyVault/preview/2021-06-01-preview/secrets.json

output-folder: Generated

namespace: Microsoft.Azure.Management.KeyVault
```