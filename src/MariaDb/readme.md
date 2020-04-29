<!-- region Generated -->
# Az.MariaDb
This directory contains the PowerShell module for the MariaDb service.

---
## Status
[![Az.MariaDb](https://img.shields.io/powershellgallery/v/Az.MariaDb.svg?style=flat-square&label=Az.MariaDb "Az.MariaDb")](https://www.powershellgallery.com/packages/Az.MariaDb/)

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
For information on how to develop for `Az.MariaDb`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/mariadb/resource-manager/Microsoft.DBforMariaDB/preview/2018-06-01-preview/mariadb.json

title: MariaDB
module-version: 0.1.0

directive:
  - where:
      verb: Set
      subject: Configuration$|FirewallRule$|VirtualNetworkRule$
    set:
      verb: Update
  - where:
      verb: New
      variant: ^Create$
    hide: true
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: Configuration$|FirewallRule$|VirtualNetworkRule$
    remove: true

# Server
  - where:
      verb: New|Update|Restart
      subject: Server
    hide: true
  - where:
      parameter-name: StorageProfileBackupRetentionDay
      subject: Server
    set:
      parameter-description: Backup retention days for the server. Day count is between 7 and 35.
  - where:
      model-name: Server
    set:
      format-table:
        properties:
          - Name
          - Location
          - AdministratorLogin
          - Version
          - SkuName
          - StorageProfileStorageMb
          - SslEnforcement
# VNet
  - where:
      subject: VirtualNetworkRule
      parameter-name: Parameter
    set:
      parameter-name: VNetRule
  - where:
      subject: VirtualNetworkRule
      parameter-name: VirtualNetworkSubnetId
    set:
      parameter-name: SubnetId

# FirewallRule
  - where:
      subject: FirewallRule
      parameter-name: Parameter
    set:
      parameter-name: FirewallRule

# MariaDBConfiguration
  - where:
      verb: New
      subject: Configuration
    hide: true
  - where:
      verb: Update
      subject: Configuration
      parameter-name: Parameter
    set:
      parameter-name: Configuration

  - where:
      subject: LogFile|Database|LocationBasedPerformanceTier|CheckNameAvailability|ServerSecurityAlertPolicy
    hide: true

# Fix the bug that OperationOrigin.System conflict with namespace System
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/OperationOrigin System/, 'OperationOrigin System1');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/internal partial interface IServerForCreateInternal/, 'public partial interface IServerForCreateInternal');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public int StorageProfileBackupRetentionDay', '[System.Management.Automation.ValidateRangeAttribute(7,35)]\n        public int StorageProfileBackupRetentionDay');
```
