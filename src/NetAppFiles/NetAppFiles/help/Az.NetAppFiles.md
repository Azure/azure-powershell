---
Module Name: Az.NetAppFiles
Module Guid: e20e99dc-6df9-479b-8504-2960f0088f00
Download Help Link: https://docs.microsoft.com/powershell/module/az.netappfiles
Help Version: 1.0.0.0
Locale: en-US
---

# Az.NetAppFiles Module
## Description
The topics in this section document the Azure PowerShell cmdlets for Azure NetApp Files in the Azure Resource Manager (ARM) framework. The cmdlets exist in the Microsoft.Azure.Commands.NetAppFiles namespace.

## Az.NetAppFiles Cmdlets
### [Approve-AzNetAppFilesReplication](Approve-AzNetAppFilesReplication.md)
Approve/Authorize replication connection on the source volume

### [Get-AzNetAppFilesAccount](Get-AzNetAppFilesAccount.md)
Gets details of an Azure NetApp Files (ANF) account.

### [Get-AzNetAppFilesActiveDirectory](Get-AzNetAppFilesActiveDirectory.md)
Gets details of an Azure NetApp Files (ANF) Active Directory configuration.

### [Get-AzNetAppFilesBackup](Get-AzNetAppFilesBackup.md)
Gets details of an Azure NetApp Files (ANF) Backup.

### [Get-AzNetAppFilesBackupPolicy](Get-AzNetAppFilesBackupPolicy.md)
Gets details of an Azure NetApp Files (ANF) Backup Policy.

### [Get-AzNetAppFilesPool](Get-AzNetAppFilesPool.md)
Gets details of an Azure NetApp Files (ANF) pool.

### [Get-AzNetAppFilesQuotaLimit](Get-AzNetAppFilesQuotaLimit.md)
Get quota limits

### [Get-AzNetAppFilesReplicationStatus](Get-AzNetAppFilesReplicationStatus.md)
Get the status of the replication

### [Get-AzNetAppFilesSnapshot](Get-AzNetAppFilesSnapshot.md)
Gets details of an Azure NetApp Files (ANF) snapshot.

### [Get-AzNetAppFilesSnapshotPolicy](Get-AzNetAppFilesSnapshotPolicy.md)
Gets details of an Azure NetApp Files (ANF) snapshot policy.

### [Get-AzNetAppFilesSubvolume](Get-AzNetAppFilesSubvolume.md)
Gets details of an Azure NetApp Files (ANF) subvolume.

### [Get-AzNetAppFilesSubvolumeMetadata](Get-AzNetAppFilesSubvolumeMetadata.md)
Gets metadata details of an Azure NetApp Files (ANF) subvolume.

### [Get-AzNetAppFilesVault](Get-AzNetAppFilesVault.md)
Gets list of Azure NetApp Files (ANF) Accounts backup vaults.

### [Get-AzNetAppFilesVolume](Get-AzNetAppFilesVolume.md)
Gets details of an Azure NetApp Files (ANF) volume.

### [Get-AzNetAppFilesVolumeBackupStatus](Get-AzNetAppFilesVolumeBackupStatus.md)
Get volume's backup status

### [Get-AzNetAppFilesVolumeGroup](Get-AzNetAppFilesVolumeGroup.md)
Gets details of an Azure NetApp Files (ANF) VolumeGroup.

### [Get-AzNetAppFilesVolumeRestoreStatus](Get-AzNetAppFilesVolumeRestoreStatus.md)
Get volume's restore status

### [Initialize-AzNetAppFilesReplication](Initialize-AzNetAppFilesReplication.md)
Re-Initializes the replication connection on the destination volume

### [New-AzExportPolicyObject](New-AzExportPolicyObject.md)
Creates export policy object.

### [New-AzExportPolicyRuleObject](New-AzExportPolicyRuleObject.md)
Creates export policy rule object.

### [New-AzNetAppFilesAccount](New-AzNetAppFilesAccount.md)
Creates a new Azure NetApp Files (ANF) account.

### [New-AzNetAppFilesActiveDirectory](New-AzNetAppFilesActiveDirectory.md)
Creates a new Azure NetApp Files (ANF) active directory configuration.

### [New-AzNetAppFilesBackup](New-AzNetAppFilesBackup.md)
Creates a new Azure NetApp Files (ANF) backup.

### [New-AzNetAppFilesBackupPolicy](New-AzNetAppFilesBackupPolicy.md)
Creates a new Azure NetApp Files (ANF) backup policy for an ANF account.

### [New-AzNetAppFilesPool](New-AzNetAppFilesPool.md)
Creates a new Azure NetApp Files (ANF) pool.

### [New-AzNetAppFilesSnapshot](New-AzNetAppFilesSnapshot.md)
Creates a new Azure NetApp Files (ANF) snapshot.

### [New-AzNetAppFilesSnapshotPolicy](New-AzNetAppFilesSnapshotPolicy.md)
Creates a new Azure NetApp Files (ANF) snapshot policy for an ANF account.

### [New-AzNetAppFilesSubvolume](New-AzNetAppFilesSubvolume.md)
Creates a new Azure NetApp Files (ANF) subvolume.

### [New-AzNetAppFilesVolume](New-AzNetAppFilesVolume.md)
Creates a new Azure NetApp Files (ANF) volume.

