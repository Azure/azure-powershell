<!-- region Generated -->
# Az.ProviderHub
This directory contains the PowerShell module for the ProviderHub service.

---
## Status
[![Az.ProviderHub](https://img.shields.io/powershellgallery/v/Az.ProviderHub.svg?style=flat-square&label=Az.ProviderHub "Az.ProviderHub")](https://www.powershellgallery.com/packages/Az.ProviderHub/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ProviderHub`, see [how-to.md](how-to.md).
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
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/9cee82c90c9c188dda3cf33a9816bdcdb395f00a/specification/providerhub/resource-manager/Microsoft.ProviderHub/stable/2020-11-20/providerhub.json

module-version: 0.1.0
title: ProviderHub
subject-prefix: $(service-name)
identity-correction-for-post: true

directive:
  - from: swagger-document
    where: $.definitions.Error.properties
    transform: delete $.innerError
  - from: swagger-document
    where: $
    transform: $ = $.replace(/"authorizations"/, '"fakefields"');
  - from: swagger-document
    where: $.definitions.FeaturesRule.properties
    transform: >-
      return {
        "requiredFeaturesPolicy": {
          "type": "string"
        }
      }
  - no-inline:
    - Error
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Manifest$|^ManifestViaIdentity$|^ManifestViaIdentityExpanded$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: Get|New|Remove
      subject: SkuNestedResourceTypeFirst
    hide: true
  - where:
      verb: Get|New|Remove
      subject: SkuNestedResourceTypeSecond
    hide: true
  - where:
      verb: Get|New|Remove
      subject: SkuNestedResourceTypeThird
    hide: true
  - where:
      verb: New
      subject: ProviderRegistrationOperation
    hide: true
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/fakefield/g, 'authorization');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/Fakefield/g, 'Authorization');
```
