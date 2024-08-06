<!-- region Generated -->
# Az.KeyVault
This directory contains the PowerShell module for the KeyVault service.

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
For information on how to develop for `Az.KeyVault`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
commit: 8fa9b5051129dd4808c9be1f5b753af226b044db
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md

input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2023-02-01/keyvault.json
  - $(repo)/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2023-02-01/managedHsm.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: KeyVault
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Combine Test-AzKeyVaultNameAvailability and Test-AzKeyVaultManagedHsmNameAvailability
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^ManagedHsms_CheckMhsmNameAvailability$/g, "ManagedHsms_CheckNameAvailability")
  - no-inline:
      - Error
  # Remove all commands except Test-AzKeyVault*NameAvailability, *-AzKeyVaultManagedHsm, *-AzKeyVaultRegion
  - where:
      subject: ^((?!MhsmRegion|ManagedHsm|NameAvailability).)*$
    remove: true
  # Rename *-AzKeyVaultMhsmRegion to *-AzKeyVaultManagedHsmRegion
  - where:
      subject: ^MhsmRegion$
    set:
      subject: ManagedHsmRegion
  - where:
      subject: ^ManagedHsmRegion$
      parameter-name: Name
    set:
      parameter-name: HsmName
  # Remove *-AzKeyVaultManagedHsmDeleted
  - where:
      subject: ^ManagedHsmDeleted$
    remove: true
  # Hide *-AzKeyVaultManagedHsm
  - where:
      subject: ^ManagedHsm$
    hide: true
  # Remove New|Remove-AzKeyVaultManagedHsm
  - where:
      verb: New|Remove
      subject: ^ManagedHsm$
    remove: true
```
