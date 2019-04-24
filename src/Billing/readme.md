# AutoRest Configuration for Billing

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/billing/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/billing/resource-manager/readme.md
  - $(repo)/specification/commerce/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/commerce/resource-manager/readme.md 
  - $(repo)/specification/consumption/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/consumption/resource-manager/readme.md

module-version: 0.0.1
title: BillingManagementClient
skip-model-cmdlets: true
profile: 
  - hybrid-2019
  - latest-2019-04-01
```