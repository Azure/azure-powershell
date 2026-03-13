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
  - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/stable/2021-05-01/mysql.json
  - https://github.com/Azure/azure-rest-api-specs/blob/2d973fccf9f28681a481e9760fa12b2334216e21/specification/mysql/resource-manager/Microsoft.DBforMySQL/FlexibleServers/stable/2023-12-30/AdvancedThreatProtectionSettings.json
# commit: 8dbe725fc8ce4873c0848071151de4bdf7bc0af8
# tag: package-flexibleserver-2023-12-30
# require:
#   - $(this-folder)/../../readme.azure.noprofile.md
#   - $(repo)/specification/mysql/resource-manager/Microsoft.DBforMySQL/FlexibleServers/readme.md

module-version: 0.1.0
title: MySQL
subject-prefix: 'MySQL'

directive:
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^CheckNameAvailability_Execute$/g, "NameAvailability_Test")
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^(Servers|ServerKeys)_/g, "flexible$1_")
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^(AzureADAdministrators|Configurations|Databases|FirewallRules|AdvancedThreatProtectionSettings|Replicas|LocationBasedCapabilities)_/g, "flexibleServer$1_")
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^CheckVirtualNetworkSubnetUsage_Execute$/g,"flexibleServerVirtualNetworkSubnetUsage_Get")
  - where: 
      verb: Restore$
      subject: ^FlexibleServer$
    hide: true
  - where:
      verb: Get$
      subject: ^FlexibleServerVirtualNetworkSubnetUsage$|^FlexibleServerLocationBasedCapability$|^Backup$
    hide: true
  - where:
      verb: Test
      subject: ^NameAvailability$
    hide: true

  - where:
      verb: New$|Update$
      subject: ^FlexibleServer$|^FlexibleServerFirewallRule$
    hide: true
  - where:
      verb: Update$
      subject: ^FlexibleServerConfiguration$|^flexibleServerDatabase$
    hide: true
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: Invoke$
      subject: ^BatchFlexibleServerConfigurationUpdate$|^ExecuteGetPrivateDnsZoneSuffix$
    hide: true
  - where:
      verb: Get
      subject: FlexibleServerAdvancedThreatProtectionSetting
      variant: ^List$|^GetViaIdentity$
    remove: true
  - where:
      model-name: AdvancedThreatProtection
    set:
      format-table:
        properties:
          - State

  - where:
      model-name: Server
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
      model-name: FirewallRule
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
    transform: $ = $.replace('public int StorageProfileBackupRetentionDay', '[System.Management.Automation.ValidateRangeAttribute(7,35)]\n        public int StorageProfileBackupRetentionDay');
  - where:
      verb: Get|New|Update|Remove|Restart|Start|Stop
      subject: ^FlexibleServer
    set:
      preview-announcement:
        preview-message: "*****************************************************************************************\\r\\n* This cmdlet will undergo a breaking change in Az v15.0.0, to be released in May 2026. *\\r\\n* At least one change applies to this cmdlet.                                                     *\\r\\n* See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *\\r\\n**************************************************************************************************"
  - where:
      verb: Get|New|Update|Remove|Restart|Restore
      subject: ^Configuration$|^FirewallRule$|^Replica$|^Server$|^VirtualNetworkRule$|ServerConfigurationsList
    set:
      breaking-change:
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 16.0.0
        change-effective-date: 2026/05
```
