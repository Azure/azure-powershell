---
Module Name: Az.RecoveryServices
Module Guid: cf85108a-4c89-4e06-b739-fd0910c5a866
Download Help Link: https://docs.microsoft.com/powershell/module/az.recoveryservices
Help Version: 1.0.0.0
Locale: en-US
---

# Az.RecoveryServices Module
## Description
Microsoft Azure PowerShell: RecoveryServices cmdlets

## Az.RecoveryServices Cmdlets
### [Add-AzRecoveryServicesReplicationProtectedItemDisk](Add-AzRecoveryServicesReplicationProtectedItemDisk.md)
Operation to add disks(s) to the replication protected item.

### [Clear-AzRecoveryServicesReplicationFabric](Clear-AzRecoveryServicesReplicationFabric.md)
The operation to purge(force delete) an Azure Site Recovery fabric.

### [Clear-AzRecoveryServicesReplicationProtectedItem](Clear-AzRecoveryServicesReplicationProtectedItem.md)
The operation to delete or purge a replication protected item.
This operation will force delete the replication protected item.
Use the remove operation on replication protected item to perform a clean disable replication for the item.

### [Clear-AzRecoveryServicesReplicationRecoveryServicesProvider](Clear-AzRecoveryServicesReplicationRecoveryServicesProvider.md)
The operation to purge(force delete) a recovery services provider from the vault.

### [Export-AzRecoveryServicesReplicationJob](Export-AzRecoveryServicesReplicationJob.md)
The operation to export the details of the Azure Site Recovery jobs of the vault.

### [Find-AzRecoveryServicesReplicationProtectionContainerProtectableItem](Find-AzRecoveryServicesReplicationProtectionContainerProtectableItem.md)
The operation to a add a protectable item to a protection container(Add physical server).

### [Get-AzRecoveryServicesMigrationRecoveryPoint](Get-AzRecoveryServicesMigrationRecoveryPoint.md)
Gets a recovery point for a migration item.

### [Get-AzRecoveryServicesRecoveryPoint](Get-AzRecoveryServicesRecoveryPoint.md)
Get the details of specified recovery point.

### [Get-AzRecoveryServicesReplicationAlertSetting](Get-AzRecoveryServicesReplicationAlertSetting.md)
Gets the details of the specified email notification(alert) configuration.

### [Get-AzRecoveryServicesReplicationAppliance](Get-AzRecoveryServicesReplicationAppliance.md)
Gets the list of Azure Site Recovery appliances for the vault.

### [Get-AzRecoveryServicesReplicationEligibilityResult](Get-AzRecoveryServicesReplicationEligibilityResult.md)
Validates whether a given VM can be protected or not in which case returns list of errors.

### [Get-AzRecoveryServicesReplicationEvent](Get-AzRecoveryServicesReplicationEvent.md)
The operation to get the details of an Azure Site recovery event.

### [Get-AzRecoveryServicesReplicationFabric](Get-AzRecoveryServicesReplicationFabric.md)
Gets the details of an Azure Site Recovery fabric.

### [Get-AzRecoveryServicesReplicationJob](Get-AzRecoveryServicesReplicationJob.md)
Get the details of an Azure Site Recovery job.

### [Get-AzRecoveryServicesReplicationLogicalNetwork](Get-AzRecoveryServicesReplicationLogicalNetwork.md)
Gets the details of a logical network.

### [Get-AzRecoveryServicesReplicationMigrationItem](Get-AzRecoveryServicesReplicationMigrationItem.md)
Gets the details of a migration item.

### [Get-AzRecoveryServicesReplicationNetwork](Get-AzRecoveryServicesReplicationNetwork.md)
Gets the details of a network.

### [Get-AzRecoveryServicesReplicationNetworkMapping](Get-AzRecoveryServicesReplicationNetworkMapping.md)
Gets the details of an ASR network mapping.

### [Get-AzRecoveryServicesReplicationPolicy](Get-AzRecoveryServicesReplicationPolicy.md)
Gets the details of a replication policy.

### [Get-AzRecoveryServicesReplicationProtectableItem](Get-AzRecoveryServicesReplicationProtectableItem.md)
The operation to get the details of a protectable item.

