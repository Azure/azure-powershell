<!-- region Generated -->
# Az.Migrate
This directory contains the PowerShell module for the Migrate service.

---
## Status
[![Az.Migrate](https://img.shields.io/powershellgallery/v/Az.Migrate.svg?style=flat-square&label=Az.Migrate "Az.Migrate")](https://www.powershellgallery.com/packages/Az.Migrate/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Migrate`, see [how-to.md](how-to.md).
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
    - $(repo)/specification/migrate/resource-manager/Microsoft.OffAzure/stable/2020-01-01/migrate.json
    - $(repo)/specification/migrateprojects/resource-manager/Microsoft.Migrate/preview/2018-09-01-preview/migrate.json
    - $(repo)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/stable/2018-01-10/service.json

module-version: 0.1.0
title: Migrate 
subject-prefix: 'Migrate'

directive:
  # Correct some swagger operationIds
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_GetAll(.*)$/g, "$1_List")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Get(.*)$/g, "$1_Get")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Put(.*)$/g, "$1_CreateOrUpdate")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Patch(.*)$/g, "$1_Update")
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Refresh(.*)$/g, "$1_Refresh")
  - from: Microsoft.Migrate/preview/2018-09-01-preview/migrate.json
    where: $
    transform: return $.replace(/IEdm/g, "Iedm")
  - from: Microsoft.Migrate/preview/2018-09-01-preview/migrate.json
    where: $
    transform: return $.replace(/IServiceProvider/g, "IserviceProvider")
  - from: Microsoft.Migrate/preview/2018-09-01-preview/migrate.json
    where: $.paths..operationId
    transform: return $.replace(/^(.*)_Enumerate(.*)$/g, "$1_List")
  # Correct some generated models
  - no-inline:
    - TestMigrateProviderSpecificInput
    - MigrationProviderSpecificSettings
    - MigrateProviderSpecificInput
    - ResyncProviderSpecificInput
    - EnableMigrationProviderSpecificInput
    - UpdateMigrationItemProviderSpecificInput
    - IedmStructuredType
    - IedmNavigationProperty
    - PolicyProviderSpecificInput
    - ReplicationProviderSpecificContainerMappingInput
    - ProtectionContainerMappingProviderSpecificDetails
  # Remove variants not in scope
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Test$
      subject: ^ReplicationMigrationItemMigrate
      variant: ^TestViaIdentity$|^TestViaIdentityExpanded$|^Test$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Get$
      subject: ReplicationFabric$|ReplicationPolicy$|ReplicationProtectionContainer$|ReplicationMigrationItem$|ReplicationJob$|ReplicationProtectionContainerMapping$
      variant: ^GetViaIdentity$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Remove$
      subject: ^ReplicationMigrationItem
      variant: ^DeleteViaIdentity$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Move$
      subject: ^ReplicationMigrationItem
      variant: ^MigrateViaIdentityExpanded$|^Migrate$|^MigrateViaIdentity$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Invoke$
      subject: ^ResyncReplicationMigrationItem
      variant: ^ResyncViaIdentityExpanded$|^ResyncViaIdentity$|^Resync$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: New$
      subject: ^ReplicationMigrationItem|ReplicationProtectionContainerMapping$|ReplicationPolicy$
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Create$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Update$
      subject: ^ReplicationMigrationItem
      variant: ^UpdateViaIdentityExpanded$|^UpdateViaIdentity$|^Update$
    remove: true
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where:
      subject: ^HyperV
    remove: true
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where:
      subject: ^Job|^VCenter|^VMwareOperationsStatus
    remove: true
  - from: Microsoft.Migrate/preview/2018-09-01-preview/migrate.json
    where:
      verb: Register$
    remove: true
  - from: Microsoft.Migrate/preview/2018-09-01-preview/migrate.json
    where:
      subject: ^Database|^DatabaseInstance|^SolutionConfig|^Event
    remove: true
  # Remove cmdlets not in scope
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      subject: ^ReplicationRecovery|ReplicationEvent$|ReplicationAlertSetting$|ReplicationLogicalNetwork$|^ReplicationProtectedItem|^ReplicationNetwork|^ReplicationStorage|RecoveryPoint$|ProtectableItem$|FabricGateway$|FabricToAad$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Export$|Find$|Switch$|Clear$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      subject: ^Commit|^Planned|^Renew|^Reprotect|^Unplanned|VaultHealth$|vCenter$|ComputeSize$|FabricConsistency$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: New$|Remove$
      subject: Fabric$|ProtectionContainer$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Update$
      subject: Fabric$|Policy$|ProtectionContainer$
    remove: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Stop$|Resume$|Restart$
      subject: Job$
    remove: true
  # Hide cmldets used by custom
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Get$
      subject: ReplicationFabric$|ReplicationProtectionContainer$|ReplicationMigrationItem$|ReplicationJob$
    hide: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Test$
      subject: ^ReplicationMigrationItemMigrate
    hide: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: New$|Remove$
      subject: ^ReplicationMigrationItem
    hide: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Move$
      subject: ^ReplicationMigrationItem
    hide: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Restart$
      subject: ^ReplicationJob
    hide: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Invoke$
      subject: ^ResyncReplicationMigrationItem
    hide: true
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      verb: Update$
      subject: ^ReplicationMigrationItem
    hide: true
  # Rename verbs to friendly names.
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where:
      verb: Set$
      subject: HyperV(Cluster|Host)$|VCenter$
    set:
      verb: Update
  # Hide cmdlets not to be visible to user.
  - from: Microsoft.OffAzure/stable/2020-01-01/migrate.json
    where:
      verb: Set$
      subject: (HyperV)?Site$
    hide: true
  - where:
      verb: New$|Update$
      variant: ^(Update|Create)(?!.*?Expanded)
    hide: true
  - where:
      verb: New$
      variant: ^CreateViaIdentity
    hide: true
  - where:
      verb: New$|Set$|Update$
      subject: Site$|VCenter$
      parameter-name: Name
    clear-alias: true
  # Table output formatting
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      model-name: MigrationItem
    set:
      suppress-format: true 
  - from: Microsoft.RecoveryServices/stable/2018-01-10/service.json
    where:
      model-name: Job
    set:
      suppress-format: true
