# AutoRest Configuration for AppService

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/web/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/web/resource-manager/readme.md

module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - hybrid-2019
  - latest-2019-04-01
```