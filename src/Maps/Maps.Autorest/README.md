<!-- region Generated -->
# Az.Maps
This directory contains the PowerShell module for the Maps service.

---
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
For information on how to develop for `Az.Maps`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 34f09c2b143dc50acc8905a415b8d6c959c9e142
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/maps/resource-manager/Microsoft.Maps/stable/2021-02-01/maps-management.json

module-version: 1.0.0
title: Maps
subject-prefix: $(service-name)

directive:
  # creator was retired from 2024-09-23
  - where:
      verb: New
      subject: Creator
    set:
      breaking-change:
        deprecated-by-version: 0.9.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/05/19

  - where:
      verb: Get
      subject: Creator
    set:
      breaking-change:
        deprecated-by-version: 0.9.0
        deprecated-by-azversion: 14.5.0
        change-effective-date: 2025/09/30

  - where:
      verb: Update
      subject: Creator
    set:
      breaking-change:
        deprecated-by-version: 0.9.0
        deprecated-by-azversion: 14.5.0
        change-effective-date: 2025/09/30

  # remove cmdlet
  - where:
      verb: Set
    remove: true

  - where: 
      verb: Get
      subject: MapOperation
    remove: true
  
  # rename cmdlet
  - where:
      verb: Get
      subject: MapSubscriptionOperation
    set:
      subject: SubscriptionOperation

  # remove variant
  - where:
      subject: Account
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true

  - where:
      subject: Creator
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true

  - where:
      variant: ^CreateViaIdentityExpanded$
    remove: true

  # Only one creator is allowed for a Maps account.
  # - where:
  #     verb: Get
  #     subject: Creator
  #     variant: ^List$
  #   remove: true
  
  - where:
      verb: New
      subject: AccountKey
      variant: ^(Regenerate)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true

  # rename parameter
  - where:
      verb: Get|New
      subject: AccountKey
      parameter-name: AccountName 
    set:
      parameter-name: Name
```
