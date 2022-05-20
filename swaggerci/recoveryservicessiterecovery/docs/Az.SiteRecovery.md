---
Module Name: Az.SiteRecovery
Module Guid: 4c56951c-3807-4314-9c4b-57e2b665afe1
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.siterecovery
Help Version: 1.0.0.0
Locale: en-US
---

# Az.SiteRecovery Module
## Description
Microsoft Azure PowerShell: SiteRecovery cmdlets

## Az.SiteRecovery Cmdlets
### [Add-AzSiteRecoveryReplicationProtectedItemDisk](Add-AzSiteRecoveryReplicationProtectedItemDisk.md)
Operation to add disks(s) to the replication protected item.

### [Add-AzSiteRecoveryReplicationProtectedItemRecoveryPoint](Add-AzSiteRecoveryReplicationProtectedItemRecoveryPoint.md)
The operation to change the recovery point of a failed over replication protected item.

### [Clear-AzSiteRecoveryReplicationFabric](Clear-AzSiteRecoveryReplicationFabric.md)
The operation to purge(force delete) an Azure Site Recovery fabric.

### [Clear-AzSiteRecoveryReplicationProtectedItem](Clear-AzSiteRecoveryReplicationProtectedItem.md)
The operation to delete or purge a replication protected item.
This operation will force delete the replication protected item.
Use the remove operation on replication protected item to perform a clean disable replication for the item.

### [Clear-AzSiteRecoveryReplicationProtectionContainerMapping](Clear-AzSiteRecoveryReplicationProtectionContainerMapping.md)
The operation to purge(force delete) a protection container mapping.

### [Clear-AzSiteRecoveryReplicationRecoveryServicesProvider](Clear-AzSiteRecoveryReplicationRecoveryServicesProvider.md)
The operation to purge(force delete) a recovery services provider from the vault.

### [Export-AzSiteRecoveryReplicationJob](Export-AzSiteRecoveryReplicationJob.md)
The operation to export the details of the Azure Site Recovery jobs of the vault.

### [Find-AzSiteRecoveryReplicationProtectionContainerProtectableItem](Find-AzSiteRecoveryReplicationProtectionContainerProtectableItem.md)
The operation to a add a protectable item to a protection container(Add physical server).

### [Get-AzSiteRecoveryMigrationRecoveryPoint](Get-AzSiteRecoveryMigrationRecoveryPoint.md)
Gets a recovery point for a migration item.

### [Get-AzSiteRecoveryPoint](Get-AzSiteRecoveryPoint.md)
Get the details of specified recovery point.

### [Get-AzSiteRecoveryReplicationAlertSetting](Get-AzSiteRecoveryReplicationAlertSetting.md)
Gets the details of the specified email notification(alert) configuration.

### [Get-AzSiteRecoveryReplicationAppliance](Get-AzSiteRecoveryReplicationAppliance.md)
Gets the list of Azure Site Recovery appliances for the vault.

### [Get-AzSiteRecoveryReplicationEligibilityResult](Get-AzSiteRecoveryReplicationEligibilityResult.md)
Validates whether a given VM can be protected or not in which case returns list of errors.

### [Get-AzSiteRecoveryReplicationEvent](Get-AzSiteRecoveryReplicationEvent.md)
The operation to get the details of an Azure Site recovery event.

### [Get-AzSiteRecoveryReplicationFabric](Get-AzSiteRecoveryReplicationFabric.md)
Gets the details of an Azure Site Recovery fabric.

### [Get-AzSiteRecoveryReplicationJob](Get-AzSiteRecoveryReplicationJob.md)
Get the details of an Azure Site Recovery job.

### [Get-AzSiteRecoveryReplicationLogicalNetwork](Get-AzSiteRecoveryReplicationLogicalNetwork.md)
Gets the details of a logical network.

### [Get-AzSiteRecoveryReplicationMigrationItem](Get-AzSiteRecoveryReplicationMigrationItem.md)
Gets the details of a migration item.

