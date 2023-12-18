<!-- region Generated -->
# Az.EdgeMarketplace
This directory contains the PowerShell module for the EdgeMarketplace service.

---
## Status
[![Az.EdgeMarketplace](https://img.shields.io/powershellgallery/v/Az.EdgeMarketplace.svg?style=flat-square&label=Az.EdgeMarketplace "Az.EdgeMarketplace")](https://www.powershellgallery.com/packages/Az.EdgeMarketplace/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.EdgeMarketplace`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 5318242ad45c60bba3e50755ae883d1e397f0419
require:
  - $(this-folder)/../../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/edgemarketplace/resource-manager/Microsoft.EdgeMarketplace/stable/2023-08-01/offers.json
  - $(repo)/specification/edgemarketplace/resource-manager/Microsoft.EdgeMarketplace/stable/2023-08-01/operations.json
  - $(repo)/specification/edgemarketplace/resource-manager/Microsoft.EdgeMarketplace/stable/2023-08-01/publishers.json

module-version: 0.1.0
title: EdgeMarketplace
subject-prefix: $(service-name)

identity-correction-for-post: true

directive:
  - where:
      variant: ^Generate$|^GenerateViaIdentity$
    remove: true
```
