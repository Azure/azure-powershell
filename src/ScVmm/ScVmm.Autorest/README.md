<!-- region Generated -->
# Az.ScVmm
This directory contains the PowerShell module for the ScVmm service.

---
## Status
[![Az.ScVmm](https://img.shields.io/powershellgallery/v/Az.ScVmm.svg?style=flat-square&label=Az.ScVmm "Az.ScVmm")](https://www.powershellgallery.com/packages/Az.ScVmm/)

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
For information on how to develop for `Az.ScVmm`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: ee9e300b2bc6e68da09d6c98f321675d33ad6c5d
require:
  - $(this-folder)/../../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/scvmm/resource-manager/Microsoft.ScVmm/stable/2023-10-07/scvmm.json

module-version: 0.1.0
title: ScVmm
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
auto-switch-view: false

use-extension:
  "@autorest/powershell": "4.x"

directive:
  - from: swagger-document 
    where: $.definitions.GuestCredential.properties.password
    transform: >-
      return {
        "description": "Gets or sets the password to connect with the guest.",
        "type": "string",
        "format": "password",
        "x-ms-mutability": [
          "create",
          "update"
        ],
        "x-ms-secret": true
      }

  - where:
      variant: ^(Create|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true
  - where:
      verb: Set
    remove: true

  - model-cmdlet:
    - model-name: AvailabilitySetListItem
    - model-name: NetworkInterfaceUpdate
    - model-name: NetworkInterface
    - model-name: VirtualDiskUpdate
    - model-name: VirtualDisk
    - model-name: Checkpoint
```
