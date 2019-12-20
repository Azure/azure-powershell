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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

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
  - $(repo)/specification/keyvault/resource-manager/readme.md
  - $(repo)/specification/keyvault/data-plane/readme.md

title: KeyVault
module-version: 4.0.2

```

This hot-patches the swagger to have a better parameterized host.

``` yaml

directive: 
  # we have to pick the model that will not be inlined in a circular reference. (was very bad previously)
  - no-inline: 
    - Error
    
  - from: swagger-document
    where: $["x-ms-parameterized-host"]
    transform: >
      return {
      "hostTemplate": "https://{vaultName}.{keyVaultDnsSuffix}/",
      "useSchemePrefix": false,
      "positionInOperation": "first",
      "parameters": [
        {
          "name": "vaultName",
          "description": "The name of the vault to execute operations on.",
          "required": true,
          "type": "string",
          "in": "path",
          "x-ms-skip-url-encoding": true
        },
        {
          "name": "keyVaultDnsSuffix",
          "description": "The URI used as the base for all key vault requests.",
          "required": true,
          "type": "string",
          "in": "path",
          "x-ms-skip-url-encoding": true,
          "default": "vault.azure.net",
          "x-ms-parameter-location": "client"
        }
      ]}
```

``` yaml
directive:
  - where:
      parameter-name: OutFile
    set:
      alias: OutputFile
  - where:
      verb: Clear|Get
      subject: VaultDeleted
    hide: true
  - where:
      verb: Clear|Get
      subject: DeletedCertificate
    hide: true
  - where:
      verb: Clear|Get
      subject: DeletedKey
    hide: true
  - where:
      verb: Clear|Get
      subject: DeletedSecret
    hide: true
  - where:
      verb: Clear|Get
      subject: DeletedStorageAccount
    hide: true
  - where:
      verb: Get
      subject: DeletedStorageDeletedSasDefinition
    hide: true
  - where:
      subject: CertificateContact
    hide: true
  - where:
      verb: Invoke
      subject: SignKey|UnwrapKey|WrapKey
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
  - where:
      verb: New
      subject: ''
      parameter-name: SkuName
    set:
      alias: Sku
  - where:
      verb: Test
      subject: VaultNameAvailability
    set:
      subject: Vault
  - where:
      verb: Import
      subject: Certificate
      parameter-name: Base64EncodedCertificate
    set:
      parameter-name: CertificateString
  - where:
      verb: New
      subject: Certificate
      parameter-name: Policy
    set:
      alias: CertificatePolicy
  - where:
      verb: Set
      subject: CertificateIssuer
      parameter-name: Provider
    set:
      alias: IssuerProvider
  - where:
      verb: Set
      subject: CertificateIssuer
      parameter-name: CredentialsAccountId
    set:
      alias: AccountId
  - where:
      verb: Set
      subject: CertificateIssuer
      parameter-name: CredentialsPassword
    set:
      alias: ApiKey
  - where:
      parameter-name: Attribute(.*)
    set:
      parameter-name: $1
  - where:
      verb: Update
      subject: CertificatePolicy
      parameter-name: SecretPropContentType
    set:
      parameter-name: SecretContentType
  - where:
      verb: Update
      subject: CertificatePolicy
      parameter-name: KeyProp(.*)
    set:
      parameter-name: $1
  - where:
      verb: Update
      subject: CertificatePolicy
      parameter-name: X509Prop(.*)
    set:
      parameter-name: $1
  - where:
      verb: Update
      subject: CertificatePolicy
      parameter-name: Subject
    set:
      parameter-name: SubjectName
  - where:
      verb: Update
      subject: CertificatePolicy
      parameter-name: SanDnsName
    set:
      parameter-name: DnsName
  - where:
      verb: Update
      subject: CertificatePolicy
      parameter-name: IssuerCertificateType
    set:
      parameter-name: CertificateType
  - where:
      verb: Set
      subject: Secret
      parameter-name: Value
    set:
      parameter-name: SecretValue
  - where:
      verb: Set
      subject: StorageAccount
      parameter-name: ResourceId
    set:
      alias: AccountResourceId
  - where:
      parameter-name: Maxresult
    set:
      parameter-name: MaxResult
  - where:
      subject: StorageSasDefinition
      variant: (.*)Expanded(.*)
      parameter-name: Parameter
    set:
      parameter-name: DefinitionMetadata
  - where:
      verb: Test
      subject: Vault
      variant: Check
    hide: true
  - where:
      verb: Set
      subject: Vault
    hide: true
  # Format output
  - where:
      model-name: Vault
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - Uri
  - where:
      model-name: DeletedVault
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - DeletionDate
          - ScheduledPurgeDate
  - where:
      model-name: KeyItem
    set:
      format-table:
        properties:
          - Name
          - AttributeEnabled
          - AttributeCreated
          - AttributeUpdated
        labels:
          AttributeEnabled: Enabled
          AttributeCreated: Created
          AttributeUpdated: Updated
  - where:
      model-name: SecretItem
    set:
      format-table:
        properties:
          - Name
          - AttributeEnabled
          - AttributeCreated
          - AttributeUpdated
        labels:
          AttributeEnabled: Enabled
          AttributeCreated: Created
          AttributeUpdated: Updated
  - where:
      model-name: SecretBundle
    set:
      format-table:
        properties:
          - Name
          - Version
          - AttributeEnabled
          - AttributeCreated
          - AttributeUpdated
        labels:
          AttributeEnabled: Enabled
          AttributeCreated: Created
          AttributeUpdated: Updated
  - where:
      model-name: CertificateIssuerItem
    set:
      format-table:
        properties:
          - Name
          - Provider
  - where:
      model-name: IssuerBundle
    set:
      format-table:
        properties:
          - Name
          - Provider
  - where:
      model-name: CertificateOperation
    set:
      format-table:
        properties:
          - Name
          - Id
          - IssuerName
          - Status
  - where:
      model-name: CertificatePolicy
    set:
      format-table:
        properties:
          - X509PropSubject
          - AttributeEnabled
          - AttributeCreated
          - AttributeUpdated
        labels:
          X509PropSubject: SubjectName
          AttributeEnabled: Enabled
          AttributeCreated: Created
          AttributeUpdated: Updated
# Fix the name of the module in the nuspec
  - from: Az.KeyVault.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - Key Vault service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor more information on Key Vault, please visit the following$1 https://docs.microsoft.com/azure/key-vault/');
# Add release notes
  - from: Az.KeyVault.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview KeyVault cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
# Make the nuget package a preview
  - from: Az.KeyVault.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) KeyVault cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - Key Vault service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor more information on Key Vault, please visit the following$1 https://docs.microsoft.com/azure/key-vault/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview KeyVault cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
```
