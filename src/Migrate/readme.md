<!-- region Generated -->
# Az.Migrate
This directory contains the PowerShell module for the Migrate service.

---
## Status
[![Az.Migrate](https://img.shields.io/powershellgallery/v/Az.Migrate.svg?style=flat-square&label=Az.Migrate "Az.Migrate")](https://www.powershellgallery.com/packages/Az.Migrate/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.7.4 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Migrate`, see [how-to.md](how-to.md).
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
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/migrate/resource-manager/Microsoft.Migrate/stable/2019-10-01/migrate.json
  - $(repo)/specification/migrate/resource-manager/Microsoft.OffAzure/stable/2020-01-01/migrate.json
module-version: 0.1.0
title: Migrate 
subject-prefix: 'Migrate'

directive:
  - from: Microsoft.Migrate/stable/2019-10-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^Project_AssessmentOptions$/g, "Project_GetAssessmentOptions")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_GetAll(.*)$/g, "$1_List")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Get(.*)$/g, "$1_Get")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Put(.*)$/g, "$1_CreateOrUpdate")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Patch(.*)$/g, "$1_Update")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Refresh(.*)$)$/g, "$1_Refresh")
  - where:
      verb: Set$
      subject: HyperV(Cluster|Host)$|VCenter$
    set:
      verb: Update
  - where:
      verb: Set$
      subject: (HyperV)?Site$
    hide: true
  - where:
      verb: New$|Update$
      variant: ^(Update|Create)(?!.*?Expanded)
    hide: true
  - where:
      verb: New$
      variant: ^CreateViaIdentity
    hide: true
  - where:
      verb: New$|Set$|Update$
      subject: Site$|VCenter$
      parameter-name: Name
    clear-alias: true
