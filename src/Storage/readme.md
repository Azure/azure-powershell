# AutoRest Configuration for Storage

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - https://raw.githubusercontent.com/azure/azure-rest-api-specs/multiapi/specification/storage/resource-manager/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/azure/azure-rest-api-specs/multiapi/specification/storage/resource-manager/readme.md

service-name: Storage
subject-prefix: ''
title: StorageManagementClient
module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - hybrid-2019
```