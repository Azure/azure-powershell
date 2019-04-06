# AutoRest Configuration for KeyVault

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - https://raw.githubusercontent.com/azure/azure-rest-api-specs/multiapi/specification/keyvault/resource-manager/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/azure/azure-rest-api-specs/multiapi/specification/keyvault/resource-manager/readme.md
  - https://raw.githubusercontent.com/azure/azure-rest-api-specs/multiapi/specification/keyvault/data-plane/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/azure/azure-rest-api-specs/multiapi/specification/keyvault/data-plane/readme.md

service-name: KeyVault
title: KeyVaultManagementClient
module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - hybrid-2019
  - latest-2019-04-01
```