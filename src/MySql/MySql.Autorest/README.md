<!-- region Generated -->
# Az.MySql
This directory contains the PowerShell module for the MySql service.

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
For information on how to develop for `Az.MySql`, see [how-to.md](how-to.md).
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
commit: 7af6056c5682b12ccfc2bb358b290158e9fce917
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/stable/2017-12-01/mysql.json
  - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/stable/2017-12-01/ServerSecurityAlertPolicies.json
  - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/stable/2021-05-01/mysql.json
module-version: 0.1.0
title: MySQL
subject-prefix: 'MySQL'

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^CheckNameAvailability_Execute$/g, "NameAvailability_Test")
  - from: Microsoft.DBforMySQL/stable/2017-12-01/mysql.json
    where: $.definitions.VirtualNetworkRule
    transform: $['required'] = ['properties']
  - from: Microsoft.DBforMySQL/stable/2017-12-01/mysql.json
    where: $.paths..operationId
    transform: return $.replace(/^ServerParameters_ListUpdateConfigurations$/g, "ServerConfigurationsList_Update")
  - from: Microsoft.DBforMySQL/stable/2021-05-01/mysql.json
    where: $.paths..operationId
    transform: return $.replace(/^(Servers|ServerKeys)_/g, "flexible$1_")
  - from: Microsoft.DBforMySQL/stable/2021-05-01/mysql.json
    where: $.paths..operationId
    transform: return $.replace(/^(Replicas|FirewallRules|Databases|Configurations|NameAvailability|LocationBasedCapabilities)_/g, "flexibleServer$1_")
  - from: Microsoft.DBforMySQL/stable/2021-05-01/mysql.json
    where: $.paths..operationId
    transform: return $.replace(/^CheckVirtualNetworkSubnetUsage_Execute$/g,"flexibleServerVirtualNetworkSubnetUsage_Get")
  - from: Microsoft.DBforMySQL/stable/2021-05-01/mysql.json
    where: 
      verb: Restore$
      subject: ^FlexibleServer$
    hide: true
  - where:
      verb: Get$
      subject: ^FlexibleServerVirtualNetworkSubnetUsage$|^FlexibleServerLocationBasedCapability$|^RecoverableServer$|^ServerBasedPerformanceTier$|^Backup$
    hide: true
  - where:
      verb: Test$
      subject: ^FlexibleServerNameAvailability$
    hide: true
  - where:
      verb: Set
      subject: ^Configuration$|^FirewallRule$|^VirtualNetworkRule$|^flexibleServerDatabase$|^flexibleServerFirewallRule$|^flexibleServer$
    set:
      verb: Update
  - where:
      subject: ^Database$|^LocationBasedPerformanceTier$|^LogFile$|SecurityAlertPolicy$|Administrator$|NameAvailability$|^FlexibleServerKey$|^FlexibleServerVirtualNetworkSubnetUsage$
    hide: true
  - where:
      verb: New$|Update$
      subject: ^Server$|^Configuration$|^FirewallRule$|^FlexibleServer$|^FlexibleServerFirewallRule$
    hide: true
  - where:
      verb: Update$
      subject: ^FlexibleServerConfiguration$|^flexibleServerDatabase$
    hide: true
  - where:
      verb: New$
      variant: ^Create$|^CreateViaIdentity
      subject: ^Server$|^Configuration$|^FirewallRule$|^Database$|^LocationBasedPerformanceTier$|^LogFile$|SecurityAlertPolicy$|Administrator$|NameAvailability$|^VirtualNetworkRule$
    hide: true
  - where:
      verb: New$|Update$
      variant: ^(?!.*?Expanded)
    hide: true
  - where:
      verb: Invoke$
      subject: ^BatchFlexibleServerConfigurationUpdate$|^ExecuteGetPrivateDnsZoneSuffix$
    hide: true
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
          - StorageSizeGb
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
          - StorageSizeGb
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
      model-name: FirewallRuleAutoGenerated
    set:
      format-table:
        properties:
          - Name
          - StartIPAddress
          - EndIPAddress
  - where:
      model-name: Database
    set:
      format-table:
        properties:
          - Name
          - Charset
          - Collation
          - Id
  - where:
      model-name: DatabaseAutogenerated
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
      subject: ^CapabilityProperty$
      parameter-name: LocationName
    set:
      parameter-name: Location
      alias: LocationName
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
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreate Property', 'public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreate Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public int StorageProfileBackupRetentionDay', '[System.Management.Automation.ValidateRangeAttribute(7,35)]\n        public int StorageProfileBackupRetentionDay');
```
