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
branch: 70b5215249735bc56df6d9fc20a535f24f655117
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/extendedlocation/resource-manager/Microsoft.ExtendedLocation/preview/2021-03-15-preview/customlocations.json

module-version: 0.1.0
title: CustomLocation
subject-prefix: $(service-name)

identity-correction-for-post: true

directive:
  - where:
      verb: Set
    remove: true
```
