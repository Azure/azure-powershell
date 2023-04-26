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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

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
# lock the commit
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/aef78a6d0f0bc49b42327621fc670200d7545816/specification/redisenterprise/resource-manager/Microsoft.Cache/preview/2023-03-01-preview/redisenterprise.json

module-version: 1.0.0
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

  # Other cmdlet renames and aliases
  - where:
      subject: OperationsStatus
    set:
      subject: OperationStatus
  - where:
      subject: DatabaseKey
    set:
      subject: Key
  - where:
      verb: New
      subject: Key
    set:
      alias:
        - New-AzRedisEnterpriseCacheDatabaseKey
        - New-AzRedisEnterpriseCacheAccessKey
  - where:
      verb: Get
      subject: Key
    set:
      alias:
        - Get-AzRedisEnterpriseCacheDatabaseKey
        - Get-AzRedisEnterpriseCacheAccessKey
  - where:
      verb: Import|Export
      subject: (^Database)(.*)
    set:
      subject: $2
  - where:
      verb: Import
      subject: ^$
    set:
      alias: Import-AzRedisEnterpriseCacheDatabase
  - where:
      verb: Clear
      subject: Database
    set:
      verb: Invoke
      subject: DatabaseFlush
  - where:
      verb: Export
      subject: ^$
    set:
      alias: Export-AzRedisEnterpriseCacheDatabase

  # Parameter renames and aliases
  - where:
      verb: Get|Update|Remove
      subject: ^$
      parameter-name: ClusterName
    set:
      alias: Name
  - where:
      verb: New
      subject: Database
      parameter-name: GeoReplicationLinkedDatabase
    set:
      parameter-name: LinkedDatabase
  - where:
      verb: New
      subject: Database
    set:
      hide: true
  - where:
      verb: New
      subject: Database
      parameter-name: GeoReplicationGroupNickname
    set:
      parameter-name: GroupNickname
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
      parameter-name: PersistenceAofEnabled
    set:
      parameter-name: AofPersistenceEnabled
  - where:
      parameter-name: PersistenceAofFrequency
    set:
      parameter-name: AofPersistenceFrequency
  - where:
      parameter-name: PersistenceRdbEnabled
    set:
      parameter-name: RdbPersistenceEnabled
  - where:
      parameter-name: PersistenceRdbFrequency
    set:
      parameter-name: RdbPersistenceFrequency

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
      subject: Key
      variant: ^Regenerate$|ViaIdentity
    remove: true
  - where:
      verb: New
      subject: ^$|Database
      variant: ^Create$|ViaIdentity
    remove: true
  - where:
      verb: Update
      subject: ^$|Database
      variant: ^Update$|ViaIdentity$
    remove: true

  # Hide cmdlets
  - where:
      verb: New|Get
      subject: ^$|^Database$|^Key$
    hide: true
  - where:
      verb: Remove|Update
      subject: Database
    hide: true
  - where:
      verb: Import|Export
      subject: ^$
    hide: true
  - where:
      subject: PrivateEndpointConnection|PrivateLinkResource
    hide: true
  - where:
      verb: Get
      subject: Sku
    hide: true

  # DatabaseName parameter to have value 'default'
  - where:
      subject: ForceDatabaseUnlink
      parameter-name: DatabaseName
    hide: true
    set:
      default:
        script: '"default"'

  # DatabaseName parameter to have value 'default'
  - where:
      verb: Invoke
      subject: DatabaseFlush
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'

  # Fix bugs in generated code from namespace conflict
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/Origin\(System.Convert.ToString\(/g, 'Origin(global::System.Convert.ToString(');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/Module.Instance.SetProxyConfiguration\(/g, 'Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Module.Instance.SetProxyConfiguration(');
```
