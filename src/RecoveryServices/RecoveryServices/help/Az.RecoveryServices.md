---
Module Name: Az.RecoveryServices
Module Guid: 4aa53b7e-fcfe-4e22-979c-9a4e6380de58
Download Help Link: https://docs.microsoft.com/powershell/module/az.recoveryservices
Help Version: 4.1.2.0
Locale: en-US
---

# Az.RecoveryServices Module
## Description
This topic displays help topics for the Azure Recovery Services cmdlets.

## Az.RecoveryServices Cmdlets
### [Add-AzRecoveryServicesAsrReplicationProtectedItemDisk](Add-AzRecoveryServicesAsrReplicationProtectedItemDisk.md)
Add the disk for protection for already protected azure virtual machine.

### [Backup-AzRecoveryServicesBackupItem](Backup-AzRecoveryServicesBackupItem.md)
Starts a backup for a Backup item.

### [Copy-AzRecoveryServicesVault](Copy-AzRecoveryServicesVault.md)
Copies data from a vault in one region to a vault in another region.

### [Disable-AzRecoveryServicesBackupAutoProtection](Disable-AzRecoveryServicesBackupAutoProtection.md)
Disables auto backup for a protectable item.

### [Disable-AzRecoveryServicesBackupProtection](Disable-AzRecoveryServicesBackupProtection.md)
Disables protection for a Backup-protected item.

### [Disable-AzRecoveryServicesBackupRPMountScript](Disable-AzRecoveryServicesBackupRPMountScript.md)
Dismounts all the files of the recovery point.

### [Edit-AzRecoveryServicesAsrRecoveryPlan](Edit-AzRecoveryServicesAsrRecoveryPlan.md)
Edits a Site Recovery plan.

### [Enable-AzRecoveryServicesBackupAutoProtection](Enable-AzRecoveryServicesBackupAutoProtection.md)
The **Enable-AzRecoveryServicesBackupAutoProtection** cmdlet sets up automatic protection of current and any future SQL DBs within the given instance with the supplied policy.

### [Enable-AzRecoveryServicesBackupProtection](Enable-AzRecoveryServicesBackupProtection.md)
Enables backup for an item with a specified Backup protection policy.

### [Get-AzRecoveryServicesAsrAlertSetting](Get-AzRecoveryServicesAsrAlertSetting.md)
Gets the configured Azure Site Recovery notification settings for the vault.

### [Get-AzRecoveryServicesAsrEvent](Get-AzRecoveryServicesAsrEvent.md)
Gets details of Azure Site Recovery events in the vault.

### [Get-AzRecoveryServicesAsrFabric](Get-AzRecoveryServicesAsrFabric.md)
Get the details of an Azure Site Recovery Fabric.

### [Get-AzRecoveryServicesAsrJob](Get-AzRecoveryServicesAsrJob.md)
Gets the details of the specified ASR job or the list of recent ASR jobs in the Recovery Services vault.

### [Get-AzRecoveryServicesAsrNetwork](Get-AzRecoveryServicesAsrNetwork.md)
Gets information about the networks managed by Site Recovery for the current vault.

### [Get-AzRecoveryServicesAsrNetworkMapping](Get-AzRecoveryServicesAsrNetworkMapping.md)
Gets information about Site Recovery network mappings for the current vault.

### [Get-AzRecoveryServicesAsrPolicy](Get-AzRecoveryServicesAsrPolicy.md)
Gets ASR replication policies.

### [Get-AzRecoveryServicesAsrProtectableItem](Get-AzRecoveryServicesAsrProtectableItem.md)
Get the protectable items in an ASR protection container.

### [Get-AzRecoveryServicesAsrProtectionContainer](Get-AzRecoveryServicesAsrProtectionContainer.md)
Gets ASR protection containers in the Recovery Services vault.

### [Get-AzRecoveryServicesAsrProtectionContainerMapping](Get-AzRecoveryServicesAsrProtectionContainerMapping.md)
Gets Azure Site Recovery Protection Container mappings.

### [Get-AzRecoveryServicesAsrRecoveryPlan](Get-AzRecoveryServicesAsrRecoveryPlan.md)
Gets a recovery plan or all the recovery plans in the Recovery Services vault

