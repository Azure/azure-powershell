<!-- region Generated -->
# Az.MobileNetwork
This directory contains the PowerShell module for the MobileNetwork service.

---
## Status
[![Az.MobileNetwork](https://img.shields.io/powershellgallery/v/Az.MobileNetwork.svg?style=flat-square&label=Az.MobileNetwork "Az.MobileNetwork")](https://www.powershellgallery.com/packages/Az.MobileNetwork/)

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
For information on how to develop for `Az.MobileNetwork`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# branch: 9a312bb730561b8e8e3c0ea7c224de38a9d05238
require:
  - $(this-folder)/readme.azure.noprofile.md
input-file:
  - $(this-folder)/attachedDataNetwork.json
  - $(this-folder)/common.json
  - $(this-folder)/dataNetwork.json
  - $(this-folder)/mobileNetwork.json
  - $(this-folder)/operation.json
  - $(this-folder)/packetCoreControlPlane.json
  - $(this-folder)/packetCoreDataPlane.json
  - $(this-folder)/service.json
  - $(this-folder)/sim.json
  - $(this-folder)/simGroup.json
  - $(this-folder)/simPolicy.json
  - $(this-folder)/site.json
  - $(this-folder)/slice.json
  - $(this-folder)/ts29571.json
#   - $(repo)/specification/digitaltwins/resource-manager/Microsoft.DigitalTwins/stable/2022-05-31/digitaltwins.json

module-version: 0.1.0
title: MobileNetwork
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    hide: true
```
