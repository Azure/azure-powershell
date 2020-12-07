<!-- region Generated -->
# Az.ResourceGraph
This directory contains the PowerShell module for the ResourceGraph service.

---
## Status
[![Az.ResourceGraph](https://img.shields.io/powershellgallery/v/Az.ResourceGraph.svg?style=flat-square&label=Az.ResourceGraph "Az.ResourceGraph")](https://www.powershellgallery.com/packages/Az.ResourceGraph/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ResourceGraph`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: e521d49bb1d1f262bd2131b57eea5c1436047650
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/resourcegraph/resource-manager/Microsoft.ResourceGraph/preview/2018-09-01-preview/graphquery.json

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