### [Get-AzRecoveryServicesAsrRecoveryPoint](Get-AzRecoveryServicesAsrRecoveryPoint.md)
Gets the available recovery points for a replication protected item.

### [Get-AzRecoveryServicesAsrReplicationProtectedItem](Get-AzRecoveryServicesAsrReplicationProtectedItem.md)
Gets the properties of an Azure Site Recovery Replication Protected Items.

### [Get-AzRecoveryServicesAsrServicesProvider](Get-AzRecoveryServicesAsrServicesProvider.md)
Gets the details of the ASR recovery services providers registered to the Recovery Services vault.

### [Get-AzRecoveryServicesAsrStorageClassification](Get-AzRecoveryServicesAsrStorageClassification.md)
Gets the available(discovered) ASR storage classifications in the Recovery Services vault.

### [Get-AzRecoveryServicesAsrStorageClassificationMapping](Get-AzRecoveryServicesAsrStorageClassificationMapping.md)
Gets ASR storage classification mappings.

### [Get-AzRecoveryServicesAsrVaultContext](Get-AzRecoveryServicesAsrVaultContext.md)
Gets ASR vault settings information for the Recovery Services vault.

### [Get-AzRecoveryServicesAsrvCenter](Get-AzRecoveryServicesAsrvCenter.md)
Gets details of the vCenter servers registered for discovery on the Configuration server specified by the ASR fabric.

### [Get-AzRecoveryServicesBackupContainer](Get-AzRecoveryServicesBackupContainer.md)
Gets Backup containers.

### [Get-AzRecoveryServicesBackupItem](Get-AzRecoveryServicesBackupItem.md)
Gets the items from a container in Backup.

### [Get-AzRecoveryServicesBackupJob](Get-AzRecoveryServicesBackupJob.md)
Gets Backup jobs.

### [Get-AzRecoveryServicesBackupJobDetail](Get-AzRecoveryServicesBackupJobDetail.md)
Gets details for a Backup job.

### [Get-AzRecoveryServicesBackupManagementServer](Get-AzRecoveryServicesBackupManagementServer.md)
Gets SCDPM and Azure Backup management servers.

### [Get-AzRecoveryServicesBackupProperty](Get-AzRecoveryServicesBackupProperty.md)
Gets Backup properties.

### [Get-AzRecoveryServicesBackupProtectableItem](Get-AzRecoveryServicesBackupProtectableItem.md)
This command will retrieve all protectable items within a certain container or across all registered containers. It will consist of all the elements of the hierarchy of the application. Returns DBs and their upper tier entities like Instance, AvailabilityGroup etc.

### [Get-AzRecoveryServicesBackupProtectionPolicy](Get-AzRecoveryServicesBackupProtectionPolicy.md)
Gets Backup protection policies for a vault.

### [Get-AzRecoveryServicesBackupRecoveryLogChain](Get-AzRecoveryServicesBackupRecoveryLogChain.md)
This command lists the start and end points of the unbroken log chain of the given backup item. Use it to determine whether the point-in-time, to which the user wants the DB to be restored, is valid or not.

### [Get-AzRecoveryServicesBackupRecoveryPoint](Get-AzRecoveryServicesBackupRecoveryPoint.md)
Gets the recovery points for a backed up item.

### [Get-AzRecoveryServicesBackupRetentionPolicyObject](Get-AzRecoveryServicesBackupRetentionPolicyObject.md)
Gets a base retention policy object.

### [Get-AzRecoveryServicesBackupRPMountScript](Get-AzRecoveryServicesBackupRPMountScript.md)
Downloads a script to mount all the files of the recovery point.

### [Get-AzRecoveryServicesBackupSchedulePolicyObject](Get-AzRecoveryServicesBackupSchedulePolicyObject.md)
Gets a base schedule policy object.

### [Get-AzRecoveryServicesBackupStatus](Get-AzRecoveryServicesBackupStatus.md)
Checks whether your ARM resource is backed up or not.

