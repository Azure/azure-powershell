# AutoRest Configuration for Storage

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/storage/resource-manager/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/storage/resource-manager/readme.md

service-name: Storage
title: StorageManagementClient
module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - hybrid-2019
  - latest-2019-04-01
```