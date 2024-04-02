<!-- region Generated -->
# Az.Chaos
This directory contains the PowerShell module for the Chaos service.

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
For information on how to develop for `Az.Chaos`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 907b79c0a6a660826e54dc1f16ea14b831b201d2
require:
  - $(this-folder)/../../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/chaos/resource-manager/Microsoft.Chaos/stable/2024-01-01/capabilities.json
  - $(repo)/specification/chaos/resource-manager/Microsoft.Chaos/stable/2024-01-01/capabilityTypes.json
  - $(repo)/specification/chaos/resource-manager/Microsoft.Chaos/stable/2024-01-01/experiments.json
  - $(repo)/specification/chaos/resource-manager/Microsoft.Chaos/stable/2024-01-01/operationStatuses.json
  - $(repo)/specification/chaos/resource-manager/Microsoft.Chaos/stable/2024-01-01/operations.json
  - $(repo)/specification/chaos/resource-manager/Microsoft.Chaos/stable/2024-01-01/targetTypes.json
  - $(repo)/specification/chaos/resource-manager/Microsoft.Chaos/stable/2024-01-01/targets.json
  - $(repo)/specification/common-types/resource-management/v2/types.json

title: Chaos
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true

directive:
  - from: swagger-document 
    where: $.definitions.TrackedResource.properties.location
    transform: >-
      return {
          "type": "string",
          "x-ms-mutability": [
            "read",
            "create",
            "update"
          ],
          "description": "The geo-location where the resource lives"
      }

  - where:
      variant: ^(Create|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true

  - where:
      verb: Set
    remove: true

  - where:
      verb: Invoke
    set:
      verb: Get

  - model-cmdlet:
    - model-name: Selector
    - model-name: Step
    - model-name: Branch
    - model-name: Action
```