### [Get-AzRecoveryServicesBackupWorkloadRecoveryConfig](Get-AzRecoveryServicesBackupWorkloadRecoveryConfig.md)
This command constructs the recovery configuration of a backed up item such as SQL DB. The configuration object stores all details such as the recovery mode, target destinations for the restore and application specific parameters like target physical paths for SQL.

### [Get-AzRecoveryServicesVault](Get-AzRecoveryServicesVault.md)
Gets a list of Recovery Services vaults.

### [Get-AzRecoveryServicesVaultProperty](Get-AzRecoveryServicesVaultProperty.md)
Returns the properties of a Recovery Services Vault.

### [Get-AzRecoveryServicesVaultSettingsFile](Get-AzRecoveryServicesVaultSettingsFile.md)
Gets the Azure Site Recovery vault settings file.

### [Import-AzRecoveryServicesAsrVaultSettingsFile](Import-AzRecoveryServicesAsrVaultSettingsFile.md)
Imports the specified ASR vault settings file to set the vault context(PowerShell session context) for subsequent ASR operations in the PowerShell session. 

### [Initialize-AzRecoveryServicesBackupProtectableItem](Initialize-AzRecoveryServicesBackupProtectableItem.md)
This command triggers the discovery of any unprotected items of the given workload type in the given container. If the DB application is not auto-protected use this command to discover new DBs whenever they are added and proceed to protect them.

### [New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig](New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig.md)
Creates a disk mapping object for Azure virtual machine disks to be replicated.

### [New-AzRecoveryServicesAsrFabric](New-AzRecoveryServicesAsrFabric.md)
Creates an Azure Site Recovery Fabric.

### [New-AzRecoveryServicesAsrInMageAzureV2DiskInput](New-AzRecoveryServicesAsrInMageAzureV2DiskInput.md)
Creates a disk mapping object for vMWare virtual machine disks to be replicated.

### [New-AzRecoveryServicesAsrNetworkMapping](New-AzRecoveryServicesAsrNetworkMapping.md)
Creates an ASR network mapping between two networks.

### [New-AzRecoveryServicesAsrPolicy](New-AzRecoveryServicesAsrPolicy.md)
Creates an Azure Site Recovery replication policy.

### [New-AzRecoveryServicesAsrProtectableItem](New-AzRecoveryServicesAsrProtectableItem.md)
Add(Discover) a physical server to the list of protectable items.

### [New-AzRecoveryServicesAsrProtectionContainer](New-AzRecoveryServicesAsrProtectionContainer.md)
Creates an Azure Site Recovery Protection Container within the specified fabric.

### [New-AzRecoveryServicesAsrProtectionContainerMapping](New-AzRecoveryServicesAsrProtectionContainerMapping.md)
Creates an Azure Site Recovery Protection Container mapping by associating the specified replication policy to the specified ASR protection container.

### [New-AzRecoveryServicesAsrRecoveryPlan](New-AzRecoveryServicesAsrRecoveryPlan.md)
Creates an ASR recovery plan.

### [New-AzRecoveryServicesAsrReplicationProtectedItem](New-AzRecoveryServicesAsrReplicationProtectedItem.md)
Enables replication for an ASR protectable item by creating a replication protected item.

### [New-AzRecoveryServicesAsrStorageClassificationMapping](New-AzRecoveryServicesAsrStorageClassificationMapping.md)
Creates an ASR storage classification mapping in the Recovery Services vault.

### [New-AzRecoveryServicesAsrvCenter](New-AzRecoveryServicesAsrvCenter.md)
Adds a vCenter server to discover protectable items from.

### [New-AzRecoveryServicesBackupProtectionPolicy](New-AzRecoveryServicesBackupProtectionPolicy.md)
Creates a Backup protection policy.

### [New-AzRecoveryServicesVault](New-AzRecoveryServicesVault.md)
Creates a new Recovery Services vault.

### [Register-AzRecoveryServicesBackupContainer](Register-AzRecoveryServicesBackupContainer.md)
The **Register-AzRecoveryServicesBackupContainer** cmdlet registers an Azure VM for AzureWorkloads with specific workloadType.

