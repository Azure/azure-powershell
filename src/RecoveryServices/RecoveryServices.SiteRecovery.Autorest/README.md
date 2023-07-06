<!-- region Generated -->
# Az.RecoveryServices
This directory contains the PowerShell module for the RecoveryServices service.

---
## Status
[![Az.RecoveryServices](https://img.shields.io/powershellgallery/v/Az.RecoveryServices.svg?style=flat-square&label=Az.RecoveryServices "Az.RecoveryServices")](https://www.powershellgallery.com/packages/Az.RecoveryServices/)

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
For information on how to develop for `Az.RecoveryServices`, see [how-to.md](how-to.md).
<!-- endregion -->

# My API 

This file contains the configuration for generating My API from the OpenAPI specification.

> see https://aka.ms/autorest

``` yaml
# it's the same options as command line options, just drop the double-dash!
branch: c94569d116a82ee11a94c5dfb190650dd675a1bf
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/stable/2023-02-01/service.json
title: RecoveryServices
directive:
  # Correct some generated models
  - no-inline:
    - PolicyProviderSpecificInput
    - FabricSpecificCreationInput
    - ReplicationProviderSpecificContainerMappingInput
    - ReplicationProviderSpecificUpdateContainerMappingInput
    - EnableProtectionProviderSpecificInput
    - UpdateReplicationProtectedItemProviderInput
    - TestFailoverProviderSpecificInput
    - UnplannedFailoverProviderSpecificInput
    - ApplyRecoveryPointProviderSpecificInput
    - ReplicationProviderSpecificSettings
  # Remove variants not in scope
  - where:
      verb: Add
      subject: ^ReplicationProtectedItemDisk$|^ReplicationProtectedItemRecoveryPoint$
      variant: ^AddViaIdentity$|^AddViaIdentityExpanded$|^ApplyViaIdentity$|^ApplyViaIdentityExpanded$
    remove: true
  - where:
      verb: Clear
      subject: ^ReplicationFabric$|^ReplicationProtectedItem$|^ReplicationProtectionContainerMapping$|^ReplicationRecoveryServicesProvider$
      variant: PurgeViaIdentity
    remove: true
  - where:
      verb: Export
      subject: ReplicationJob
      variant: ^ExportViaIdentity$|^ExportViaIdentityExpanded$
    remove: true
  - where:
      verb: Find
      subject: ReplicationProtectionContainerProtectableItem
      variant: ^DiscoverViaIdentity$|^DiscoverViaIdentityExpanded$
    remove: true
  - where:
      verb: Get
      subject: ^MigrationRecoveryPoint$|^RecoveryPoint$|^ReplicationAlertSetting$|^ReplicationEligibilityResult$|^ReplicationEvent$|^ReplicationFabric$|^ReplicationJob$|^ReplicationLogicalNetwork$|^ReplicationMigrationItem$|^ReplicationNetwork$|^ReplicationNetworkMapping$|^ReplicationPolicy$|^ReplicationProtectableItem$|^ReplicationProtectedItem$|^ReplicationProtectionContainer$|^ReplicationProtectionContainerMapping$|^ReplicationProtectionIntent$|^ReplicationRecoveryPlan$|^ReplicationRecoveryServicesProvider$|^ReplicationStorageClassification$|^ReplicationStorageClassificationMapping$|^ReplicationVaultHealth$|^ReplicationVaultSetting$|^ReplicationvCenter$|^SupportedOperatingSystem$
      variant: GetViaIdentity
    remove: true
  - where:
      verb: Invoke
      subject: ^CommitReplicationProtectedItemFailover$|^CommitReplicationRecoveryPlanFailover$|^PlannedReplicationProtectedItemFailover$|^PlannedReplicationRecoveryPlanFailover$|^RenewReplicationFabricCertificate$|^ReprotectReplicationProtectedItem$|^ReprotectReplicationRecoveryPlan$|^ResyncReplicationMigrationItem$|^UnplannedReplicationProtectedItemFailover$|^UnplannedReplicationRecoveryPlanFailover$
      variant: ^CommitViaIdentity$|^PlannedViaIdentity$|^PlannedViaIdentityExpanded$|^RenewViaIdentity$|^RenewViaIdentityExpanded$|^ReprotectViaIdentity$|^ReprotectViaIdentityExpanded$|^ResyncViaIdentity$|^ResyncViaIdentityExpanded$|^UnplannedViaIdentity$|^UnplannedViaIdentityExpanded$
    remove: true
  - where:
      verb: Move
      subject: ^ReplicationFabricGateway$|^ReplicationFabricToAad$|^ReplicationMigrationItem$
      variant: ^ReassociateViaIdentity$|^ReassociateViaIdentityExpanded$|^MigrateViaIdentity$|^MigrateViaIdentityExpanded$
    remove: true
  - where:
      verb: New
      subject: ^ReplicationAlertSetting$|^ReplicationFabric$|^ReplicationMigrationItem$|^ReplicationNetworkMapping$|^ReplicationPolicy$|^ReplicationProtectedItem$|^ReplicationProtectionContainer$|^ReplicationProtectionContainerMapping$|^ReplicationProtectionIntent$|^ReplicationRecoveryPlan$|^ReplicationRecoveryServicesProvider$|^ReplicationStorageClassificationMapping$|^ReplicationVaultSetting$|^ReplicationvCenter$
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  - where:
      verb: ^New$|^Update$
      subject: ^ReplicationPolicy$|^ReplicationFabric$|^ReplicationProtectionContainer$|^ReplicationProtectionContainerMapping$
      variant: ^Create$|^Update$
    remove: true
  - where:
      verb: ^New$|^Remove$|^Update$
      subject: ReplicationProtectedItem
      variant: ^Create$|^Delete$|^Update$
    remove: true
  - where:
      verb: Remove
      subject: ReplicationProtectionContainerMapping
      variant: Delete
    remove: true
  - where:
      verb: Clear
      subject: ReplicationProtectionContainerMapping
    remove: true
  - where:
      verb: Test
      subject: ^ReplicationProtectedItemFailover$|^ReplicationProtectedItemFailoverCleanup$
      variant: Test
    remove: true
  - where:
      verb: Invoke
      subject: UnplannedReplicationProtectedItemFailover
      variant: Unplanned
    remove: true
  - where:
      verb: Add
      subject: ReplicationProtectedItemRecoveryPoint
      variant: Apply
    remove: true
  - where:
      verb: Remove
      subject: ^ReplicationFabric$|^ReplicationMigrationItem$|^ReplicationNetworkMapping$|^ReplicationPolicy$|^ReplicationProtectedItem$|^ReplicationProtectedItemDisk$|^ReplicationProtectionContainer$|^ReplicationProtectionContainerMapping$|^ReplicationRecoveryPlan$|^ReplicationRecoveryServicesProvider$|^ReplicationStorageClassificationMapping$|^ReplicationvCenter$
      variant: ^DeleteViaIdentity$|^DeleteViaIdentityExpanded$|^RemoveViaIdentity$|^RemoveViaIdentityExpanded$
    remove: true
  - where:
      verb: Repair
      subject: ReplicationProtectedItemReplication
      variant: RepairViaIdentity
    remove: true
  - where:
      verb: Resolve
      subject: ReplicationProtectedItemHealthError
      variant: ^ResolveViaIdentity$|^ResolveViaIdentityExpanded$
    remove: true
  - where:
      verb: Restart
      subject: ReplicationJob
      variant: RestartViaIdentity
    remove: true
  - where:
      verb: Resume
      subject: ^ReplicationJob$|^ReplicationMigrationItemReplication$
      variant: ^ResumeViaIdentity$|^ResumeViaIdentityExpanded$
    remove: true
  - where:
      verb: Stop
      subject: ^ReplicationJob$|^ReplicationProtectedItemFailover$|^ReplicationRecoveryPlanFailover$
      variant: ^CancelViaIdentity$
    remove: true
  - where:
      verb: Suspend
      subject: ReplicationMigrationItemReplication
      variant: ^PauseViaIdentity$|^PauseViaIdentityExpanded$
    remove: true
  - where:
      verb: Switch
      subject: ^ReplicationProtectedItemProvider$|^ReplicationProtectionContainerProtection$
      variant: ^SwitchViaIdentity$|^SwitchViaIdentityExpanded$
    remove: true
  - where:
      verb: Test
      subject: ^ReplicationFabricConsistency$|^ReplicationMigrationItemMigrate$|^ReplicationMigrationItemMigrateCleanup$|^ReplicationProtectedItemFailover$|^ReplicationProtectedItemFailoverCleanup$|^ReplicationRecoveryPlanFailover$|^ReplicationRecoveryPlanFailoverCleanup$
      variant: ^CheckViaIdentity$|^TestViaIdentity$|^TestViaIdentityExpanded$
    remove: true
  - where:
      verb: Update
      subject: ^ReplicationMigrationItem$|^ReplicationNetworkMapping$|^ReplicationPolicy$|^ReplicationProtectedItem$|^ReplicationProtectedItemAppliance$|^ReplicationProtectedItemMobilityService$|^ReplicationProtectionContainerMapping$|^ReplicationRecoveryPlan$|^ReplicationRecoveryServicesProvider$|^ReplicationVaultHealth$|^ReplicationvCenter$
      variant: ^UpdateViaIdentity$|^UpdateViaIdentityExpanded$|^RefreshViaIdentity$
    remove: true
  # Hide some commands that require some edits
  - where:
      verb: ^Remove$|^New$|^Update$
      subject: ^ReplicationPolicy$|^ReplicationProtectionContainer$
    hide: true
  - where:
      verb: Remove
      subject: ^ReplicationFabric$|^ReplicationProtectedItem$|^ReplicationProtectionContainerMapping$
    hide: true
  - where:
      verb: ^Clear$|^New$|^Update$
      subject: ReplicationProtectionContainerMapping
    hide: true
  - where:
      verb: Get
      subject: ^ReplicationProtectionContainer$|^ReplicationProtectionContainerMapping$|^ReplicationProtectedItem$|^RecoveryPoint$
      variant: ^Get$|^List$
    hide: true
  - where:
      verb: ^New$|^Update$
      subject: ReplicationProtectedItem
    hide: true
  - where:
      verb: Test
      subject: ^ReplicationProtectedItemFailover$|^ReplicationProtectedItemFailoverCleanup$
    hide: true
  - where:
      verb: Invoke
      subject: ^UnplannedReplicationProtectedItemFailover$|^CommitReplicationProtectedItemFailover$
    hide: true
  - where:
      verb: Add
      subject: ReplicationProtectedItemRecoveryPoint
    hide: true
  - where:
      verb: New
      subject: ReplicationFabric
    hide: true
  # Rename some model properties
  - where:
      model-name: ^A2APolicyCreationInput$|^PolicyProviderSpecificInput$|^A2ACrossClusterMigrationPolicyCreationInput$|^InMagePolicyInput$|^HyperVReplicaAzurePolicyInput$|^HyperVReplicaBluePolicyInput$|^HyperVReplicaPolicyInput$|^InMageRcmFailbackPolicyCreationInput$|^InMageRcmPolicyCreationInput$|^InMageAzureV2PolicyInput$|^VMwareCbtPolicyCreationInput$|^FabricSpecificCreationInput$|^AzureFabricCreationInput$|^InMageRcmFabricCreationInput$|^VMwareV2FabricCreationInput$|^ReplicationProviderSpecificContainerCreationInput$|^A2AContainerCreationInput$|^A2ACrossClusterMigrationContainerCreationInput$|^VMwareCbtContainerCreationInput$|^ReplicationProviderSpecificContainerMappingInput$|^A2AContainerMappingInput$|^VMwareCbtContainerMappingInput$|^EnableProtectionProviderSpecificInput$|^A2ACrossClusterMigrationEnableProtectionInput$|^A2AEnableProtectionInput$|^HyperVReplicaAzureEnableProtectionInput$|^InMageAzureV2EnableProtectionInput$|^InMageEnableProtectionInput$|^InMageRcmEnableProtectionInput$|^UpdateReplicationProtectedItemProviderInput$|^A2AUpdateReplicationProtectedItemInput$|^HyperVReplicaAzureUpdateReplicationProtectedItemInput$|^InMageAzureV2UpdateReplicationProtectedItemInput$|^InMageRcmUpdateReplicationProtectedItemInput$|^TestFailoverProviderSpecificInput$|^A2ATestFailoverInput$|^HyperVReplicaAzureTestFailoverInput$|^InMageAzureV2TestFailoverInput$|^InMageRcmTestFailoverInput$|^InMageTestFailoverInput$|^UnplannedFailoverProviderSpecificInput$|^A2AUnplannedFailoverInput$|^HyperVReplicaAzureUnplannedFailoverInput$|^InMageAzureV2UnplannedFailoverInput$|^InMageRcmUnplannedFailoverInput$|^InMageUnplannedFailoverInput$|^ReplicationProviderSpecificUpdateContainerMappingInput$|^A2AUpdateContainerMappingInput$|^InMageRcmUpdateContainerMappingInput$|^ApplyRecoveryPointProviderSpecificInput$|^A2AApplyRecoveryPointInput$|^A2ACrossClusterMigrationApplyRecoveryPointInput$|^HyperVReplicaAzureApplyRecoveryPointInput$|^InMageAzureV2ApplyRecoveryPointInput$|^InMageRcmApplyRecoveryPointInput$
      property-name: InstanceType
    set:
      property-name: ReplicationScenario
```

## Alternate settings

This section is only activated if the `--make-it-rain` switch is added to the command line

``` yaml $(make-it-rain)
namespace: MyCompany.Special.Rest
```
