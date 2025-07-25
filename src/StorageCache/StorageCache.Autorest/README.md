<!-- region Generated -->
# Az.StorageCache
This directory contains the PowerShell module for the StorageCache service.

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
For information on how to develop for `Az.StorageCache`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: f3a04ddc23771fca8a99b179ea8eaa428c21fa2f
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2023-05-01/amlfilesystem.json

module-version: 0.1.0
title: StorageCache
subject-prefix: $(service-name)

directive:
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
      variant: ^(Create|Update|Archive|Check)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      subject: ^AmlFileSystemSubnetRequiredSize$
      variant: ^Get(?!.*?Expanded)
    remove: true

  - where:
      verb: Set
    remove: true

  - where:
      subject: AmlFileSystemSubnet
      parameter-name: FilesystemSubnet
    set:
      parameter-name: Name

  - where:
      parameter-name: OperationId
    set:
      parameter-name: Id

  - where:
      subject: AscOperation
    hide: true

  - where:
      model-name: AmlFilesystem
    set:
      format-table:
        properties:
          - Name
          - Location
          - ResourceGroupName
          - HealthState
          - SkuName
```
