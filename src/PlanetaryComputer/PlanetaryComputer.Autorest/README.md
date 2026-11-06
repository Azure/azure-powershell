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
commit: 9ecfd7c772db95534126fb62a2e983d9145bbd57
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/orbitalplanetarycomputer/resource-manager/readme.md

try-require:
  - $(repo)/specification/orbitalplanetarycomputer/resource-manager/readme.powershell.md

tag: package-2026-10-01

# For new RP, the version is 0.1.0
module-version: 0.1.0
title: PlanetaryComputer
subject-prefix: $(service-name)

# Keep service-specific connection management alongside GeoCatalog private-link discovery.
keep-pec-and-plr: true

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

  # Distinguish connections belonging to a GeoCatalog from other service resources.
  - where:
      subject: PrivateEndpointConnection
    set:
      subject: GeoCatalogPrivateEndpointConnection
```
