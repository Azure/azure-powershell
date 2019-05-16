<!-- region Generated -->
# Az.KeyVault
This directory contains the PowerShell module for the KeyVault service.

---
## Status
[![Az.KeyVault](https://img.shields.io/powershellgallery/v/Az.KeyVault.svg?style=flat-square&label=Az.KeyVault "Az.KeyVault")](https://www.powershellgallery.com/packages/Az.KeyVault/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.4.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.KeyVault`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/keyvault/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/keyvault/resource-manager/readme.md
  - $(repo)/specification/keyvault/data-plane/readme.enable-multi-api.md
  - $(repo)/specification/keyvault/data-plane/readme.md

title: KeyVault
module-version: 0.0.1
skip-model-cmdlets: true

directive:
  - where:
      verb: Get
      subject: Deleted(.*)
    hide: true
  - where:
      verb: Clear
      subject: Deleted(.*)
    hide: true
  - where:
      verb: New
      subject: Certificate
    set:
      alias: Add-AzKeyVaultCertificate
  - where:
      verb: New
      subject: Key
    set:
      alias: Add-AzKeyVaultKey
  - where:
      verb: Set
      subject: CertificateContact
    set:
      alias: Add-AzKeyVaultCertificateContact
  - where:
      verb: Set
      subject: StorageAccount
    set:
      alias: Add-AzKeyVaultManagedStorageAccount
  - where:
      verb: Backup
      subject: StorageAccount
    set:
      alias: Backup-AzKeyVaultManagedStorageAccount
  - where:
      verb: Get
      subject: StorageAccount
    set:
      alias: Get-AzKeyVaultManagedStorageAccount
  - where:
      verb: Get
      subject: StorageSasDefinition
    set:
      alias: Get-AzKeyVaultManagedStorageSasDefinition
  - where:
      verb: Remove
      subject: StorageAccount
    set:
      alias: Remove-AzKeyVaultManagedStorageAccount
  - where:
      verb: Remove
      subject: StorageSasDefinition
    set:
      alias: Remove-AzKeyVaultManagedStorageSasDefinition
  - where:
      verb: Restore
      subject: StorageAccount
    set:
      alias: Restore-AzKeyVaultManagedStorageAccount
  - where:
      verb: Set
      subject: StorageSasDefinition
    set:
      alias: Set-AzKeyVaultManagedStorageSasDefinition
  - where:
      verb: Update
      subject: StorageAccount
    set:
      alias: Update-AzKeyVaultManagedStorageAccount
  - where:
      verb: Update
      subject: StorageSasDefinition
    set:
      alias: Update-AzKeyVaultManagedStorageSasDefinition
  - where:
      verb: New
      subject: StorageAccountKey
    set:
      alias: Update-AzKeyVaultManagedStorageAccountKey
  - where:
      verb: Restore
      subject: StorageAccount
    set:
      alias: Undo-AzKeyVaultManagedStorageAccountRemoval
  - where:
      verb: Update
      subject: CertificatePolicy
    set:
      alias: Set-AzKeyVaultCertificatePolicy
  - where:
      verb: Import
      subject: Key
    set:
      alias: Add-AzKeyVaultKey
  - where:
      verb: Update
      subject: CertificateOperation
    set:
      alias: Stop-AzKeyVaultCertificateOperation
  - where:
      verb: Restore
      subject: DeletedCertificate
    set:
      verb: Undo
      subject: CertificateRemoval
  - where:
      verb: Restore
      subject: DeletedKey
    set:
      verb: Undo
      subject: KeyRemoval
  - where:
      verb: Restore
      subject: DeletedSecret
    set:
      verb: Undo
      subject: SecretRemoval
  - where:
      verb: Restore
      subject: DeletedStorageAccount
    set:
      verb: Undo
      subject: StorageAccountRemoval
      alias: Undo-AzKeyVaultManagedStorageAccountRemoval
  - where:
      verb: Restore
      subject: DeletedStorageDeletedSasDefinition
    set:
      verb: Undo
      subject: StorageSasDefinitionRemoval
      alias: Undo-AzKeyVaultManagedStorageSasDefinitionRemoval
  - where:
      verb: Invoke
      subject: DecryptKey
    set:
      verb: Unprotect
      subject: Key
  - where:
      verb: Invoke
      subject: EncryptKey
    set:
      verb: Protect
      subject: Key
```
