<!-- region Generated -->
# Az.Mdp
This directory contains the PowerShell module for the Mdp service.

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
For information on how to develop for `Az.Mdp`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 8b9c9e84b2ed9da6d74ce0856bb0d8973912cb2f
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/devopsinfrastructure/resource-manager/readme.md

try-require: 
  - $(repo)/specification/devopsinfrastructure/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
title: Managed DevOps Pools
service-name: Mdp
subject-prefix: $(service-name)

directive:
# Dont expose images and usages endpoints
  - remove-operation: ImageVersions_ListByImage
  - remove-operation: SubscriptionUsages_Usages
# Hide set cmdlets
  - where:
      verb: Set
    hide: true
# Rename to pool agents
  - where:
      verb: Get
      subject: ResourceDetail
    set:
      subject: PoolAgent
# Rename LocationName parameter
  - where:
      verb: Get
      subject: Sku
      parameter-name: LocationName
    set:
      parameter-name: Location
# Dont flatten hash objects
  - no-inline:
    - AgentProfile
    - OrganizationProfile
    - FabricProfile
```
