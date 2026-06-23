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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 5.4.0 or greater

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

# Using local spec file for private engineering build (API not yet on public ARM)
# When the API is publicly available, replace with remote commit reference:
#   commit: dfb4d26996c17aaf42c52593924f027d7c6019e3
#   require:
#     - $(this-folder)/../../readme.azure.noprofile.md
#     - $(repo)/specification/privatetrafficmanager/resource-manager/Microsoft.Network/PrivateTrafficManager/readme.md
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - ./spec/openapi.json

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
