<!-- region Generated -->
# Az.StackHCI
This directory contains the PowerShell module for the StackHci service.

---
## Status
[![Az.StackHCI](https://img.shields.io/powershellgallery/v/Az.StackHCI.svg?style=flat-square&label=Az.StackHCI "Az.StackHCI")](https://www.powershellgallery.com/packages/Az.StackHCI/)

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
For information on how to develop for `Az.StackHCI`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: ad5110c7ba2113d5f77946338231f45ac4d09c82
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2022-05-01/arcSettings.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2022-05-01/clusters.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2022-05-01/extensions.json

module-version: 1.1.0
title: StackHCI
service-name: StackHCI
subject-prefix: $(service-name)

inlining-threshold: 50

resourcegroup-append: true 

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
      subject: Workspace
    remove: true
  # Remove Update-AzStackHciExtension 
  - where:
      verb: Update
      subject: Extension
    remove: true
  # Remove Invoke-AzStackHciUploadClusterCertificate
  - where:
      verb: Invoke
      subject: UploadClusterCertificate
    remove: true 
  # Remove New-AzStackHciArcSettingPassword
  - where:
      verb: New
      subject: ArcSettingPassword
    remove: true
  # Remove Update-AzStackHciArcSetting
  - where:
      verb: Update
      subject: ArcSetting
    remove: true 
  # Hide aadClientId from Update-AzStackHCICluster
  - where:
      verb: Update
      subject: Cluster
      parameter-name: AadClientId
    hide: true
  # Hide name from arcSettings 
  - where:
      verb: New
      subject: ArcSetting
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'
  # Update ExtensionParameters.settings
  - from: swagger-document
    where: $.definitions.ExtensionParameters.properties.settings
    transform: $["additionalProperties"] = true
  # Update ExtensionParameters.protectedSettings
  - from: swagger-document
    where: $.definitions.ExtensionParameters.properties.protectedSettings
    transform: $["additionalProperties"] = true
```
