<!-- region Generated -->
# Az.Alb
This directory contains the PowerShell module for the Alb service.

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
For information on how to develop for `Az.Alb`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml

module-version: 0.1.0
title: Alb
subject-prefix: $(service-name)
inlining-threshold: 100

# pin the swagger version by using the commit id instead of branch name
commit: 1b338481329645df2d9460738cbaab6109472488
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/servicenetworking/resource-manager/readme.md

try-require: 
  - $(repo)/specification/servicenetworking/resource-manager/readme.powershell.md

directive:
  # Fix swagger issues
  - from: swagger-document
    where: $.definitions.TrafficControllerUpdateProperties
    transform: delete $['properties']
  - from: swagger-document
    where: $.definitions.TrafficControllerUpdateProperties
    transform: $['additionalProperties'] = true;
  - from: swagger-document
    where: $.tags
    transform: '[{"name": "Associations"},{"name": "Frontends"},{"name": "TrafficController"},{"name": "Operations"}]'
  - where:
      subject: (.*)Interface.*
    set:
      subject: $1
  # Remove the unexpanded parameter set
  - where:
      variant: ^(Create|Update)(?!.*?Expanded|JsonFilePath|JsonString)
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
# Param and table formatting
  - where:
      subject: TrafficController
      parameter-name: TrafficControllerName
    set:
      parameter-name: Name
  - where:
      model-name: TrafficController
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - ProvisioningState
# Collapse cmdlets
  - where:
      subject: (.*)TrafficController
    set:
      subject: $1
  - where:
      subject: Associations
    set:
      subject: Association
  - where: 
      subject: Frontends
    set: 
      subject: Frontend
# Renames for parameters continued
  - where:
      subject: Frontend
      parameter-name: FrontendName
    set:
      parameter-name: Name
  - where:
      subject: Frontend
      parameter-name: TrafficControllerName
    set:
      parameter-name: AlbName
  - where:
      subject: Association
      parameter-name: AssociationName
    set:
      parameter-name: Name
  - where:
      subject: Association
      parameter-name: TrafficControllerName
    set:
      parameter-name: AlbName
# remove set-* related cmdlets, since they are not supported for Azure PowerShell modules.
  - where:
      verb: Set
    remove: true
# Format output
  - where:
      model-name: Frontend
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - fqdn
          - ProvisioningState
  - where:
      model-name: Association
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - AssociationType
          - SubnetId
          - ProvisioningState
  - where:
      verb: New
    set:
      preview-announcement:
        preview-message: Application Gateway for Containers is currently in Preview.
  - where:
      verb: Get
    set:
      preview-announcement:
        preview-message: Application Gateway for Containers is currently in Preview.
  - where:
      verb: Update
    set:
      preview-announcement:
        preview-message: Application Gateway for Containers is currently in Preview.
  - where:
      verb: Remove
    set:
      preview-announcement:
        preview-message: Application Gateway for Containers is currently in Preview.
