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
commit: 2d973fccf9f28681a481e9760fa12b2334216e21
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/legacy/stable/2017-12-01/mysql.json
  - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/legacy/stable/2017-12-01/ServerSecurityAlertPolicies.json
  - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/legacy/stable/2021-05-01/mysql.json
  - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/FlexibleServers/stable/2023-12-30/AdvancedThreatProtectionSettings.json

module-version: 0.1.0
title: MySQL
subject-prefix: 'MySQL'

identity-correction-for-post: true
nested-object-to-string: true
auto-switch-view: false

directive:
  - where:
      variant: ^(Create|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true

  - where:
      subject: Operation
    remove: true

  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^CheckNameAvailability_Execute$/g, "NameAvailability_Test")

  - from: Microsoft.DBforMySQL/legacy/stable/2017-12-01/mysql.json
    where: $.definitions.VirtualNetworkRule
    transform: $['required'] = ['properties']

  - from: Microsoft.DBforMySQL/legacy/stable/2017-12-01/mysql.json
    where: $.paths..operationId
    transform: return $.replace(/^ServerParameters_ListUpdateConfigurations$/g, "ServerConfigurationsList_Update")

  - from: Microsoft.DBforMySQL/legacy/stable/2021-05-01/mysql.json
    where: $.paths..operationId
    transform: return $.replace(/^(Servers|ServerKeys)_/g, "Flexible$1_")

  - from: Microsoft.DBforMySQL/legacy/stable/2021-05-01/mysql.json
    where: $.paths..operationId
    transform: return $.replace(/^(Replicas|FirewallRules|Databases|Configurations|NameAvailability|LocationBasedCapabilities)_/g, "FlexibleServer$1_")

  - from: Microsoft.DBforMySQL/legacy/stable/2021-05-01/mysql.json
    where: $.paths..operationId
    transform: return $.replace(/^CheckVirtualNetworkSubnetUsage_Execute$/g,"FlexibleServerVirtualNetworkSubnetUsage_Get")

  - from: Microsoft.DBforMySQL/legacy/stable/2021-05-01/mysql.json
    where: 
      verb: Restore$
      subject: ^FlexibleServer$
    hide: true

  - where:
      verb: Get$
      subject: ^FlexibleServerVirtualNetworkSubnetUsage$|^FlexibleServerLocationBasedCapability$|^RecoverableServer$|^ServerBasedPerformanceTier$|^Backup$
    hide: true

  - where:
      verb: Set
      subject: ^Configuration$|^FirewallRule$|^VirtualNetworkRule$|^FlexibleServerDatabase$|^FlexibleServerFirewallRule$|^FlexibleServer$
    set:
      verb: Update

  - where:
      verb: Set
    hide: true

  - where:
      subject: ^Database$|^LocationBasedPerformanceTier$|^LogFile$|SecurityAlertPolicy$|Administrator$|NameAvailability$|^FlexibleServerKey$|^FlexibleServerVirtualNetworkSubnetUsage$
    hide: true

  - where:
      verb: Update$
      subject: ^FirewallRule$|^FlexibleServer$|^FlexibleServerFirewallRule$
    hide: true

  - where:
      verb: New$
      subject: ^Server$|^Configuration$|^FirewallRule$|^FlexibleServer$|^FlexibleServerFirewallRule$
    hide: true

  - where:
      verb: Update$
      subject: ^FlexibleServerDatabase$
    hide: true

  - where:
      verb: Invoke$
      subject: ^BatchFlexibleServerConfigurationUpdate$|^ExecuteGetPrivateDnsZoneSuffix$
    hide: true

  - where:
      verb: Invoke
      subject: ^ExecuteCheckNameAvailabilityWithoutLocation$
    set:
      verb: Test

  - where:
      subject: ^AdvancedThreatProtectionSetting$
    set:
      subject: FlexibleServerAdvancedThreatProtectionSetting
  - where:
      verb: Get
      subject: FlexibleServerAdvancedThreatProtectionSetting
      variant: ^Get$|^GetViaIdentity$
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
          - StorageInMb
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
      model-name: AdvancedThreatProtection
    set:
      format-table:
        properties:
          - State

  - where:
      subject: FlexibleServer
      parameter-name: ServerName
    set:
      parameter-name: Name
      alias: ServerName
  - where:
      subject: FlexibleServer
      parameter-name: SkuName
    set:
      parameter-name: Sku
  - where:
      subject: FlexibleServer
      parameter-name: AvailabilityZone
    set:
      parameter-name: Zone
  - where:
      subject: FlexibleServer
      parameter-name: StorageIop
    set:
      parameter-name: Iops

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
      subject: Server
      parameter-name: StorageProfileStorageMb
    set:
      parameter-name: StorageInMb
  - where:
      subject: Server
      parameter-name: SkuName
    set:
      parameter-name: Sku
  - where:
      subject: Server
      parameter-name: StorageProfileBackupRetentionDay
    set:
      parameter-name: BackupRetentionDay
      parameter-description: Backup retention days for the server. Day count is between 7 and 35.
  - where:
      subject: Server
      parameter-name: StorageProfileStorageAutogrow
    set:
      parameter-name: StorageAutoGrow
  - where:
      subject: Server
      parameter-name: StorageProfileGeoRedundantBackup
    set:
      parameter-name: GeoRedundantBackup

  - where:
      subject: FlexibleServerConfiguration
      parameter-name: Source
    set:
      default:
        script: '"user-override"'

  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public int BackupRetentionDay', '[System.Management.Automation.ValidateRangeAttribute(7,35)]\n        public int BackupRetentionDay');

  - no-inline:
      - ServerForCreate
      - ServerPropertiesForCreate
```
