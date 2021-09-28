<!-- region Generated -->
# Az.CustomLocation
This directory contains the PowerShell module for the CustomLocation service.

---
## Status
[![Az.CustomLocation](https://img.shields.io/powershellgallery/v/Az.CustomLocation.svg?style=flat-square&label=Az.CustomLocation "Az.CustomLocation")](https://www.powershellgallery.com/packages/Az.CustomLocation/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.CustomLocation`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: c6c9e02ae4de78cd7357bc4a5a7be38e6f1909d0
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/extendedlocation/resource-manager/Microsoft.ExtendedLocation/stable/2021-08-15/customlocations.json

module-version: 0.1.0
title: CustomLocation
subject-prefix: $(service-name)

identity-correction-for-post: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      verb: Set
    remove: true

  - where:
      verb: New|Update
      subject: ^CustomLocation$
      parameter-name: HostType
    hide: true
    set:
      default:
        script: '"Kubernetes"'

  - where:
      subject: CustomLocationOperation
    hide: true

  - where:
      verb: New|Update
      subject: CustomLocation
    hide: true
```