### [Get-AzSiteRecoveryReplicationNetwork](Get-AzSiteRecoveryReplicationNetwork.md)
Gets the details of a network.

### [Get-AzSiteRecoveryReplicationNetworkMapping](Get-AzSiteRecoveryReplicationNetworkMapping.md)
Gets the details of an ASR network mapping.

### [Get-AzSiteRecoveryReplicationPolicy](Get-AzSiteRecoveryReplicationPolicy.md)
Gets the details of a replication policy.

### [Get-AzSiteRecoveryReplicationProtectableItem](Get-AzSiteRecoveryReplicationProtectableItem.md)
The operation to get the details of a protectable item.

### [Get-AzSiteRecoveryReplicationProtectedItem](Get-AzSiteRecoveryReplicationProtectedItem.md)
Gets the details of an ASR replication protected item.

### [Get-AzSiteRecoveryReplicationProtectionContainer](Get-AzSiteRecoveryReplicationProtectionContainer.md)
Gets the details of a protection container.

### [Get-AzSiteRecoveryReplicationProtectionContainerMapping](Get-AzSiteRecoveryReplicationProtectionContainerMapping.md)
Gets the details of a protection container mapping.

### [Get-AzSiteRecoveryReplicationProtectionIntent](Get-AzSiteRecoveryReplicationProtectionIntent.md)
Gets the details of an ASR replication protection intent.

### [Get-AzSiteRecoveryReplicationRecoveryPlan](Get-AzSiteRecoveryReplicationRecoveryPlan.md)
Gets the details of the recovery plan.

### [Get-AzSiteRecoveryReplicationRecoveryServiceProvider](Get-AzSiteRecoveryReplicationRecoveryServiceProvider.md)
Lists the registered recovery services providers for the specified fabric.

### [Get-AzSiteRecoveryReplicationRecoveryServicesProvider](Get-AzSiteRecoveryReplicationRecoveryServicesProvider.md)
Gets the details of registered recovery services provider.

### [Get-AzSiteRecoveryReplicationStorageClassification](Get-AzSiteRecoveryReplicationStorageClassification.md)
Gets the details of the specified storage classification.

### [Get-AzSiteRecoveryReplicationStorageClassificationMapping](Get-AzSiteRecoveryReplicationStorageClassificationMapping.md)
Gets the details of the specified storage classification mapping.

### [Get-AzSiteRecoveryReplicationVaultHealth](Get-AzSiteRecoveryReplicationVaultHealth.md)
Gets the health details of the vault.

### [Get-AzSiteRecoveryReplicationVaultSetting](Get-AzSiteRecoveryReplicationVaultSetting.md)
Gets the vault setting.
This includes the Migration Hub connection settings.

### [Get-AzSiteRecoveryReplicationvCenter](Get-AzSiteRecoveryReplicationvCenter.md)
Gets the details of a registered vCenter server(Add vCenter server).

### [Get-AzSiteRecoverySupportedOperatingSystem](Get-AzSiteRecoverySupportedOperatingSystem.md)
Gets the data of supported operating systems by SRS.

### [Get-AzSiteRecoveryTargetComputeSize](Get-AzSiteRecoveryTargetComputeSize.md)
Lists the available target compute sizes for a replication protected item.

### [Invoke-AzSiteRecoveryCommitReplicationProtectedItemFailover](Invoke-AzSiteRecoveryCommitReplicationProtectedItemFailover.md)
Operation to commit the failover of the replication protected item.

### [Invoke-AzSiteRecoveryCommitReplicationRecoveryPlanFailover](Invoke-AzSiteRecoveryCommitReplicationRecoveryPlanFailover.md)
The operation to commit the failover of a recovery plan.

### [Invoke-AzSiteRecoveryPlannedReplicationProtectedItemFailover](Invoke-AzSiteRecoveryPlannedReplicationProtectedItemFailover.md)
Operation to initiate a planned failover of the replication protected item.

### [Invoke-AzSiteRecoveryPlannedReplicationRecoveryPlanFailover](Invoke-AzSiteRecoveryPlannedReplicationRecoveryPlanFailover.md)
The operation to start the planned failover of a recovery plan.

