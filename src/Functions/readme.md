<!-- region Generated -->
# Az.Functions
This directory contains the PowerShell module for the Functions service.

---
## Status
[![Az.Functions](https://img.shields.io/powershellgallery/v/Az.Functions.svg?style=flat-square&label=Az.Functions "Az.Functions")](https://www.powershellgallery.com/packages/Az.Functions/)

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
For information on how to develop for `Az.Functions`, see [how-to.md](how-to.md).
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
use: "@microsoft.azure/autorest.powershell@beta"
azure: true
branch: master
repo: https://github.com/Azure/azure-rest-api-specs/blob/$(branch)
prefix: Az
subject-prefix: ''
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
clear-output-folder: true
output-folder: .
require:
  - $(repo)/specification/web/resource-manager/readme.md
enable-multi-api: false
web: $(repo)/specification/web/resource-manager/Microsoft.Web
input-file:
- $(web)/stable/2018-02-01/Certificates.json
- $(web)/stable/2018-02-01/CommonDefinitions.json
- $(web)/stable/2018-02-01/DeletedWebApps.json
- $(web)/stable/2018-02-01/Diagnostics.json
- $(web)/stable/2018-02-01/Provider.json
- $(web)/stable/2018-02-01/Recommendations.json
- $(web)/stable/2018-02-01/ResourceProvider.json
- $(web)/stable/2018-02-01/WebApps.json
- $(web)/stable/2018-02-01/AppServiceEnvironments.json
- $(web)/stable/2018-02-01/AppServicePlans.json
- $(web)/stable/2018-02-01/ResourceHealthMetadata.json

module-version: 0.0.1
title: FunctionsClient

directive:
  - where:
      subject: Operation
    hide: true
  - where: $.definitions.Identifier.properties
    suppress: R3019
```