### [New-AzNetAppFilesVolumeGroup](New-AzNetAppFilesVolumeGroup.md)
Creates a new Azure NetApp Files (ANF) VolumeGroup along with requisite volumes.
Creating volume group will create all the volumes specified in request body implicitly. Once volumes are created using volume group, those will be treated as regular volumes thereafter.

### [Remove-AzNetAppFilesAccount](Remove-AzNetAppFilesAccount.md)
Deletes an Azure NetApp Files (ANF) account.

### [Remove-AzNetAppFilesActiveDirectory](Remove-AzNetAppFilesActiveDirectory.md)
Deletes an Azure NetApp Files (ANF) active directory configuration.

### [Remove-AzNetAppFilesBackup](Remove-AzNetAppFilesBackup.md)
Deletes an Azure NetApp Files (ANF) backup.

### [Remove-AzNetAppFilesBackupPolicy](Remove-AzNetAppFilesBackupPolicy.md)
Deletes an Azure NetApp Files (ANF) backup policy.

### [Remove-AzNetAppFilesPool](Remove-AzNetAppFilesPool.md)
Deletes an Azure NetApp Files (ANF) pool.

### [Remove-AzNetAppFilesReplication](Remove-AzNetAppFilesReplication.md)
Remove/Delete the replication connection on the destination volume, and send release to the source replication

### [Remove-AzNetAppFilesSnapshot](Remove-AzNetAppFilesSnapshot.md)
Deletes an Azure NetApp Files (ANF) snapshot.

### [Remove-AzNetAppFilesSnapshotPolicy](Remove-AzNetAppFilesSnapshotPolicy.md)
Deletes an Azure NetApp Files (ANF) snapshot policy.

### [Remove-AzNetAppFilesSubvolume](Remove-AzNetAppFilesSubvolume.md)
Deletes an Azure NetApp Files (ANF) subvolume.

### [Remove-AzNetAppFilesVolume](Remove-AzNetAppFilesVolume.md)
Deletes an Azure NetApp Files (ANF) volume.

### [Remove-AzNetAppFilesVolumeGroup](Remove-AzNetAppFilesVolumeGroup.md)
Deletes an Azure NetApp Files (ANF) VolumeGroup. This delete the specified volume group only does not delete the volumes.

### [Restore-AzNetAppFilesVolume](Restore-AzNetAppFilesVolume.md)
Restore/Revert a volume to one of its snapshots

### [Resume-AzNetAppFilesReplication](Resume-AzNetAppFilesReplication.md)
Resume/Resync the connection on the destination volume. If the operation is ran on the source volume it will reverse-resync the connection and sync from source to destination.

### [Set-AzNetAppFilesAccount](Set-AzNetAppFilesAccount.md)
Updates an Azure NetApp Files (ANF) account with the new data set. Useful for deletion of associated active directories.

### [Set-AzNetAppFilesBackupPolicy](Set-AzNetAppFilesBackupPolicy.md)
Updates an Azure NetApp Files (ANF) Backup Policy with the new data set. 

### [Set-AzNetAppFilesPool](Set-AzNetAppFilesPool.md)
Updates an Azure NetApp Files (ANF) Capacity Pool with the new data set. 

### [Set-AzNetAppFilesSnapshotPolicy](Set-AzNetAppFilesSnapshotPolicy.md)
Updates an Azure NetApp Files (ANF) Snapshot Policy with the new data set. 

### [Set-AzNetAppFilesVolumePool](Set-AzNetAppFilesVolumePool.md)
Change pool for an Azure NetApp Files (ANF) volume.

### [Suspend-AzNetAppFilesReplication](Suspend-AzNetAppFilesReplication.md)
Suspend/break the replication connection on the destination volume

### [Update-AzNetAppFilesAccount](Update-AzNetAppFilesAccount.md)
Updates an Azure NetApp Files (ANF) account according to the optional modifiers provided.

### [Update-AzNetAppFilesActiveDirectory](Update-AzNetAppFilesActiveDirectory.md)
Updates an Azure NetApp Files (ANF) active directory configuration to the optional modifiers provided.

### [Update-AzNetAppFilesBackup](Update-AzNetAppFilesBackup.md)
Updates an Azure NetApp Files (ANF) backup to the optional modifiers provided.

### [Update-AzNetAppFilesBackupPolicy](Update-AzNetAppFilesBackupPolicy.md)
Updates an Azure NetApp Files (ANF) backup policy to the optional modifiers provided.

### [Update-AzNetAppFilesPool](Update-AzNetAppFilesPool.md)
Updates an Azure NetApp Files (ANF) pool according to the optional modifiers provided.

### [Update-AzNetAppFilesSnapshotPolicy](Update-AzNetAppFilesSnapshotPolicy.md)
Updates an Azure NetApp Files (ANF) snapshot policy to the optional modifiers provided.

### [Update-AzNetAppFilesSubvolume](Update-AzNetAppFilesSubvolume.md)
Updates an Azure NetApp Files (ANF) subvolume according to the optional modifiers provided.

### [Update-AzNetAppFilesVolume](Update-AzNetAppFilesVolume.md)
Updates an Azure NetApp Files (ANF) volume according to the optional modifiers provided.

