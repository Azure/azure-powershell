<!-- region Generated -->
# Az.PlanetaryComputer
This directory contains the PowerShell module for the PlanetaryComputer service.

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
For information on how to develop for `Az.PlanetaryComputer`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 5bdf5ca47c2e514554564bb5ba554318ffc99a78
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/orbitalplanetarycomputer/resource-manager/readme.md

try-require:
  - $(repo)/specification/orbitalplanetarycomputer/resource-manager/readme.powershell.md

tag: package-2026-04-15

# For new RP, the version is 0.1.0
module-version: 0.1.0
title: PlanetaryComputer
subject-prefix: $(service-name)

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
```
