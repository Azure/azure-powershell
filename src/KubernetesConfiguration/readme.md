<!-- region Generated -->
# Az.KubernetesConfiguration
This directory contains the PowerShell module for the KubernetesConfiguration service.

---
## Status
[![Az.KubernetesConfiguration](https://img.shields.io/powershellgallery/v/Az.KubernetesConfiguration.svg?style=flat-square&label=Az.KubernetesConfiguration "Az.KubernetesConfiguration")](https://www.powershellgallery.com/packages/Az.KubernetesConfiguration/)

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
For information on how to develop for `Az.KubernetesConfiguration`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/kubernetesconfiguration/resource-manager/Microsoft.KubernetesConfiguration/preview/2019-11-01-preview/kubernetesconfiguration.json

title: KubernetesConfiguration
module-version: 0.1.0
subject-prefix: ''

identity-correction-for-post: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      subject: SourceControlConfiguration
    set:
      subject: KubernetesConfiguration
  - where:
      parameter-name: ClusterResourceName
    set:
      parameter-name: ClusterType
  - where:
      verb: Set
      subject: KubernetesConfiguration
    set:
      verb: Update
  - where:
      verb: New|Remove
      subject: KubernetesConfiguration
    hide: true
  - where:
      verb: Update
      subject: KubernetesConfiguration
    remove: true
```
