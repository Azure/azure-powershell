<!-- region Generated -->
# Azs.Backup.Admin
This directory contains the PowerShell module for the BackupAdmin service.

---
## Status
[![Azs.Backup.Admin](https://img.shields.io/powershellgallery/v/Azs.Backup.Admin.svg?style=flat-square&label=Azs.Backup.Admin "Azs.Backup.Admin")](https://www.powershellgallery.com/packages/Azs.Backup.Admin/)

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
For information on how to develop for `Azs.Backup.Admin`, see [how-to.md](how-to.md).
<!-- endregion -->

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
  - $(this-folder)/../readme.azurestack.md
  - $(repo)/specification/azsadmin/resource-manager/backup/readme.azsautogen.md
  - $(repo)/specification/azsadmin/resource-manager/backup/readme.md
```

### File Renames 
``` yaml
module-name: Azs.Backup.Admin 
csproj: Azs.Backup.Admin.csproj 
psd1: Azs.Backup.Admin.psd1 
psm1: Azs.Backup.Admin.psm1
```

### Parameter default values
``` yaml
directive:
    # Default to Format-List for the Backup and BackupLocation model as there are many important fields
  - where:
      model-name: Backup
    set:
      suppress-format: true
  - where:
      model-name: BackupLocation
    set:
      suppress-format: true

    # Rename model property names
    # Remove "ExternalStoreDefault" from properties InfoStatus, InfoCreatedDateTime, InfoEncryptionCertThumbprint, etc.
  - where:
      model-name: BackupLocation
      property-name: ^ExternalStoreDefault(.+)
    set:
      property-name: $1
  - where:
      model-name: BackupLocation
      property-name: BackupFrequencyInHour
    set:
      property-name: BackupFrequencyInHours
  - where:
      model-name: BackupLocation
      property-name: BackupRetentionPeriodInDay
    set:
      property-name: BackupRetentionPeriodInDays
    # Remove "Info" from properties ExternalStoreDefaultPath, ExternalStoreDefaultUserName, ExternalStoreDefaultPassword, etc.
  - where:
      model-name: Backup
      property-name: ^Info(.+)
    set:
      property-name: $1

    # Default value for ResourceGroupName
  - where:
      parameter-name: ResourceGroupName
    set:
      default:
        script: '"system.$((Get-AzLocation)[0].Name)"'

    # Rename parameter Backup to Name
  - where:
      subject: Backup
      parameter-name: Backup
    set:
      parameter-name: Name

    # Rename Get/Set-AzsBackupLocation to Get/Set-AzsBackupConfiguration
  - where:
      subject: BackupLocation
    set:
      subject: BackupConfiguration

    # Rename cmdlet parameter names in Set-AzsBackupConfiguration
    # Remove "ExternalStoreDefault" from parameters ExternalStoreDefaultPath, ExternalStoreDefaultUserName, ExternalStoreDefaultPassword, etc.
  - where:
      verb: Set
      subject: BackupConfiguration
      parameter-name: ^ExternalStoreDefault(.+)
    set:
      parameter-name: $1
  - where:
      verb: Set
      subject: BackupConfiguration
      parameter-name: BackupFrequencyInHour
    set:
      parameter-name: BackupFrequencyInHours
  - where:
      verb: Set
      subject: BackupConfiguration
      parameter-name: BackupRetentionPeriodInDay
    set:
      parameter-name: BackupRetentionPeriodInDays

    # Hide the auto-generated Set-AzsBackupConfiguration and expose it through customized one
  - where:
      verb: Set
      subject: BackupConfiguration
    hide: true

    # Hide the auto-generated Restore-AzsBackup and expose it through customized one
  - where:
      verb: Restore
      subject: Backup
    hide: true

    # Hide the auto-generated Get-AzsBackup and expose it through customized one
  - where:
      verb: Get
      subject: Backup
    hide: true

    # Rename New-AzsBackupLocationBackup to Start-AzsBackup
  - where:
      verb: New
      subject: BackupLocationBackup
    set:
      verb: Start
      subject: Backup

    # Hide the auto-generated Start-AzsBackup and expose it through customized one
  - where:
      verb: Start
      subject: Backup
    hide: true

subject-prefix: ''
module-version: 0.0.1