### [Get-AzRecoveryServicesReplicationProtectedItem](Get-AzRecoveryServicesReplicationProtectedItem.md)
Gets the list of ASR replication protected items in the vault.

### [Get-AzRecoveryServicesReplicationProtectionContainer](Get-AzRecoveryServicesReplicationProtectionContainer.md)
Lists the protection containers in a vault.

### [Get-AzRecoveryServicesReplicationProtectionContainerMapping](Get-AzRecoveryServicesReplicationProtectionContainerMapping.md)
Lists the protection container mappings in the vault.

### [Get-AzRecoveryServicesReplicationProtectionIntent](Get-AzRecoveryServicesReplicationProtectionIntent.md)
Gets the details of an ASR replication protection intent.

### [Get-AzRecoveryServicesReplicationRecoveryPlan](Get-AzRecoveryServicesReplicationRecoveryPlan.md)
Gets the details of the recovery plan.

### [Get-AzRecoveryServicesReplicationRecoveryServiceProvider](Get-AzRecoveryServicesReplicationRecoveryServiceProvider.md)
Lists the registered recovery services providers for the specified fabric.

### [Get-AzRecoveryServicesReplicationRecoveryServicesProvider](Get-AzRecoveryServicesReplicationRecoveryServicesProvider.md)
Gets the details of registered recovery services provider.

### [Get-AzRecoveryServicesReplicationStorageClassification](Get-AzRecoveryServicesReplicationStorageClassification.md)
Gets the details of the specified storage classification.

### [Get-AzRecoveryServicesReplicationStorageClassificationMapping](Get-AzRecoveryServicesReplicationStorageClassificationMapping.md)
Gets the details of the specified storage classification mapping.

### [Get-AzRecoveryServicesReplicationVaultHealth](Get-AzRecoveryServicesReplicationVaultHealth.md)
Gets the health details of the vault.

### [Get-AzRecoveryServicesReplicationVaultSetting](Get-AzRecoveryServicesReplicationVaultSetting.md)
Gets the vault setting.
This includes the Migration Hub connection settings.

### [Get-AzRecoveryServicesReplicationvCenter](Get-AzRecoveryServicesReplicationvCenter.md)
Gets the details of a registered vCenter server(Add vCenter server).

### [Get-AzRecoveryServicesSupportedOperatingSystem](Get-AzRecoveryServicesSupportedOperatingSystem.md)
Gets the data of supported operating systems by SRS.

### [Get-AzRecoveryServicesTargetComputeSize](Get-AzRecoveryServicesTargetComputeSize.md)
Lists the available target compute sizes for a replication protected item.

### [Invoke-AzRecoveryServicesCommitReplicationProtectedItemFailover](Invoke-AzRecoveryServicesCommitReplicationProtectedItemFailover.md)
Operation to commit the failover of the replication protected item.

### [Invoke-AzRecoveryServicesCommitReplicationRecoveryPlanFailover](Invoke-AzRecoveryServicesCommitReplicationRecoveryPlanFailover.md)
The operation to commit the failover of a recovery plan.

### [Invoke-AzRecoveryServicesPlannedReplicationProtectedItemFailover](Invoke-AzRecoveryServicesPlannedReplicationProtectedItemFailover.md)
Operation to initiate a planned failover of the replication protected item.

### [Invoke-AzRecoveryServicesPlannedReplicationRecoveryPlanFailover](Invoke-AzRecoveryServicesPlannedReplicationRecoveryPlanFailover.md)
The operation to start the planned failover of a recovery plan.

### [Invoke-AzRecoveryServicesRenewReplicationFabricCertificate](Invoke-AzRecoveryServicesRenewReplicationFabricCertificate.md)
Renews the connection certificate for the ASR replication fabric.

### [Invoke-AzRecoveryServicesReplicationProtectedItemApplyRecoveryPoint](Invoke-AzRecoveryServicesReplicationProtectedItemApplyRecoveryPoint.md)
The operation to change the recovery point of a failed over replication protected item.

