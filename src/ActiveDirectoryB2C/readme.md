<!-- region Generated -->
# Az.ActiveDirectoryB2C
This directory contains the PowerShell module for the ActiveDirectoryB2C service.

---
## Status
[![Az.ActiveDirectoryB2C](https://img.shields.io/powershellgallery/v/Az.ActiveDirectoryB2C.svg?style=flat-square&label=Az.ActiveDirectoryB2C "Az.ActiveDirectoryB2C")](https://www.powershellgallery.com/packages/Az.ActiveDirectoryB2C/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ActiveDirectoryB2C`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - C:\AzurePowershell\azure-rest-api-specs-pr-AADB2C\specification\cpim\resource-manager\Microsoft.AzureActiveDirectory\preview\2020-05-01-preview\cpim.json

module-version: 0.1.0
title: ActiveDirectoryB2C
subject-prefix: ADB2C

inlining-threshold: 50

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      subject-prefix: Adb2C
    set:
      subject-prefix: ADB2C
  - where:
      verb: New
      subject: GuestUsage
    hide: true
  # Format output
  - where:
      model-name: GuestUsagesResource
    set:
      format-table:
        properties:
          - Name
          - Location
          - TenantId
```
