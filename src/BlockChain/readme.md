<!-- region Generated -->
# Az.Blockchain
This directory contains the PowerShell module for the Blockchain service.

---
## Status
[![Az.Blockchain](https://img.shields.io/powershellgallery/v/Az.Blockchain.svg?style=flat-square&label=Az.Blockchain "Az.Blockchain")](https://www.powershellgallery.com/packages/Az.Blockchain/)

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
For information on how to develop for `Az.Blockchain`, see [how-to.md](how-to.md).
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
azure: true
powershell: true
branch: ps-preview
repo: https://github.com/Azure/azure-rest-api-specs/blob/$(branch)
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
  - $(repo)/specification/blockchain/resource-manager/readme.md

module-version: 0.0.1

```