### [Invoke-AzRecoveryServicesReprotectReplicationProtectedItem](Invoke-AzRecoveryServicesReprotectReplicationProtectedItem.md)
Operation to reprotect or reverse replicate a failed over replication protected item.

### [Invoke-AzRecoveryServicesReprotectReplicationRecoveryPlan](Invoke-AzRecoveryServicesReprotectReplicationRecoveryPlan.md)
The operation to reprotect(reverse replicate) a recovery plan.

### [Invoke-AzRecoveryServicesResyncReplicationMigrationItem](Invoke-AzRecoveryServicesResyncReplicationMigrationItem.md)
The operation to resynchronize replication of an ASR migration item.

### [Invoke-AzRecoveryServicesUnplannedReplicationProtectedItemFailover](Invoke-AzRecoveryServicesUnplannedReplicationProtectedItemFailover.md)
Operation to initiate a failover of the replication protected item.

### [Invoke-AzRecoveryServicesUnplannedReplicationRecoveryPlanFailover](Invoke-AzRecoveryServicesUnplannedReplicationRecoveryPlanFailover.md)
The operation to start the unplanned failover of a recovery plan.

### [Move-AzRecoveryServicesReplicationFabricGateway](Move-AzRecoveryServicesReplicationFabricGateway.md)
The operation to move replications from a process server to another process server.

### [Move-AzRecoveryServicesReplicationFabricToAad](Move-AzRecoveryServicesReplicationFabricToAad.md)
The operation to migrate an Azure Site Recovery fabric to AAD.

### [Move-AzRecoveryServicesReplicationMigrationItem](Move-AzRecoveryServicesReplicationMigrationItem.md)
The operation to initiate migration of the item.

### [New-AzRecoveryServicesReplicationAlertSetting](New-AzRecoveryServicesReplicationAlertSetting.md)
Create or update an email notification(alert) configuration.

### [New-AzRecoveryServicesReplicationFabric](New-AzRecoveryServicesReplicationFabric.md)
The operation to create an Azure Site Recovery fabric (for e.g.
Hyper-V site).

### [New-AzRecoveryServicesReplicationMigrationItem](New-AzRecoveryServicesReplicationMigrationItem.md)
The operation to create an ASR migration item (enable migration).

### [New-AzRecoveryServicesReplicationNetworkMapping](New-AzRecoveryServicesReplicationNetworkMapping.md)
The operation to create an ASR network mapping.

### [New-AzRecoveryServicesReplicationPolicy](New-AzRecoveryServicesReplicationPolicy.md)


### [New-AzRecoveryServicesReplicationProtectedItem](New-AzRecoveryServicesReplicationProtectedItem.md)
The operation to create an ASR replication protected item (Enable replication).

### [New-AzRecoveryServicesReplicationProtectionContainer](New-AzRecoveryServicesReplicationProtectionContainer.md)
Operation to create a protection container.

### [New-AzRecoveryServicesReplicationProtectionContainerMapping](New-AzRecoveryServicesReplicationProtectionContainerMapping.md)
The operation to create a protection container mapping.

### [New-AzRecoveryServicesReplicationProtectionIntent](New-AzRecoveryServicesReplicationProtectionIntent.md)
The operation to create an ASR replication protection intent item.

### [New-AzRecoveryServicesReplicationRecoveryPlan](New-AzRecoveryServicesReplicationRecoveryPlan.md)
The operation to create a recovery plan.

### [New-AzRecoveryServicesReplicationRecoveryServicesProvider](New-AzRecoveryServicesReplicationRecoveryServicesProvider.md)
The operation to add a recovery services provider.

### [New-AzRecoveryServicesReplicationStorageClassificationMapping](New-AzRecoveryServicesReplicationStorageClassificationMapping.md)
The operation to create a storage classification mapping.

### [New-AzRecoveryServicesReplicationVaultSetting](New-AzRecoveryServicesReplicationVaultSetting.md)
The operation to configure vault setting.

### [New-AzRecoveryServicesReplicationvCenter](New-AzRecoveryServicesReplicationvCenter.md)
The operation to create a vCenter object..

