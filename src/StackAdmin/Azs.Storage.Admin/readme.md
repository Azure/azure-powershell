<!-- region Generated -->
# Azs.Storage.Admin
This directory contains the PowerShell module for the StorageAdmin service.

---
## Status
[![Azs.Storage.Admin](https://img.shields.io/powershellgallery/v/Azs.Storage.Admin.svg?style=flat-square&label=Azs.Storage.Admin "Azs.Storage.Admin")](https://www.powershellgallery.com/packages/Azs.Storage.Admin/)

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
For information on how to develop for `Azs.Storage.Admin`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/azsadmin/resource-manager/storage/readme.azsautogen.md

subject-prefix: 'Storage'
module-version: 0.0.1

### File Renames 
module-name: Azs.Storage.Admin 
csproj: Azs.Storage.Admin.csproj 
psd1: Azs.Storage.Admin.psd1 
psm1: Azs.Storage.Admin.psm1

directive:
  - where:
      subject: StorageQuota
      parameter-name: QuotaName
    set:
      parameter-name: Name
  - where:
      verb: New
      parameter-name: CapacityInGb
    set:
      default:
        script: '500'
  - where:
      verb: New
      parameter-name: NumberOfStorageAccount
    set:
      default:
        script: '20'
```