### [Invoke-AzSiteRecoveryRenewReplicationFabricCertificate](Invoke-AzSiteRecoveryRenewReplicationFabricCertificate.md)
Renews the connection certificate for the ASR replication fabric.

### [Invoke-AzSiteRecoveryReprotectReplicationProtectedItem](Invoke-AzSiteRecoveryReprotectReplicationProtectedItem.md)
Operation to reprotect or reverse replicate a failed over replication protected item.

### [Invoke-AzSiteRecoveryReprotectReplicationRecoveryPlan](Invoke-AzSiteRecoveryReprotectReplicationRecoveryPlan.md)
The operation to reprotect(reverse replicate) a recovery plan.

### [Invoke-AzSiteRecoveryResyncReplicationMigrationItem](Invoke-AzSiteRecoveryResyncReplicationMigrationItem.md)
The operation to resynchronize replication of an ASR migration item.

### [Invoke-AzSiteRecoveryUnplannedReplicationProtectedItemFailover](Invoke-AzSiteRecoveryUnplannedReplicationProtectedItemFailover.md)
Operation to initiate a failover of the replication protected item.

### [Invoke-AzSiteRecoveryUnplannedReplicationRecoveryPlanFailover](Invoke-AzSiteRecoveryUnplannedReplicationRecoveryPlanFailover.md)
The operation to start the unplanned failover of a recovery plan.

### [Move-AzSiteRecoveryReplicationFabricGateway](Move-AzSiteRecoveryReplicationFabricGateway.md)
The operation to move replications from a process server to another process server.

### [Move-AzSiteRecoveryReplicationFabricToAad](Move-AzSiteRecoveryReplicationFabricToAad.md)
The operation to migrate an Azure Site Recovery fabric to AAD.

### [Move-AzSiteRecoveryReplicationMigrationItem](Move-AzSiteRecoveryReplicationMigrationItem.md)
The operation to initiate migration of the item.

### [New-AzSiteRecoveryReplicationAlertSetting](New-AzSiteRecoveryReplicationAlertSetting.md)
Create or update an email notification(alert) configuration.

### [New-AzSiteRecoveryReplicationFabric](New-AzSiteRecoveryReplicationFabric.md)
The operation to create an Azure Site Recovery fabric (for e.g.
Hyper-V site).

### [New-AzSiteRecoveryReplicationMigrationItem](New-AzSiteRecoveryReplicationMigrationItem.md)
The operation to create an ASR migration item (enable migration).

### [New-AzSiteRecoveryReplicationNetworkMapping](New-AzSiteRecoveryReplicationNetworkMapping.md)
The operation to create an ASR network mapping.

### [New-AzSiteRecoveryReplicationPolicy](New-AzSiteRecoveryReplicationPolicy.md)
The operation to create a replication policy.

### [New-AzSiteRecoveryReplicationProtectedItem](New-AzSiteRecoveryReplicationProtectedItem.md)
The operation to create an ASR replication protected item (Enable replication).

### [New-AzSiteRecoveryReplicationProtectionContainer](New-AzSiteRecoveryReplicationProtectionContainer.md)
Operation to create a protection container.

### [New-AzSiteRecoveryReplicationProtectionContainerMapping](New-AzSiteRecoveryReplicationProtectionContainerMapping.md)
The operation to create a protection container mapping.

### [New-AzSiteRecoveryReplicationProtectionIntent](New-AzSiteRecoveryReplicationProtectionIntent.md)
The operation to create an ASR replication protection intent item.

### [New-AzSiteRecoveryReplicationRecoveryPlan](New-AzSiteRecoveryReplicationRecoveryPlan.md)
The operation to create a recovery plan.

### [New-AzSiteRecoveryReplicationRecoveryServicesProvider](New-AzSiteRecoveryReplicationRecoveryServicesProvider.md)
The operation to add a recovery services provider.

