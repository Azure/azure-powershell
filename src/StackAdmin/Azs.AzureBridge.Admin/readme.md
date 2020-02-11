<!-- region Generated -->
# Azs.AzureBridge.Admin
This directory contains the PowerShell module for the BridgeAdmin service.

---
## Status
[![Azs.AzureBridge.Admin](https://img.shields.io/powershellgallery/v/Azs.AzureBridge.Admin.svg?style=flat-square&label=Azs.AzureBridge.Admin "Azs.AzureBridge.Admin")](https://www.powershellgallery.com/packages/Azs.AzureBridge.Admin/)

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
For information on how to develop for `Azs.AzureBridge.Admin`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/azsadmin/resource-manager/azurebridge/readme.azsautogen.md
  - $(repo)/specification/azsadmin/resource-manager/azurebridge/readme.md

### File Renames
module-name: Azs.AzureBridge.Admin
csproj: Azs.AzureBridge.Admin.csproj
psd1: Azs.AzureBridge.Admin.psd1
psm1: Azs.AzureBridge.Admin.psm1

directive:  
  - where:
        model-name: ActivationResource
    set:	  
        suppress-format: true
  - where:
        model-name: ProductResource
    set:	  
        suppress-format: true
  - where:
        model-name: DownloadedProductResource
    set:	  
        suppress-format: true
  
  # Add alias for ProductName to Name
  - where:
        parameter-name: ProductName
    set:
        alias: Name
        
  # Rename Properties 
  - where:
      model-name: ProductResource
      property-name: ProductPropertyVersion
    set:
      property-name: ProductProperties

  - where:
      model-name: DownloadedProductResource
      property-name: ProductPropertyVersion
    set:
      property-name: ProductProperties

  # Rename DownloadProduct to ProductDownload
  - where:
      verb: Invoke
      subject: DownloadProduct
    set:
      subject: ProductDownload

  # Remove cmdlets that don't exist in AzureRm module
  - where:
      verb: Set
    remove: true.
  - where:
      verb: New
    remove: true.
  - where:
      verb: Remove
      subject: Activation
    remove: true.

subject-prefix: AzureBridge
module-version: 0.0.1
```
