<!-- region Generated -->
# Az.AD
This directory contains the PowerShell module for the Ad service.

---
## Status
[![Az.AD](https://img.shields.io/powershellgallery/v/Az.AD.svg?style=flat-square&label=Az.AD "Az.AD")](https://www.powershellgallery.com/packages/Az.AD/)

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
For information on how to develop for `Az.AD`, see [how-to.md](how-to.md).
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
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  #- https://github.com/Azure/azure-rest-api-specs/blob/master/specification/confluent/resource-manager/Microsoft.Confluent/stable/2020-03-01/confluent.json
  #- ../../../azure-rest-api-specs/specification/confluent/resource-manager/Microsoft.Confluent/stable/2020-03-01/confluent.json
  - https://github.com/Azure/azure-rest-api-specs/blob/master/specification/graphrbac/data-plane/Microsoft.GraphRbac/stable/1.6/graphrbac.json
module-version: 0.1.0
#title: Confluent
title: AD
service-name: AD
subject-prefix: AD

directive:
  # - where:
  #     subject: OrganizationOperation
  #   hide: true
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentityExpanded$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      subject-prefix: Ad
    set:
      subject-prefix: AD
```
