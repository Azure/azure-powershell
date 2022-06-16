<!-- region Generated -->
# Az.FluidRelay
This directory contains the PowerShell module for the FluidRelay service.

---
## Status
[![Az.FluidRelay](https://img.shields.io/powershellgallery/v/Az.FluidRelay.svg?style=flat-square&label=Az.FluidRelay "Az.FluidRelay")](https://www.powershellgallery.com/packages/Az.FluidRelay/)

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
For information on how to develop for `Az.FluidRelay`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 9a6b5748f6ba9eeb2684497551226036c9d1da6b
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/fluidrelay/resource-manager/Microsoft.FluidRelay/stable/2022-05-26/fluidrelay.json

module-version: 0.1.0
title: FluidRelay
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Regenerate$|^RegenerateViaIdentity$
    remove: true
  - where:
      subject: FluidRelayServerKey
      variant: Get
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      subject: FluidRelayOperation
    hide: true
  - where:
      model-name: FluidRelayContainer
    set:
      format-table:
        properties:
          - Name
          - CreationTime
          - LastAccessTime
          - ResourceGroupName
```
