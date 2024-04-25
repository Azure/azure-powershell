<!-- region Generated -->
# Az.Synapse
This directory contains the PowerShell module for the Synapse service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

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
commit: 57e4490a06aad262ca9154dc15b40f5a11bf7af5
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/kustoPool.json

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
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Fix the case mismatch between swagger and RP
  - from: swagger-document
    where: $
    transform: return $.replace(/\/databases\//g, "/Databases/")
  - from: swagger-document
    where: $
    transform: return $.replace(/\/dataConnections\//g, "/DataConnections/")
  # Remove the unexpanded parameter set
  - where:
      variant: ^Add$|^AddViaIdentity$|^Check$|^CheckViaIdentity$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Detach$|^DetachViaIdentity$
    remove: true
  # Remove the unexpanded parameter set for specific commands
  - where:
      subject: ^KustoPoolAttachedDatabaseConfiguration$|^KustoPoolPrincipalAssignment$|^KustoPoolDatabasePrincipalAssignment$
      variant: ^Create$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      subject: ^KustoPool$
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Remove
      subject: KustoPoolLanguageExtension
      variant: ^Remove$|^RemoveViaIdentity$
    remove: true 
  # Custom commands
  - where:
      subject: ^KustoPool$
      variant: ^Create$|^CreateExpanded$
    hide: true
  - where:
      subject: ^KustoPoolDatabase$|^KustoPoolDataConnection$
      variant: ^Create$|^CreateExpanded$|^Update$|^UpdateExpanded$|^UpdateViaIdentity$|^UpdateViaIdentityExpanded$
    hide: true
  # Hide the operation API
  - where:
      subject: KustoOperation
    hide: true
  # Remove the set-* and test-* cmdlet
  - where:
      verb: Set|Test
    remove: true
  - where:
      subject: ^DataKustoPoolDataConnectionValidation$
    remove: true
  # Correct some generated code
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IDataConnection Property', 'public Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IDataConnection Property');
  # set alias for some name
  - where:
      verb: Get|Remove
      subject: KustoPoolDatabase
      parameter-name: DatabaseName
    set:
      alias: Name
  - where:
      verb: New|Get|Remove
      subject: KustoPoolAttachedDatabaseConfiguration
      parameter-name: AttachedDatabaseConfigurationName
    set:
      alias: Name
  - where:
      verb: Get|Remove
      subject: KustoPoolDataConnection
      parameter-name: DataConnectionName
    set:
      alias: Name
```
