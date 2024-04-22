<!-- region Generated -->
# Az.Quantum
This directory contains the PowerShell module for the Quantum service.

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
For information on how to develop for `Az.Quantum`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: b9b3dc975efbc8d25b5c7d84febb710cc889b6bf
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/quantum/resource-manager/Microsoft.Quantum/preview/2022-01-10-preview/quantum.json

title: Quantum
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Check$|^CheckViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: Update
      parameter-name: WorkspaceName
    set:
      parameter-name: Name
      alias: WorkspaceName
  - where:
      subject: ^WorkspaceTag$
    set:
      subject: Workspace
#   # The following are commented out and their generated cmdlets may be renamed and custom logic
#   - model-cmdlet:
#       - Provider
  - where:
      model-name: Provider
    set:
      format-table:
        properties:
          - Sku
```
