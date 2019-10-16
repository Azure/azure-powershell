<!-- region Generated -->
# Az.ContainerService
This directory contains the PowerShell module for the ContainerService service.

---
## Status
[![Az.ContainerService](https://img.shields.io/powershellgallery/v/Az.ContainerService.svg?style=flat-square&label=Az.ContainerService "Az.ContainerService")](https://www.powershellgallery.com/packages/Az.ContainerService/)

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
For information on how to develop for `Az.ContainerService`, see [how-to.md](how-to.md).
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

### General settings
> Values

``` yaml
powershell: true
azure: true
branch: master
repo: https://github.com/erich-wang/azure-rest-api-specs/blob/$(branch)
prefix: Az
subject-prefix: ''
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
clear-output-folder: true
output-folder: .
aks: $(repo)/specification/containerservice/resource-manager/Microsoft.ContainerService
input-file:
- $(aks)/stable/2019-08-01/location.json
- $(aks)/stable/2019-08-01/managedClusters.json
- $(aks)/stable/2017-07-01/containerService.json

module-version: 0.0.1
title: ContainerServiceClient

directive:
  - where:
      subject: Operation
    hide: true
  - where: $.definitions.Identifier.properties
    suppress: R3019
```

<!--

REMOVED FROM input-files
- $(aks)/preview/2019-09-30/openShiftManagedClusters.json



require:
  - $(repo)/specification/containerservice/resource-manager/readme.md

``` yaml
azure: true
powershell: true
branch: master
repo: https://github.com/erich-wang/azure-rest-api-specs/blob/$(branch)
```

> Names
``` yaml
prefix: Az
subject-prefix: $(service-name)
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
```

> Folders
``` yaml
clear-output-folder: true
output-folder: .
```

> Profiles
``` yaml
require: $(repo)/profiles/readme.md
profile:
  - hybrid-2019-03-01
  - latest-2019-04-30
```

> Directives
``` yaml
directive:
  - where:
      subject: Operation
    hide: true
```

``` yaml
require:
  - $(repo)/specification/containerservice/resource-manager/readme.md

module-version: 0.0.1

```
-->
