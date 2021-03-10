v

<!-- region Generated -->
# Az.DnsResolver
This directory contains the PowerShell module for the DnsResolver service.

---
## Status
[![Az.DnsResolver](https://img.shields.io/powershellgallery/v/Az.DnsResolver.svg?style=flat-square&label=Az.DnsResolver "Az.DnsResolver")](https://www.powershellgallery.com/packages/Az.DnsResolver/)

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
For information on how to develop for `Az.DnsResolver`, see [how-to.md](how-to.md).
<!-- endregion -->

<!-- region Generated -->
# DnsResolver
This directory contains the PowerShell module for the DnsResolver service.

---
## Status
[![DnsResolver](https://img.shields.io/powershellgallery/v/DnsResolver.svg?style=flat-square&label=DnsResolver "DnsResolver")](https://www.powershellgallery.com/packages/DnsResolver/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Development
For information on how to develop for `DnsResolver`, see [how-to.md](how-to.md).

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
branch: ffebe2759a66ebd6ca52288a9eaf1c02f28e3842
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs-pr/blob/Microsoft.Network-dnsresolver-2020-01-01-preview/specification/dnsresolver/resource-manager/Microsoft.Network/preview/2020-04-01-preview/dnsresolver.json

module-version: 0.1.0
title: DnsResolver
subject-prefix: $(service-name)

inlining-threshold: 50
# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
    # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
```
