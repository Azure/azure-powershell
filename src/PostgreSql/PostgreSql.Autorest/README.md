<!-- region Generated -->
# Az.PostgreSql
This directory contains the PowerShell module for the PostgreSql service.

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
For information on how to develop for `Az.PostgreSql`, see [how-to.md](how-to.md).
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
commit: d241e05b224891ddc0147544213d8edccf53f7d9
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/postgresql/resource-manager/Microsoft.DBforPostgreSQL/stable/2017-12-01/postgresql.json
  - $(repo)/specification/postgresql/resource-manager/Microsoft.DBforPostgreSQL/stable/2017-12-01/ServerSecurityAlertPolicies.json
  - $(repo)/specification/postgresql/resource-manager/Microsoft.DBforPostgreSQL/stable/2021-06-01/postgresql.json
  - $(repo)/specification/postgresql/resource-manager/Microsoft.DBforPostgreSQL/stable/2021-06-01/Databases.json
module-version: 0.1.0
title: PostgreSQL 
subject-prefix: 'PostgreSQL'

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^CheckNameAvailability_Execute$/g, "NameAvailability_Test")
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^LocationBasedCapabilities_Execute$/g, "LocationBasedCapabilities_Get")
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^ServerParameters_ListUpdateConfigurations$/g, "ConfigurationsList_Update")
  - from: Microsoft.DBforPostgreSQL/stable/2017-12-01/postgresql.json
    where: $.definitions.VirtualNetworkRule
    transform: $['required'] = ['properties']
  - from: Microsoft.DBforPostgreSQL/stable/2021-06-01/postgresql.json
    where: $.paths..operationId
    transform: return $.replace(/^(Servers|ServerKeys)_/g, "flexible$1_")
  - from: Microsoft.DBforPostgreSQL/stable/2021-06-01/postgresql.json
    where: $.paths..operationId
    transform: return $.replace(/^(FirewallRules|Configurations|NameAvailabilities|LocationBasedCapabilities)_/g, "flexibleServer$1_")
  - from: Microsoft.DBforPostgreSQL/stable/2021-06-01/Databases.json
    where: $.paths..operationId
    transform: return $.replace(/^(Databases)_/g, "flexibleServer$1_")
  - from: Microsoft.DBforPostgreSQL/stable/2021-06-01/postgresql.json
    where: $.paths..operationId
    transform: return $.replace(/^VirtualNetworkSubnetUsage_Execute$/g,"flexibleServerVirtualNetworkSubnetUsage_Get")
  - from: Microsoft.DBforPostgreSQL/stable/2021-06-01/Databases.json
    where: $.paths..operationId
    transform: return $.replace(/^(Databases)_/g, "flexibleServer$1_")
  - from: Microsoft.DBforPostgreSQL/stable/2021-06-01/postgresql.json
    where: 
      verb: Restore$
      subject: ^FlexibleServer$
    hide: true
  - where:
      verb: Get$
      subject: ^FlexibleServerVirtualNetworkSubnetUsage$|^FlexibleServerLocationBasedCapability$
    hide: true
  - where:
      verb: Execute$
      subject: ^PrivateDnsZoneSuffix$
    hide: true
  - where:
      verb: Test$
      subject: ^FlexibleServerNameAvailability$
    hide: true
  - where:
      verb: Set
      subject: Configuration$|FirewallRule$|VirtualNetworkRule$|^flexibleServerFirewallRule$
    set:
      verb: Update
  - where:
      subject: ^Database$|^ServerSecurityAlertPolicy$|^ServerAdministrator$|^LocationBasedPerformanceTier$|^LogFile$|^NameAvailability$|^FlexibleServerKey$|^FlexibleServerVirtualNetworkSubnetUsage$|^ServerBasedPerformanceTier$
    hide: true
  - where:
      verb: New$|Update$
      subject: ^Server$|^Configuration$|^FirewallRule$|^FlexibleServer$|^FlexibleServerFirewallRule$
    hide: true
  - where:
      verb: New$
      variant: ^Create$|^CreateViaIdentity
      subject: ^Server$|^Configuration$|^FirewallRule$|^Database$|^LocationBasedPerformanceTier$|^LogFile$|^SecurityAlertPolicy$|^Administrator$|^NameAvailability$|^VirtualNetworkRule$
    hide: true
  - where:
      verb: Update$
      subject: ^FlexibleServerConfiguration$
    hide: true
  - where:
      verb: New$|Update$
      variant: ^(?!.*?Expanded)
    hide: true
  - where:
      subject: ^ConfigurationsList$|^RecoverableServer$
    remove: true
  - where:
      parameter-name: VirtualNetworkSubnetId
      subject: VirtualNetworkRule
    set:
      parameter-name: SubnetId
  - where:
      model-name: Server
    set:
      format-table:
        properties:
        - Name
        - Location
        - AdministratorLogin
        - Version
        - StorageProfileStorageMb
        - SkuName
        - SkuTier
        - SslEnforcement
  - where:
      model-name: ServerAutoGenerated
    set:
      format-table:
        properties:
          - Name
          - Location
          - SkuName
          - SkuTier
          - AdministratorLogin
          - Version
          - StorageProfileStorageMb
  - where:
      model-name: Configuration
    set:
      format-table:
        properties:
        - Name
        - Value
        - AllowedValue
        - Source
        - DefaultValue
  - where:
      model-name: ConfigurationAutoGenerated
    set:
      format-table:
        properties:
        - Name
        - Value
        - AllowedValue
        - Source
        - DefaultValue
  - where:
      model-name: FirewallRule
    set:
      format-table:
        properties:
        - Name
        - StartIPAddress
        - EndIPAddress
  - where:
      model-name: DatabaseAutoGenerated
    set:
      format-table:
        properties:
          - Name
          - Charset
          - Collation
          - Id
  - where:
      subject: ^FlexibleServer$
      parameter-name: ServerName
    set:
      parameter-name: Name
      alias: ServerName
  - where:
      subject: ^FlexibleServerFirewallRule$
      parameter-name: FirewallRuleName
    set:
      parameter-name: Name
      alias: FirewallRuleName
  - where:
      subject: ^FlexibleServerDatabase$
      parameter-name: DatabaseName
    set:
      parameter-name: Name
      alias: DatabaseName
  - where:
      subject: ^FlexibleServerConfiguration$
      parameter-name: ConfigurationName
    set:
      parameter-name: Name
      alias: ConfigurationName
  - where:
      parameter-name: StorageProfileBackupRetentionDay
      subject: Server
    set:
      parameter-description: Backup retention days for the server. Day count is between 7 and 35.
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/OperationOrigin System/, 'OperationOrigin System1');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreate Property', 'public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreate Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public int StorageProfileBackupRetentionDay', '[System.Management.Automation.ValidateRangeAttribute(7,35)]\n        public int StorageProfileBackupRetentionDay');
```
