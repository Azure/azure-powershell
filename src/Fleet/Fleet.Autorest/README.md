<!-- region Generated -->
# Az.Fleet
This directory contains the PowerShell module for the Fleet service.

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
For information on how to develop for `Az.Fleet`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 8f889f0967e411fc1042aed0a097868b360f525a
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/containerservice/resource-manager/Microsoft.ContainerService/fleet/readme.md
  
title: Fleet
module-version: 0.1.0
subject-prefix: $(service-name)

directive:
  # Fix required parameter missing
  - from: swagger-document
    where: $.definitions.FleetMember
    transform: $['required'] = ['properties']
  - from: swagger-document
    where: $.definitions.FleetUpdateStrategy
    transform: $['required'] = ['properties']
  - from: swagger-document
    where: $.definitions.UpdateRun
    transform: $['required'] = ['properties']
  - from: swagger-document
    where: $.definitions.FleetUpdateStrategy.properties.properties.x-ms-mutability
    transform: >-
      return [
        "read",
        "update",
        "create"
      ]
  - from: swagger-document
    where: $.definitions.UpdateRun.properties.properties
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.ManagedClusterUpdate.properties.nodeImageSelection
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.NodeImageSelection.properties.type
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
# #   # Following is two common directive which are normally required in all the RPs
# #   # 1. Remove the unexpanded parameter set
# #   # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  # Hide set cmdlet
  - where:
      verb: Set
    remove: true
  # Rename UpdateStrategyName
  - where:
      parameter-name: UpdateStrategyName
      subject: FleetUpdateStrategy
    set:
      parameter-name: Name
  # Add required model cmdlet
  - model-cmdlet:
    - model-name: UpdateStage
    - model-name: UpdateGroup
