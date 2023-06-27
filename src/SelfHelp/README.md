<!-- region Generated -->
# Az.SelfHelp
This directory contains the PowerShell module for the SelfHelp service.

---
## Status
[![Az.SelfHelp](https://img.shields.io/powershellgallery/v/Az.SelfHelp.svg?style=flat-square&label=Az.SelfHelp "Az.SelfHelp")](https://www.powershellgallery.com/packages/Az.SelfHelp/)

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
For information on how to develop for `Az.SelfHelp`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
branch: c2c2f7a359c217380a5ae047e153bac36c404a0c
require:
  # readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/help/resource-manager/readme.md
  # If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
  # - $(this-folder)/azure-rest-api-specs/specification/help/resource-manager/readme.md

try-require:
  - $(repo)/specification/help/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: SelfHelp
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

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
```
