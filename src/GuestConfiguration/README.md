<!-- region Generated -->
# Az.GuestConfiguration
This directory contains the PowerShell module for the GuestConfiguration service.

---
## Status
[![Az.GuestConfiguration](https://img.shields.io/powershellgallery/v/Az.GuestConfiguration.svg?style=flat-square&label=Az.GuestConfiguration "Az.GuestConfiguration")](https://www.powershellgallery.com/packages/Az.GuestConfiguration/)

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
For information on how to develop for `Az.GuestConfiguration`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
branch: d5c524d7228920ac75e27efe2e4616d5e43f71b1
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/guestconfiguration/resource-manager/Microsoft.GuestConfiguration/stable/2022-01-25/guestconfiguration.json
module-version: 0.10.8
title: GuestConfiguration
subject-prefix: $(service-name)
identity-correction-for-post: true 
nested-object-to-string: true
resourcegroup-append: true
directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # The properties of VmssVMList are read-only
  - where:
      parameter-name: VmssVMList
    hide: true
  # The properties of AssignmentReportResource are read-only
  - where:
      parameter-name: LatestAssignmentReportResource
    hide: true
```
