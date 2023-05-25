<!-- region Generated -->
# Az.StorageCache
This directory contains the PowerShell module for the StorageCache service.

---
## Status
[![Az.StorageCache](https://img.shields.io/powershellgallery/v/Az.StorageCache.svg?style=flat-square&label=Az.StorageCache "Az.StorageCache")](https://www.powershellgallery.com/packages/Az.StorageCache/)

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
For information on how to develop for `Az.StorageCache`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 7a65f22cf67826187f75981e914c7e679039257b
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2023-05-01/storagecache.json
  - $(repo)/specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2023-05-01/amlfilesystem.json

module-version: 0.1.0
title: StorageCache
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      subject: ^Cach(.*)
    set:
      subject: $1
  - where:
      subject: ^Info(.*)
    set:
      subject: $1
 
  - where:
      subject: ^SpaceCachAllocation$
    set:
      subject: SpaceAllocation

  - where:
      subject: ^AmlFilesystem$
    set:
      subject: AmlFileSystem

  - where:
      subject: ^ArchiveAmlFilesystem$
    set:
      subject: AmlFileSystemArchive

  - where:
      subject: ^RequiredAmlFSubnetSize$
    set:
      subject: AmlFileSystemSubnetRequiredSize

  - where:
      subject: ^AmlFSubnet$
    set:
      subject: AmlFileSystemSubnet

  - where:
      subject: ^StorageTarget$
    set:
      subject: Target

  - where:
      subject: ^InvalidateStorageTarget$
    set:
      subject: InvalidateTarget

  - where:
      subject: ^StorageTargetDefault$
    set:
      subject: TargetSetting

  - where:
      subject: ^StorageTargetDns$
    set:
      subject: TargetDns

  - from: swagger-document 
    where: $.definitions.PrimingJobIdParameter.properties.primingJobId
    transform: >-
      return {
          "description": "The unique identifier of the priming job.",
          "pattern": "^[-0-9a-zA-Z_]{1,80}$",
          "readOnly": true,
          "type": "string"
      }

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      subject: ^AmlFileSystemSubnetRequiredSize$
      variant: ^Get$|^GetViaIdentity$
    remove: true
  - where:
      subject: ^PrimingJob$
      variant: ^Start$|^StartViaIdentity$|^Resume$|^ResumeViaIdentity$|^Stop$|^StopViaIdentity$|^Pause$|^PauseViaIdentity$
    remove: true
  - where:
      variant: ^Archive$|^ArchiveViaIdentity$|^Check$|^CheckViaIdentity$
    remove: true

  - where:
      verb: Set
    remove: true

  - where:
      verb: Invoke
      subject: ^SpaceAllocation$
    set:
      verb: Update

  - where:
      parameter-name: EName
    set:
      parameter-name: Name
      alias: CacheName

  - where:
      subject: AmlFileSystemSubnet
      parameter-name: FilesystemSubnet
    set:
      parameter-name: Name

  - where:
      parameter-name: OperationId
    set:
      parameter-name: Id

  # # The following are commented out and their generated cmdlets may be renamed and custom logic
  # - model-cmdlet:
  #     - CacheDirectorySettings
  #     - NfsAccessPolicy
  #     - NfsAccessRule
  #     - NamespaceJunction
  #     - PrimingJob
  #     - StorageTargetSpaceAllocation
```
