<!-- region Generated -->
# Az.RegionMove
This directory contains the PowerShell module for the RegionMove service.

---
## Status
[![Az.RegionMove](https://img.shields.io/powershellgallery/v/Az.RegionMove.svg?style=flat-square&label=Az.RegionMove "Az.RegionMove")](https://www.powershellgallery.com/packages/Az.RegionMove/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.RegionMove`, see [how-to.md](how-to.md).
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

> Metadata
``` yaml
metadata:
  authors: Microsoft Corporation
  owners: Microsoft Corporation
  description: 'Microsoft Azure PowerShell: $(service-name) cmdlets'
  copyright: Microsoft Corporation. All rights reserved.
  tags: Azure ResourceManager ARM PSModule $(service-name)
  companyName: Microsoft Corporation
  requireLicenseAcceptance: true
  licenseUri: https://aka.ms/azps-license
  projectUri: https://github.com/Azure/azure-powershell

service-name: RegionMove
powershell: true
azure: true
branch: kakattam/sourceidchanges
repo: https://github.com/kattamudi-karthik/azure-rest-api-specs/tree/$(branch)
prefix: AzResourceMover
subject-prefix: ''
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
clear-output-folder: true
output-folder: .
aks: $(repo)/specification/regionmove/resource-manager/Microsoft.Migrate/preview/2019-10-01-preview
input-file:
	- $(aks)/regionmovecollection.json
module-version: 1.0.0
title: Rms-client
directive:
  - where:
      verb: Get
      subject: MoveCollection
    set:
      alias: Select-AzResourceMoveContext
  - where:
      verb: New
      subject: MoveCollection
    set:
      alias: AzResourceMoveContext
  - where:
      verb: Get
      subject: MoveResource
    set:
      alias: Add-AzResourceToMoveContext
  - where:
      verb: Test
      subject: MoveCollectionDependency
    set:
      alias: ValidateAzResourceMoveDependencies
  - where:
      model-name: MoveResource
    set:
       suppress-format: true
  - where:
      model-name: OperationStatus
    set:
       suppress-format: true
```
