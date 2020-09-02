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
    - $(repo)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/stable/2018-01-10/service.json

module-version: 0.1.0
title: Migrate 
subject-prefix: 'Migrate'

directive:
  # Correct some generated models
  - no-inline:
    - TestMigrateProviderSpecificInput
    - MigrationProviderSpecificSettings
    - MigrateProviderSpecificInput
    - ResyncProviderSpecificInput
    - EnableMigrationProviderSpecificInput
    - UpdateMigrationItemProviderSpecificInput
  # Remove variants not in scope
  - where:
      verb: Test$
      subject: ^ReplicationMigrationItemMigrate
      variant: ^TestViaIdentity$|^TestViaIdentityExpanded$|^Test$
    remove: true
  - where:
      verb: Get$
      subject: ReplicationFabric$|ReplicationPolicy$|ReplicationProtectionContainer$|ReplicationMigrationItem$|ReplicationJob$
      variant: ^GetViaIdentity$
    remove: true
  - where:
      verb: Remove$
      subject: ^ReplicationMigrationItem
      variant: ^DeleteViaIdentity$
    remove: true
  - where:
      verb: Move$
      subject: ^ReplicationMigrationItem
      variant: ^MigrateViaIdentityExpanded$|^Migrate$|^MigrateViaIdentity$
    remove: true
  - where:
      verb: Invoke$
      subject: ^ResyncReplicationMigrationItem
      variant: ^ResyncViaIdentityExpanded$|^ResyncViaIdentity$|^Resync$
    remove: true
  - where:
      verb: New$
      subject: ^ReplicationMigrationItem
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Create$
    remove: true
  - where:
      verb: Update$
      subject: ^ReplicationMigrationItem
      variant: ^UpdateViaIdentityExpanded$|^UpdateViaIdentity$|^Update$
    remove: true
  # Remove cmdlets not in scope
  - where:
      subject: ^ReplicationRecovery|ReplicationProtectionContainerMapping$|ReplicationEvent$|ReplicationAlertSetting$|ReplicationLogicalNetwork$|^ReplicationProtectedItem|^ReplicationNetwork|^ReplicationStorage|RecoveryPoint$|ProtectableItem$|FabricGateway$|FabricToAad$
    remove: true
  - where:
      verb: Export$|Find$|Switch$|Clear$
    remove: true
  - where:
      subject: ^Commit|^Planned|^Renew|^Reprotect|^Unplanned|VaultHealth$|vCenter$|ComputeSize$|FabricConsistency$
    remove: true
  - where:
      verb: New$|Remove$
      subject: Fabric$|Policy$|ProtectionContainer$
    remove: true
  - where:
      verb: Update$
      subject: Fabric$|Policy$|ProtectionContainer$
    remove: true
  - where:
      verb: Stop$|Resume$|Restart$
      subject: Job$
    remove: true
  # Hide cmldets used by custom
  - where:
      verb: Get$
      subject: ReplicationPolicy$|ReplicationFabric$|ReplicationProtectionContainer$|ReplicationMigrationItem$|ReplicationJob$
    hide: true
  - where:
      verb: Test$
      subject: ^ReplicationMigrationItemMigrate
    hide: true
  - where:
      verb: New$|Remove$
      subject: ^ReplicationMigrationItem
    hide: true
  - where:
      verb: Move$
      subject: ^ReplicationMigrationItem
    hide: true
  - where:
      verb: Restart$
      subject: ^ReplicationJob
    hide: true
  - where:
      verb: Invoke$
      subject: ^ResyncReplicationMigrationItem
    hide: true
  - where:
      verb: Update$
      subject: ^ReplicationMigrationItem
    hide: true
