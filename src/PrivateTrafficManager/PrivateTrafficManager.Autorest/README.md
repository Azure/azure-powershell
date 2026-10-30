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

commit: 1e7fff538a7e9d7ca6127b349295c467601362a0
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/privatetrafficmanager/resource-manager/Microsoft.Network/PrivateTrafficManager/preview/2026-10-01-preview/privateTrafficManager.json

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  # Keep named creation and parent identity sets without whole-resource identity creation.
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # Remove Set-* cmdlets
  - where:
      verb: Set
    remove: true
```