### [New-AzRecoveryServicesReplicationVmNicConfig](New-AzRecoveryServicesReplicationVmNicConfig.md)


### [New-AzRecoveryServicesReplicationVmNicIPConfig](New-AzRecoveryServicesReplicationVmNicIPConfig.md)


### [Remove-AzRecoveryServicesReplicationFabric](Remove-AzRecoveryServicesReplicationFabric.md)
The operation to delete or remove an Azure Site Recovery fabric.

### [Remove-AzRecoveryServicesReplicationMigrationItem](Remove-AzRecoveryServicesReplicationMigrationItem.md)
The operation to delete an ASR migration item.

### [Remove-AzRecoveryServicesReplicationNetworkMapping](Remove-AzRecoveryServicesReplicationNetworkMapping.md)
The operation to delete a network mapping.

### [Remove-AzRecoveryServicesReplicationPolicy](Remove-AzRecoveryServicesReplicationPolicy.md)
Removes a given replication policy in a given recovery services vault

### [Remove-AzRecoveryServicesReplicationProtectedItem](Remove-AzRecoveryServicesReplicationProtectedItem.md)
The operation to disable replication on a replication protected item.
This will also remove the item.

### [Remove-AzRecoveryServicesReplicationProtectedItemDisk](Remove-AzRecoveryServicesReplicationProtectedItemDisk.md)
Operation to remove disk(s) from the replication protected item.

### [Remove-AzRecoveryServicesReplicationProtectionContainer](Remove-AzRecoveryServicesReplicationProtectionContainer.md)
Operation to remove a protection container.

### [Remove-AzRecoveryServicesReplicationProtectionContainerMapping](Remove-AzRecoveryServicesReplicationProtectionContainerMapping.md)
The operation to delete or remove a protection container mapping.

### [Remove-AzRecoveryServicesReplicationRecoveryPlan](Remove-AzRecoveryServicesReplicationRecoveryPlan.md)
Delete a recovery plan.

### [Remove-AzRecoveryServicesReplicationRecoveryServicesProvider](Remove-AzRecoveryServicesReplicationRecoveryServicesProvider.md)
The operation to removes/delete(unregister) a recovery services provider from the vault.

### [Remove-AzRecoveryServicesReplicationStorageClassificationMapping](Remove-AzRecoveryServicesReplicationStorageClassificationMapping.md)
The operation to delete a storage classification mapping.

### [Remove-AzRecoveryServicesReplicationvCenter](Remove-AzRecoveryServicesReplicationvCenter.md)
The operation to remove(unregister) a registered vCenter server from the vault.

### [Repair-AzRecoveryServicesReplicationProtectedItemReplication](Repair-AzRecoveryServicesReplicationProtectedItemReplication.md)
The operation to start resynchronize/repair replication for a replication protected item requiring resynchronization.

### [Resolve-AzRecoveryServicesReplicationProtectedItemHealthError](Resolve-AzRecoveryServicesReplicationProtectedItemHealthError.md)
Operation to resolve health issues of the replication protected item.

### [Restart-AzRecoveryServicesReplicationJob](Restart-AzRecoveryServicesReplicationJob.md)
The operation to restart an Azure Site Recovery job.

### [Resume-AzRecoveryServicesReplicationJob](Resume-AzRecoveryServicesReplicationJob.md)
The operation to resume an Azure Site Recovery job.

### [Resume-AzRecoveryServicesReplicationMigrationItemReplication](Resume-AzRecoveryServicesReplicationMigrationItemReplication.md)
The operation to initiate resume replication of the item.

### [Stop-AzRecoveryServicesReplicationJob](Stop-AzRecoveryServicesReplicationJob.md)
The operation to cancel an Azure Site Recovery job.

### [Stop-AzRecoveryServicesReplicationProtectedItemFailover](Stop-AzRecoveryServicesReplicationProtectedItemFailover.md)
Operation to cancel the failover of the replication protected item.

### [Stop-AzRecoveryServicesReplicationRecoveryPlanFailover](Stop-AzRecoveryServicesReplicationRecoveryPlanFailover.md)
The operation to cancel the failover of a recovery plan.

