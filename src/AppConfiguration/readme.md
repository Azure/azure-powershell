<!-- region Generated -->
# Az.AppConfiguration
This directory contains the PowerShell module for the AppConfiguration service.

---
## Status
[![Az.AppConfiguration](https://img.shields.io/powershellgallery/v/Az.AppConfiguration.svg?style=flat-square&label=Az.AppConfiguration "Az.AppConfiguration")](https://www.powershellgallery.com/packages/Az.AppConfiguration/)

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
For information on how to develop for `Az.AppConfiguration`, see [how-to.md](how-to.md).
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
# locking the commit
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/29446bf77d48b7128b0c6d587b78355c2b4dde73/specification/appconfiguration/resource-manager/Microsoft.AppConfiguration/preview/2019-11-01-preview/appconfiguration.json

module-version: 0.2.0
title: AppConfiguration

directive:
  - where:
      parameter-name: ConfigStoreCreationParameter|RegenerateKeyParameter|CheckNameAvailabilityParameter
    select: command
    hide: true
  - where:
      verb: Update
      subject: ConfigurationStore
    hide: true
  - where:
      subject: OperationNameAvailability
    set:
      subject: StoreNameAvailability
  - where:
      subject: ConfigurationStoreKeyValue
      verb: Get
    remove: true

  # Sanitize doesn't work because parameter name doesn't start with subject
  - where:
      subject: ConfigurationStore|ConfigurationStoreKey
      parameter-name: ConfigStoreName
    set:
      parameter-name: Name

  # Private link features are implemented in Az.Network so we don't need them
  - where:
      subject: PrivateEndpointConnection|PrivateLinkResource
    remove: true
```