### [Remove-AzRecoveryServicesAsrFabric](Remove-AzRecoveryServicesAsrFabric.md)
Deletes the specified Azure Site Recovery Fabric from the Recovery Services vault.

### [Remove-AzRecoveryServicesAsrNetworkMapping](Remove-AzRecoveryServicesAsrNetworkMapping.md)
Deletes the specified ASR network mapping from the Recovery Services vault.

### [Remove-AzRecoveryServicesAsrPolicy](Remove-AzRecoveryServicesAsrPolicy.md)
Deletes the specified ASR replication policy from the Recovery Services vault.

### [Remove-AzRecoveryServicesAsrProtectionContainer](Remove-AzRecoveryServicesAsrProtectionContainer.md)
Deletes the specified Protection Container from its Fabric.

### [Remove-AzRecoveryServicesAsrProtectionContainerMapping](Remove-AzRecoveryServicesAsrProtectionContainerMapping.md)
Deletes the specified Azure Site Recovery protection container mapping.

### [Remove-AzRecoveryServicesAsrRecoveryPlan](Remove-AzRecoveryServicesAsrRecoveryPlan.md)
Deletes the specified ASR recovery plan from Recovery Services vault.

### [Remove-AzRecoveryServicesAsrReplicationProtectedItem](Remove-AzRecoveryServicesAsrReplicationProtectedItem.md)
Stops/Disables replication for an Azure Site Recovery replication protected item.

### [Remove-AzRecoveryServicesAsrServicesProvider](Remove-AzRecoveryServicesAsrServicesProvider.md)
Deletes/unregister the specified Azure Site Recovery recovery services provider from the recovery services vault.

### [Remove-AzRecoveryServicesAsrStorageClassificationMapping](Remove-AzRecoveryServicesAsrStorageClassificationMapping.md)
Deletes the specified ASR storage classification mapping.

### [Remove-AzRecoveryServicesAsrvCenter](Remove-AzRecoveryServicesAsrvCenter.md)
Removes the vCenter server from the ASR fabric and stops discovery of virtual machines from the vCenter server.

### [Remove-AzRecoveryServicesBackupProtectionPolicy](Remove-AzRecoveryServicesBackupProtectionPolicy.md)
Deletes a Backup protection policy from a vault.

### [Remove-AzRecoveryServicesVault](Remove-AzRecoveryServicesVault.md)
Deletes a Recovery Services vault.

### [Restart-AzRecoveryServicesAsrJob](Restart-AzRecoveryServicesAsrJob.md)
Restarts an Azure Site Recovery job.

### [Restore-AzRecoveryServicesBackupItem](Restore-AzRecoveryServicesBackupItem.md)
Restores the data and configuration for a Backup item to a recovery point.

### [Resume-AzRecoveryServicesAsrJob](Resume-AzRecoveryServicesAsrJob.md)
Resumes a suspended Azure Site Recovery job.

### [Set-AzRecoveryServicesAsrAlertSetting](Set-AzRecoveryServicesAsrAlertSetting.md)
Configure Azure Site Recovery notification settings (email notification) for the vault.

### [Set-AzRecoveryServicesAsrReplicationProtectedItem](Set-AzRecoveryServicesAsrReplicationProtectedItem.md)
Sets recovery properties such as target network and virtual machine size for the specified replication protected item.

### [Set-AzRecoveryServicesAsrVaultContext](Set-AzRecoveryServicesAsrVaultContext.md)
Sets the Recovery Services vault context to be used for subsequent Azure Site Recovery operations in the current PowerShell session.

### [Set-AzRecoveryServicesBackupProperty](Set-AzRecoveryServicesBackupProperty.md)
Sets the properties for backup management.

### [Set-AzRecoveryServicesBackupProtectionPolicy](Set-AzRecoveryServicesBackupProtectionPolicy.md)
Modifies a Backup protection policy.

### [Set-AzRecoveryServicesVaultContext](Set-AzRecoveryServicesVaultContext.md)
Sets vault context.

### [Set-AzRecoveryServicesVaultProperty](Set-AzRecoveryServicesVaultProperty.md)
Updates properties of a Vault.

