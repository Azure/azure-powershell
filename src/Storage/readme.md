<!-- region Generated -->
# Az.Storage
This directory contains the PowerShell module for the Storage service.

---
## Status
[![Az.Storage](https://img.shields.io/powershellgallery/v/Az.Storage.svg?style=flat-square&label=Az.Storage "Az.Storage")](https://www.powershellgallery.com/packages/Az.Storage/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Storage`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/storage/resource-manager/readme.md

subject-prefix: ''
title: Storage
module-version: 0.0.1
skip-model-cmdlets: true

directive:
  - where:
      subject: ^BlobContainer
    set:
      subject: RmStorageContainer
  - where:
      subject: ^BlobService
    set:
      subject: StorageBlobService
  - where:
      subject: ManagementPolicy$
    set:
      subject: StorageAccountManagementPolicy
  - where:
      verb: Test
      subject: StorageAccountNameAvailability
    set:
      alias: Get-AzStorageAccountNameAvailability
  - where:
      verb: Set
      subject: RmStorageContainerLegalHold
    set:
      alias: Add-AzRmStorageContainerLegalHold
  - where:
      verb: Clear
      subject: RmStorageContainerLegalHold
    set:
      alias: Remove-AzRmStorageContainerLegalHold
  - where:
      subject: ^Usage$
    set:
      subject: StorageUsage
  # StorageAccount
  - where:
      subject: StorageAccount
      parameter-name: CustomDomainUseSubDomainName
    set:
      parameter-name: UseSubDomain
  - where:
      verb: Set
      subject: ^StorageAccount$
    set:
      verb: Invoke
      subject: StorageAccountFailover
  - where:
      verb: Update
      subject: ^StorageAccount$
      parameter-name: Keyvaultproperty(.*)
    set:
      parameter-name: $1
  - where:
      verb: Set
      subject: ^StorageContainerImmutabilityPolicy$
      parameter-name: ImmutabilityPeriodSinceCreationInDay
    set:
      parameter-name: ImmutabilityPeriod
# Update csproj for customizations
  - from: Az.Storage.csproj
    where: $
    transform: >
        return $.replace('</Project>', '  <Import Project=\"custom\\dataplane.props\" />\n</Project>' );
```
