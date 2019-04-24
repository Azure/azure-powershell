# AutoRest Configuration for Monitor

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/monitor/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/monitor/resource-manager/readme.md
  - $(repo)/specification/monitor/data-plane/readme.enable-multi-api.md
  - $(repo)/specification/monitor/data-plane/readme.md

subject-prefix: ''
module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - hybrid-2019
  - latest-2019-04-01
```