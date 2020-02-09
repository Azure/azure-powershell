<!-- region Generated -->
# Azs.Compute.Admin
This directory contains the PowerShell module for the ComputeAdmin service.

---
## Status
[![Azs.Compute.Admin](https://img.shields.io/powershellgallery/v/Azs.Compute.Admin.svg?style=flat-square&label=Azs.Compute.Admin "Azs.Compute.Admin")](https://www.powershellgallery.com/packages/Azs.Compute.Admin/)

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
For information on how to develop for `Azs.Compute.Admin`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/azsadmin/resource-manager/compute/readme.azsautogen.md
  - $(repo)/specification/azsadmin/resource-manager/compute/readme.md
```
``` yaml
### File Renames 
module-name: Azs.Compute.Admin 
csproj: Azs.Compute.Admin.csproj 
psd1: Azs.Compute.Admin.psd1 
psm1: Azs.Compute.Admin.psm1
```
### Parameter default values
``` yaml
directive:
    # Prepend Compute for the Quota cmdlets
  - where:
      subject: Quota
    set:
      subject-prefix: Compute

    # Rename New-AzsPlatformImage to Add-AzsPlatformImage
  - where:
      verb: New
      subject: PlatformImage
    set:
      verb: Add

    # Rename New-AzsVMExtension to Add-AzsVMExtension
  - where:
      verb: New
      subject: VMExtension
    set:
      verb: Add

    # Rename New-AzsDiskMigrationJob to Start-AzsDiskMigrationJob and create alias with same name 
  - where:
      verb: New
      subject: DiskMigrationJob
    set:
      alias: Start-AzsDiskMigrationJob  

  # Default to Format-List for the VMExtension commandlets as there are many important fields
  - where:
      model-name: VMExtension
    set:
      suppress-format: true

    # Default to Format-List for the Quota commandlets as there are many important fields
  - where:
      model-name: Quota
    set:
      suppress-format: true

    # Default to Format-List for the PlatformImage commandlets as there are many important fields
  - where:
      model-name: PlatformImage
    set:
      suppress-format: true

    # Default to Format-List for the Disk commandlets as there are many important fields
  - where:
      model-name: Disk
    set:
      suppress-format: true

    # Default to Format-List for the DiskMigrationJob commandlets as there are many important fields
  - where:
      model-name: DiskMigrationJob
    set:
      suppress-format: true

    # Rename DataDisk parameter to DataDisks in Add-AzsPlatformImage for back-compat
  - where:
      verb: Add
      subject: PlatformImage
      parameter-name: DataDisk
    set:
      parameter-name: DataDisks

    # Rename DetailBillingPartNumber parameter to BillingPartNumber for back-compat
  - where:
      parameter-name: DetailBillingPartNumber
    set:
      parameter-name: BillingPartNumber

    # Rename OsDiskOsType parameter to OsType for back-compat
  - where:
      parameter-name: OsDiskOsType
    set:
      parameter-name: OsType

    # Rename OsDiskUri parameter to OsUri for back-compat
  - where:
      parameter-name: OsDiskUri
    set:
      parameter-name: OsUri
  
    # Rename VmosType parameter to VmOsType for back-compat
  - where:
      parameter-name: VmosType
    set:
      parameter-name: VmOsType

  - where:
      parameter-name: SourceBlobUri
    set:
      parameter-name: SourceBlob

  - where:
      parameter-name: VmScaleSetEnabled
    set:
      parameter-name: VMScaleSetEnabled

  - where:
      parameter-set: SupportMultipleExtension
    set:
      parameter-set: SupportMultipleExtensions
  
subject-prefix: ''
module-version: 0.0.1
