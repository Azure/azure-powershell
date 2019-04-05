# AutoRest Configuration for Billing

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/billing/resource-manager/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/billing/resource-manager/readme.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/consumption/resource-manager/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/consumption/resource-manager/readme.md

service-name: Billing
module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - hybrid-2019
  - latest-2019-04-01
```