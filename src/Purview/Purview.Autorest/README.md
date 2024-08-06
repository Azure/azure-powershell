<!-- region Generated -->
# Az.Purview
This directory contains the PowerShell module for the Purview service.

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
For information on how to develop for `Az.Purview`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: ebe90b1dfef9ec9706dee06e84676a6c6979ab53
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/purview/resource-manager/Microsoft.Purview/stable/2021-07-01/purview.json 

module-version: 0.1.0
title: Purview
subject-prefix: $(service-name)
identity-correction-for-post: true 
nested-object-to-string: true
resourcegroup-append: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$|^Set$|^AddViaIdentity$|^Add$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
      subject: Account
    remove: true
  # Remove PrivateEndpointConnection or PrivateLinkResource cmdlets
  - where:
      subject: PrivateEndpointConnection|PrivateLinkResource
    hide: true
  # AccountName, ResourceGroupName and ScopeTenantId are required
  - where:
      verb: Set
      subject: DefaultAccount
    hide: true
  # Location, IdentityType, SkuName and SkuCapacity are required for creating an account
  - where:
      verb: New
      subject: Account
    hide: true
  # Name and Type are required
  - where:
      verb: Test
      subject: AccountNameAvailability
    hide: true
  # ObjectId is required
  - where:
      verb: Add
      subject: AccountRootCollectionAdmin
    hide: true
```