### [New-AzSiteRecoveryReplicationStorageClassificationMapping](New-AzSiteRecoveryReplicationStorageClassificationMapping.md)
The operation to create a storage classification mapping.

### [New-AzSiteRecoveryReplicationVaultSetting](New-AzSiteRecoveryReplicationVaultSetting.md)
The operation to configure vault setting.

### [New-AzSiteRecoveryReplicationvCenter](New-AzSiteRecoveryReplicationvCenter.md)
The operation to create a vCenter object..

### [Remove-AzSiteRecoveryReplicationFabric](Remove-AzSiteRecoveryReplicationFabric.md)
The operation to delete or remove an Azure Site Recovery fabric.

### [Remove-AzSiteRecoveryReplicationMigrationItem](Remove-AzSiteRecoveryReplicationMigrationItem.md)
The operation to delete an ASR migration item.

### [Remove-AzSiteRecoveryReplicationNetworkMapping](Remove-AzSiteRecoveryReplicationNetworkMapping.md)
The operation to delete a network mapping.

### [Remove-AzSiteRecoveryReplicationPolicy](Remove-AzSiteRecoveryReplicationPolicy.md)
The operation to delete a replication policy.

### [Remove-AzSiteRecoveryReplicationProtectedItem](Remove-AzSiteRecoveryReplicationProtectedItem.md)
The operation to disable replication on a replication protected item.
This will also remove the item.

### [Remove-AzSiteRecoveryReplicationProtectedItemDisk](Remove-AzSiteRecoveryReplicationProtectedItemDisk.md)
Operation to remove disk(s) from the replication protected item.

### [Remove-AzSiteRecoveryReplicationProtectionContainer](Remove-AzSiteRecoveryReplicationProtectionContainer.md)
Operation to remove a protection container.

### [Remove-AzSiteRecoveryReplicationProtectionContainerMapping](Remove-AzSiteRecoveryReplicationProtectionContainerMapping.md)
The operation to delete or remove a protection container mapping.

### [Remove-AzSiteRecoveryReplicationRecoveryPlan](Remove-AzSiteRecoveryReplicationRecoveryPlan.md)
Delete a recovery plan.

### [Remove-AzSiteRecoveryReplicationRecoveryServicesProvider](Remove-AzSiteRecoveryReplicationRecoveryServicesProvider.md)
The operation to removes/delete(unregister) a recovery services provider from the vault.

### [Remove-AzSiteRecoveryReplicationStorageClassificationMapping](Remove-AzSiteRecoveryReplicationStorageClassificationMapping.md)
The operation to delete a storage classification mapping.

### [Remove-AzSiteRecoveryReplicationvCenter](Remove-AzSiteRecoveryReplicationvCenter.md)
The operation to remove(unregister) a registered vCenter server from the vault.

### [Repair-AzSiteRecoveryReplicationProtectedItemReplication](Repair-AzSiteRecoveryReplicationProtectedItemReplication.md)
The operation to start resynchronize/repair replication for a replication protected item requiring resynchronization.

### [Resolve-AzSiteRecoveryReplicationProtectedItemHealthError](Resolve-AzSiteRecoveryReplicationProtectedItemHealthError.md)
Operation to resolve health issues of the replication protected item.

### [Restart-AzSiteRecoveryReplicationJob](Restart-AzSiteRecoveryReplicationJob.md)
The operation to restart an Azure Site Recovery job.

### [Resume-AzSiteRecoveryReplicationJob](Resume-AzSiteRecoveryReplicationJob.md)
The operation to resume an Azure Site Recovery job.

### [Stop-AzSiteRecoveryReplicationJob](Stop-AzSiteRecoveryReplicationJob.md)
The operation to cancel an Azure Site Recovery job.

### [Stop-AzSiteRecoveryReplicationProtectedItemFailover](Stop-AzSiteRecoveryReplicationProtectedItemFailover.md)
Operation to cancel the failover of the replication protected item.

### [Stop-AzSiteRecoveryReplicationRecoveryPlanFailover](Stop-AzSiteRecoveryReplicationRecoveryPlanFailover.md)
The operation to cancel the failover of a recovery plan.

