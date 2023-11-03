<!-- region Generated -->
# Az.BareMetal
This directory contains the PowerShell module for the BareMetal service.

---
## Status
[![Az.BareMetal](https://img.shields.io/powershellgallery/v/Az.BareMetal.svg?style=flat-square&label=Az.BareMetal "Az.BareMetal")](https://www.powershellgallery.com/packages/Az.BareMetal/)

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
For information on how to develop for `Az.BareMetal`, see [how-to.md](how-to.md).
<!-- endregion -->

<!-- region Generated -->
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 1e42e81660d1bc0be000477a4659b29a7ce7d67b
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/baremetalinfrastructure/resource-manager/Microsoft.BareMetalInfrastructure/stable/2021-08-09/baremetalinfrastructure.json

module-version: 0.1.0
title: BareMetal
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      subject: ^AzureBareMetalInstance(.*)
    set:
      subject: $1
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^GetViaIdentity$
      subject-prefix: BareMetal
    remove: true

```
