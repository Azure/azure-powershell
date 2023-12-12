<!-- region Generated -->
# Az.NetworkFunction
This directory contains the PowerShell module for the NetworkFunction service.

---
## Status
[![Az.NetworkFunction](https://img.shields.io/powershellgallery/v/Az.NetworkFunction.svg?style=flat-square&label=Az.NetworkFunction "Az.NetworkFunction")](https://www.powershellgallery.com/packages/Az.NetworkFunction/)

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
For information on how to develop for `Az.NetworkFunction`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 5ef93469c04983e472e57ca227fc5159d13a172a
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/networkfunction/resource-manager/Microsoft.NetworkFunction/stable/2022-11-01/AzureTrafficCollector.json
module-version: 0.1.0
title: NetworkFunction
subject-prefix: $(service-name)
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      subject: ^AzureTrafficCollector(.*)
    set:
      subject: TrafficCollector$1
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    hide: true
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^(AzureTrafficCollectors)(.+)(_List)$/, "$1$3$2")
  - where:
      subject: (.)*(Operation)$
    hide: true
  - where:
      verb: Set
    hide: true
```
