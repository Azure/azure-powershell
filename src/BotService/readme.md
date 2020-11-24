<!-- region Generated -->
# Az.BotService
This directory contains the PowerShell module for the BotService service.

---
## Status
[![Az.BotService](https://img.shields.io/powershellgallery/v/Az.BotService.svg?style=flat-square&label=Az.BotService "Az.BotService")](https://www.powershellgallery.com/packages/Az.BotService/)

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
For information on how to develop for `Az.BotService`, see [how-to.md](how-to.md).
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
  # - $(repo)/specification/botservice/resource-manager/Microsoft.BotService/preview/2018-07-12/botservice.json
  - $(this-folder)/resources/bot.json
  # - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2020-06-01/WebApps.json
  # - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2020-06-01/Certificates.json
  # - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2020-06-01/StaticSites.json
title: BotService
module-version: 0.1.0
subject-prefix: ''
directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^RegenerateViaIdentity$|^RegenerateViaIdentityExpanded$
    remove: true
  - where:
      subject: Bot
    set:
      subject: BotService
  - where:
      subject: BotService
      verb: New
    hide: true
  - where:
      subject: Channel|EnterpriseChannel|BotConnectionServiceProvider|BotConnection
    remove: true
  - where:
      subject: BotCheckNameAvailability
    hide: true
  - where:
      subject: BotService
      parameter-name: ResourceName
    set:
      parameter-name: Name
      alias: BotName
```
