<!-- region Generated -->
# Az.KeyVault
This directory contains the PowerShell module for the KeyVault service.

---
## Status
[![Az.KeyVault](https://img.shields.io/powershellgallery/v/Az.KeyVault.svg?style=flat-square&label=Az.KeyVault "Az.KeyVault")](https://www.powershellgallery.com/packages/Az.KeyVault/)

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
branch: 63a4b37b66740087b113e00c1b32b2b9c98fd9db
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md

input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2021-10-01/keyvault.json
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
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Remove all commands except Test-AzKeyVaultNameAvailability
  - where:
      verb: ^((?!Test).)*$
      subject: ^((?!VaultNameAvailability).)*$
    remove: true
  # Remove the Test-* variant
  - where:
      verb: Test
      subject: VaultNameAvailability
      variant: ^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
    remove: true
```
