<!-- region Generated -->
# Az.Portal
This directory contains the PowerShell module for the Portal service.

---
## Status
[![Az.Portal](https://img.shields.io/powershellgallery/v/Az.Portal.svg?style=flat-square&label=Az.Portal "Az.Portal")](https://www.powershellgallery.com/packages/Az.Portal/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.7.4 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Portal`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/portal/resource-manager/Microsoft.Portal/preview/2019-01-01-preview/portal.json

module-version: 0.0.1
title: Portal
subject-prefix: $(service-name)

directive:
  - where: 
      verb: Set
      subject: Dashboard
    hide: true
  - where:
      verb: New
      subject: Dashboard
      variant: CreateViaIdentity|CreateViaIdentityExpanded
    remove: true
  - where:
      verb: Update
      subject: Dashboard
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
      

```
