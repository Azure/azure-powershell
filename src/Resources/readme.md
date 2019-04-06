# AutoRest Configuration for Resources

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - https://raw.githubusercontent.com/azure/azure-rest-api-specs/multiapi/specification/resources/resource-manager/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/azure/azure-rest-api-specs/multiapi/specification/resources/resource-manager/readme.md

service-name: Resources
subject-prefix: ''
module-version: 0.0.1
skip-model-cmdlets: true
title: ResourceManagementClient
profile: 
  - hybrid-2019
  - latest-2019-04-01
```