### [Switch-AzSiteRecoveryReplicationProtectedItemProvider](Switch-AzSiteRecoveryReplicationProtectedItemProvider.md)
Operation to initiate a switch provider of the replication protected item.

### [Switch-AzSiteRecoveryReplicationProtectionContainerProtection](Switch-AzSiteRecoveryReplicationProtectionContainerProtection.md)
Operation to switch protection from one container to another or one replication provider to another.

### [Test-AzSiteRecoveryReplicationFabricConsistency](Test-AzSiteRecoveryReplicationFabricConsistency.md)
The operation to perform a consistency check on the fabric.

### [Test-AzSiteRecoveryReplicationMigrationItemMigrate](Test-AzSiteRecoveryReplicationMigrationItemMigrate.md)
The operation to initiate test migration of the item.

### [Test-AzSiteRecoveryReplicationMigrationItemMigrateCleanup](Test-AzSiteRecoveryReplicationMigrationItemMigrateCleanup.md)
The operation to initiate test migrate cleanup.

### [Test-AzSiteRecoveryReplicationProtectedItemFailover](Test-AzSiteRecoveryReplicationProtectedItemFailover.md)
Operation to perform a test failover of the replication protected item.

### [Test-AzSiteRecoveryReplicationProtectedItemFailoverCleanup](Test-AzSiteRecoveryReplicationProtectedItemFailoverCleanup.md)
Operation to clean up the test failover of a replication protected item.

### [Test-AzSiteRecoveryReplicationRecoveryPlanFailover](Test-AzSiteRecoveryReplicationRecoveryPlanFailover.md)
The operation to start the test failover of a recovery plan.

### [Test-AzSiteRecoveryReplicationRecoveryPlanFailoverCleanup](Test-AzSiteRecoveryReplicationRecoveryPlanFailoverCleanup.md)
The operation to cleanup test failover of a recovery plan.

### [Update-AzSiteRecoveryReplicationMigrationItem](Update-AzSiteRecoveryReplicationMigrationItem.md)
The operation to update the recovery settings of an ASR migration item.

### [Update-AzSiteRecoveryReplicationNetworkMapping](Update-AzSiteRecoveryReplicationNetworkMapping.md)
The operation to update an ASR network mapping.

### [Update-AzSiteRecoveryReplicationPolicy](Update-AzSiteRecoveryReplicationPolicy.md)
The operation to update a replication policy.

### [Update-AzSiteRecoveryReplicationProtectedItem](Update-AzSiteRecoveryReplicationProtectedItem.md)
The operation to update the recovery settings of an ASR replication protected item.

### [Update-AzSiteRecoveryReplicationProtectedItemAppliance](Update-AzSiteRecoveryReplicationProtectedItemAppliance.md)
The operation to update appliance of an ASR replication protected item.

### [Update-AzSiteRecoveryReplicationProtectedItemMobilityService](Update-AzSiteRecoveryReplicationProtectedItemMobilityService.md)
The operation to update(push update) the installed mobility service software on a replication protected item to the latest available version.

### [Update-AzSiteRecoveryReplicationProtectionContainerMapping](Update-AzSiteRecoveryReplicationProtectionContainerMapping.md)
The operation to update protection container mapping.

### [Update-AzSiteRecoveryReplicationRecoveryPlan](Update-AzSiteRecoveryReplicationRecoveryPlan.md)
The operation to update a recovery plan.

### [Update-AzSiteRecoveryReplicationRecoveryServiceProvider](Update-AzSiteRecoveryReplicationRecoveryServiceProvider.md)
The operation to refresh the information from the recovery services provider.

### [Update-AzSiteRecoveryReplicationVaultHealth](Update-AzSiteRecoveryReplicationVaultHealth.md)
Refreshes health summary of the vault.

### [Update-AzSiteRecoveryReplicationvCenter](Update-AzSiteRecoveryReplicationvCenter.md)
The operation to update a registered vCenter.

