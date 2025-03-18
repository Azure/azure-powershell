<!-- region Generated -->
# Az.ResourceGraph
This directory contains the PowerShell module for the ResourceGraph service.

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
For information on how to develop for `Az.ResourceGraph`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: cb843b318ece878394d127733abe5da858466daf
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/resourcegraph/resource-manager/Microsoft.ResourceGraph/stable/2024-04-01/graphquery.json

title: ResourceGraph
module-version: 0.1.0
subject-prefix: $(service-name)

directive:
  - from: swagger-document
    where: $
    transform: return $.replace(/\/subscriptions\/\{subscriptionId\}\/resourceGroups\/\{resourceGroupName\}\/providers\/Microsoft\.ResourceGraph\/queries\/\{resourceName\}/g, "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.resourcegraph/queries/{resourceName}")
  ## Remove Etag
  - from: swagger-document
    where: $.definitions.Resource.properties
    transform: delete $.eTag
  ## Remove Etag
  - from: swagger-document
    where: $.definitions.GraphQueryUpdateParameters.properties
    transform: delete $.eTag
  - where:
      verb: Set
      subject: Query$
    remove: true
  - where:
      vert: Get|New|Update|Remove
      parameter-name: ResourceName
    set:
      parameter-name: Name
  - where:
      verb: New
      subject: Query$
    hide: true
  - where:
      verb: Update
      subject: Query$
    hide: true
```
