<!-- region Generated -->
# Az.DiskPool
This directory contains the PowerShell module for the DiskPool service.

---
## Status
[![Az.DiskPool](https://img.shields.io/powershellgallery/v/Az.DiskPool.svg?style=flat-square&label=Az.DiskPool "Az.DiskPool")](https://www.powershellgallery.com/packages/Az.DiskPool/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DiskPool`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 418603118e704ffeabacff1dd56957400cf83f3a
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/storagepool/resource-manager/Microsoft.StoragePool/preview/2021-04-01-preview/storagepool.json

module-version: 0.1.0
title: DiskPool
subject-prefix: $(service-name)
identity-correction-for-post: true 
nested-object-to-string: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      verb: Invoke
      subject: DeallocateDiskPool
    set:
      verb: Stop
      subject-prefix: ''
      subject: DiskPool
  - where:
      verb: Stop
      subject: DiskPool
      parameter-name: DiskPoolName
    set:
      parameter-name: Name
  - where:
      verb: New
      subject: DiskPool
    hide: true
  - where:
      verb: Update
      subject: DiskPool
    hide: true
  - where:
      verb: New
      subject: IscsiTarget
    hide: true
  - where:
      verb: Update
      subject: IscsiTarget
    hide: true
  - model-cmdlet:
    - Acl
    - IscsiLun
  - where:
      model-name: DiskPoolZoneInfo
    set:
      format-table:
        properties:
          - SkuName
          - SkuTier
          - AvailabilityZone
          - AdditionalCapability
  - where:
      model-name: OutboundEnvironmentEndpoint
    set:
      format-table:
        properties:
          - Category
          - Endpoint
  - where:
      model-name: DiskPool 
    set:
      format-table:
        properties:
          - Name
          - Location
          - Status
          - ProvisioningState
          - AvailabilityZone       
```
