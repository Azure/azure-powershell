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

# Internal
This directory contains a module to handle *internal only* cmdlets. Cmdlets that you **hide** in configuration are created here. For more information on hiding, see [cmdlet hiding](https://github.com/Azure/autorest/blob/master/docs/powershell/options.md#cmdlet-hiding-exportation-suppression). The cmdlets in this directory are generated at **build-time**. Do not put any custom code, files, cmdlets, etc. into this directory. Please use `..\custom` for all custom implementation.

## Info
- Modifiable: no
- Generated: all
- Committed: no
- Packaged: yes

## Details
The `Az.Storage.internal.psm1` file is generated to this folder. This module file handles the hidden cmdlets. These cmdlets will not be exported by `Az.Storage`. Instead, this sub-module is imported by the `..\custom\Az.Storage.custom.psm1` module, allowing you to use hidden cmdlets in your custom, exposed cmdlets. To call these cmdlets in your custom scripts, simply use [module-qualified calls](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_command_precedence?view=powershell-6#qualified-names). For example, `Az.Storage.internal\Get-Example` would call an internal cmdlet named `Get-Example`.

## Purpose
This allows you to include REST specifications for services that you *do not wish to expose from your module*, but simply want to call within custom cmdlets. For example, if you want to make a custom cmdlet that uses `Storage` services, you could include a simplified `Storage` REST specification that has only the operations you need. When you run the generator and build this module, note the generated `Storage` cmdlets. Then, in your readme configuration, use [cmdlet hiding](https://github.com/Azure/autorest/blob/master/docs/powershell/options.md#cmdlet-hiding-exportation-suppression) on the `Storage` cmdlets and they will *only be exposed to the custom cmdlets* you want to write, and not be exported as part of `Az.Storage`.

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2019-04-01/storage.json
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2019-04-01/blob.json

subject-prefix: ''
# title: Storage
# module-version: 4.0.0
# skip-model-cmdlets: true

directive:
  # Remove unnedded cmdlets
  - where:
      subject: ^BlobContainerLegalHold$
    remove: true
  - where:
      subject: ^BlobContainer$
    remove: true
  - where:
      subject: ^BlobContainerImmutabilityPolicy$
    remove: true
  - where:
      subject: ^BlobService$
    remove: true
  - where:
      subject: ^BlobServiceProperty$
    remove: true
  - where:
      subject: ^FileService$
    remove: true
  - where:
      subject: ^FileServiceProperty$
    remove: true
  - where:
      subject: ^FileShare$
    remove: true
  - where:
      subject: ^ManagementPolicy$
    remove: true
  - where:
      subject: ^Operation$
    remove: true
  - where:
      subject: ^Sku$
    remove: true
  - where:
      subject: ^StorageAccountProperty$
    remove: true
  - where:
      subject: ^Usage$
    remove: true
  - where:
      subject: ^ExtendBlobContainerImmutabilityPolicy$
    remove: true
  - where:
      subject: ^LeaseBlobContainer$
    remove: true
  - where:
      subject: ^StorageAccountFailover$
    remove: true
  - where:
      subject: ^ContainerImmutabilityPolicy$
    remove: true
  - where:
      subject: ^StorageAccountUserDelegationKey$
    remove: true
  - where:
      subject: ^StorageAccountNameAvailability$
    remove: true
  - where:
      verb: Set|New|Remove|Update
      subject: ^StorageAccount$
    remove: true
  - where:
      verb: Get
      subject: ^StorageAccountServiceSas$
    remove: true
  - where:
      verb: Get
      subject: ^StorageAccountSas$
    remove: true
  - where:
      verb: New
      subject: ^StorageAccountKey$
    remove: true


  # Hide Storage Account cmdlets
  - where:
      subject: ^StorageAccount.*
    hide: true
  - where:
      subject: ^StorageAccount.*
    set:
      subject-prefix: ''
  
  # StorageAccount
  - where:
      subject: StorageAccount.*
      parameter-name: AccountName
    set:
      parameter-name: Name
  - where:
      subject: StorageAccount
      parameter-name: CustomDomainUseSubDomainName
    set:
      parameter-name: UseSubDomain
  - where:
      subject: StorageAccount
      parameter-name: NetworkAcls(.*)
    set:
      parameter-name: NetworkRuleSet$1
  - where:
      subject: StorageAccount
      parameter-name: BlobEnabled
    set:
      parameter-name: EncryptBlobService
  - where:
      subject: StorageAccount
      parameter-name: FileEnabled
    set:
      parameter-name: EncryptFileService
  - where:
      subject: StorageAccount
      parameter-name: QueueEnabled
    set:
      parameter-name: EncryptQueueService
  - where:
      subject: StorageAccount
      parameter-name: TableEnabled
    set:
      parameter-name: EncryptTableService
  - where:
      subject: ^StorageAccount$
      parameter-name: Keyvaultproperty(.*)
    set:
      parameter-name: $1
  - where:
      subject: ^StorageAccount$
      parameter-name: IsHnsEnabled
    set:
      parameter-name: EnableHierarchicalNamespace
```
