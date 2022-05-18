<!-- region Generated -->
# Az.ManagedServiceIdentity
This directory contains the PowerShell module for the ManagedServiceIdentity service.

---
## Status
[![Az.ManagedServiceIdentity](https://img.shields.io/powershellgallery/v/Az.ManagedServiceIdentity.svg?style=flat-square&label=Az.ManagedServiceIdentity "Az.ManagedServiceIdentity")](https://www.powershellgallery.com/packages/Az.ManagedServiceIdentity/)

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
For information on how to develop for `Az.ManagedServiceIdentity`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 476564a1aa6ddb38ec681c9f89d42f00c1becd25
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/msi/resource-manager/Microsoft.ManagedIdentity/stable/2018-11-30/ManagedIdentity.json

subject-prefix: ""
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true

directive:
  - where:
      verb: Set
    remove: true

  - where:
      verb: Get
      subject: SystemAssignedIdentity
      variant: ^GetViaIdentity$
    remove: true
    
  - where:
      subject: UserAssignedIdentity
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      subject: UserAssignedIdentity
      parameter-name: ResourceName
    set:
      parameter-name: Name
```
