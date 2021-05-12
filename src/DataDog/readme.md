<!-- region Generated -->
# Az.DataDog
This directory contains the PowerShell module for the DataDog service.

---
## Status
[![Az.DataDog](https://img.shields.io/powershellgallery/v/Az.DataDog.svg?style=flat-square&label=Az.DataDog "Az.DataDog")](https://www.powershellgallery.com/packages/Az.DataDog/)

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
For information on how to develop for `Az.DataDog`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 3d039aede6de1e63023177d0aceaae1820b12cf2
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/datadog/resource-manager/Microsoft.Datadog/stable/2021-03-01/datadog.json
  
title: DataDog
module-version: 0.1.0
subject-prefix: $(service-name)

directive:
  # Remove cmdlet.
  - where:
      verb: Set
    remove: true

  # Remove variant
  - where:
      variant: ^Create$|^CreateViaIdentity$
      subject: MarketplaceAgreement
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: Monitor
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$
      subject: SingleSignOnConfiguration
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$
      subject: TagRule
    remove: true

  # For memory object that generate cmdlet.
  - model-cmdlet:
    - FilteringTag
```
