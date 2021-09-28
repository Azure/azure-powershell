<!-- region Generated -->
# Az.Synapse
This directory contains the PowerShell module for the Synapse service.

---
## Status
[![Az.Synapse](https://img.shields.io/powershellgallery/v/Az.Synapse.svg?style=flat-square&label=Az.Synapse "Az.Synapse")](https://www.powershellgallery.com/packages/Az.Synapse/)

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
For information on how to develop for `Az.Synapse`, see [how-to.md](how-to.md).
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

### General settings
> Values
``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/cde7f150e8d3bf3af2418cc347cae0fb2baed6a7/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/kustoPool.json

```

> Names
``` yaml
module-version: 0.1.0
title: Synapse
subject-prefix: $(service-name)
```

> Folders
``` yaml
clear-output-folder: true
output-folder: .
```

> Directives
``` yaml
identity-correction-for-post: true
directive:
  # Remove all commands except kusto pool
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  - where:
      subject: ^Database$|^DataConnection$|^KustoPoolPrincipalAssignment$|^DatabasePrincipalAssignment$|^KustoOperation$|^KustoPoolLanguageExtension$|^AttachedDatabaseConfiguration$|^KustoPoolFollowerDatabase$|^KustoPoolSku$
    remove: true
  - where:
      verb: Set|Test|Start|Stop|Invoke
    remove: true
  - where:
      subject: ^KustoPool$
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      subject: ^KustoPool$
      variant: ^Create$|^CreateExpanded$
    hide: true
```
