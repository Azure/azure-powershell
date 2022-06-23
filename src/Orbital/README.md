<!-- region Generated -->
# Az.Orbital
This directory contains the PowerShell module for the Orbital service.

---
## Status
[![Az.Orbital](https://img.shields.io/powershellgallery/v/Az.Orbital.svg?style=flat-square&label=Az.Orbital "Az.Orbital")](https://www.powershellgallery.com/packages/Az.Orbital/)

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
For information on how to develop for `Az.Orbital`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: a5cd8e4c6a799a60d90a2f4a190ea930ea509d9d
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  # - $(repo)/specification/orbital/resource-manager/Microsoft.Orbital/stable/2022-03-01/orbital.json
  - D:\_Code\azure-rest-api-specs\specification\orbital\resource-manager\Microsoft.Orbital\stable\2022-03-01\orbital.json

module-version: 0.1.0
title: Orbital
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      subject: OperationsResult
    remove: true
  - where:
      subject: Contact
    set:
      subject: SpacecraftContact
  - where:
      subject: SpacecraftAvailableContact
    set:
      subject: SpacecraftContactAvailable
  - where:
      subject: ContactProfileTag
    set:
      subject: ContactProfile
  - where:
      subject: SpacecraftTag
    set:
      subject: Spacecraft
  # Re-name and custom it
  # - model-cmdlet:
  #     - ContactProfileLinkChannel
  #     - SpacecraftLink
  #     - ContactProfileLink
  - where:
      model-name: Spacecraft
    set:
      format-table:
        properties:
          - Name
          - Location
          - NoradId
          - TitleLine
          - ResourceGroupName
  - where:
      model-name: ContactProfile
    set:
      format-table:
        properties:
          - Name
          - Location
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: Contact
    set:
      format-table:
        properties:
          - Name
          - GroundStationName
          - Status
          - ReservationStartTime
          - ReservationEndTime
          - ResourceGroupName
```