### [Start-AzRecoveryServicesAsrApplyRecoveryPoint](Start-AzRecoveryServicesAsrApplyRecoveryPoint.md)
Changes a recovery point for a failed over protected item before committing the failover operation.

### [Start-AzRecoveryServicesAsrCommitFailoverJob](Start-AzRecoveryServicesAsrCommitFailoverJob.md)
Starts the commit failover action for a Site Recovery object.

### [Start-AzRecoveryServicesAsrPlannedFailoverJob](Start-AzRecoveryServicesAsrPlannedFailoverJob.md)
Starts a planned failover operation.

### [Start-AzRecoveryServicesAsrResynchronizeReplicationJob](Start-AzRecoveryServicesAsrResynchronizeReplicationJob.md)
Starts replication resynchronization.

### [Start-AzRecoveryServicesAsrSwitchProcessServerJob](Start-AzRecoveryServicesAsrSwitchProcessServerJob.md)
Switch replication from one Process server to another for load balancing.

### [Start-AzRecoveryServicesAsrTestFailoverCleanupJob](Start-AzRecoveryServicesAsrTestFailoverCleanupJob.md)
Starts the test failover cleanup operation.

### [Start-AzRecoveryServicesAsrTestFailoverJob](Start-AzRecoveryServicesAsrTestFailoverJob.md)
Starts a test failover operation.

### [Start-AzRecoveryServicesAsrUnplannedFailoverJob](Start-AzRecoveryServicesAsrUnplannedFailoverJob.md)
Starts a unplanned failover operation.

### [Stop-AzRecoveryServicesAsrJob](Stop-AzRecoveryServicesAsrJob.md)
Stops an Azure Site Recovery job.

### [Stop-AzRecoveryServicesBackupJob](Stop-AzRecoveryServicesBackupJob.md)
Cancels a running job.

### [Undo-AzRecoveryServicesBackupItemDeletion](Undo-AzRecoveryServicesBackupItemDeletion.md)
If a backup item is deleted and present in a soft-deleted state, this command brings the item back to a state where the data is retained forever 

### [Unregister-AzRecoveryServicesBackupContainer](Unregister-AzRecoveryServicesBackupContainer.md)
Unregisters a Windows Server or other container from the vault.

### [Unregister-AzRecoveryServicesBackupManagementServer](Unregister-AzRecoveryServicesBackupManagementServer.md)
Unregisters a SCDPM server or Backup server from the vault.

### [Update-AzRecoveryServicesAsrMobilityService](Update-AzRecoveryServicesAsrMobilityService.md)
Push mobility service agent updates to protected machines.

### [Update-AzRecoveryServicesAsrNetworkMapping](Update-AzRecoveryServicesAsrNetworkMapping.md)
Updates the specified azure site recovery network mapping.

### [Update-AzRecoveryServicesAsrPolicy](Update-AzRecoveryServicesAsrPolicy.md)
Updates an Azure Site Recovery replication policy.

### [Update-AzRecoveryServicesAsrProtectionContainerMapping](Update-AzRecoveryServicesAsrProtectionContainerMapping.md)
Update the Azure site recovery protection container mapping.

### [Update-AzRecoveryServicesAsrProtectionDirection](Update-AzRecoveryServicesAsrProtectionDirection.md)
Updates the replication direction for the specified replication protected item or recovery plan. Used to re-protect/reverse replicate a failed over replicated item or recovery plan.

### [Update-AzRecoveryServicesAsrRecoveryPlan](Update-AzRecoveryServicesAsrRecoveryPlan.md)
Updates the contents of an Azure Site recovery plan.

### [Update-AzRecoveryServicesAsrServicesProvider](Update-AzRecoveryServicesAsrServicesProvider.md)
Refreshes (Refresh server) the information received from the Azure Site Recovery Services Provider.

### [Update-AzRecoveryServicesAsrvCenter](Update-AzRecoveryServicesAsrvCenter.md)
Update discovery details for a registered vCenter.

### [Wait-AzRecoveryServicesBackupJob](Wait-AzRecoveryServicesBackupJob.md)
Waits for a Backup job to finish.