### [Suspend-AzRecoveryServicesReplicationMigrationItemReplication](Suspend-AzRecoveryServicesReplicationMigrationItemReplication.md)
The operation to initiate pause replication of the item.

### [Switch-AzRecoveryServicesReplicationProtectedItemProvider](Switch-AzRecoveryServicesReplicationProtectedItemProvider.md)
Operation to initiate a switch provider of the replication protected item.

### [Switch-AzRecoveryServicesReplicationProtectionContainerProtection](Switch-AzRecoveryServicesReplicationProtectionContainerProtection.md)
Operation to switch protection from one container to another or one replication provider to another.

### [Test-AzRecoveryServicesReplicationFabricConsistency](Test-AzRecoveryServicesReplicationFabricConsistency.md)
The operation to perform a consistency check on the fabric.

### [Test-AzRecoveryServicesReplicationMigrationItemMigrate](Test-AzRecoveryServicesReplicationMigrationItemMigrate.md)
The operation to initiate test migration of the item.

### [Test-AzRecoveryServicesReplicationMigrationItemMigrateCleanup](Test-AzRecoveryServicesReplicationMigrationItemMigrateCleanup.md)
The operation to initiate test migrate cleanup.

### [Test-AzRecoveryServicesReplicationProtectedItemFailover](Test-AzRecoveryServicesReplicationProtectedItemFailover.md)
Operation to perform a test failover of the replication protected item.

### [Test-AzRecoveryServicesReplicationProtectedItemFailoverCleanup](Test-AzRecoveryServicesReplicationProtectedItemFailoverCleanup.md)
Operation to clean up the test failover of a replication protected item.

### [Test-AzRecoveryServicesReplicationRecoveryPlanFailover](Test-AzRecoveryServicesReplicationRecoveryPlanFailover.md)
The operation to start the test failover of a recovery plan.

### [Test-AzRecoveryServicesReplicationRecoveryPlanFailoverCleanup](Test-AzRecoveryServicesReplicationRecoveryPlanFailoverCleanup.md)
The operation to cleanup test failover of a recovery plan.

### [Update-AzRecoveryServicesReplicationMigrationItem](Update-AzRecoveryServicesReplicationMigrationItem.md)
The operation to update the recovery settings of an ASR migration item.

### [Update-AzRecoveryServicesReplicationNetworkMapping](Update-AzRecoveryServicesReplicationNetworkMapping.md)
The operation to update an ASR network mapping.

### [Update-AzRecoveryServicesReplicationPolicy](Update-AzRecoveryServicesReplicationPolicy.md)
The operation to update a replication policy.

### [Update-AzRecoveryServicesReplicationProtectedItem](Update-AzRecoveryServicesReplicationProtectedItem.md)
The operation to update the recovery settings of an ASR replication protected item.

### [Update-AzRecoveryServicesReplicationProtectedItemAppliance](Update-AzRecoveryServicesReplicationProtectedItemAppliance.md)
The operation to update appliance of an ASR replication protected item.

### [Update-AzRecoveryServicesReplicationProtectedItemMobilityService](Update-AzRecoveryServicesReplicationProtectedItemMobilityService.md)
The operation to update(push update) the installed mobility service software on a replication protected item to the latest available version.

### [Update-AzRecoveryServicesReplicationProtectionContainerMapping](Update-AzRecoveryServicesReplicationProtectionContainerMapping.md)
The operation to update protection container mapping.

### [Update-AzRecoveryServicesReplicationRecoveryPlan](Update-AzRecoveryServicesReplicationRecoveryPlan.md)
The operation to update a recovery plan.

### [Update-AzRecoveryServicesReplicationRecoveryServiceProvider](Update-AzRecoveryServicesReplicationRecoveryServiceProvider.md)
The operation to refresh the information from the recovery services provider.

### [Update-AzRecoveryServicesReplicationVaultHealth](Update-AzRecoveryServicesReplicationVaultHealth.md)
Refreshes health summary of the vault.

### [Update-AzRecoveryServicesReplicationvCenter](Update-AzRecoveryServicesReplicationvCenter.md)
The operation to update a registered vCenter.

