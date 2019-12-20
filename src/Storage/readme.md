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
module-version: 4.0.2
skip-model-cmdlets: true

directive:
  - where:
      subject: ^Usage$
    set:
      subject: StorageUsage
  # Blob/Storage Container
  - where:
      subject: ^BlobContainer
    set:
      subject: RmStorageContainer
  - where:
      subject: ^BlobService
    set:
      subject: StorageBlobService
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
      verb: Set
      subject: RmStorageContainerImmutabilityPolicy
    hide: true
  - where:
      verb: Invoke
      subject: ExtendBlobContainerImmutabilityPolicy
    hide: true
  # StorageAccount
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
      verb: Set
      subject: ^StorageAccount$
    set:
      verb: Invoke
      subject: StorageAccountFailover
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
  - where:
      subject: .*ImmutabilityPolicy.*
      parameter-name: ImmutabilityPeriodSinceCreationInDay
    set:
      parameter-name: ImmutabilityPeriod
  - where:
      subject: StorageAccountProperty
    hide: true
  - where:
      verb: Update
      subject: ^StorageAccount$
    hide: true
  - where:
      verb: New
      subject: ^StorageAccount$
    hide: true
  # Update csproj for customizations
  - from: Az.Storage.csproj
    where: $
    transform: >
        return $.replace('</Project>', '  <Import Project=\"custom\\dataplane.props\" />\n</Project>' );
  # Fix duplicate name
  - where:
      subject: StorageAccountNameAvailability
      variant: ^Check\d?$|^CheckViaIdentity\d?$
      parameter-name: Name
    set:
      parameter-name: Parameter
# Update psm1 for module load
  - from: Az.Storage.psm1
    where: $
    transform: >
        return $.replace('\$null = Import-Module -Name \(Join-Path $PSScriptRoot \'\./bin/Az\.Storage\.private\.dll\'\)', '');
#
  - from: Az.Storage.psm1
    where: $
    transform: >
        return $.replace('\$instance = \[Microsoft\.Azure\.PowerShell\.Cmdlets\.Storage\.Module\]::Instance', '' );
# add back in
  - from: Az.Storage.psm1
    where: $
    transform: >
        return $.replace('# Ask for the shared functionality table', '$null = Import-Module -Name (Join-Path $PSScriptRoot \'./bin/Az.Storage.private.dll\')\n# Ask for the shared functionality table' );
# add again
  - from: Az.Storage.psm1
    where: $
    transform: >
        return $.replace('# Ask for the shared functionality table', '$instance = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Module]::Instance\n# Ask for the shared functionality table' );

# Fix the name of the module in the nuspec
  - from: Az.Storage.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - Storage service data plane and management cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor more information on Resource Manager, please visit the following$1 https://docs.microsoft.com/azure/azure-resource-manager/\nFor more information on Storage, please visit the following$1 https://docs.microsoft.com/azure/storage/');
# Add release notes
  - from: Az.Storage.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview Azure Storage cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
# Make the nuget package a preview
  - from: Az.Storage.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Add dependencies to the nuspec
  - from: Az.Storage.nuspec
    where: $
    transform: $ = $.replace('<file src="bin/Az.Storage.private.deps.json" target="bin" />', '<file src="bin/Az.Storage.private.deps.json" target="bin" />\n    <file src="bin/Microsoft.Azure.Cosmos.Table.dll" target="bin" />\n    <file src="bin/Microsoft.Azure.DocumentDB.Core.dll" target="bin" />\n    <file src="bin/Microsoft.Azure.KeyVault.Core.dll" target="bin" />\n    <file src="bin/Microsoft.Azure.Storage.Blob.dll" target="bin" />\n    <file src="bin/Microsoft.Azure.Storage.Common.dll" target="bin" />\n    <file src="bin/Microsoft.Azure.Storage.DataMovement.dll" target="bin" />\n    <file src="bin/Microsoft.Azure.Storage.File.dll" target="bin" />\n    <file src="bin/Microsoft.Azure.Storage.Queue.dll" target="bin" />\n    <file src="bin/Microsoft.OData.Core.dll" target="bin" />');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) Storage cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - Storage service data plane and management cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor more information on Resource Manager, please visit the following$1 https://docs.microsoft.com/azure/azure-resource-manager/\\nFor more information on Storage, please visit the following$1 https://docs.microsoft.com/azure/storage/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview Storage cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
```
