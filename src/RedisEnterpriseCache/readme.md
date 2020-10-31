<!-- region Generated -->
# Az.RedisEnterpriseCache
This directory contains the PowerShell module for the RedisEnterpriseCache service.

---
## Status
[![Az.RedisEnterpriseCache](https://img.shields.io/powershellgallery/v/Az.RedisEnterpriseCache.svg?style=flat-square&label=Az.RedisEnterpriseCache "Az.RedisEnterpriseCache")](https://www.powershellgallery.com/packages/Az.RedisEnterpriseCache/)

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
For information on how to develop for `Az.RedisEnterpriseCache`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/redisenterprise/resource-manager/readme.md

module-version: 0.1.0
title: RedisEnterpriseCache
subject-prefix: 'RedisEnterpriseCache'

# This will remove the 'RedisEnterprise' prefix from the subject of every cmdlet
# beginning with 'RedisEnterprise', because we have already set the subject-prefix above
directive:
  # This will remove the 'RedisEnterprise' prefix from the subject of every cmdlet
  # beginning with 'RedisEnterprise', because we have already set the subject-prefix above
  - where:
      subject: (^RedisEnterprise)(.*) 
    set:
      subject: $2

  # Cmdlet renames
  - where:
      verb: Invoke
      subject: OperationGetStatus
    set:
      verb: Get
      subject: OperationStatus

  # Parameter renames
  - where:
      verb: Get|Update|Remove
      subject: ^$
      parameter-name: ClusterName
    set:
      parameter-name: Name
      alias: ClusterName
  - where:
      parameter-name: Module
    set:
      parameter-name: Modules
      alias: Module
  - where:
      parameter-name: Zone
    set:
      parameter-name: Zones
      alias: Zone
  - where:
      parameter-name: SkuCapacity
    set:
      parameter-name: Capacity
      alias: SkuCapacity
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku
      alias: SkuName
  - where:
      parameter-name: Tag
    set:
      parameter-name: Tags
      alias: Tag


  # Remove unused variants
  - where:
      verb: Get
      variant: ^GetViaIdentity$
    remove: true
  - where:
      verb: Export
      variant: ^Export$|^ExportViaIdentity
    remove: true
  - where:
      verb: Import
      variant: ^Import$|^ImportViaIdentity
    remove: true
  - where:
      verb: Get
      subject: OperationStatus
      variant: ViaIdentity$
    remove: true
  - where:
      verb: New
      subject: DatabaseKey
      variant: ^Regenerate$|ViaIdentity
    remove: true
  - where:
      verb: Update
      subject: ^$|Database
      variant: ^Update$|ViaIdentity$
    remove: true

  # Hide cmdlets
  - where:
      verb: New|Get
      subject: ^$|^Database$
    hide: true
  - where:
      verb: Remove
      subject: Database
    hide: true
  - where:
      verb: Get
      subject: ^$
    hide: true

  # Fix bug in generated code from namespace conflict
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/Origin\(System.Convert.ToString\(/g, 'Origin(global::System.Convert.ToString(');
```
