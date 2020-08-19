<!-- region Generated -->
# Az.Kusto
This directory contains the PowerShell module for the Kusto service.

---
## Status
[![Az.Kusto](https://img.shields.io/powershellgallery/v/Az.Kusto.svg?style=flat-square&label=Az.Kusto "Az.Kusto")](https://www.powershellgallery.com/packages/Az.Kusto/)

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
For information on how to develop for `Az.Kusto`, see [how-to.md](how-to.md).
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
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2020-06-14/kusto.json

```

> Names
``` yaml
module-version: 0.1.4
title: Kusto
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
  # Fix the error in swagger, RP actually returns 200 when deletion succeeds
  - from: swagger-document
    where: $..produces
    transform: $ = $.filter( each => each === 'application/json');
    reason: this spec adds produces application/xml and text/json erronously.
  # Fix the case mismatch between swagger and RP
  - from: swagger-document
    where: $
    transform: return $.replace(/\/clusters\//g, "/Clusters/")
  - from: swagger-document
    where: $
    transform: return $.replace(/\/databases\//g, "/Databases/")
  - from: swagger-document
    where: $
    transform: return $.replace(/\/dataConnections\//g, "/DataConnections/")
  - from: swagger-document
    where: $
    transform: return $.replace(/\/attachedDatabaseConfigurations\//g, "/AttachedDatabaseConfigurations/")
  - from: swagger-document
    where: $
    transform: return $.replace(/\/principalAssignments\//g, "/PrincipalAssignments/")
  # Remove the unexpanded parameter set
  - where:
      variant: ^Add$|^AddViaIdentity$|^Check$|^CheckViaIdentity$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Detach$|^DetachViaIdentity$
    remove: true
  # Remove the unexpanded parameter set for specific commands
  - where:
      subject: ^AttachedDatabaseConfiguration$|^Cluster$|^ClusterPrincipalAssignment$|^DatabasePrincipalAssignment$
      variant: ^Create$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Remove
      subject: DatabasePrincipal|ClusterLanguageExtension
      variant: ^Remove$|^RemoveViaIdentity$
    remove: true
  # Custom commands
  - where:
      subject: ^DataConnectionValidation$
    hide: true
  - where:
      subject: ^Database$|^DataConnection$
      variant: ^Create$|^CreateExpanded$|^Update$|^UpdateExpanded$|^UpdateViaIdentity$|^UpdateViaIdentityExpanded$
    hide: true
  # Hide the operation API
  - where:
      subject: Operation
    hide: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Correct some generated code
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection Property', 'public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection Property');
```
