# AutoRest Configuration for ServiceBus

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/servicebus/resource-manager/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/servicebus/resource-manager/readme.md

service-name: ServiceBus
module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - latest-2019-04-01
```