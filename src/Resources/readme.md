# AutoRest Configuration for Resources

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/resources/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/resources/resource-manager/readme.md

subject-prefix: ''
module-version: 0.0.1
skip-model-cmdlets: true
title: ResourceManagementClient
profile: 
  - hybrid-2019
  - latest-2019-04-01
```