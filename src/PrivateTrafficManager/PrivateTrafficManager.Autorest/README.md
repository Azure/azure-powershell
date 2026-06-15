<!-- region Generated -->
# Az.PrivateTrafficManager
This directory contains the PowerShell module for the PrivateTrafficManager service.

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
For information on how to develop for `Az.PrivateTrafficManager`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml

module-version: 0.1.0
title: PrivateTrafficManager
subject-prefix: $(service-name)

# pin the swagger version by using the commit id instead of branch name
commit: dfb4d26996c17aaf42c52593924f027d7c6019e3
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/privatetrafficmanager/resource-manager/Microsoft.Network/PrivateTrafficManager/readme.md

try-require:
  - $(repo)/specification/privatetrafficmanager/resource-manager/Microsoft.Network/PrivateTrafficManager/readme.powershell.md

directive:
  # Fix polymorphism conflict: ProbeHealthPolicy redefines 'properties' from parent HealthPolicy
  - from: swagger-document
    where: $.definitions.ProbeHealthPolicy.properties
    transform: delete $.properties
  # Remove the unexpanded parameter set
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # Remove Set-* cmdlets
  - where:
      verb: Set
    remove: true
```
