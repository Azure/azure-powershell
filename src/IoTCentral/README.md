<!-- region Generated -->
# Az.IoTCentral
This directory contains the PowerShell module for the IoTCentral service.

---
## Status
[![Az.IoTCentral](https://img.shields.io/powershellgallery/v/Az.IoTCentral.svg?style=flat-square&label=Az.IoTCentral "Az.IoTCentral")](https://www.powershellgallery.com/packages/Az.IoTCentral/)

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
For information on how to develop for `Az.IoTCentral`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: b0cf39b0fd0713e6e0c449633b23a13c99e7fea2
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/iotcentral/resource-manager/Microsoft.IoTCentral/stable/2021-06-01/iotcentral.json

module-version: 0.1.0
title: IoTCentral
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set|Test
    remove: true
  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name
```
